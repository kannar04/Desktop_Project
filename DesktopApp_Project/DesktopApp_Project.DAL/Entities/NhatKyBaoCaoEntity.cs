using System;
using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.NhatKyBaoCao")]
    public class NhatKyBaoCaoEntity
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
            public int MaNhatKy { get; set; }
    
            [Column] public int MaNguoiDung { get; set; }
            [Column] public string LoaiBaoCao { get; set; }
            [Column] public string TieuChi { get; set; }
            [Column] public DateTime ThoiGianTao { get; set; }
        }
}


