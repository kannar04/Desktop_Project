using System;
// Thực thể dữ liệu ánh xạ bảng chi tiết người nhận thông báo trong cơ sở dữ liệu
// Chức năng:
// - Khai báo các cột LINQ sang SQL
// - Được kho dữ liệu dùng để đọc và ghi dữ liệu cơ sở dữ liệu

using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.ChiTiet_ThongBao")]
    // Lớp thực thể dữ liệu ánh xạ dữ liệu chi tiết người nhận thông báo từ bảng cơ sở dữ liệu sang đối tượng C#.
    public class ChiTietThongBaoEntity
        {
            [Column(IsPrimaryKey = true)] public int MaThongBao { get; set; }
            [Column(IsPrimaryKey = true)] public int MaNguoiDung { get; set; }
            [Column] public bool DaDoc { get; set; }
        }
}


