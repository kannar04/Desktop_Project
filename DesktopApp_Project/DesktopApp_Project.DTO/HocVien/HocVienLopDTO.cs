using System;

namespace DesktopApp_Project.DTO
{
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

