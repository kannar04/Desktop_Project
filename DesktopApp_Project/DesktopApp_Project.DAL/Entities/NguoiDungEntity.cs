using System;
using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.NguoiDung")]
    public class NguoiDungEntity
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
            public int MaNguoiDung { get; set; }
    
            [Column] public string VaiTro { get; set; }
            [Column] public string HoTen { get; set; }
            [Column] public DateTime? NgaySinh { get; set; }
            [Column] public string SDT { get; set; }
            [Column] public string Email { get; set; }
            [Column] public string TrinhDoDauVao { get; set; }
            [Column] public string TaiKhoan { get; set; }
            [Column] public string MatKhau { get; set; }
        }
}


