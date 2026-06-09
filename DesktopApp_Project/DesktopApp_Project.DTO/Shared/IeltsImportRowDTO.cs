// Đối tượng truyền dữ liệu dòng dữ liệu nhập IELTS
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ

namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu dòng dữ liệu nhập IELTS giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
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
