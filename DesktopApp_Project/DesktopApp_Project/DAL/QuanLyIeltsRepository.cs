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
                    db.ChiTietLopHocs.InsertOnSubmit(new ChiTietLopHocEntity { MaNguoiDung = maNguoiDung, MaLopHoc = maLopHoc });
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

        public decimal TinhTiLeChuyenCan(int maNguoiDung, int maLopHoc)
        {
            using (var db = _factory.Create())
            {
                var buoiIds = db.BuoiHocs.Where(x => x.MaLopHoc == maLopHoc).Select(x => x.MaBuoiHoc).ToList();
                if (buoiIds.Count == 0)
                {
                    return 0m;
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

        public int InsertCauHoi(CauHoiDTO dto)
        {
            using (var db = _factory.Create())
            {
                var entity = new CauHoiEntity { NoiDung = dto.NoiDung, DapAn = dto.DapAn, NhanKyNang = dto.NhanKyNang };
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
                    Nghia = dto.Nghia
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
            using (var db = _factory.Create())
            {
                var query =
                    from hp in db.ThanhToanHocPhis
                    join nd in db.NguoiDungs on hp.MaNguoiDung equals nd.MaNguoiDung
                    orderby hp.HanThanhToan descending
                    select new ThanhToanHocPhiDTO
                    {
                        MaThanhToan = hp.MaThanhToan,
                        MaNguoiDung = hp.MaNguoiDung,
                        HoTen = nd.HoTen,
                        SoTien = hp.SoTien,
                        ThongTinNganHang = hp.ThongTinNganHang,
                        NgayTao = hp.NgayTao,
                        HanThanhToan = hp.HanThanhToan,
                        TrangThai = hp.TrangThai
                    };

                return query.ToList();
            }
        }

        public int InsertHocPhi(ThanhToanHocPhiDTO dto)
        {
            using (var db = _factory.Create())
            {
                var entity = new ThanhToanHocPhiEntity
                {
                    MaNguoiDung = dto.MaNguoiDung,
                    SoTien = dto.SoTien,
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

        public void UpdateTrangThaiHocPhi(int maThanhToan, string trangThai)
        {
            using (var db = _factory.Create())
            {
                var entity = db.ThanhToanHocPhis.First(x => x.MaThanhToan == maThanhToan);
                entity.TrangThai = trangThai;
                db.SubmitChanges();
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
    }
}
