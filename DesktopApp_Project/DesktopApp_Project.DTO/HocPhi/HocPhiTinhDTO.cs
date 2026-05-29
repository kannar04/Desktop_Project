using System;

namespace DesktopApp_Project.DTO
{
    public class HocPhiTinhDTO
        {
            public int MaNguoiDung { get; set; }
            public int MaLopHoc { get; set; }
            public string HoTen { get; set; }
            public DateTime NgayVaoLop { get; set; }
            public decimal SoTienGoc { get; set; }
            public decimal PhanTramGiam { get; set; }
            public decimal SoTienGiam { get; set; }
            public decimal SoTienCuoi { get; set; }
            public string TrangThai { get; set; }
            public string GhiChu { get; set; }
        }
}

