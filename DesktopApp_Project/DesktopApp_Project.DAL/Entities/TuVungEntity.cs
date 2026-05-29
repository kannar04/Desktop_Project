using System;
using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.TuVung")]
    public class TuVungEntity
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
            public int MaTuVung { get; set; }
    
            [Column] public int MaLopHoc { get; set; }
            [Column] public string TuTiengAnh { get; set; }
            [Column] public string TuLoai { get; set; }
            [Column] public string PhienAm { get; set; }
            [Column] public string Nghia { get; set; }
            [Column] public string CapDo { get; set; }
            [Column] public string ChuDe { get; set; }
        }
}


