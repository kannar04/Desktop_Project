-- DEV-ONLY DESTRUCTIVE RESET SCRIPT.
-- This script drops and recreates tables for the local QuanLyLopIELTS development database.
-- Do not run against production or any database that contains data you need to keep.

IF DB_ID(N'QuanLyLopIELTS') IS NULL
BEGIN
    CREATE DATABASE QuanLyLopIELTS;
END
GO

USE QuanLyLopIELTS;
GO

IF OBJECT_ID(N'dbo.ChiTiet_ThongBao', N'U') IS NOT NULL DROP TABLE dbo.ChiTiet_ThongBao;
IF OBJECT_ID(N'dbo.ThongBao', N'U') IS NOT NULL DROP TABLE dbo.ThongBao;
IF OBJECT_ID(N'dbo.ThanhToanHocPhi', N'U') IS NOT NULL DROP TABLE dbo.ThanhToanHocPhi;
IF OBJECT_ID(N'dbo.NhatKyBaoCao', N'U') IS NOT NULL DROP TABLE dbo.NhatKyBaoCao;
IF OBJECT_ID(N'dbo.TienTrinh_Flashcard', N'U') IS NOT NULL DROP TABLE dbo.TienTrinh_Flashcard;
IF OBJECT_ID(N'dbo.TuVung', N'U') IS NOT NULL DROP TABLE dbo.TuVung;
IF OBJECT_ID(N'dbo.ChiTiet_DiemSo', N'U') IS NOT NULL DROP TABLE dbo.ChiTiet_DiemSo;
IF OBJECT_ID(N'dbo.DotKiemTra', N'U') IS NOT NULL DROP TABLE dbo.DotKiemTra;
IF OBJECT_ID(N'dbo.ChiTiet_DeThi', N'U') IS NOT NULL DROP TABLE dbo.ChiTiet_DeThi;
IF OBJECT_ID(N'dbo.CauHoi', N'U') IS NOT NULL DROP TABLE dbo.CauHoi;
IF OBJECT_ID(N'dbo.DeThi', N'U') IS NOT NULL DROP TABLE dbo.DeThi;
IF OBJECT_ID(N'dbo.ChiTiet_DiemDanh', N'U') IS NOT NULL DROP TABLE dbo.ChiTiet_DiemDanh;
IF OBJECT_ID(N'dbo.BuoiHoc', N'U') IS NOT NULL DROP TABLE dbo.BuoiHoc;
IF OBJECT_ID(N'dbo.ChiTiet_NopBai', N'U') IS NOT NULL DROP TABLE dbo.ChiTiet_NopBai;
IF OBJECT_ID(N'dbo.BaiTap', N'U') IS NOT NULL DROP TABLE dbo.BaiTap;
IF OBJECT_ID(N'dbo.TaiLieu', N'U') IS NOT NULL DROP TABLE dbo.TaiLieu;
IF OBJECT_ID(N'dbo.ChiTiet_LopHoc', N'U') IS NOT NULL DROP TABLE dbo.ChiTiet_LopHoc;
IF OBJECT_ID(N'dbo.LopHoc', N'U') IS NOT NULL DROP TABLE dbo.LopHoc;
IF OBJECT_ID(N'dbo.NguoiDung', N'U') IS NOT NULL DROP TABLE dbo.NguoiDung;
GO

CREATE TABLE dbo.NguoiDung
(
    MaNguoiDung INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_NguoiDung PRIMARY KEY,
    VaiTro NVARCHAR(30) NOT NULL,
    HoTen NVARCHAR(120) NOT NULL,
    NgaySinh DATE NULL,
    SDT NVARCHAR(20) NULL,
    Email NVARCHAR(120) NOT NULL,
    TrinhDoDauVao NVARCHAR(50) NULL,
    TaiKhoan NVARCHAR(50) NOT NULL,
    MatKhau NVARCHAR(200) NOT NULL,
    CONSTRAINT UQ_NguoiDung_TaiKhoan UNIQUE (TaiKhoan),
    CONSTRAINT UQ_NguoiDung_Email UNIQUE (Email),
    CONSTRAINT CK_NguoiDung_VaiTro CHECK (VaiTro IN (N'Admin', N'GiaoVien', N'HocSinh', N'NhanVien'))
);

CREATE TABLE dbo.LopHoc
(
    MaLopHoc INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_LopHoc PRIMARY KEY,
    MaGiaoVien INT NOT NULL,
    TenLop NVARCHAR(80) NOT NULL,
    NhomTrinhDo NVARCHAR(50) NOT NULL,
    LichHoc NVARCHAR(80) NULL,
    CONSTRAINT UQ_LopHoc_TenLop UNIQUE (TenLop),
    CONSTRAINT FK_LopHoc_GiaoVien FOREIGN KEY (MaGiaoVien) REFERENCES dbo.NguoiDung(MaNguoiDung)
);

CREATE TABLE dbo.ChiTiet_LopHoc
(
    MaNguoiDung INT NOT NULL,
    MaLopHoc INT NOT NULL,
    NgayVaoLop DATE NOT NULL CONSTRAINT DF_CTLH_NgayVaoLop DEFAULT CONVERT(date, GETDATE()),
    NgayNghiHoc DATETIME NULL,
    TrangThai NVARCHAR(30) NOT NULL CONSTRAINT DF_CTLH_TrangThai DEFAULT N'Đang học',
    CONSTRAINT PK_ChiTiet_LopHoc PRIMARY KEY (MaNguoiDung, MaLopHoc),
    CONSTRAINT FK_CTLH_NguoiDung FOREIGN KEY (MaNguoiDung) REFERENCES dbo.NguoiDung(MaNguoiDung) ON DELETE CASCADE,
    CONSTRAINT FK_CTLH_LopHoc FOREIGN KEY (MaLopHoc) REFERENCES dbo.LopHoc(MaLopHoc) ON DELETE CASCADE,
    CONSTRAINT CK_CTLH_TrangThai CHECK (TrangThai IN (N'Đang học', N'Tạm nghỉ', N'Đã nghỉ'))
);

CREATE TABLE dbo.TaiLieu
(
    MaTaiLieu INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_TaiLieu PRIMARY KEY,
    MaLopHoc INT NOT NULL,
    TenChuDe NVARCHAR(150) NOT NULL,
    NoiDungMoTa NVARCHAR(1000) NULL,
    DuongDanFile NVARCHAR(500) NULL,
    VideoLink NVARCHAR(500) NULL,
    NhanKyNang NVARCHAR(30) NOT NULL,
    NgayCapNhat DATETIME NOT NULL CONSTRAINT DF_TaiLieu_NgayCapNhat DEFAULT GETDATE(),
    CONSTRAINT FK_TaiLieu_LopHoc FOREIGN KEY (MaLopHoc) REFERENCES dbo.LopHoc(MaLopHoc) ON DELETE CASCADE,
    CONSTRAINT CK_TaiLieu_KyNang CHECK (NhanKyNang IN (N'Listening', N'Reading', N'Writing', N'Speaking'))
);

CREATE TABLE dbo.BaiTap
(
    MaBaiTap INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_BaiTap PRIMARY KEY,
    MaLopHoc INT NOT NULL,
    TieuDe NVARCHAR(150) NOT NULL,
    MoTa NVARCHAR(1500) NOT NULL,
    Deadline DATETIME NOT NULL,
    FileDinhKem NVARCHAR(500) NULL,
    NgayTao DATETIME NOT NULL CONSTRAINT DF_BaiTap_NgayTao DEFAULT GETDATE(),
    CONSTRAINT FK_BaiTap_LopHoc FOREIGN KEY (MaLopHoc) REFERENCES dbo.LopHoc(MaLopHoc) ON DELETE CASCADE
);

