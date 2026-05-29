using System;
using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.ChiTiet_ThongBao")]
    public class ChiTietThongBaoEntity
        {
            [Column(IsPrimaryKey = true)] public int MaThongBao { get; set; }
            [Column(IsPrimaryKey = true)] public int MaNguoiDung { get; set; }
            [Column] public bool DaDoc { get; set; }
        }
}


