-- NON-DESTRUCTIVE SETUP SCRIPT.
-- Creates the QuanLyLopIELTS database and initial schema only when the schema is missing.
-- For a full destructive rebuild, run ResetDatabase.sql instead.

IF DB_ID(N'QuanLyLopIELTS') IS NULL
BEGIN
    CREATE DATABASE QuanLyLopIELTS;
END
GO

USE QuanLyLopIELTS;
GO

-- Each table and seed block below is guarded so the script can be rerun safely.

IF OBJECT_ID(N'dbo.NguoiDung', N'U') IS NULL
BEGIN
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
END

IF OBJECT_ID(N'dbo.LopHoc', N'U') IS NULL
BEGIN
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
END

IF OBJECT_ID(N'dbo.ChiTiet_LopHoc', N'U') IS NULL
BEGIN
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
END

IF OBJECT_ID(N'dbo.TaiLieu', N'U') IS NULL
BEGIN
CREATE TABLE dbo.TaiLieu
(
    MaTaiLieu INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_TaiLieu PRIMARY KEY,
    MaLopHoc INT NOT NULL,
    TenChuDe NVARCHAR(150) NOT NULL,
    NoiDungMoTa NVARCHAR(1000) NULL,
    DuongDanFile NVARCHAR(500) NULL,
    VideoLink NVARCHAR(500) NULL,
    AudioPath NVARCHAR(500) NULL,
    NhanKyNang NVARCHAR(30) NOT NULL,
    LoaiFile NVARCHAR(30) NULL,
    TenFileGoc NVARCHAR(255) NULL,
    DuongDanLocal NVARCHAR(500) NULL,
    DuongDanCloud NVARCHAR(500) NULL,
    ThumbnailPath NVARCHAR(500) NULL,
    NgayCapNhat DATETIME NOT NULL CONSTRAINT DF_TaiLieu_NgayCapNhat DEFAULT GETDATE(),
    CONSTRAINT FK_TaiLieu_LopHoc FOREIGN KEY (MaLopHoc) REFERENCES dbo.LopHoc(MaLopHoc) ON DELETE CASCADE,
    CONSTRAINT CK_TaiLieu_KyNang CHECK (NhanKyNang IN (N'Listening', N'Reading', N'Writing', N'Speaking'))
);
END

IF OBJECT_ID(N'dbo.BaiTap', N'U') IS NULL
BEGIN
CREATE TABLE dbo.BaiTap
(
    MaBaiTap INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_BaiTap PRIMARY KEY,
    MaLopHoc INT NOT NULL,
    TieuDe NVARCHAR(150) NOT NULL,
    MoTa NVARCHAR(1500) NOT NULL,
    Deadline DATETIME NOT NULL,
    FileDinhKem NVARCHAR(500) NULL,
    LoaiFile NVARCHAR(30) NULL,
    TenFileGoc NVARCHAR(255) NULL,
    DuongDanLocal NVARCHAR(500) NULL,
    NgayTao DATETIME NOT NULL CONSTRAINT DF_BaiTap_NgayTao DEFAULT GETDATE(),
    CONSTRAINT FK_BaiTap_LopHoc FOREIGN KEY (MaLopHoc) REFERENCES dbo.LopHoc(MaLopHoc) ON DELETE CASCADE
);
END

IF OBJECT_ID(N'dbo.ChiTiet_NopBai', N'U') IS NULL
BEGIN
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
END

IF OBJECT_ID(N'dbo.BuoiHoc', N'U') IS NULL
BEGIN
CREATE TABLE dbo.BuoiHoc
(
    MaBuoiHoc INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_BuoiHoc PRIMARY KEY,
    MaLopHoc INT NOT NULL,
    NgayHoc DATE NOT NULL,
    CONSTRAINT FK_BuoiHoc_LopHoc FOREIGN KEY (MaLopHoc) REFERENCES dbo.LopHoc(MaLopHoc) ON DELETE CASCADE,
    CONSTRAINT UQ_BuoiHoc UNIQUE (MaLopHoc, NgayHoc)
);
END

IF OBJECT_ID(N'dbo.ChiTiet_DiemDanh', N'U') IS NULL
BEGIN
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
END

IF OBJECT_ID(N'dbo.DeThi', N'U') IS NULL
BEGIN
CREATE TABLE dbo.DeThi
(
    MaDeThi INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_DeThi PRIMARY KEY,
    TenDeThi NVARCHAR(150) NOT NULL,
    KyNang NVARCHAR(30) NULL,
    BandLevel DECIMAL(3,1) NULL,
    BandTu DECIMAL(3,1) NULL,
    BandDen DECIMAL(3,1) NULL,
    MoTa NVARCHAR(MAX) NULL,
    FileDuLieu NVARCHAR(500) NULL,
    AudioPath NVARCHAR(500) NULL,
    ImagePath NVARCHAR(500) NULL,
    NgayTao DATETIME NOT NULL CONSTRAINT DF_DeThi_NgayTao DEFAULT GETDATE(),
    TrangThai NVARCHAR(30) NOT NULL CONSTRAINT DF_DeThi_TrangThai DEFAULT N'DangTao'
);
END

IF OBJECT_ID(N'dbo.ReadingPassage', N'U') IS NULL
BEGIN
CREATE TABLE dbo.ReadingPassage
(
    PassageId INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_ReadingPassage PRIMARY KEY,
    PassageCode NVARCHAR(50) NULL,
    Title NVARCHAR(200) NOT NULL,
    Content NVARCHAR(MAX) NOT NULL,
    ImagePath NVARCHAR(500) NULL,
    BandLevel DECIMAL(3,1) NULL,
    Topic NVARCHAR(150) NULL,
    NgayTao DATETIME NOT NULL CONSTRAINT DF_ReadingPassage_NgayTao DEFAULT GETDATE(),
    CreatedAt DATETIME NOT NULL CONSTRAINT DF_ReadingPassage_CreatedAt DEFAULT GETDATE()
);
END

IF OBJECT_ID(N'dbo.ListeningSection', N'U') IS NULL
BEGIN
CREATE TABLE dbo.ListeningSection
(
    SectionId INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_ListeningSection PRIMARY KEY,
    SectionCode NVARCHAR(50) NULL,
    Title NVARCHAR(200) NOT NULL,
    SectionNumber INT NOT NULL,
    PartNo INT NOT NULL CONSTRAINT DF_ListeningSection_PartNo DEFAULT 1,
    AudioPath NVARCHAR(500) NULL,
    Transcript NVARCHAR(MAX) NULL,
    BandLevel DECIMAL(3,1) NULL,
    Topic NVARCHAR(150) NULL,
    NgayTao DATETIME NOT NULL CONSTRAINT DF_ListeningSection_NgayTao DEFAULT GETDATE(),
    CreatedAt DATETIME NOT NULL CONSTRAINT DF_ListeningSection_CreatedAt DEFAULT GETDATE(),
    CONSTRAINT CK_ListeningSection_Number CHECK (SectionNumber BETWEEN 1 AND 4)
);
END

IF OBJECT_ID(N'dbo.CauHoi', N'U') IS NULL
BEGIN
CREATE TABLE dbo.CauHoi
(
    MaCauHoi INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_CauHoi PRIMARY KEY,
    NoiDung NVARCHAR(MAX) NOT NULL,
    DapAn NVARCHAR(MAX) NULL,
    NhanKyNang NVARCHAR(30) NOT NULL,
    QuestionType NVARCHAR(80) NULL,
    OptionA NVARCHAR(500) NULL,
    OptionB NVARCHAR(500) NULL,
    OptionC NVARCHAR(500) NULL,
    OptionD NVARCHAR(500) NULL,
    AnswerKey NVARCHAR(500) NULL,
    Explanation NVARCHAR(MAX) NULL,
    PassageId INT NULL,
    SectionId INT NULL,
    BandLevel DECIMAL(3,1) NULL,
    CONSTRAINT CK_CauHoi_KyNang CHECK (NhanKyNang IN (N'Listening', N'Reading', N'Writing', N'Speaking')),
    CONSTRAINT CK_CauHoi_BandLevel CHECK (BandLevel IS NULL OR (BandLevel >= 0 AND BandLevel <= 9)),
    CONSTRAINT FK_CauHoi_ReadingPassage FOREIGN KEY (PassageId) REFERENCES dbo.ReadingPassage(PassageId),
    CONSTRAINT FK_CauHoi_ListeningSection FOREIGN KEY (SectionId) REFERENCES dbo.ListeningSection(SectionId)
);
END