CREATE TABLE dbo.ChiTiet_NopBai
(
    MaNguoiDung INT NOT NULL,
    MaBaiTap INT NOT NULL,
    FileBaiLam NVARCHAR(500) NULL,
    ThoiGianNop DATETIME NULL,
    TrangThaiNop NVARCHAR(30) NOT NULL CONSTRAINT DF_NopBai_TrangThai DEFAULT N'Chưa nộp',
    DiemSo DECIMAL(3,1) NULL,
    NhanXet NVARCHAR(1000) NULL,
    CONSTRAINT PK_ChiTiet_NopBai PRIMARY KEY (MaNguoiDung, MaBaiTap),
    CONSTRAINT FK_NopBai_NguoiDung FOREIGN KEY (MaNguoiDung) REFERENCES dbo.NguoiDung(MaNguoiDung) ON DELETE CASCADE,
    CONSTRAINT FK_NopBai_BaiTap FOREIGN KEY (MaBaiTap) REFERENCES dbo.BaiTap(MaBaiTap) ON DELETE CASCADE,
    CONSTRAINT CK_NopBai_Diem CHECK (DiemSo IS NULL OR (DiemSo >= 0 AND DiemSo <= 9))
);

CREATE TABLE dbo.BuoiHoc
(
    MaBuoiHoc INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_BuoiHoc PRIMARY KEY,
    MaLopHoc INT NOT NULL,
    NgayHoc DATE NOT NULL,
    CONSTRAINT FK_BuoiHoc_LopHoc FOREIGN KEY (MaLopHoc) REFERENCES dbo.LopHoc(MaLopHoc) ON DELETE CASCADE,
    CONSTRAINT UQ_BuoiHoc UNIQUE (MaLopHoc, NgayHoc)
);

CREATE TABLE dbo.ChiTiet_DiemDanh
(
    MaNguoiDung INT NOT NULL,
    MaBuoiHoc INT NOT NULL,
    TrangThai NVARCHAR(30) NOT NULL,
    LyDoVang NVARCHAR(500) NULL,
    CONSTRAINT PK_ChiTiet_DiemDanh PRIMARY KEY (MaNguoiDung, MaBuoiHoc),
    CONSTRAINT FK_DiemDanh_NguoiDung FOREIGN KEY (MaNguoiDung) REFERENCES dbo.NguoiDung(MaNguoiDung) ON DELETE CASCADE,
    CONSTRAINT FK_DiemDanh_BuoiHoc FOREIGN KEY (MaBuoiHoc) REFERENCES dbo.BuoiHoc(MaBuoiHoc) ON DELETE CASCADE,
    CONSTRAINT CK_DiemDanh_TrangThai CHECK (TrangThai IN (N'Có mặt', N'Vắng', N'Đi trễ'))
);

CREATE TABLE dbo.DeThi
(
    MaDeThi INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_DeThi PRIMARY KEY,
    TenDeThi NVARCHAR(150) NOT NULL,
    FileDuLieu NVARCHAR(500) NULL,
    NgayTao DATETIME NOT NULL CONSTRAINT DF_DeThi_NgayTao DEFAULT GETDATE()
);

CREATE TABLE dbo.CauHoi
(
    MaCauHoi INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_CauHoi PRIMARY KEY,
    NoiDung NVARCHAR(MAX) NOT NULL,
    DapAn NVARCHAR(MAX) NULL,
    NhanKyNang NVARCHAR(30) NOT NULL,
    BandLevel DECIMAL(3,1) NULL,
    CONSTRAINT CK_CauHoi_KyNang CHECK (NhanKyNang IN (N'Listening', N'Reading', N'Writing', N'Speaking')),
    CONSTRAINT CK_CauHoi_BandLevel CHECK (BandLevel IS NULL OR (BandLevel >= 0 AND BandLevel <= 9))
);

CREATE TABLE dbo.ChiTiet_DeThi
(
    MaDeThi INT NOT NULL,
    MaCauHoi INT NOT NULL,
    CONSTRAINT PK_ChiTiet_DeThi PRIMARY KEY (MaDeThi, MaCauHoi),
    CONSTRAINT FK_CTDT_DeThi FOREIGN KEY (MaDeThi) REFERENCES dbo.DeThi(MaDeThi) ON DELETE CASCADE,
    CONSTRAINT FK_CTDT_CauHoi FOREIGN KEY (MaCauHoi) REFERENCES dbo.CauHoi(MaCauHoi) ON DELETE CASCADE
);

CREATE TABLE dbo.DotKiemTra
(
    MaDotKiemTra INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_DotKiemTra PRIMARY KEY,
    MaLopHoc INT NOT NULL,
    MaDeThi INT NULL,
    TenDotKiemTra NVARCHAR(150) NOT NULL,
    NgayKiemTra DATE NOT NULL,
    CONSTRAINT FK_DotKiemTra_LopHoc FOREIGN KEY (MaLopHoc) REFERENCES dbo.LopHoc(MaLopHoc) ON DELETE CASCADE,
    CONSTRAINT FK_DotKiemTra_DeThi FOREIGN KEY (MaDeThi) REFERENCES dbo.DeThi(MaDeThi)
);

CREATE TABLE dbo.ChiTiet_DiemSo
(
    MaNguoiDung INT NOT NULL,
    MaDotKiemTra INT NOT NULL,
    DiemL DECIMAL(3,1) NULL,
    DiemR DECIMAL(3,1) NULL,
    DiemW DECIMAL(3,1) NULL,
    DiemS DECIMAL(3,1) NULL,
    DiemTong DECIMAL(3,1) NULL,
    NhanXet NVARCHAR(1000) NULL,
    CONSTRAINT PK_ChiTiet_DiemSo PRIMARY KEY (MaNguoiDung, MaDotKiemTra),
    CONSTRAINT FK_DiemSo_NguoiDung FOREIGN KEY (MaNguoiDung) REFERENCES dbo.NguoiDung(MaNguoiDung) ON DELETE CASCADE,
    CONSTRAINT FK_DiemSo_DotKiemTra FOREIGN KEY (MaDotKiemTra) REFERENCES dbo.DotKiemTra(MaDotKiemTra) ON DELETE CASCADE,
    CONSTRAINT CK_DiemSo_ThangDiem CHECK
    (
        (DiemL IS NULL OR (DiemL >= 0 AND DiemL <= 9)) AND
        (DiemR IS NULL OR (DiemR >= 0 AND DiemR <= 9)) AND
        (DiemW IS NULL OR (DiemW >= 0 AND DiemW <= 9)) AND
        (DiemS IS NULL OR (DiemS >= 0 AND DiemS <= 9)) AND
        (DiemTong IS NULL OR (DiemTong >= 0 AND DiemTong <= 9))
    )
);

CREATE TABLE dbo.TuVung
(
    MaTuVung INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_TuVung PRIMARY KEY,
    MaLopHoc INT NOT NULL,
    TuTiengAnh NVARCHAR(120) NOT NULL,
    TuLoai NVARCHAR(60) NOT NULL,
    PhienAm NVARCHAR(120) NOT NULL,
    Nghia NVARCHAR(300) NOT NULL,
    CapDo NVARCHAR(10) NOT NULL,
    ChuDe NVARCHAR(100) NOT NULL,
    CONSTRAINT FK_TuVung_LopHoc FOREIGN KEY (MaLopHoc) REFERENCES dbo.LopHoc(MaLopHoc) ON DELETE CASCADE,
    CONSTRAINT UQ_TuVung_Lop UNIQUE (MaLopHoc, TuTiengAnh),
    CONSTRAINT CK_TuVung_CapDo CHECK (CapDo IN (N'B1', N'B2', N'C1', N'C2'))
);

