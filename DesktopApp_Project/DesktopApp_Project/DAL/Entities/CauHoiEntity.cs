using System;
using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.CauHoi")]
    public class CauHoiEntity
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
            public int MaCauHoi { get; set; }
    
            [Column] public string NoiDung { get; set; }
            [Column] public string DapAn { get; set; }
            [Column] public string NhanKyNang { get; set; }
            [Column] public decimal? BandLevel { get; set; }
        }
}


