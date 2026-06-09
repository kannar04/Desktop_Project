using System;
// Đối tượng truyền dữ liệu câu hỏi
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ


namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu câu hỏi giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class CauHoiDTO
        {
            public int MaCauHoi { get; set; }
            public string NoiDung { get; set; }
            public string DapAn { get; set; }
            public string NhanKyNang { get; set; }
            public string QuestionType { get; set; }
            public string OptionA { get; set; }
            public string OptionB { get; set; }
            public string OptionC { get; set; }
            public string OptionD { get; set; }
            public string AnswerKey { get; set; }
            public string Explanation { get; set; }
            public int? PassageId { get; set; }
            public int? SectionId { get; set; }
            public string GroupTitle { get; set; }
            public decimal? BandLevel { get; set; }
        }
}
