using System;
using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.ThongBao")]
    public class ThongBaoEntity
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
            public int MaThongBao { get; set; }
    
            [Column] public int MaNguoiGui { get; set; }
            [Column] public string TieuDe { get; set; }
            [Column] public string NoiDung { get; set; }
            [Column] public string DoiTuongNhan { get; set; }
            [Column] public DateTime ThoiGianGui { get; set; }
        }
}


