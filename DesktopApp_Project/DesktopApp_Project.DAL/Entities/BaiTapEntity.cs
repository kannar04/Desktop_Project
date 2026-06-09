using System;
// Thực thể dữ liệu ánh xạ bảng bài tập trong cơ sở dữ liệu
// Chức năng:
// - Khai báo các cột LINQ sang SQL
// - Được kho dữ liệu dùng để đọc và ghi dữ liệu cơ sở dữ liệu

using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.BaiTap")]
    // Lớp thực thể dữ liệu ánh xạ dữ liệu bài tập từ bảng cơ sở dữ liệu sang đối tượng C#.
    public class BaiTapEntity
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
            public int MaBaiTap { get; set; }
    
            [Column] public int MaLopHoc { get; set; }
            [Column] public string TieuDe { get; set; }
            [Column] public string MoTa { get; set; }
            [Column] public DateTime Deadline { get; set; }
            [Column] public string FileDinhKem { get; set; }
            [Column] public string LoaiFile { get; set; }
            [Column] public string TenFileGoc { get; set; }
            [Column] public string DuongDanLocal { get; set; }
            [Column] public DateTime NgayTao { get; set; }
        }
}

