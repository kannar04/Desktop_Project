// Dịch vụ xử lý nghiệp vụ học phí
// Chức năng:
// - Nhận dữ liệu từ giao diện dưới dạng đối tượng truyền dữ liệu hoặc tham số lọc
// - Kiểm tra nghiệp vụ trước khi gọi tầng dữ liệu
// - Trả kết quả xử lý hoặc danh sách đối tượng truyền dữ liệu cho giao diện

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
    // Lớp xử lý nghiệp vụ học phí, kiểm tra dữ liệu trước khi gọi kho dữ liệu/tầng dữ liệu.
    public class HocPhiService : ServiceBase
        {
            public HocPhiService(IQuanLyIeltsRepository repository) : base(repository) { }
    
            // Lấy danh sách.
            public List<ThanhToanHocPhiDTO> LayDanhSach()
            {
                // Lấy danh sách học phí qua tầng dữ liệu.
                return Repository.GetHocPhi();
            }
    
            // Lấy danh sách.
            public List<ThanhToanHocPhiDTO> LayDanhSach(int? maLopHoc)
            {
                // Lấy danh sách học phí qua tầng dữ liệu.
                return Repository.GetHocPhi(maLopHoc, null, null);
            }
    
            // Tính toán nghiệp vụ học phí trước khi tạo dữ liệu lưu trữ.
            public ServiceResult<List<HocPhiTinhDTO>> TinhTheoLop(int maLopHoc, decimal soTienGoc)
            {
                return Try(() =>
                {
                    // Ràng buộc dữ liệu: chọn lớp.
                    if (maLopHoc <= 0)
                    {
                        return ServiceResult<List<HocPhiTinhDTO>>.Fail("Vui lòng chọn lớp.");
                    }
    
                    // Ràng buộc dữ liệu: Số tiền gốc phải lớn hơn 0.
                    if (soTienGoc <= 0)
                    {
                        return ServiceResult<List<HocPhiTinhDTO>>.Fail("Số tiền gốc phải lớn hơn 0.");
                    }
    
                    var rows = TinhHocPhi(maLopHoc, soTienGoc);
                    return ServiceResult<List<HocPhiTinhDTO>>.Ok(rows, "Đã tính học phí cho lớp.");
                });
            }
    
            // Tạo yêu cầu học phí theo lớp.
            public ServiceResult TaoYeuCauTheoLop(int maLopHoc, decimal soTienGoc, string thongTinNganHang)
            {
                return Try(() =>
                {
                    // Ràng buộc dữ liệu: chọn lớp.
                    if (maLopHoc <= 0)
                    {
                        return ServiceResult.Fail("Vui lòng chọn lớp.");
                    }
    
                    // Ràng buộc dữ liệu: nhập số tiền gốc và thông tin ngân hàng.
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
                    // Giới hạn dữ liệu trong lớp học đang chọn.
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
    
                    // Thêm nhiều phiếu học phí qua tầng dữ liệu.
                    Repository.InsertHocPhiBulk(payments);
                    return ServiceResult.Ok("Đã tạo phiếu học phí cho " + payments.Count + " học viên.");
                });
            }
    
            // Tạo yêu cầu học phí.
            public ServiceResult TaoYeuCau(ThanhToanHocPhiDTO dto)
            {
                return Try(() =>
                {
                    // Ràng buộc dữ liệu: chọn học viên, nhập số tiền và thông tin ngân hàng.
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

                    // Thêm phiếu học phí mới qua tầng dữ liệu.
                    Repository.InsertHocPhi(dto);
                    return ServiceResult.Ok("Tạo yêu cầu thanh toán học phí thành công. Hạn thanh toán là 10 ngày.");
                });
            }
    
            // Cập nhật trạng thái nghiệp vụ học phí và đồng bộ xuống tầng dữ liệu.
            public ServiceResult CapNhatTrangThai(int maThanhToan, string trangThai)
            {
                return Try(() =>
                {
                    // Ràng buộc dữ liệu: Trạng thái học phí không hợp lệ.
                    if (ValidationHelper.IsBlank(trangThai) || !AppConstants.PaymentStatuses.Contains(trangThai))
                    {
                        return ServiceResult.Fail("Trạng thái học phí không hợp lệ.");
                    }
    
                    // Cập nhật trạng thái học phí qua tầng dữ liệu.
                    Repository.UpdateTrangThaiHocPhi(maThanhToan, trangThai);
                    return ServiceResult.Ok("Cập nhật trạng thái học phí thành công.");
                });
            }
    
            // Tính toán nghiệp vụ học phí trước khi tạo dữ liệu lưu trữ.
            private List<HocPhiTinhDTO> TinhHocPhi(int maLopHoc, decimal soTienGoc)
            {
                var today = DateTime.Today;
                // Lấy danh sách học viên kèm trạng thái lớp qua tầng dữ liệu.
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

            // Lấy học phí trong tháng.
            private List<ThanhToanHocPhiDTO> LayHocPhiTrongThang(int? maLopHoc, DateTime ngayTao)
            {
                var dauThang = new DateTime(ngayTao.Year, ngayTao.Month, 1);
                var cuoiThang = dauThang.AddMonths(1).AddDays(-1);
                // Lấy danh sách học phí qua tầng dữ liệu.
                return Repository.GetHocPhi(maLopHoc, dauThang, cuoiThang);
            }

            // Kiểm tra học phí bị trùng.
            private static bool CoHocPhiTrung(IEnumerable<ThanhToanHocPhiDTO> existing, int maNguoiDung, int? maLopHoc)
            {
                return existing != null && existing.Any(x =>
                    x.MaNguoiDung == maNguoiDung
                    && x.MaLopHoc == maLopHoc
                    && !LaHocPhiDaHuy(x.TrangThai));
            }

            // Kiểm tra học phí đã hủy.
            private static bool LaHocPhiDaHuy(string trangThai)
            {
                return AppConstants.GetTextAliases(AppConstants.PaymentCancelled).Contains(trangThai);
            }
        }
}
