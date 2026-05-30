using System;

namespace DesktopApp_Project.DTO
{
    public class ListeningSectionDTO
    {
        public int SectionId { get; set; }
        public string SectionCode { get; set; }
        public string Title { get; set; }
        public int SectionNumber { get; set; }
        public int PartNo { get; set; }
        public string AudioPath { get; set; }
        public string Transcript { get; set; }
        public decimal? BandLevel { get; set; }
        public string Topic { get; set; }
        public int SoCauHoi { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
