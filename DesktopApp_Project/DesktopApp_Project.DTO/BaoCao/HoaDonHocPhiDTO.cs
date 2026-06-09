// Đối tượng truyền dữ liệu hóa đơn học phí
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ

using System;

namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu hóa đơn học phí giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class HoaDonHocPhiDTO
    {
        public int MaThanhToan { get; set; }
        public string MaHoaDon { get; set; }
        public int MaNguoiDung { get; set; }
        public int? MaLopHoc { get; set; }
        public string HoTen { get; set; }
        public string TenLop { get; set; }
        public decimal SoTien { get; set; }
        public decimal? SoTienGoc { get; set; }
        public decimal PhanTramGiam { get; set; }
        public decimal SoTienGiam { get; set; }
        public decimal? SoTienCuoi { get; set; }
        public string ThongTinNganHang { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime HanThanhToan { get; set; }
        public DateTime? NgayThanhToan { get; set; }
        public string PhuongThucThanhToan { get; set; }
        public string TrangThai { get; set; }
    }
}
