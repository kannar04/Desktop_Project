using System;
// Thực thể dữ liệu ánh xạ bảng câu hỏi trong cơ sở dữ liệu
// Chức năng:
// - Khai báo các cột LINQ sang SQL
// - Được kho dữ liệu dùng để đọc và ghi dữ liệu cơ sở dữ liệu

using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.CauHoi")]
    // Lớp thực thể dữ liệu ánh xạ dữ liệu câu hỏi từ bảng cơ sở dữ liệu sang đối tượng C#.
    public class CauHoiEntity
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
            public int MaCauHoi { get; set; }
    
            [Column] public string NoiDung { get; set; }
            [Column] public string DapAn { get; set; }
            [Column] public string NhanKyNang { get; set; }
            [Column] public string QuestionType { get; set; }
            [Column] public string OptionA { get; set; }
            [Column] public string OptionB { get; set; }
            [Column] public string OptionC { get; set; }
            [Column] public string OptionD { get; set; }
            [Column] public string AnswerKey { get; set; }
            [Column] public string Explanation { get; set; }
            [Column] public int? PassageId { get; set; }
            [Column] public int? SectionId { get; set; }
            [Column] public decimal? BandLevel { get; set; }
        }
}

