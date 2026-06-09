using System;
// Đối tượng truyền dữ liệu điểm danh
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ


namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu điểm danh giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class DiemDanhDTO
        {
            public int MaNguoiDung { get; set; }
            public int MaBuoiHoc { get; set; }
            public string HoTen { get; set; }
            public bool CoMat { get; set; }
            public string TrangThai { get; set; }
            public string LyDoVang { get; set; }
            public decimal TiLeChuyenCan { get; set; }
        }
}

