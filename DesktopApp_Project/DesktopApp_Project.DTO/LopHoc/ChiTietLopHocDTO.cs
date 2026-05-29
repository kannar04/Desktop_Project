using System;

namespace DesktopApp_Project.DTO
{
    public class ChiTietLopHocDTO
        {
            public int MaNguoiDung { get; set; }
            public int MaLopHoc { get; set; }
            public DateTime NgayVaoLop { get; set; }
            public DateTime? NgayNghiHoc { get; set; }
            public string TrangThai { get; set; }
        }
}

