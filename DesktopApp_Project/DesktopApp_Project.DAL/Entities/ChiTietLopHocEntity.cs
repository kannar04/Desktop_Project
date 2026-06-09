using System;
// Thực thể dữ liệu ánh xạ bảng chi tiết lớp học trong cơ sở dữ liệu
// Chức năng:
// - Khai báo các cột LINQ sang SQL
// - Được kho dữ liệu dùng để đọc và ghi dữ liệu cơ sở dữ liệu

using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.ChiTiet_LopHoc")]
    // Lớp thực thể dữ liệu ánh xạ dữ liệu chi tiết lớp học từ bảng cơ sở dữ liệu sang đối tượng C#.
    public class ChiTietLopHocEntity
        {
            [Column(IsPrimaryKey = true)] public int MaNguoiDung { get; set; }
            [Column(IsPrimaryKey = true)] public int MaLopHoc { get; set; }
            [Column] public DateTime NgayVaoLop { get; set; }
            [Column] public DateTime? NgayNghiHoc { get; set; }
            [Column] public string TrangThai { get; set; }
        }
}


