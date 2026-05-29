using System;
using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.LopHoc")]
    public class LopHocEntity
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
            public int MaLopHoc { get; set; }
    
            [Column] public int MaGiaoVien { get; set; }
            [Column] public string TenLop { get; set; }
            [Column] public string NhomTrinhDo { get; set; }
            [Column] public string LichHoc { get; set; }
        }
}


