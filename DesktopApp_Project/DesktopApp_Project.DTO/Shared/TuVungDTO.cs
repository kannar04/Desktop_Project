using System;
// Đối tượng truyền dữ liệu từ vựng và flashcard
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ


namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu từ vựng và flashcard giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class TuVungDTO
        {
            public int MaTuVung { get; set; }
            public int MaLopHoc { get; set; }
            public string TuTiengAnh { get; set; }
            public string TuLoai { get; set; }
            public string PhienAm { get; set; }
            public string Nghia { get; set; }
            public string CapDo { get; set; }
            public string ChuDe { get; set; }
        }
}

