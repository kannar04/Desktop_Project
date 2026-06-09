using System;
// Đối tượng truyền dữ liệu chỉ số tổng quan màn hình tổng quan
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ


namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu chỉ số tổng quan màn hình tổng quan giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class DashboardSummaryDTO
        {
            public int TongHocVien { get; set; }
            public int HocVienDangHoc { get; set; }
            public decimal DoanhThuThangNay { get; set; }
            public int TongLopHoc { get; set; }
        }
}

