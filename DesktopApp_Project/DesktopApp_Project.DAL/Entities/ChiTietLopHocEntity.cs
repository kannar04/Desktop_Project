using System;
using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.ChiTiet_LopHoc")]
    public class ChiTietLopHocEntity
        {
            [Column(IsPrimaryKey = true)] public int MaNguoiDung { get; set; }
            [Column(IsPrimaryKey = true)] public int MaLopHoc { get; set; }
            [Column] public DateTime NgayVaoLop { get; set; }
            [Column] public DateTime? NgayNghiHoc { get; set; }
            [Column] public string TrangThai { get; set; }
        }
}


