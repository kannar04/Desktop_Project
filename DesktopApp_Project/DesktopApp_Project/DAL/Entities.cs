using System;
using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.NguoiDung")]
    public class NguoiDungEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int MaNguoiDung { get; set; }

        [Column] public string VaiTro { get; set; }
        [Column] public string HoTen { get; set; }
        [Column] public DateTime? NgaySinh { get; set; }
        [Column] public string SDT { get; set; }
        [Column] public string Email { get; set; }
        [Column] public string TrinhDoDauVao { get; set; }
        [Column] public string TaiKhoan { get; set; }
        [Column] public string MatKhau { get; set; }
    }

    [Table(Name = "dbo.LopHoc")]
    public class LopHocEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int MaLopHoc { get; set; }

        [Column] public int MaGiaoVien { get; set; }
        [Column] public string TenLop { get; set; }
        [Column] public string NhomTrinhDo { get; set; }
        [Column] public string LichHoc { get; set; }
    }

    [Table(Name = "dbo.ChiTiet_LopHoc")]
    public class ChiTietLopHocEntity
    {
        [Column(IsPrimaryKey = true)] public int MaNguoiDung { get; set; }
        [Column(IsPrimaryKey = true)] public int MaLopHoc { get; set; }
    }

    [Table(Name = "dbo.TaiLieu")]
    public class TaiLieuEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int MaTaiLieu { get; set; }

        [Column] public int MaLopHoc { get; set; }
        [Column] public string TenChuDe { get; set; }
        [Column] public string NoiDungMoTa { get; set; }
        [Column] public string DuongDanFile { get; set; }
        [Column] public string VideoLink { get; set; }
        [Column] public string NhanKyNang { get; set; }
        [Column] public DateTime NgayCapNhat { get; set; }
    }

    [Table(Name = "dbo.BaiTap")]
    public class BaiTapEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int MaBaiTap { get; set; }

        [Column] public int MaLopHoc { get; set; }
        [Column] public string TieuDe { get; set; }
        [Column] public string MoTa { get; set; }
        [Column] public DateTime Deadline { get; set; }
        [Column] public string FileDinhKem { get; set; }
        [Column] public DateTime NgayTao { get; set; }
    }

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

    [Table(Name = "dbo.BuoiHoc")]
    public class BuoiHocEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int MaBuoiHoc { get; set; }

        [Column] public int MaLopHoc { get; set; }
        [Column] public DateTime NgayHoc { get; set; }
    }

    [Table(Name = "dbo.ChiTiet_DiemDanh")]
    public class ChiTietDiemDanhEntity
    {
        [Column(IsPrimaryKey = true)] public int MaNguoiDung { get; set; }
        [Column(IsPrimaryKey = true)] public int MaBuoiHoc { get; set; }
        [Column] public string TrangThai { get; set; }
        [Column] public string LyDoVang { get; set; }
    }

    [Table(Name = "dbo.DeThi")]
    public class DeThiEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int MaDeThi { get; set; }

        [Column] public string TenDeThi { get; set; }
        [Column] public string FileDuLieu { get; set; }
        [Column] public DateTime NgayTao { get; set; }
    }

    [Table(Name = "dbo.CauHoi")]
    public class CauHoiEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int MaCauHoi { get; set; }

        [Column] public string NoiDung { get; set; }
        [Column] public string DapAn { get; set; }
        [Column] public string NhanKyNang { get; set; }
    }

    [Table(Name = "dbo.ChiTiet_DeThi")]
    public class ChiTietDeThiEntity
    {
        [Column(IsPrimaryKey = true)] public int MaDeThi { get; set; }
        [Column(IsPrimaryKey = true)] public int MaCauHoi { get; set; }
    }

    [Table(Name = "dbo.DotKiemTra")]
    public class DotKiemTraEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int MaDotKiemTra { get; set; }

        [Column] public int MaLopHoc { get; set; }
        [Column] public int? MaDeThi { get; set; }
        [Column] public string TenDotKiemTra { get; set; }
        [Column] public DateTime NgayKiemTra { get; set; }
    }

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

    [Table(Name = "dbo.TuVung")]
    public class TuVungEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int MaTuVung { get; set; }

        [Column] public int MaLopHoc { get; set; }
        [Column] public string TuTiengAnh { get; set; }
        [Column] public string TuLoai { get; set; }
        [Column] public string PhienAm { get; set; }
        [Column] public string Nghia { get; set; }
    }

    [Table(Name = "dbo.TienTrinh_Flashcard")]
    public class TienTrinhFlashcardEntity
    {
        [Column(IsPrimaryKey = true)] public int MaNguoiDung { get; set; }
        [Column(IsPrimaryKey = true)] public int MaTuVung { get; set; }
        [Column] public string KetQua { get; set; }
    }

    [Table(Name = "dbo.ThongBao")]
    public class ThongBaoEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int MaThongBao { get; set; }

        [Column] public int MaNguoiGui { get; set; }
        [Column] public string TieuDe { get; set; }
        [Column] public string NoiDung { get; set; }
        [Column] public string DoiTuongNhan { get; set; }
        [Column] public DateTime ThoiGianGui { get; set; }
    }

    [Table(Name = "dbo.ChiTiet_ThongBao")]
    public class ChiTietThongBaoEntity
    {
        [Column(IsPrimaryKey = true)] public int MaThongBao { get; set; }
        [Column(IsPrimaryKey = true)] public int MaNguoiDung { get; set; }
        [Column] public bool DaDoc { get; set; }
    }

    [Table(Name = "dbo.ThanhToanHocPhi")]
    public class ThanhToanHocPhiEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int MaThanhToan { get; set; }

        [Column] public int MaNguoiDung { get; set; }
        [Column] public decimal SoTien { get; set; }
        [Column] public string ThongTinNganHang { get; set; }
        [Column] public DateTime NgayTao { get; set; }
        [Column] public DateTime HanThanhToan { get; set; }
        [Column] public string TrangThai { get; set; }
    }

    [Table(Name = "dbo.NhatKyBaoCao")]
    public class NhatKyBaoCaoEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int MaNhatKy { get; set; }

        [Column] public int MaNguoiDung { get; set; }
        [Column] public string LoaiBaoCao { get; set; }
        [Column] public string TieuChi { get; set; }
        [Column] public DateTime ThoiGianTao { get; set; }
    }
}