CREATE TABLE dbo.TienTrinh_Flashcard
(
    MaNguoiDung INT NOT NULL,
    MaTuVung INT NOT NULL,
    KetQua NVARCHAR(50) NOT NULL CONSTRAINT DF_Flashcard_KetQua DEFAULT N'Chưa học',
    CONSTRAINT PK_TienTrinh_Flashcard PRIMARY KEY (MaNguoiDung, MaTuVung),
    CONSTRAINT FK_Flashcard_NguoiDung FOREIGN KEY (MaNguoiDung) REFERENCES dbo.NguoiDung(MaNguoiDung) ON DELETE CASCADE,
    CONSTRAINT FK_Flashcard_TuVung FOREIGN KEY (MaTuVung) REFERENCES dbo.TuVung(MaTuVung) ON DELETE CASCADE
);

CREATE TABLE dbo.ThongBao
(
    MaThongBao INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_ThongBao PRIMARY KEY,
    MaNguoiGui INT NOT NULL,
    TieuDe NVARCHAR(150) NOT NULL,
    NoiDung NVARCHAR(MAX) NOT NULL,
    DoiTuongNhan NVARCHAR(120) NOT NULL,
    ThoiGianGui DATETIME NOT NULL CONSTRAINT DF_ThongBao_ThoiGian DEFAULT GETDATE(),
    CONSTRAINT FK_ThongBao_NguoiGui FOREIGN KEY (MaNguoiGui) REFERENCES dbo.NguoiDung(MaNguoiDung)
);

CREATE TABLE dbo.ChiTiet_ThongBao
(
    MaThongBao INT NOT NULL,
    MaNguoiDung INT NOT NULL,
    DaDoc BIT NOT NULL CONSTRAINT DF_CTThongBao_DaDoc DEFAULT 0,
    CONSTRAINT PK_ChiTiet_ThongBao PRIMARY KEY (MaThongBao, MaNguoiDung),
    CONSTRAINT FK_CTThongBao_ThongBao FOREIGN KEY (MaThongBao) REFERENCES dbo.ThongBao(MaThongBao) ON DELETE CASCADE,
    CONSTRAINT FK_CTThongBao_NguoiDung FOREIGN KEY (MaNguoiDung) REFERENCES dbo.NguoiDung(MaNguoiDung) ON DELETE CASCADE
);

CREATE TABLE dbo.ThanhToanHocPhi
(
    MaThanhToan INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_ThanhToanHocPhi PRIMARY KEY,
    MaNguoiDung INT NOT NULL,
    MaLopHoc INT NULL,
    SoTien DECIMAL(18,2) NOT NULL,
    SoTienGoc DECIMAL(18,2) NULL,
    PhanTramGiam DECIMAL(5,2) NOT NULL CONSTRAINT DF_HocPhi_PhanTramGiam DEFAULT 0,
    SoTienGiam DECIMAL(18,2) NOT NULL CONSTRAINT DF_HocPhi_SoTienGiam DEFAULT 0,
    SoTienCuoi DECIMAL(18,2) NULL,
    ThongTinNganHang NVARCHAR(300) NOT NULL,
    NgayTao DATETIME NOT NULL CONSTRAINT DF_HocPhi_NgayTao DEFAULT GETDATE(),
    HanThanhToan DATETIME NOT NULL,
    TrangThai NVARCHAR(40) NOT NULL,
    CONSTRAINT FK_HocPhi_NguoiDung FOREIGN KEY (MaNguoiDung) REFERENCES dbo.NguoiDung(MaNguoiDung) ON DELETE CASCADE,
    CONSTRAINT FK_HocPhi_LopHoc FOREIGN KEY (MaLopHoc) REFERENCES dbo.LopHoc(MaLopHoc)
);

CREATE TABLE dbo.NhatKyBaoCao
(
    MaNhatKy INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_NhatKyBaoCao PRIMARY KEY,
    MaNguoiDung INT NOT NULL,
    LoaiBaoCao NVARCHAR(100) NOT NULL,
    TieuChi NVARCHAR(500) NULL,
    ThoiGianTao DATETIME NOT NULL CONSTRAINT DF_NhatKyBaoCao_ThoiGian DEFAULT GETDATE(),
    CONSTRAINT FK_NhatKyBaoCao_NguoiDung FOREIGN KEY (MaNguoiDung) REFERENCES dbo.NguoiDung(MaNguoiDung)
);
GO

