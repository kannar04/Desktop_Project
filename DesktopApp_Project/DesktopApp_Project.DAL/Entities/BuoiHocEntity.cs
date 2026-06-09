using System;
// Thực thể dữ liệu ánh xạ bảng buổi học trong cơ sở dữ liệu
// Chức năng:
// - Khai báo các cột LINQ sang SQL
// - Được kho dữ liệu dùng để đọc và ghi dữ liệu cơ sở dữ liệu

using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.BuoiHoc")]
    // Lớp thực thể dữ liệu ánh xạ dữ liệu buổi học từ bảng cơ sở dữ liệu sang đối tượng C#.
    public class BuoiHocEntity
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
            public int MaBuoiHoc { get; set; }
    
            [Column] public int MaLopHoc { get; set; }
            [Column] public DateTime NgayHoc { get; set; }
        }
}


