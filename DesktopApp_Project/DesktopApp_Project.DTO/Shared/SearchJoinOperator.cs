// Đối tượng truyền dữ liệu toán tử nối điều kiện tìm kiếm
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ

namespace DesktopApp_Project.DTO
{
    // Kiểu liệt kê biểu diễn toán tử nối điều kiện tìm kiếm dùng trong luồng xử lý nghiệp vụ.
    public enum SearchJoinOperator
    {
        And,
        Or
    }
}