INSERT INTO dbo.NguoiDung (VaiTro, HoTen, NgaySinh, SDT, Email, TrinhDoDauVao, TaiKhoan, MatKhau)
VALUES
(N'Admin', N'Quản trị hệ thống', NULL, N'0900000000', N'admin@ielts.local', NULL, N'admin', N'admin'),
(N'GiaoVien', N'Giáo viên IELTS', NULL, N'0900000001', N'giaovien@ielts.local', NULL, N'giaovien', N'123456'),
(N'HocSinh', N'Nguyễn Văn An', '2005-01-10', N'0911000001', N'an.nguyen@example.com', N'Band 4.5', N'an.nguyen', N'123456'),
(N'HocSinh', N'Trần Thị Bình', '2005-03-15', N'0911000002', N'binh.tran@example.com', N'Band 5.0', N'binh.tran', N'123456'),
(N'HocSinh', N'Lê Minh Châu', '2004-07-21', N'0911000003', N'chau.le@example.com', N'Band 5.0', N'chau.le', N'123456'),
(N'HocSinh', N'Phạm Gia Hân', '2005-09-02', N'0911000004', N'han.pham@example.com', N'Band 4.0', N'han.pham', N'123456'),
(N'HocSinh', N'Hoàng Quốc Huy', '2004-12-11', N'0911000005', N'huy.hoang@example.com', N'Band 5.5', N'huy.hoang', N'123456'),
(N'HocSinh', N'Vũ Ngọc Linh', '2005-05-18', N'0911000006', N'linh.vu@example.com', N'Band 4.5', N'linh.vu', N'123456'),
(N'HocSinh', N'Đặng Phương Mai', '2004-02-27', N'0911000007', N'mai.dang@example.com', N'Band 5.0', N'mai.dang', N'123456'),
(N'HocSinh', N'Bùi Tuấn Kiệt', '2005-08-19', N'0911000008', N'kiet.bui@example.com', N'Band 4.5', N'kiet.bui', N'123456'),
(N'HocSinh', N'Đỗ Hải Nam', '2004-11-08', N'0911000009', N'nam.do@example.com', N'Band 5.5', N'nam.do', N'123456'),
(N'HocSinh', N'Ngô Khánh Ngân', '2005-04-24', N'0911000010', N'ngan.ngo@example.com', N'Band 4.0', N'ngan.ngo', N'123456'),
(N'HocSinh', N'Phan Nhật Minh', '2004-06-30', N'0911000011', N'minh.phan@example.com', N'Band 5.0', N'minh.phan', N'123456'),
(N'HocSinh', N'Trịnh Bảo Ngọc', '2005-10-12', N'0911000012', N'ngoc.trinh@example.com', N'Band 4.5', N'ngoc.trinh', N'123456'),
(N'HocSinh', N'Võ Thanh Tâm', '2004-01-17', N'0911000013', N'tam.vo@example.com', N'Band 5.5', N'tam.vo', N'123456'),
(N'HocSinh', N'Huỳnh Mai Trang', '2005-06-06', N'0911000014', N'trang.huynh@example.com', N'Band 5.0', N'trang.huynh', N'123456'),
(N'HocSinh', N'Cao Đức Việt', '2004-03-03', N'0911000015', N'viet.cao@example.com', N'Band 4.5', N'viet.cao', N'123456'),
(N'HocSinh', N'Nguyễn Hoài Anh', '2003-12-14', N'0912000001', N'anh.nguyen@example.com', N'Band 6.0', N'anh.nguyen', N'123456'),
(N'HocSinh', N'Trần Đức Bảo', '2004-04-18', N'0912000002', N'bao.tran@example.com', N'Band 5.5', N'bao.tran', N'123456'),
(N'HocSinh', N'Lê Thảo Chi', '2003-09-09', N'0912000003', N'chi.le@example.com', N'Band 6.0', N'chi.le', N'123456'),
(N'HocSinh', N'Phạm Minh Duy', '2004-07-07', N'0912000004', N'duy.pham@example.com', N'Band 5.5', N'duy.pham', N'123456'),
(N'HocSinh', N'Hoàng Khánh Hà', '2003-11-22', N'0912000005', N'ha.hoang@example.com', N'Band 6.5', N'ha.hoang', N'123456'),
(N'HocSinh', N'Vũ Gia Huy', '2004-05-05', N'0912000006', N'giahuy.vu@example.com', N'Band 6.0', N'giahuy.vu', N'123456'),
(N'HocSinh', N'Đặng Thu Hương', '2003-02-20', N'0912000007', N'huong.dang@example.com', N'Band 5.5', N'huong.dang', N'123456'),
(N'HocSinh', N'Bùi Quang Khải', '2004-10-01', N'0912000008', N'khai.bui@example.com', N'Band 6.0', N'khai.bui', N'123456'),
(N'HocSinh', N'Đỗ Phương Lan', '2003-08-26', N'0912000009', N'lan.do@example.com', N'Band 6.5', N'lan.do', N'123456'),
(N'HocSinh', N'Ngô Nhật Long', '2004-12-02', N'0912000010', N'long.ngo@example.com', N'Band 5.5', N'long.ngo', N'123456'),
(N'HocSinh', N'Phan Bảo Nhi', '2003-03-16', N'0912000011', N'nhi.phan@example.com', N'Band 6.0', N'nhi.phan', N'123456'),
(N'HocSinh', N'Trịnh Quốc Phong', '2004-01-25', N'0912000012', N'phong.trinh@example.com', N'Band 6.5', N'phong.trinh', N'123456'),
(N'HocSinh', N'Võ Minh Quân', '2003-06-28', N'0912000013', N'quan.vo@example.com', N'Band 5.5', N'quan.vo', N'123456'),
(N'HocSinh', N'Huỳnh Ngọc Thảo', '2004-09-13', N'0912000014', N'thao.huynh@example.com', N'Band 6.0', N'thao.huynh', N'123456'),
(N'HocSinh', N'Cao Tuệ Vy', '2003-05-30', N'0912000015', N'vy.cao@example.com', N'Band 6.5', N'vy.cao', N'123456');

INSERT INTO dbo.LopHoc (MaGiaoVien, TenLop, NhomTrinhDo, LichHoc)
VALUES
(2, N'IELTS Cơ Bản', N'Band 4.0-5.5', N'Thứ 2 - Thứ 4, 18:00'),
(2, N'IELTS Nâng Cao', N'Band 5.5-7.0', N'Thứ 3 - Thứ 5, 19:30');

INSERT INTO dbo.ChiTiet_LopHoc (MaNguoiDung, MaLopHoc, NgayVaoLop, NgayNghiHoc, TrangThai)
VALUES
(3, 1, '2023-02-01', NULL, N'Đang học'),
(4, 1, '2023-06-01', NULL, N'Đang học'),
(5, 1, '2024-01-15', NULL, N'Đang học'),
(6, 1, '2024-03-01', NULL, N'Đang học'),
(7, 1, '2022-09-01', NULL, N'Đang học'),
(8, 1, '2024-08-01', NULL, N'Đang học'),
(9, 1, '2023-10-01', NULL, N'Đang học'),
(10, 1, '2025-01-05', NULL, N'Đang học'),
(11, 1, '2022-05-15', NULL, N'Đang học'),
(12, 1, '2025-02-01', NULL, N'Đang học'),
(13, 1, '2023-04-10', NULL, N'Đang học'),
(14, 1, '2024-06-01', NULL, N'Đang học'),
(15, 1, '2022-11-01', NULL, N'Đang học'),
(16, 1, '2024-09-01', DATEADD(month, -2, GETDATE()), N'Đã nghỉ'),
(17, 1, '2024-09-01', NULL, N'Tạm nghỉ'),
(18, 2, '2022-03-01', NULL, N'Đang học'),
(19, 2, '2023-09-01', NULL, N'Đang học'),
(20, 2, '2022-07-01', NULL, N'Đang học'),
(21, 2, '2024-02-01', NULL, N'Đang học'),
(22, 2, '2023-01-20', NULL, N'Đang học'),
(23, 2, '2024-05-10', NULL, N'Đang học'),
(24, 2, '2022-12-01', NULL, N'Đang học'),
(25, 2, '2024-07-01', NULL, N'Đang học'),
(26, 2, '2023-05-01', NULL, N'Đang học'),
(27, 2, '2024-10-01', NULL, N'Đang học'),
(28, 2, '2022-08-15', NULL, N'Đang học'),
(29, 2, '2025-01-01', NULL, N'Đang học'),
(30, 2, '2023-02-15', NULL, N'Đang học'),
(31, 2, '2024-04-01', NULL, N'Đang học'),
(32, 2, '2023-11-01', DATEADD(day, -10, GETDATE()), N'Tạm nghỉ');
GO

