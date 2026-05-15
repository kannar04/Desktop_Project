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
    CONSTRAINT PK_ChiTiet_LopHoc PRIMARY KEY (MaNguoiDung, MaLopHoc),
    CONSTRAINT FK_CTLH_NguoiDung FOREIGN KEY (MaNguoiDung) REFERENCES dbo.NguoiDung(MaNguoiDung) ON DELETE CASCADE,
    CONSTRAINT FK_CTLH_LopHoc FOREIGN KEY (MaLopHoc) REFERENCES dbo.LopHoc(MaLopHoc) ON DELETE CASCADE
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
    CONSTRAINT CK_CauHoi_KyNang CHECK (NhanKyNang IN (N'Listening', N'Reading', N'Writing', N'Speaking'))
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
    CONSTRAINT FK_TuVung_LopHoc FOREIGN KEY (MaLopHoc) REFERENCES dbo.LopHoc(MaLopHoc) ON DELETE CASCADE,
    CONSTRAINT UQ_TuVung_Lop UNIQUE (MaLopHoc, TuTiengAnh)
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
    SoTien DECIMAL(18,2) NOT NULL,
    ThongTinNganHang NVARCHAR(300) NOT NULL,
    NgayTao DATETIME NOT NULL CONSTRAINT DF_HocPhi_NgayTao DEFAULT GETDATE(),
    HanThanhToan DATETIME NOT NULL,
    TrangThai NVARCHAR(40) NOT NULL,
    CONSTRAINT FK_HocPhi_NguoiDung FOREIGN KEY (MaNguoiDung) REFERENCES dbo.NguoiDung(MaNguoiDung) ON DELETE CASCADE
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
(N'HocSinh', N'Nguyễn Văn An', '2005-01-10', N'0911111111', N'an@example.com', N'Band 4.5', N'an', N'123456'),
(N'HocSinh', N'Trần Thị Bình', '2005-03-15', N'0922222222', N'binh@example.com', N'Band 5.0', N'binh', N'123456');

INSERT INTO dbo.LopHoc (MaGiaoVien, TenLop, NhomTrinhDo, LichHoc)
VALUES (2, N'Lớp IELTS T2-T4', N'Band 4.5-5.5', N'Thứ 2 - Thứ 4, 18:00');

INSERT INTO dbo.ChiTiet_LopHoc (MaNguoiDung, MaLopHoc)
VALUES (3, 1), (4, 1);
GO
