using System;
// Đối tượng truyền dữ liệu báo cáo điểm
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ


namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu báo cáo điểm giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class BaoCaoDiemDTO
        {
            public string TenLop { get; set; }
            public string HoTen { get; set; }
            public string TenDotKiemTra { get; set; }
            public decimal? DiemTong { get; set; }
            public string NhanXet { get; set; }
        }
}

