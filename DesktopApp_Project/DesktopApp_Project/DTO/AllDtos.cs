using System;

namespace DesktopApp_Project.DTO
{
    public class NguoiDungDTO
    {
        public int MaNguoiDung { get; set; }
        public string VaiTro { get; set; }
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string TrinhDoDauVao { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
    }

    public class LopHocDTO
    {
        public int MaLopHoc { get; set; }
        public int MaGiaoVien { get; set; }
        public string TenLop { get; set; }
        public string NhomTrinhDo { get; set; }
        public string LichHoc { get; set; }
    }

    public class ChiTietLopHocDTO
    {
        public int MaNguoiDung { get; set; }
        public int MaLopHoc { get; set; }
    }

    public class TaiLieuDTO
    {
        public int MaTaiLieu { get; set; }
        public int MaLopHoc { get; set; }
        public string TenChuDe { get; set; }
        public string NoiDungMoTa { get; set; }
        public string DuongDanFile { get; set; }
        public string VideoLink { get; set; }
        public string NhanKyNang { get; set; }
        public DateTime NgayCapNhat { get; set; }
    }

    public class BaiTapDTO
    {
        public int MaBaiTap { get; set; }
        public int MaLopHoc { get; set; }
        public string TieuDe { get; set; }
        public string MoTa { get; set; }
        public DateTime Deadline { get; set; }
        public string FileDinhKem { get; set; }
        public DateTime NgayTao { get; set; }
    }

    public class NopBaiDTO
    {
        public int MaNguoiDung { get; set; }
        public int MaBaiTap { get; set; }
        public string HoTen { get; set; }
        public string FileBaiLam { get; set; }
        public DateTime? ThoiGianNop { get; set; }
        public string TrangThaiNop { get; set; }
        public decimal? DiemSo { get; set; }
        public string NhanXet { get; set; }
    }

    public class BuoiHocDTO
    {
        public int MaBuoiHoc { get; set; }
        public int MaLopHoc { get; set; }
        public DateTime NgayHoc { get; set; }
    }

    public class DiemDanhDTO
    {
        public int MaNguoiDung { get; set; }
        public int MaBuoiHoc { get; set; }
        public string HoTen { get; set; }
        public string TrangThai { get; set; }
        public string LyDoVang { get; set; }
        public decimal TiLeChuyenCan { get; set; }
    }

    public class DeThiDTO
    {
        public int MaDeThi { get; set; }
        public string TenDeThi { get; set; }
        public string FileDuLieu { get; set; }
        public DateTime NgayTao { get; set; }
    }

    public class CauHoiDTO
    {
        public int MaCauHoi { get; set; }
        public string NoiDung { get; set; }
        public string DapAn { get; set; }
        public string NhanKyNang { get; set; }
    }

    public class DotKiemTraDTO
    {
        public int MaDotKiemTra { get; set; }
        public int MaLopHoc { get; set; }
        public int MaDeThi { get; set; }
        public string TenDotKiemTra { get; set; }
        public DateTime NgayKiemTra { get; set; }
    }

    public class DiemSoDTO
    {
        public int MaNguoiDung { get; set; }
        public int MaDotKiemTra { get; set; }
        public string HoTen { get; set; }
        public decimal? DiemL { get; set; }
        public decimal? DiemR { get; set; }
        public decimal? DiemW { get; set; }
        public decimal? DiemS { get; set; }
        public decimal? DiemTong { get; set; }
        public string NhanXet { get; set; }
    }

    public class TuVungDTO
    {
        public int MaTuVung { get; set; }
        public int MaLopHoc { get; set; }
        public string TuTiengAnh { get; set; }
        public string TuLoai { get; set; }
        public string PhienAm { get; set; }
        public string Nghia { get; set; }
    }

    public class FlashcardTienTrinhDTO
    {
        public int MaNguoiDung { get; set; }
        public int MaTuVung { get; set; }
        public string KetQua { get; set; }
    }

    public class ThongBaoDTO
    {
        public int MaThongBao { get; set; }
        public int MaNguoiGui { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public string DoiTuongNhan { get; set; }
        public DateTime ThoiGianGui { get; set; }
    }

    public class ThanhToanHocPhiDTO
    {
        public int MaThanhToan { get; set; }
        public int MaNguoiDung { get; set; }
        public string HoTen { get; set; }
        public decimal SoTien { get; set; }
        public string ThongTinNganHang { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime HanThanhToan { get; set; }
        public string TrangThai { get; set; }
    }

    public class BaoCaoDTO
    {
        public string LoaiBaoCao { get; set; }
        public int? MaLopHoc { get; set; }
        public int? MaNguoiDung { get; set; }
        public DateTime? TuNgay { get; set; }
        public DateTime? DenNgay { get; set; }
    }
}
