using System;
using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.ChiTiet_DiemDanh")]
    public class ChiTietDiemDanhEntity
        {
            [Column(IsPrimaryKey = true)] public int MaNguoiDung { get; set; }
            [Column(IsPrimaryKey = true)] public int MaBuoiHoc { get; set; }
            [Column] public string TrangThai { get; set; }
            [Column] public string LyDoVang { get; set; }
        }
}


