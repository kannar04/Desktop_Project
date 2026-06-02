using System;
using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.DeThi")]
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
