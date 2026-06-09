using System;
// Đối tượng truyền dữ liệu người dùng
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ


namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu người dùng giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class NguoiDungDTO
        {
            public int MaNguoiDung { get; set; }
            public string VaiTro { get; set; }
            public string HoTen { get; set; }
            public DateTime? NgaySinh { get; set; }
            public string SDT { get; set; }
            public string Email { get; set; }
            public string TrinhDoDauVao { get; set; }
            public string TaiKhoan { get; set; }
            public string MatKhau { get; set; }
        }
}

