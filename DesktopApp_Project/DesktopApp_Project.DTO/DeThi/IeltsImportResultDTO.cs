// Đối tượng truyền dữ liệu kết quả nhập IELTS
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ

using System.Collections.Generic;

namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu kết quả nhập IELTS giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class IeltsImportResultDTO
    {
        public int PassageCount { get; set; }
        public int SectionCount { get; set; }
        public int QuestionCount { get; set; }
        public List<string> Errors { get; set; }

        // Khởi tạo đối tượng phục vụ xử lý kết quả nhập IELTS.
        public IeltsImportResultDTO()
        {
            Errors = new List<string>();
        }
    }
}
