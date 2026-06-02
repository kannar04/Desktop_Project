using System;

namespace DesktopApp_Project.DTO
{
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