IF OBJECT_ID(N'dbo.ChiTiet_DeThi', N'U') IS NULL
BEGIN
CREATE TABLE dbo.ChiTiet_DeThi
(
    MaDeThi INT NOT NULL,
    MaCauHoi INT NOT NULL,
    GroupType NVARCHAR(30) NULL,
    GroupId INT NULL,
    ThuTu INT NULL,
    Diem DECIMAL(5,2) NULL,
    GhiChu NVARCHAR(500) NULL,
    CONSTRAINT PK_ChiTiet_DeThi PRIMARY KEY (MaDeThi, MaCauHoi),
    CONSTRAINT FK_CTDT_DeThi FOREIGN KEY (MaDeThi) REFERENCES dbo.DeThi(MaDeThi) ON DELETE CASCADE,
    CONSTRAINT FK_CTDT_CauHoi FOREIGN KEY (MaCauHoi) REFERENCES dbo.CauHoi(MaCauHoi) ON DELETE CASCADE
);
END

IF OBJECT_ID(N'dbo.DotKiemTra', N'U') IS NULL
BEGIN
CREATE TABLE dbo.DotKiemTra
(
    MaDotKiemTra INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_DotKiemTra PRIMARY KEY,
    MaLopHoc INT NOT NULL,
    MaDeThi INT NULL,
    TenDotKiemTra NVARCHAR(150) NOT NULL,
    NgayKiemTra DATE NOT NULL,
    CONSTRAINT FK_DotKiemTra_LopHoc FOREIGN KEY (MaLopHoc) REFERENCES dbo.LopHoc(MaLopHoc) ON DELETE CASCADE,
    CONSTRAINT FK_DotKiemTra_DeThi FOREIGN KEY (MaDeThi) REFERENCES dbo.DeThi(MaDeThi) ON DELETE SET NULL
);
END

IF OBJECT_ID(N'dbo.ChiTiet_DiemSo', N'U') IS NULL
BEGIN
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
END

IF OBJECT_ID(N'dbo.TuVung', N'U') IS NULL
BEGIN
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
    CONSTRAINT CK_TuVung_CapDo CHECK (CapDo IN (N'A1', N'A2', N'B1', N'B2', N'C1', N'C2'))
);
END

IF OBJECT_ID(N'dbo.CK_TuVung_CapDo', N'C') IS NOT NULL
BEGIN
    ALTER TABLE dbo.TuVung DROP CONSTRAINT CK_TuVung_CapDo;
END

IF OBJECT_ID(N'dbo.TuVung', N'U') IS NOT NULL
   AND OBJECT_ID(N'dbo.CK_TuVung_CapDo', N'C') IS NULL
BEGIN
    ALTER TABLE dbo.TuVung
    ADD CONSTRAINT CK_TuVung_CapDo CHECK (CapDo IN (N'A1', N'A2', N'B1', N'B2', N'C1', N'C2'));
END

IF OBJECT_ID(N'dbo.TienTrinh_Flashcard', N'U') IS NULL
BEGIN
CREATE TABLE dbo.TienTrinh_Flashcard
(
    MaNguoiDung INT NOT NULL,
    MaTuVung INT NOT NULL,
    KetQua NVARCHAR(50) NOT NULL CONSTRAINT DF_Flashcard_KetQua DEFAULT N'Chưa học',
    CONSTRAINT PK_TienTrinh_Flashcard PRIMARY KEY (MaNguoiDung, MaTuVung),
    CONSTRAINT FK_Flashcard_NguoiDung FOREIGN KEY (MaNguoiDung) REFERENCES dbo.NguoiDung(MaNguoiDung) ON DELETE CASCADE,
    CONSTRAINT FK_Flashcard_TuVung FOREIGN KEY (MaTuVung) REFERENCES dbo.TuVung(MaTuVung) ON DELETE CASCADE
);
END

IF OBJECT_ID(N'dbo.ThongBao', N'U') IS NULL
BEGIN
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
END

IF OBJECT_ID(N'dbo.ChiTiet_ThongBao', N'U') IS NULL
BEGIN
CREATE TABLE dbo.ChiTiet_ThongBao
(
    MaThongBao INT NOT NULL,
    MaNguoiDung INT NOT NULL,
    DaDoc BIT NOT NULL CONSTRAINT DF_CTThongBao_DaDoc DEFAULT 0,
    CONSTRAINT PK_ChiTiet_ThongBao PRIMARY KEY (MaThongBao, MaNguoiDung),
    CONSTRAINT FK_CTThongBao_ThongBao FOREIGN KEY (MaThongBao) REFERENCES dbo.ThongBao(MaThongBao) ON DELETE CASCADE,
    CONSTRAINT FK_CTThongBao_NguoiDung FOREIGN KEY (MaNguoiDung) REFERENCES dbo.NguoiDung(MaNguoiDung) ON DELETE CASCADE
);
END

IF OBJECT_ID(N'dbo.ThanhToanHocPhi', N'U') IS NULL
BEGIN
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
    MaHoaDon NVARCHAR(50) NULL,
    PhuongThucThanhToan NVARCHAR(50) NULL,
    NgayThanhToan DATETIME NULL,
    TrangThai NVARCHAR(40) NOT NULL,
    CONSTRAINT FK_HocPhi_NguoiDung FOREIGN KEY (MaNguoiDung) REFERENCES dbo.NguoiDung(MaNguoiDung) ON DELETE CASCADE,
    CONSTRAINT FK_HocPhi_LopHoc FOREIGN KEY (MaLopHoc) REFERENCES dbo.LopHoc(MaLopHoc)
);
END

IF OBJECT_ID(N'dbo.NhatKyThanhToan', N'U') IS NULL
BEGIN
CREATE TABLE dbo.NhatKyThanhToan
(
    MaGiaoDich INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_NhatKyThanhToan PRIMARY KEY,
    MaThanhToan INT NOT NULL,
    PhuongThuc NVARCHAR(50) NOT NULL,
    SoTien DECIMAL(18,2) NOT NULL,
    NoiDungThanhToan NVARCHAR(300) NULL,
    MaGiaoDichNgoai NVARCHAR(100) NULL,
    PaymentUrl NVARCHAR(500) NULL,
    QrContent NVARCHAR(1000) NULL,
    TrangThai NVARCHAR(40) NOT NULL,
    NgayTao DATETIME NOT NULL CONSTRAINT DF_NhatKyThanhToan_NgayTao DEFAULT GETDATE(),
    NgayCapNhat DATETIME NULL,
    ReceiverEmail NVARCHAR(150) NULL,
    DebugStudentName NVARCHAR(120) NULL,
    DebugClassName NVARCHAR(120) NULL,
    DebugNote NVARCHAR(500) NULL,
    IsDebugPayment BIT NULL,
    PaymentEmailSent BIT NULL,
    PaymentEmailSentAt DATETIME NULL,
    PaymentEmailError NVARCHAR(1000) NULL,
    StatusEmailSent BIT NULL,
    StatusEmailSentAt DATETIME NULL,
    StatusEmailError NVARCHAR(1000) NULL,
    LastStatusUpdateAt DATETIME NULL,
    CONSTRAINT FK_NhatKyThanhToan_ThanhToanHocPhi FOREIGN KEY (MaThanhToan) REFERENCES dbo.ThanhToanHocPhi(MaThanhToan)
);
END

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
END

