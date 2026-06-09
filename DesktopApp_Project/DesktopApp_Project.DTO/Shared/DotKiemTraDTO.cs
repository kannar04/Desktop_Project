using System;
// Đối tượng truyền dữ liệu đợt kiểm tra
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ


namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu đợt kiểm tra giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class DotKiemTraDTO
        {
            public int MaDotKiemTra { get; set; }
            public int MaLopHoc { get; set; }
            public int MaDeThi { get; set; }
            public string TenDotKiemTra { get; set; }
            public DateTime NgayKiemTra { get; set; }
        }
}

