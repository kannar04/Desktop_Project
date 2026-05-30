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
        public PaymentService(IQuanLyIeltsRepository repository) : base(repository) { }

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
                    ? "Thanh toan hoc phi " + (string.IsNullOrWhiteSpace(invoice.MaHoaDon) ? invoice.MaThanhToan.ToString() : invoice.MaHoaDon)
                    : request.NoiDungThanhToan.Trim();

                var prefix = request.PhuongThuc == AppConstants.PaymentMethodMoMo ? "MOMO" : "VNPAY";
                var externalId = prefix + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + request.MaThanhToan;
                var paymentUrl = "https://fake-payment.local/" + prefix.ToLowerInvariant() + "?txn=" + Uri.EscapeDataString(externalId);
                var qrContent = prefix + "|" + request.MaThanhToan + "|" + request.SoTien.ToString("0") + "|" + externalId;

                var result = Repository.TaoNhatKyThanhToan(request, externalId, paymentUrl, qrContent);
                Repository.CapNhatTrangThaiHocPhi(request.MaThanhToan, AppConstants.PaymentPending, null, null);
                return ServiceResult<PaymentResultDTO>.Ok(result, "Da tao thanh toan gia lap.");
            });
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
    }
}
