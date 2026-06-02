namespace DesktopApp_Project.DTO
{
    public class BankRowDTO
    {
        public string Kind { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Skill { get; set; }
        public decimal? BandLevel { get; set; }
        public int? ParentId { get; set; }
        public int QuestionCount { get; set; }
        public string MediaPath { get; set; }
        public string ContentPreview { get; set; }
        public string ParentTitle { get; set; }
    }
}
