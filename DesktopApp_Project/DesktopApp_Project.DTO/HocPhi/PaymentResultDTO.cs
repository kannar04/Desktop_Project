using System;

namespace DesktopApp_Project.DTO
{
    public class PaymentResultDTO
    {
        public int MaGiaoDich { get; set; }
        public int MaThanhToan { get; set; }
        public string PhuongThuc { get; set; }
        public decimal SoTien { get; set; }
        public string NoiDungThanhToan { get; set; }
        public string MaGiaoDichNgoai { get; set; }
        public string PaymentUrl { get; set; }
        public string QrContent { get; set; }
        public string TrangThai { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
    }
}
