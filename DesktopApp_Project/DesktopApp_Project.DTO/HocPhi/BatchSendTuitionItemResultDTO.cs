// Đối tượng truyền dữ liệu kết quả gửi học phí cho từng học viên
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ

namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu kết quả gửi học phí cho từng học viên giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class BatchSendTuitionItemResultDTO
    {
        public int HocPhiId { get; set; }
        public string HocVienName { get; set; }
        public string Email { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
