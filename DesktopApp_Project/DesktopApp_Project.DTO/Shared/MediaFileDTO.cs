// Đối tượng truyền dữ liệu tệp đa phương tiện
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ

namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu tệp đa phương tiện giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class MediaFileDTO
    {
        public string OriginalFileName { get; set; }
        public string FileType { get; set; }
        public string LocalPath { get; set; }
        public string Extension { get; set; }
        public long SizeInBytes { get; set; }
    }
}
