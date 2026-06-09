using System;
// Đối tượng truyền dữ liệu doanh thu theo tháng
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ


namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu doanh thu theo tháng giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class MonthlyRevenueDTO
        {
            public int Nam { get; set; }
            public int Thang { get; set; }
            public string Nhan { get; set; }
            public decimal TongTien { get; set; }
        }
}

