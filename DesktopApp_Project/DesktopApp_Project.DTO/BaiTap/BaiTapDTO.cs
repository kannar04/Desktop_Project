using System;
// Đối tượng truyền dữ liệu bài tập
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ


namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu bài tập giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class BaiTapDTO
        {
            public int MaBaiTap { get; set; }
            public int MaLopHoc { get; set; }
            public string TieuDe { get; set; }
            public string MoTa { get; set; }
            public DateTime Deadline { get; set; }
            public string FileDinhKem { get; set; }
            public string LoaiFile { get; set; }
            public string TenFileGoc { get; set; }
            public string DuongDanLocal { get; set; }
            public DateTime NgayTao { get; set; }
        }
}
