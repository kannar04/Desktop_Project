// Đối tượng truyền dữ liệu điều kiện tìm kiếm nâng cao
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ

namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu điều kiện tìm kiếm nâng cao giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class SearchConditionDTO
    {
        public string Field { get; set; }
        public object Value { get; set; }
        public SearchJoinOperator? JoinOperator { get; set; }
        public int OpenParentheses { get; set; }
        public int CloseParentheses { get; set; }
    }
}
