// Bộ chuyển đổi thực thể dữ liệu sang đối tượng truyền dữ liệu
// Chức năng:
// - Nhận thực thể dữ liệu từ tầng dữ liệu
// - Tạo đối tượng truyền dữ liệu để tầng nghiệp vụ và giao diện sử dụng mà không lộ lớp ánh xạ cơ sở dữ liệu

using DesktopApp_Project.DTO;

namespace DesktopApp_Project.DAL
{
    // Lớp chuyển đổi thực thể dữ liệu sang đối tượng truyền dữ liệu cho các tầng phía trên.
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
                AudioPath = entity.AudioPath,
                NhanKyNang = entity.NhanKyNang,
                LoaiFile = entity.LoaiFile,
                TenFileGoc = entity.TenFileGoc,
                DuongDanLocal = entity.DuongDanLocal,
                DuongDanCloud = entity.DuongDanCloud,
                ThumbnailPath = entity.ThumbnailPath,
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
                LoaiFile = entity.LoaiFile,
                TenFileGoc = entity.TenFileGoc,
                DuongDanLocal = entity.DuongDanLocal,
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
                KyNang = entity.KyNang,
                BandLevel = entity.BandLevel,
                BandTu = entity.BandTu,
                BandDen = entity.BandDen,
                MoTa = entity.MoTa,
                FileDuLieu = entity.FileDuLieu,
                AudioPath = entity.AudioPath,
                ImagePath = entity.ImagePath,
                TrangThai = entity.TrangThai,
                NgayTao = entity.NgayTao
            };
        }

        public static PaymentResultDTO ToDto(NhatKyThanhToanEntity entity)
        {
            if (entity == null) return null;
            return new PaymentResultDTO
            {
                MaGiaoDich = entity.MaGiaoDich,
                MaThanhToan = entity.MaThanhToan,
                PhuongThuc = entity.PhuongThuc,
                SoTien = entity.SoTien,
                NoiDungThanhToan = entity.NoiDungThanhToan,
                MaGiaoDichNgoai = entity.MaGiaoDichNgoai,
                PaymentUrl = entity.PaymentUrl,
                QrContent = entity.QrContent,
                TrangThai = entity.TrangThai,
                NgayTao = entity.NgayTao,
                NgayCapNhat = entity.NgayCapNhat,
                ReceiverEmail = entity.ReceiverEmail,
                PaymentEmailSent = entity.PaymentEmailSent == true,
                PaymentEmailSentAt = entity.PaymentEmailSentAt,
                PaymentEmailError = entity.PaymentEmailError,
                StatusEmailSent = entity.StatusEmailSent == true,
                StatusEmailSentAt = entity.StatusEmailSentAt,
                StatusEmailError = entity.StatusEmailError,
                LastStatusUpdateAt = entity.LastStatusUpdateAt
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
                QuestionType = entity.QuestionType,
                OptionA = entity.OptionA,
                OptionB = entity.OptionB,
                OptionC = entity.OptionC,
                OptionD = entity.OptionD,
                AnswerKey = entity.AnswerKey,
                Explanation = entity.Explanation,
                PassageId = entity.PassageId,
                SectionId = entity.SectionId,
                BandLevel = entity.BandLevel
            };
        }

        public static ReadingPassageDTO ToDto(ReadingPassageEntity entity)
        {
            if (entity == null) return null;
            return new ReadingPassageDTO
            {
                PassageId = entity.PassageId,
                PassageCode = entity.PassageCode,
                Title = entity.Title,
                Content = entity.Content,
                ImagePath = entity.ImagePath,
                BandLevel = entity.BandLevel,
                Topic = entity.Topic,
                NgayTao = entity.NgayTao,
                CreatedAt = entity.CreatedAt
            };
        }

        public static ListeningSectionDTO ToDto(ListeningSectionEntity entity)
        {
            if (entity == null) return null;
            return new ListeningSectionDTO
            {
                SectionId = entity.SectionId,
                SectionCode = entity.SectionCode,
                Title = entity.Title,
                SectionNumber = entity.SectionNumber,
                PartNo = entity.PartNo,
                AudioPath = entity.AudioPath,
                Transcript = entity.Transcript,
                BandLevel = entity.BandLevel,
                Topic = entity.Topic,
                NgayTao = entity.NgayTao,
                CreatedAt = entity.CreatedAt
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
