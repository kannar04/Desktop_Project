using System;
// Thực thể dữ liệu ánh xạ bảng từ vựng và flashcard trong cơ sở dữ liệu
// Chức năng:
// - Khai báo các cột LINQ sang SQL
// - Được kho dữ liệu dùng để đọc và ghi dữ liệu cơ sở dữ liệu

using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.TuVung")]
    // Lớp thực thể dữ liệu ánh xạ dữ liệu từ vựng và flashcard từ bảng cơ sở dữ liệu sang đối tượng C#.
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


