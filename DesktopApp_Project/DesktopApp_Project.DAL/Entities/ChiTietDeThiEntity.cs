using System;
// Thực thể dữ liệu ánh xạ bảng chi tiết đề thi trong cơ sở dữ liệu
// Chức năng:
// - Khai báo các cột LINQ sang SQL
// - Được kho dữ liệu dùng để đọc và ghi dữ liệu cơ sở dữ liệu

using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.ChiTiet_DeThi")]
    // Lớp thực thể dữ liệu ánh xạ dữ liệu chi tiết đề thi từ bảng cơ sở dữ liệu sang đối tượng C#.
    public class ChiTietDeThiEntity
        {
            [Column(IsPrimaryKey = true)] public int MaDeThi { get; set; }
            [Column(IsPrimaryKey = true)] public int MaCauHoi { get; set; }
            [Column] public string GroupType { get; set; }
            [Column] public int? GroupId { get; set; }
            [Column] public int? ThuTu { get; set; }
            [Column] public decimal? Diem { get; set; }
            [Column] public string GhiChu { get; set; }
        }
}
