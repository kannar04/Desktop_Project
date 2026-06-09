using System;
// Thực thể dữ liệu ánh xạ bảng chi tiết nộp bài trong cơ sở dữ liệu
// Chức năng:
// - Khai báo các cột LINQ sang SQL
// - Được kho dữ liệu dùng để đọc và ghi dữ liệu cơ sở dữ liệu

using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.ChiTiet_NopBai")]
    // Lớp thực thể dữ liệu ánh xạ dữ liệu chi tiết nộp bài từ bảng cơ sở dữ liệu sang đối tượng C#.
    public class ChiTietNopBaiEntity
        {
            [Column(IsPrimaryKey = true)] public int MaNguoiDung { get; set; }
            [Column(IsPrimaryKey = true)] public int MaBaiTap { get; set; }
            [Column] public string FileBaiLam { get; set; }
            [Column] public DateTime? ThoiGianNop { get; set; }
            [Column] public string TrangThaiNop { get; set; }
            [Column] public decimal? DiemSo { get; set; }
            [Column] public string NhanXet { get; set; }
        }
}