INSERT INTO dbo.TuVung (MaLopHoc, TuTiengAnh, TuLoai, PhienAm, Nghia, CapDo, ChuDe)
VALUES
(1, N'algorithm', N'noun', N'/ˈælɡərɪðəm/', N'thuật toán', N'B2', N'Technology'),
(1, N'automation', N'noun', N'/ˌɔːtəˈmeɪʃn/', N'tự động hóa', N'B2', N'Technology'),
(1, N'bandwidth', N'noun', N'/ˈbændwɪdθ/', N'băng thông', N'C1', N'Technology'),
(1, N'cybersecurity', N'noun', N'/ˌsaɪbərsɪˈkjʊərəti/', N'an ninh mạng', N'C1', N'Technology'),
(1, N'database', N'noun', N'/ˈdeɪtəbeɪs/', N'cơ sở dữ liệu', N'B2', N'Technology'),
(1, N'device', N'noun', N'/dɪˈvaɪs/', N'thiết bị', N'B1', N'Technology'),
(1, N'innovation', N'noun', N'/ˌɪnəˈveɪʃn/', N'sự đổi mới', N'B2', N'Technology'),
(1, N'interface', N'noun', N'/ˈɪntərfeɪs/', N'giao diện', N'B2', N'Technology'),
(1, N'network', N'noun', N'/ˈnetwɜːrk/', N'mạng lưới', N'B1', N'Technology'),
(1, N'privacy', N'noun', N'/ˈpraɪvəsi/', N'quyền riêng tư', N'B2', N'Technology'),
(1, N'program', N'noun', N'/ˈproʊɡræm/', N'chương trình', N'B1', N'Technology'),
(1, N'software', N'noun', N'/ˈsɔːftwer/', N'phần mềm', N'B1', N'Technology'),
(1, N'hardware', N'noun', N'/ˈhɑːrdwer/', N'phần cứng', N'B1', N'Technology'),
(1, N'encrypt', N'verb', N'/ɪnˈkrɪpt/', N'mã hóa', N'C1', N'Technology'),
(1, N'prototype', N'noun', N'/ˈproʊtətaɪp/', N'nguyên mẫu', N'C1', N'Technology'),
(1, N'robotic', N'adjective', N'/roʊˈbɑːtɪk/', N'thuộc về rô bốt', N'B2', N'Technology'),
(1, N'sensor', N'noun', N'/ˈsensər/', N'cảm biến', N'B2', N'Technology'),
(1, N'update', N'verb', N'/ˌʌpˈdeɪt/', N'cập nhật', N'B1', N'Technology'),
(1, N'digital', N'adjective', N'/ˈdɪdʒɪtl/', N'kỹ thuật số', N'B1', N'Technology'),
(1, N'virtual', N'adjective', N'/ˈvɜːrtʃuəl/', N'ảo', N'B2', N'Technology'),
(1, N'electronically', N'adverb', N'/ɪˌlekˈtrɑːnɪkli/', N'bằng phương thức điện tử', N'C1', N'Technology'),
(1, N'scalable', N'adjective', N'/ˈskeɪləbl/', N'có thể mở rộng', N'C1', N'Technology'),
(2, N'athlete', N'noun', N'/ˈæθliːt/', N'vận động viên', N'B1', N'Sports'),
(2, N'championship', N'noun', N'/ˈtʃæmpiənʃɪp/', N'giải vô địch', N'B2', N'Sports'),
(2, N'endurance', N'noun', N'/ɪnˈdʊrəns/', N'sức bền', N'B2', N'Sports'),
(2, N'fitness', N'noun', N'/ˈfɪtnəs/', N'thể lực', N'B1', N'Sports'),
(2, N'referee', N'noun', N'/ˌrefəˈriː/', N'trọng tài', N'B1', N'Sports'),
(2, N'tournament', N'noun', N'/ˈtʊrnəmənt/', N'giải đấu', N'B1', N'Sports'),
(2, N'training', N'noun', N'/ˈtreɪnɪŋ/', N'sự luyện tập', N'B1', N'Sports'),
(2, N'teamwork', N'noun', N'/ˈtiːmwɜːrk/', N'tinh thần đồng đội', N'B2', N'Sports'),
(2, N'tactic', N'noun', N'/ˈtæktɪk/', N'chiến thuật', N'B2', N'Sports'),
(2, N'competitor', N'noun', N'/kəmˈpetɪtər/', N'đối thủ', N'B2', N'Sports'),
(2, N'stadium', N'noun', N'/ˈsteɪdiəm/', N'sân vận động', N'B1', N'Sports'),
(2, N'medal', N'noun', N'/ˈmedl/', N'huy chương', N'B1', N'Sports'),
(2, N'victory', N'noun', N'/ˈvɪktəri/', N'chiến thắng', N'B2', N'Sports'),
(2, N'defeat', N'noun', N'/dɪˈfiːt/', N'thất bại', N'B2', N'Sports'),
(2, N'coach', N'noun', N'/koʊtʃ/', N'huấn luyện viên', N'B1', N'Sports'),
(2, N'marathon', N'noun', N'/ˈmærəθɑːn/', N'cuộc chạy marathon', N'B1', N'Sports'),
(2, N'injury', N'noun', N'/ˈɪndʒəri/', N'chấn thương', N'B1', N'Sports'),
(2, N'score', N'noun', N'/skɔːr/', N'điểm số', N'B1', N'Sports'),
(2, N'perform', N'verb', N'/pərˈfɔːrm/', N'thi đấu, trình diễn', N'B1', N'Sports'),
(2, N'disciplined', N'adjective', N'/ˈdɪsəplɪnd/', N'có kỷ luật', N'B2', N'Sports'),
(2, N'aggressively', N'adverb', N'/əˈɡresɪvli/', N'một cách quyết liệt', N'C1', N'Sports'),
(2, N'competitive', N'adjective', N'/kəmˈpetətɪv/', N'cạnh tranh', N'B2', N'Sports'),
(1, N'curriculum', N'noun', N'/kəˈrɪkjələm/', N'chương trình học', N'C1', N'Education'),
(1, N'assessment', N'noun', N'/əˈsesmənt/', N'sự đánh giá', N'B2', N'Education'),
(1, N'scholarship', N'noun', N'/ˈskɑːlərʃɪp/', N'học bổng', N'B2', N'Education'),
(1, N'lecture', N'noun', N'/ˈlektʃər/', N'bài giảng', N'B1', N'Education'),
(1, N'seminar', N'noun', N'/ˈsemɪnɑːr/', N'hội thảo chuyên đề', N'B2', N'Education'),
(1, N'literacy', N'noun', N'/ˈlɪtərəsi/', N'khả năng đọc viết', N'B2', N'Education'),
(1, N'assignment', N'noun', N'/əˈsaɪnmənt/', N'bài tập', N'B1', N'Education'),
(1, N'attendance', N'noun', N'/əˈtendəns/', N'chuyên cần', N'B1', N'Education'),
(1, N'classroom', N'noun', N'/ˈklæsruːm/', N'phòng học', N'B1', N'Education'),
(1, N'qualification', N'noun', N'/ˌkwɑːlɪfɪˈkeɪʃn/', N'bằng cấp', N'B2', N'Education'),
(1, N'research', N'noun', N'/rɪˈsɜːrtʃ/', N'nghiên cứu', N'B1', N'Education'),
(1, N'dissertation', N'noun', N'/ˌdɪsərˈteɪʃn/', N'luận văn', N'C1', N'Education'),
(1, N'tutor', N'noun', N'/ˈtuːtər/', N'gia sư', N'B1', N'Education'),
(1, N'enrollment', N'noun', N'/ɪnˈroʊlmənt/', N'sự ghi danh', N'B2', N'Education'),
(1, N'pedagogy', N'noun', N'/ˈpedəɡɑːdʒi/', N'phương pháp sư phạm', N'C2', N'Education'),
(1, N'syllabus', N'noun', N'/ˈsɪləbəs/', N'đề cương môn học', N'C1', N'Education'),
(1, N'graduate', N'verb', N'/ˈɡrædʒueɪt/', N'tốt nghiệp', N'B1', N'Education'),
(1, N'campus', N'noun', N'/ˈkæmpəs/', N'khuôn viên trường', N'B1', N'Education'),
(1, N'feedback', N'noun', N'/ˈfiːdbæk/', N'phản hồi', N'B1', N'Education'),
(1, N'revise', N'verb', N'/rɪˈvaɪz/', N'ôn tập, sửa lại', N'B1', N'Education'),
(1, N'academic', N'adjective', N'/ˌækəˈdemɪk/', N'thuộc học thuật', N'B2', N'Education'),
(1, N'independently', N'adverb', N'/ˌɪndɪˈpendəntli/', N'một cách độc lập', N'B2', N'Education'),
(2, N'nutritious', N'adjective', N'/nuˈtrɪʃəs/', N'bổ dưỡng', N'B2', N'Health'),
(2, N'vaccine', N'noun', N'/vækˈsiːn/', N'vắc xin', N'B2', N'Health'),
(2, N'symptom', N'noun', N'/ˈsɪmptəm/', N'triệu chứng', N'B1', N'Health'),
(2, N'diagnosis', N'noun', N'/ˌdaɪəɡˈnoʊsɪs/', N'chẩn đoán', N'C1', N'Health'),
(2, N'treatment', N'noun', N'/ˈtriːtmənt/', N'điều trị', N'B1', N'Health'),
(2, N'recovery', N'noun', N'/rɪˈkʌvəri/', N'sự hồi phục', N'B2', N'Health'),
(2, N'infection', N'noun', N'/ɪnˈfekʃn/', N'nhiễm trùng', N'B2', N'Health'),
(2, N'mental', N'adjective', N'/ˈmentl/', N'thuộc tinh thần', N'B1', N'Health'),
(2, N'physical', N'adjective', N'/ˈfɪzɪkl/', N'thuộc thể chất', N'B1', N'Health'),
(2, N'exercise', N'noun', N'/ˈeksərsaɪz/', N'bài tập thể dục', N'B1', N'Health'),
(2, N'prevention', N'noun', N'/prɪˈvenʃn/', N'sự phòng ngừa', N'B2', N'Health'),
(2, N'chronic', N'adjective', N'/ˈkrɑːnɪk/', N'mãn tính', N'C1', N'Health'),
(2, N'therapy', N'noun', N'/ˈθerəpi/', N'liệu pháp', N'B2', N'Health'),
(2, N'emergency', N'noun', N'/ɪˈmɜːrdʒənsi/', N'tình huống khẩn cấp', N'B1', N'Health'),
(2, N'hygiene', N'noun', N'/ˈhaɪdʒiːn/', N'vệ sinh', N'B2', N'Health'),
(2, N'medicine', N'noun', N'/ˈmedɪsn/', N'thuốc, y học', N'B1', N'Health'),
(2, N'patient', N'noun', N'/ˈpeɪʃnt/', N'bệnh nhân', N'B1', N'Health'),
(2, N'stress', N'noun', N'/stres/', N'căng thẳng', N'B1', N'Health'),
(2, N'balanced', N'adjective', N'/ˈbælənst/', N'cân bằng', N'B1', N'Health'),
(2, N'immunity', N'noun', N'/ɪˈmjuːnəti/', N'khả năng miễn dịch', N'C1', N'Health'),
(2, N'medically', N'adverb', N'/ˈmedɪkli/', N'về mặt y khoa', N'B2', N'Health'),
(2, N'heal', N'verb', N'/hiːl/', N'chữa lành', N'B1', N'Health'),
(1, N'revenue', N'noun', N'/ˈrevənuː/', N'doanh thu', N'B2', N'Business'),
(1, N'investment', N'noun', N'/ɪnˈvestmənt/', N'khoản đầu tư', N'B2', N'Business'),
(1, N'market', N'noun', N'/ˈmɑːrkɪt/', N'thị trường', N'B1', N'Business'),
(1, N'negotiation', N'noun', N'/nɪˌɡoʊʃiˈeɪʃn/', N'sự đàm phán', N'C1', N'Business'),
(1, N'contract', N'noun', N'/ˈkɑːntrækt/', N'hợp đồng', N'B2', N'Business'),
(1, N'profit', N'noun', N'/ˈprɑːfɪt/', N'lợi nhuận', N'B1', N'Business'),
(1, N'loss', N'noun', N'/lɔːs/', N'thua lỗ', N'B1', N'Business'),
(1, N'startup', N'noun', N'/ˈstɑːrtʌp/', N'công ty khởi nghiệp', N'B2', N'Business'),
(1, N'customer', N'noun', N'/ˈkʌstəmər/', N'khách hàng', N'B1', N'Business'),
(1, N'enterprise', N'noun', N'/ˈentərpraɪz/', N'doanh nghiệp', N'B2', N'Business'),
(1, N'budget', N'noun', N'/ˈbʌdʒɪt/', N'ngân sách', N'B1', N'Business'),
(1, N'invoice', N'noun', N'/ˈɪnvɔɪs/', N'hóa đơn', N'B2', N'Business'),
(1, N'supply', N'noun', N'/səˈplaɪ/', N'nguồn cung', N'B1', N'Business'),
(1, N'demand', N'noun', N'/dɪˈmænd/', N'nhu cầu', N'B1', N'Business'),
(1, N'brand', N'noun', N'/brænd/', N'thương hiệu', N'B1', N'Business'),
(1, N'advertise', N'verb', N'/ˈædvərtaɪz/', N'quảng cáo', N'B1', N'Business'),
(1, N'management', N'noun', N'/ˈmænɪdʒmənt/', N'quản lý', N'B2', N'Business'),
(1, N'leadership', N'noun', N'/ˈliːdərʃɪp/', N'năng lực lãnh đạo', N'B2', N'Business'),
(1, N'productivity', N'noun', N'/ˌproʊdʌkˈtɪvəti/', N'năng suất', N'C1', N'Business'),
(1, N'shareholder', N'noun', N'/ˈʃerhoʊldər/', N'cổ đông', N'C1', N'Business'),
(1, N'commercially', N'adverb', N'/kəˈmɜːrʃəli/', N'về mặt thương mại', N'C1', N'Business'),
(1, N'economic', N'adjective', N'/ˌiːkəˈnɑːmɪk/', N'thuộc kinh tế', N'B2', N'Business'),
(2, N'biodiversity', N'noun', N'/ˌbaɪoʊdaɪˈvɜːrsəti/', N'đa dạng sinh học', N'C1', N'Environment'),
(2, N'pollution', N'noun', N'/pəˈluːʃn/', N'ô nhiễm', N'B1', N'Environment'),
(2, N'recycling', N'noun', N'/ˌriːˈsaɪklɪŋ/', N'tái chế', N'B1', N'Environment'),
(2, N'conservation', N'noun', N'/ˌkɑːnsərˈveɪʃn/', N'bảo tồn', N'B2', N'Environment'),
(2, N'climate', N'noun', N'/ˈklaɪmət/', N'khí hậu', N'B1', N'Environment'),
(2, N'renewable', N'adjective', N'/rɪˈnuːəbl/', N'tái tạo', N'B2', N'Environment'),
(2, N'emission', N'noun', N'/ɪˈmɪʃn/', N'khí thải', N'B2', N'Environment'),
(2, N'habitat', N'noun', N'/ˈhæbɪtæt/', N'môi trường sống', N'B2', N'Environment'),
(2, N'ecosystem', N'noun', N'/ˈiːkoʊsɪstəm/', N'hệ sinh thái', N'B2', N'Environment'),
(2, N'sustainability', N'noun', N'/səˌsteɪnəˈbɪləti/', N'tính bền vững', N'C1', N'Environment'),
(2, N'deforestation', N'noun', N'/diːˌfɔːrɪˈsteɪʃn/', N'phá rừng', N'C1', N'Environment'),
(2, N'drought', N'noun', N'/draʊt/', N'hạn hán', N'B2', N'Environment'),
(2, N'flood', N'noun', N'/flʌd/', N'lũ lụt', N'B1', N'Environment'),
(2, N'wildlife', N'noun', N'/ˈwaɪldlaɪf/', N'động vật hoang dã', N'B1', N'Environment'),
(2, N'carbon', N'noun', N'/ˈkɑːrbən/', N'cacbon', N'B2', N'Environment'),
(2, N'waste', N'noun', N'/weɪst/', N'rác thải', N'B1', N'Environment'),
(2, N'resource', N'noun', N'/ˈriːsɔːrs/', N'tài nguyên', N'B2', N'Environment'),
(2, N'landfill', N'noun', N'/ˈlændfɪl/', N'bãi chôn lấp rác', N'C1', N'Environment'),
(2, N'species', N'noun', N'/ˈspiːʃiːz/', N'loài', N'B2', N'Environment'),
(2, N'erosion', N'noun', N'/ɪˈroʊʒn/', N'xói mòn', N'C1', N'Environment'),
(2, N'environmental', N'adjective', N'/ɪnˌvaɪrənˈmentl/', N'thuộc môi trường', N'B2', N'Environment'),
(2, N'naturally', N'adverb', N'/ˈnætʃrəli/', N'một cách tự nhiên', N'B1', N'Environment'),
(1, N'itinerary', N'noun', N'/aɪˈtɪnəreri/', N'lịch trình', N'C1', N'Travel'),
(1, N'destination', N'noun', N'/ˌdestɪˈneɪʃn/', N'điểm đến', N'B1', N'Travel'),
(1, N'accommodation', N'noun', N'/əˌkɑːməˈdeɪʃn/', N'chỗ ở', N'B2', N'Travel'),
(1, N'passport', N'noun', N'/ˈpæspɔːrt/', N'hộ chiếu', N'B1', N'Travel'),
(1, N'luggage', N'noun', N'/ˈlʌɡɪdʒ/', N'hành lý', N'B1', N'Travel'),
(1, N'departure', N'noun', N'/dɪˈpɑːrtʃər/', N'sự khởi hành', N'B1', N'Travel'),
(1, N'arrival', N'noun', N'/əˈraɪvl/', N'sự đến nơi', N'B1', N'Travel'),
(1, N'customs', N'noun', N'/ˈkʌstəmz/', N'hải quan', N'B2', N'Travel'),
(1, N'sightseeing', N'noun', N'/ˈsaɪtsiːɪŋ/', N'tham quan', N'B1', N'Travel'),
(1, N'journey', N'noun', N'/ˈdʒɜːrni/', N'chuyến đi', N'B1', N'Travel'),
(1, N'tourist', N'noun', N'/ˈtʊrɪst/', N'khách du lịch', N'B1', N'Travel'),
(1, N'reservation', N'noun', N'/ˌrezərˈveɪʃn/', N'đặt chỗ', N'B1', N'Travel'),
(1, N'transportation', N'noun', N'/ˌtrænspərˈteɪʃn/', N'giao thông vận tải', N'B2', N'Travel'),
(1, N'adventure', N'noun', N'/ədˈventʃər/', N'cuộc phiêu lưu', N'B1', N'Travel'),
(1, N'culture', N'noun', N'/ˈkʌltʃər/', N'văn hóa', N'B1', N'Travel'),
(1, N'landmark', N'noun', N'/ˈlændmɑːrk/', N'danh thắng', N'B2', N'Travel'),
(1, N'visa', N'noun', N'/ˈviːzə/', N'thị thực', N'B1', N'Travel'),
(1, N'delay', N'noun', N'/dɪˈleɪ/', N'sự chậm trễ', N'B1', N'Travel'),
(1, N'route', N'noun', N'/ruːt/', N'tuyến đường', N'B1', N'Travel'),
(1, N'souvenir', N'noun', N'/ˌsuːvəˈnɪr/', N'quà lưu niệm', N'B1', N'Travel'),
(1, N'overseas', N'adverb', N'/ˌoʊvərˈsiːz/', N'ở nước ngoài', N'B2', N'Travel'),
(1, N'flexible', N'adjective', N'/ˈfleksəbl/', N'linh hoạt', N'B2', N'Travel'),
(2, N'apple', N'noun', N'/ˈæpl/', N'táo', N'B1', N'Food/Fruits'),
(2, N'banana', N'noun', N'/bəˈnænə/', N'chuối', N'B1', N'Food/Fruits'),
(2, N'mango', N'noun', N'/ˈmæŋɡoʊ/', N'xoài', N'B1', N'Food/Fruits'),
(2, N'pineapple', N'noun', N'/ˈpaɪnæpl/', N'dứa', N'B1', N'Food/Fruits'),
(2, N'watermelon', N'noun', N'/ˈwɔːtərmelən/', N'dưa hấu', N'B1', N'Food/Fruits'),
(2, N'grape', N'noun', N'/ɡreɪp/', N'nho', N'B1', N'Food/Fruits'),
(2, N'strawberry', N'noun', N'/ˈstrɔːberi/', N'dâu tây', N'B1', N'Food/Fruits'),
(2, N'avocado', N'noun', N'/ˌævəˈkɑːdoʊ/', N'bơ', N'B1', N'Food/Fruits'),
(2, N'orange', N'noun', N'/ˈɔːrɪndʒ/', N'cam', N'B1', N'Food/Fruits'),
(2, N'coconut', N'noun', N'/ˈkoʊkənʌt/', N'dừa', N'B1', N'Food/Fruits'),
(2, N'ingredient', N'noun', N'/ɪnˈɡriːdiənt/', N'nguyên liệu', N'B2', N'Food/Fruits'),
(2, N'cuisine', N'noun', N'/kwɪˈziːn/', N'ẩm thực', N'B2', N'Food/Fruits'),
(2, N'recipe', N'noun', N'/ˈresəpi/', N'công thức nấu ăn', N'B1', N'Food/Fruits'),
(2, N'flavor', N'noun', N'/ˈfleɪvər/', N'hương vị', N'B1', N'Food/Fruits'),
(2, N'vegetarian', N'adjective', N'/ˌvedʒəˈteriən/', N'ăn chay', N'B1', N'Food/Fruits'),
(2, N'protein', N'noun', N'/ˈproʊtiːn/', N'chất đạm', N'B2', N'Food/Fruits'),
(2, N'carbohydrate', N'noun', N'/ˌkɑːrboʊˈhaɪdreɪt/', N'tinh bột', N'C1', N'Food/Fruits'),
(2, N'dairy', N'noun', N'/ˈderi/', N'sản phẩm từ sữa', N'B2', N'Food/Fruits'),
(2, N'seafood', N'noun', N'/ˈsiːfuːd/', N'hải sản', N'B1', N'Food/Fruits'),
(2, N'dessert', N'noun', N'/dɪˈzɜːrt/', N'món tráng miệng', N'B1', N'Food/Fruits'),
(2, N'freshly', N'adverb', N'/ˈfreʃli/', N'một cách tươi mới', N'B1', N'Food/Fruits'),
(2, N'spicy', N'adjective', N'/ˈspaɪsi/', N'cay', N'B1', N'Food/Fruits'),
(1, N'coherence', N'noun', N'/koʊˈhɪrəns/', N'tính mạch lạc', N'C1', N'Academic/IELTS General'),
(1, N'cohesion', N'noun', N'/koʊˈhiːʒn/', N'tính liên kết', N'C1', N'Academic/IELTS General'),
(1, N'paraphrase', N'verb', N'/ˈpærəfreɪz/', N'diễn đạt lại', N'B2', N'Academic/IELTS General'),
(1, N'inference', N'noun', N'/ˈɪnfərəns/', N'suy luận', N'C1', N'Academic/IELTS General'),
(1, N'evidence', N'noun', N'/ˈevɪdəns/', N'bằng chứng', N'B2', N'Academic/IELTS General'),
(1, N'argument', N'noun', N'/ˈɑːrɡjumənt/', N'luận điểm', N'B2', N'Academic/IELTS General'),
(1, N'analysis', N'noun', N'/əˈnæləsɪs/', N'phân tích', N'B2', N'Academic/IELTS General'),
(1, N'context', N'noun', N'/ˈkɑːntekst/', N'ngữ cảnh', N'B2', N'Academic/IELTS General'),
(1, N'criterion', N'noun', N'/kraɪˈtɪriən/', N'tiêu chí', N'C1', N'Academic/IELTS General'),
(1, N'fluency', N'noun', N'/ˈfluːənsi/', N'độ trôi chảy', N'B2', N'Academic/IELTS General'),
(1, N'pronunciation', N'noun', N'/prəˌnʌnsiˈeɪʃn/', N'phát âm', N'B1', N'Academic/IELTS General'),
(1, N'vocabulary', N'noun', N'/voʊˈkæbjəleri/', N'từ vựng', N'B1', N'Academic/IELTS General'),
(1, N'grammar', N'noun', N'/ˈɡræmər/', N'ngữ pháp', N'B1', N'Academic/IELTS General'),
(1, N'overview', N'noun', N'/ˈoʊvərvjuː/', N'tổng quan', N'B2', N'Academic/IELTS General'),
(1, N'summary', N'noun', N'/ˈsʌməri/', N'tóm tắt', N'B1', N'Academic/IELTS General'),
(1, N'comparison', N'noun', N'/kəmˈpærɪsn/', N'sự so sánh', N'B2', N'Academic/IELTS General'),
(1, N'trend', N'noun', N'/trend/', N'xu hướng', N'B2', N'Academic/IELTS General'),
(1, N'task', N'noun', N'/tæsk/', N'nhiệm vụ', N'B1', N'Academic/IELTS General'),
(1, N'response', N'noun', N'/rɪˈspɑːns/', N'câu trả lời', N'B1', N'Academic/IELTS General'),
(1, N'accuracy', N'noun', N'/ˈækjərəsi/', N'độ chính xác', N'B2', N'Academic/IELTS General'),
(1, N'analytically', N'adverb', N'/ˌænəˈlɪtɪkli/', N'một cách phân tích', N'C1', N'Academic/IELTS General'),
(1, N'relevant', N'adjective', N'/ˈreləvənt/', N'liên quan', N'B2', N'Academic/IELTS General');
GO

