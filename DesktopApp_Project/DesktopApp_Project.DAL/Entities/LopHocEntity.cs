using System;
// Thực thể dữ liệu ánh xạ bảng lớp học trong cơ sở dữ liệu
// Chức năng:
// - Khai báo các cột LINQ sang SQL
// - Được kho dữ liệu dùng để đọc và ghi dữ liệu cơ sở dữ liệu

using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.LopHoc")]
    // Lớp thực thể dữ liệu ánh xạ dữ liệu lớp học từ bảng cơ sở dữ liệu sang đối tượng C#.
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


