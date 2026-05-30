namespace DesktopApp_Project.DTO
{
    public class IeltsExamItemDTO
    {
        public int MaDeThi { get; set; }
        public int MaCauHoi { get; set; }
        public string GroupType { get; set; }
        public int? GroupId { get; set; }
        public int? ThuTu { get; set; }
        public string GroupTitle { get; set; }
        public string NoiDung { get; set; }
        public string QuestionType { get; set; }
        public string AnswerKey { get; set; }
        public decimal? BandLevel { get; set; }
    }
}
