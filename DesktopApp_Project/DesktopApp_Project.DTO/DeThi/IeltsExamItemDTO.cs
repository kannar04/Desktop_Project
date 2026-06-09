// Đối tượng truyền dữ liệu mục nội dung đề IELTS
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ

namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu mục nội dung đề IELTS giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
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
