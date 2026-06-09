// Đối tượng truyền dữ liệu phần nghe Listening
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ

using System;

namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu phần nghe Listening giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class ListeningSectionDTO
    {
        public int SectionId { get; set; }
        public string SectionCode { get; set; }
        public string Title { get; set; }
        public int SectionNumber { get; set; }
        public int PartNo { get; set; }
        public string AudioPath { get; set; }
        public string Transcript { get; set; }
        public decimal? BandLevel { get; set; }
        public string Topic { get; set; }
        public int SoCauHoi { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