INSERT INTO dbo.DeThi (TenDeThi, FileDuLieu, NgayTao)
VALUES
(N'IELTS Practice Test 1', NULL, GETDATE()),
(N'IELTS Practice Test 2', NULL, GETDATE());

INSERT INTO dbo.CauHoi (NoiDung, DapAn, NhanKyNang, BandLevel)
VALUES
(N'Listen to a conversation about booking accommodation and identify the final price.', N'120 dollars', N'Listening', 5.5),
(N'Read the passage about renewable energy and choose the best heading.', N'Benefits of renewable sources', N'Reading', 6.0),
(N'Write an overview for a line graph showing monthly revenue changes.', N'Clear overview with main trend', N'Writing', 6.5),
(N'Describe a time when teamwork helped you achieve a goal.', N'Personal response', N'Speaking', 5.5),
(N'Explain why cybersecurity has become important for modern businesses.', N'Because digital systems store sensitive data', N'Reading', 6.5),
(N'Compare two views about online education and give your opinion.', N'Balanced opinion essay', N'Writing', 7.0);

INSERT INTO dbo.BaiTap (MaLopHoc, TieuDe, MoTa, Deadline, FileDinhKem, NgayTao)
VALUES
(1, N'Writing Task 1 - Biểu đồ đường', N'Viết báo cáo 150 từ về xu hướng doanh thu.', DATEADD(day, 7, GETDATE()), NULL, GETDATE()),
(2, N'Speaking Part 2 - Teamwork', N'Chuẩn bị câu trả lời 2 phút về làm việc nhóm.', DATEADD(day, 5, GETDATE()), NULL, GETDATE());

