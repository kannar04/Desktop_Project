using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DesktopApp_Project.Common;
using DesktopApp_Project.DAL;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.BUS
{
    public class ServiceFactory
    {
        private readonly IQuanLyIeltsRepository _repository;

        public ServiceFactory()
            : this(new QuanLyIeltsRepository(new AppConfigDataContextFactory()))
        {
        }

        public ServiceFactory(IQuanLyIeltsRepository repository)
        {
            _repository = repository;
            Auth = new AuthService(_repository);
            HocVien = new HocVienService(_repository);
            LopHoc = new LopHocService(_repository);
            TaiLieu = new TaiLieuService(_repository);
            BaiTap = new BaiTapService(_repository);
            ChamBai = new ChamBaiService(_repository);
            DiemDanh = new DiemDanhService(_repository);
            DiemSo = new DiemSoService(_repository);
            DeThi = new DeThiService(_repository);
            BaoCao = new BaoCaoService(_repository);
            TuVung = new TuVungService(_repository);
            ThongBao = new ThongBaoService(_repository);
            HocPhi = new HocPhiService(_repository);
            Dashboard = new DashboardService(_repository);
        }

        public AuthService Auth { get; private set; }
        public HocVienService HocVien { get; private set; }
        public LopHocService LopHoc { get; private set; }
        public TaiLieuService TaiLieu { get; private set; }
        public BaiTapService BaiTap { get; private set; }
        public ChamBaiService ChamBai { get; private set; }
        public DiemDanhService DiemDanh { get; private set; }
        public DiemSoService DiemSo { get; private set; }
        public DeThiService DeThi { get; private set; }
        public BaoCaoService BaoCao { get; private set; }
        public TuVungService TuVung { get; private set; }
        public ThongBaoService ThongBao { get; private set; }
        public HocPhiService HocPhi { get; private set; }
        public DashboardService Dashboard { get; private set; }
    }

    public abstract class ServiceBase
    {
        protected readonly IQuanLyIeltsRepository Repository;

        protected ServiceBase(IQuanLyIeltsRepository repository)
        {
            Repository = repository;
        }

        protected ServiceResult<T> Try<T>(Func<ServiceResult<T>> action)
        {
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                return ServiceResult<T>.Fail("Lỗi xử lý dữ liệu: " + ex.Message);
            }
        }

        protected ServiceResult Try(Func<ServiceResult> action)
        {
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail("Lỗi xử lý dữ liệu: " + ex.Message);
            }
        }
    }

    public class AuthService : ServiceBase
    {
        public AuthService(IQuanLyIeltsRepository repository) : base(repository) { }

        public ServiceResult<NguoiDungDTO> DangNhap(string taiKhoan, string matKhau)
        {
            return Try(() =>
            {
                if (ValidationHelper.IsBlank(taiKhoan) || ValidationHelper.IsBlank(matKhau))
                {
                    return ServiceResult<NguoiDungDTO>.Fail("Vui lòng nhập tài khoản và mật khẩu.");
                }

                string error;
                if (!Repository.KiemTraKetNoi(out error))
                {
                    return ServiceResult<NguoiDungDTO>.Fail("Không kết nối được cơ sở dữ liệu. Hãy chạy DAL\\Sql\\Schema.sql và kiểm tra chuỗi kết nối. Chi tiết: " + error);
                }

                var nguoiDung = Repository.GetNguoiDungByTaiKhoan(taiKhoan.Trim());
                if (nguoiDung == null || nguoiDung.MatKhau != matKhau)
                {
                    return ServiceResult<NguoiDungDTO>.Fail("Tài khoản hoặc mật khẩu không đúng.");
                }

                if (!AppConstants.AdminRoles.Contains(nguoiDung.VaiTro))
                {
                    return ServiceResult<NguoiDungDTO>.Fail("Vai trò Học sinh đã được chừa trong kiến trúc nhưng chưa có giao diện ở phiên bản hiện tại.");
                }

                return ServiceResult<NguoiDungDTO>.Ok(nguoiDung, "Đăng nhập thành công.");
            });
        }
    }

    public class HocVienService : ServiceBase
    {
        public HocVienService(IQuanLyIeltsRepository repository) : base(repository) { }

        public List<NguoiDungDTO> TimKiem(string keyword)
        {
            return Repository.SearchHocVien(keyword);
        }

        public List<NguoiDungDTO> TimKiem(HocVienSearchCriteriaDTO criteria)
        {
            return Repository.SearchHocVien(criteria);
        }

        public ServiceResult Luu(NguoiDungDTO dto)
        {
            return Try(() =>
            {
                dto.VaiTro = AppConstants.RoleStudent;
                if (ValidationHelper.IsBlank(dto.HoTen) || ValidationHelper.IsBlank(dto.SDT) ||
                    ValidationHelper.IsBlank(dto.Email) || ValidationHelper.IsBlank(dto.TaiKhoan) ||
                    ValidationHelper.IsBlank(dto.MatKhau))
                {
                    return ServiceResult.Fail("Vui lòng nhập đầy đủ họ tên, SĐT, email, tài khoản và mật khẩu.");
                }

                if (!ValidationHelper.IsValidEmail(dto.Email))
                {
                    return ServiceResult.Fail("Email không hợp lệ.");
                }

                if (Repository.ExistsTaiKhoan(dto.TaiKhoan.Trim(), dto.MaNguoiDung))
                {
                    return ServiceResult.Fail("Tài khoản học viên đã tồn tại.");
                }

                if (Repository.ExistsEmail(dto.Email.Trim(), dto.MaNguoiDung))
                {
                    return ServiceResult.Fail("Email học viên đã tồn tại.");
                }

                if (dto.MaNguoiDung == 0)
                {
                    Repository.InsertNguoiDung(dto);
                    return ServiceResult.Ok("Thêm học viên thành công.");
                }

                Repository.UpdateNguoiDung(dto);
                return ServiceResult.Ok("Cập nhật học viên thành công.");
            });
        }

        public ServiceResult Xoa(int maNguoiDung)
        {
            return Try(() =>
            {
                Repository.DeleteNguoiDung(maNguoiDung);
                return ServiceResult.Ok("Xóa học viên thành công.");
            });
        }
    }

    public class LopHocService : ServiceBase
    {
        public LopHocService(IQuanLyIeltsRepository repository) : base(repository) { }

        public List<LopHocDTO> LayDanhSach()
        {
            return Repository.GetLopHoc();
        }

        public List<NguoiDungDTO> LayHocVienTrongLop(int maLopHoc)
        {
            return Repository.GetHocVienTrongLop(maLopHoc);
        }

        public List<NguoiDungDTO> LayHocVienChuaTrongLop(int maLopHoc)
        {
            return Repository.GetHocVienChuaTrongLop(maLopHoc);
        }

        public ServiceResult Luu(LopHocDTO dto)
        {
            return Try(() =>
            {
                if (ValidationHelper.IsBlank(dto.TenLop) || ValidationHelper.IsBlank(dto.NhomTrinhDo))
                {
                    return ServiceResult.Fail("Tên lớp và nhóm trình độ không được để trống.");
                }

                if (Repository.ExistsTenLop(dto.TenLop.Trim(), dto.MaLopHoc))
                {
                    return ServiceResult.Fail("Tên lớp đã tồn tại.");
                }

                if (Repository.ExistsLichHoc(dto.LichHoc, dto.MaLopHoc))
                {
                    return ServiceResult.Fail("Lịch học đã trùng với lớp khác.");
                }

                if (dto.MaLopHoc == 0)
                {
                    Repository.InsertLopHoc(dto);
                    return ServiceResult.Ok("Tạo lớp học thành công.");
                }

                Repository.UpdateLopHoc(dto);
                return ServiceResult.Ok("Cập nhật lớp học thành công.");
            });
        }

        public ServiceResult Xoa(int maLopHoc)
        {
            return Try(() =>
            {
                Repository.DeleteLopHoc(maLopHoc);
                return ServiceResult.Ok("Xóa lớp học thành công.");
            });
        }

        public ServiceResult ThemHocVien(int maNguoiDung, int maLopHoc)
        {
            return Try(() =>
            {
                Repository.ThemHocVienVaoLop(maNguoiDung, maLopHoc);
                return ServiceResult.Ok("Phân bổ học viên vào lớp thành công.");
            });
        }

        public ServiceResult XoaHocVien(int maNguoiDung, int maLopHoc)
        {
            return Try(() =>
            {
                Repository.XoaHocVienKhoiLop(maNguoiDung, maLopHoc);
                return ServiceResult.Ok("Đã xóa học viên khỏi lớp.");
            });
        }
    }

    public class TaiLieuService : ServiceBase
    {
        public TaiLieuService(IQuanLyIeltsRepository repository) : base(repository) { }

        public List<TaiLieuDTO> LayDanhSach(int? maLopHoc)
        {
            return Repository.GetTaiLieu(maLopHoc);
        }

        public ServiceResult Luu(TaiLieuDTO dto)
        {
            return Try(() =>
            {
                if (dto.MaLopHoc <= 0 || ValidationHelper.IsBlank(dto.TenChuDe))
                {
                    return ServiceResult.Fail("Vui lòng chọn lớp và nhập tên chủ đề.");
                }

                if (!ValidationHelper.IsValidSkill(dto.NhanKyNang))
                {
                    return ServiceResult.Fail("Nhãn kỹ năng phải là Listening, Reading, Writing hoặc Speaking.");
                }

                if (!ValidationHelper.IsSupportedFile(dto.DuongDanFile, new[] { ".pdf", ".doc", ".docx" }))
                {
                    return ServiceResult.Fail("Định dạng tài liệu không được hỗ trợ. Chỉ nhận PDF, Word.");
                }

                if (!ValidationHelper.IsValidVideoLink(dto.VideoLink))
                {
                    return ServiceResult.Fail("Link video không hợp lệ.");
                }

                if (dto.MaTaiLieu == 0)
                {
                    Repository.InsertTaiLieu(dto);
                    return ServiceResult.Ok("Cập nhật tài liệu thành công.");
                }

                Repository.UpdateTaiLieu(dto);
                return ServiceResult.Ok("Sửa tài liệu thành công.");
            });
        }

        public ServiceResult Xoa(int maTaiLieu)
        {
            return Try(() =>
            {
                Repository.DeleteTaiLieu(maTaiLieu);
                return ServiceResult.Ok("Xóa tài liệu thành công.");
            });
        }
    }

    public class BaiTapService : ServiceBase
    {
        public BaiTapService(IQuanLyIeltsRepository repository) : base(repository) { }

        public List<BaiTapDTO> LayDanhSach(int? maLopHoc)
        {
            return Repository.GetBaiTap(maLopHoc);
        }

        public ServiceResult GiaoBai(BaiTapDTO dto)
        {
            return Try(() =>
            {
                if (dto.MaLopHoc <= 0 || ValidationHelper.IsBlank(dto.TieuDe) || ValidationHelper.IsBlank(dto.MoTa))
                {
                    return ServiceResult.Fail("Vui lòng chọn lớp, nhập tiêu đề và mô tả bài tập.");
                }

                if (dto.Deadline <= DateTime.Now)
                {
                    return ServiceResult.Fail("Hạn nộp phải lớn hơn thời điểm hiện tại.");
                }

                if (!ValidationHelper.IsSupportedFile(dto.FileDinhKem, new[] { ".pdf", ".doc", ".docx", ".zip", ".rar" }))
                {
                    return ServiceResult.Fail("Định dạng file đính kèm không được hỗ trợ.");
                }

                if (dto.MaBaiTap == 0)
                {
                    var maBaiTap = Repository.InsertBaiTap(dto);
                    Repository.TaoChiTietNopBaiChoLop(maBaiTap, dto.MaLopHoc);
                    return ServiceResult.Ok("Giao bài tập thành công.");
                }

                Repository.UpdateBaiTap(dto);
                Repository.TaoChiTietNopBaiChoLop(dto.MaBaiTap, dto.MaLopHoc);
                return ServiceResult.Ok("Cập nhật bài tập thành công.");
            });
        }

        public ServiceResult Xoa(int maBaiTap)
        {
            return Try(() =>
            {
                Repository.DeleteBaiTap(maBaiTap);
                return ServiceResult.Ok("Xóa bài tập thành công.");
            });
        }
    }

    public class ChamBaiService : ServiceBase
    {
        public ChamBaiService(IQuanLyIeltsRepository repository) : base(repository) { }

        public List<NopBaiDTO> LayDanhSach(int maBaiTap)
        {
            return Repository.GetNopBaiTheoBaiTap(maBaiTap);
        }

        public ServiceResult Cham(NopBaiDTO dto)
        {
            return Try(() =>
            {
                if (!ValidationHelper.IsValidIeltsScore(dto.DiemSo))
                {
                    return ServiceResult.Fail("Điểm phải nằm trong khoảng 0 đến 9 và theo bước 0.5.");
                }

                if (dto.DiemSo == null)
                {
                    return ServiceResult.Fail("Vui lòng nhập điểm bài làm.");
                }

                if (dto.TrangThaiNop == "Chưa nộp" && string.IsNullOrWhiteSpace(dto.FileBaiLam))
                {
                    return ServiceResult.Fail("Học viên chưa nộp bài nên chưa thể chấm.");
                }

                Repository.ChamBai(dto);
                return ServiceResult.Ok("Chấm bài thành công.");
            });
        }
    }

    public class DiemDanhService : ServiceBase
    {
        public DiemDanhService(IQuanLyIeltsRepository repository) : base(repository) { }

        public ServiceResult<List<DiemDanhDTO>> LayBangDiemDanh(int maLopHoc, DateTime ngayHoc)
        {
            return Try(() =>
            {
                if (maLopHoc <= 0)
                {
                    return ServiceResult<List<DiemDanhDTO>>.Fail("Vui lòng chọn lớp học.");
                }

                var maBuoiHoc = Repository.GetOrCreateBuoiHoc(maLopHoc, ngayHoc);
                var hocVien = Repository.GetHocVienLop(maLopHoc, true);
                var daDiemDanh = Repository.GetDiemDanh(maBuoiHoc).ToDictionary(x => x.MaNguoiDung);
                var result = new List<DiemDanhDTO>();

                foreach (var hv in hocVien)
                {
                    DiemDanhDTO dto;
                    if (!daDiemDanh.TryGetValue(hv.MaNguoiDung, out dto))
                    {
                        dto = new DiemDanhDTO
                        {
                            MaNguoiDung = hv.MaNguoiDung,
                            MaBuoiHoc = maBuoiHoc,
                            HoTen = hv.HoTen,
                            TrangThai = "Có mặt"
                        };
                        dto.CoMat = false;
                        dto.TrangThai = AppConstants.AttendanceAbsent;
                    }
                    else
                    {
                        dto.CoMat = dto.TrangThai == AppConstants.AttendancePresent || dto.TrangThai == AppConstants.AttendanceLate;
                    }

                    dto.TiLeChuyenCan = Repository.TinhTiLeChuyenCan(hv.MaNguoiDung, maLopHoc);
                    result.Add(dto);
                }

                return ServiceResult<List<DiemDanhDTO>>.Ok(result, "Tải bảng điểm danh thành công.");
            });
        }

        public ServiceResult Luu(DiemDanhDTO dto)
        {
            return Try(() =>
            {
                dto.TrangThai = dto.CoMat ? AppConstants.AttendancePresent : AppConstants.AttendanceAbsent;
                if (!AppConstants.AttendanceStatuses.Contains(dto.TrangThai))
                {
                    return ServiceResult.Fail("Vui lòng chọn trạng thái điểm danh hợp lệ.");
                }

                Repository.LuuDiemDanh(dto);
                return ServiceResult.Ok("Lưu điểm danh thành công.");
            });
        }

        public ServiceResult LuuTatCa(IEnumerable<DiemDanhDTO> danhSach)
        {
            return Try(() =>
            {
                var rows = (danhSach ?? Enumerable.Empty<DiemDanhDTO>()).ToList();
                if (rows.Count == 0)
                {
                    return ServiceResult.Fail("Không có học viên để lưu điểm danh.");
                }

                foreach (var row in rows)
                {
                    row.TrangThai = row.CoMat ? AppConstants.AttendancePresent : AppConstants.AttendanceAbsent;
                    row.LyDoVang = row.CoMat ? string.Empty : row.LyDoVang;
                    if (row.MaNguoiDung <= 0 || row.MaBuoiHoc <= 0)
                    {
                        return ServiceResult.Fail("Dữ liệu điểm danh không hợp lệ.");
                    }
                }

                Repository.LuuDiemDanh(rows);
                return ServiceResult.Ok("Đã lưu điểm danh cho toàn bộ lớp.");
            });
        }
    }

    public class DiemSoService : ServiceBase
    {
        public DiemSoService(IQuanLyIeltsRepository repository) : base(repository) { }

        public List<DotKiemTraDTO> LayDotKiemTra(int maLopHoc)
        {
            return Repository.GetDotKiemTra(maLopHoc);
        }

        public ServiceResult<int> TaoDotKiemTra(DotKiemTraDTO dto)
        {
            return Try(() =>
            {
                if (dto.MaLopHoc <= 0 || ValidationHelper.IsBlank(dto.TenDotKiemTra))
                {
                    return ServiceResult<int>.Fail("Vui lòng chọn lớp và nhập tên đợt kiểm tra.");
                }

                var id = Repository.InsertDotKiemTra(dto);
                return ServiceResult<int>.Ok(id, "Tạo đợt kiểm tra thành công.");
            });
        }

        public List<DiemSoDTO> LayDiemSo(int maDotKiemTra)
        {
            return Repository.GetDiemSo(maDotKiemTra);
        }

        public ServiceResult LuuDiem(DiemSoDTO dto)
        {
            return Try(() =>
            {
                var scores = new[] { dto.DiemL, dto.DiemR, dto.DiemW, dto.DiemS, dto.DiemTong };
                if (scores.Any(x => !ValidationHelper.IsValidIeltsScore(x)))
                {
                    return ServiceResult.Fail("Điểm IELTS phải nằm trong khoảng 0 đến 9 và theo bước 0.5.");
                }

                if (!dto.DiemTong.HasValue)
                {
                    var parts = new[] { dto.DiemL, dto.DiemR, dto.DiemW, dto.DiemS }.Where(x => x.HasValue).Select(x => x.Value).ToList();
                    if (parts.Count > 0)
                    {
                        dto.DiemTong = Math.Round(parts.Average() * 2m, MidpointRounding.AwayFromZero) / 2m;
                    }
                }

                if (Repository.ExistsDiemSo(dto.MaNguoiDung, dto.MaDotKiemTra))
                {
                    return ServiceResult.Fail("Học viên đã có điểm cho đợt kiểm tra này. PDF yêu cầu lưu lịch sử, không ghi đè điểm cũ.");
                }

                Repository.InsertDiemSo(dto);
                return ServiceResult.Ok("Lưu điểm thành công.");
            });
        }
    }

    public class DeThiService : ServiceBase
    {
        public DeThiService(IQuanLyIeltsRepository repository) : base(repository) { }

        public List<DeThiDTO> LayDeThi()
        {
            return Repository.GetDeThi();
        }

        public List<CauHoiDTO> LayCauHoi(string keyword)
        {
            return Repository.GetCauHoi(keyword);
        }

        public ServiceResult<List<CauHoiDTO>> LayCauHoi(CauHoiSearchCriteriaDTO criteria)
        {
            return Try(() =>
            {
                criteria = criteria ?? new CauHoiSearchCriteriaDTO();
                if (criteria.BandTu.HasValue && !ValidationHelper.IsValidIeltsScore(criteria.BandTu))
                {
                    return ServiceResult<List<CauHoiDTO>>.Fail("Band bắt đầu không hợp lệ.");
                }

                if (criteria.BandDen.HasValue && !ValidationHelper.IsValidIeltsScore(criteria.BandDen))
                {
                    return ServiceResult<List<CauHoiDTO>>.Fail("Band kết thúc không hợp lệ.");
                }

                if (criteria.BandTu.HasValue && criteria.BandDen.HasValue && criteria.BandTu.Value > criteria.BandDen.Value)
                {
                    return ServiceResult<List<CauHoiDTO>>.Fail("Band bắt đầu không được lớn hơn band kết thúc.");
                }

                return ServiceResult<List<CauHoiDTO>>.Ok(Repository.SearchCauHoi(criteria), "Tải câu hỏi thành công.");
            });
        }

        public ServiceResult<int> TaoDeThi(DeThiDTO dto)
        {
            return Try(() =>
            {
                if (ValidationHelper.IsBlank(dto.TenDeThi))
                {
                    return ServiceResult<int>.Fail("Vui lòng nhập tên đề thi.");
                }

                var id = Repository.InsertDeThi(dto);
                return ServiceResult<int>.Ok(id, "Tạo đề thi thành công.");
            });
        }

        public ServiceResult LuuCauHoi(CauHoiDTO dto)
        {
            return Try(() =>
            {
                if (ValidationHelper.IsBlank(dto.NoiDung) || !ValidationHelper.IsValidSkill(dto.NhanKyNang))
                {
                    return ServiceResult.Fail("Nội dung câu hỏi và nhãn kỹ năng không hợp lệ.");
                }

                if (!ValidationHelper.IsValidIeltsScore(dto.BandLevel))
                {
                    return ServiceResult.Fail("Band câu hỏi phải nằm trong khoảng 0 đến 9 và theo bước 0.5.");
                }

                if (dto.MaCauHoi == 0)
                {
                    Repository.InsertCauHoi(dto);
                    return ServiceResult.Ok("Thêm câu hỏi thành công.");
                }

                Repository.UpdateCauHoi(dto);
                return ServiceResult.Ok("Cập nhật câu hỏi thành công.");
            });
        }

        public ServiceResult XoaCauHoi(int maCauHoi)
        {
            return Try(() =>
            {
                Repository.DeleteCauHoi(maCauHoi);
                return ServiceResult.Ok("Xóa câu hỏi thành công.");
            });
        }

        public ServiceResult ThemCauHoiVaoDeThi(int maDeThi, int maCauHoi)
        {
            return Try(() =>
            {
                if (maDeThi <= 0 || maCauHoi <= 0)
                {
                    return ServiceResult.Fail("Vui lòng chọn đề thi và câu hỏi.");
                }

                Repository.ThemCauHoiVaoDeThi(maDeThi, maCauHoi);
                return ServiceResult.Ok("Đã thêm câu hỏi vào đề thi.");
            });
        }
    }

    public class BaoCaoService : ServiceBase
    {
        public BaoCaoService(IQuanLyIeltsRepository repository) : base(repository) { }

        public ServiceResult<string> TaoBaoCao(BaoCaoDTO dto, int maNguoiDungLapBaoCao)
        {
            return Try(() =>
            {
                if (AppConstants.ReportTypes.Contains(dto.LoaiBaoCao))
                {
                    var htmlResult = TaoBaoCaoHtml(dto);
                    if (!htmlResult.Success)
                    {
                        return htmlResult;
                    }

                    Repository.GhiNhatKyBaoCao(maNguoiDungLapBaoCao, dto.LoaiBaoCao, "MaLopHoc=" + dto.MaLopHoc);
                    return ServiceResult<string>.Ok(htmlResult.Data, "Tạo báo cáo HTML thành công.");
                }

                var builder = new StringBuilder();
                builder.AppendLine("BÁO CÁO QUẢN LÝ LỚP IELTS");
                builder.AppendLine("Loại báo cáo: " + dto.LoaiBaoCao);
                builder.AppendLine("Thời gian tạo: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                builder.AppendLine(new string('-', 60));

                if (dto.LoaiBaoCao == "Điểm số")
                {
                    var lop = dto.MaLopHoc.HasValue ? Repository.GetLopHoc().FirstOrDefault(x => x.MaLopHoc == dto.MaLopHoc.Value) : null;
                    builder.AppendLine("Lớp: " + (lop == null ? "Tất cả" : lop.TenLop));
                    if (dto.MaLopHoc.HasValue)
                    {
                        foreach (var dot in Repository.GetDotKiemTra(dto.MaLopHoc.Value))
                        {
                            builder.AppendLine("Đợt kiểm tra: " + dot.TenDotKiemTra + " - " + dot.NgayKiemTra.ToString("dd/MM/yyyy"));
                            foreach (var diem in Repository.GetDiemSo(dot.MaDotKiemTra))
                            {
                                builder.AppendLine(string.Format("{0}: L={1}, R={2}, W={3}, S={4}, Tổng={5}, Nhận xét={6}",
                                    diem.HoTen, diem.DiemL, diem.DiemR, diem.DiemW, diem.DiemS, diem.DiemTong, diem.NhanXet));
                            }
                        }
                    }
                }
                else
                {
                    if (!dto.MaLopHoc.HasValue)
                    {
                        return ServiceResult<string>.Fail("Vui lòng chọn lớp để tạo báo cáo chuyên cần.");
                    }

                    var lop = Repository.GetLopHoc().FirstOrDefault(x => x.MaLopHoc == dto.MaLopHoc.Value);
                    builder.AppendLine("Lớp: " + (lop == null ? string.Empty : lop.TenLop));
                    foreach (var hv in Repository.GetHocVienTrongLop(dto.MaLopHoc.Value))
                    {
                        builder.AppendLine(hv.HoTen + ": " + Repository.TinhTiLeChuyenCan(hv.MaNguoiDung, dto.MaLopHoc.Value) + "% chuyên cần");
                    }
                }

                Repository.GhiNhatKyBaoCao(maNguoiDungLapBaoCao, dto.LoaiBaoCao, "MaLopHoc=" + dto.MaLopHoc);
                return ServiceResult<string>.Ok(builder.ToString(), "Tạo báo cáo thành công.");
            });
        }

        private ServiceResult<string> TaoBaoCaoHtml(BaoCaoDTO dto)
        {
            if ((dto.LoaiBaoCao == "Chuyên cần" || dto.LoaiBaoCao == "Cuối kỳ") && (!dto.MaLopHoc.HasValue || dto.MaLopHoc.Value <= 0))
            {
                return ServiceResult<string>.Fail("Vui lòng chọn lớp cho báo cáo này.");
            }

            var builder = new StringBuilder();
            builder.AppendLine("<!doctype html><html><head><meta charset=\"utf-8\"><title>Báo cáo IELTS</title>");
            builder.AppendLine("<style>body{font-family:Segoe UI,Arial,sans-serif;margin:24px;color:#222}table{border-collapse:collapse;width:100%;margin-top:16px}th,td{border:1px solid #ddd;padding:8px;text-align:left}th{background:#2A2A3E;color:#EAEAEA}.muted{color:#666}</style>");
            builder.AppendLine("</head><body>");
            builder.AppendLine("<h1>Báo cáo quản lý lớp IELTS</h1>");
            builder.AppendLine("<p class=\"muted\">Loại báo cáo: " + Html(dto.LoaiBaoCao) + " | Thời gian tạo: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "</p>");

            if (dto.LoaiBaoCao == "Điểm số")
            {
                builder.AppendLine("<table><tr><th>Lớp</th><th>Học viên</th><th>Đợt kiểm tra</th><th>Điểm</th><th>Band estimate</th><th>Nhận xét</th></tr>");
                foreach (var row in Repository.GetBaoCaoDiem(dto.MaLopHoc))
                {
                    builder.AppendLine("<tr><td>" + Html(row.TenLop) + "</td><td>" + Html(row.HoTen) + "</td><td>" + Html(row.TenDotKiemTra) + "</td><td>" + Html(FormatScore(row.DiemTong)) + "</td><td>" + Html(FormatScore(row.DiemTong)) + "</td><td>" + Html(row.NhanXet) + "</td></tr>");
                }
                builder.AppendLine("</table>");
            }
            else if (dto.LoaiBaoCao == "Bài tập")
            {
                builder.AppendLine("<table><tr><th>Học viên</th><th>Bài tập</th><th>Hạn nộp</th><th>Trạng thái</th></tr>");
                foreach (var row in Repository.GetBaoCaoBaiTap(dto.MaLopHoc))
                {
                    builder.AppendLine("<tr><td>" + Html(row.HoTen) + "</td><td>" + Html(row.TieuDe) + "</td><td>" + row.Deadline.ToString("dd/MM/yyyy") + "</td><td>" + Html(row.TrangThaiNop) + "</td></tr>");
                }
                builder.AppendLine("</table>");
            }
            else if (dto.LoaiBaoCao == "Chuyên cần")
            {
                builder.AppendLine("<table><tr><th>Học viên</th><th>Có mặt</th><th>Vắng</th><th>Tỉ lệ</th></tr>");
                foreach (var row in Repository.GetBaoCaoChuyenCan(dto.MaLopHoc.Value))
                {
                    builder.AppendLine("<tr><td>" + Html(row.HoTen) + "</td><td>" + row.SoBuoiCoMat + "</td><td>" + row.SoBuoiVang + "</td><td>" + row.TiLeChuyenCan.ToString("0.##") + "%</td></tr>");
                }
                builder.AppendLine("</table>");
            }
            else if (dto.LoaiBaoCao == "Cuối kỳ")
            {
                builder.AppendLine("<table><tr><th>Học viên</th><th>Đợt kiểm tra</th><th>Điểm</th><th>Trung bình</th><th>Nhận xét giáo viên</th></tr>");
                foreach (var row in Repository.GetBaoCaoCuoiKy(dto.MaLopHoc.Value))
                {
                    builder.AppendLine("<tr><td>" + Html(row.HoTen) + "</td><td>" + Html(row.TenDotKiemTra) + "</td><td>" + Html(FormatScore(row.DiemTong)) + "</td><td>" + Html(FormatScore(row.DiemTrungBinh)) + "</td><td>" + Html(row.NhanXet) + "</td></tr>");
                }
                builder.AppendLine("</table>");
            }

            builder.AppendLine("</body></html>");
            return ServiceResult<string>.Ok(builder.ToString(), "OK");
        }

        private static string FormatScore(decimal? score)
        {
            return score.HasValue ? score.Value.ToString("0.0") : string.Empty;
        }

        private static string Html(string value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            return value.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;");
        }

        public ServiceResult XuatBaoCao(string noiDung, string filePath)
        {
            return Try(() =>
            {
                if (ValidationHelper.IsBlank(noiDung) || ValidationHelper.IsBlank(filePath))
                {
                    return ServiceResult.Fail("Không có nội dung hoặc đường dẫn xuất báo cáo.");
                }

                File.WriteAllText(filePath, noiDung, Encoding.UTF8);
                return ServiceResult.Ok("Xuất báo cáo thành công.");
            });
        }
    }

    public class TuVungService : ServiceBase
    {
        public TuVungService(IQuanLyIeltsRepository repository) : base(repository) { }

        public List<TuVungDTO> LayDanhSach(int? maLopHoc)
        {
            return Repository.GetTuVung(maLopHoc);
        }

        public List<TuVungDTO> TimKiem(TuVungSearchCriteriaDTO criteria)
        {
            return Repository.SearchTuVung(criteria);
        }

        public ServiceResult Luu(TuVungDTO dto)
        {
            return Try(() =>
            {
                if (ValidationHelper.IsBlank(dto.CapDo))
                {
                    dto.CapDo = "B1";
                }

                if (ValidationHelper.IsBlank(dto.ChuDe))
                {
                    dto.ChuDe = "Academic/IELTS General";
                }

                if (dto.MaLopHoc <= 0 || ValidationHelper.IsBlank(dto.TuTiengAnh) ||
                    ValidationHelper.IsBlank(dto.TuLoai) || ValidationHelper.IsBlank(dto.PhienAm) ||
                    ValidationHelper.IsBlank(dto.Nghia))
                {
                    return ServiceResult.Fail("Vui lòng nhập đầy đủ thông tin từ vựng.");
                }

                if (!AppConstants.CefrLevels.Contains(dto.CapDo))
                {
                    return ServiceResult.Fail("Cấp độ CEFR không hợp lệ.");
                }

                if (Repository.ExistsTuVungTrongLop(dto.TuTiengAnh.Trim(), dto.MaLopHoc, dto.MaTuVung))
                {
                    return ServiceResult.Fail("Từ vựng đã tồn tại trong lớp này.");
                }

                if (dto.MaTuVung == 0)
                {
                    var maTuVung = Repository.InsertTuVung(dto);
                    Repository.DongBoFlashcardChoLop(maTuVung, dto.MaLopHoc);
                    return ServiceResult.Ok("Thêm từ vựng thành công và đã đồng bộ Flashcard.");
                }

                Repository.UpdateTuVung(dto);
                return ServiceResult.Ok("Cập nhật từ vựng thành công.");
            });
        }

        public ServiceResult Xoa(int maTuVung)
        {
            return Try(() =>
            {
                Repository.DeleteTuVung(maTuVung);
                return ServiceResult.Ok("Xóa từ vựng thành công.");
            });
        }
    }

    public class ThongBaoService : ServiceBase
    {
        public ThongBaoService(IQuanLyIeltsRepository repository) : base(repository) { }

        public List<ThongBaoDTO> LayDanhSach()
        {
            return Repository.GetThongBao();
        }

        public ServiceResult Gui(ThongBaoDTO dto, int? maLopHoc)
        {
            return Try(() =>
            {
                if (ValidationHelper.IsBlank(dto.TieuDe) || ValidationHelper.IsBlank(dto.NoiDung))
                {
                    return ServiceResult.Fail("Tiêu đề và nội dung thông báo không được để trống.");
                }

                List<int> nguoiNhan;
                if (maLopHoc.HasValue)
                {
                    nguoiNhan = Repository.GetHocVienTrongLop(maLopHoc.Value).Select(x => x.MaNguoiDung).ToList();
                    dto.DoiTuongNhan = "Lớp " + maLopHoc.Value;
                }
                else
                {
                    nguoiNhan = Repository.GetNguoiDungByVaiTro(AppConstants.RoleStudent).Select(x => x.MaNguoiDung).ToList();
                    dto.DoiTuongNhan = "Tất cả học viên";
                }

                if (nguoiNhan.Count == 0)
                {
                    return ServiceResult.Fail("Không có học viên nhận thông báo.");
                }

                var maThongBao = Repository.InsertThongBao(dto);
                Repository.TaoNguoiNhanThongBao(maThongBao, nguoiNhan);
                return ServiceResult.Ok("Gửi thông báo thành công.");
            });
        }
    }

    public class HocPhiService : ServiceBase
    {
        public HocPhiService(IQuanLyIeltsRepository repository) : base(repository) { }

        public List<ThanhToanHocPhiDTO> LayDanhSach()
        {
            return Repository.GetHocPhi();
        }

        public List<ThanhToanHocPhiDTO> LayDanhSach(int? maLopHoc)
        {
            return Repository.GetHocPhi(maLopHoc, null, null);
        }

        public ServiceResult<List<HocPhiTinhDTO>> TinhTheoLop(int maLopHoc, decimal soTienGoc)
        {
            return Try(() =>
            {
                if (maLopHoc <= 0)
                {
                    return ServiceResult<List<HocPhiTinhDTO>>.Fail("Vui lòng chọn lớp.");
                }

                if (soTienGoc <= 0)
                {
                    return ServiceResult<List<HocPhiTinhDTO>>.Fail("Số tiền gốc phải lớn hơn 0.");
                }

                var rows = TinhHocPhi(maLopHoc, soTienGoc);
                return ServiceResult<List<HocPhiTinhDTO>>.Ok(rows, "Đã tính học phí cho lớp.");
            });
        }

        public ServiceResult TaoYeuCauTheoLop(int maLopHoc, decimal soTienGoc, string thongTinNganHang)
        {
            return Try(() =>
            {
                if (maLopHoc <= 0)
                {
                    return ServiceResult.Fail("Vui lòng chọn lớp.");
                }

                if (soTienGoc <= 0 || ValidationHelper.IsBlank(thongTinNganHang))
                {
                    return ServiceResult.Fail("Vui lòng nhập số tiền gốc và thông tin ngân hàng.");
                }

                var rows = TinhHocPhi(maLopHoc, soTienGoc);
                if (rows.Count == 0)
                {
                    return ServiceResult.Fail("Lớp không có học viên đang học để tạo học phí.");
                }

                var now = DateTime.Now;
                var payments = rows.Select(x => new ThanhToanHocPhiDTO
                {
                    MaNguoiDung = x.MaNguoiDung,
                    MaLopHoc = x.MaLopHoc,
                    SoTien = x.SoTienCuoi,
                    SoTienGoc = x.SoTienGoc,
                    PhanTramGiam = x.PhanTramGiam,
                    SoTienGiam = x.SoTienGiam,
                    SoTienCuoi = x.SoTienCuoi,
                    ThongTinNganHang = thongTinNganHang.Trim(),
                    NgayTao = now,
                    HanThanhToan = now.AddDays(AppConstants.HocPhiDeadlineDays),
                    TrangThai = AppConstants.PaymentPending
                }).ToList();

                Repository.InsertHocPhiBulk(payments);
                return ServiceResult.Ok("Đã tạo phiếu học phí cho " + payments.Count + " học viên.");
            });
        }

        public ServiceResult TaoYeuCau(ThanhToanHocPhiDTO dto)
        {
            return Try(() =>
            {
                if (dto.MaNguoiDung <= 0 || dto.SoTien <= 0 || ValidationHelper.IsBlank(dto.ThongTinNganHang))
                {
                    return ServiceResult.Fail("Vui lòng chọn học viên, nhập số tiền và thông tin ngân hàng.");
                }

                dto.NgayTao = DateTime.Now;
                dto.HanThanhToan = DateTime.Now.AddDays(AppConstants.HocPhiDeadlineDays);
                dto.TrangThai = "Chờ thanh toán";
                dto.SoTienGoc = dto.SoTienGoc ?? dto.SoTien;
                dto.SoTienCuoi = dto.SoTienCuoi ?? dto.SoTien;
                dto.TrangThai = AppConstants.PaymentPending;
                Repository.InsertHocPhi(dto);
                return ServiceResult.Ok("Tạo yêu cầu thanh toán học phí thành công. Hạn thanh toán là 10 ngày.");
            });
        }

        public ServiceResult CapNhatTrangThai(int maThanhToan, string trangThai)
        {
            return Try(() =>
            {
                if (ValidationHelper.IsBlank(trangThai) || !AppConstants.PaymentStatuses.Contains(trangThai))
                {
                    return ServiceResult.Fail("Trạng thái học phí không hợp lệ.");
                }

                Repository.UpdateTrangThaiHocPhi(maThanhToan, trangThai);
                return ServiceResult.Ok("Cập nhật trạng thái học phí thành công.");
            });
        }

        private List<HocPhiTinhDTO> TinhHocPhi(int maLopHoc, decimal soTienGoc)
        {
            var today = DateTime.Today;
            return Repository.GetHocVienLop(maLopHoc, true).Select(hv =>
            {
                var discount = hv.NgayVaoLop.Date <= today.AddYears(-AppConstants.LongTermTuitionDiscountYears)
                    ? AppConstants.LongTermTuitionDiscountPercent
                    : 0m;
                var discountAmount = Math.Round(soTienGoc * discount / 100m, 0);
                return new HocPhiTinhDTO
                {
                    MaNguoiDung = hv.MaNguoiDung,
                    MaLopHoc = hv.MaLopHoc,
                    HoTen = hv.HoTen,
                    NgayVaoLop = hv.NgayVaoLop,
                    SoTienGoc = soTienGoc,
                    PhanTramGiam = discount,
                    SoTienGiam = discountAmount,
                    SoTienCuoi = soTienGoc - discountAmount,
                    TrangThai = hv.TrangThai,
                    GhiChu = discount > 0 ? "Giảm 20% do học trên 2 năm" : string.Empty
                };
            }).ToList();
        }
    }

    public class DashboardService : ServiceBase
    {
        public DashboardService(IQuanLyIeltsRepository repository) : base(repository) { }

        public ServiceResult<DashboardSummaryDTO> LayTongQuan()
        {
            return Try(() => ServiceResult<DashboardSummaryDTO>.Ok(Repository.GetDashboardSummary(DateTime.Today), "Tải tổng quan thành công."));
        }

        public ServiceResult<List<MonthlyRevenueDTO>> LayDoanhThuThang(int soThang)
        {
            return Try(() => ServiceResult<List<MonthlyRevenueDTO>>.Ok(Repository.GetRevenueByMonth(soThang, DateTime.Today), "Tải doanh thu thành công."));
        }

        public ServiceResult<List<WeeklyScheduleDTO>> LayLichHocTuan()
        {
            return Try(() => ServiceResult<List<WeeklyScheduleDTO>>.Ok(Repository.GetWeeklySchedule(DateTime.Today), "Tải lịch học tuần thành công."));
        }
    }
}
