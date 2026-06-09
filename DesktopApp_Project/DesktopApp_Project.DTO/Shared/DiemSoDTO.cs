using System;
// Đối tượng truyền dữ liệu điểm số
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ


namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu điểm số giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class DiemSoDTO
        {
            public int MaNguoiDung { get; set; }
            public int MaDotKiemTra { get; set; }
            public string HoTen { get; set; }
            public decimal? DiemL { get; set; }
            public decimal? DiemR { get; set; }
            public decimal? DiemW { get; set; }
            public decimal? DiemS { get; set; }
            public decimal? DiemTong { get; set; }
            public string NhanXet { get; set; }
        }
}

