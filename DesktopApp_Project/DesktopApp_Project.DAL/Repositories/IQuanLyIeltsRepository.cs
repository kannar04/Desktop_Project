// Hợp đồng khai báo thao tác truy cập dữ liệu
// Chức năng:
// - Định nghĩa các thao tác tầng dữ liệu mà tầng nghiệp vụ được phép gọi
// - Giúp tầng nghiệp vụ không phụ thuộc trực tiếp vào lớp kho dữ liệu cụ thể

using System;
using System.Collections.Generic;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.DAL
{
    // Hợp đồng mô tả các thao tác tầng dữ liệu để tầng nghiệp vụ gọi mà không phụ thuộc lớp cài đặt.
    public interface IQuanLyIeltsRepository
    {
        // Khai báo hàm kiểm tra kết nối cơ sở dữ liệu.
        bool KiemTraKetNoi(out string error);

        // Khai báo hàm lấy thông tin người dùng theo tài khoản.
        NguoiDungDTO GetNguoiDungByTaiKhoan(string taiKhoan);
        // Khai báo hàm lấy thông tin người dùng theo mã.
        NguoiDungDTO GetNguoiDungById(int maNguoiDung);
        // Khai báo hàm lấy danh sách người dùng theo vai trò.
        List<NguoiDungDTO> GetNguoiDungByVaiTro(string vaiTro);
        // Khai báo hàm tìm kiếm danh sách học viên theo tiêu chí tìm kiếm.
        List<NguoiDungDTO> SearchHocVien(string keyword);
        // Khai báo hàm tìm kiếm danh sách học viên theo tiêu chí tìm kiếm.
        List<NguoiDungDTO> SearchHocVien(HocVienSearchCriteriaDTO criteria);
        // Khai báo hàm thêm người dùng mới.
        int InsertNguoiDung(NguoiDungDTO dto);
        // Khai báo hàm cập nhật thông tin người dùng.
        void UpdateNguoiDung(NguoiDungDTO dto);
        // Khai báo hàm xóa người dùng đã chọn.
        void DeleteNguoiDung(int maNguoiDung);
        // Khai báo hàm kiểm tra tài khoản bị trùng.
        bool ExistsTaiKhoan(string taiKhoan, int exceptId);
        // Khai báo hàm kiểm tra thư điện tử bị trùng.
        bool ExistsEmail(string email, int exceptId);

        // Khai báo hàm lấy danh sách lớp học.
        List<LopHocDTO> GetLopHoc();
        // Khai báo hàm thêm lớp học mới.
        int InsertLopHoc(LopHocDTO dto);
        // Khai báo hàm cập nhật thông tin lớp học.
        void UpdateLopHoc(LopHocDTO dto);
        // Khai báo hàm xóa lớp học đã chọn.
        void DeleteLopHoc(int maLopHoc);
        // Khai báo hàm kiểm tra tên lớp bị trùng.
        bool ExistsTenLop(string tenLop, int exceptId);
        // Khai báo hàm kiểm tra lịch học bị trùng.
        bool ExistsLichHoc(string lichHoc, int exceptId);
        // Khai báo hàm lấy danh sách học viên trong lớp.
        List<NguoiDungDTO> GetHocVienTrongLop(int maLopHoc);
        // Khai báo hàm lấy danh sách học viên kèm trạng thái lớp.
        List<HocVienLopDTO> GetHocVienLop(int maLopHoc, bool onlyActive);
        // Khai báo hàm lấy lớp hiện tại của học viên.
        int? GetLopHocDangHocCuaHocVien(int maNguoiDung);
        // Khai báo hàm lưu học viên và chuyển lớp nếu có thay đổi.
        int SaveHocVienVaChuyenLop(NguoiDungDTO dto, int maLopHoc);
        // Khai báo hàm xử lý học viên sang lớp mới.
        void ChuyenHocVienSangLop(int maNguoiDung, int maLopHoc);

        // Khai báo hàm lấy danh sách tài liệu theo lớp.
        List<TaiLieuDTO> GetTaiLieu(int? maLopHoc);
        // Khai báo hàm thêm tài liệu mới.
        int InsertTaiLieu(TaiLieuDTO dto);
        // Khai báo hàm cập nhật thông tin tài liệu.
        void UpdateTaiLieu(TaiLieuDTO dto);
        // Khai báo hàm xóa tài liệu đã chọn.
        void DeleteTaiLieu(int maTaiLieu);

        // Khai báo hàm lấy danh sách bài tập theo lớp.
        List<BaiTapDTO> GetBaiTap(int? maLopHoc);
        // Khai báo hàm thêm bài tập mới.
        int InsertBaiTap(BaiTapDTO dto);
        // Khai báo hàm cập nhật thông tin bài tập.
        void UpdateBaiTap(BaiTapDTO dto);
        // Khai báo hàm xóa bài tập đã chọn.
        void DeleteBaiTap(int maBaiTap);
        // Khai báo hàm tạo dòng nộp bài cho từng học viên trong lớp.
        void TaoChiTietNopBaiChoLop(int maBaiTap, int maLopHoc);
        // Khai báo hàm lấy danh sách bài nộp của bài tập.
        List<NopBaiDTO> GetNopBaiTheoBaiTap(int maBaiTap);
        void ChamBai(NopBaiDTO dto);

        // Khai báo hàm lấy danh sách buổi học của lớp.
        List<BuoiHocDTO> GetBuoiHoc(int maLopHoc);
        // Khai báo hàm lấy buổi học theo ngày, tạo mới nếu chưa có.
        int GetOrCreateBuoiHoc(int maLopHoc, DateTime ngayHoc);
        // Khai báo hàm lấy danh sách điểm danh của buổi học.
        List<DiemDanhDTO> GetDiemDanh(int maBuoiHoc);
        // Khai báo hàm lưu dữ liệu điểm danh.
        void LuuDiemDanh(DiemDanhDTO dto);
        // Khai báo hàm lưu dữ liệu điểm danh.
        void LuuDiemDanh(IEnumerable<DiemDanhDTO> danhSach);
        // Khai báo hàm tính tỉ lệ chuyên cần.
        decimal TinhTiLeChuyenCan(int maNguoiDung, int maLopHoc, int? thang = null, int? nam = null);

        // Khai báo hàm lấy danh sách đề thi.
        List<DeThiDTO> GetDeThi();
        // Khai báo hàm thêm đề thi mới.
        int InsertDeThi(DeThiDTO dto);
        // Khai báo hàm cập nhật thông tin đề thi.
        void UpdateDeThi(DeThiDTO dto);
        // Khai báo hàm xóa đề thi đã chọn.
        void DeleteDeThi(int maDeThi);
        // Khai báo hàm lấy các đoạn Reading theo khoảng band.
        List<ReadingPassageDTO> GetReadingPassages(decimal? bandTu, decimal? bandDen);
        // Khai báo hàm lấy các phần Listening theo khoảng band.
        List<ListeningSectionDTO> GetListeningSections(decimal? bandTu, decimal? bandDen);
        // Khai báo hàm lấy đoạn Reading theo mã.
        ReadingPassageDTO GetReadingPassageById(int maPassage);
        // Khai báo hàm lấy phần Listening theo mã.
        ListeningSectionDTO GetListeningSectionById(int maSection);
        // Khai báo hàm thêm đoạn Reading mới.
        int InsertReadingPassage(ReadingPassageDTO dto);
        // Khai báo hàm thêm nhiều đoạn Reading.
        void InsertReadingPassageBulk(IEnumerable<ReadingPassageDTO> danhSach);
        // Khai báo hàm thêm phần Listening mới.
        int InsertListeningSection(ListeningSectionDTO dto);
        // Khai báo hàm thêm nhiều phần Listening.
        void InsertListeningSectionBulk(IEnumerable<ListeningSectionDTO> danhSach);
        // Khai báo hàm lấy danh sách câu hỏi.
        List<CauHoiDTO> GetCauHoi(string keyword);
        // Khai báo hàm tìm kiếm câu hỏi theo bộ lọc nâng cao.
        List<CauHoiDTO> SearchCauHoi(CauHoiSearchCriteriaDTO criteria);
        // Khai báo hàm lấy câu hỏi thuộc đoạn Reading.
        List<CauHoiDTO> GetCauHoiByPassageId(int maPassage);
        // Khai báo hàm lấy câu hỏi thuộc phần Listening.
        List<CauHoiDTO> GetCauHoiBySectionId(int maSection);
        // Khai báo hàm thêm câu hỏi mới.
        int InsertCauHoi(CauHoiDTO dto);
        // Khai báo hàm thêm nhiều câu hỏi.
        void InsertCauHoiBulk(IEnumerable<CauHoiDTO> danhSach);
        // Khai báo hàm cập nhật thông tin câu hỏi.
        void UpdateCauHoi(CauHoiDTO dto);
        // Khai báo hàm xóa câu hỏi đã chọn.
        void DeleteCauHoi(int maCauHoi);
        // Khai báo hàm lấy thứ tự tiếp theo trong đề thi.
        int GetNextThuTu(int maDeThi);
        // Khai báo hàm kiểm tra câu hỏi đã nằm trong đề thi.
        bool ExistsQuestionInExam(int maDeThi, int maCauHoi);
        // Khai báo hàm thêm câu hỏi vào đề thi.
        void ThemCauHoiVaoDeThi(int maDeThi, int maCauHoi);
        // Khai báo hàm thêm câu hỏi vào đề thi.
        void ThemCauHoiVaoDeThi(int maDeThi, int maCauHoi, string groupType, int? groupId, int? thuTu);
        // Khai báo hàm xóa câu hỏi khỏi đề thi.
        void XoaCauHoiKhoiDeThi(int maDeThi, int maCauHoi);
        // Khai báo hàm lấy nội dung đề thi.
        List<IeltsExamItemDTO> GetNoiDungDeThi(int maDeThi);
        // Khai báo hàm nhập dữ liệu IELTS từ tệp nhập.
        int ImportIeltsRows(IEnumerable<IeltsImportRowDTO> rows);

        // Khai báo hàm lấy danh sách đợt kiểm tra của lớp.
        List<DotKiemTraDTO> GetDotKiemTra(int maLopHoc);
        // Khai báo hàm thêm đợt kiểm tra mới.
        int InsertDotKiemTra(DotKiemTraDTO dto);
        // Khai báo hàm lấy danh sách điểm số của đợt kiểm tra.
        List<DiemSoDTO> GetDiemSo(int maDotKiemTra);
        // Khai báo hàm kiểm tra điểm số đã có của học viên trong đợt kiểm tra.
        bool ExistsDiemSo(int maNguoiDung, int maDotKiemTra);
        // Khai báo hàm thêm điểm số mới cho học viên.
        void InsertDiemSo(DiemSoDTO dto);

        // Khai báo hàm lấy danh sách từ vựng theo lớp.
        List<TuVungDTO> GetTuVung(int? maLopHoc);
        // Khai báo hàm tìm kiếm từ vựng theo tiêu chí tìm kiếm.
        List<TuVungDTO> SearchTuVung(TuVungSearchCriteriaDTO criteria);
        // Khai báo hàm kiểm tra từ vựng bị trùng trong lớp.
        bool ExistsTuVungTrongLop(string tuTiengAnh, int maLopHoc, int exceptId);
        // Khai báo hàm thêm từ vựng mới.
        int InsertTuVung(TuVungDTO dto);
        // Khai báo hàm cập nhật thông tin từ vựng.
        void UpdateTuVung(TuVungDTO dto);
        // Khai báo hàm xóa từ vựng đã chọn.
        void DeleteTuVung(int maTuVung);
        // Khai báo hàm đồng bộ flashcard của lớp theo từ vựng.
        void DongBoFlashcardChoLop(int maTuVung, int maLopHoc);
        // Khai báo hàm lưu tiến trình học flashcard.
        void UpsertTienTrinhFlashcard(int maNguoiDung, int maTuVung, string ketQua);

        // Khai báo hàm lấy danh sách thông báo.
        List<ThongBaoDTO> GetThongBao();
        // Khai báo hàm thêm thông báo mới.
        int InsertThongBao(ThongBaoDTO dto);
        // Khai báo hàm tạo danh sách người nhận thông báo.
        void TaoNguoiNhanThongBao(int maThongBao, IEnumerable<int> maNguoiNhan);

        // Khai báo hàm lấy danh sách học phí.
        List<ThanhToanHocPhiDTO> GetHocPhi();
        // Khai báo hàm lấy danh sách học phí.
        List<ThanhToanHocPhiDTO> GetHocPhi(int? maLopHoc, DateTime? tuNgay, DateTime? denNgay);
        // Khai báo hàm thêm phiếu học phí mới.
        int InsertHocPhi(ThanhToanHocPhiDTO dto);
        // Khai báo hàm thêm nhiều phiếu học phí.
        void InsertHocPhiBulk(IEnumerable<ThanhToanHocPhiDTO> danhSach);
        // Khai báo hàm cập nhật trạng thái học phí.
        void UpdateTrangThaiHocPhi(int maThanhToan, string trangThai);
        // Khai báo hàm tạo nhật ký giao dịch thanh toán.
        PaymentResultDTO TaoNhatKyThanhToan(PaymentRequestDTO request, string maGiaoDichNgoai, string paymentUrl, string qrContent);
        // Khai báo hàm lấy giao dịch thanh toán theo mã.
        PaymentResultDTO LayGiaoDichThanhToan(int maGiaoDich);
        // Khai báo hàm lấy các giao dịch của khoản học phí.
        List<PaymentResultDTO> LayGiaoDichTheoThanhToan(int maThanhToan);
        // Khai báo hàm lấy chi tiết giao dịch để kiểm thử.
        PaymentDebugResultDTO LayChiTietGiaoDichDebug(int maGiaoDich);
        // Khai báo hàm cập nhật trạng thái gửi thư yêu cầu thanh toán.
        void CapNhatEmailThanhToan(int maGiaoDich, bool sent, DateTime? sentAt, string error);
        // Khai báo hàm cập nhật trạng thái gửi thư thông báo giao dịch.
        void CapNhatEmailTrangThai(int maGiaoDich, bool sent, DateTime? sentAt, string error);
        // Khai báo hàm cập nhật trạng thái giao dịch.
        void CapNhatTrangThaiGiaoDich(int maGiaoDich, string trangThai);
        // Khai báo hàm cập nhật trạng thái và phương thức thanh toán học phí.
        void CapNhatTrangThaiHocPhi(int maThanhToan, string trangThai, string phuongThuc, DateTime? ngayThanhToan);
        // Khai báo hàm lấy hóa đơn học phí theo mã thanh toán.
        HoaDonHocPhiDTO LayHoaDonHocPhi(int maThanhToan);
        // Khai báo hàm lấy hóa đơn học phí theo khoảng ngày.
        List<HoaDonHocPhiDTO> LayHoaDonHocPhiTheoKhoangNgay(DateTime tuNgay, DateTime denNgay);
        // Khai báo hàm lấy báo cáo doanh thu theo khoảng ngày.
        List<BaoCaoDoanhThuDTO> LayBaoCaoDoanhThu(DateTime tuNgay, DateTime denNgay);
        // Khai báo hàm cập nhật mã hóa đơn học phí.
        void CapNhatThongTinHoaDon(int maThanhToan, string maHoaDon);

        // Khai báo hàm lấy số liệu tổng quan màn hình tổng quan.
        DashboardSummaryDTO GetDashboardSummary(DateTime today);
        // Khai báo hàm lấy doanh thu theo tháng.
        List<MonthlyRevenueDTO> GetRevenueByMonth(int months, DateTime today);
        // Khai báo hàm lấy lịch học trong tuần.
        List<WeeklyScheduleDTO> GetWeeklySchedule(DateTime weekStart);
        // Khai báo hàm lấy dữ liệu báo cáo điểm.
        List<BaoCaoDiemDTO> GetBaoCaoDiem(int? maLopHoc);
        // Khai báo hàm lấy dữ liệu báo cáo bài tập.
        List<BaoCaoBaiTapDTO> GetBaoCaoBaiTap(int? maLopHoc);
        // Khai báo hàm lấy dữ liệu báo cáo chuyên cần.
        List<BaoCaoChuyenCanDTO> GetBaoCaoChuyenCan(int maLopHoc);
        // Khai báo hàm lấy dữ liệu báo cáo cuối kỳ.
        List<BaoCaoCuoiKyDTO> GetBaoCaoCuoiKy(int maLopHoc);
        // Khai báo hàm xử lý nhật ký lập báo cáo.
        void GhiNhatKyBaoCao(int maNguoiDung, string loaiBaoCao, string tieuChi);
    }
}
