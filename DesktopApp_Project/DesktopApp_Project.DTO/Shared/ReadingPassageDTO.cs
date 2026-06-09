// Đối tượng truyền dữ liệu đoạn đọc Reading
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ

using System;

namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu đoạn đọc Reading giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class ReadingPassageDTO
    {
        public int PassageId { get; set; }
        public string PassageCode { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public decimal? BandLevel { get; set; }
        public string Topic { get; set; }
        public int SoCauHoi { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
