// kho dữ liệu truy cập dữ liệu cơ sở dữ liệu SQL Server cho hệ thống quản lý IELTS
// Chức năng:
// - Thực hiện truy vấn LINQ sang SQL
// - Thêm, sửa, xóa và tổng hợp dữ liệu
// - Chuyển thực thể dữ liệu thành đối tượng truyền dữ liệu trước khi trả cho tầng nghiệp vụ

using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.DAL
{
    // Lớp kho dữ liệu cài đặt toàn bộ truy vấn và cập nhật dữ liệu cơ sở dữ liệu SQL Server cho tầng nghiệp vụ.
    public class QuanLyIeltsRepository : IQuanLyIeltsRepository
    {
        private readonly IDataContextFactory _factory;

        // Khởi tạo đối tượng tầng dữ liệu với cấu hình kết nối hoặc factory dữ liệu.
        public QuanLyIeltsRepository(IDataContextFactory factory)
        {
            _factory = factory;
        }

        // Trả về thực thể bắt buộc hoặc ném lỗi rõ ràng khi không tìm thấy dữ liệu.
        private static T RequireEntity<T>(T entity, string message) where T : class
        {
            if (entity == null)
            {
                throw new InvalidOperationException(message);
            }

            return entity;
        }

        // Kiểm tra kết nối cơ sở dữ liệu trong cơ sở dữ liệu.
        public bool KiemTraKetNoi(out string error)
        {
            try
            {
                using (var db = _factory.Create())
                {
                    db.Connection.Open();
                    db.NguoiDungs.Take(1).ToList();
                }

                error = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        // Tầng dữ liệu thực hiện lấy thông tin người dùng theo tài khoản.
        public NguoiDungDTO GetNguoiDungByTaiKhoan(string taiKhoan)
        {
            using (var db = _factory.Create())
            {
                var entity = db.NguoiDungs.FirstOrDefault(x => x.TaiKhoan == taiKhoan);
                return DtoMapper.ToDto(entity);
            }
        }

        // Tầng dữ liệu thực hiện lấy thông tin người dùng theo mã.
        public NguoiDungDTO GetNguoiDungById(int maNguoiDung)
        {
            using (var db = _factory.Create())
            {
                return DtoMapper.ToDto(db.NguoiDungs.FirstOrDefault(x => x.MaNguoiDung == maNguoiDung));
            }
        }

        // Tầng dữ liệu thực hiện lấy danh sách người dùng theo vai trò.
        public List<NguoiDungDTO> GetNguoiDungByVaiTro(string vaiTro)
        {
            using (var db = _factory.Create())
            {
                return db.NguoiDungs
                    // Lọc người dùng theo vai trò được yêu cầu.
                    .Where(x => x.VaiTro == vaiTro)
                    .OrderBy(x => x.HoTen)
                    .AsEnumerable()
                    .Select(DtoMapper.ToDto)
                    .ToList();
            }
        }

        // Tầng dữ liệu thực hiện tìm kiếm danh sách học viên theo tiêu chí tìm kiếm.
        public List<NguoiDungDTO> SearchHocVien(string keyword)
        {
            using (var db = _factory.Create())
            {
                // Khởi tạo truy vấn người dùng trước khi áp dụng bộ lọc.
                var query = db.NguoiDungs.Where(x => x.VaiTro == AppConstants.RoleStudent);
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    // Lọc học viên theo từ khóa họ tên, tài khoản hoặc thư điện tử.
                    query = query.Where(x => x.HoTen.Contains(keyword) || x.TaiKhoan.Contains(keyword) || x.Email.Contains(keyword));
                }

                return query.OrderBy(x => x.HoTen).AsEnumerable().Select(DtoMapper.ToDto).ToList();
            }
        }

        // Tầng dữ liệu thực hiện tìm kiếm danh sách học viên theo tiêu chí tìm kiếm.
        public List<NguoiDungDTO> SearchHocVien(HocVienSearchCriteriaDTO criteria)
        {
            using (var db = _factory.Create())
            {
                criteria = criteria ?? new HocVienSearchCriteriaDTO();
                // Khởi tạo truy vấn người dùng trước khi áp dụng bộ lọc.
                var query = db.NguoiDungs.Where(x => x.VaiTro == AppConstants.RoleStudent);

                if (!string.IsNullOrWhiteSpace(criteria.HoTen))
                {
                    var keyword = criteria.HoTen.Trim();
                    // Chỉ thêm điều kiện lọc khi có tiêu chí họ tên.
                    query = query.Where(x => x.HoTen.Contains(keyword));
                }

                if (!string.IsNullOrWhiteSpace(criteria.LienHe))
                {
                    var lienHe = criteria.LienHe.Trim();
                    // Chỉ thêm điều kiện lọc khi có tiêu chí liên hệ.
                    query = query.Where(x => x.SDT.Contains(lienHe) || x.Email.Contains(lienHe));
                }

                if (criteria.MaLopHoc.HasValue && criteria.MaLopHoc.Value > 0)
                {
                    var maLopHoc = criteria.MaLopHoc.Value;
                    // Chỉ thêm điều kiện lọc khi có tiêu chí lớp học.
                    query = query.Where(x => db.ChiTietLopHocs.Any(ct => ct.MaNguoiDung == x.MaNguoiDung && ct.MaLopHoc == maLopHoc));
                }

                if (!string.IsNullOrWhiteSpace(criteria.TrangThai) && criteria.TrangThai != AppConstants.FilterAll)
                {
                    var trangThai = criteria.TrangThai.Trim();
                    if (criteria.MaLopHoc.HasValue && criteria.MaLopHoc.Value > 0)
                    {
                        var maLopHoc = criteria.MaLopHoc.Value;
                        // Chỉ thêm điều kiện lọc khi có tiêu chí lớp học.
                        query = query.Where(x => db.ChiTietLopHocs.Any(ct =>
                            ct.MaNguoiDung == x.MaNguoiDung
                            && ct.MaLopHoc == maLopHoc
                            && AppConstants.GetTextAliases(trangThai).Contains(ct.TrangThai)));
                    }
                    else
                    {
                        query = query.Where(x => db.ChiTietLopHocs.Any(ct =>
                            ct.MaNguoiDung == x.MaNguoiDung
                            && AppConstants.GetTextAliases(trangThai).Contains(ct.TrangThai)));
                    }
                }

                return query.OrderBy(x => x.HoTen).AsEnumerable().Select(DtoMapper.ToDto).ToList();
            }
        }

        // Tầng dữ liệu thực hiện thêm người dùng mới.
        public int InsertNguoiDung(NguoiDungDTO dto)
        {
            using (var db = _factory.Create())
            {
                var entity = new NguoiDungEntity
                {
                    VaiTro = dto.VaiTro,
                    HoTen = dto.HoTen,
                    NgaySinh = dto.NgaySinh,
                    SDT = dto.SDT,
                    Email = dto.Email,
                    TrinhDoDauVao = dto.TrinhDoDauVao,
                    TaiKhoan = dto.TaiKhoan,
                    MatKhau = dto.MatKhau
                };
                db.NguoiDungs.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.MaNguoiDung;
            }
        }

        // Tầng dữ liệu thực hiện cập nhật thông tin người dùng.
        public void UpdateNguoiDung(NguoiDungDTO dto)
        {
            using (var db = _factory.Create())
            {
                var entity = RequireEntity(
                    db.NguoiDungs.FirstOrDefault(x => x.MaNguoiDung == dto.MaNguoiDung),
                    "Khong tim thay nguoi dung can cap nhat.");
                entity.VaiTro = dto.VaiTro;
                entity.HoTen = dto.HoTen;
                entity.NgaySinh = dto.NgaySinh;
                entity.SDT = dto.SDT;
                entity.Email = dto.Email;
                entity.TrinhDoDauVao = dto.TrinhDoDauVao;
                entity.TaiKhoan = dto.TaiKhoan;
                entity.MatKhau = dto.MatKhau;
                db.SubmitChanges();
            }
        }

        // Tầng dữ liệu thực hiện xóa người dùng đã chọn.
        public void DeleteNguoiDung(int maNguoiDung)
        {
            using (var db = _factory.Create())
            {
                var entity = RequireEntity(
                    db.NguoiDungs.FirstOrDefault(x => x.MaNguoiDung == maNguoiDung),
                    "Khong tim thay nguoi dung can xoa.");
                db.NguoiDungs.DeleteOnSubmit(entity);
                db.SubmitChanges();
            }
        }

        // Kiểm tra tài khoản bị trùng trong cơ sở dữ liệu.
        public bool ExistsTaiKhoan(string taiKhoan, int exceptId)
        {
            using (var db = _factory.Create())
            {
                return db.NguoiDungs.Any(x => x.TaiKhoan == taiKhoan && x.MaNguoiDung != exceptId);
            }
        }

        // Kiểm tra thư điện tử bị trùng trong cơ sở dữ liệu.
        public bool ExistsEmail(string email, int exceptId)
        {
            using (var db = _factory.Create())
            {
                return db.NguoiDungs.Any(x => x.Email == email && x.MaNguoiDung != exceptId);
            }
        }

        // Tầng dữ liệu thực hiện lấy danh sách lớp học.
        public List<LopHocDTO> GetLopHoc()
        {
            using (var db = _factory.Create())
            {
                return db.LopHocs.OrderBy(x => x.TenLop).AsEnumerable().Select(DtoMapper.ToDto).ToList();
            }
        }

        // Tầng dữ liệu thực hiện thêm lớp học mới.
        public int InsertLopHoc(LopHocDTO dto)
        {
            using (var db = _factory.Create())
            {
                var entity = new LopHocEntity
                {
                    MaGiaoVien = dto.MaGiaoVien,
                    TenLop = dto.TenLop,
                    NhomTrinhDo = dto.NhomTrinhDo,
                    LichHoc = dto.LichHoc
                };
                db.LopHocs.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.MaLopHoc;
            }
        }

        // Tầng dữ liệu thực hiện cập nhật thông tin lớp học.
        public void UpdateLopHoc(LopHocDTO dto)
        {
            using (var db = _factory.Create())
            {
                var entity = RequireEntity(
                    db.LopHocs.FirstOrDefault(x => x.MaLopHoc == dto.MaLopHoc),
                    "Khong tim thay lop hoc can cap nhat.");
                entity.MaGiaoVien = dto.MaGiaoVien;
                entity.TenLop = dto.TenLop;
                entity.NhomTrinhDo = dto.NhomTrinhDo;
                entity.LichHoc = dto.LichHoc;
                db.SubmitChanges();
            }
        }

        // Tầng dữ liệu thực hiện xóa lớp học đã chọn.
        public void DeleteLopHoc(int maLopHoc)
        {
            using (var db = _factory.Create())
            {
                var entity = RequireEntity(
                    db.LopHocs.FirstOrDefault(x => x.MaLopHoc == maLopHoc),
                    "Khong tim thay lop hoc can xoa.");
                db.LopHocs.DeleteOnSubmit(entity);
                db.SubmitChanges();
            }
        }

        // Kiểm tra tên lớp bị trùng trong cơ sở dữ liệu.
        public bool ExistsTenLop(string tenLop, int exceptId)
        {
            using (var db = _factory.Create())
            {
                return db.LopHocs.Any(x => x.TenLop == tenLop && x.MaLopHoc != exceptId);
            }
        }

        // Kiểm tra lịch học bị trùng trong cơ sở dữ liệu.
        public bool ExistsLichHoc(string lichHoc, int exceptId)
        {
            if (string.IsNullOrWhiteSpace(lichHoc))
            {
                return false;
            }

            using (var db = _factory.Create())
            {
                return db.LopHocs.Any(x => x.LichHoc == lichHoc && x.MaLopHoc != exceptId);
            }
        }

        // Tầng dữ liệu thực hiện lấy danh sách học viên trong lớp.
        public List<NguoiDungDTO> GetHocVienTrongLop(int maLopHoc)
        {
            using (var db = _factory.Create())
            {
                var query =
                    // Khởi tạo truy vấn chi tiết lớp học trước khi áp dụng bộ lọc.
                    from ct in db.ChiTietLopHocs
                    join nd in db.NguoiDungs on ct.MaNguoiDung equals nd.MaNguoiDung
                    where ct.MaLopHoc == maLopHoc
                          && nd.VaiTro == AppConstants.RoleStudent
                          && AppConstants.EnrollmentActiveAliases.Contains(ct.TrangThai)
                          && ct.NgayNghiHoc == null
                    orderby nd.HoTen
                    select nd;

                return query.AsEnumerable().Select(DtoMapper.ToDto).ToList();
            }
        }

        // Tầng dữ liệu thực hiện lấy danh sách học viên kèm trạng thái lớp.
        public List<HocVienLopDTO> GetHocVienLop(int maLopHoc, bool onlyActive)
        {
            using (var db = _factory.Create())
            {
                var query =
                    // Khởi tạo truy vấn chi tiết lớp học trước khi áp dụng bộ lọc.
                    from ct in db.ChiTietLopHocs
                    join nd in db.NguoiDungs on ct.MaNguoiDung equals nd.MaNguoiDung
                    where ct.MaLopHoc == maLopHoc && nd.VaiTro == AppConstants.RoleStudent
                    select new
                    {
                        ct,
                        nd
                    };

                if (onlyActive)
                {
                    // Lọc theo trạng thái đã chọn trên màn hình.
                    query = query.Where(x => AppConstants.EnrollmentActiveAliases.Contains(x.ct.TrangThai) && x.ct.NgayNghiHoc == null);
                }

                return query.AsEnumerable().Select(x => new HocVienLopDTO
                {
                    MaNguoiDung = x.nd.MaNguoiDung,
                    MaLopHoc = x.ct.MaLopHoc,
                    HoTen = x.nd.HoTen,
                    SDT = x.nd.SDT,
                    Email = x.nd.Email,
                    NgayVaoLop = x.ct.NgayVaoLop,
                    NgayNghiHoc = x.ct.NgayNghiHoc,
                    TrangThai = x.ct.TrangThai,
                    DangHoc = AppConstants.EnrollmentActiveAliases.Contains(x.ct.TrangThai) && !x.ct.NgayNghiHoc.HasValue
                }).OrderBy(x => x.HoTen).ToList();
            }
        }

        // Tầng dữ liệu thực hiện lấy lớp hiện tại của học viên.
        public int? GetLopHocDangHocCuaHocVien(int maNguoiDung)
        {
            using (var db = _factory.Create())
            {
                return db.ChiTietLopHocs
                    .Where(x => x.MaNguoiDung == maNguoiDung
                                && AppConstants.EnrollmentActiveAliases.Contains(x.TrangThai)
                                && x.NgayNghiHoc == null)
                    .OrderByDescending(x => x.NgayVaoLop)
                    .Select(x => (int?)x.MaLopHoc)
                    .FirstOrDefault();
            }
        }

        // Trả về thực thể bắt buộc hoặc ném lỗi rõ ràng khi không tìm thấy dữ liệu.
        public int SaveHocVienVaChuyenLop(NguoiDungDTO dto, int maLopHoc)
        {
            using (var db = _factory.Create())
            {
                NguoiDungEntity entity;
                if (dto.MaNguoiDung == 0)
                {
                    entity = new NguoiDungEntity();
                    ApplyNguoiDungValues(entity, dto);
                    db.NguoiDungs.InsertOnSubmit(entity);
                    db.SubmitChanges();
                }
                else
                {
                    entity = RequireEntity(
                        db.NguoiDungs.FirstOrDefault(x => x.MaNguoiDung == dto.MaNguoiDung),
                        "Khong tim thay nguoi dung can cap nhat.");
                    ApplyNguoiDungValues(entity, dto);
                }

                MoveActiveEnrollment(db, entity.MaNguoiDung, maLopHoc);
                db.SubmitChanges();
                return entity.MaNguoiDung;
            }
        }

        // Trả về thực thể bắt buộc hoặc ném lỗi rõ ràng khi không tìm thấy dữ liệu.
        public void ChuyenHocVienSangLop(int maNguoiDung, int maLopHoc)
        {
            using (var db = _factory.Create())
            {
                MoveActiveEnrollment(db, maNguoiDung, maLopHoc);
                db.SubmitChanges();
            }
        }

        // Xử lý dữ liệu phụ trợ trước khi kho dữ liệu đọc hoặc ghi cơ sở dữ liệu.
        private static void ApplyNguoiDungValues(NguoiDungEntity entity, NguoiDungDTO dto)
        {
            entity.VaiTro = dto.VaiTro;
            entity.HoTen = dto.HoTen;
            entity.NgaySinh = dto.NgaySinh;
            entity.SDT = dto.SDT;
            entity.Email = dto.Email;
            entity.TrinhDoDauVao = dto.TrinhDoDauVao;
            entity.TaiKhoan = dto.TaiKhoan;
            entity.MatKhau = dto.MatKhau;
        }

        // Xử lý dữ liệu phụ trợ trước khi kho dữ liệu đọc hoặc ghi cơ sở dữ liệu.
        private static void MoveActiveEnrollment(QuanLyIeltsDataContext db, int maNguoiDung, int maLopHoc)
        {
            var today = DateTime.Today;
            var activeRows = db.ChiTietLopHocs
                .Where(x => x.MaNguoiDung == maNguoiDung
                            && AppConstants.EnrollmentActiveAliases.Contains(x.TrangThai)
                            && x.NgayNghiHoc == null)
                .ToList();

            // Giới hạn dữ liệu trong lớp học đang chọn.
            foreach (var row in activeRows.Where(x => x.MaLopHoc != maLopHoc))
            {
                row.TrangThai = AppConstants.EnrollmentStopped;
                row.NgayNghiHoc = today;
            }

            var selected = db.ChiTietLopHocs.FirstOrDefault(x => x.MaNguoiDung == maNguoiDung && x.MaLopHoc == maLopHoc);
            if (selected == null)
            {
                db.ChiTietLopHocs.InsertOnSubmit(new ChiTietLopHocEntity
                {
                    MaNguoiDung = maNguoiDung,
                    MaLopHoc = maLopHoc,
                    NgayVaoLop = today,
                    NgayNghiHoc = null,
                    TrangThai = AppConstants.EnrollmentActive
                });
                return;
            }

            if (!AppConstants.EnrollmentActiveAliases.Contains(selected.TrangThai) || selected.NgayNghiHoc.HasValue)
            {
                selected.NgayVaoLop = today;
            }

            selected.TrangThai = AppConstants.EnrollmentActive;
            selected.NgayNghiHoc = null;
        }

        // Tầng dữ liệu thực hiện lấy danh sách tài liệu theo lớp.
        public List<TaiLieuDTO> GetTaiLieu(int? maLopHoc)
        {
            using (var db = _factory.Create())
            {
                // Khởi tạo truy vấn tài liệu trước khi áp dụng bộ lọc.
                var query = db.TaiLieus.AsQueryable();
                if (maLopHoc.HasValue)
                {
                    // Giới hạn dữ liệu trong lớp học đang chọn.
                    query = query.Where(x => x.MaLopHoc == maLopHoc.Value);
                }

                return query.OrderByDescending(x => x.NgayCapNhat).AsEnumerable().Select(DtoMapper.ToDto).ToList();
            }
        }

        // Tầng dữ liệu thực hiện thêm tài liệu mới.
        public int InsertTaiLieu(TaiLieuDTO dto)
        {
            using (var db = _factory.Create())
            {
                var entity = new TaiLieuEntity
                {
                    MaLopHoc = dto.MaLopHoc,
                    TenChuDe = dto.TenChuDe,
                    NoiDungMoTa = dto.NoiDungMoTa,
                    DuongDanFile = dto.DuongDanFile,
                    VideoLink = dto.VideoLink,
                    AudioPath = dto.AudioPath,
                    NhanKyNang = dto.NhanKyNang,
                    LoaiFile = dto.LoaiFile,
                    TenFileGoc = dto.TenFileGoc,
                    DuongDanLocal = dto.DuongDanLocal,
                    DuongDanCloud = dto.DuongDanCloud,
                    ThumbnailPath = dto.ThumbnailPath,
                    NgayCapNhat = DateTime.Now
                };
                db.TaiLieus.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.MaTaiLieu;
            }
        }

        // Tầng dữ liệu thực hiện cập nhật thông tin tài liệu.
        public void UpdateTaiLieu(TaiLieuDTO dto)
        {
            using (var db = _factory.Create())
            {
                var entity = RequireEntity(
                    db.TaiLieus.FirstOrDefault(x => x.MaTaiLieu == dto.MaTaiLieu),
                    "Khong tim thay tai lieu can cap nhat.");
                entity.MaLopHoc = dto.MaLopHoc;
                entity.TenChuDe = dto.TenChuDe;
                entity.NoiDungMoTa = dto.NoiDungMoTa;
                entity.DuongDanFile = dto.DuongDanFile;
                entity.VideoLink = dto.VideoLink;
                entity.AudioPath = dto.AudioPath;
                entity.NhanKyNang = dto.NhanKyNang;
                entity.LoaiFile = dto.LoaiFile;
                entity.TenFileGoc = dto.TenFileGoc;
                entity.DuongDanLocal = dto.DuongDanLocal;
                entity.DuongDanCloud = dto.DuongDanCloud;
                entity.ThumbnailPath = dto.ThumbnailPath;
                entity.NgayCapNhat = DateTime.Now;
                db.SubmitChanges();
            }
        }

        // Tầng dữ liệu thực hiện xóa tài liệu đã chọn.
        public void DeleteTaiLieu(int maTaiLieu)
        {
            using (var db = _factory.Create())
            {
                var entity = RequireEntity(
                    db.TaiLieus.FirstOrDefault(x => x.MaTaiLieu == maTaiLieu),
                    "Khong tim thay tai lieu can xoa.");
                db.TaiLieus.DeleteOnSubmit(entity);
                db.SubmitChanges();
            }
        }

        // Tầng dữ liệu thực hiện lấy danh sách bài tập theo lớp.
        public List<BaiTapDTO> GetBaiTap(int? maLopHoc)
        {
            using (var db = _factory.Create())
            {
                // Khởi tạo truy vấn bài tập trước khi áp dụng bộ lọc.
                var query = db.BaiTaps.AsQueryable();
                if (maLopHoc.HasValue)
                {
                    // Giới hạn dữ liệu trong lớp học đang chọn.
                    query = query.Where(x => x.MaLopHoc == maLopHoc.Value);
                }

                return query.OrderByDescending(x => x.Deadline).AsEnumerable().Select(DtoMapper.ToDto).ToList();
            }
        }

        // Tầng dữ liệu thực hiện thêm bài tập mới.
        public int InsertBaiTap(BaiTapDTO dto)
        {
            using (var db = _factory.Create())
            {
                var entity = new BaiTapEntity
                {
                    MaLopHoc = dto.MaLopHoc,
                    TieuDe = dto.TieuDe,
                    MoTa = dto.MoTa,
                    Deadline = dto.Deadline,
                    FileDinhKem = dto.FileDinhKem,
                    NgayTao = DateTime.Now
                };
                db.BaiTaps.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.MaBaiTap;
            }
        }

        // Tầng dữ liệu thực hiện cập nhật thông tin bài tập.
        public void UpdateBaiTap(BaiTapDTO dto)
        {
            using (var db = _factory.Create())
            {
                var entity = RequireEntity(
                    db.BaiTaps.FirstOrDefault(x => x.MaBaiTap == dto.MaBaiTap),
                    "Khong tim thay bai tap can cap nhat.");
                entity.MaLopHoc = dto.MaLopHoc;
                entity.TieuDe = dto.TieuDe;
                entity.MoTa = dto.MoTa;
                entity.Deadline = dto.Deadline;
                entity.FileDinhKem = dto.FileDinhKem;
                db.SubmitChanges();
            }
        }

        // Tầng dữ liệu thực hiện xóa bài tập đã chọn.
        public void DeleteBaiTap(int maBaiTap)
        {
            using (var db = _factory.Create())
            {
                var entity = RequireEntity(
                    db.BaiTaps.FirstOrDefault(x => x.MaBaiTap == maBaiTap),
                    "Khong tim thay bai tap can xoa.");
                db.BaiTaps.DeleteOnSubmit(entity);
                db.SubmitChanges();
            }
        }

        // Tầng dữ liệu thực hiện tạo dòng nộp bài cho từng học viên trong lớp.
        public void TaoChiTietNopBaiChoLop(int maBaiTap, int maLopHoc)
        {
            using (var db = _factory.Create())
            {
                // Giới hạn dữ liệu trong lớp học đang chọn.
                var hocVienIds = db.ChiTietLopHocs.Where(x => x.MaLopHoc == maLopHoc).Select(x => x.MaNguoiDung).ToList();
                foreach (var maNguoiDung in hocVienIds)
                {
                    if (!db.ChiTietNopBais.Any(x => x.MaNguoiDung == maNguoiDung && x.MaBaiTap == maBaiTap))
                    {
                        db.ChiTietNopBais.InsertOnSubmit(new ChiTietNopBaiEntity
                        {
                            MaNguoiDung = maNguoiDung,
                            MaBaiTap = maBaiTap,
                            TrangThaiNop = "Chưa nộp"
                        });
                    }
                }

                db.SubmitChanges();
            }
        }

        // Tầng dữ liệu thực hiện lấy danh sách bài nộp của bài tập.
        public List<NopBaiDTO> GetNopBaiTheoBaiTap(int maBaiTap)
        {
            using (var db = _factory.Create())
            {
                var query =
                    // Khởi tạo truy vấn chi tiết bài nộp trước khi áp dụng bộ lọc.
                    from nb in db.ChiTietNopBais
                    join nd in db.NguoiDungs on nb.MaNguoiDung equals nd.MaNguoiDung
                    where nb.MaBaiTap == maBaiTap
                    orderby nd.HoTen
                    select new NopBaiDTO
                    {
                        MaNguoiDung = nb.MaNguoiDung,
                        MaBaiTap = nb.MaBaiTap,
                        HoTen = nd.HoTen,
                        FileBaiLam = nb.FileBaiLam,
                        ThoiGianNop = nb.ThoiGianNop,
                        TrangThaiNop = nb.TrangThaiNop,
                        DiemSo = nb.DiemSo,
                        NhanXet = nb.NhanXet
                    };

                return query.ToList();
            }
        }

        public void ChamBai(NopBaiDTO dto)
        {
            using (var db = _factory.Create())
            {
                var entity = RequireEntity(
                    db.ChiTietNopBais.FirstOrDefault(x => x.MaNguoiDung == dto.MaNguoiDung && x.MaBaiTap == dto.MaBaiTap),
                    "Khong tim thay bai nop can cham.");
                entity.DiemSo = dto.DiemSo;
                entity.NhanXet = dto.NhanXet;
                entity.TrangThaiNop = "Đã chấm";
                db.SubmitChanges();
            }
        }

        // Tầng dữ liệu thực hiện lấy danh sách buổi học của lớp.
        public List<BuoiHocDTO> GetBuoiHoc(int maLopHoc)
        {
            using (var db = _factory.Create())
            {
                // Giới hạn dữ liệu trong lớp học đang chọn.
                return db.BuoiHocs.Where(x => x.MaLopHoc == maLopHoc)
                    .OrderByDescending(x => x.NgayHoc)
                    .AsEnumerable()
                    .Select(DtoMapper.ToDto)
                    .ToList();
            }
        }

        // Tầng dữ liệu thực hiện lấy buổi học theo ngày, tạo mới nếu chưa có.
        public int GetOrCreateBuoiHoc(int maLopHoc, DateTime ngayHoc)
        {
            using (var db = _factory.Create())
            {
                var date = ngayHoc.Date;
                var entity = db.BuoiHocs.FirstOrDefault(x => x.MaLopHoc == maLopHoc && x.NgayHoc == date);
                if (entity != null)
                {
                    return entity.MaBuoiHoc;
                }

                entity = new BuoiHocEntity { MaLopHoc = maLopHoc, NgayHoc = date };
                db.BuoiHocs.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.MaBuoiHoc;
            }
        }

        // Tầng dữ liệu thực hiện lấy danh sách điểm danh của buổi học.
        public List<DiemDanhDTO> GetDiemDanh(int maBuoiHoc)
        {
            using (var db = _factory.Create())
            {
                var query =
                    // Khởi tạo truy vấn chi tiết điểm danh trước khi áp dụng bộ lọc.
                    from dd in db.ChiTietDiemDanhs
                    join nd in db.NguoiDungs on dd.MaNguoiDung equals nd.MaNguoiDung
                    where dd.MaBuoiHoc == maBuoiHoc
                    orderby nd.HoTen
                    select new DiemDanhDTO
                    {
                        MaNguoiDung = dd.MaNguoiDung,
                        MaBuoiHoc = dd.MaBuoiHoc,
                        HoTen = nd.HoTen,
                        CoMat = AppConstants.AttendancePresentAliases.Contains(dd.TrangThai) || AppConstants.AttendanceLateAliases.Contains(dd.TrangThai),
                        TrangThai = dd.TrangThai,
                        LyDoVang = dd.LyDoVang
                    };

                return query.ToList();
            }
        }

        // Tầng dữ liệu thực hiện lưu dữ liệu điểm danh.
        public void LuuDiemDanh(DiemDanhDTO dto)
        {
            using (var db = _factory.Create())
            {
                var entity = db.ChiTietDiemDanhs.FirstOrDefault(x => x.MaNguoiDung == dto.MaNguoiDung && x.MaBuoiHoc == dto.MaBuoiHoc);
                if (entity == null)
                {
                    entity = new ChiTietDiemDanhEntity { MaNguoiDung = dto.MaNguoiDung, MaBuoiHoc = dto.MaBuoiHoc };
                    db.ChiTietDiemDanhs.InsertOnSubmit(entity);
                }

                entity.TrangThai = dto.TrangThai;
                entity.LyDoVang = dto.LyDoVang;
                db.SubmitChanges();
            }
        }

        // Tầng dữ liệu thực hiện lưu dữ liệu điểm danh.
        public void LuuDiemDanh(IEnumerable<DiemDanhDTO> danhSach)
        {
            using (var db = _factory.Create())
            {
                foreach (var dto in danhSach)
                {
                    var entity = db.ChiTietDiemDanhs.FirstOrDefault(x => x.MaNguoiDung == dto.MaNguoiDung && x.MaBuoiHoc == dto.MaBuoiHoc);
                    if (entity == null)
                    {
                        entity = new ChiTietDiemDanhEntity
                        {
                            MaNguoiDung = dto.MaNguoiDung,
                            MaBuoiHoc = dto.MaBuoiHoc
                        };
                        db.ChiTietDiemDanhs.InsertOnSubmit(entity);
                    }

                    entity.TrangThai = dto.TrangThai;
                    entity.LyDoVang = dto.LyDoVang;
                }

                db.SubmitChanges();
            }
        }

        // Trả về thực thể bắt buộc hoặc ném lỗi rõ ràng khi không tìm thấy dữ liệu.
        public decimal TinhTiLeChuyenCan(int maNguoiDung, int maLopHoc, int? thang = null, int? nam = null)
        {
            using (var db = _factory.Create())
            {
                var chiTietLop = db.ChiTietLopHocs
                    // Giới hạn dữ liệu trong lớp học đang chọn.
                    .Where(x => x.MaNguoiDung == maNguoiDung && x.MaLopHoc == maLopHoc)
                    .OrderByDescending(x => x.NgayVaoLop)
                    .FirstOrDefault();
                if (chiTietLop == null)
                {
                    return 0m;
                }

                var ngayVaoLop = chiTietLop.NgayVaoLop.Date;
                // Giới hạn dữ liệu trong lớp học đang chọn.
                var buoiQuery = db.BuoiHocs.Where(x => x.MaLopHoc == maLopHoc && x.NgayHoc >= ngayVaoLop);
                if (thang.HasValue)
                {
                    buoiQuery = buoiQuery.Where(x => x.NgayHoc.Month == thang.Value);
                }

                if (nam.HasValue)
                {
                    buoiQuery = buoiQuery.Where(x => x.NgayHoc.Year == nam.Value);
                }

                var buoiIds = buoiQuery.Select(x => x.MaBuoiHoc).ToList();
                if (buoiIds.Count == 0)
                {
                    return 0m;
                }

                var soBuoiCoMatTheoHangSo = db.ChiTietDiemDanhs.Count(x =>
                    x.MaNguoiDung == maNguoiDung
                    && buoiIds.Contains(x.MaBuoiHoc)
                    && (AppConstants.AttendancePresentAliases.Contains(x.TrangThai) || AppConstants.AttendanceLateAliases.Contains(x.TrangThai)));
                if (soBuoiCoMatTheoHangSo >= 0)
                {
                    return Math.Round(soBuoiCoMatTheoHangSo * 100m / buoiIds.Count, 2);
                }

                var soBuoiCoMat = db.ChiTietDiemDanhs.Count(x =>
                    x.MaNguoiDung == maNguoiDung
                    && buoiIds.Contains(x.MaBuoiHoc)
                    && (x.TrangThai == "Có mặt" || x.TrangThai == "Đi trễ"));

                return Math.Round(soBuoiCoMat * 100m / buoiIds.Count, 2);
            }
        }

        // Tầng dữ liệu thực hiện lấy danh sách đề thi.
        public List<DeThiDTO> GetDeThi()
        {
            using (var db = _factory.Create())
            {
                return db.DeThis.OrderByDescending(x => x.NgayTao).AsEnumerable().Select(DtoMapper.ToDto).ToList();
            }
        }

        // Tầng dữ liệu thực hiện thêm đề thi mới.
        public int InsertDeThi(DeThiDTO dto)
        {
            using (var db = _factory.Create())
            {
                var entity = new DeThiEntity
                {
                    TenDeThi = dto.TenDeThi,
                    KyNang = dto.KyNang,
                    BandLevel = dto.BandLevel,
                    BandTu = dto.BandTu,
                    BandDen = dto.BandDen,
                    MoTa = dto.MoTa,
                    FileDuLieu = dto.FileDuLieu,
                    AudioPath = dto.AudioPath,
                    ImagePath = dto.ImagePath,
                    TrangThai = string.IsNullOrWhiteSpace(dto.TrangThai) ? "DangTao" : dto.TrangThai,
                    NgayTao = DateTime.Now
                };
                db.DeThis.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.MaDeThi;
            }
        }

        // Tầng dữ liệu thực hiện cập nhật thông tin đề thi.
        public void UpdateDeThi(DeThiDTO dto)
        {
            using (var db = _factory.Create())
            {
                var entity = RequireEntity(
                    db.DeThis.FirstOrDefault(x => x.MaDeThi == dto.MaDeThi),
                    "Khong tim thay de thi can cap nhat.");
                entity.TenDeThi = dto.TenDeThi;
                entity.KyNang = dto.KyNang;
                entity.BandLevel = dto.BandLevel;
                entity.BandTu = dto.BandTu;
                entity.BandDen = dto.BandDen;
                entity.MoTa = dto.MoTa;
                entity.FileDuLieu = dto.FileDuLieu;
                entity.AudioPath = dto.AudioPath;
                entity.ImagePath = dto.ImagePath;
                entity.TrangThai = string.IsNullOrWhiteSpace(dto.TrangThai) ? entity.TrangThai : dto.TrangThai;
                db.SubmitChanges();
            }
        }

        // Tầng dữ liệu thực hiện xóa đề thi đã chọn.
        public void DeleteDeThi(int maDeThi)
        {
            using (var db = _factory.Create())
            {
                var entity = RequireEntity(
                    db.DeThis.FirstOrDefault(x => x.MaDeThi == maDeThi),
                    "Khong tim thay de thi can xoa.");
                var details = db.ChiTietDeThis.Where(x => x.MaDeThi == maDeThi);
                db.ChiTietDeThis.DeleteAllOnSubmit(details);
                foreach (var dot in db.DotKiemTras.Where(x => x.MaDeThi == maDeThi))
                {
                    dot.MaDeThi = null;
                }

                db.DeThis.DeleteOnSubmit(entity);
                db.SubmitChanges();
            }
        }

        // Tầng dữ liệu thực hiện lấy các đoạn Reading theo khoảng band.
        public List<ReadingPassageDTO> GetReadingPassages(decimal? bandTu, decimal? bandDen)
        {
            using (var db = _factory.Create())
            {
                // Khởi tạo truy vấn đoạn Reading trước khi áp dụng bộ lọc.
                var query = db.ReadingPassages.AsQueryable();
                if (bandTu.HasValue)
                {
                    // Lọc nội dung IELTS theo khoảng band điểm.
                    query = query.Where(x => !x.BandLevel.HasValue || x.BandLevel.Value >= bandTu.Value);
                }

                if (bandDen.HasValue)
                {
                    // Lọc nội dung IELTS theo khoảng band điểm.
                    query = query.Where(x => !x.BandLevel.HasValue || x.BandLevel.Value <= bandDen.Value);
                }

                var questionCounts = db.CauHois
                    .Where(x => x.PassageId.HasValue)
                    // Gom nhóm dữ liệu để tính toán báo cáo hoặc thống kê.
                    .GroupBy(x => x.PassageId.Value)
                    .ToDictionary(x => x.Key, x => x.Count());

                return query.OrderByDescending(x => x.NgayTao)
                    .AsEnumerable()
                    .Select(x =>
                    {
                        var dto = DtoMapper.ToDto(x);
                        int count;
                        dto.SoCauHoi = questionCounts.TryGetValue(dto.PassageId, out count) ? count : 0;
                        return dto;
                    })
                    .ToList();
            }
        }

        // Tầng dữ liệu thực hiện lấy đoạn Reading theo mã.
        public ReadingPassageDTO GetReadingPassageById(int maPassage)
        {
            using (var db = _factory.Create())
            {
                return DtoMapper.ToDto(db.ReadingPassages.FirstOrDefault(x => x.PassageId == maPassage));
            }
        }

        // Tầng dữ liệu thực hiện lấy các phần Listening theo khoảng band.
        public List<ListeningSectionDTO> GetListeningSections(decimal? bandTu, decimal? bandDen)
        {
            using (var db = _factory.Create())
            {
                // Khởi tạo truy vấn phần Listening trước khi áp dụng bộ lọc.
                var query = db.ListeningSections.AsQueryable();
                if (bandTu.HasValue)
                {
                    // Lọc nội dung IELTS theo khoảng band điểm.
                    query = query.Where(x => !x.BandLevel.HasValue || x.BandLevel.Value >= bandTu.Value);
                }

                if (bandDen.HasValue)
                {
                    // Lọc nội dung IELTS theo khoảng band điểm.
                    query = query.Where(x => !x.BandLevel.HasValue || x.BandLevel.Value <= bandDen.Value);
                }

                var questionCounts = db.CauHois
                    .Where(x => x.SectionId.HasValue)
                    // Gom nhóm dữ liệu để tính toán báo cáo hoặc thống kê.
                    .GroupBy(x => x.SectionId.Value)
                    .ToDictionary(x => x.Key, x => x.Count());

                return query.OrderBy(x => x.SectionNumber)
                    .ThenByDescending(x => x.NgayTao)
                    .AsEnumerable()
                    .Select(x =>
                    {
                        var dto = DtoMapper.ToDto(x);
                        int count;
                        dto.SoCauHoi = questionCounts.TryGetValue(dto.SectionId, out count) ? count : 0;
                        return dto;
                    })
                    .ToList();
            }
        }

        // Tầng dữ liệu thực hiện lấy phần Listening theo mã.
        public ListeningSectionDTO GetListeningSectionById(int maSection)
        {
            using (var db = _factory.Create())
            {
                return DtoMapper.ToDto(db.ListeningSections.FirstOrDefault(x => x.SectionId == maSection));
            }
        }

        // Tầng dữ liệu thực hiện thêm đoạn Reading mới.
        public int InsertReadingPassage(ReadingPassageDTO dto)
        {
            using (var db = _factory.Create())
            {
                var entity = new ReadingPassageEntity
                {
                    PassageCode = dto.PassageCode,
                    Title = dto.Title,
                    Content = dto.Content,
                    ImagePath = dto.ImagePath,
                    BandLevel = dto.BandLevel,
                    Topic = dto.Topic,
                    NgayTao = DateTime.Now,
                    CreatedAt = DateTime.Now
                };
                db.ReadingPassages.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.PassageId;
            }
        }

        // Tầng dữ liệu thực hiện thêm nhiều đoạn Reading.
        public void InsertReadingPassageBulk(IEnumerable<ReadingPassageDTO> danhSach)
        {
            using (var db = _factory.Create())
            {
                db.ReadingPassages.InsertAllOnSubmit((danhSach ?? new List<ReadingPassageDTO>()).Select(dto => new ReadingPassageEntity
                {
                    PassageCode = dto.PassageCode,
                    Title = dto.Title,
                    Content = dto.Content,
                    ImagePath = dto.ImagePath,
                    BandLevel = dto.BandLevel,
                    Topic = dto.Topic,
                    NgayTao = DateTime.Now,
                    CreatedAt = DateTime.Now
                }));
                db.SubmitChanges();
            }
        }

        // Tầng dữ liệu thực hiện thêm phần Listening mới.
        public int InsertListeningSection(ListeningSectionDTO dto)
        {
            using (var db = _factory.Create())
            {
                var entity = new ListeningSectionEntity
                {
                    SectionCode = dto.SectionCode,
                    Title = dto.Title,
                    SectionNumber = dto.SectionNumber > 0 ? dto.SectionNumber : dto.PartNo,
                    PartNo = dto.PartNo > 0 ? dto.PartNo : dto.SectionNumber,
                    AudioPath = dto.AudioPath,
                    Transcript = dto.Transcript,
                    BandLevel = dto.BandLevel,
                    Topic = dto.Topic,
                    NgayTao = DateTime.Now,
                    CreatedAt = DateTime.Now
                };
                db.ListeningSections.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.SectionId;
            }
        }

        // Tầng dữ liệu thực hiện thêm nhiều phần Listening.
        public void InsertListeningSectionBulk(IEnumerable<ListeningSectionDTO> danhSach)
        {
            using (var db = _factory.Create())
            {
                db.ListeningSections.InsertAllOnSubmit((danhSach ?? new List<ListeningSectionDTO>()).Select(dto => new ListeningSectionEntity
                {
                    SectionCode = dto.SectionCode,
                    Title = dto.Title,
                    SectionNumber = dto.SectionNumber > 0 ? dto.SectionNumber : dto.PartNo,
                    PartNo = dto.PartNo > 0 ? dto.PartNo : dto.SectionNumber,
                    AudioPath = dto.AudioPath,
                    Transcript = dto.Transcript,
                    BandLevel = dto.BandLevel,
                    Topic = dto.Topic,
                    NgayTao = DateTime.Now,
                    CreatedAt = DateTime.Now
                }));
                db.SubmitChanges();
            }
        }

        // Tầng dữ liệu thực hiện lấy danh sách câu hỏi.
        public List<CauHoiDTO> GetCauHoi(string keyword)
        {
            using (var db = _factory.Create())
            {
                // Khởi tạo truy vấn câu hỏi trước khi áp dụng bộ lọc.
                var query = db.CauHois.AsQueryable();
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    // Lọc học viên theo từ khóa họ tên, tài khoản hoặc thư điện tử.
                    query = query.Where(x => x.NoiDung.Contains(keyword) || x.NhanKyNang.Contains(keyword) || x.QuestionType.Contains(keyword));
                }

                return query.OrderBy(x => x.NhanKyNang).AsEnumerable().Select(x => FillQuestionGroupTitle(DtoMapper.ToDto(x), db)).ToList();
            }
        }

        // Tầng dữ liệu thực hiện tìm kiếm câu hỏi theo bộ lọc nâng cao.
        public List<CauHoiDTO> SearchCauHoi(CauHoiSearchCriteriaDTO criteria)
        {
            using (var db = _factory.Create())
            {
                criteria = criteria ?? new CauHoiSearchCriteriaDTO();
                // Khởi tạo truy vấn câu hỏi trước khi áp dụng bộ lọc.
                var query = db.CauHois.AsQueryable();

                if (!string.IsNullOrWhiteSpace(criteria.NhanKyNang) && criteria.NhanKyNang != AppConstants.FilterAll)
                {
                    var skill = criteria.NhanKyNang.Trim();
                    // Chỉ thêm điều kiện lọc khi có tiêu chí nhãn kỹ năng.
                    query = query.Where(x => x.NhanKyNang == skill);
                }

                if (criteria.BandTu.HasValue)
                {
                    // Chỉ thêm điều kiện lọc khi có tiêu chí band từ.
                    query = query.Where(x => x.BandLevel.HasValue && x.BandLevel.Value >= criteria.BandTu.Value);
                }

                if (criteria.BandDen.HasValue)
                {
                    // Chỉ thêm điều kiện lọc khi có tiêu chí band đến.
                    query = query.Where(x => x.BandLevel.HasValue && x.BandLevel.Value <= criteria.BandDen.Value);
                }

                if (!string.IsNullOrWhiteSpace(criteria.Keyword))
                {
                    var keyword = criteria.Keyword.Trim();
                    // Chỉ thêm điều kiện lọc khi có tiêu chí từ khóa.
                    query = query.Where(x => x.NoiDung.Contains(keyword) || x.DapAn.Contains(keyword) || x.QuestionType.Contains(keyword) || x.AnswerKey.Contains(keyword));
                }

                return query.OrderBy(x => x.NhanKyNang)
                    .ThenBy(x => x.BandLevel)
                    .AsEnumerable()
                    .Select(x => FillQuestionGroupTitle(DtoMapper.ToDto(x), db))
                    .ToList();
            }
        }

        // Tầng dữ liệu thực hiện thêm câu hỏi mới.
        public int InsertCauHoi(CauHoiDTO dto)
        {
            using (var db = _factory.Create())
            {
                var entity = ToCauHoiEntity(dto);
                db.CauHois.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.MaCauHoi;
            }
        }

        // Tầng dữ liệu thực hiện lấy câu hỏi thuộc đoạn Reading.
        public List<CauHoiDTO> GetCauHoiByPassageId(int maPassage)
        {
            using (var db = _factory.Create())
            {
                return db.CauHois
                    .Where(x => x.PassageId == maPassage)
                    .OrderBy(x => x.MaCauHoi)
                    .AsEnumerable()
                    .Select(x => FillQuestionGroupTitle(DtoMapper.ToDto(x), db))
                    .ToList();
            }
        }

        // Tầng dữ liệu thực hiện lấy câu hỏi thuộc phần Listening.
        public List<CauHoiDTO> GetCauHoiBySectionId(int maSection)
        {
            using (var db = _factory.Create())
            {
                return db.CauHois
                    .Where(x => x.SectionId == maSection)
                    .OrderBy(x => x.MaCauHoi)
                    .AsEnumerable()
                    .Select(x => FillQuestionGroupTitle(DtoMapper.ToDto(x), db))
                    .ToList();
            }
        }

        // Tầng dữ liệu thực hiện thêm nhiều câu hỏi.
        public void InsertCauHoiBulk(IEnumerable<CauHoiDTO> danhSach)
        {
            using (var db = _factory.Create())
            {
                db.CauHois.InsertAllOnSubmit((danhSach ?? new List<CauHoiDTO>()).Select(ToCauHoiEntity));
                db.SubmitChanges();
            }
        }

        // Tầng dữ liệu thực hiện cập nhật thông tin câu hỏi.
        public void UpdateCauHoi(CauHoiDTO dto)
        {
            using (var db = _factory.Create())
            {
                var entity = RequireEntity(
                    db.CauHois.FirstOrDefault(x => x.MaCauHoi == dto.MaCauHoi),
                    "Khong tim thay cau hoi can cap nhat.");
                entity.NoiDung = dto.NoiDung;
                entity.DapAn = dto.DapAn;
                entity.NhanKyNang = dto.NhanKyNang;
                entity.QuestionType = dto.QuestionType;
                entity.OptionA = dto.OptionA;
                entity.OptionB = dto.OptionB;
                entity.OptionC = dto.OptionC;
                entity.OptionD = dto.OptionD;
                entity.AnswerKey = dto.AnswerKey;
                entity.Explanation = dto.Explanation;
                entity.PassageId = dto.PassageId;
                entity.SectionId = dto.SectionId;
                entity.BandLevel = dto.BandLevel;
                db.SubmitChanges();
            }
        }

        // Tầng dữ liệu thực hiện xóa câu hỏi đã chọn.
        public void DeleteCauHoi(int maCauHoi)
        {
            using (var db = _factory.Create())
            {
                var entity = RequireEntity(
                    db.CauHois.FirstOrDefault(x => x.MaCauHoi == maCauHoi),
                    "Khong tim thay cau hoi can xoa.");
                var details = db.ChiTietDeThis.Where(x => x.MaCauHoi == maCauHoi);
                db.ChiTietDeThis.DeleteAllOnSubmit(details);
                db.CauHois.DeleteOnSubmit(entity);
                db.SubmitChanges();
            }
        }

        // Tầng dữ liệu thực hiện thêm câu hỏi vào đề thi.
        public void ThemCauHoiVaoDeThi(int maDeThi, int maCauHoi)
        {
            ThemCauHoiVaoDeThi(maDeThi, maCauHoi, null, null, null);
        }

        // Tầng dữ liệu thực hiện lấy thứ tự tiếp theo trong đề thi.
        public int GetNextThuTu(int maDeThi)
        {
            using (var db = _factory.Create())
            {
                var current = db.ChiTietDeThis
                    .Where(x => x.MaDeThi == maDeThi && x.ThuTu.HasValue)
                    .Select(x => x.ThuTu.Value)
                    .DefaultIfEmpty(0)
                    .Max();
                return current + 1;
            }
        }

        // Kiểm tra câu hỏi đã nằm trong đề thi trong cơ sở dữ liệu.
        public bool ExistsQuestionInExam(int maDeThi, int maCauHoi)
        {
            using (var db = _factory.Create())
            {
                return db.ChiTietDeThis.Any(x => x.MaDeThi == maDeThi && x.MaCauHoi == maCauHoi);
            }
        }

        // Tầng dữ liệu thực hiện thêm câu hỏi vào đề thi.
        public void ThemCauHoiVaoDeThi(int maDeThi, int maCauHoi, string groupType, int? groupId, int? thuTu)
        {
            using (var db = _factory.Create())
            {
                if (!db.ChiTietDeThis.Any(x => x.MaDeThi == maDeThi && x.MaCauHoi == maCauHoi))
                {
                    var finalOrder = thuTu.HasValue && thuTu.Value > 0
                        ? thuTu.Value
                        : db.ChiTietDeThis.Where(x => x.MaDeThi == maDeThi && x.ThuTu.HasValue).Select(x => x.ThuTu.Value).DefaultIfEmpty(0).Max() + 1;
                    db.ChiTietDeThis.InsertOnSubmit(new ChiTietDeThiEntity
                    {
                        MaDeThi = maDeThi,
                        MaCauHoi = maCauHoi,
                        GroupType = groupType,
                        GroupId = groupId,
                        ThuTu = finalOrder
                    });
                    db.SubmitChanges();
                }
            }
        }

        // Tầng dữ liệu thực hiện lấy nội dung đề thi.
        public List<IeltsExamItemDTO> GetNoiDungDeThi(int maDeThi)
        {
            using (var db = _factory.Create())
            {
                var query =
                    // Khởi tạo truy vấn chi tiết đề thi trước khi áp dụng bộ lọc.
                    from ct in db.ChiTietDeThis
                    join q in db.CauHois on ct.MaCauHoi equals q.MaCauHoi
                    where ct.MaDeThi == maDeThi
                    select new { ct, q };

                return query.AsEnumerable()
                    .Select(x => new IeltsExamItemDTO
                    {
                        MaDeThi = x.ct.MaDeThi,
                        MaCauHoi = x.ct.MaCauHoi,
                        GroupType = x.ct.GroupType,
                        GroupId = x.ct.GroupId,
                        ThuTu = x.ct.ThuTu,
                        GroupTitle = ResolveGroupTitle(db, x.ct.GroupType, x.ct.GroupId),
                        NoiDung = x.q.NoiDung,
                        QuestionType = x.q.QuestionType,
                        AnswerKey = x.q.AnswerKey,
                        BandLevel = x.q.BandLevel
                    })
                    .OrderBy(x => x.GroupType)
                    .ThenBy(x => x.GroupId)
                    .ThenBy(x => x.ThuTu)
                    .ToList();
            }
        }

        // Tầng dữ liệu thực hiện xóa câu hỏi khỏi đề thi.
        public void XoaCauHoiKhoiDeThi(int maDeThi, int maCauHoi)
        {
            using (var db = _factory.Create())
            {
                var entity = db.ChiTietDeThis.FirstOrDefault(x => x.MaDeThi == maDeThi && x.MaCauHoi == maCauHoi);
                if (entity != null)
                {
                    db.ChiTietDeThis.DeleteOnSubmit(entity);
                    db.SubmitChanges();
                }
            }
        }

        // Trả về thực thể bắt buộc hoặc ném lỗi rõ ràng khi không tìm thấy dữ liệu.
        public int ImportIeltsRows(IEnumerable<IeltsImportRowDTO> rows)
        {
            using (var db = _factory.Create())
            {
                var count = 0;
                foreach (var row in rows ?? new List<IeltsImportRowDTO>())
                {
                    var skill = (row.Skill ?? string.Empty).Trim();
                    int? passageId = null;
                    int? sectionId = null;

                    if (string.Equals(skill, "Reading", StringComparison.OrdinalIgnoreCase))
                    {
                        var title = string.IsNullOrWhiteSpace(row.PassageTitle) ? "Reading Passage" : row.PassageTitle.Trim();
                        var code = string.IsNullOrWhiteSpace(row.PassageCode) ? row.ParentCode : row.PassageCode;
                        var passage = db.ReadingPassages.FirstOrDefault(x => (!string.IsNullOrEmpty(code) && x.PassageCode == code) || x.Title == title);
                        if (passage == null)
                        {
                            passage = new ReadingPassageEntity
                            {
                                PassageCode = code,
                                Title = title,
                                Content = row.PassageContent ?? string.Empty,
                                ImagePath = row.ImagePath,
                                BandLevel = row.BandLevel,
                                Topic = row.Topic,
                                NgayTao = DateTime.Now,
                                CreatedAt = DateTime.Now
                            };
                            db.ReadingPassages.InsertOnSubmit(passage);
                            db.SubmitChanges();
                        }

                        passageId = passage.PassageId;
                    }
                    else if (string.Equals(skill, "Listening", StringComparison.OrdinalIgnoreCase))
                    {
                        var title = string.IsNullOrWhiteSpace(row.SectionTitle) ? "Listening Section" : row.SectionTitle.Trim();
                        var number = row.SectionNumber.HasValue && row.SectionNumber.Value >= 1 && row.SectionNumber.Value <= 4 ? row.SectionNumber.Value : 1;
                        var code = string.IsNullOrWhiteSpace(row.SectionCode) ? row.ParentCode : row.SectionCode;
                        var section = db.ListeningSections.FirstOrDefault(x => (!string.IsNullOrEmpty(code) && x.SectionCode == code) || (x.Title == title && x.SectionNumber == number));
                        if (section == null)
                        {
                            section = new ListeningSectionEntity
                            {
                                SectionCode = code,
                                Title = title,
                                SectionNumber = number,
                                PartNo = number,
                                AudioPath = row.AudioPath,
                                Transcript = row.Transcript,
                                BandLevel = row.BandLevel,
                                Topic = row.Topic,
                                NgayTao = DateTime.Now,
                                CreatedAt = DateTime.Now
                            };
                            db.ListeningSections.InsertOnSubmit(section);
                            db.SubmitChanges();
                        }

                        sectionId = section.SectionId;
                    }

                    db.CauHois.InsertOnSubmit(new CauHoiEntity
                    {
                        NoiDung = row.QuestionText,
                        DapAn = row.AnswerKey,
                        NhanKyNang = skill,
                        QuestionType = row.QuestionType,
                        OptionA = row.OptionA,
                        OptionB = row.OptionB,
                        OptionC = row.OptionC,
                        OptionD = row.OptionD,
                        AnswerKey = row.AnswerKey,
                        Explanation = row.Explanation,
                        PassageId = passageId,
                        SectionId = sectionId,
                        BandLevel = row.BandLevel
                    });
                    count++;
                }

                db.SubmitChanges();
                return count;
            }
        }

        // Chuyển đối tượng truyền dữ liệu sang thực thể dữ liệu trước khi lưu xuống cơ sở dữ liệu.
        private static CauHoiEntity ToCauHoiEntity(CauHoiDTO dto)
        {
            return new CauHoiEntity
            {
                NoiDung = dto.NoiDung,
                DapAn = string.IsNullOrWhiteSpace(dto.DapAn) ? dto.AnswerKey : dto.DapAn,
                NhanKyNang = dto.NhanKyNang,
                QuestionType = dto.QuestionType,
                OptionA = dto.OptionA,
                OptionB = dto.OptionB,
                OptionC = dto.OptionC,
                OptionD = dto.OptionD,
                AnswerKey = dto.AnswerKey,
                Explanation = dto.Explanation,
                PassageId = dto.PassageId,
                SectionId = dto.SectionId,
                BandLevel = dto.BandLevel
            };
        }

        // Xử lý dữ liệu phụ trợ trước khi kho dữ liệu đọc hoặc ghi cơ sở dữ liệu.
        private static CauHoiDTO FillQuestionGroupTitle(CauHoiDTO dto, QuanLyIeltsDataContext db)
        {
            if (dto == null)
            {
                return null;
            }

            if (dto.PassageId.HasValue)
            {
                var passage = db.ReadingPassages.FirstOrDefault(x => x.PassageId == dto.PassageId.Value);
                dto.GroupTitle = passage == null ? string.Empty : passage.Title;
            }
            else if (dto.SectionId.HasValue)
            {
                var section = db.ListeningSections.FirstOrDefault(x => x.SectionId == dto.SectionId.Value);
                dto.GroupTitle = section == null ? string.Empty : section.Title;
            }

            return dto;
        }

        // Xây dựng truy vấn hoặc diễn giải dữ liệu phục vụ tầng dữ liệu.
        private static string ResolveGroupTitle(QuanLyIeltsDataContext db, string groupType, int? groupId)
        {
            if (!groupId.HasValue)
            {
                return string.Empty;
            }

            if (string.Equals(groupType, "Reading", StringComparison.OrdinalIgnoreCase))
            {
                var passage = db.ReadingPassages.FirstOrDefault(x => x.PassageId == groupId.Value);
                return passage == null ? string.Empty : passage.Title;
            }

            if (string.Equals(groupType, "Listening", StringComparison.OrdinalIgnoreCase))
            {
                var section = db.ListeningSections.FirstOrDefault(x => x.SectionId == groupId.Value);
                return section == null ? string.Empty : section.Title;
            }

            return string.Empty;
        }

        // Tầng dữ liệu thực hiện lấy danh sách đợt kiểm tra của lớp.
        public List<DotKiemTraDTO> GetDotKiemTra(int maLopHoc)
        {
            using (var db = _factory.Create())
            {
                // Giới hạn dữ liệu trong lớp học đang chọn.
                return db.DotKiemTras.Where(x => x.MaLopHoc == maLopHoc)
                    .OrderByDescending(x => x.NgayKiemTra)
                    .AsEnumerable()
                    .Select(DtoMapper.ToDto)
                    .ToList();
            }
        }

        // Tầng dữ liệu thực hiện thêm đợt kiểm tra mới.
        public int InsertDotKiemTra(DotKiemTraDTO dto)
        {
            using (var db = _factory.Create())
            {
                var entity = new DotKiemTraEntity
                {
                    MaLopHoc = dto.MaLopHoc,
                    MaDeThi = dto.MaDeThi == 0 ? (int?)null : dto.MaDeThi,
                    TenDotKiemTra = dto.TenDotKiemTra,
                    NgayKiemTra = dto.NgayKiemTra.Date
                };
                db.DotKiemTras.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.MaDotKiemTra;
            }
        }

        // Tầng dữ liệu thực hiện lấy danh sách điểm số của đợt kiểm tra.
        public List<DiemSoDTO> GetDiemSo(int maDotKiemTra)
        {
            using (var db = _factory.Create())
            {
                var query =
                    // Khởi tạo truy vấn chi tiết điểm số trước khi áp dụng bộ lọc.
                    from ds in db.ChiTietDiemSos
                    join nd in db.NguoiDungs on ds.MaNguoiDung equals nd.MaNguoiDung
                    where ds.MaDotKiemTra == maDotKiemTra
                    orderby nd.HoTen
                    select new DiemSoDTO
                    {
                        MaNguoiDung = ds.MaNguoiDung,
                        MaDotKiemTra = ds.MaDotKiemTra,
                        HoTen = nd.HoTen,
                        DiemL = ds.DiemL,
                        DiemR = ds.DiemR,
                        DiemW = ds.DiemW,
                        DiemS = ds.DiemS,
                        DiemTong = ds.DiemTong,
                        NhanXet = ds.NhanXet
                    };

                return query.ToList();
            }
        }

        // Kiểm tra điểm số đã có của học viên trong đợt kiểm tra trong cơ sở dữ liệu.
        public bool ExistsDiemSo(int maNguoiDung, int maDotKiemTra)
        {
            using (var db = _factory.Create())
            {
                return db.ChiTietDiemSos.Any(x => x.MaNguoiDung == maNguoiDung && x.MaDotKiemTra == maDotKiemTra);
            }
        }

        // Tầng dữ liệu thực hiện thêm điểm số mới cho học viên.
        public void InsertDiemSo(DiemSoDTO dto)
        {
            using (var db = _factory.Create())
            {
                db.ChiTietDiemSos.InsertOnSubmit(new ChiTietDiemSoEntity
                {
                    MaNguoiDung = dto.MaNguoiDung,
                    MaDotKiemTra = dto.MaDotKiemTra,
                    DiemL = dto.DiemL,
                    DiemR = dto.DiemR,
                    DiemW = dto.DiemW,
                    DiemS = dto.DiemS,
                    DiemTong = dto.DiemTong,
                    NhanXet = dto.NhanXet
                });
                db.SubmitChanges();
            }
        }

        // Tầng dữ liệu thực hiện lấy danh sách từ vựng theo lớp.
        public List<TuVungDTO> GetTuVung(int? maLopHoc)
        {
            using (var db = _factory.Create())
            {
                // Khởi tạo truy vấn từ vựng trước khi áp dụng bộ lọc.
                var query = db.TuVungs.AsQueryable();
                if (maLopHoc.HasValue)
                {
                    // Giới hạn dữ liệu trong lớp học đang chọn.
                    query = query.Where(x => x.MaLopHoc == maLopHoc.Value);
                }

                return query.OrderBy(x => x.TuTiengAnh).AsEnumerable().Select(DtoMapper.ToDto).ToList();
            }
        }

        // Tầng dữ liệu thực hiện tìm kiếm từ vựng theo tiêu chí tìm kiếm.
        public List<TuVungDTO> SearchTuVung(TuVungSearchCriteriaDTO criteria)
        {
            using (var db = _factory.Create())
            {
                criteria = criteria ?? new TuVungSearchCriteriaDTO();
                // Khởi tạo truy vấn từ vựng trước khi áp dụng bộ lọc.
                var query = db.TuVungs.AsQueryable();

                if (criteria.MaLopHoc.HasValue && criteria.MaLopHoc.Value > 0)
                {
                    // Chỉ thêm điều kiện lọc khi có tiêu chí lớp học.
                    query = query.Where(x => x.MaLopHoc == criteria.MaLopHoc.Value);
                }

                if (!string.IsNullOrWhiteSpace(criteria.Keyword))
                {
                    var keyword = criteria.Keyword.Trim();
                    // Chỉ thêm điều kiện lọc khi có tiêu chí từ khóa.
                    query = query.Where(x => x.TuTiengAnh.Contains(keyword) || x.Nghia.Contains(keyword));
                }

                if (!string.IsNullOrWhiteSpace(criteria.TuLoai) && criteria.TuLoai != AppConstants.FilterAll)
                {
                    var tuLoai = criteria.TuLoai.Trim();
                    query = query.Where(x => x.TuLoai == tuLoai);
                }

                if (!string.IsNullOrWhiteSpace(criteria.CapDo) && criteria.CapDo != AppConstants.FilterAll)
                {
                    var capDo = criteria.CapDo.Trim();
                    // Chỉ thêm điều kiện lọc khi có tiêu chí cấp độ.
                    query = query.Where(x => x.CapDo == capDo);
                }

                if (!string.IsNullOrWhiteSpace(criteria.ChuDe) && criteria.ChuDe != AppConstants.FilterAll)
                {
                    var chuDe = criteria.ChuDe.Trim();
                    // Chỉ thêm điều kiện lọc khi có tiêu chí chủ đề.
                    query = query.Where(x => x.ChuDe == chuDe);
                }

                if (!string.IsNullOrWhiteSpace(criteria.ChuCaiDau) && criteria.ChuCaiDau != AppConstants.FilterAll)
                {
                    var chuCaiDau = criteria.ChuCaiDau.Trim();
                    // Chỉ thêm điều kiện lọc khi có tiêu chí chữ cái đầu.
                    query = query.Where(x => x.TuTiengAnh.StartsWith(chuCaiDau));
                }

                return query.OrderBy(x => x.TuTiengAnh).AsEnumerable().Select(DtoMapper.ToDto).ToList();
            }
        }

        // Kiểm tra từ vựng bị trùng trong lớp trong cơ sở dữ liệu.
        public bool ExistsTuVungTrongLop(string tuTiengAnh, int maLopHoc, int exceptId)
        {
            using (var db = _factory.Create())
            {
                return db.TuVungs.Any(x => x.MaLopHoc == maLopHoc && x.TuTiengAnh == tuTiengAnh && x.MaTuVung != exceptId);
            }
        }

        // Tầng dữ liệu thực hiện thêm từ vựng mới.
        public int InsertTuVung(TuVungDTO dto)
        {
            using (var db = _factory.Create())
            {
                var entity = new TuVungEntity
                {
                    MaLopHoc = dto.MaLopHoc,
                    TuTiengAnh = dto.TuTiengAnh,
                    TuLoai = dto.TuLoai,
                    PhienAm = dto.PhienAm,
                    Nghia = dto.Nghia,
                    CapDo = dto.CapDo,
                    ChuDe = dto.ChuDe
                };
                db.TuVungs.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.MaTuVung;
            }
        }

        // Tầng dữ liệu thực hiện cập nhật thông tin từ vựng.
        public void UpdateTuVung(TuVungDTO dto)
        {
            using (var db = _factory.Create())
            {
                var entity = RequireEntity(
                    db.TuVungs.FirstOrDefault(x => x.MaTuVung == dto.MaTuVung),
                    "Khong tim thay tu vung can cap nhat.");
                entity.MaLopHoc = dto.MaLopHoc;
                entity.TuTiengAnh = dto.TuTiengAnh;
                entity.TuLoai = dto.TuLoai;
                entity.PhienAm = dto.PhienAm;
                entity.Nghia = dto.Nghia;
                entity.CapDo = dto.CapDo;
                entity.ChuDe = dto.ChuDe;
                db.SubmitChanges();
            }
        }

        // Tầng dữ liệu thực hiện xóa từ vựng đã chọn.
        public void DeleteTuVung(int maTuVung)
        {
            using (var db = _factory.Create())
            {
                var progress = db.TienTrinhFlashcards.Where(x => x.MaTuVung == maTuVung);
                db.TienTrinhFlashcards.DeleteAllOnSubmit(progress);
                var entity = RequireEntity(
                    db.TuVungs.FirstOrDefault(x => x.MaTuVung == maTuVung),
                    "Khong tim thay tu vung can xoa.");
                db.TuVungs.DeleteOnSubmit(entity);
                db.SubmitChanges();
            }
        }

        // Trả về thực thể bắt buộc hoặc ném lỗi rõ ràng khi không tìm thấy dữ liệu.
        public void DongBoFlashcardChoLop(int maTuVung, int maLopHoc)
        {
            using (var db = _factory.Create())
            {
                // Giới hạn dữ liệu trong lớp học đang chọn.
                var hocVienIds = db.ChiTietLopHocs.Where(x => x.MaLopHoc == maLopHoc).Select(x => x.MaNguoiDung).ToList();
                foreach (var maNguoiDung in hocVienIds)
                {
                    if (!db.TienTrinhFlashcards.Any(x => x.MaNguoiDung == maNguoiDung && x.MaTuVung == maTuVung))
                    {
                        db.TienTrinhFlashcards.InsertOnSubmit(new TienTrinhFlashcardEntity
                        {
                            MaNguoiDung = maNguoiDung,
                            MaTuVung = maTuVung,
                            KetQua = "Chưa học"
                        });
                    }
                }

                db.SubmitChanges();
            }
        }

        // Tầng dữ liệu thực hiện lưu tiến trình học flashcard.
        public void UpsertTienTrinhFlashcard(int maNguoiDung, int maTuVung, string ketQua)
        {
            using (var db = _factory.Create())
            {
                var entity = db.TienTrinhFlashcards.FirstOrDefault(x =>
                    x.MaNguoiDung == maNguoiDung && x.MaTuVung == maTuVung);
                if (entity == null)
                {
                    db.TienTrinhFlashcards.InsertOnSubmit(new TienTrinhFlashcardEntity
                    {
                        MaNguoiDung = maNguoiDung,
                        MaTuVung = maTuVung,
                        KetQua = ketQua
                    });
                }
                else
                {
                    entity.KetQua = ketQua;
                }

                db.SubmitChanges();
            }
        }

        // Tầng dữ liệu thực hiện lấy danh sách thông báo.
        public List<ThongBaoDTO> GetThongBao()
        {
            using (var db = _factory.Create())
            {
                return db.ThongBaos.OrderByDescending(x => x.ThoiGianGui).AsEnumerable().Select(DtoMapper.ToDto).ToList();
            }
        }

        // Tầng dữ liệu thực hiện thêm thông báo mới.
        public int InsertThongBao(ThongBaoDTO dto)
        {
            using (var db = _factory.Create())
            {
                var entity = new ThongBaoEntity
                {
                    MaNguoiGui = dto.MaNguoiGui,
                    TieuDe = dto.TieuDe,
                    NoiDung = dto.NoiDung,
                    DoiTuongNhan = dto.DoiTuongNhan,
                    ThoiGianGui = DateTime.Now
                };
                db.ThongBaos.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.MaThongBao;
            }
        }

        // Tầng dữ liệu thực hiện tạo danh sách người nhận thông báo.
        public void TaoNguoiNhanThongBao(int maThongBao, IEnumerable<int> maNguoiNhan)
        {
            using (var db = _factory.Create())
            {
                foreach (var maNguoiDung in maNguoiNhan.Distinct())
                {
                    if (!db.ChiTietThongBaos.Any(x => x.MaThongBao == maThongBao && x.MaNguoiDung == maNguoiDung))
                    {
                        db.ChiTietThongBaos.InsertOnSubmit(new ChiTietThongBaoEntity
                        {
                            MaThongBao = maThongBao,
                            MaNguoiDung = maNguoiDung,
                            DaDoc = false
                        });
                    }
                }

                db.SubmitChanges();
            }
        }

        // Tầng dữ liệu thực hiện lấy danh sách học phí.
        public List<ThanhToanHocPhiDTO> GetHocPhi()
        {
            return GetHocPhi(null, null, null);
        }

        // Tầng dữ liệu thực hiện lấy danh sách học phí.
        public List<ThanhToanHocPhiDTO> GetHocPhi(int? maLopHoc, DateTime? tuNgay, DateTime? denNgay)
        {
            using (var db = _factory.Create())
            {
                var query =
                    // Khởi tạo truy vấn thanh toán học phí trước khi áp dụng bộ lọc.
                    from hp in db.ThanhToanHocPhis
                    join nd in db.NguoiDungs on hp.MaNguoiDung equals nd.MaNguoiDung
                    join lop in db.LopHocs on hp.MaLopHoc equals (int?)lop.MaLopHoc into lopJoin
                    from lop in lopJoin.DefaultIfEmpty()
                    select new ThanhToanHocPhiDTO
                    {
                        MaThanhToan = hp.MaThanhToan,
                        MaNguoiDung = hp.MaNguoiDung,
                        MaLopHoc = hp.MaLopHoc,
                        HoTen = nd.HoTen,
                        TenLop = lop == null ? string.Empty : lop.TenLop,
                        SoTien = hp.SoTien,
                        SoTienGoc = hp.SoTienGoc,
                        PhanTramGiam = hp.PhanTramGiam,
                        SoTienGiam = hp.SoTienGiam,
                        SoTienCuoi = hp.SoTienCuoi,
                        ThongTinNganHang = hp.ThongTinNganHang,
                        NgayTao = hp.NgayTao,
                        HanThanhToan = hp.HanThanhToan,
                        MaHoaDon = hp.MaHoaDon,
                        PhuongThucThanhToan = hp.PhuongThucThanhToan,
                        NgayThanhToan = hp.NgayThanhToan,
                        TrangThai = hp.TrangThai
                    };

                if (maLopHoc.HasValue && maLopHoc.Value > 0)
                {
                    // Giới hạn dữ liệu trong lớp học đang chọn.
                    query = query.Where(x => x.MaLopHoc == maLopHoc.Value);
                }

                if (tuNgay.HasValue)
                {
                    // Lọc dữ liệu trong khoảng ngày được chọn.
                    query = query.Where(x => x.NgayTao >= tuNgay.Value.Date);
                }

                if (denNgay.HasValue)
                {
                    var den = denNgay.Value.Date.AddDays(1);
                    // Lọc dữ liệu trong khoảng ngày được chọn.
                    query = query.Where(x => x.NgayTao < den);
                }

                return query.OrderByDescending(x => x.HanThanhToan).ToList();
            }
        }

        // Tầng dữ liệu thực hiện thêm phiếu học phí mới.
        public int InsertHocPhi(ThanhToanHocPhiDTO dto)
        {
            using (var db = _factory.Create())
            {
                var entity = new ThanhToanHocPhiEntity
                {
                    MaNguoiDung = dto.MaNguoiDung,
                    MaLopHoc = dto.MaLopHoc,
                    SoTien = dto.SoTien,
                    SoTienGoc = dto.SoTienGoc,
                    PhanTramGiam = dto.PhanTramGiam,
                    SoTienGiam = dto.SoTienGiam,
                    SoTienCuoi = dto.SoTienCuoi,
                    ThongTinNganHang = dto.ThongTinNganHang,
                    NgayTao = DateTime.Now,
                    HanThanhToan = dto.HanThanhToan,
                    MaHoaDon = dto.MaHoaDon,
                    PhuongThucThanhToan = dto.PhuongThucThanhToan,
                    NgayThanhToan = dto.NgayThanhToan,
                    TrangThai = dto.TrangThai
                };
                db.ThanhToanHocPhis.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.MaThanhToan;
            }
        }

        // Tầng dữ liệu thực hiện thêm nhiều phiếu học phí.
        public void InsertHocPhiBulk(IEnumerable<ThanhToanHocPhiDTO> danhSach)
        {
            using (var db = _factory.Create())
            {
                foreach (var dto in danhSach)
                {
                    db.ThanhToanHocPhis.InsertOnSubmit(new ThanhToanHocPhiEntity
                    {
                        MaNguoiDung = dto.MaNguoiDung,
                        MaLopHoc = dto.MaLopHoc,
                        SoTien = dto.SoTien,
                        SoTienGoc = dto.SoTienGoc,
                        PhanTramGiam = dto.PhanTramGiam,
                        SoTienGiam = dto.SoTienGiam,
                        SoTienCuoi = dto.SoTienCuoi,
                        ThongTinNganHang = dto.ThongTinNganHang,
                        NgayTao = dto.NgayTao,
                        HanThanhToan = dto.HanThanhToan,
                        MaHoaDon = dto.MaHoaDon,
                        PhuongThucThanhToan = dto.PhuongThucThanhToan,
                        NgayThanhToan = dto.NgayThanhToan,
                        TrangThai = dto.TrangThai
                    });
                }

                db.SubmitChanges();
            }
        }

        // Tầng dữ liệu thực hiện cập nhật trạng thái học phí.
        public void UpdateTrangThaiHocPhi(int maThanhToan, string trangThai)
        {
            using (var db = _factory.Create())
            {
                var entity = RequireEntity(
                    db.ThanhToanHocPhis.FirstOrDefault(x => x.MaThanhToan == maThanhToan),
                    "Khong tim thay phieu hoc phi can cap nhat.");
                entity.TrangThai = trangThai;
                db.SubmitChanges();
            }
        }

        // Tầng dữ liệu thực hiện tạo nhật ký giao dịch thanh toán.
        public PaymentResultDTO TaoNhatKyThanhToan(PaymentRequestDTO request, string maGiaoDichNgoai, string paymentUrl, string qrContent)
        {
            using (var db = _factory.Create())
            {
                EnsurePaymentDebugColumns(db);
                var entity = new NhatKyThanhToanEntity
                {
                    MaThanhToan = request.MaThanhToan,
                    PhuongThuc = request.PhuongThuc,
                    SoTien = request.SoTien,
                    NoiDungThanhToan = request.NoiDungThanhToan,
                    MaGiaoDichNgoai = maGiaoDichNgoai,
                    PaymentUrl = paymentUrl,
                    QrContent = qrContent,
                    TrangThai = AppConstants.PaymentPending,
                    NgayTao = DateTime.Now,
                    ReceiverEmail = request.EmailNguoiNhan,
                    IsDebugPayment = false,
                    PaymentEmailSent = false,
                    StatusEmailSent = false
                };
                db.NhatKyThanhToans.InsertOnSubmit(entity);
                db.SubmitChanges();
                return DtoMapper.ToDto(entity);
            }
        }

        // Tầng dữ liệu thực hiện lấy giao dịch thanh toán theo mã.
        public PaymentResultDTO LayGiaoDichThanhToan(int maGiaoDich)
        {
            using (var db = _factory.Create())
            {
                EnsurePaymentDebugColumns(db);
                return DtoMapper.ToDto(db.NhatKyThanhToans.FirstOrDefault(x => x.MaGiaoDich == maGiaoDich));
            }
        }

        // Tầng dữ liệu thực hiện lấy các giao dịch của khoản học phí.
        public List<PaymentResultDTO> LayGiaoDichTheoThanhToan(int maThanhToan)
        {
            using (var db = _factory.Create())
            {
                EnsurePaymentDebugColumns(db);
                return db.NhatKyThanhToans
                    .Where(x => x.MaThanhToan == maThanhToan)
                    .OrderByDescending(x => x.NgayTao)
                    .AsEnumerable()
                    .Select(DtoMapper.ToDto)
                    .ToList();
            }
        }

        // Tầng dữ liệu thực hiện lấy chi tiết giao dịch để kiểm thử.
        public PaymentDebugResultDTO LayChiTietGiaoDichDebug(int maGiaoDich)
        {
            using (var db = _factory.Create())
            {
                EnsurePaymentDebugColumns(db);
                return BuildPaymentDebugQuery(db).FirstOrDefault(x => x.TransactionId == maGiaoDich);
            }
        }

        // Tầng dữ liệu thực hiện cập nhật trạng thái gửi thư yêu cầu thanh toán.
        public void CapNhatEmailThanhToan(int maGiaoDich, bool sent, DateTime? sentAt, string error)
        {
            using (var db = _factory.Create())
            {
                EnsurePaymentDebugColumns(db);
                var entity = RequireEntity(
                    db.NhatKyThanhToans.FirstOrDefault(x => x.MaGiaoDich == maGiaoDich),
                    "Khong tim thay giao dich thanh toan.");
                entity.PaymentEmailSent = sent;
                entity.PaymentEmailSentAt = sentAt;
                entity.PaymentEmailError = sent ? null : TrimForColumn(error, 1000);
                entity.NgayCapNhat = DateTime.Now;
                db.SubmitChanges();
            }
        }

        // Tầng dữ liệu thực hiện cập nhật trạng thái gửi thư thông báo giao dịch.
        public void CapNhatEmailTrangThai(int maGiaoDich, bool sent, DateTime? sentAt, string error)
        {
            using (var db = _factory.Create())
            {
                EnsurePaymentDebugColumns(db);
                var entity = RequireEntity(
                    db.NhatKyThanhToans.FirstOrDefault(x => x.MaGiaoDich == maGiaoDich),
                    "Khong tim thay giao dich thanh toan.");
                entity.StatusEmailSent = sent;
                entity.StatusEmailSentAt = sentAt;
                entity.StatusEmailError = sent ? null : TrimForColumn(error, 1000);
                entity.LastStatusUpdateAt = DateTime.Now;
                entity.NgayCapNhat = DateTime.Now;
                db.SubmitChanges();
            }
        }

        // Tầng dữ liệu thực hiện cập nhật trạng thái giao dịch.
        public void CapNhatTrangThaiGiaoDich(int maGiaoDich, string trangThai)
        {
            using (var db = _factory.Create())
            {
                EnsurePaymentDebugColumns(db);
                var entity = RequireEntity(
                    db.NhatKyThanhToans.FirstOrDefault(x => x.MaGiaoDich == maGiaoDich),
                    "Khong tim thay giao dich thanh toan.");
                entity.TrangThai = trangThai;
                entity.NgayCapNhat = DateTime.Now;
                entity.LastStatusUpdateAt = DateTime.Now;
                db.SubmitChanges();
            }
        }

        // Tầng dữ liệu thực hiện cập nhật trạng thái và phương thức thanh toán học phí.
        public void CapNhatTrangThaiHocPhi(int maThanhToan, string trangThai, string phuongThuc, DateTime? ngayThanhToan)
        {
            using (var db = _factory.Create())
            {
                var entity = RequireEntity(
                    db.ThanhToanHocPhis.FirstOrDefault(x => x.MaThanhToan == maThanhToan),
                    "Khong tim thay phieu hoc phi can cap nhat.");
                entity.TrangThai = trangThai;
                entity.PhuongThucThanhToan = phuongThuc;
                entity.NgayThanhToan = ngayThanhToan;
                db.SubmitChanges();
            }
        }

        // Tầng dữ liệu thực hiện lấy hóa đơn học phí theo mã thanh toán.
        public HoaDonHocPhiDTO LayHoaDonHocPhi(int maThanhToan)
        {
            using (var db = _factory.Create())
            {
                return BuildHoaDonQuery(db).FirstOrDefault(x => x.MaThanhToan == maThanhToan);
            }
        }

        // Tầng dữ liệu thực hiện lấy hóa đơn học phí theo khoảng ngày.
        public List<HoaDonHocPhiDTO> LayHoaDonHocPhiTheoKhoangNgay(DateTime tuNgay, DateTime denNgay)
        {
            using (var db = _factory.Create())
            {
                var start = tuNgay.Date;
                var end = denNgay.Date.AddDays(1);
                return BuildHoaDonQuery(db)
                    .Where(x => x.NgayTao >= start && x.NgayTao < end)
                    .OrderBy(x => x.NgayTao)
                    .ThenBy(x => x.TenLop)
                    .ToList();
            }
        }

        // Tầng dữ liệu thực hiện lấy báo cáo doanh thu theo khoảng ngày.
        public List<BaoCaoDoanhThuDTO> LayBaoCaoDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            using (var db = _factory.Create())
            {
                var start = tuNgay.Date;
                var end = denNgay.Date.AddDays(1);
                return BuildHoaDonQuery(db)
                    .Where(x => x.NgayTao >= start && x.NgayTao < end)
                    .AsEnumerable()
                    // Gom nhóm dữ liệu để tính toán báo cáo hoặc thống kê.
                    .GroupBy(x => new { Ngay = x.NgayTao.Date, x.MaLopHoc, x.TenLop })
                    .Select(g => new BaoCaoDoanhThuDTO
                    {
                        Ngay = g.Key.Ngay,
                        MaLopHoc = g.Key.MaLopHoc,
                        TenLop = g.Key.TenLop,
                        SoPhieu = g.Count(),
                        SoPhieuDaThanhToan = g.Count(x => AppConstants.PaymentPaidAliases.Contains(x.TrangThai)),
                        TongTienDaThanhToan = g
                            // Lọc theo trạng thái đã chọn trên màn hình.
                            .Where(x => AppConstants.PaymentPaidAliases.Contains(x.TrangThai))
                            .Sum(x => x.SoTienCuoi.HasValue ? x.SoTienCuoi.Value : x.SoTien)
                    })
                    .OrderBy(x => x.Ngay)
                    .ThenBy(x => x.TenLop)
                    .ToList();
            }
        }

        // Tầng dữ liệu thực hiện cập nhật mã hóa đơn học phí.
        public void CapNhatThongTinHoaDon(int maThanhToan, string maHoaDon)
        {
            using (var db = _factory.Create())
            {
                var entity = RequireEntity(
                    db.ThanhToanHocPhis.FirstOrDefault(x => x.MaThanhToan == maThanhToan),
                    "Khong tim thay phieu hoc phi can cap nhat hoa don.");
                entity.MaHoaDon = maHoaDon;
                db.SubmitChanges();
            }
        }

        // Xây dựng truy vấn hoặc diễn giải dữ liệu phục vụ tầng dữ liệu.
        private static IQueryable<PaymentDebugResultDTO> BuildPaymentDebugQuery(QuanLyIeltsDataContext db)
        {
            return
                // Khởi tạo truy vấn nhật ký thanh toán trước khi áp dụng bộ lọc.
                from tx in db.NhatKyThanhToans
                join hp in db.ThanhToanHocPhis on tx.MaThanhToan equals hp.MaThanhToan
                join nd in db.NguoiDungs on hp.MaNguoiDung equals nd.MaNguoiDung
                select new PaymentDebugResultDTO
                {
                    TransactionId = tx.MaGiaoDich,
                    TuitionPaymentId = tx.MaThanhToan,
                    ExternalTransactionRef = tx.MaGiaoDichNgoai,
                    StudentName = tx.DebugStudentName ?? nd.HoTen,
                    ReceiverEmail = tx.ReceiverEmail ?? nd.Email,
                    ClassName = tx.DebugClassName,
                    InvoiceCode = hp.MaHoaDon,
                    Amount = tx.SoTien,
                    PaymentMethod = tx.PhuongThuc,
                    PaymentUrl = tx.PaymentUrl,
                    PaymentStatus = tx.TrangThai,
                    TuitionStatus = hp.TrangThai,
                    PaymentEmailSent = tx.PaymentEmailSent == true,
                    PaymentEmailSentAt = tx.PaymentEmailSentAt,
                    PaymentEmailError = tx.PaymentEmailError,
                    StatusEmailSent = tx.StatusEmailSent == true,
                    StatusEmailSentAt = tx.StatusEmailSentAt,
                    StatusEmailError = tx.StatusEmailError,
                    CreatedAt = tx.NgayTao,
                    UpdatedAt = tx.NgayCapNhat,
                    LastStatusUpdateAt = tx.LastStatusUpdateAt,
                    DebugNote = tx.DebugNote,
                    IsDebugPayment = tx.IsDebugPayment == true
                };
        }

        // Xử lý dữ liệu phụ trợ trước khi kho dữ liệu đọc hoặc ghi cơ sở dữ liệu.
        private static string TrimForColumn(string value, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            value = value.Trim();
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        // Xử lý dữ liệu phụ trợ trước khi kho dữ liệu đọc hoặc ghi cơ sở dữ liệu.
        private static void EnsurePaymentDebugColumns(QuanLyIeltsDataContext db)
        {
            // Thực thi SQL trực tiếp để bổ sung cột kiểm thử thanh toán khi cần.
            db.ExecuteCommand(@"
IF OBJECT_ID(N'dbo.NhatKyThanhToan', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.NhatKyThanhToan', N'ReceiverEmail') IS NULL
BEGIN
    ALTER TABLE dbo.NhatKyThanhToan ADD ReceiverEmail NVARCHAR(150) NULL;
END
IF OBJECT_ID(N'dbo.NhatKyThanhToan', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.NhatKyThanhToan', N'DebugStudentName') IS NULL
BEGIN
    ALTER TABLE dbo.NhatKyThanhToan ADD DebugStudentName NVARCHAR(120) NULL;
END
IF OBJECT_ID(N'dbo.NhatKyThanhToan', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.NhatKyThanhToan', N'DebugClassName') IS NULL
BEGIN
    ALTER TABLE dbo.NhatKyThanhToan ADD DebugClassName NVARCHAR(120) NULL;
END
IF OBJECT_ID(N'dbo.NhatKyThanhToan', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.NhatKyThanhToan', N'DebugNote') IS NULL
BEGIN
    ALTER TABLE dbo.NhatKyThanhToan ADD DebugNote NVARCHAR(500) NULL;
END
IF OBJECT_ID(N'dbo.NhatKyThanhToan', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.NhatKyThanhToan', N'IsDebugPayment') IS NULL
BEGIN
    ALTER TABLE dbo.NhatKyThanhToan ADD IsDebugPayment BIT NULL;
END
IF OBJECT_ID(N'dbo.NhatKyThanhToan', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.NhatKyThanhToan', N'PaymentEmailSent') IS NULL
BEGIN
    ALTER TABLE dbo.NhatKyThanhToan ADD PaymentEmailSent BIT NULL;
END
IF OBJECT_ID(N'dbo.NhatKyThanhToan', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.NhatKyThanhToan', N'PaymentEmailSentAt') IS NULL
BEGIN
    ALTER TABLE dbo.NhatKyThanhToan ADD PaymentEmailSentAt DATETIME NULL;
END
IF OBJECT_ID(N'dbo.NhatKyThanhToan', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.NhatKyThanhToan', N'PaymentEmailError') IS NULL
BEGIN
    ALTER TABLE dbo.NhatKyThanhToan ADD PaymentEmailError NVARCHAR(1000) NULL;
END
IF OBJECT_ID(N'dbo.NhatKyThanhToan', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.NhatKyThanhToan', N'StatusEmailSent') IS NULL
BEGIN
    ALTER TABLE dbo.NhatKyThanhToan ADD StatusEmailSent BIT NULL;
END
IF OBJECT_ID(N'dbo.NhatKyThanhToan', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.NhatKyThanhToan', N'StatusEmailSentAt') IS NULL
BEGIN
    ALTER TABLE dbo.NhatKyThanhToan ADD StatusEmailSentAt DATETIME NULL;
END
IF OBJECT_ID(N'dbo.NhatKyThanhToan', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.NhatKyThanhToan', N'StatusEmailError') IS NULL
BEGIN
    ALTER TABLE dbo.NhatKyThanhToan ADD StatusEmailError NVARCHAR(1000) NULL;
END
IF OBJECT_ID(N'dbo.NhatKyThanhToan', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.NhatKyThanhToan', N'LastStatusUpdateAt') IS NULL
BEGIN
    ALTER TABLE dbo.NhatKyThanhToan ADD LastStatusUpdateAt DATETIME NULL;
END");
        }

        // Xây dựng truy vấn hoặc diễn giải dữ liệu phục vụ tầng dữ liệu.
        private static IQueryable<HoaDonHocPhiDTO> BuildHoaDonQuery(QuanLyIeltsDataContext db)
        {
            return
                // Khởi tạo truy vấn thanh toán học phí trước khi áp dụng bộ lọc.
                from hp in db.ThanhToanHocPhis
                join nd in db.NguoiDungs on hp.MaNguoiDung equals nd.MaNguoiDung
                join lop in db.LopHocs on hp.MaLopHoc equals (int?)lop.MaLopHoc into lopJoin
                from lop in lopJoin.DefaultIfEmpty()
                select new HoaDonHocPhiDTO
                {
                    MaThanhToan = hp.MaThanhToan,
                    MaHoaDon = hp.MaHoaDon,
                    MaNguoiDung = hp.MaNguoiDung,
                    MaLopHoc = hp.MaLopHoc,
                    HoTen = nd.HoTen,
                    TenLop = lop == null ? string.Empty : lop.TenLop,
                    SoTien = hp.SoTien,
                    SoTienGoc = hp.SoTienGoc,
                    PhanTramGiam = hp.PhanTramGiam,
                    SoTienGiam = hp.SoTienGiam,
                    SoTienCuoi = hp.SoTienCuoi,
                    ThongTinNganHang = hp.ThongTinNganHang,
                    NgayTao = hp.NgayTao,
                    HanThanhToan = hp.HanThanhToan,
                    NgayThanhToan = hp.NgayThanhToan,
                    PhuongThucThanhToan = hp.PhuongThucThanhToan,
                    TrangThai = hp.TrangThai
                };
        }

        // Tầng dữ liệu thực hiện lấy số liệu tổng quan màn hình tổng quan.
        public DashboardSummaryDTO GetDashboardSummary(DateTime today)
        {
            using (var db = _factory.Create())
            {
                var start = new DateTime(today.Year, today.Month, 1);
                var end = start.AddMonths(1);
                var paidThisMonth = db.ThanhToanHocPhis
                    // Lọc theo trạng thái đã chọn trên màn hình.
                    .Where(x => AppConstants.PaymentPaidAliases.Contains(x.TrangThai) && x.NgayTao >= start && x.NgayTao < end)
                    .AsEnumerable()
                    .Sum(x => x.SoTienCuoi.HasValue ? x.SoTienCuoi.Value : x.SoTien);

                return new DashboardSummaryDTO
                {
                    TongHocVien = db.NguoiDungs.Count(x => x.VaiTro == AppConstants.RoleStudent),
                    HocVienDangHoc = db.ChiTietLopHocs
                        // Lọc theo trạng thái đã chọn trên màn hình.
                        .Where(x => AppConstants.EnrollmentActiveAliases.Contains(x.TrangThai) && x.NgayNghiHoc == null)
                        .Select(x => x.MaNguoiDung)
                        .Distinct()
                        .Count(),
                    DoanhThuThangNay = paidThisMonth,
                    TongLopHoc = db.LopHocs.Count()
                };
            }
        }

        // Tầng dữ liệu thực hiện lấy doanh thu theo tháng.
        public List<MonthlyRevenueDTO> GetRevenueByMonth(int months, DateTime today)
        {
            using (var db = _factory.Create())
            {
                months = Math.Max(1, months);
                var firstMonth = new DateTime(today.Year, today.Month, 1).AddMonths(-(months - 1));
                var paid = db.ThanhToanHocPhis
                    // Lọc theo trạng thái đã chọn trên màn hình.
                    .Where(x => AppConstants.PaymentPaidAliases.Contains(x.TrangThai) && x.NgayTao >= firstMonth)
                    .AsEnumerable()
                    // Gom nhóm dữ liệu để tính toán báo cáo hoặc thống kê.
                    .GroupBy(x => new { x.NgayTao.Year, x.NgayTao.Month })
                    .ToDictionary(
                        x => x.Key.Year + "-" + x.Key.Month,
                        x => x.Sum(item => item.SoTienCuoi.HasValue ? item.SoTienCuoi.Value : item.SoTien));

                var result = new List<MonthlyRevenueDTO>();
                for (var i = 0; i < months; i++)
                {
                    var month = firstMonth.AddMonths(i);
                    var key = month.Year + "-" + month.Month;
                    decimal total;
                    paid.TryGetValue(key, out total);
                    result.Add(new MonthlyRevenueDTO
                    {
                        Nam = month.Year,
                        Thang = month.Month,
                        Nhan = month.ToString("MM/yyyy"),
                        TongTien = total
                    });
                }

                return result;
            }
        }

        // Tầng dữ liệu thực hiện lấy lịch học trong tuần.
        public List<WeeklyScheduleDTO> GetWeeklySchedule(DateTime weekStart)
        {
            using (var db = _factory.Create())
            {
                var monday = weekStart.Date.AddDays(-(((int)weekStart.DayOfWeek + 6) % 7));
                var result = new List<WeeklyScheduleDTO>();
                foreach (var lop in db.LopHocs.OrderBy(x => x.TenLop).ToList())
                {
                    AddScheduleRows(result, lop, monday);
                }

                return result.OrderBy(x => x.NgayHoc).ThenBy(x => x.TenLop).ToList();
            }
        }

        // Tầng dữ liệu thực hiện lấy dữ liệu báo cáo điểm.
        public List<BaoCaoDiemDTO> GetBaoCaoDiem(int? maLopHoc)
        {
            using (var db = _factory.Create())
            {
                var query =
                    // Khởi tạo truy vấn chi tiết điểm số trước khi áp dụng bộ lọc.
                    from ds in db.ChiTietDiemSos
                    join dot in db.DotKiemTras on ds.MaDotKiemTra equals dot.MaDotKiemTra
                    join lop in db.LopHocs on dot.MaLopHoc equals lop.MaLopHoc
                    join nd in db.NguoiDungs on ds.MaNguoiDung equals nd.MaNguoiDung
                    select new BaoCaoDiemDTO
                    {
                        TenLop = lop.TenLop,
                        HoTen = nd.HoTen,
                        TenDotKiemTra = dot.TenDotKiemTra,
                        DiemTong = ds.DiemTong,
                        NhanXet = ds.NhanXet
                    };

                if (maLopHoc.HasValue && maLopHoc.Value > 0)
                {
                    var lopId = maLopHoc.Value;
                    query =
                        // Khởi tạo truy vấn chi tiết điểm số trước khi áp dụng bộ lọc.
                        from ds in db.ChiTietDiemSos
                        join dot in db.DotKiemTras on ds.MaDotKiemTra equals dot.MaDotKiemTra
                        join lop in db.LopHocs on dot.MaLopHoc equals lop.MaLopHoc
                        join nd in db.NguoiDungs on ds.MaNguoiDung equals nd.MaNguoiDung
                        where dot.MaLopHoc == lopId
                        select new BaoCaoDiemDTO
                        {
                            TenLop = lop.TenLop,
                            HoTen = nd.HoTen,
                            TenDotKiemTra = dot.TenDotKiemTra,
                            DiemTong = ds.DiemTong,
                            NhanXet = ds.NhanXet
                        };
                }

                return query.OrderBy(x => x.TenLop).ThenBy(x => x.HoTen).ThenBy(x => x.TenDotKiemTra).ToList();
            }
        }

        // Tầng dữ liệu thực hiện lấy dữ liệu báo cáo bài tập.
        public List<BaoCaoBaiTapDTO> GetBaoCaoBaiTap(int? maLopHoc)
        {
            using (var db = _factory.Create())
            {
                var lopIds = maLopHoc.HasValue && maLopHoc.Value > 0
                    ? new List<int> { maLopHoc.Value }
                    : db.LopHocs.Select(x => x.MaLopHoc).ToList();
                var result = new List<BaoCaoBaiTapDTO>();

                foreach (var lopId in lopIds)
                {
                    var hocVien = GetHocVienLop(lopId, true);
                    // Giới hạn dữ liệu trong lớp học đang chọn.
                    var baiTap = db.BaiTaps.Where(x => x.MaLopHoc == lopId).ToList();
                    var baiTapIds = baiTap.Select(x => x.MaBaiTap).ToList();
                    var nopBai = db.ChiTietNopBais.Where(x => baiTapIds.Contains(x.MaBaiTap)).ToList();

                    foreach (var bt in baiTap)
                    {
                        foreach (var hv in hocVien)
                        {
                            var nop = nopBai.FirstOrDefault(x => x.MaBaiTap == bt.MaBaiTap && x.MaNguoiDung == hv.MaNguoiDung);
                            result.Add(new BaoCaoBaiTapDTO
                            {
                                HoTen = hv.HoTen,
                                TieuDe = bt.TieuDe,
                                Deadline = bt.Deadline,
                                TrangThaiNop = nop == null ? "Chưa nộp" : nop.TrangThaiNop
                            });
                        }
                    }
                }

                return result.OrderBy(x => x.HoTen).ThenBy(x => x.TieuDe).ToList();
            }
        }

        // Tầng dữ liệu thực hiện lấy dữ liệu báo cáo chuyên cần.
        public List<BaoCaoChuyenCanDTO> GetBaoCaoChuyenCan(int maLopHoc)
        {
            using (var db = _factory.Create())
            {
                var hocVien = GetHocVienLop(maLopHoc, true);
                // Giới hạn dữ liệu trong lớp học đang chọn.
                var buoiIds = db.BuoiHocs.Where(x => x.MaLopHoc == maLopHoc).Select(x => x.MaBuoiHoc).ToList();
                // Giới hạn dữ liệu trong lớp học đang chọn.
                var diemDanh = db.ChiTietDiemDanhs.Where(x => buoiIds.Contains(x.MaBuoiHoc)).ToList();
                var result = new List<BaoCaoChuyenCanDTO>();

                foreach (var hv in hocVien)
                {
                    var soCoMat = diemDanh.Count(x => x.MaNguoiDung == hv.MaNguoiDung
                        && (AppConstants.AttendancePresentAliases.Contains(x.TrangThai) || AppConstants.AttendanceLateAliases.Contains(x.TrangThai)));
                    var soVang = Math.Max(0, buoiIds.Count - soCoMat);
                    result.Add(new BaoCaoChuyenCanDTO
                    {
                        MaNguoiDung = hv.MaNguoiDung,
                        HoTen = hv.HoTen,
                        SoBuoiCoMat = soCoMat,
                        SoBuoiVang = soVang,
                        TiLeChuyenCan = buoiIds.Count == 0 ? 0m : Math.Round(soCoMat * 100m / buoiIds.Count, 2)
                    });
                }

                return result.OrderBy(x => x.HoTen).ToList();
            }
        }

        // Tầng dữ liệu thực hiện lấy dữ liệu báo cáo cuối kỳ.
        public List<BaoCaoCuoiKyDTO> GetBaoCaoCuoiKy(int maLopHoc)
        {
            using (var db = _factory.Create())
            {
                var hocVien = GetHocVienLop(maLopHoc, true);
                // Giới hạn dữ liệu trong lớp học đang chọn.
                var dot = db.DotKiemTras.Where(x => x.MaLopHoc == maLopHoc).OrderBy(x => x.NgayKiemTra).ToList();
                var dotIds = dot.Select(x => x.MaDotKiemTra).ToList();
                var diem = db.ChiTietDiemSos.Where(x => dotIds.Contains(x.MaDotKiemTra)).ToList();
                var result = new List<BaoCaoCuoiKyDTO>();

                foreach (var hv in hocVien)
                {
                    var diemHocVien = diem.Where(x => x.MaNguoiDung == hv.MaNguoiDung && x.DiemTong.HasValue).ToList();
                    decimal? trungBinh = diemHocVien.Count == 0 ? (decimal?)null : Math.Round(diemHocVien.Average(x => x.DiemTong.Value), 2);
                    foreach (var d in dot)
                    {
                        var diemDot = diem.FirstOrDefault(x => x.MaNguoiDung == hv.MaNguoiDung && x.MaDotKiemTra == d.MaDotKiemTra);
                        result.Add(new BaoCaoCuoiKyDTO
                        {
                            HoTen = hv.HoTen,
                            TenDotKiemTra = d.TenDotKiemTra,
                            DiemTong = diemDot == null ? null : diemDot.DiemTong,
                            DiemTrungBinh = trungBinh,
                            NhanXet = diemDot == null ? string.Empty : diemDot.NhanXet
                        });
                    }
                }

                return result.OrderBy(x => x.HoTen).ThenBy(x => x.TenDotKiemTra).ToList();
            }
        }

        // Trả về thực thể bắt buộc hoặc ném lỗi rõ ràng khi không tìm thấy dữ liệu.
        public void GhiNhatKyBaoCao(int maNguoiDung, string loaiBaoCao, string tieuChi)
        {
            using (var db = _factory.Create())
            {
                db.NhatKyBaoCaos.InsertOnSubmit(new NhatKyBaoCaoEntity
                {
                    MaNguoiDung = maNguoiDung,
                    LoaiBaoCao = loaiBaoCao,
                    TieuChi = tieuChi,
                    ThoiGianTao = DateTime.Now
                });
                db.SubmitChanges();
            }
        }

        // Xử lý dữ liệu phụ trợ trước khi kho dữ liệu đọc hoặc ghi cơ sở dữ liệu.
        private static void AddScheduleRows(List<WeeklyScheduleDTO> result, LopHocEntity lop, DateTime monday)
        {
            var labels = new[] { "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7", "Chủ nhật" };
            var matched = false;
            var lichHoc = lop.LichHoc ?? string.Empty;

            for (var i = 0; i < labels.Length; i++)
            {
                if (lichHoc.IndexOf(labels[i], StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    matched = true;
                    result.Add(new WeeklyScheduleDTO
                    {
                        MaLopHoc = lop.MaLopHoc,
                        TenLop = lop.TenLop,
                        LichHoc = lop.LichHoc,
                        NgayHoc = monday.AddDays(i),
                        ThuTrongTuan = labels[i]
                    });
                }
            }

            if (!matched)
            {
                result.Add(new WeeklyScheduleDTO
                {
                    MaLopHoc = lop.MaLopHoc,
                    TenLop = lop.TenLop,
                    LichHoc = lop.LichHoc,
                    NgayHoc = monday,
                    ThuTrongTuan = "Chưa rõ"
                });
            }
        }
    }
}
