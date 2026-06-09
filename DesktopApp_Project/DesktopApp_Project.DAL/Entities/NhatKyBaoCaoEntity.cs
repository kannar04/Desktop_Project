using System;
// Thực thể dữ liệu ánh xạ bảng nhật ký báo cáo trong cơ sở dữ liệu
// Chức năng:
// - Khai báo các cột LINQ sang SQL
// - Được kho dữ liệu dùng để đọc và ghi dữ liệu cơ sở dữ liệu

using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.NhatKyBaoCao")]
    // Lớp thực thể dữ liệu ánh xạ dữ liệu nhật ký báo cáo từ bảng cơ sở dữ liệu sang đối tượng C#.
    public class NhatKyBaoCaoEntity
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
            public int MaNhatKy { get; set; }
    
            [Column] public int MaNguoiDung { get; set; }
            [Column] public string LoaiBaoCao { get; set; }
            [Column] public string TieuChi { get; set; }
            [Column] public DateTime ThoiGianTao { get; set; }
        }
}


