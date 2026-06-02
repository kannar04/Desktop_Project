using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DesktopApp_Project.Common;
using DesktopApp_Project.DAL;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.BUS
{
    public class HocPhiService : ServiceBase
        {
            public HocPhiService(IQuanLyIeltsRepository repository) : base(repository) { }
    
            public List<ThanhToanHocPhiDTO> LayDanhSach()
            {
                return Repository.GetHocPhi();
            }
    
            public List<ThanhToanHocPhiDTO> LayDanhSach(int? maLopHoc)
            {
                return Repository.GetHocPhi(maLopHoc, null, null);
            }
    
            public ServiceResult<List<HocPhiTinhDTO>> TinhTheoLop(int maLopHoc, decimal soTienGoc)
            {
                return Try(() =>
                {
                    if (maLopHoc <= 0)
                    {
                        return ServiceResult<List<HocPhiTinhDTO>>.Fail("Vui lòng chọn lớp.");
                    }
    
                    if (soTienGoc <= 0)
                    {
                        return ServiceResult<List<HocPhiTinhDTO>>.Fail("Số tiền gốc phải lớn hơn 0.");
                    }
    
                    var rows = TinhHocPhi(maLopHoc, soTienGoc);
                    return ServiceResult<List<HocPhiTinhDTO>>.Ok(rows, "Đã tính học phí cho lớp.");
                });
            }
    
            public ServiceResult TaoYeuCauTheoLop(int maLopHoc, decimal soTienGoc, string thongTinNganHang)
            {
                return Try(() =>
                {
                    if (maLopHoc <= 0)
                    {
                        return ServiceResult.Fail("Vui lòng chọn lớp.");
                    }
    
                    if (soTienGoc <= 0 || ValidationHelper.IsBlank(thongTinNganHang))
                    {
                        return ServiceResult.Fail("Vui lòng nhập số tiền gốc và thông tin ngân hàng.");
                    }
    
                    var rows = TinhHocPhi(maLopHoc, soTienGoc);
                    if (rows.Count == 0)
                    {
                        return ServiceResult.Fail("Lớp không có học viên đang học để tạo học phí.");
                    }
    
                    var now = DateTime.Now;
                    var existing = LayHocPhiTrongThang(maLopHoc, now);
                    if (rows.Any(x => CoHocPhiTrung(existing, x.MaNguoiDung, x.MaLopHoc)))
                    {
                        return ServiceResult.Fail("Học phí này đã tồn tại cho học viên/lớp/kỳ tương ứng.");
                    }

                    var payments = rows.Select(x => new ThanhToanHocPhiDTO
                    {
                        MaNguoiDung = x.MaNguoiDung,
                        MaLopHoc = x.MaLopHoc,
                        SoTien = x.SoTienCuoi,
                        SoTienGoc = x.SoTienGoc,
                        PhanTramGiam = x.PhanTramGiam,
                        SoTienGiam = x.SoTienGiam,
                        SoTienCuoi = x.SoTienCuoi,
                        ThongTinNganHang = thongTinNganHang.Trim(),
                        NgayTao = now,
                        HanThanhToan = now.AddDays(AppConstants.HocPhiDeadlineDays),
                        TrangThai = AppConstants.PaymentPending
                    }).ToList();
    
                    Repository.InsertHocPhiBulk(payments);
                    return ServiceResult.Ok("Đã tạo phiếu học phí cho " + payments.Count + " học viên.");
                });
            }
    
            public ServiceResult TaoYeuCau(ThanhToanHocPhiDTO dto)
            {
                return Try(() =>
                {
                    if (dto.MaNguoiDung <= 0 || dto.SoTien <= 0 || ValidationHelper.IsBlank(dto.ThongTinNganHang))
                    {
                        return ServiceResult.Fail("Vui lòng chọn học viên, nhập số tiền và thông tin ngân hàng.");
                    }
    
                    dto.NgayTao = DateTime.Now;
                    dto.HanThanhToan = DateTime.Now.AddDays(AppConstants.HocPhiDeadlineDays);
                    dto.TrangThai = "Chờ thanh toán";
                    dto.SoTienGoc = dto.SoTienGoc ?? dto.SoTien;
                    dto.SoTienCuoi = dto.SoTienCuoi ?? dto.SoTien;
                    dto.TrangThai = AppConstants.PaymentPending;
                    var existing = LayHocPhiTrongThang(dto.MaLopHoc, dto.NgayTao);
                    if (CoHocPhiTrung(existing, dto.MaNguoiDung, dto.MaLopHoc))
                    {
                        return ServiceResult.Fail("Học phí này đã tồn tại cho học viên/lớp/kỳ tương ứng.");
                    }

                    Repository.InsertHocPhi(dto);
                    return ServiceResult.Ok("Tạo yêu cầu thanh toán học phí thành công. Hạn thanh toán là 10 ngày.");
                });
            }
    
            public ServiceResult CapNhatTrangThai(int maThanhToan, string trangThai)
            {
                return Try(() =>
                {
                    if (ValidationHelper.IsBlank(trangThai) || !AppConstants.PaymentStatuses.Contains(trangThai))
                    {
                        return ServiceResult.Fail("Trạng thái học phí không hợp lệ.");
                    }
    
                    Repository.UpdateTrangThaiHocPhi(maThanhToan, trangThai);
                    return ServiceResult.Ok("Cập nhật trạng thái học phí thành công.");
                });
            }
    
            private List<HocPhiTinhDTO> TinhHocPhi(int maLopHoc, decimal soTienGoc)
            {
                var today = DateTime.Today;
                return Repository.GetHocVienLop(maLopHoc, true).Select(hv =>
                {
                    var discount = hv.NgayVaoLop.Date <= today.AddYears(-AppConstants.LongTermTuitionDiscountYears)
                        ? AppConstants.LongTermTuitionDiscountPercent
                        : 0m;
                    var discountAmount = Math.Round(soTienGoc * discount / 100m, 0);
                    return new HocPhiTinhDTO
                    {
                        MaNguoiDung = hv.MaNguoiDung,
                        MaLopHoc = hv.MaLopHoc,
                        HoTen = hv.HoTen,
                        NgayVaoLop = hv.NgayVaoLop,
                        SoTienGoc = soTienGoc,
                        PhanTramGiam = discount,
                        SoTienGiam = discountAmount,
                        SoTienCuoi = soTienGoc - discountAmount,
                        TrangThai = hv.TrangThai,
                        GhiChu = discount > 0 ? "Giảm 20% do học trên 2 năm" : string.Empty
                    };
                }).ToList();
            }

            private List<ThanhToanHocPhiDTO> LayHocPhiTrongThang(int? maLopHoc, DateTime ngayTao)
            {
                var dauThang = new DateTime(ngayTao.Year, ngayTao.Month, 1);
                var cuoiThang = dauThang.AddMonths(1).AddDays(-1);
                return Repository.GetHocPhi(maLopHoc, dauThang, cuoiThang);
            }

            private static bool CoHocPhiTrung(IEnumerable<ThanhToanHocPhiDTO> existing, int maNguoiDung, int? maLopHoc)
            {
                return existing != null && existing.Any(x =>
                    x.MaNguoiDung == maNguoiDung
                    && x.MaLopHoc == maLopHoc
                    && !LaHocPhiDaHuy(x.TrangThai));
            }

            private static bool LaHocPhiDaHuy(string trangThai)
            {
                return AppConstants.GetTextAliases(AppConstants.PaymentCancelled).Contains(trangThai);
            }
        }
}

