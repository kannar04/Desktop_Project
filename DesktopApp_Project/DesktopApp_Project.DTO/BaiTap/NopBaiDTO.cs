using System;

namespace DesktopApp_Project.DTO
{
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

