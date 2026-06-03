using System;
using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.ReadingPassage")]
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
