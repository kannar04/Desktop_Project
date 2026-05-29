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
            public DateTime NgayTao { get; set; }
        }
}

