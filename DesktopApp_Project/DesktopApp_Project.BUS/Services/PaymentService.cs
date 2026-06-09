// Dịch vụ xử lý nghiệp vụ thanh toán
// Chức năng:
// - Nhận dữ liệu từ giao diện dưới dạng đối tượng truyền dữ liệu hoặc tham số lọc
// - Kiểm tra nghiệp vụ trước khi gọi tầng dữ liệu
// - Trả kết quả xử lý hoặc danh sách đối tượng truyền dữ liệu cho giao diện

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DesktopApp_Project.Common;
using DesktopApp_Project.DAL;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.BUS
{
    // Lớp xử lý nghiệp vụ thanh toán, kiểm tra dữ liệu trước khi gọi kho dữ liệu/tầng dữ liệu.
    public class PaymentService : ServiceBase
    {
        private static readonly Random DemoRandom = new Random();
        private static readonly object DemoRandomLock = new object();
        private readonly VnpayUrlService _vnpayUrlService;
        private readonly PaymentEmailService _emailService;

        public PaymentService(IQuanLyIeltsRepository repository) : base(repository)
        {
            _vnpayUrlService = new VnpayUrlService();
            _emailService = new PaymentEmailService();
        }

        // Tạo thanh toán.
        public ServiceResult<PaymentResultDTO> TaoThanhToan(PaymentRequestDTO request)
        {
            return Try(() =>
            {
                // Ràng buộc dữ liệu: Vui lòng chọn phiếu học phí.
                if (request == null || request.MaThanhToan <= 0)
                {
                    return ServiceResult<PaymentResultDTO>.Fail("Vui long chon phieu hoc phi.");
                }

                if (!AppConstants.PaymentMethods.Contains(request.PhuongThuc))
                {
                    return ServiceResult<PaymentResultDTO>.Fail("Phuong thuc thanh toan khong hop le.");
                }

                // Lấy hóa đơn học phí theo mã thanh toán qua tầng dữ liệu.
                var invoice = Repository.LayHoaDonHocPhi(request.MaThanhToan);
                if (invoice == null)
                {
                    return ServiceResult<PaymentResultDTO>.Fail("Khong tim thay phieu hoc phi.");
                }

                request.SoTien = request.SoTien <= 0 ? (invoice.SoTienCuoi.HasValue ? invoice.SoTienCuoi.Value : invoice.SoTien) : request.SoTien;
                request.NoiDungThanhToan = string.IsNullOrWhiteSpace(request.NoiDungThanhToan)
                    ? "Thanh toan hoc phi " + LayMaHoaDon(invoice)
                    : request.NoiDungThanhToan.Trim();

                if (request.PhuongThuc == AppConstants.PaymentMethodVNPay)
                {
                    return TaoThanhToanVnpay(request, invoice);
                }

                var prefix = "MOMO";
                var externalId = prefix + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + request.MaThanhToan;
                var paymentUrl = "https://fake-payment.local/" + prefix.ToLowerInvariant() + "?txn=" + Uri.EscapeDataString(externalId);
                var qrContent = prefix + "|" + request.MaThanhToan + "|" + request.SoTien.ToString("0") + "|" + externalId;

                // Tạo nhật ký giao dịch thanh toán qua tầng dữ liệu.
                var result = Repository.TaoNhatKyThanhToan(request, externalId, paymentUrl, qrContent);
                // Cập nhật trạng thái và phương thức thanh toán học phí qua tầng dữ liệu.
                Repository.CapNhatTrangThaiHocPhi(request.MaThanhToan, AppConstants.PaymentPending, null, null);
                return ServiceResult<PaymentResultDTO>.Ok(result, "Da tao thanh toan gia lap.");
            });
        }

        // Xử lý gửi thông tin học phí.
        public ServiceResult<PaymentResultDTO> GuiThongTinHocPhi(int maThanhToan)
        {
            return Try(() =>
            {
                var outcome = SendTuitionPaymentInfo(maThanhToan);
                return outcome.Success
                    ? ServiceResult<PaymentResultDTO>.Ok(outcome.PaymentResult, "Đã gửi thông tin học phí thành công.")
                    : FailGuiHocPhi(outcome.Message);
            });
        }

        // Xử lý gửi học phí hàng loạt.
        public ServiceResult<BatchSendTuitionResultDTO> GuiHocPhiHangLoat(List<int> hocPhiIds)
        {
            return Try(() =>
            {
                var ids = (hocPhiIds ?? new List<int>())
                    .Where(x => x > 0)
                    .Distinct()
                    .ToList();

                if (ids.Count == 0)
                {
                    return ServiceResult<BatchSendTuitionResultDTO>.Fail("Vui lòng chọn ít nhất một học phí để gửi.");
                }

                var result = new BatchSendTuitionResultDTO { TotalCount = ids.Count };
                foreach (var id in ids)
                {
                    var outcome = SendTuitionPaymentInfo(id);
                    result.Items.Add(new BatchSendTuitionItemResultDTO
                    {
                        HocPhiId = id,
                        HocVienName = outcome.StudentName,
                        Email = outcome.Email,
                        Success = outcome.Success,
                        Message = outcome.Success ? "Đã gửi thông tin học phí thành công." : outcome.Message
                    });
                }

                result.SuccessCount = result.Items.Count(x => x.Success);
                result.FailedCount = result.TotalCount - result.SuccessCount;

                var message = "Đã gửi thành công " + result.SuccessCount + "/" + result.TotalCount
                    + " học phí. Thất bại: " + result.FailedCount + ".";
                if (result.FailedCount > 0)
                {
                    message += " Một số học phí gửi thất bại. Vui lòng xem chi tiết.";
                }

                return new ServiceResult<BatchSendTuitionResultDTO>
                {
                    Success = result.FailedCount == 0,
                    Data = result,
                    Message = message
                };
            });
        }

        // Gửi thông tin thanh toán học phí cho một hoặc nhiều học viên.
        private TuitionSendOutcome SendTuitionPaymentInfo(int maThanhToan)
        {
            var outcome = new TuitionSendOutcome { TuitionPaymentId = maThanhToan };
            try
            {
                if (maThanhToan <= 0)
                {
                    outcome.Message = "Vui lòng chọn phiếu học phí.";
                    return outcome;
                }

                // Lấy hóa đơn học phí theo mã thanh toán qua tầng dữ liệu.
                var invoice = Repository.LayHoaDonHocPhi(maThanhToan);
                if (invoice == null)
                {
                    outcome.Message = "Không tìm thấy thông tin học phí đã chọn.";
                    return outcome;
                }

                // Lấy thông tin người dùng theo mã qua tầng dữ liệu.
                var student = Repository.GetNguoiDungById(invoice.MaNguoiDung);
                outcome.StudentName = student == null ? invoice.HoTen : student.HoTen;
                outcome.Email = student == null ? string.Empty : student.Email;

                if (student == null)
                {
                    outcome.Message = "Không tìm thấy học viên.";
                    return outcome;
                }

                if (!ValidationHelper.IsValidEmail(student.Email))
                {
                    outcome.Message = "Email học viên không hợp lệ hoặc đang trống.";
                    return outcome;
                }

                var amount = invoice.SoTienCuoi.HasValue ? invoice.SoTienCuoi.Value : invoice.SoTien;
                if (amount <= 0)
                {
                    outcome.Message = "Số tiền học phí không hợp lệ.";
                    return outcome;
                }

                // Lấy các giao dịch của khoản học phí qua tầng dữ liệu.
                var reusable = Repository.LayGiaoDichTheoThanhToan(maThanhToan)
                    .FirstOrDefault(IsReusablePaymentTransaction);
                if (reusable == null)
                {
                    var created = TaoThanhToanVnpay(new PaymentRequestDTO
                    {
                        MaThanhToan = maThanhToan,
                        SoTien = amount,
                        PhuongThuc = AppConstants.PaymentMethodVNPay,
                        NoiDungThanhToan = "Thanh toán học phí " + LayMaHoaDon(invoice),
                        EmailNguoiNhan = student.Email.Trim()
                    }, invoice);

                    if (!created.Success)
                    {
                        outcome.Message = SafeReason(created.Message);
                        outcome.PaymentResult = created.Data;
                        return outcome;
                    }

                    outcome.Success = true;
                    outcome.Message = "Đã gửi thông tin học phí thành công.";
                    outcome.PaymentResult = created.Data;
                    return outcome;
                }

                var detail = BuildPaymentEmailDetail(invoice, student, reusable);
                var email = TrySendPaymentRequest(detail);
                // Lấy giao dịch thanh toán theo mã qua tầng dữ liệu.
                var refreshed = Repository.LayGiaoDichThanhToan(reusable.MaGiaoDich) ?? reusable;

                if (!email.Success)
                {
                    outcome.Message = SafeReason(email.Error);
                    outcome.PaymentResult = refreshed;
                    return outcome;
                }

                outcome.Success = true;
                outcome.Message = "Đã gửi thông tin học phí thành công.";
                outcome.PaymentResult = refreshed;
                return outcome;
            }
            catch (Exception ex)
            {
                outcome.Message = SafeReason(ex.Message);
                return outcome;
            }
        }

        // Tạo chi tiết thư thanh toán.
        private static PaymentDebugResultDTO BuildPaymentEmailDetail(
            HoaDonHocPhiDTO invoice,
            NguoiDungDTO student,
            PaymentResultDTO transaction)
        {
            return new PaymentDebugResultDTO
            {
                TransactionId = transaction.MaGiaoDich,
                TuitionPaymentId = transaction.MaThanhToan,
                ExternalTransactionRef = transaction.MaGiaoDichNgoai,
                StudentName = student.HoTen,
                ReceiverEmail = student.Email,
                ClassName = invoice.TenLop,
                InvoiceCode = LayMaHoaDon(invoice),
                Amount = transaction.SoTien,
                PaymentMethod = transaction.PhuongThuc,
                PaymentUrl = transaction.PaymentUrl,
                PaymentStatus = transaction.TrangThai,
                TuitionStatus = invoice.TrangThai,
                PaymentEmailSent = transaction.PaymentEmailSent,
                PaymentEmailSentAt = transaction.PaymentEmailSentAt,
                PaymentEmailError = transaction.PaymentEmailError,
                StatusEmailSent = transaction.StatusEmailSent,
                StatusEmailSentAt = transaction.StatusEmailSentAt,
                StatusEmailError = transaction.StatusEmailError,
                CreatedAt = transaction.NgayTao,
                UpdatedAt = transaction.NgayCapNhat,
                LastStatusUpdateAt = transaction.LastStatusUpdateAt
            };
        }

        // Xử lý giao dịch thanh toán còn có thể dùng lại.
        private static bool IsReusablePaymentTransaction(PaymentResultDTO transaction)
        {
            return transaction != null
                && !string.IsNullOrWhiteSpace(transaction.PaymentUrl)
                && !IsFinalPaymentStatus(transaction.TrangThai);
        }

        // Xử lý trạng thái thanh toán đã kết thúc.
        private static bool IsFinalPaymentStatus(string status)
        {
            return AppConstants.GetTextAliases(AppConstants.PaymentPaid).Contains(status)
                || AppConstants.GetTextAliases(AppConstants.PaymentExpired).Contains(status)
                || AppConstants.GetTextAliases(AppConstants.PaymentFailed).Contains(status)
                || AppConstants.GetTextAliases(AppConstants.PaymentCancelled).Contains(status);
        }

        // Xử lý lỗi khi gửi học phí.
        private static ServiceResult<PaymentResultDTO> FailGuiHocPhi(string reason)
        {
            return ServiceResult<PaymentResultDTO>.Fail("Gửi thông tin học phí thất bại: " + SafeReason(reason));
        }

        // Xử lý safe reason.
        private static string SafeReason(string reason)
        {
            // Ràng buộc dữ liệu: Vui lòng nhập thư điện tử người nhận hợp lệ.
            return string.IsNullOrWhiteSpace(reason) ? "Lỗi không xác định." : reason.Trim();
        }

        // Tạo thanh toán VNPay.
        private ServiceResult<PaymentResultDTO> TaoThanhToanVnpay(PaymentRequestDTO request, HoaDonHocPhiDTO invoice)
        {
            // Ràng buộc dữ liệu: Vui lòng nhập thư điện tử người nhận hợp lệ.
            if (!ValidationHelper.IsValidEmail(request.EmailNguoiNhan))
            {
                return ServiceResult<PaymentResultDTO>.Fail("Vui long nhap email nguoi nhan hop le.");
            }

            var txnRef = TaoMaGiaoDichDemo();
            var paymentUrl = _vnpayUrlService.BuildPaymentUrl(
                txnRef,
                request.SoTien,
                request.NoiDungThanhToan,
                "127.0.0.1");
            // Tạo nhật ký giao dịch thanh toán qua tầng dữ liệu.
            var result = Repository.TaoNhatKyThanhToan(request, txnRef, paymentUrl, paymentUrl);
            // Cập nhật trạng thái và phương thức thanh toán học phí qua tầng dữ liệu.
            Repository.CapNhatTrangThaiHocPhi(request.MaThanhToan, AppConstants.PaymentPending, null, null);

            var detail = new PaymentDebugResultDTO
            {
                TransactionId = result.MaGiaoDich,
                StudentName = invoice.HoTen,
                ReceiverEmail = request.EmailNguoiNhan,
                InvoiceCode = LayMaHoaDon(invoice),
                Amount = request.SoTien,
                PaymentUrl = paymentUrl
            };
            var email = TrySendPaymentRequest(detail);
            // Lấy giao dịch thanh toán theo mã qua tầng dữ liệu.
            result = Repository.LayGiaoDichThanhToan(result.MaGiaoDich) ?? result;

            if (!email.Success)
            {
                return WithData(false, result, "Da tao link thanh toan VNPAY sandbox nhung gui email that bai: " + email.Error);
            }

            return ServiceResult<PaymentResultDTO>.Ok(result, "Da tao thanh toan VNPAY sandbox va gui email.");
        }

        // Lấy giao dịch.
        public ServiceResult<PaymentResultDTO> LayGiaoDich(int maGiaoDich)
        {
            return Try(() =>
            {
                // Lấy giao dịch thanh toán theo mã qua tầng dữ liệu.
                var result = Repository.LayGiaoDichThanhToan(maGiaoDich);
                return result == null
                    ? ServiceResult<PaymentResultDTO>.Fail("Khong tim thay giao dich.")
                    : ServiceResult<PaymentResultDTO>.Ok(result, "OK");
            });
        }

        // Lấy các giao dịch của khoản học phí.
        public ServiceResult<List<PaymentResultDTO>> LayGiaoDichTheoThanhToan(int maThanhToan)
        {
            return Try(() => ServiceResult<List<PaymentResultDTO>>.Ok(Repository.LayGiaoDichTheoThanhToan(maThanhToan), "OK"));
        }

        // Xử lý xac nhan thanh toán.
        public ServiceResult XacNhanThanhToan(int maGiaoDich)
        {
            return Try(() =>
            {
                // Lấy giao dịch thanh toán theo mã qua tầng dữ liệu.
                var giaoDich = Repository.LayGiaoDichThanhToan(maGiaoDich);
                if (giaoDich == null)
                {
                    return ServiceResult.Fail("Khong tim thay giao dich.");
                }

                // Cập nhật trạng thái giao dịch qua tầng dữ liệu.
                Repository.CapNhatTrangThaiGiaoDich(maGiaoDich, AppConstants.PaymentPaid);
                // Cập nhật trạng thái và phương thức thanh toán học phí qua tầng dữ liệu.
                Repository.CapNhatTrangThaiHocPhi(giaoDich.MaThanhToan, AppConstants.PaymentPaid, giaoDich.PhuongThuc, DateTime.Now);
                return ServiceResult.Ok("Da xac nhan thanh toan.");
            });
        }

        // Xử lý huy thanh toán.
        public ServiceResult HuyThanhToan(int maGiaoDich)
        {
            return Try(() =>
            {
                // Lấy giao dịch thanh toán theo mã qua tầng dữ liệu.
                var giaoDich = Repository.LayGiaoDichThanhToan(maGiaoDich);
                if (giaoDich == null)
                {
                    return ServiceResult.Fail("Khong tim thay giao dich.");
                }

                // Cập nhật trạng thái giao dịch qua tầng dữ liệu.
                Repository.CapNhatTrangThaiGiaoDich(maGiaoDich, AppConstants.PaymentCancelled);
                // Cập nhật trạng thái và phương thức thanh toán học phí qua tầng dữ liệu.
                Repository.CapNhatTrangThaiHocPhi(giaoDich.MaThanhToan, AppConstants.PaymentPending, null, null);
                return ServiceResult.Ok("Da huy thanh toan gia lap.");
            });
        }

        // Xử lý mô phỏng trạng thái thanh toán.
        public ServiceResult<PaymentDebugResultDTO> SimulatePaymentStatus(int transactionId, string fakeStatus, string receiverEmail)
        {
            return Try(() =>
            {
                // Ràng buộc dữ liệu: Vui lòng tạo hoặc chọn giao dịch trước.
                if (transactionId <= 0)
                {
                    return ServiceResult<PaymentDebugResultDTO>.Fail("Vui long tao hoac chon giao dich truoc.");
                }

                // Lấy chi tiết giao dịch để kiểm thử qua tầng dữ liệu.
                var detail = Repository.LayChiTietGiaoDichDebug(transactionId);
                if (detail == null)
                {
                    return ServiceResult<PaymentDebugResultDTO>.Fail("Khong tim thay giao dich.");
                }

                var toEmail = string.IsNullOrWhiteSpace(receiverEmail) ? detail.ReceiverEmail : receiverEmail.Trim();
                if (!ValidationHelper.IsValidEmail(toEmail))
                {
                    return WithData(false, detail, "Email nguoi nhan khong hop le.");
                }

                var status = string.IsNullOrWhiteSpace(fakeStatus) ? string.Empty : fakeStatus.Trim();
                string transactionStatus;
                string tuitionStatus;
                string paymentMethod = null;
                DateTime? paidAt = null;

                if (string.Equals(status, "Complete", StringComparison.OrdinalIgnoreCase))
                {
                    transactionStatus = AppConstants.PaymentPaid;
                    tuitionStatus = AppConstants.PaymentPaid;
                    paymentMethod = detail.PaymentMethod;
                    paidAt = DateTime.Now;
                }
                else if (string.Equals(status, "Expired", StringComparison.OrdinalIgnoreCase))
                {
                    transactionStatus = AppConstants.PaymentExpired;
                    tuitionStatus = AppConstants.PaymentOverdue;
                }
                else if (string.Equals(status, "Failed", StringComparison.OrdinalIgnoreCase))
                {
                    transactionStatus = AppConstants.PaymentFailed;
                    tuitionStatus = AppConstants.PaymentPending;
                }
                else
                {
                    return WithData(false, detail, "Trang thai gia lap khong hop le.");
                }

                // Cập nhật trạng thái giao dịch qua tầng dữ liệu.
                Repository.CapNhatTrangThaiGiaoDich(transactionId, transactionStatus);
                // Cập nhật trạng thái và phương thức thanh toán học phí qua tầng dữ liệu.
                Repository.CapNhatTrangThaiHocPhi(detail.TuitionPaymentId, tuitionStatus, paymentMethod, paidAt);

                // Lấy chi tiết giao dịch để kiểm thử qua tầng dữ liệu.
                detail = Repository.LayChiTietGiaoDichDebug(transactionId) ?? detail;
                detail.ReceiverEmail = toEmail;
                var email = TrySendStatusNotification(detail, transactionStatus);
                // Lấy chi tiết giao dịch để kiểm thử qua tầng dữ liệu.
                detail = Repository.LayChiTietGiaoDichDebug(transactionId) ?? detail;

                if (!email.Success)
                {
                    return WithData(false, detail, "Da cap nhat trang thai nhung gui email thong bao that bai: " + email.Error);
                }

                return ServiceResult<PaymentDebugResultDTO>.Ok(detail, "Da cap nhat trang thai va gui email thong bao.");
            });
        }

        // Thử gửi thư yêu cầu thanh toán và trả trạng thái lỗi nếu có.
        private EmailOutcome TrySendPaymentRequest(PaymentDebugResultDTO detail)
        {
            try
            {
                var qrBytes = LoadStaticPaymentQrBytes();
                _emailService.SendPaymentRequest(
                    detail.ReceiverEmail,
                    detail.StudentName,
                    string.IsNullOrWhiteSpace(detail.InvoiceCode) ? detail.ExternalTransactionRef : detail.InvoiceCode,
                    detail.Amount,
                    detail.PaymentUrl,
                    qrBytes);
                // Cập nhật trạng thái gửi thư yêu cầu thanh toán qua tầng dữ liệu.
                Repository.CapNhatEmailThanhToan(detail.TransactionId, true, DateTime.Now, null);
                return EmailOutcome.Ok();
            }
            catch (Exception ex)
            {
                // Cập nhật trạng thái gửi thư yêu cầu thanh toán qua tầng dữ liệu.
                Repository.CapNhatEmailThanhToan(detail.TransactionId, false, null, ex.Message);
                return EmailOutcome.Fail(ex.Message);
            }
        }

        // Đọc ảnh QR thanh toán cố định từ thư mục tài nguyên.
        private static byte[] LoadStaticPaymentQrBytes()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Payment", "myQR.png");
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Khong tim thay anh QR thanh toan tinh.", path);
            }

            return File.ReadAllBytes(path);
        }

        // Thử gửi thư thông báo trạng thái và trả trạng thái lỗi nếu có.
        private EmailOutcome TrySendStatusNotification(PaymentDebugResultDTO detail, string status)
        {
            try
            {
                _emailService.SendStatusNotification(
                    detail.ReceiverEmail,
                    detail.StudentName,
                    string.IsNullOrWhiteSpace(detail.InvoiceCode) ? detail.ExternalTransactionRef : detail.InvoiceCode,
                    detail.Amount,
                    status);
                // Cập nhật trạng thái gửi thư thông báo giao dịch qua tầng dữ liệu.
                Repository.CapNhatEmailTrangThai(detail.TransactionId, true, DateTime.Now, null);
                return EmailOutcome.Ok();
            }
            catch (Exception ex)
            {
                // Cập nhật trạng thái gửi thư thông báo giao dịch qua tầng dữ liệu.
                Repository.CapNhatEmailTrangThai(detail.TransactionId, false, null, ex.Message);
                return EmailOutcome.Fail(ex.Message);
            }
        }

        // Tạo ma giao dịch demo.
        private static string TaoMaGiaoDichDemo()
        {
            int suffix;
            lock (DemoRandomLock)
            {
                suffix = DemoRandom.Next(1000, 10000);
            }

            return "DEMO" + DateTime.Now.ToString("yyyyMMddHHmmss") + suffix;
        }

        // Lấy ma hóa đơn.
        private static string LayMaHoaDon(HoaDonHocPhiDTO invoice)
        {
            return string.IsNullOrWhiteSpace(invoice.MaHoaDon)
                ? invoice.MaThanhToan.ToString()
                : invoice.MaHoaDon.Trim();
        }

        // Thực hiện nghiệp vụ thanh toán và trả kết quả cho giao diện.
        private static ServiceResult<T> WithData<T>(bool success, T data, string message)
        {
            return new ServiceResult<T>
            {
                Success = success,
                Data = data,
                Message = message
            };
        }

        // Lớp hỗ trợ lưu trạng thái kết quả gửi Thư điện tử trong quá trình xử lý nghiệp vụ.
        private class EmailOutcome
        {
            public bool Success { get; private set; }
            public string Error { get; private set; }

            // Xử lý ok.
            public static EmailOutcome Ok()
            {
                return new EmailOutcome { Success = true, Error = string.Empty };
            }

            // Xử lý fail.
            public static EmailOutcome Fail(string error)
            {
                return new EmailOutcome { Success = false, Error = error };
            }
        }

        // Lớp hỗ trợ lưu trạng thái kết quả gửi học phí trong quá trình xử lý nghiệp vụ.
        private class TuitionSendOutcome
        {
            public int TuitionPaymentId { get; set; }
            public string StudentName { get; set; }
            public string Email { get; set; }
            public bool Success { get; set; }
            public string Message { get; set; }
            public PaymentResultDTO PaymentResult { get; set; }
        }
    }
}
