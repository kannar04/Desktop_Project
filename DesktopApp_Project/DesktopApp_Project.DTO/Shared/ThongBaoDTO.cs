using System;
// Đối tượng truyền dữ liệu thông báo
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ


namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu thông báo giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class ThongBaoDTO
        {
            public int MaThongBao { get; set; }
            public int MaNguoiGui { get; set; }
            public string TieuDe { get; set; }
            public string NoiDung { get; set; }
            public string DoiTuongNhan { get; set; }
            public DateTime ThoiGianGui { get; set; }
        }
}

