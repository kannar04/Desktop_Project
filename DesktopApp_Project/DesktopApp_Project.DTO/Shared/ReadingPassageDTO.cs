using System;

namespace DesktopApp_Project.DTO
{
    public class ReadingPassageDTO
    {
        public int PassageId { get; set; }
        public string PassageCode { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public decimal? BandLevel { get; set; }
        public string Topic { get; set; }
        public int SoCauHoi { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
