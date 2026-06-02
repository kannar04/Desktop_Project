using System;
using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.ChiTiet_DeThi")]
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
