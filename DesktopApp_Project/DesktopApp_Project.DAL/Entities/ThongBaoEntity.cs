using System;
// Thực thể dữ liệu ánh xạ bảng thông báo trong cơ sở dữ liệu
// Chức năng:
// - Khai báo các cột LINQ sang SQL
// - Được kho dữ liệu dùng để đọc và ghi dữ liệu cơ sở dữ liệu

using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.ThongBao")]
    // Lớp thực thể dữ liệu ánh xạ dữ liệu thông báo từ bảng cơ sở dữ liệu sang đối tượng C#.
    public class ThongBaoEntity
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
            public int MaThongBao { get; set; }
    
            [Column] public int MaNguoiGui { get; set; }
            [Column] public string TieuDe { get; set; }
            [Column] public string NoiDung { get; set; }
            [Column] public string DoiTuongNhan { get; set; }
            [Column] public DateTime ThoiGianGui { get; set; }
        }
}


