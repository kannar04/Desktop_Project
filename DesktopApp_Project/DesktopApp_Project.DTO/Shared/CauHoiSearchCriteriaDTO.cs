using System;
// Đối tượng truyền dữ liệu tiêu chí tìm kiếm câu hỏi
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ


namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu tiêu chí tìm kiếm câu hỏi giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class CauHoiSearchCriteriaDTO
        {
            public string NhanKyNang { get; set; }
            public decimal? BandTu { get; set; }
            public decimal? BandDen { get; set; }
            public string Keyword { get; set; }
        }
}

