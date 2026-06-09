using System;
// Đối tượng truyền dữ liệu bài nộp của học viên
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ


namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu bài nộp của học viên giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class NopBaiDTO
        {
            public int MaNguoiDung { get; set; }
            public int MaBaiTap { get; set; }
            public string HoTen { get; set; }
            public string FileBaiLam { get; set; }
            public DateTime? ThoiGianNop { get; set; }
            public string TrangThaiNop { get; set; }
            public decimal? DiemSo { get; set; }
            public string NhanXet { get; set; }
        }
}

