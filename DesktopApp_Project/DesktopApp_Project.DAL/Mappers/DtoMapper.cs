using DesktopApp_Project.DTO;

namespace DesktopApp_Project.DAL
{
    internal static class DtoMapper
    {
        public static NguoiDungDTO ToDto(NguoiDungEntity entity)
        {
            if (entity == null) return null;
            return new NguoiDungDTO
            {
                MaNguoiDung = entity.MaNguoiDung,
                VaiTro = entity.VaiTro,
                HoTen = entity.HoTen,
                NgaySinh = entity.NgaySinh,
                SDT = entity.SDT,
                Email = entity.Email,
                TrinhDoDauVao = entity.TrinhDoDauVao,
                TaiKhoan = entity.TaiKhoan,
                MatKhau = entity.MatKhau
            };
        }

        public static LopHocDTO ToDto(LopHocEntity entity)
        {
            if (entity == null) return null;
            return new LopHocDTO
            {
                MaLopHoc = entity.MaLopHoc,
                MaGiaoVien = entity.MaGiaoVien,
                TenLop = entity.TenLop,
                NhomTrinhDo = entity.NhomTrinhDo,
                LichHoc = entity.LichHoc
            };
        }

        public static TaiLieuDTO ToDto(TaiLieuEntity entity)
        {
            if (entity == null) return null;
            return new TaiLieuDTO
            {
                MaTaiLieu = entity.MaTaiLieu,
                MaLopHoc = entity.MaLopHoc,
                TenChuDe = entity.TenChuDe,
                NoiDungMoTa = entity.NoiDungMoTa,
                DuongDanFile = entity.DuongDanFile,
                VideoLink = entity.VideoLink,
                NhanKyNang = entity.NhanKyNang,
                NgayCapNhat = entity.NgayCapNhat
            };
        }

        public static BaiTapDTO ToDto(BaiTapEntity entity)
        {
            if (entity == null) return null;
            return new BaiTapDTO
            {
                MaBaiTap = entity.MaBaiTap,
                MaLopHoc = entity.MaLopHoc,
                TieuDe = entity.TieuDe,
                MoTa = entity.MoTa,
                Deadline = entity.Deadline,
                FileDinhKem = entity.FileDinhKem,
                NgayTao = entity.NgayTao
            };
        }

        public static BuoiHocDTO ToDto(BuoiHocEntity entity)
        {
            if (entity == null) return null;
            return new BuoiHocDTO
            {
                MaBuoiHoc = entity.MaBuoiHoc,
                MaLopHoc = entity.MaLopHoc,
                NgayHoc = entity.NgayHoc
            };
        }

        public static DeThiDTO ToDto(DeThiEntity entity)
        {
            if (entity == null) return null;
            return new DeThiDTO
            {
                MaDeThi = entity.MaDeThi,
                TenDeThi = entity.TenDeThi,
                FileDuLieu = entity.FileDuLieu,
                NgayTao = entity.NgayTao
            };
        }

        public static CauHoiDTO ToDto(CauHoiEntity entity)
        {
            if (entity == null) return null;
            return new CauHoiDTO
            {
                MaCauHoi = entity.MaCauHoi,
                NoiDung = entity.NoiDung,
                DapAn = entity.DapAn,
                NhanKyNang = entity.NhanKyNang,
                BandLevel = entity.BandLevel
            };
        }

        public static DotKiemTraDTO ToDto(DotKiemTraEntity entity)
        {
            if (entity == null) return null;
            return new DotKiemTraDTO
            {
                MaDotKiemTra = entity.MaDotKiemTra,
                MaLopHoc = entity.MaLopHoc,
                MaDeThi = entity.MaDeThi.HasValue ? entity.MaDeThi.Value : 0,
                TenDotKiemTra = entity.TenDotKiemTra,
                NgayKiemTra = entity.NgayKiemTra
            };
        }

        public static TuVungDTO ToDto(TuVungEntity entity)
        {
            if (entity == null) return null;
            return new TuVungDTO
            {
                MaTuVung = entity.MaTuVung,
                MaLopHoc = entity.MaLopHoc,
                TuTiengAnh = entity.TuTiengAnh,
                TuLoai = entity.TuLoai,
                PhienAm = entity.PhienAm,
                Nghia = entity.Nghia,
                CapDo = entity.CapDo,
                ChuDe = entity.ChuDe
            };
        }

        public static ThongBaoDTO ToDto(ThongBaoEntity entity)
        {
            if (entity == null) return null;
            return new ThongBaoDTO
            {
                MaThongBao = entity.MaThongBao,
                MaNguoiGui = entity.MaNguoiGui,
                TieuDe = entity.TieuDe,
                NoiDung = entity.NoiDung,
                DoiTuongNhan = entity.DoiTuongNhan,
                ThoiGianGui = entity.ThoiGianGui
            };
        }
    }
}
