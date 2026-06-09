using System;
// Thực thể dữ liệu ánh xạ bảng người dùng trong cơ sở dữ liệu
// Chức năng:
// - Khai báo các cột LINQ sang SQL
// - Được kho dữ liệu dùng để đọc và ghi dữ liệu cơ sở dữ liệu

using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.NguoiDung")]
    // Lớp thực thể dữ liệu ánh xạ dữ liệu người dùng từ bảng cơ sở dữ liệu sang đối tượng C#.
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


