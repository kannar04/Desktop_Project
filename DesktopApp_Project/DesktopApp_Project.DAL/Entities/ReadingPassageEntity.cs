// Thực thể dữ liệu ánh xạ bảng đoạn đọc Reading trong cơ sở dữ liệu
// Chức năng:
// - Khai báo các cột LINQ sang SQL
// - Được kho dữ liệu dùng để đọc và ghi dữ liệu cơ sở dữ liệu

using System;
using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.ReadingPassage")]
    // Lớp thực thể dữ liệu ánh xạ dữ liệu đoạn đọc Reading từ bảng cơ sở dữ liệu sang đối tượng C#.
    public class ReadingPassageEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int PassageId { get; set; }

        [Column] public string PassageCode { get; set; }
        [Column] public string Title { get; set; }
        [Column] public string Content { get; set; }
        [Column] public string ImagePath { get; set; }
        [Column] public decimal? BandLevel { get; set; }
        [Column] public string Topic { get; set; }
        [Column] public DateTime NgayTao { get; set; }
        [Column] public DateTime CreatedAt { get; set; }
    }
}
