using System;
// Đối tượng truyền dữ liệu tài liệu học tập
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ


namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu tài liệu học tập giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class TaiLieuDTO
        {
            public int MaTaiLieu { get; set; }
            public int MaLopHoc { get; set; }
            public string TenChuDe { get; set; }
            public string NoiDungMoTa { get; set; }
            public string DuongDanFile { get; set; }
            public string VideoLink { get; set; }
            public string AudioPath { get; set; }
            public string NhanKyNang { get; set; }
            public string LoaiFile { get; set; }
            public string TenFileGoc { get; set; }
            public string DuongDanLocal { get; set; }
            public string DuongDanCloud { get; set; }
            public string ThumbnailPath { get; set; }
            public DateTime NgayCapNhat { get; set; }
        }
}
