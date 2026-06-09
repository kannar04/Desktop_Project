// Thực thể dữ liệu ánh xạ bảng phần nghe Listening trong cơ sở dữ liệu
// Chức năng:
// - Khai báo các cột LINQ sang SQL
// - Được kho dữ liệu dùng để đọc và ghi dữ liệu cơ sở dữ liệu

using System;
using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.ListeningSection")]
    // Lớp thực thể dữ liệu ánh xạ dữ liệu phần nghe Listening từ bảng cơ sở dữ liệu sang đối tượng C#.
    public class ListeningSectionEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int SectionId { get; set; }

        [Column] public string SectionCode { get; set; }
        [Column] public string Title { get; set; }
        [Column] public int SectionNumber { get; set; }
        [Column] public int PartNo { get; set; }
        [Column] public string AudioPath { get; set; }
        [Column] public string Transcript { get; set; }
        [Column] public decimal? BandLevel { get; set; }
        [Column] public string Topic { get; set; }
        [Column] public DateTime NgayTao { get; set; }
        [Column] public DateTime CreatedAt { get; set; }
    }
}
