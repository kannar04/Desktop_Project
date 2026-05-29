using System;
using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.ChiTiet_DiemSo")]
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


