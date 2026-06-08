using System;
using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.BuoiHoc")]
    public class BuoiHocEntity
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
            public int MaBuoiHoc { get; set; }
    
            [Column] public int MaLopHoc { get; set; }
            [Column] public DateTime NgayHoc { get; set; }
        }
}


