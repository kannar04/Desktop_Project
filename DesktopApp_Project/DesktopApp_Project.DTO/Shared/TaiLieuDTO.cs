using System;

namespace DesktopApp_Project.DTO
{
    public class TaiLieuDTO
        {
            public int MaTaiLieu { get; set; }
            public int MaLopHoc { get; set; }
            public string TenChuDe { get; set; }
            public string NoiDungMoTa { get; set; }
            public string DuongDanFile { get; set; }
            public string VideoLink { get; set; }
            public string NhanKyNang { get; set; }
            public string LoaiFile { get; set; }
            public string TenFileGoc { get; set; }
            public string DuongDanLocal { get; set; }
            public string DuongDanCloud { get; set; }
            public string ThumbnailPath { get; set; }
            public DateTime NgayCapNhat { get; set; }
        }
}
