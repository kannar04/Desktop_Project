using System;
using System.Collections.Generic;
using System.Linq;
using DesktopApp_Project.Common;
using DesktopApp_Project.DAL;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.BUS
{
    public class PaymentService : ServiceBase
    {
        private static readonly Random DemoRandom = new Random();
        private static readonly object DemoRandomLock = new object();
        private readonly VnpayUrlService _vnpayUrlService;
        private readonly QrCodeService _qrCodeService;
        private readonly PaymentEmailService _emailService;

        public PaymentService(IQuanLyIeltsRepository repository) : base(repository)
        {
            _vnpayUrlService = new VnpayUrlService();
            _qrCodeService = new QrCodeService();
            _emailService = new PaymentEmailService();
        }

        public ServiceResult<PaymentResultDTO> TaoThanhToan(PaymentRequestDTO request)
        {
            return Try(() =>
            {
                if (request == null || request.MaThanhToan <= 0)
                {
                    return ServiceResult<PaymentResultDTO>.Fail("Vui long chon phieu hoc phi.");
                }

                if (!AppConstants.PaymentMethods.Contains(request.PhuongThuc))
                {
                    return ServiceResult<PaymentResultDTO>.Fail("Phuong thuc thanh toan khong hop le.");
                }

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

                var result = Repository.TaoNhatKyThanhToan(request, externalId, paymentUrl, qrContent);
                Repository.CapNhatTrangThaiHocPhi(request.MaThanhToan, AppConstants.PaymentPending, null, null);
                return ServiceResult<PaymentResultDTO>.Ok(result, "Da tao thanh toan gia lap.");
            });
        }

        public ServiceResult<PaymentDebugResultDTO> CreateDebugPayment(PaymentDebugRequestDTO request)
        {
            return Try(() =>
            {
                var validation = ValidateDebugRequest(request);
                if (!string.IsNullOrEmpty(validation))
                {
                    return ServiceResult<PaymentDebugResultDTO>.Fail(validation);
                }

                NormalizeDebugRequest(request);
                var maThanhToan = Repository.TaoHocPhiDebug(request, request.InvoiceCode);
                var txnRef = TaoMaGiaoDichDemo();
                var paymentUrl = _vnpayUrlService.BuildPaymentUrl(
                    txnRef,
                    request.Amount,
                    request.PaymentContent,
                    "127.0.0.1");

                var detail = Repository.TaoNhatKyThanhToanDebug(request, maThanhToan, txnRef, paymentUrl, paymentUrl);
                var email = TrySendPaymentRequest(detail);
                detail = Repository.LayChiTietGiaoDichDebug(detail.TransactionId) ?? detail;

                if (!email.Success)
                {
                    return WithData(false, detail, "Da tao link thanh toan nhung gui email that bai: " + email.Error);
                }

                return ServiceResult<PaymentDebugResultDTO>.Ok(detail, "Da tao link thanh toan va gui email thanh cong.");
            });
        }

        public ServiceResult<List<PaymentDebugResultDTO>> GetRecentDebugPayments()
        {
            return Try(() => ServiceResult<List<PaymentDebugResultDTO>>.Ok(Repository.LayGiaoDichDebugGanDay(100), "OK"));
        }

        public ServiceResult<PaymentDebugResultDTO> GetPaymentDebugDetail(int transactionId)
        {
            return Try(() =>
            {
                var detail = Repository.LayChiTietGiaoDichDebug(transactionId);
                return detail == null
                    ? ServiceResult<PaymentDebugResultDTO>.Fail("Khong tim thay giao dich thanh toan.")
                    : ServiceResult<PaymentDebugResultDTO>.Ok(detail, "OK");
            });
        }

        public ServiceResult<PaymentDebugResultDTO> ResendPaymentEmail(int transactionId)
        {
            return Try(() =>
            {
                var detail = Repository.LayChiTietGiaoDichDebug(transactionId);
                if (detail == null)
                {
                    return ServiceResult<PaymentDebugResultDTO>.Fail("Khong tim thay giao dich thanh toan.");
                }

                if (string.IsNullOrWhiteSpace(detail.PaymentUrl))
                {
                    return WithData(false, detail, "Giao dich chua co link thanh toan de gui lai email.");
                }

                if (!ValidationHelper.IsValidEmail(detail.ReceiverEmail))
                {
                    return WithData(false, detail, "Email nguoi nhan khong hop le.");
                }

                var email = TrySendPaymentRequest(detail);
                detail = Repository.LayChiTietGiaoDichDebug(transactionId) ?? detail;

                if (!email.Success)
                {
                    return WithData(false, detail, "Gui lai email thanh toan that bai: " + email.Error);
                }

                return ServiceResult<PaymentDebugResultDTO>.Ok(detail, "Da gui lai email thanh toan.");
            });
        }

        private ServiceResult<PaymentResultDTO> TaoThanhToanVnpay(PaymentRequestDTO request, HoaDonHocPhiDTO invoice)
        {
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
            var result = Repository.TaoNhatKyThanhToan(request, txnRef, paymentUrl, paymentUrl);
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
            result = Repository.LayGiaoDichThanhToan(result.MaGiaoDich) ?? result;

            if (!email.Success)
            {
                return WithData(false, result, "Da tao link thanh toan VNPAY sandbox nhung gui email that bai: " + email.Error);
            }

            return ServiceResult<PaymentResultDTO>.Ok(result, "Da tao thanh toan VNPAY sandbox va gui email.");
        }

        public ServiceResult<PaymentResultDTO> LayGiaoDich(int maGiaoDich)
        {
            return Try(() =>
            {
                var result = Repository.LayGiaoDichThanhToan(maGiaoDich);
                return result == null
                    ? ServiceResult<PaymentResultDTO>.Fail("Khong tim thay giao dich.")
                    : ServiceResult<PaymentResultDTO>.Ok(result, "OK");
            });
        }

        public ServiceResult<List<PaymentResultDTO>> LayGiaoDichTheoThanhToan(int maThanhToan)
        {
            return Try(() => ServiceResult<List<PaymentResultDTO>>.Ok(Repository.LayGiaoDichTheoThanhToan(maThanhToan), "OK"));
        }

        public ServiceResult XacNhanThanhToan(int maGiaoDich)
        {
            return Try(() =>
            {
                var giaoDich = Repository.LayGiaoDichThanhToan(maGiaoDich);
                if (giaoDich == null)
                {
                    return ServiceResult.Fail("Khong tim thay giao dich.");
                }

                Repository.CapNhatTrangThaiGiaoDich(maGiaoDich, AppConstants.PaymentPaid);
                Repository.CapNhatTrangThaiHocPhi(giaoDich.MaThanhToan, AppConstants.PaymentPaid, giaoDich.PhuongThuc, DateTime.Now);
                return ServiceResult.Ok("Da xac nhan thanh toan.");
            });
        }

        public ServiceResult HuyThanhToan(int maGiaoDich)
        {
            return Try(() =>
            {
                var giaoDich = Repository.LayGiaoDichThanhToan(maGiaoDich);
                if (giaoDich == null)
                {
                    return ServiceResult.Fail("Khong tim thay giao dich.");
                }

                Repository.CapNhatTrangThaiGiaoDich(maGiaoDich, AppConstants.PaymentCancelled);
                Repository.CapNhatTrangThaiHocPhi(giaoDich.MaThanhToan, AppConstants.PaymentPending, null, null);
                return ServiceResult.Ok("Da huy thanh toan gia lap.");
            });
        }

        public ServiceResult<PaymentDebugResultDTO> SimulatePaymentStatus(int transactionId, string fakeStatus, string receiverEmail)
        {
            return Try(() =>
            {
                if (transactionId <= 0)
                {
                    return ServiceResult<PaymentDebugResultDTO>.Fail("Vui long tao hoac chon giao dich truoc.");
                }

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

                Repository.CapNhatTrangThaiGiaoDich(transactionId, transactionStatus);
                Repository.CapNhatTrangThaiHocPhi(detail.TuitionPaymentId, tuitionStatus, paymentMethod, paidAt);

                detail = Repository.LayChiTietGiaoDichDebug(transactionId) ?? detail;
                detail.ReceiverEmail = toEmail;
                var email = TrySendStatusNotification(detail, transactionStatus);
                detail = Repository.LayChiTietGiaoDichDebug(transactionId) ?? detail;

                if (!email.Success)
                {
                    return WithData(false, detail, "Da cap nhat trang thai nhung gui email thong bao that bai: " + email.Error);
                }

                return ServiceResult<PaymentDebugResultDTO>.Ok(detail, "Da cap nhat trang thai va gui email thong bao.");
            });
        }

        private EmailOutcome TrySendPaymentRequest(PaymentDebugResultDTO detail)
        {
            try
            {
                var qrBytes = _qrCodeService.GenerateQrBytes(detail.PaymentUrl);
                _emailService.SendPaymentRequest(
                    detail.ReceiverEmail,
                    detail.StudentName,
                    string.IsNullOrWhiteSpace(detail.InvoiceCode) ? detail.ExternalTransactionRef : detail.InvoiceCode,
                    detail.Amount,
                    detail.PaymentUrl,
                    qrBytes);
                Repository.CapNhatEmailThanhToan(detail.TransactionId, true, DateTime.Now, null);
                return EmailOutcome.Ok();
            }
            catch (Exception ex)
            {
                Repository.CapNhatEmailThanhToan(detail.TransactionId, false, null, ex.Message);
                return EmailOutcome.Fail(ex.Message);
            }
        }

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
                Repository.CapNhatEmailTrangThai(detail.TransactionId, true, DateTime.Now, null);
                return EmailOutcome.Ok();
            }
            catch (Exception ex)
            {
                Repository.CapNhatEmailTrangThai(detail.TransactionId, false, null, ex.Message);
                return EmailOutcome.Fail(ex.Message);
            }
        }

        private static string ValidateDebugRequest(PaymentDebugRequestDTO request)
        {
            if (request == null)
            {
                return "Du lieu thanh toan debug khong hop le.";
            }

            if (string.IsNullOrWhiteSpace(request.StudentName))
            {
                return "Vui long nhap ten hoc sinh.";
            }

            if (!ValidationHelper.IsValidEmail(request.ReceiverEmail))
            {
                return "Email nguoi nhan khong hop le.";
            }

            if (request.Amount <= 0)
            {
                return "So tien thanh toan phai lon hon 0.";
            }

            if (!string.IsNullOrWhiteSpace(request.PaymentMethod)
                && request.PaymentMethod != AppConstants.PaymentMethodVNPay)
            {
                return "Cong cu debug hien chi ho tro VNPay sandbox.";
            }

            return string.Empty;
        }

        private static void NormalizeDebugRequest(PaymentDebugRequestDTO request)
        {
            request.StudentName = request.StudentName.Trim();
            request.ReceiverEmail = request.ReceiverEmail.Trim();
            request.ClassName = string.IsNullOrWhiteSpace(request.ClassName) ? "Debug" : request.ClassName.Trim();
            request.InvoiceCode = string.IsNullOrWhiteSpace(request.InvoiceCode)
                ? "DBG" + DateTime.Now.ToString("yyyyMMddHHmmss")
                : request.InvoiceCode.Trim();
            request.PaymentMethod = AppConstants.PaymentMethodVNPay;
            request.PaymentContent = string.IsNullOrWhiteSpace(request.PaymentContent)
                ? "Thanh toan hoc phi debug " + request.InvoiceCode
                : request.PaymentContent.Trim();
            request.DebugNote = string.IsNullOrWhiteSpace(request.DebugNote) ? string.Empty : request.DebugNote.Trim();
            request.IsDebugPayment = true;
        }

        private static string TaoMaGiaoDichDemo()
        {
            int suffix;
            lock (DemoRandomLock)
            {
                suffix = DemoRandom.Next(1000, 10000);
            }

            return "DEMO" + DateTime.Now.ToString("yyyyMMddHHmmss") + suffix;
        }

        private static string LayMaHoaDon(HoaDonHocPhiDTO invoice)
        {
            return string.IsNullOrWhiteSpace(invoice.MaHoaDon)
                ? invoice.MaThanhToan.ToString()
                : invoice.MaHoaDon.Trim();
        }

        private static ServiceResult<T> WithData<T>(bool success, T data, string message)
        {
            return new ServiceResult<T>
            {
                Success = success,
                Data = data,
                Message = message
            };
        }

        private class EmailOutcome
        {
            public bool Success { get; private set; }
            public string Error { get; private set; }

            public static EmailOutcome Ok()
            {
                return new EmailOutcome { Success = true, Error = string.Empty };
            }

            public static EmailOutcome Fail(string error)
            {
                return new EmailOutcome { Success = false, Error = error };
            }
        }
    }
}
