using System;
using System.Collections.Generic;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.DAL
{
    public interface IQuanLyIeltsRepository
    {
        bool KiemTraKetNoi(out string error);

        NguoiDungDTO GetNguoiDungByTaiKhoan(string taiKhoan);
        NguoiDungDTO GetNguoiDungById(int maNguoiDung);
        List<NguoiDungDTO> GetNguoiDungByVaiTro(string vaiTro);
        List<NguoiDungDTO> SearchHocVien(string keyword);
        List<NguoiDungDTO> SearchHocVien(HocVienSearchCriteriaDTO criteria);
        int InsertNguoiDung(NguoiDungDTO dto);
        void UpdateNguoiDung(NguoiDungDTO dto);
        void DeleteNguoiDung(int maNguoiDung);
        bool ExistsTaiKhoan(string taiKhoan, int exceptId);
        bool ExistsEmail(string email, int exceptId);

        List<LopHocDTO> GetLopHoc();
        int InsertLopHoc(LopHocDTO dto);
        void UpdateLopHoc(LopHocDTO dto);
        void DeleteLopHoc(int maLopHoc);
        bool ExistsTenLop(string tenLop, int exceptId);
        bool ExistsLichHoc(string lichHoc, int exceptId);
        List<NguoiDungDTO> GetHocVienTrongLop(int maLopHoc);
        List<HocVienLopDTO> GetHocVienLop(int maLopHoc, bool onlyActive);
        List<NguoiDungDTO> GetHocVienChuaTrongLop(int maLopHoc);
        void ThemHocVienVaoLop(int maNguoiDung, int maLopHoc);
        void XoaHocVienKhoiLop(int maNguoiDung, int maLopHoc);

        List<TaiLieuDTO> GetTaiLieu(int? maLopHoc);
        int InsertTaiLieu(TaiLieuDTO dto);
        void UpdateTaiLieu(TaiLieuDTO dto);
        void DeleteTaiLieu(int maTaiLieu);

        List<BaiTapDTO> GetBaiTap(int? maLopHoc);
        int InsertBaiTap(BaiTapDTO dto);
        void UpdateBaiTap(BaiTapDTO dto);
        void DeleteBaiTap(int maBaiTap);
        void TaoChiTietNopBaiChoLop(int maBaiTap, int maLopHoc);
        List<NopBaiDTO> GetNopBaiTheoBaiTap(int maBaiTap);
        void ChamBai(NopBaiDTO dto);

        List<BuoiHocDTO> GetBuoiHoc(int maLopHoc);
        int GetOrCreateBuoiHoc(int maLopHoc, DateTime ngayHoc);
        List<DiemDanhDTO> GetDiemDanh(int maBuoiHoc);
        void LuuDiemDanh(DiemDanhDTO dto);
        void LuuDiemDanh(IEnumerable<DiemDanhDTO> danhSach);
        decimal TinhTiLeChuyenCan(int maNguoiDung, int maLopHoc, int? thang = null, int? nam = null);

        List<DeThiDTO> GetDeThi();
        int InsertDeThi(DeThiDTO dto);
        void UpdateDeThi(DeThiDTO dto);
        void DeleteDeThi(int maDeThi);
        List<ReadingPassageDTO> GetReadingPassages(decimal? bandTu, decimal? bandDen);
        List<ListeningSectionDTO> GetListeningSections(decimal? bandTu, decimal? bandDen);
        ReadingPassageDTO GetReadingPassageById(int maPassage);
        ListeningSectionDTO GetListeningSectionById(int maSection);
        int InsertReadingPassage(ReadingPassageDTO dto);
        void InsertReadingPassageBulk(IEnumerable<ReadingPassageDTO> danhSach);
        int InsertListeningSection(ListeningSectionDTO dto);
        void InsertListeningSectionBulk(IEnumerable<ListeningSectionDTO> danhSach);
        List<CauHoiDTO> GetCauHoi(string keyword);
        List<CauHoiDTO> SearchCauHoi(CauHoiSearchCriteriaDTO criteria);
        List<CauHoiDTO> GetCauHoiByPassageId(int maPassage);
        List<CauHoiDTO> GetCauHoiBySectionId(int maSection);
        int InsertCauHoi(CauHoiDTO dto);
        void InsertCauHoiBulk(IEnumerable<CauHoiDTO> danhSach);
        void UpdateCauHoi(CauHoiDTO dto);
        void DeleteCauHoi(int maCauHoi);
        int GetNextThuTu(int maDeThi);
        bool ExistsQuestionInExam(int maDeThi, int maCauHoi);
        void ThemCauHoiVaoDeThi(int maDeThi, int maCauHoi);
        void ThemCauHoiVaoDeThi(int maDeThi, int maCauHoi, string groupType, int? groupId, int? thuTu);
        void XoaCauHoiKhoiDeThi(int maDeThi, int maCauHoi);
        List<IeltsExamItemDTO> GetNoiDungDeThi(int maDeThi);
        int ImportIeltsRows(IEnumerable<IeltsImportRowDTO> rows);

        List<DotKiemTraDTO> GetDotKiemTra(int maLopHoc);
        int InsertDotKiemTra(DotKiemTraDTO dto);
        List<DiemSoDTO> GetDiemSo(int maDotKiemTra);
        bool ExistsDiemSo(int maNguoiDung, int maDotKiemTra);
        void InsertDiemSo(DiemSoDTO dto);

        List<TuVungDTO> GetTuVung(int? maLopHoc);
        List<TuVungDTO> SearchTuVung(TuVungSearchCriteriaDTO criteria);
        bool ExistsTuVungTrongLop(string tuTiengAnh, int maLopHoc, int exceptId);
        int InsertTuVung(TuVungDTO dto);
        void UpdateTuVung(TuVungDTO dto);
        void DeleteTuVung(int maTuVung);
        void DongBoFlashcardChoLop(int maTuVung, int maLopHoc);

        List<ThongBaoDTO> GetThongBao();
        int InsertThongBao(ThongBaoDTO dto);
        void TaoNguoiNhanThongBao(int maThongBao, IEnumerable<int> maNguoiNhan);

        List<ThanhToanHocPhiDTO> GetHocPhi();
        List<ThanhToanHocPhiDTO> GetHocPhi(int? maLopHoc, DateTime? tuNgay, DateTime? denNgay);
        int InsertHocPhi(ThanhToanHocPhiDTO dto);
        void InsertHocPhiBulk(IEnumerable<ThanhToanHocPhiDTO> danhSach);
        void UpdateTrangThaiHocPhi(int maThanhToan, string trangThai);
        PaymentResultDTO TaoNhatKyThanhToan(PaymentRequestDTO request, string maGiaoDichNgoai, string paymentUrl, string qrContent);
        PaymentResultDTO LayGiaoDichThanhToan(int maGiaoDich);
        List<PaymentResultDTO> LayGiaoDichTheoThanhToan(int maThanhToan);
        int TaoHocPhiDebug(PaymentDebugRequestDTO request, string invoiceCode);
        PaymentDebugResultDTO TaoNhatKyThanhToanDebug(PaymentDebugRequestDTO request, int maThanhToan, string maGiaoDichNgoai, string paymentUrl, string qrContent);
        List<PaymentDebugResultDTO> LayGiaoDichDebugGanDay(int limit);
        PaymentDebugResultDTO LayChiTietGiaoDichDebug(int maGiaoDich);
        void CapNhatEmailThanhToan(int maGiaoDich, bool sent, DateTime? sentAt, string error);
        void CapNhatEmailTrangThai(int maGiaoDich, bool sent, DateTime? sentAt, string error);
        void CapNhatTrangThaiGiaoDich(int maGiaoDich, string trangThai);
        void CapNhatTrangThaiHocPhi(int maThanhToan, string trangThai, string phuongThuc, DateTime? ngayThanhToan);
        HoaDonHocPhiDTO LayHoaDonHocPhi(int maThanhToan);
        List<HoaDonHocPhiDTO> LayHoaDonHocPhiTheoKhoangNgay(DateTime tuNgay, DateTime denNgay);
        List<BaoCaoDoanhThuDTO> LayBaoCaoDoanhThu(DateTime tuNgay, DateTime denNgay);
        void CapNhatThongTinHoaDon(int maThanhToan, string maHoaDon);

        DashboardSummaryDTO GetDashboardSummary(DateTime today);
        List<MonthlyRevenueDTO> GetRevenueByMonth(int months, DateTime today);
        List<WeeklyScheduleDTO> GetWeeklySchedule(DateTime weekStart);
        List<BaoCaoDiemDTO> GetBaoCaoDiem(int? maLopHoc);
        List<BaoCaoBaiTapDTO> GetBaoCaoBaiTap(int? maLopHoc);
        List<BaoCaoChuyenCanDTO> GetBaoCaoChuyenCan(int maLopHoc);
        List<BaoCaoCuoiKyDTO> GetBaoCaoCuoiKy(int maLopHoc);
        void GhiNhatKyBaoCao(int maNguoiDung, string loaiBaoCao, string tieuChi);
    }
}