INSERT INTO dbo.ChiTiet_NopBai (MaNguoiDung, MaBaiTap, FileBaiLam, ThoiGianNop, TrangThaiNop, DiemSo, NhanXet)
VALUES
(3, 1, N'an_task1.docx', DATEADD(day, -1, GETDATE()), N'Đã chấm', 6.0, N'Bố cục rõ, cần cải thiện từ vựng.'),
(4, 1, NULL, NULL, N'Chưa nộp', NULL, NULL),
(18, 2, N'anh_speaking.mp3', DATEADD(hour, -8, GETDATE()), N'Đã nộp', NULL, NULL);

INSERT INTO dbo.BuoiHoc (MaLopHoc, NgayHoc)
VALUES
(1, CONVERT(date, DATEADD(day, -7, GETDATE()))),
(1, CONVERT(date, DATEADD(day, -2, GETDATE()))),
(2, CONVERT(date, DATEADD(day, -6, GETDATE()))),
(2, CONVERT(date, DATEADD(day, -1, GETDATE())));

INSERT INTO dbo.ChiTiet_DiemDanh (MaNguoiDung, MaBuoiHoc, TrangThai, LyDoVang)
VALUES
(3, 1, N'Có mặt', NULL),
(4, 1, N'Vắng', N'Bận gia đình'),
(5, 1, N'Đi trễ', NULL),
(3, 2, N'Có mặt', NULL),
(4, 2, N'Có mặt', NULL),
(18, 3, N'Có mặt', NULL),
(19, 3, N'Vắng', NULL),
(18, 4, N'Có mặt', NULL),
(19, 4, N'Có mặt', NULL);

