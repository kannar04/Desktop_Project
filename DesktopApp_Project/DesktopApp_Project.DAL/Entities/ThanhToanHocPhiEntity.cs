using System;
using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.ThanhToanHocPhi")]
    public class ThanhToanHocPhiEntity
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
            public int MaThanhToan { get; set; }
    
            [Column] public int MaNguoiDung { get; set; }
            [Column] public int? MaLopHoc { get; set; }
            [Column] public decimal SoTien { get; set; }
            [Column] public decimal? SoTienGoc { get; set; }
            [Column] public decimal PhanTramGiam { get; set; }
            [Column] public decimal SoTienGiam { get; set; }
            [Column] public decimal? SoTienCuoi { get; set; }
            [Column] public string ThongTinNganHang { get; set; }
            [Column] public DateTime NgayTao { get; set; }
            [Column] public DateTime HanThanhToan { get; set; }
            [Column] public string MaHoaDon { get; set; }
            [Column] public string PhuongThucThanhToan { get; set; }
            [Column] public DateTime? NgayThanhToan { get; set; }
            [Column] public string TrangThai { get; set; }
        }
}

