using System;
// Đối tượng truyền dữ liệu lịch học theo tuần
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ


namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu lịch học theo tuần giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class WeeklyScheduleDTO
        {
            public int MaLopHoc { get; set; }
            public string TenLop { get; set; }
            public string LichHoc { get; set; }
            public DateTime NgayHoc { get; set; }
            public string ThuTrongTuan { get; set; }
        }
}

