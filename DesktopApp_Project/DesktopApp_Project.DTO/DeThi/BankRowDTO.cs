// Đối tượng truyền dữ liệu dòng dữ liệu ngân hàng
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ

namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu dòng dữ liệu ngân hàng giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
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
