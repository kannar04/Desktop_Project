// Đối tượng truyền dữ liệu yêu cầu thanh toán
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ

namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu yêu cầu thanh toán giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class PaymentRequestDTO
    {
        public int MaThanhToan { get; set; }
        public decimal SoTien { get; set; }
        public string PhuongThuc { get; set; }
        public string NoiDungThanhToan { get; set; }
        public string EmailNguoiNhan { get; set; }
    }
}
