using System;
// Đối tượng truyền dữ liệu buổi học
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ


namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu buổi học giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class BuoiHocDTO
        {
            public int MaBuoiHoc { get; set; }
            public int MaLopHoc { get; set; }
            public DateTime NgayHoc { get; set; }
        }
}

