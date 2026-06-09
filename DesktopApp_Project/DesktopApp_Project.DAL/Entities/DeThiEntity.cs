using System;
// Thực thể dữ liệu ánh xạ bảng đề thi IELTS trong cơ sở dữ liệu
// Chức năng:
// - Khai báo các cột LINQ sang SQL
// - Được kho dữ liệu dùng để đọc và ghi dữ liệu cơ sở dữ liệu

using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.DeThi")]
    // Lớp thực thể dữ liệu ánh xạ dữ liệu đề thi IELTS từ bảng cơ sở dữ liệu sang đối tượng C#.
    public class DeThiEntity
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
            public int MaDeThi { get; set; }
    
            [Column] public string TenDeThi { get; set; }
            [Column] public string KyNang { get; set; }
            [Column] public decimal? BandLevel { get; set; }
            [Column] public decimal? BandTu { get; set; }
            [Column] public decimal? BandDen { get; set; }
            [Column] public string MoTa { get; set; }
            [Column] public string FileDuLieu { get; set; }
            [Column] public string AudioPath { get; set; }
            [Column] public string ImagePath { get; set; }
            [Column] public DateTime NgayTao { get; set; }
            [Column] public string TrangThai { get; set; }
        }
}
