namespace DesktopApp_Project.DTO
{
    public class IeltsImportRowDTO
    {
        public int RowNumber { get; set; }
        public string ParentCode { get; set; }
        public string Skill { get; set; }
        public string PassageCode { get; set; }
        public string PassageTitle { get; set; }
        public string PassageContent { get; set; }
        public string Topic { get; set; }
        public string SectionCode { get; set; }
        public string SectionTitle { get; set; }
        public int? SectionNumber { get; set; }
        public string Transcript { get; set; }
        public string AudioPath { get; set; }
        public string ImagePath { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string AnswerKey { get; set; }
        public decimal? BandLevel { get; set; }
        public string Explanation { get; set; }
    }
}
