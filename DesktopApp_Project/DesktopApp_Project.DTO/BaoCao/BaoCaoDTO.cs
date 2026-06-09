using System;
// Đối tượng truyền dữ liệu báo cáo
// Chức năng:
// - Truyền dữ liệu giữa giao diện, tầng nghiệp vụ và tầng dữ liệu
// - Chứa các thuộc tính phục vụ hiển thị hoặc xử lý nghiệp vụ


namespace DesktopApp_Project.DTO
{
    // Lớp đối tượng truyền dữ liệu dùng để truyền dữ liệu báo cáo giữa các tầng giao diện, tầng nghiệp vụ và tầng dữ liệu.
    public class BaoCaoDTO
        {
            public string LoaiBaoCao { get; set; }
            public int? MaLopHoc { get; set; }
            public int? MaNguoiDung { get; set; }
            public DateTime? TuNgay { get; set; }
            public DateTime? DenNgay { get; set; }
        }
}

