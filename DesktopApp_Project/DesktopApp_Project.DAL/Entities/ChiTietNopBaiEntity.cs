using System;
using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.ChiTiet_NopBai")]
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