INSERT INTO dbo.DotKiemTra (MaLopHoc, MaDeThi, TenDotKiemTra, NgayKiemTra)
VALUES
(1, 1, N'Midterm 1', CONVERT(date, DATEADD(day, -20, GETDATE()))),
(2, 2, N'Midterm 1', CONVERT(date, DATEADD(day, -18, GETDATE())));

INSERT INTO dbo.ChiTiet_DiemSo (MaNguoiDung, MaDotKiemTra, DiemL, DiemR, DiemW, DiemS, DiemTong, NhanXet)
VALUES
(3, 1, 5.5, 6.0, 5.5, 6.0, 6.0, N'Cần tăng độ chính xác ngữ pháp.'),
(4, 1, 5.0, 5.5, 5.0, 5.5, 5.5, N'Nên luyện thêm đọc hiểu.'),
(18, 2, 6.5, 7.0, 6.0, 6.5, 6.5, N'Phản xạ nói tốt.'),
(19, 2, 6.0, 6.5, 6.0, 6.0, 6.0, N'Cần mở rộng ý trong Writing.');

INSERT INTO dbo.ThanhToanHocPhi
    (MaNguoiDung, MaLopHoc, SoTien, SoTienGoc, PhanTramGiam, SoTienGiam, SoTienCuoi, ThongTinNganHang, NgayTao, HanThanhToan, TrangThai)
VALUES
(3, 1, 2400000, 3000000, 20, 600000, 2400000, N'VCB 012345678 - Trung tâm IELTS', DATEADD(day, -5, GETDATE()), DATEADD(day, 5, GETDATE()), N'Đã thanh toán'),
(4, 1, 3000000, 3000000, 0, 0, 3000000, N'VCB 012345678 - Trung tâm IELTS', DATEADD(day, -4, GETDATE()), DATEADD(day, 6, GETDATE()), N'Chờ thanh toán'),
(18, 2, 2800000, 3500000, 20, 700000, 2800000, N'VCB 012345678 - Trung tâm IELTS', DATEADD(month, -1, GETDATE()), DATEADD(day, -18, GETDATE()), N'Đã thanh toán'),
(19, 2, 3500000, 3500000, 0, 0, 3500000, N'VCB 012345678 - Trung tâm IELTS', DATEADD(day, -3, GETDATE()), DATEADD(day, 7, GETDATE()), N'Đã thanh toán');
GO
