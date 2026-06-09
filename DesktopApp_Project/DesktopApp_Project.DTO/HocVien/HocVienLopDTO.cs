using System;
// Đối tượng truyền dữ liệu học viên trong lớp
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ


namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu học viên trong lớp giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class HocVienLopDTO
        {
            public int MaNguoiDung { get; set; }
            public int MaLopHoc { get; set; }
            public string HoTen { get; set; }
            public string SDT { get; set; }
            public string Email { get; set; }
            public DateTime NgayVaoLop { get; set; }
            public DateTime? NgayNghiHoc { get; set; }
            public string TrangThai { get; set; }
            public bool DangHoc { get; set; }
        }
}

