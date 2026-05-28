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
                            && ct.TrangThai == trangThai));
                    }
                    else
                    {
                        query = query.Where(x => db.ChiTietLopHocs.Any(ct =>
                            ct.MaNguoiDung == x.MaNguoiDung
                            && ct.TrangThai == trangThai));
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
                var entity = db.NguoiDungs.First(x => x.MaNguoiDung == dto.MaNguoiDung);
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
                var entity = db.NguoiDungs.First(x => x.MaNguoiDung == maNguoiDung);
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
                var entity = db.LopHocs.First(x => x.MaLopHoc == dto.MaLopHoc);
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
                var entity = db.LopHocs.First(x => x.MaLopHoc == maLopHoc);
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
                    query = query.Where(x => x.ct.TrangThai == AppConstants.EnrollmentActive && x.ct.NgayNghiHoc == null);
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
                    DangHoc = x.ct.TrangThai == AppConstants.EnrollmentActive && !x.ct.NgayNghiHoc.HasValue
                }).OrderBy(x => x.HoTen).ToList();
            }
        }

        public List<NguoiDungDTO> GetHocVienChuaTrongLop(int maLopHoc)
        {
            using (var db = _factory.Create())
            {
                var query =
                    from nd in db.NguoiDungs
                    where nd.VaiTro == AppConstants.RoleStudent
                          && !db.ChiTietLopHocs.Any(ct => ct.MaNguoiDung == nd.MaNguoiDung && ct.MaLopHoc == maLopHoc)
                    orderby nd.HoTen
                    select nd;

                return query.AsEnumerable().Select(DtoMapper.ToDto).ToList();
            }
        }

        public void ThemHocVienVaoLop(int maNguoiDung, int maLopHoc)
        {
            using (var db = _factory.Create())
            {
                if (!db.ChiTietLopHocs.Any(x => x.MaNguoiDung == maNguoiDung && x.MaLopHoc == maLopHoc))
                {
                    db.ChiTietLopHocs.InsertOnSubmit(new ChiTietLopHocEntity
                    {
                        MaNguoiDung = maNguoiDung,
                        MaLopHoc = maLopHoc,
                        NgayVaoLop = DateTime.Today,
                        TrangThai = AppConstants.EnrollmentActive
                    });
                    db.SubmitChanges();
                }
            }
        }

        public void XoaHocVienKhoiLop(int maNguoiDung, int maLopHoc)
        {
            using (var db = _factory.Create())
            {
                var entity = db.ChiTietLopHocs.FirstOrDefault(x => x.MaNguoiDung == maNguoiDung && x.MaLopHoc == maLopHoc);
                if (entity != null)
                {
                    db.ChiTietLopHocs.DeleteOnSubmit(entity);
                    db.SubmitChanges();
                }
            }
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
                    NhanKyNang = dto.NhanKyNang,
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
                var entity = db.TaiLieus.First(x => x.MaTaiLieu == dto.MaTaiLieu);
                entity.MaLopHoc = dto.MaLopHoc;
                entity.TenChuDe = dto.TenChuDe;
                entity.NoiDungMoTa = dto.NoiDungMoTa;
                entity.DuongDanFile = dto.DuongDanFile;
                entity.VideoLink = dto.VideoLink;
                entity.NhanKyNang = dto.NhanKyNang;
                entity.NgayCapNhat = DateTime.Now;
                db.SubmitChanges();
            }
        }

        public void DeleteTaiLieu(int maTaiLieu)
        {
            using (var db = _factory.Create())
            {
                var entity = db.TaiLieus.First(x => x.MaTaiLieu == maTaiLieu);
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
                var entity = db.BaiTaps.First(x => x.MaBaiTap == dto.MaBaiTap);
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
                var entity = db.BaiTaps.First(x => x.MaBaiTap == maBaiTap);
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
                var entity = db.ChiTietNopBais.First(x => x.MaNguoiDung == dto.MaNguoiDung && x.MaBaiTap == dto.MaBaiTap);
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
                        CoMat = dd.TrangThai == AppConstants.AttendancePresent || dd.TrangThai == AppConstants.AttendanceLate,
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

        public decimal TinhTiLeChuyenCan(int maNguoiDung, int maLopHoc)
        {
            using (var db = _factory.Create())
            {
                var buoiIds = db.BuoiHocs.Where(x => x.MaLopHoc == maLopHoc).Select(x => x.MaBuoiHoc).ToList();
                if (buoiIds.Count == 0)
                {
                    return 0m;
                }

                var soBuoiCoMatTheoHangSo = db.ChiTietDiemDanhs.Count(x =>
                    x.MaNguoiDung == maNguoiDung
                    && buoiIds.Contains(x.MaBuoiHoc)
                    && (x.TrangThai == AppConstants.AttendancePresent || x.TrangThai == AppConstants.AttendanceLate));
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
                var entity = new DeThiEntity { TenDeThi = dto.TenDeThi, FileDuLieu = dto.FileDuLieu, NgayTao = DateTime.Now };
                db.DeThis.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.MaDeThi;
            }
        }

        public List<CauHoiDTO> GetCauHoi(string keyword)
        {
            using (var db = _factory.Create())
            {
                var query = db.CauHois.AsQueryable();
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    query = query.Where(x => x.NoiDung.Contains(keyword) || x.NhanKyNang.Contains(keyword));
                }

                return query.OrderBy(x => x.NhanKyNang).AsEnumerable().Select(DtoMapper.ToDto).ToList();
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
                    query = query.Where(x => x.NoiDung.Contains(keyword) || x.DapAn.Contains(keyword));
                }

                return query.OrderBy(x => x.NhanKyNang)
                    .ThenBy(x => x.BandLevel)
                    .AsEnumerable()
                    .Select(DtoMapper.ToDto)
                    .ToList();
            }
        }

        public int InsertCauHoi(CauHoiDTO dto)
        {
            using (var db = _factory.Create())
            {
                var entity = new CauHoiEntity { NoiDung = dto.NoiDung, DapAn = dto.DapAn, NhanKyNang = dto.NhanKyNang, BandLevel = dto.BandLevel };
                db.CauHois.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.MaCauHoi;
            }
        }

        public void UpdateCauHoi(CauHoiDTO dto)
        {
            using (var db = _factory.Create())
            {
                var entity = db.CauHois.First(x => x.MaCauHoi == dto.MaCauHoi);
                entity.NoiDung = dto.NoiDung;
                entity.DapAn = dto.DapAn;
                entity.NhanKyNang = dto.NhanKyNang;
                entity.BandLevel = dto.BandLevel;
                db.SubmitChanges();
            }
        }

        public void DeleteCauHoi(int maCauHoi)
        {
            using (var db = _factory.Create())
            {
                var entity = db.CauHois.First(x => x.MaCauHoi == maCauHoi);
                db.CauHois.DeleteOnSubmit(entity);
                db.SubmitChanges();
            }
        }

        public void ThemCauHoiVaoDeThi(int maDeThi, int maCauHoi)
        {
            using (var db = _factory.Create())
            {
                if (!db.ChiTietDeThis.Any(x => x.MaDeThi == maDeThi && x.MaCauHoi == maCauHoi))
                {
                    db.ChiTietDeThis.InsertOnSubmit(new ChiTietDeThiEntity { MaDeThi = maDeThi, MaCauHoi = maCauHoi });
                    db.SubmitChanges();
                }
            }
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
                var entity = db.TuVungs.First(x => x.MaTuVung == dto.MaTuVung);
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
                var entity = db.TuVungs.First(x => x.MaTuVung == maTuVung);
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
                var entity = db.ThanhToanHocPhis.First(x => x.MaThanhToan == maThanhToan);
                entity.TrangThai = trangThai;
                db.SubmitChanges();
            }
        }

        public DashboardSummaryDTO GetDashboardSummary(DateTime today)
        {
            using (var db = _factory.Create())
            {
                var start = new DateTime(today.Year, today.Month, 1);
                var end = start.AddMonths(1);
                var paidThisMonth = db.ThanhToanHocPhis
                    .Where(x => x.TrangThai == AppConstants.PaymentPaid && x.NgayTao >= start && x.NgayTao < end)
                    .AsEnumerable()
                    .Sum(x => x.SoTienCuoi.HasValue ? x.SoTienCuoi.Value : x.SoTien);

                return new DashboardSummaryDTO
                {
                    TongHocVien = db.NguoiDungs.Count(x => x.VaiTro == AppConstants.RoleStudent),
                    HocVienDangHoc = db.ChiTietLopHocs
                        .Where(x => x.TrangThai == AppConstants.EnrollmentActive && x.NgayNghiHoc == null)
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
                    .Where(x => x.TrangThai == AppConstants.PaymentPaid && x.NgayTao >= firstMonth)
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
                        && (x.TrangThai == AppConstants.AttendancePresent || x.TrangThai == AppConstants.AttendanceLate));
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
