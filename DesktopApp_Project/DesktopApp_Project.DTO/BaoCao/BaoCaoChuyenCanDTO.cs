using System;
// Đối tượng truyền dữ liệu báo cáo chuyên cần
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ


namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu báo cáo chuyên cần giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class BaoCaoChuyenCanDTO
        {
            public int MaNguoiDung { get; set; }
            public string HoTen { get; set; }
            public int SoBuoiCoMat { get; set; }
            public int SoBuoiVang { get; set; }
            public decimal TiLeChuyenCan { get; set; }
        }
}