IF OBJECT_ID(N'dbo.NhatKyBaoCao', N'U') IS NULL
BEGIN
CREATE TABLE dbo.NhatKyBaoCao
(
    MaNhatKy INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_NhatKyBaoCao PRIMARY KEY,
    MaNguoiDung INT NOT NULL,
    LoaiBaoCao NVARCHAR(100) NOT NULL,
    TieuChi NVARCHAR(500) NULL,
    ThoiGianTao DATETIME NOT NULL CONSTRAINT DF_NhatKyBaoCao_ThoiGian DEFAULT GETDATE(),
    CONSTRAINT FK_NhatKyBaoCao_NguoiDung FOREIGN KEY (MaNguoiDung) REFERENCES dbo.NguoiDung(MaNguoiDung)
);
END

IF OBJECT_ID(N'dbo.ThanhToanHocPhi', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.ThanhToanHocPhi', N'MaHoaDon') IS NULL
BEGIN
    ALTER TABLE dbo.ThanhToanHocPhi ADD MaHoaDon NVARCHAR(50) NULL;
END

IF OBJECT_ID(N'dbo.ThanhToanHocPhi', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.ThanhToanHocPhi', N'PhuongThucThanhToan') IS NULL
BEGIN
    ALTER TABLE dbo.ThanhToanHocPhi ADD PhuongThucThanhToan NVARCHAR(50) NULL;
END

IF OBJECT_ID(N'dbo.ThanhToanHocPhi', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.ThanhToanHocPhi', N'NgayThanhToan') IS NULL
BEGIN
    ALTER TABLE dbo.ThanhToanHocPhi ADD NgayThanhToan DATETIME NULL;
END

IF OBJECT_ID(N'dbo.TaiLieu', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.TaiLieu', N'LoaiFile') IS NULL
BEGIN
    ALTER TABLE dbo.TaiLieu ADD LoaiFile NVARCHAR(30) NULL;
END

IF OBJECT_ID(N'dbo.TaiLieu', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.TaiLieu', N'TenFileGoc') IS NULL
BEGIN
    ALTER TABLE dbo.TaiLieu ADD TenFileGoc NVARCHAR(255) NULL;
END

IF OBJECT_ID(N'dbo.TaiLieu', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.TaiLieu', N'DuongDanLocal') IS NULL
BEGIN
    ALTER TABLE dbo.TaiLieu ADD DuongDanLocal NVARCHAR(500) NULL;
END

IF OBJECT_ID(N'dbo.TaiLieu', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.TaiLieu', N'DuongDanCloud') IS NULL
BEGIN
    ALTER TABLE dbo.TaiLieu ADD DuongDanCloud NVARCHAR(500) NULL;
END

IF OBJECT_ID(N'dbo.TaiLieu', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.TaiLieu', N'ThumbnailPath') IS NULL
BEGIN
    ALTER TABLE dbo.TaiLieu ADD ThumbnailPath NVARCHAR(500) NULL;
END

IF OBJECT_ID(N'dbo.TaiLieu', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.TaiLieu', N'AudioPath') IS NULL
BEGIN
    ALTER TABLE dbo.TaiLieu ADD AudioPath NVARCHAR(500) NULL;
END

IF OBJECT_ID(N'dbo.BaiTap', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.BaiTap', N'LoaiFile') IS NULL
BEGIN
    ALTER TABLE dbo.BaiTap ADD LoaiFile NVARCHAR(30) NULL;
END

IF OBJECT_ID(N'dbo.BaiTap', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.BaiTap', N'TenFileGoc') IS NULL
BEGIN
    ALTER TABLE dbo.BaiTap ADD TenFileGoc NVARCHAR(255) NULL;
END

IF OBJECT_ID(N'dbo.BaiTap', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.BaiTap', N'DuongDanLocal') IS NULL
BEGIN
    ALTER TABLE dbo.BaiTap ADD DuongDanLocal NVARCHAR(500) NULL;
END

IF OBJECT_ID(N'dbo.DeThi', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.DeThi', N'AudioPath') IS NULL
BEGIN
    ALTER TABLE dbo.DeThi ADD AudioPath NVARCHAR(500) NULL;
END

IF OBJECT_ID(N'dbo.DeThi', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.DeThi', N'ImagePath') IS NULL
BEGIN
    ALTER TABLE dbo.DeThi ADD ImagePath NVARCHAR(500) NULL;
END

IF OBJECT_ID(N'dbo.DeThi', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.DeThi', N'KyNang') IS NULL
BEGIN
    ALTER TABLE dbo.DeThi ADD KyNang NVARCHAR(30) NULL;
END

IF OBJECT_ID(N'dbo.DeThi', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.DeThi', N'BandTu') IS NULL
BEGIN
    ALTER TABLE dbo.DeThi ADD BandTu DECIMAL(3,1) NULL;
END

IF OBJECT_ID(N'dbo.DeThi', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.DeThi', N'BandDen') IS NULL
BEGIN
    ALTER TABLE dbo.DeThi ADD BandDen DECIMAL(3,1) NULL;
END

IF OBJECT_ID(N'dbo.DeThi', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.DeThi', N'BandLevel') IS NULL
BEGIN
    ALTER TABLE dbo.DeThi ADD BandLevel DECIMAL(3,1) NULL;
END

IF OBJECT_ID(N'dbo.DeThi', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.DeThi', N'MoTa') IS NULL
BEGIN
    ALTER TABLE dbo.DeThi ADD MoTa NVARCHAR(MAX) NULL;
END

IF OBJECT_ID(N'dbo.DeThi', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.DeThi', N'TrangThai') IS NULL
BEGIN
    ALTER TABLE dbo.DeThi ADD TrangThai NVARCHAR(30) NOT NULL CONSTRAINT DF_DeThi_TrangThai DEFAULT N'DangTao';
END

IF OBJECT_ID(N'dbo.ReadingPassage', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.ReadingPassage
    (
        PassageId INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_ReadingPassage PRIMARY KEY,
        PassageCode NVARCHAR(50) NULL,
        Title NVARCHAR(200) NOT NULL,
        Content NVARCHAR(MAX) NOT NULL,
        ImagePath NVARCHAR(500) NULL,
        BandLevel DECIMAL(3,1) NULL,
        Topic NVARCHAR(150) NULL,
        NgayTao DATETIME NOT NULL CONSTRAINT DF_ReadingPassage_NgayTao DEFAULT GETDATE(),
        CreatedAt DATETIME NOT NULL CONSTRAINT DF_ReadingPassage_CreatedAt DEFAULT GETDATE()
    );
END

IF OBJECT_ID(N'dbo.ReadingPassage', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.ReadingPassage', N'PassageCode') IS NULL
BEGIN
    ALTER TABLE dbo.ReadingPassage ADD PassageCode NVARCHAR(50) NULL;
END

IF OBJECT_ID(N'dbo.ReadingPassage', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.ReadingPassage', N'Topic') IS NULL
BEGIN
    ALTER TABLE dbo.ReadingPassage ADD Topic NVARCHAR(150) NULL;
END

IF OBJECT_ID(N'dbo.ReadingPassage', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.ReadingPassage', N'CreatedAt') IS NULL
BEGIN
    ALTER TABLE dbo.ReadingPassage ADD CreatedAt DATETIME NOT NULL CONSTRAINT DF_ReadingPassage_CreatedAt DEFAULT GETDATE();
END

IF OBJECT_ID(N'dbo.ListeningSection', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.ListeningSection
    (
        SectionId INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_ListeningSection PRIMARY KEY,
        SectionCode NVARCHAR(50) NULL,
        Title NVARCHAR(200) NOT NULL,
        SectionNumber INT NOT NULL,
        PartNo INT NOT NULL CONSTRAINT DF_ListeningSection_PartNo DEFAULT 1,
        AudioPath NVARCHAR(500) NULL,
        Transcript NVARCHAR(MAX) NULL,
        BandLevel DECIMAL(3,1) NULL,
        Topic NVARCHAR(150) NULL,
        NgayTao DATETIME NOT NULL CONSTRAINT DF_ListeningSection_NgayTao DEFAULT GETDATE(),
        CreatedAt DATETIME NOT NULL CONSTRAINT DF_ListeningSection_CreatedAt DEFAULT GETDATE(),
        CONSTRAINT CK_ListeningSection_Number CHECK (SectionNumber BETWEEN 1 AND 4)
    );
END

IF OBJECT_ID(N'dbo.ListeningSection', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.ListeningSection', N'SectionCode') IS NULL
BEGIN
    ALTER TABLE dbo.ListeningSection ADD SectionCode NVARCHAR(50) NULL;
END

IF OBJECT_ID(N'dbo.ListeningSection', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.ListeningSection', N'PartNo') IS NULL
BEGIN
    ALTER TABLE dbo.ListeningSection ADD PartNo INT NOT NULL CONSTRAINT DF_ListeningSection_PartNo DEFAULT 1;
END

IF OBJECT_ID(N'dbo.ListeningSection', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.ListeningSection', N'Topic') IS NULL
BEGIN
    ALTER TABLE dbo.ListeningSection ADD Topic NVARCHAR(150) NULL;
END

IF OBJECT_ID(N'dbo.ListeningSection', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.ListeningSection', N'CreatedAt') IS NULL
BEGIN
    ALTER TABLE dbo.ListeningSection ADD CreatedAt DATETIME NOT NULL CONSTRAINT DF_ListeningSection_CreatedAt DEFAULT GETDATE();
END

IF OBJECT_ID(N'dbo.CauHoi', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.CauHoi', N'QuestionType') IS NULL
BEGIN
    ALTER TABLE dbo.CauHoi ADD QuestionType NVARCHAR(80) NULL;
END

IF OBJECT_ID(N'dbo.CauHoi', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.CauHoi', N'OptionA') IS NULL
BEGIN
    ALTER TABLE dbo.CauHoi ADD OptionA NVARCHAR(500) NULL;
END

IF OBJECT_ID(N'dbo.CauHoi', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.CauHoi', N'OptionB') IS NULL
BEGIN
    ALTER TABLE dbo.CauHoi ADD OptionB NVARCHAR(500) NULL;
END

IF OBJECT_ID(N'dbo.CauHoi', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.CauHoi', N'OptionC') IS NULL
BEGIN
    ALTER TABLE dbo.CauHoi ADD OptionC NVARCHAR(500) NULL;
END

IF OBJECT_ID(N'dbo.CauHoi', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.CauHoi', N'OptionD') IS NULL
BEGIN
    ALTER TABLE dbo.CauHoi ADD OptionD NVARCHAR(500) NULL;
END

IF OBJECT_ID(N'dbo.CauHoi', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.CauHoi', N'AnswerKey') IS NULL
BEGIN
    ALTER TABLE dbo.CauHoi ADD AnswerKey NVARCHAR(500) NULL;
END

IF OBJECT_ID(N'dbo.CauHoi', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.CauHoi', N'Explanation') IS NULL
BEGIN
    ALTER TABLE dbo.CauHoi ADD Explanation NVARCHAR(MAX) NULL;
END

IF OBJECT_ID(N'dbo.CauHoi', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.CauHoi', N'PassageId') IS NULL
BEGIN
    ALTER TABLE dbo.CauHoi ADD PassageId INT NULL;
END

IF OBJECT_ID(N'dbo.CauHoi', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.CauHoi', N'SectionId') IS NULL
BEGIN
    ALTER TABLE dbo.CauHoi ADD SectionId INT NULL;
END

IF OBJECT_ID(N'dbo.CK_CauHoi_Context', N'C') IS NOT NULL
BEGIN
    ALTER TABLE dbo.CauHoi DROP CONSTRAINT CK_CauHoi_Context;
END

IF OBJECT_ID(N'dbo.ChiTiet_DeThi', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.ChiTiet_DeThi', N'GroupType') IS NULL
BEGIN
    ALTER TABLE dbo.ChiTiet_DeThi ADD GroupType NVARCHAR(30) NULL;
END

IF OBJECT_ID(N'dbo.ChiTiet_DeThi', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.ChiTiet_DeThi', N'GroupId') IS NULL
BEGIN
    ALTER TABLE dbo.ChiTiet_DeThi ADD GroupId INT NULL;
END

IF OBJECT_ID(N'dbo.ChiTiet_DeThi', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.ChiTiet_DeThi', N'ThuTu') IS NULL
BEGIN
    ALTER TABLE dbo.ChiTiet_DeThi ADD ThuTu INT NULL;
END

IF OBJECT_ID(N'dbo.ChiTiet_DeThi', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.ChiTiet_DeThi', N'Diem') IS NULL
BEGIN
    ALTER TABLE dbo.ChiTiet_DeThi ADD Diem DECIMAL(5,2) NULL;
END

IF OBJECT_ID(N'dbo.ChiTiet_DeThi', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.ChiTiet_DeThi', N'GhiChu') IS NULL
BEGIN
    ALTER TABLE dbo.ChiTiet_DeThi ADD GhiChu NVARCHAR(500) NULL;
END

IF OBJECT_ID(N'dbo.FK_DotKiemTra_DeThi', N'F') IS NOT NULL
BEGIN
    ALTER TABLE dbo.DotKiemTra DROP CONSTRAINT FK_DotKiemTra_DeThi;
END

IF OBJECT_ID(N'dbo.DotKiemTra', N'U') IS NOT NULL
   AND OBJECT_ID(N'dbo.FK_DotKiemTra_DeThi', N'F') IS NULL
BEGIN
    ALTER TABLE dbo.DotKiemTra
    ADD CONSTRAINT FK_DotKiemTra_DeThi
        FOREIGN KEY (MaDeThi) REFERENCES dbo.DeThi(MaDeThi) ON DELETE SET NULL;
END

IF OBJECT_ID(N'dbo.NhatKyThanhToan', N'U') IS NOT NULL
    AND OBJECT_ID(N'dbo.FK_NhatKyThanhToan_ThanhToanHocPhi', N'F') IS NULL
BEGIN
    ALTER TABLE dbo.NhatKyThanhToan
    ADD CONSTRAINT FK_NhatKyThanhToan_ThanhToanHocPhi
        FOREIGN KEY (MaThanhToan) REFERENCES dbo.ThanhToanHocPhi(MaThanhToan);
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_GetReadingPassageCandidates
    @BandTu DECIMAL(3,1),
    @BandDen DECIMAL(3,1)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT p.PassageId, p.Title, p.Content, p.ImagePath, p.BandLevel, COUNT(q.MaCauHoi) AS SoCauHoi
    FROM dbo.ReadingPassage p
    INNER JOIN dbo.CauHoi q ON q.PassageId = p.PassageId AND q.NhanKyNang = N'Reading'
    WHERE (p.BandLevel IS NULL OR p.BandLevel BETWEEN @BandTu AND @BandDen)
      AND (q.BandLevel IS NULL OR q.BandLevel BETWEEN @BandTu AND @BandDen)
    GROUP BY p.PassageId, p.Title, p.Content, p.ImagePath, p.BandLevel
    HAVING COUNT(q.MaCauHoi) > 0;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_GetListeningSectionCandidates
    @BandTu DECIMAL(3,1),
    @BandDen DECIMAL(3,1)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT s.SectionId, s.Title, s.SectionNumber, s.AudioPath, s.Transcript, s.BandLevel, COUNT(q.MaCauHoi) AS SoCauHoi
    FROM dbo.ListeningSection s
    INNER JOIN dbo.CauHoi q ON q.SectionId = s.SectionId AND q.NhanKyNang = N'Listening'
    WHERE (s.BandLevel IS NULL OR s.BandLevel BETWEEN @BandTu AND @BandDen)
      AND (q.BandLevel IS NULL OR q.BandLevel BETWEEN @BandTu AND @BandDen)
    GROUP BY s.SectionId, s.Title, s.SectionNumber, s.AudioPath, s.Transcript, s.BandLevel
    HAVING COUNT(q.MaCauHoi) > 0;
END
GO

IF OBJECT_ID(N'dbo.NguoiDung', N'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM dbo.NguoiDung)
BEGIN
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

END

IF OBJECT_ID(N'dbo.LopHoc', N'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM dbo.LopHoc)
BEGIN
INSERT INTO dbo.LopHoc (MaGiaoVien, TenLop, NhomTrinhDo, LichHoc)
VALUES
(2, N'IELTS Cơ Bản', N'Band 4.0-5.5', N'Thứ 2 - Thứ 4, 18:00'),
(2, N'IELTS Nâng Cao', N'Band 5.5-7.0', N'Thứ 3 - Thứ 5, 19:30');

END

IF OBJECT_ID(N'dbo.ChiTiet_LopHoc', N'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM dbo.ChiTiet_LopHoc)
BEGIN
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
END
GO

IF OBJECT_ID(N'dbo.TuVung', N'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM dbo.TuVung)
BEGIN
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
END
GO

IF OBJECT_ID(N'dbo.TuVung', N'U') IS NOT NULL
BEGIN
DECLARE @BasicClassId INT = COALESCE((SELECT TOP 1 MaLopHoc FROM dbo.LopHoc WHERE NhomTrinhDo LIKE N'%4.0-5.5%' ORDER BY MaLopHoc), 1);
DECLARE @AdvancedClassId INT = COALESCE((SELECT TOP 1 MaLopHoc FROM dbo.LopHoc WHERE NhomTrinhDo LIKE N'%5.5-7.0%' ORDER BY MaLopHoc), 2);

INSERT INTO dbo.TuVung (MaLopHoc, TuTiengAnh, TuLoai, PhienAm, Nghia, CapDo, ChuDe)
SELECT @BasicClassId, v.TuTiengAnh, v.TuLoai, v.PhienAm, v.Nghia, v.CapDo, v.ChuDe
FROM (VALUES
(N'family', N'noun', N'/family/', N'gia dinh', N'A1', N'Academic/IELTS General'),
(N'friend', N'noun', N'/friend/', N'ban be', N'A1', N'Academic/IELTS General'),
(N'house', N'noun', N'/house/', N'ngoi nha', N'A1', N'Academic/IELTS General'),
(N'room', N'noun', N'/room/', N'can phong', N'A1', N'Academic/IELTS General'),
(N'kitchen', N'noun', N'/kitchen/', N'nha bep', N'A1', N'Academic/IELTS General'),
(N'school', N'noun', N'/school/', N'truong hoc', N'A1', N'Education'),
(N'teacher', N'noun', N'/teacher/', N'giao vien', N'A1', N'Education'),
(N'student', N'noun', N'/student/', N'hoc sinh', N'A1', N'Education'),
(N'book', N'noun', N'/book/', N'quyen sach', N'A1', N'Education'),
(N'pen', N'noun', N'/pen/', N'but', N'A1', N'Education'),
(N'table', N'noun', N'/table/', N'cai ban', N'A1', N'Academic/IELTS General'),
(N'chair', N'noun', N'/chair/', N'ghe', N'A1', N'Academic/IELTS General'),
(N'window', N'noun', N'/window/', N'cua so', N'A1', N'Academic/IELTS General'),
(N'door', N'noun', N'/door/', N'cua ra vao', N'A1', N'Academic/IELTS General'),
(N'water', N'noun', N'/water/', N'nuoc', N'A1', N'Food/Fruits'),
(N'food', N'noun', N'/food/', N'thuc an', N'A1', N'Food/Fruits'),
(N'breakfast', N'noun', N'/breakfast/', N'bua sang', N'A1', N'Food/Fruits'),
(N'lunch', N'noun', N'/lunch/', N'bua trua', N'A1', N'Food/Fruits'),
(N'dinner', N'noun', N'/dinner/', N'bua toi', N'A1', N'Food/Fruits'),
(N'coffee', N'noun', N'/coffee/', N'ca phe', N'A1', N'Food/Fruits'),
(N'tea', N'noun', N'/tea/', N'tra', N'A1', N'Food/Fruits'),
(N'milk', N'noun', N'/milk/', N'sua', N'A1', N'Food/Fruits'),
(N'bread', N'noun', N'/bread/', N'banh mi', N'A1', N'Food/Fruits'),
(N'rice', N'noun', N'/rice/', N'gao, com', N'A1', N'Food/Fruits'),
(N'egg', N'noun', N'/egg/', N'trung', N'A1', N'Food/Fruits'),
(N'bus', N'noun', N'/bus/', N'xe buyt', N'A1', N'Travel'),
(N'car', N'noun', N'/car/', N'xe hoi', N'A1', N'Travel'),
(N'bike', N'noun', N'/bike/', N'xe dap', N'A1', N'Travel'),
(N'train', N'noun', N'/train/', N'tau hoa', N'A1', N'Travel'),
(N'street', N'noun', N'/street/', N'duong pho', N'A1', N'Travel'),
(N'city', N'noun', N'/city/', N'thanh pho', N'A1', N'Travel'),
(N'village', N'noun', N'/village/', N'lang que', N'A1', N'Travel'),
(N'park', N'noun', N'/park/', N'cong vien', N'A1', N'Environment'),
(N'shop', N'noun', N'/shop/', N'cua hang', N'A1', N'Business'),
(N'marketplace', N'noun', N'/marketplace/', N'khu cho', N'A1', N'Business'),
(N'doctor', N'noun', N'/doctor/', N'bac si', N'A1', N'Health'),
(N'nurse', N'noun', N'/nurse/', N'y ta', N'A1', N'Health'),
(N'phone', N'noun', N'/phone/', N'dien thoai', N'A1', N'Technology'),
(N'computer desk', N'noun', N'/computer desk/', N'ban may tinh', N'A1', N'Technology'),
(N'bag', N'noun', N'/bag/', N'cai tui', N'A1', N'Academic/IELTS General'),
(N'shirt', N'noun', N'/shirt/', N'ao so mi', N'A1', N'Academic/IELTS General'),
(N'shoes', N'noun', N'/shoes/', N'giay', N'A1', N'Academic/IELTS General'),
(N'happy', N'adjective', N'/happy/', N'vui ve', N'A1', N'Academic/IELTS General'),
(N'sad', N'adjective', N'/sad/', N'buon', N'A1', N'Academic/IELTS General'),
(N'tired', N'adjective', N'/tired/', N'met moi', N'A1', N'Health'),
(N'hungry', N'adjective', N'/hungry/', N'doi bung', N'A1', N'Food/Fruits'),
(N'busy', N'adjective', N'/busy/', N'ban ron', N'A1', N'Business'),
(N'clean', N'adjective', N'/clean/', N'sach se', N'A1', N'Health'),
(N'easy', N'adjective', N'/easy/', N'de dang', N'A1', N'Education'),
(N'early', N'adverb', N'/early/', N'som', N'A1', N'Academic/IELTS General'),
(N'airport', N'noun', N'/airport/', N'san bay', N'A2', N'Travel'),
(N'ticket', N'noun', N'/ticket/', N've', N'A2', N'Travel'),
(N'map', N'noun', N'/map/', N'ban do', N'A2', N'Travel'),
(N'hotel', N'noun', N'/hotel/', N'khach san', N'A2', N'Travel'),
(N'suitcase', N'noun', N'/suitcase/', N'vali', N'A2', N'Travel'),
(N'weather', N'noun', N'/weather/', N'thoi tiet', N'A2', N'Environment'),
(N'cloudy', N'adjective', N'/cloudy/', N'nhieu may', N'A2', N'Environment'),
(N'sunny', N'adjective', N'/sunny/', N'nang', N'A2', N'Environment'),
(N'rainy', N'adjective', N'/rainy/', N'mua', N'A2', N'Environment'),
(N'windy', N'adjective', N'/windy/', N'co gio', N'A2', N'Environment'),
(N'appointment', N'noun', N'/appointment/', N'cuoc hen', N'A2', N'Health'),
(N'message', N'noun', N'/message/', N'tin nhan', N'A2', N'Technology'),
(N'address', N'noun', N'/address/', N'dia chi', N'A2', N'Travel'),
(N'neighbor', N'noun', N'/neighbor/', N'hang xom', N'A2', N'Academic/IELTS General'),
(N'weekend', N'noun', N'/weekend/', N'cuoi tuan', N'A2', N'Academic/IELTS General'),
(N'holiday', N'noun', N'/holiday/', N'ky nghi', N'A2', N'Travel'),
(N'hobby', N'noun', N'/hobby/', N'so thich', N'A2', N'Sports'),
(N'music', N'noun', N'/music/', N'am nhac', N'A2', N'Academic/IELTS General'),
(N'movie', N'noun', N'/movie/', N'phim', N'A2', N'Academic/IELTS General'),
(N'workout', N'noun', N'/workout/', N'buoi tap the duc', N'A2', N'Health'),
(N'healthy habit', N'noun', N'/healthy habit/', N'thoi quen lanh manh', N'A2', N'Health'),
(N'careful', N'adjective', N'/careful/', N'can than', N'A2', N'Academic/IELTS General'),
(N'useful', N'adjective', N'/useful/', N'huu ich', N'A2', N'Education'),
(N'common', N'adjective', N'/common/', N'pho bien', N'A2', N'Academic/IELTS General'),
(N'simple', N'adjective', N'/simple/', N'don gian', N'A2', N'Education'),
(N'describe', N'verb', N'/describe/', N'mo ta', N'A2', N'Academic/IELTS General'),
(N'explain', N'verb', N'/explain/', N'giai thich', N'A2', N'Education'),
(N'invite', N'verb', N'/invite/', N'moi', N'A2', N'Academic/IELTS General'),
(N'borrow', N'verb', N'/borrow/', N'muon', N'A2', N'Education'),
(N'return item', N'verb', N'/return item/', N'tra lai do', N'A2', N'Business'),
(N'improve', N'verb', N'/improve/', N'cai thien', N'B1', N'Education'),
(N'prepare', N'verb', N'/prepare/', N'chuan bi', N'B1', N'Education'),
(N'discuss', N'verb', N'/discuss/', N'thao luan', N'B1', N'Education'),
(N'suggest', N'verb', N'/suggest/', N'de xuat', N'B1', N'Academic/IELTS General'),
(N'compare', N'verb', N'/compare/', N'so sanh', N'B1', N'Academic/IELTS General'),
(N'decide', N'verb', N'/decide/', N'quyet dinh', N'B1', N'Academic/IELTS General'),
(N'develop', N'verb', N'/develop/', N'phat trien', N'B1', N'Business'),
(N'protect', N'verb', N'/protect/', N'bao ve', N'B1', N'Environment'),
(N'support', N'verb', N'/support/', N'ho tro', N'B1', N'Academic/IELTS General'),
(N'reduce', N'verb', N'/reduce/', N'giam', N'B1', N'Environment'),
(N'increase', N'verb', N'/increase/', N'tang', N'B1', N'Business'),
(N'achieve', N'verb', N'/achieve/', N'dat duoc', N'B1', N'Education'),
(N'avoid', N'verb', N'/avoid/', N'tranh', N'B1', N'Health'),
(N'depend', N'verb', N'/depend/', N'phu thuoc', N'B1', N'Academic/IELTS General'),
(N'include', N'verb', N'/include/', N'bao gom', N'B1', N'Academic/IELTS General'),
(N'manage time', N'verb', N'/manage time/', N'quan ly thoi gian', N'B1', N'Education'),
(N'notice', N'verb', N'/notice/', N'nhan thay', N'B1', N'Academic/IELTS General'),
(N'prefer', N'verb', N'/prefer/', N'thich hon', N'B1', N'Academic/IELTS General'),
(N'purpose', N'noun', N'/purpose/', N'muc dich', N'B1', N'Academic/IELTS General'),
(N'outcome', N'noun', N'/outcome/', N'ket qua', N'B1', N'Education')
) AS v(TuTiengAnh, TuLoai, PhienAm, Nghia, CapDo, ChuDe)
WHERE NOT EXISTS (SELECT 1 FROM dbo.TuVung tv WHERE tv.MaLopHoc = @BasicClassId AND tv.TuTiengAnh = v.TuTiengAnh);

INSERT INTO dbo.TuVung (MaLopHoc, TuTiengAnh, TuLoai, PhienAm, Nghia, CapDo, ChuDe)
SELECT @AdvancedClassId, v.TuTiengAnh, v.TuLoai, v.PhienAm, v.Nghia, v.CapDo, v.ChuDe
FROM (VALUES
(N'consistent', N'adjective', N'/consistent/', N'nhat quan', N'B2', N'Academic/IELTS General'),
(N'considerable', N'adjective', N'/considerable/', N'dang ke', N'B2', N'Academic/IELTS General'),
(N'demonstrate', N'verb', N'/demonstrate/', N'chung minh', N'B2', N'Education'),
(N'emphasize', N'verb', N'/emphasize/', N'nhan manh', N'B2', N'Academic/IELTS General'),
(N'evaluate', N'verb', N'/evaluate/', N'danh gia', N'B2', N'Education'),
(N'illustrate', N'verb', N'/illustrate/', N'minh hoa', N'B2', N'Academic/IELTS General'),
(N'interpret', N'verb', N'/interpret/', N'dien giai', N'B2', N'Academic/IELTS General'),
(N'maintain', N'verb', N'/maintain/', N'duy tri', N'B2', N'Health'),
(N'obtain', N'verb', N'/obtain/', N'dat duoc', N'B2', N'Education'),
(N'participate', N'verb', N'/participate/', N'tham gia', N'B2', N'Sports'),
(N'perspective', N'noun', N'/perspective/', N'goc nhin', N'B2', N'Academic/IELTS General'),
(N'potential', N'noun', N'/potential/', N'tiem nang', N'B2', N'Business'),
(N'priority', N'noun', N'/priority/', N'uu tien', N'B2', N'Business'),
(N'reliable', N'adjective', N'/reliable/', N'dang tin cay', N'B2', N'Technology'),
(N'significant', N'adjective', N'/significant/', N'quan trong', N'B2', N'Academic/IELTS General'),
(N'sufficient', N'adjective', N'/sufficient/', N'du', N'B2', N'Academic/IELTS General'),
(N'transform', N'verb', N'/transform/', N'bien doi', N'B2', N'Technology'),
(N'vary', N'verb', N'/vary/', N'thay doi', N'B2', N'Academic/IELTS General'),
(N'widespread', N'adjective', N'/widespread/', N'pho bien rong rai', N'B2', N'Environment'),
(N'approximately', N'adverb', N'/approximately/', N'xap xi', N'B2', N'Academic/IELTS General'),
(N'beneficial', N'adjective', N'/beneficial/', N'co loi', N'B2', N'Health'),
(N'challenging', N'adjective', N'/challenging/', N'thu thach', N'B2', N'Education'),
(N'complex', N'adjective', N'/complex/', N'phuc tap', N'B2', N'Technology'),
(N'efficient', N'adjective', N'/efficient/', N'hieu qua', N'B2', N'Business'),
(N'adaptable', N'adjective', N'/adaptable/', N'de thich nghi', N'B2', N'Business'),
(N'fundamental', N'adjective', N'/fundamental/', N'co ban, nen tang', N'B2', N'Education'),
(N'global', N'adjective', N'/global/', N'toan cau', N'B2', N'Environment'),
(N'logical', N'adjective', N'/logical/', N'hop ly', N'B2', N'Academic/IELTS General'),
(N'optional', N'adjective', N'/optional/', N'tuy chon', N'B2', N'Education'),
(N'practical', N'adjective', N'/practical/', N'thuc te', N'B2', N'Education'),
(N'previous', N'adjective', N'/previous/', N'truoc do', N'B2', N'Academic/IELTS General'),
(N'rapid', N'adjective', N'/rapid/', N'nhanh chong', N'B2', N'Technology'),
(N'regional', N'adjective', N'/regional/', N'thuoc khu vuc', N'B2', N'Travel'),
(N'stable', N'adjective', N'/stable/', N'on dinh', N'B2', N'Business'),
(N'temporary', N'adjective', N'/temporary/', N'tam thoi', N'B2', N'Academic/IELTS General'),
(N'urban', N'adjective', N'/urban/', N'thuoc do thi', N'B2', N'Environment'),
(N'visible', N'adjective', N'/visible/', N'co the nhin thay', N'B2', N'Academic/IELTS General'),
(N'voluntary', N'adjective', N'/voluntary/', N'tu nguyen', N'B2', N'Health'),
(N'whereas', N'phrase', N'/whereas/', N'trong khi do', N'B2', N'Academic/IELTS General'),
(N'consequently', N'adverb', N'/consequently/', N'do do', N'B2', N'Academic/IELTS General'),
(N'ambiguous', N'adjective', N'/ambiguous/', N'mo ho', N'C1', N'Academic/IELTS General'),
(N'anticipate', N'verb', N'/anticipate/', N'du doan', N'C1', N'Business'),
(N'articulate', N'verb', N'/articulate/', N'dien dat ro rang', N'C1', N'Education'),
(N'coherent', N'adjective', N'/coherent/', N'mach lac', N'C1', N'Academic/IELTS General'),
(N'compelling', N'adjective', N'/compelling/', N'thuyet phuc', N'C1', N'Academic/IELTS General'),
(N'comprehensive', N'adjective', N'/comprehensive/', N'toan dien', N'C1', N'Education'),
(N'conceptual', N'adjective', N'/conceptual/', N'thuoc khai niem', N'C1', N'Education'),
(N'contradict', N'verb', N'/contradict/', N'mau thuan', N'C1', N'Academic/IELTS General'),
(N'diminish', N'verb', N'/diminish/', N'lam giam', N'C1', N'Environment'),
(N'empirical', N'adjective', N'/empirical/', N'dua tren thuc nghiem', N'C1', N'Education'),
(N'enhance', N'verb', N'/enhance/', N'nang cao', N'C1', N'Business'),
(N'explicit', N'adjective', N'/explicit/', N'ro rang', N'C1', N'Academic/IELTS General'),
(N'facilitate', N'verb', N'/facilitate/', N'tao dieu kien', N'C1', N'Education'),
(N'fluctuate', N'verb', N'/fluctuate/', N'dao dong', N'C1', N'Business'),
(N'hierarchical', N'adjective', N'/hierarchical/', N'co thu bac', N'C1', N'Business'),
(N'implicit', N'adjective', N'/implicit/', N'ngam hieu', N'C1', N'Academic/IELTS General'),
(N'inhibit', N'verb', N'/inhibit/', N'can tro', N'C1', N'Health'),
(N'integrate', N'verb', N'/integrate/', N'tich hop', N'C1', N'Technology'),
(N'legislation', N'noun', N'/legislation/', N'luat phap', N'C1', N'Business'),
(N'marginal', N'adjective', N'/marginal/', N'khong dang ke', N'C1', N'Business'),
(N'negotiate', N'verb', N'/negotiate/', N'dam phan', N'C1', N'Business'),
(N'preliminary', N'adjective', N'/preliminary/', N'so bo', N'C1', N'Academic/IELTS General'),
(N'predominant', N'adjective', N'/predominant/', N'chiem uu the', N'C1', N'Academic/IELTS General'),
(N'refine', N'verb', N'/refine/', N'tinh chinh', N'C1', N'Education'),
(N'reinforce', N'verb', N'/reinforce/', N'cung co', N'C1', N'Education'),
(N'reluctant', N'adjective', N'/reluctant/', N'mien cuong', N'C1', N'Academic/IELTS General'),
(N'substantial', N'adjective', N'/substantial/', N'dang ke', N'C1', N'Business'),
(N'sustainable practice', N'noun', N'/sustainable practice/', N'thuc hanh ben vung', N'C1', N'Environment'),
(N'undermine', N'verb', N'/undermine/', N'lam suy yeu', N'C1', N'Business'),
(N'valid', N'adjective', N'/valid/', N'hop le', N'C1', N'Academic/IELTS General'),
(N'viable', N'adjective', N'/viable/', N'kha thi', N'C1', N'Business'),
(N'vulnerability', N'noun', N'/vulnerability/', N'tinh de bi ton thuong', N'C1', N'Health'),
(N'allocate', N'verb', N'/allocate/', N'phan bo', N'C1', N'Business'),
(N'collaborate', N'verb', N'/collaborate/', N'hop tac', N'C1', N'Education'),
(N'derive', N'verb', N'/derive/', N'bat nguon', N'C1', N'Academic/IELTS General'),
(N'abate', N'verb', N'/abate/', N'giam bot', N'C2', N'Environment'),
(N'aberration', N'noun', N'/aberration/', N'su lech chuan', N'C2', N'Academic/IELTS General'),
(N'acquiesce', N'verb', N'/acquiesce/', N'mien cuong dong y', N'C2', N'Business'),
(N'arduous', N'adjective', N'/arduous/', N'gian nan', N'C2', N'Education'),
(N'astute', N'adjective', N'/astute/', N'sac sao', N'C2', N'Business'),
(N'austere', N'adjective', N'/austere/', N'kham kho, nghiem khac', N'C2', N'Business'),
(N'benevolent', N'adjective', N'/benevolent/', N'nhan tu', N'C2', N'Academic/IELTS General'),
(N'conjecture', N'noun', N'/conjecture/', N'phong doan', N'C2', N'Academic/IELTS General'),
(N'conundrum', N'noun', N'/conundrum/', N'van de nan giai', N'C2', N'Academic/IELTS General'),
(N'deleterious', N'adjective', N'/deleterious/', N'co hai', N'C2', N'Health'),
(N'discerning', N'adjective', N'/discerning/', N'tinh te, sang suot', N'C2', N'Academic/IELTS General'),
(N'embellish', N'verb', N'/embellish/', N'to diem, them that', N'C2', N'Academic/IELTS General'),
(N'exacerbate', N'verb', N'/exacerbate/', N'lam tram trong hon', N'C2', N'Health'),
(N'meticulous', N'adjective', N'/meticulous/', N'ti mi', N'C2', N'Education'),
(N'nuanced', N'adjective', N'/nuanced/', N'co sac thai tinh te', N'C2', N'Academic/IELTS General'),
(N'obscure', N'adjective', N'/obscure/', N'kho hieu', N'C2', N'Academic/IELTS General'),
(N'pervasive', N'adjective', N'/pervasive/', N'lan rong', N'C2', N'Technology'),
(N'pragmatic', N'adjective', N'/pragmatic/', N'thuc dung', N'C2', N'Business'),
(N'quintessential', N'adjective', N'/quintessential/', N'tieu bieu nhat', N'C2', N'Academic/IELTS General'),
(N'reconcile', N'verb', N'/reconcile/', N'hoa giai, dung hoa', N'C2', N'Academic/IELTS General'),
(N'scrutinize', N'verb', N'/scrutinize/', N'xem xet ky', N'C2', N'Education'),
(N'ubiquitous', N'adjective', N'/ubiquitous/', N'co mat khap noi', N'C2', N'Technology'),
(N'unprecedented', N'adjective', N'/unprecedented/', N'chua tung co', N'C2', N'Business'),
(N'vindicate', N'verb', N'/vindicate/', N'minh oan, chung minh dung', N'C2', N'Academic/IELTS General'),
(N'watershed', N'noun', N'/watershed/', N'buoc ngoat quan trong', N'C2', N'Environment')
) AS v(TuTiengAnh, TuLoai, PhienAm, Nghia, CapDo, ChuDe)
WHERE NOT EXISTS (SELECT 1 FROM dbo.TuVung tv WHERE tv.MaLopHoc = @AdvancedClassId AND tv.TuTiengAnh = v.TuTiengAnh);
END
GO

IF OBJECT_ID(N'dbo.DeThi', N'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM dbo.DeThi)
BEGIN
INSERT INTO dbo.DeThi (TenDeThi, FileDuLieu, NgayTao)
VALUES
(N'IELTS Practice Test 1', NULL, GETDATE()),
(N'IELTS Practice Test 2', NULL, GETDATE());

END

IF OBJECT_ID(N'dbo.CauHoi', N'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM dbo.CauHoi)
BEGIN
INSERT INTO dbo.CauHoi (NoiDung, DapAn, NhanKyNang, BandLevel)
VALUES
(N'Listen to a conversation about booking accommodation and identify the final price.', N'120 dollars', N'Listening', 5.5),
(N'Read the passage about renewable energy and choose the best heading.', N'Benefits of renewable sources', N'Reading', 6.0),
(N'Write an overview for a line graph showing monthly revenue changes.', N'Clear overview with main trend', N'Writing', 6.5),
(N'Describe a time when teamwork helped you achieve a goal.', N'Personal response', N'Speaking', 5.5),
(N'Explain why cybersecurity has become important for modern businesses.', N'Because digital systems store sensitive data', N'Reading', 6.5),
(N'Compare two views about online education and give your opinion.', N'Balanced opinion essay', N'Writing', 7.0);

END

IF OBJECT_ID(N'dbo.BaiTap', N'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM dbo.BaiTap)
BEGIN
INSERT INTO dbo.BaiTap (MaLopHoc, TieuDe, MoTa, Deadline, FileDinhKem, NgayTao)
VALUES
(1, N'Writing Task 1 - Biểu đồ đường', N'Viết báo cáo 150 từ về xu hướng doanh thu.', DATEADD(day, 7, GETDATE()), NULL, GETDATE()),
(2, N'Speaking Part 2 - Teamwork', N'Chuẩn bị câu trả lời 2 phút về làm việc nhóm.', DATEADD(day, 5, GETDATE()), NULL, GETDATE());

END

IF OBJECT_ID(N'dbo.ChiTiet_NopBai', N'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM dbo.ChiTiet_NopBai)
BEGIN
INSERT INTO dbo.ChiTiet_NopBai (MaNguoiDung, MaBaiTap, FileBaiLam, ThoiGianNop, TrangThaiNop, DiemSo, NhanXet)
VALUES
(3, 1, N'an_task1.docx', DATEADD(day, -1, GETDATE()), N'Đã chấm', 6.0, N'Bố cục rõ, cần cải thiện từ vựng.'),
(4, 1, NULL, NULL, N'Chưa nộp', NULL, NULL),
(18, 2, N'anh_speaking.mp3', DATEADD(hour, -8, GETDATE()), N'Đã nộp', NULL, NULL);

END

IF OBJECT_ID(N'dbo.BuoiHoc', N'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM dbo.BuoiHoc)
BEGIN
INSERT INTO dbo.BuoiHoc (MaLopHoc, NgayHoc)
VALUES
(1, CONVERT(date, DATEADD(day, -7, GETDATE()))),
(1, CONVERT(date, DATEADD(day, -2, GETDATE()))),
(2, CONVERT(date, DATEADD(day, -6, GETDATE()))),
(2, CONVERT(date, DATEADD(day, -1, GETDATE())));

END

IF OBJECT_ID(N'dbo.ChiTiet_DiemDanh', N'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM dbo.ChiTiet_DiemDanh)
BEGIN
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

END

IF OBJECT_ID(N'dbo.DotKiemTra', N'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM dbo.DotKiemTra)
BEGIN
INSERT INTO dbo.DotKiemTra (MaLopHoc, MaDeThi, TenDotKiemTra, NgayKiemTra)
VALUES
(1, 1, N'Midterm 1', CONVERT(date, DATEADD(day, -20, GETDATE()))),
(2, 2, N'Midterm 1', CONVERT(date, DATEADD(day, -18, GETDATE())));

END

IF OBJECT_ID(N'dbo.ChiTiet_DiemSo', N'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM dbo.ChiTiet_DiemSo)
BEGIN
INSERT INTO dbo.ChiTiet_DiemSo (MaNguoiDung, MaDotKiemTra, DiemL, DiemR, DiemW, DiemS, DiemTong, NhanXet)
VALUES
(3, 1, 5.5, 6.0, 5.5, 6.0, 6.0, N'Cần tăng độ chính xác ngữ pháp.'),
(4, 1, 5.0, 5.5, 5.0, 5.5, 5.5, N'Nên luyện thêm đọc hiểu.'),
(18, 2, 6.5, 7.0, 6.0, 6.5, 6.5, N'Phản xạ nói tốt.'),
(19, 2, 6.0, 6.5, 6.0, 6.0, 6.0, N'Cần mở rộng ý trong Writing.');

END

IF OBJECT_ID(N'dbo.ThanhToanHocPhi', N'U') IS NOT NULL AND NOT EXISTS (SELECT 1 FROM dbo.ThanhToanHocPhi)
BEGIN
INSERT INTO dbo.ThanhToanHocPhi
    (MaNguoiDung, MaLopHoc, SoTien, SoTienGoc, PhanTramGiam, SoTienGiam, SoTienCuoi, ThongTinNganHang, NgayTao, HanThanhToan, TrangThai)
VALUES
(3, 1, 2400000, 3000000, 20, 600000, 2400000, N'VCB 012345678 - Trung tâm IELTS', DATEADD(day, -5, GETDATE()), DATEADD(day, 5, GETDATE()), N'Đã thanh toán'),
(4, 1, 3000000, 3000000, 0, 0, 3000000, N'VCB 012345678 - Trung tâm IELTS', DATEADD(day, -4, GETDATE()), DATEADD(day, 6, GETDATE()), N'Chờ thanh toán'),
(18, 2, 2800000, 3500000, 20, 700000, 2800000, N'VCB 012345678 - Trung tâm IELTS', DATEADD(month, -1, GETDATE()), DATEADD(day, -18, GETDATE()), N'Đã thanh toán'),
(19, 2, 3500000, 3500000, 0, 0, 3500000, N'VCB 012345678 - Trung tâm IELTS', DATEADD(day, -3, GETDATE()), DATEADD(day, 7, GETDATE()), N'Đã thanh toán');
END
GO

IF OBJECT_ID(N'dbo.CK_CauHoi_Context', N'C') IS NULL
BEGIN
    ALTER TABLE dbo.CauHoi WITH NOCHECK
    ADD CONSTRAINT CK_CauHoi_Context CHECK
    (
        (NhanKyNang = N'Reading' AND PassageId IS NOT NULL AND SectionId IS NULL)
        OR (NhanKyNang = N'Listening' AND SectionId IS NOT NULL AND PassageId IS NULL)
        OR (NhanKyNang NOT IN (N'Reading', N'Listening') AND PassageId IS NULL AND SectionId IS NULL)
    );
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_GetQuestionsByPassage
    @PassageId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM dbo.CauHoi
    WHERE PassageId = @PassageId
    ORDER BY MaCauHoi;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_GetQuestionsBySection
    @SectionId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM dbo.CauHoi
    WHERE SectionId = @SectionId
    ORDER BY MaCauHoi;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_AddQuestionToExam
    @MaDeThi INT,
    @MaCauHoi INT,
    @ThuTu INT = NULL,
    @GroupType NVARCHAR(30) = NULL,
    @GroupId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM dbo.ChiTiet_DeThi WHERE MaDeThi = @MaDeThi AND MaCauHoi = @MaCauHoi)
    BEGIN
        IF @ThuTu IS NULL
        BEGIN
            SELECT @ThuTu = ISNULL(MAX(ThuTu), 0) + 1
            FROM dbo.ChiTiet_DeThi
            WHERE MaDeThi = @MaDeThi;
        END

        INSERT INTO dbo.ChiTiet_DeThi (MaDeThi, MaCauHoi, GroupType, GroupId, ThuTu)
        VALUES (@MaDeThi, @MaCauHoi, @GroupType, @GroupId, @ThuTu);
    END
END
GO
ALTER TABLE dbo.NhatKyThanhToan
ALTER COLUMN PaymentUrl NVARCHAR(2000) NULL;

ALTER TABLE dbo.NhatKyThanhToan
ALTER COLUMN QrContent NVARCHAR(2000) NULL;
