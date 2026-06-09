// Đối tượng truyền dữ liệu kết quả gửi học phí hàng loạt
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ

using System.Collections.Generic;

namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu kết quả gửi học phí hàng loạt giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class BatchSendTuitionResultDTO
    {
        // Khởi tạo đối tượng phục vụ xử lý kết quả gửi học phí hàng loạt.
        public BatchSendTuitionResultDTO()
        {
            Items = new List<BatchSendTuitionItemResultDTO>();
        }

        public int TotalCount { get; set; }
        public int SuccessCount { get; set; }
        public int FailedCount { get; set; }
        public List<BatchSendTuitionItemResultDTO> Items { get; set; }
    }
}
