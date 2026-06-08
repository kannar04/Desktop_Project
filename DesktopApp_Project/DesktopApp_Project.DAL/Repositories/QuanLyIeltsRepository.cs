using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.DAL
{
    public class QuanLyIeltsRepository : IQuanLyIeltsRepository
    {
        private readonly IDataContextFactory _factory;

        public QuanLyIeltsRepository(IDataContextFactory factory)
        {
            _factory = factory;
        }

        private static T RequireEntity<T>(T entity, string message) where T : class
        {
            if (entity == null)
            {
                throw new InvalidOperationException(message);
            }

            return entity;
        }

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

        public NguoiDungDTO GetNguoiDungByTaiKhoan(string taiKhoan)
        {
            using (var db = _factory.Create())
            {
                var entity = db.NguoiDungs.FirstOrDefault(x => x.TaiKhoan == taiKhoan);
                return DtoMapper.ToDto(entity);
            }
        }

        public NguoiDungDTO GetNguoiDungById(int maNguoiDung)
        {
            using (var db = _factory.Create())
            {
                return DtoMapper.ToDto(db.NguoiDungs.FirstOrDefault(x => x.MaNguoiDung == maNguoiDung));
            }
        }

        public List<NguoiDungDTO> GetNguoiDungByVaiTro(string vaiTro)
        {
            using (var db = _factory.Create())
            {
                return db.NguoiDungs
                    .Where(x => x.VaiTro == vaiTro)
                    .OrderBy(x => x.HoTen)
                    .AsEnumerable()
                    .Select(DtoMapper.ToDto)
                    .ToList();
            }
        }

        public List<NguoiDungDTO> SearchHocVien(string keyword)
        {
            using (var db = _factory.Create())
            {
                var query = db.NguoiDungs.Where(x => x.VaiTro == AppConstants.RoleStudent);
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    query = query.Where(x => x.HoTen.Contains(keyword) || x.TaiKhoan.Contains(keyword) || x.Email.Contains(keyword));
                }

                return query.OrderBy(x => x.HoTen).AsEnumerable().Select(DtoMapper.ToDto).ToList();
            }
        }

        public List<NguoiDungDTO> SearchHocVien(HocVienSearchCriteriaDTO criteria)
        {
            using (var db = _factory.Create())
            {
                criteria = criteria ?? new HocVienSearchCriteriaDTO();
                var query = db.NguoiDungs.Where(x => x.VaiTro == AppConstants.RoleStudent);

                if (!string.IsNullOrWhiteSpace(criteria.HoTen))
                {
                    var keyword = criteria.HoTen.Trim();
                    query = query.Where(x => x.HoTen.Contains(keyword));
                }

                if (!string.IsNullOrWhiteSpace(criteria.LienHe))
                {
                    var lienHe = criteria.LienHe.Trim();
                    query = query.Where(x => x.SDT.Contains(lienHe) || x.Email.Contains(lienHe));
                }

                if (criteria.MaLopHoc.HasValue && criteria.MaLopHoc.Value > 0)
                {
                    var maLopHoc = criteria.MaLopHoc.Value;
                    query = query.Where(x => db.ChiTietLopHocs.Any(ct => ct.MaNguoiDung == x.MaNguoiDung && ct.MaLopHoc == maLopHoc));
                }

                if (!string.IsNullOrWhiteSpace(criteria.TrangThai) && criteria.TrangThai != AppConstants.FilterAll)
                {
                    var trangThai = criteria.TrangThai.Trim();
                    if (criteria.MaLopHoc.HasValue && criteria.MaLopHoc.Value > 0)
                    {
                        var maLopHoc = criteria.MaLopHoc.Value;
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

        public bool ExistsTaiKhoan(string taiKhoan, int exceptId)
        {
            using (var db = _factory.Create())
            {
                return db.NguoiDungs.Any(x => x.TaiKhoan == taiKhoan && x.MaNguoiDung != exceptId);
            }
        }

        public bool ExistsEmail(string email, int exceptId)
        {
            using (var db = _factory.Create())
            {
                return db.NguoiDungs.Any(x => x.Email == email && x.MaNguoiDung != exceptId);
            }
        }

        public List<LopHocDTO> GetLopHoc()
        {
            using (var db = _factory.Create())
            {
                return db.LopHocs.OrderBy(x => x.TenLop).AsEnumerable().Select(DtoMapper.ToDto).ToList();
            }
        }

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

        public bool ExistsTenLop(string tenLop, int exceptId)
        {
            using (var db = _factory.Create())
            {
                return db.LopHocs.Any(x => x.TenLop == tenLop && x.MaLopHoc != exceptId);
            }
        }

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

        public List<NguoiDungDTO> GetHocVienTrongLop(int maLopHoc)
        {
            using (var db = _factory.Create())
            {
                var query =
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

        public List<HocVienLopDTO> GetHocVienLop(int maLopHoc, bool onlyActive)
        {
            using (var db = _factory.Create())
            {
                var query =
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

        public void ChuyenHocVienSangLop(int maNguoiDung, int maLopHoc)
        {
            using (var db = _factory.Create())
            {
                MoveActiveEnrollment(db, maNguoiDung, maLopHoc);
                db.SubmitChanges();
            }
        }

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

        private static void MoveActiveEnrollment(QuanLyIeltsDataContext db, int maNguoiDung, int maLopHoc)
        {
            var today = DateTime.Today;
            var activeRows = db.ChiTietLopHocs
                .Where(x => x.MaNguoiDung == maNguoiDung
                            && AppConstants.EnrollmentActiveAliases.Contains(x.TrangThai)
                            && x.NgayNghiHoc == null)
                .ToList();

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

        public List<TaiLieuDTO> GetTaiLieu(int? maLopHoc)
        {
            using (var db = _factory.Create())
            {
                var query = db.TaiLieus.AsQueryable();
                if (maLopHoc.HasValue)
                {
                    query = query.Where(x => x.MaLopHoc == maLopHoc.Value);
                }

                return query.OrderByDescending(x => x.NgayCapNhat).AsEnumerable().Select(DtoMapper.ToDto).ToList();
            }
        }

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

        public List<BaiTapDTO> GetBaiTap(int? maLopHoc)
        {
            using (var db = _factory.Create())
            {
                var query = db.BaiTaps.AsQueryable();
                if (maLopHoc.HasValue)
                {
                    query = query.Where(x => x.MaLopHoc == maLopHoc.Value);
                }

                return query.OrderByDescending(x => x.Deadline).AsEnumerable().Select(DtoMapper.ToDto).ToList();
            }
        }

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

        public void TaoChiTietNopBaiChoLop(int maBaiTap, int maLopHoc)
        {
            using (var db = _factory.Create())
            {
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

        public List<NopBaiDTO> GetNopBaiTheoBaiTap(int maBaiTap)
        {
            using (var db = _factory.Create())
            {
                var query =
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

        public List<BuoiHocDTO> GetBuoiHoc(int maLopHoc)
        {
            using (var db = _factory.Create())
            {
                return db.BuoiHocs.Where(x => x.MaLopHoc == maLopHoc)
                    .OrderByDescending(x => x.NgayHoc)
                    .AsEnumerable()
                    .Select(DtoMapper.ToDto)
                    .ToList();
            }
        }

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

        public List<DiemDanhDTO> GetDiemDanh(int maBuoiHoc)
        {
            using (var db = _factory.Create())
            {
                var query =
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

        public decimal TinhTiLeChuyenCan(int maNguoiDung, int maLopHoc, int? thang = null, int? nam = null)
        {
            using (var db = _factory.Create())
            {
                var chiTietLop = db.ChiTietLopHocs
                    .Where(x => x.MaNguoiDung == maNguoiDung && x.MaLopHoc == maLopHoc)
                    .OrderByDescending(x => x.NgayVaoLop)
                    .FirstOrDefault();
                if (chiTietLop == null)
                {
                    return 0m;
                }

                var ngayVaoLop = chiTietLop.NgayVaoLop.Date;
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

        public List<DeThiDTO> GetDeThi()
        {
            using (var db = _factory.Create())
            {
                return db.DeThis.OrderByDescending(x => x.NgayTao).AsEnumerable().Select(DtoMapper.ToDto).ToList();
            }
        }

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

        public List<ReadingPassageDTO> GetReadingPassages(decimal? bandTu, decimal? bandDen)
        {
            using (var db = _factory.Create())
            {
                var query = db.ReadingPassages.AsQueryable();
                if (bandTu.HasValue)
                {
                    query = query.Where(x => !x.BandLevel.HasValue || x.BandLevel.Value >= bandTu.Value);
                }

                if (bandDen.HasValue)
                {
                    query = query.Where(x => !x.BandLevel.HasValue || x.BandLevel.Value <= bandDen.Value);
                }

                var questionCounts = db.CauHois
                    .Where(x => x.PassageId.HasValue)
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

        public ReadingPassageDTO GetReadingPassageById(int maPassage)
        {
            using (var db = _factory.Create())
            {
                return DtoMapper.ToDto(db.ReadingPassages.FirstOrDefault(x => x.PassageId == maPassage));
            }
        }

        public List<ListeningSectionDTO> GetListeningSections(decimal? bandTu, decimal? bandDen)
        {
            using (var db = _factory.Create())
            {
                var query = db.ListeningSections.AsQueryable();
                if (bandTu.HasValue)
                {
                    query = query.Where(x => !x.BandLevel.HasValue || x.BandLevel.Value >= bandTu.Value);
                }

                if (bandDen.HasValue)
                {
                    query = query.Where(x => !x.BandLevel.HasValue || x.BandLevel.Value <= bandDen.Value);
                }

                var questionCounts = db.CauHois
                    .Where(x => x.SectionId.HasValue)
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

        public ListeningSectionDTO GetListeningSectionById(int maSection)
        {
            using (var db = _factory.Create())
            {
                return DtoMapper.ToDto(db.ListeningSections.FirstOrDefault(x => x.SectionId == maSection));
            }
        }

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

        public List<CauHoiDTO> GetCauHoi(string keyword)
        {
            using (var db = _factory.Create())
            {
                var query = db.CauHois.AsQueryable();
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    query = query.Where(x => x.NoiDung.Contains(keyword) || x.NhanKyNang.Contains(keyword) || x.QuestionType.Contains(keyword));
                }

                return query.OrderBy(x => x.NhanKyNang).AsEnumerable().Select(x => FillQuestionGroupTitle(DtoMapper.ToDto(x), db)).ToList();
            }
        }

        public List<CauHoiDTO> SearchCauHoi(CauHoiSearchCriteriaDTO criteria)
        {
            using (var db = _factory.Create())
            {
                criteria = criteria ?? new CauHoiSearchCriteriaDTO();
                var query = db.CauHois.AsQueryable();

                if (!string.IsNullOrWhiteSpace(criteria.NhanKyNang) && criteria.NhanKyNang != AppConstants.FilterAll)
                {
                    var skill = criteria.NhanKyNang.Trim();
                    query = query.Where(x => x.NhanKyNang == skill);
                }

                if (criteria.BandTu.HasValue)
                {
                    query = query.Where(x => x.BandLevel.HasValue && x.BandLevel.Value >= criteria.BandTu.Value);
                }

                if (criteria.BandDen.HasValue)
                {
                    query = query.Where(x => x.BandLevel.HasValue && x.BandLevel.Value <= criteria.BandDen.Value);
                }

                if (!string.IsNullOrWhiteSpace(criteria.Keyword))
                {
                    var keyword = criteria.Keyword.Trim();
                    query = query.Where(x => x.NoiDung.Contains(keyword) || x.DapAn.Contains(keyword) || x.QuestionType.Contains(keyword) || x.AnswerKey.Contains(keyword));
                }

                return query.OrderBy(x => x.NhanKyNang)
                    .ThenBy(x => x.BandLevel)
                    .AsEnumerable()
                    .Select(x => FillQuestionGroupTitle(DtoMapper.ToDto(x), db))
                    .ToList();
            }
        }

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

        public void InsertCauHoiBulk(IEnumerable<CauHoiDTO> danhSach)
        {
            using (var db = _factory.Create())
            {
                db.CauHois.InsertAllOnSubmit((danhSach ?? new List<CauHoiDTO>()).Select(ToCauHoiEntity));
                db.SubmitChanges();
            }
        }

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

        public void ThemCauHoiVaoDeThi(int maDeThi, int maCauHoi)
        {
            ThemCauHoiVaoDeThi(maDeThi, maCauHoi, null, null, null);
        }

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

        public bool ExistsQuestionInExam(int maDeThi, int maCauHoi)
        {
            using (var db = _factory.Create())
            {
                return db.ChiTietDeThis.Any(x => x.MaDeThi == maDeThi && x.MaCauHoi == maCauHoi);
            }
        }

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

        public List<IeltsExamItemDTO> GetNoiDungDeThi(int maDeThi)
        {
            using (var db = _factory.Create())
            {
                var query =
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

        public List<DotKiemTraDTO> GetDotKiemTra(int maLopHoc)
        {
            using (var db = _factory.Create())
            {
                return db.DotKiemTras.Where(x => x.MaLopHoc == maLopHoc)
                    .OrderByDescending(x => x.NgayKiemTra)
                    .AsEnumerable()
                    .Select(DtoMapper.ToDto)
                    .ToList();
            }
        }

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

        public List<DiemSoDTO> GetDiemSo(int maDotKiemTra)
        {
            using (var db = _factory.Create())
            {
                var query =
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

        public bool ExistsDiemSo(int maNguoiDung, int maDotKiemTra)
        {
            using (var db = _factory.Create())
            {
                return db.ChiTietDiemSos.Any(x => x.MaNguoiDung == maNguoiDung && x.MaDotKiemTra == maDotKiemTra);
            }
        }

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

        public List<TuVungDTO> GetTuVung(int? maLopHoc)
        {
            using (var db = _factory.Create())
            {
                var query = db.TuVungs.AsQueryable();
                if (maLopHoc.HasValue)
                {
                    query = query.Where(x => x.MaLopHoc == maLopHoc.Value);
                }

                return query.OrderBy(x => x.TuTiengAnh).AsEnumerable().Select(DtoMapper.ToDto).ToList();
            }
        }

        public List<TuVungDTO> SearchTuVung(TuVungSearchCriteriaDTO criteria)
        {
            using (var db = _factory.Create())
            {
                criteria = criteria ?? new TuVungSearchCriteriaDTO();
                var query = db.TuVungs.AsQueryable();

                if (criteria.MaLopHoc.HasValue && criteria.MaLopHoc.Value > 0)
                {
                    query = query.Where(x => x.MaLopHoc == criteria.MaLopHoc.Value);
                }

                if (!string.IsNullOrWhiteSpace(criteria.Keyword))
                {
                    var keyword = criteria.Keyword.Trim();
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
                    query = query.Where(x => x.CapDo == capDo);
                }

                if (!string.IsNullOrWhiteSpace(criteria.ChuDe) && criteria.ChuDe != AppConstants.FilterAll)
                {
                    var chuDe = criteria.ChuDe.Trim();
                    query = query.Where(x => x.ChuDe == chuDe);
                }

                if (!string.IsNullOrWhiteSpace(criteria.ChuCaiDau) && criteria.ChuCaiDau != AppConstants.FilterAll)
                {
                    var chuCaiDau = criteria.ChuCaiDau.Trim();
                    query = query.Where(x => x.TuTiengAnh.StartsWith(chuCaiDau));
                }

                return query.OrderBy(x => x.TuTiengAnh).AsEnumerable().Select(DtoMapper.ToDto).ToList();
            }
        }

        public bool ExistsTuVungTrongLop(string tuTiengAnh, int maLopHoc, int exceptId)
        {
            using (var db = _factory.Create())
            {
                return db.TuVungs.Any(x => x.MaLopHoc == maLopHoc && x.TuTiengAnh == tuTiengAnh && x.MaTuVung != exceptId);
            }
        }

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

        public void DongBoFlashcardChoLop(int maTuVung, int maLopHoc)
        {
            using (var db = _factory.Create())
            {
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

        public List<ThongBaoDTO> GetThongBao()
        {
            using (var db = _factory.Create())
            {
                return db.ThongBaos.OrderByDescending(x => x.ThoiGianGui).AsEnumerable().Select(DtoMapper.ToDto).ToList();
            }
        }

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

        public List<ThanhToanHocPhiDTO> GetHocPhi()
        {
            return GetHocPhi(null, null, null);
        }

        public List<ThanhToanHocPhiDTO> GetHocPhi(int? maLopHoc, DateTime? tuNgay, DateTime? denNgay)
        {
            using (var db = _factory.Create())
            {
                var query =
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
                    query = query.Where(x => x.MaLopHoc == maLopHoc.Value);
                }

                if (tuNgay.HasValue)
                {
                    query = query.Where(x => x.NgayTao >= tuNgay.Value.Date);
                }

                if (denNgay.HasValue)
                {
                    var den = denNgay.Value.Date.AddDays(1);
                    query = query.Where(x => x.NgayTao < den);
                }

                return query.OrderByDescending(x => x.HanThanhToan).ToList();
            }
        }

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

        public PaymentResultDTO LayGiaoDichThanhToan(int maGiaoDich)
        {
            using (var db = _factory.Create())
            {
                EnsurePaymentDebugColumns(db);
                return DtoMapper.ToDto(db.NhatKyThanhToans.FirstOrDefault(x => x.MaGiaoDich == maGiaoDich));
            }
        }

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

        public PaymentDebugResultDTO LayChiTietGiaoDichDebug(int maGiaoDich)
        {
            using (var db = _factory.Create())
            {
                EnsurePaymentDebugColumns(db);
                return BuildPaymentDebugQuery(db).FirstOrDefault(x => x.TransactionId == maGiaoDich);
            }
        }

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

        public HoaDonHocPhiDTO LayHoaDonHocPhi(int maThanhToan)
        {
            using (var db = _factory.Create())
            {
                return BuildHoaDonQuery(db).FirstOrDefault(x => x.MaThanhToan == maThanhToan);
            }
        }

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

        public List<BaoCaoDoanhThuDTO> LayBaoCaoDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            using (var db = _factory.Create())
            {
                var start = tuNgay.Date;
                var end = denNgay.Date.AddDays(1);
                return BuildHoaDonQuery(db)
                    .Where(x => x.NgayTao >= start && x.NgayTao < end)
                    .AsEnumerable()
                    .GroupBy(x => new { Ngay = x.NgayTao.Date, x.MaLopHoc, x.TenLop })
                    .Select(g => new BaoCaoDoanhThuDTO
                    {
                        Ngay = g.Key.Ngay,
                        MaLopHoc = g.Key.MaLopHoc,
                        TenLop = g.Key.TenLop,
                        SoPhieu = g.Count(),
                        SoPhieuDaThanhToan = g.Count(x => AppConstants.PaymentPaidAliases.Contains(x.TrangThai)),
                        TongTienDaThanhToan = g
                            .Where(x => AppConstants.PaymentPaidAliases.Contains(x.TrangThai))
                            .Sum(x => x.SoTienCuoi.HasValue ? x.SoTienCuoi.Value : x.SoTien)
                    })
                    .OrderBy(x => x.Ngay)
                    .ThenBy(x => x.TenLop)
                    .ToList();
            }
        }

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

        private static IQueryable<PaymentDebugResultDTO> BuildPaymentDebugQuery(QuanLyIeltsDataContext db)
        {
            return
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

        private static string TrimForColumn(string value, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            value = value.Trim();
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        private static void EnsurePaymentDebugColumns(QuanLyIeltsDataContext db)
        {
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

        private static IQueryable<HoaDonHocPhiDTO> BuildHoaDonQuery(QuanLyIeltsDataContext db)
        {
            return
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

        public DashboardSummaryDTO GetDashboardSummary(DateTime today)
        {
            using (var db = _factory.Create())
            {
                var start = new DateTime(today.Year, today.Month, 1);
                var end = start.AddMonths(1);
                var paidThisMonth = db.ThanhToanHocPhis
                    .Where(x => AppConstants.PaymentPaidAliases.Contains(x.TrangThai) && x.NgayTao >= start && x.NgayTao < end)
                    .AsEnumerable()
                    .Sum(x => x.SoTienCuoi.HasValue ? x.SoTienCuoi.Value : x.SoTien);

                return new DashboardSummaryDTO
                {
                    TongHocVien = db.NguoiDungs.Count(x => x.VaiTro == AppConstants.RoleStudent),
                    HocVienDangHoc = db.ChiTietLopHocs
                        .Where(x => AppConstants.EnrollmentActiveAliases.Contains(x.TrangThai) && x.NgayNghiHoc == null)
                        .Select(x => x.MaNguoiDung)
                        .Distinct()
                        .Count(),
                    DoanhThuThangNay = paidThisMonth,
                    TongLopHoc = db.LopHocs.Count()
                };
            }
        }

        public List<MonthlyRevenueDTO> GetRevenueByMonth(int months, DateTime today)
        {
            using (var db = _factory.Create())
            {
                months = Math.Max(1, months);
                var firstMonth = new DateTime(today.Year, today.Month, 1).AddMonths(-(months - 1));
                var paid = db.ThanhToanHocPhis
                    .Where(x => AppConstants.PaymentPaidAliases.Contains(x.TrangThai) && x.NgayTao >= firstMonth)
                    .AsEnumerable()
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

        public List<BaoCaoDiemDTO> GetBaoCaoDiem(int? maLopHoc)
        {
            using (var db = _factory.Create())
            {
                var query =
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

        public List<BaoCaoChuyenCanDTO> GetBaoCaoChuyenCan(int maLopHoc)
        {
            using (var db = _factory.Create())
            {
                var hocVien = GetHocVienLop(maLopHoc, true);
                var buoiIds = db.BuoiHocs.Where(x => x.MaLopHoc == maLopHoc).Select(x => x.MaBuoiHoc).ToList();
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

        public List<BaoCaoCuoiKyDTO> GetBaoCaoCuoiKy(int maLopHoc)
        {
            using (var db = _factory.Create())
            {
                var hocVien = GetHocVienLop(maLopHoc, true);
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
