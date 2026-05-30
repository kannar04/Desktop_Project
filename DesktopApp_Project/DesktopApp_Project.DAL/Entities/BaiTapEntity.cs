using System;
using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.BaiTap")]
    public class BaiTapEntity
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
            public int MaBaiTap { get; set; }
    
            [Column] public int MaLopHoc { get; set; }
            [Column] public string TieuDe { get; set; }
            [Column] public string MoTa { get; set; }
            [Column] public DateTime Deadline { get; set; }
            [Column] public string FileDinhKem { get; set; }
            [Column] public string LoaiFile { get; set; }
            [Column] public string TenFileGoc { get; set; }
            [Column] public string DuongDanLocal { get; set; }
            [Column] public DateTime NgayTao { get; set; }
        }
}

