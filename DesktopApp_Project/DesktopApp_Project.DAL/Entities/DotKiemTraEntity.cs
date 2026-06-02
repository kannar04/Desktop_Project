using System;
using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.DotKiemTra")]
    public class DotKiemTraEntity
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
            public int MaDotKiemTra { get; set; }
    
            [Column] public int MaLopHoc { get; set; }
            [Column] public int? MaDeThi { get; set; }
            [Column] public string TenDotKiemTra { get; set; }
            [Column] public DateTime NgayKiemTra { get; set; }
        }
}


