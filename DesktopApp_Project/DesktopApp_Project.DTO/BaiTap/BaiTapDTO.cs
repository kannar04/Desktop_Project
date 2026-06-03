using System;

namespace DesktopApp_Project.DTO
{
    public class BaiTapDTO
        {
            public int MaBaiTap { get; set; }
            public int MaLopHoc { get; set; }
            public string TieuDe { get; set; }
            public string MoTa { get; set; }
            public DateTime Deadline { get; set; }
            public string FileDinhKem { get; set; }
            public string LoaiFile { get; set; }
            public string TenFileGoc { get; set; }
            public string DuongDanLocal { get; set; }
            public DateTime NgayTao { get; set; }
        }
}
