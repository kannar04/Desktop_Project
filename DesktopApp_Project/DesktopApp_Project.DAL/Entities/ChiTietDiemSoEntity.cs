using System;
// Thực thể dữ liệu ánh xạ bảng chi tiết điểm số trong cơ sở dữ liệu
// Chức năng:
// - Khai báo các cột LINQ sang SQL
// - Được kho dữ liệu dùng để đọc và ghi dữ liệu cơ sở dữ liệu

using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.ChiTiet_DiemSo")]
    // Lớp thực thể dữ liệu ánh xạ dữ liệu chi tiết điểm số từ bảng cơ sở dữ liệu sang đối tượng C#.
    public class ChiTietDiemSoEntity
        {
            [Column(IsPrimaryKey = true)] public int MaNguoiDung { get; set; }
            [Column(IsPrimaryKey = true)] public int MaDotKiemTra { get; set; }
            [Column] public decimal? DiemL { get; set; }
            [Column] public decimal? DiemR { get; set; }
            [Column] public decimal? DiemW { get; set; }
            [Column] public decimal? DiemS { get; set; }
            [Column] public decimal? DiemTong { get; set; }
            [Column] public string NhanXet { get; set; }
        }
}


