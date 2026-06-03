using System;

namespace DesktopApp_Project.DTO
{
    public class BaoCaoDoanhThuDTO
    {
        public DateTime Ngay { get; set; }
        public int? MaLopHoc { get; set; }
        public string TenLop { get; set; }
        public int SoPhieu { get; set; }
        public int SoPhieuDaThanhToan { get; set; }
        public decimal TongTienDaThanhToan { get; set; }
    }
}
