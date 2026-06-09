// Thực thể dữ liệu ánh xạ bảng nhật ký thanh toán trong cơ sở dữ liệu
// Chức năng:
// - Khai báo các cột LINQ sang SQL
// - Được kho dữ liệu dùng để đọc và ghi dữ liệu cơ sở dữ liệu

using System;
using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.NhatKyThanhToan")]
    // Lớp thực thể dữ liệu ánh xạ dữ liệu nhật ký thanh toán từ bảng cơ sở dữ liệu sang đối tượng C#.
    public class NhatKyThanhToanEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int MaGiaoDich { get; set; }

        [Column] public int MaThanhToan { get; set; }
        [Column] public string PhuongThuc { get; set; }
        [Column] public decimal SoTien { get; set; }
        [Column] public string NoiDungThanhToan { get; set; }
        [Column] public string MaGiaoDichNgoai { get; set; }
        [Column] public string PaymentUrl { get; set; }
        [Column] public string QrContent { get; set; }
        [Column] public string TrangThai { get; set; }
        [Column] public DateTime NgayTao { get; set; }
        [Column] public DateTime? NgayCapNhat { get; set; }
        [Column] public string ReceiverEmail { get; set; }
        [Column] public string DebugStudentName { get; set; }
        [Column] public string DebugClassName { get; set; }
        [Column] public string DebugNote { get; set; }
        [Column] public bool? IsDebugPayment { get; set; }
        [Column] public bool? PaymentEmailSent { get; set; }
        [Column] public DateTime? PaymentEmailSentAt { get; set; }
        [Column] public string PaymentEmailError { get; set; }
        [Column] public bool? StatusEmailSent { get; set; }
        [Column] public DateTime? StatusEmailSentAt { get; set; }
        [Column] public string StatusEmailError { get; set; }
        [Column] public DateTime? LastStatusUpdateAt { get; set; }
    }
}
