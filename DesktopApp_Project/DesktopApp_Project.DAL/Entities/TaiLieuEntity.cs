using System;
using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.TaiLieu")]
    public class TaiLieuEntity
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
            public int MaTaiLieu { get; set; }
    
            [Column] public int MaLopHoc { get; set; }
            [Column] public string TenChuDe { get; set; }
            [Column] public string NoiDungMoTa { get; set; }
            [Column] public string DuongDanFile { get; set; }
            [Column] public string VideoLink { get; set; }
            [Column] public string NhanKyNang { get; set; }
            [Column] public DateTime NgayCapNhat { get; set; }
        }
}


