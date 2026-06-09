using System;
// Đối tượng truyền dữ liệu tiêu chí tìm kiếm từ vựng
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ


namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu tiêu chí tìm kiếm từ vựng giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class TuVungSearchCriteriaDTO
        {
            public int? MaLopHoc { get; set; }
            public string Keyword { get; set; }
            public string TuLoai { get; set; }
            public string CapDo { get; set; }
            public string ChuDe { get; set; }
            public string ChuCaiDau { get; set; }
        }
}

