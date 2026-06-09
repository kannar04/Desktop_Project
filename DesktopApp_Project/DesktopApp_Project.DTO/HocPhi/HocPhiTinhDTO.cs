using System;
// Đối tượng truyền dữ liệu học phí đã tính
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ


namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu học phí đã tính giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class HocPhiTinhDTO
        {
            public int MaNguoiDung { get; set; }
            public int MaLopHoc { get; set; }
            public string HoTen { get; set; }
            public DateTime NgayVaoLop { get; set; }
            public decimal SoTienGoc { get; set; }
            public decimal PhanTramGiam { get; set; }
            public decimal SoTienGiam { get; set; }
            public decimal SoTienCuoi { get; set; }
            public string TrangThai { get; set; }
            public string GhiChu { get; set; }
        }
}

