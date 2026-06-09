// Đối tượng truyền dữ liệu báo cáo doanh thu
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ

using System;

namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu báo cáo doanh thu giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class BaoCaoDoanhThuDTO
    {
        public DateTime Ngay { get; set; }
        public int? MaLopHoc { get; set; }
        public string TenLop { get; set; }
        public int SoPhieu { get; set; }
        public int SoPhieuDaThanhToan { get; set; }
        public decimal TongTienDaThanhToan { get; set; }
    }
}
