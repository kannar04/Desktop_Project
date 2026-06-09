using System;
// Đối tượng truyền dữ liệu báo cáo bài tập
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ


namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu báo cáo bài tập giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class BaoCaoBaiTapDTO
        {
            public string HoTen { get; set; }
            public string TieuDe { get; set; }
            public string TrangThaiNop { get; set; }
            public DateTime Deadline { get; set; }
        }
}

