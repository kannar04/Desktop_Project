using System;
// Thực thể dữ liệu ánh xạ bảng đợt kiểm tra trong cơ sở dữ liệu
// Chức năng:
// - Khai báo các cột LINQ sang SQL
// - Được kho dữ liệu dùng để đọc và ghi dữ liệu cơ sở dữ liệu

using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.DotKiemTra")]
    // Lớp thực thể dữ liệu ánh xạ dữ liệu đợt kiểm tra từ bảng cơ sở dữ liệu sang đối tượng C#.
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


