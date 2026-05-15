using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public class FrmDiemDanh : ModuleFormBase
    {
        private readonly ComboBox _cboLop = UiHelpers.ComboBox();
        private readonly DateTimePicker _dtNgay = new DateTimePicker { Width = 150, Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy" };
        private readonly DataGridView _grid = UiHelpers.Grid();
        private readonly ComboBox _cboTrangThai = UiHelpers.ComboBox();
        private readonly TextBox _txtLyDo = UiHelpers.TextBox();

        public FrmDiemDanh(ServiceFactory services, NguoiDungDTO currentUser) : base(services, currentUser, "Điểm danh và báo cáo chuyên cần")
        {
            var root = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 3 };
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            var top = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, Padding = new Padding(8) };
            var btnTai = UiHelpers.Button("Tải lớp");
            btnTai.Click += (s, e) => LoadData();
            top.Controls.Add(UiHelpers.Label("Lớp"));
            top.Controls.Add(_cboLop);
            top.Controls.Add(UiHelpers.Label("Ngày học"));
            top.Controls.Add(_dtNgay);
            top.Controls.Add(btnTai);

            var bottom = new FlowLayoutPanel { Dock = DockStyle.Bottom, AutoSize = true, Padding = new Padding(8) };
            var btnLuu = UiHelpers.Button("Lưu điểm danh");
            btnLuu.Width = 140;
            btnLuu.Click += (s, e) => Save();
            _cboTrangThai.DataSource = AppConstants.AttendanceStatuses.ToList();
            _txtLyDo.Width = 320;
            bottom.Controls.Add(UiHelpers.Label("Trạng thái"));
            bottom.Controls.Add(_cboTrangThai);
            bottom.Controls.Add(UiHelpers.Label("Lý do vắng"));
            bottom.Controls.Add(_txtLyDo);
            bottom.Controls.Add(btnLuu);

            _grid.SelectionChanged += (s, e) => Fill();

            root.Controls.Add(top, 0, 0);
            root.Controls.Add(_grid, 0, 1);
            root.Controls.Add(bottom, 0, 2);
            AddContent(root);
            UiHelpers.BindLopHoc(_cboLop, Services);
            LoadData();
        }

        private void LoadData()
        {
            var result = Services.DiemDanh.LayBangDiemDanh(UiHelpers.SelectedId(_cboLop), _dtNgay.Value);
            if (result.Success)
            {
                _grid.DataSource = result.Data;
            }
            else
            {
                UiHelpers.ShowResult(result);
            }
        }

        private void Fill()
        {
            var item = UiHelpers.SelectedItem<DiemDanhDTO>(_grid);
            if (item == null) return;
            _cboTrangThai.SelectedItem = item.TrangThai;
            _txtLyDo.Text = item.LyDoVang;
        }

        private void Save()
        {
            var item = UiHelpers.SelectedItem<DiemDanhDTO>(_grid);
            if (item == null) return;
            item.TrangThai = Convert.ToString(_cboTrangThai.SelectedItem);
            item.LyDoVang = _txtLyDo.Text.Trim();
            var result = Services.DiemDanh.Luu(item);
            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }
    }

    public class FrmDiemSo : ModuleFormBase
    {
        private readonly ComboBox _cboLop = UiHelpers.ComboBox();
        private readonly ComboBox _cboDot = UiHelpers.ComboBox();
        private readonly DataGridView _gridHocVien = UiHelpers.Grid();
        private readonly DataGridView _gridDiem = UiHelpers.Grid();
        private readonly TextBox _txtTenDot = UiHelpers.TextBox();
        private readonly DateTimePicker _dtNgay = new DateTimePicker { Width = 150, Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy" };
        private readonly NumericUpDown _diemL = ScoreBox();
        private readonly NumericUpDown _diemR = ScoreBox();
        private readonly NumericUpDown _diemW = ScoreBox();
        private readonly NumericUpDown _diemS = ScoreBox();
        private readonly TextBox _txtNhanXet = UiHelpers.TextBox();

        public FrmDiemSo(ServiceFactory services, NguoiDungDTO currentUser) : base(services, currentUser, "Cập nhật điểm số IELTS")
        {
            var root = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 3 };
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 60));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 40));

            var top = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, Padding = new Padding(8) };
            var btnTaoDot = UiHelpers.Button("Tạo đợt");
            var btnTai = UiHelpers.Button("Tải điểm");
            btnTaoDot.Click += (s, e) => CreateExamRound();
            btnTai.Click += (s, e) => LoadScores();
            top.Controls.Add(UiHelpers.Label("Lớp"));
            top.Controls.Add(_cboLop);
            top.Controls.Add(UiHelpers.Label("Tên đợt"));
            top.Controls.Add(_txtTenDot);
            top.Controls.Add(UiHelpers.Label("Ngày"));
            top.Controls.Add(_dtNgay);
            top.Controls.Add(btnTaoDot);
            top.Controls.Add(UiHelpers.Label("Đợt kiểm tra"));
            top.Controls.Add(_cboDot);
            top.Controls.Add(btnTai);

            var middle = new SplitContainer { Dock = DockStyle.Fill, Orientation = Orientation.Vertical, SplitterDistance = 520 };
            middle.Panel1.Controls.Add(_gridHocVien);
            middle.Panel2.Controls.Add(_gridDiem);

            var bottom = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, Padding = new Padding(8) };
            var btnLuu = UiHelpers.Button("Lưu điểm");
            btnLuu.Click += (s, e) => SaveScore();
            _txtNhanXet.Width = 320;
            bottom.Controls.Add(UiHelpers.Label("L"));
            bottom.Controls.Add(_diemL);
            bottom.Controls.Add(UiHelpers.Label("R"));
            bottom.Controls.Add(_diemR);
            bottom.Controls.Add(UiHelpers.Label("W"));
            bottom.Controls.Add(_diemW);
            bottom.Controls.Add(UiHelpers.Label("S"));
            bottom.Controls.Add(_diemS);
            bottom.Controls.Add(UiHelpers.Label("Nhận xét"));
            bottom.Controls.Add(_txtNhanXet);
            bottom.Controls.Add(btnLuu);

            root.Controls.Add(top, 0, 0);
            root.Controls.Add(middle, 0, 1);
            root.Controls.Add(bottom, 0, 2);
            AddContent(root);
            UiHelpers.BindLopHoc(_cboLop, Services);
            _cboLop.SelectedIndexChanged += (s, e) => LoadRoundsAndStudents();
            LoadRoundsAndStudents();
        }

        private static NumericUpDown ScoreBox()
        {
            return new NumericUpDown { Width = 58, DecimalPlaces = 1, Increment = 0.5m, Minimum = 0, Maximum = 9 };
        }

        private void LoadRoundsAndStudents()
        {
            var maLop = UiHelpers.SelectedId(_cboLop);
            if (maLop <= 0) return;
            _gridHocVien.DataSource = Services.LopHoc.LayHocVienTrongLop(maLop);
            _cboDot.DataSource = Services.DiemSo.LayDotKiemTra(maLop);
            _cboDot.DisplayMember = "TenDotKiemTra";
            _cboDot.ValueMember = "MaDotKiemTra";
            LoadScores();
        }

        private void CreateExamRound()
        {
            var result = Services.DiemSo.TaoDotKiemTra(new DotKiemTraDTO
            {
                MaLopHoc = UiHelpers.SelectedId(_cboLop),
                TenDotKiemTra = _txtTenDot.Text.Trim(),
                NgayKiemTra = _dtNgay.Value.Date
            });
            UiHelpers.ShowResult(result);
            if (result.Success) LoadRoundsAndStudents();
        }

        private void LoadScores()
        {
            var maDot = UiHelpers.SelectedId(_cboDot);
            if (maDot > 0)
            {
                _gridDiem.DataSource = Services.DiemSo.LayDiemSo(maDot);
            }
        }

        private void SaveScore()
        {
            var hv = UiHelpers.SelectedItem<NguoiDungDTO>(_gridHocVien);
            if (hv == null) return;
            var result = Services.DiemSo.LuuDiem(new DiemSoDTO
            {
                MaNguoiDung = hv.MaNguoiDung,
                MaDotKiemTra = UiHelpers.SelectedId(_cboDot),
                DiemL = _diemL.Value,
                DiemR = _diemR.Value,
                DiemW = _diemW.Value,
                DiemS = _diemS.Value,
                NhanXet = _txtNhanXet.Text.Trim()
            });
            UiHelpers.ShowResult(result);
            if (result.Success) LoadScores();
        }
    }

    public class FrmDeThi : ModuleFormBase
    {
        private readonly DataGridView _gridCauHoi = UiHelpers.Grid();
        private readonly DataGridView _gridDeThi = UiHelpers.Grid();
        private readonly ComboBox _cboKyNang = UiHelpers.ComboBox();
        private readonly TextBox _txtNoiDung = new TextBox { Width = 430, Multiline = true, Height = 65, ScrollBars = ScrollBars.Vertical };
        private readonly TextBox _txtDapAn = new TextBox { Width = 430, Multiline = true, Height = 55, ScrollBars = ScrollBars.Vertical };
        private readonly TextBox _txtTenDe = UiHelpers.TextBox();
        private int _selectedQuestionId;

        public FrmDeThi(ServiceFactory services, NguoiDungDTO currentUser) : base(services, currentUser, "Tạo đề thi IELTS")
        {
            var root = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 3 };
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 55));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 45));
            var form = UiHelpers.FormGrid();
            UiHelpers.BindKyNang(_cboKyNang);
            form.Controls.Add(UiHelpers.Label("Kỹ năng"), 0, 0);
            form.Controls.Add(_cboKyNang, 1, 0);
            form.Controls.Add(UiHelpers.Label("Tên đề thi"), 2, 0);
            form.Controls.Add(_txtTenDe, 3, 0);
            form.Controls.Add(UiHelpers.Label("Nội dung câu hỏi"), 0, 1);
            form.Controls.Add(_txtNoiDung, 1, 1);
            form.Controls.Add(UiHelpers.Label("Đáp án"), 2, 1);
            form.Controls.Add(_txtDapAn, 3, 1);
            var buttons = new FlowLayoutPanel { AutoSize = true };
            var btnMoi = UiHelpers.Button("Thêm mới");
            var btnLuuCau = UiHelpers.Button("Lưu câu hỏi");
            var btnXoaCau = UiHelpers.Button("Xóa câu hỏi");
            var btnTaoDe = UiHelpers.Button("Tạo đề");
            var btnThemVaoDe = UiHelpers.Button("Gắn vào đề");
            btnThemVaoDe.Width = 120;
            btnMoi.Click += (s, e) => ClearQuestion();
            btnLuuCau.Click += (s, e) => SaveQuestion();
            btnXoaCau.Click += (s, e) => DeleteQuestion();
            btnTaoDe.Click += (s, e) => CreateExam();
            btnThemVaoDe.Click += (s, e) => AttachQuestion();
            buttons.Controls.Add(btnMoi);
            buttons.Controls.Add(btnLuuCau);
            buttons.Controls.Add(btnXoaCau);
            buttons.Controls.Add(btnTaoDe);
            buttons.Controls.Add(btnThemVaoDe);
            form.Controls.Add(buttons, 3, 2);
            _gridCauHoi.SelectionChanged += (s, e) => FillQuestion();
            root.Controls.Add(form, 0, 0);
            root.Controls.Add(_gridCauHoi, 0, 1);
            root.Controls.Add(_gridDeThi, 0, 2);
            AddContent(root);
            LoadData();
        }

        private void LoadData()
        {
            _gridCauHoi.DataSource = Services.DeThi.LayCauHoi(null);
            _gridDeThi.DataSource = Services.DeThi.LayDeThi();
        }

        private void FillQuestion()
        {
            var item = UiHelpers.SelectedItem<CauHoiDTO>(_gridCauHoi);
            if (item == null) return;
            _selectedQuestionId = item.MaCauHoi;
            _txtNoiDung.Text = item.NoiDung;
            _txtDapAn.Text = item.DapAn;
            _cboKyNang.SelectedItem = item.NhanKyNang;
        }

        private void ClearQuestion()
        {
            _selectedQuestionId = 0;
            _txtNoiDung.Clear();
            _txtDapAn.Clear();
        }

        private void SaveQuestion()
        {
            var result = Services.DeThi.LuuCauHoi(new CauHoiDTO
            {
                MaCauHoi = _selectedQuestionId,
                NoiDung = _txtNoiDung.Text.Trim(),
                DapAn = _txtDapAn.Text.Trim(),
                NhanKyNang = Convert.ToString(_cboKyNang.SelectedItem)
            });
            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }

        private void DeleteQuestion()
        {
            if (_selectedQuestionId == 0) return;
            var result = Services.DeThi.XoaCauHoi(_selectedQuestionId);
            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }

        private void CreateExam()
        {
            var result = Services.DeThi.TaoDeThi(new DeThiDTO { TenDeThi = _txtTenDe.Text.Trim() });
            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }

        private void AttachQuestion()
        {
            var exam = UiHelpers.SelectedItem<DeThiDTO>(_gridDeThi);
            var question = UiHelpers.SelectedItem<CauHoiDTO>(_gridCauHoi);
            if (exam == null || question == null) return;
            var result = Services.DeThi.ThemCauHoiVaoDeThi(exam.MaDeThi, question.MaCauHoi);
            UiHelpers.ShowResult(result);
        }
    }

    public class FrmBaoCao : ModuleFormBase
    {
        private readonly ComboBox _cboLoai = UiHelpers.ComboBox();
        private readonly ComboBox _cboLop = UiHelpers.ComboBox();
        private readonly TextBox _txtNoiDung = new TextBox { Dock = DockStyle.Fill, Multiline = true, ScrollBars = ScrollBars.Both, Font = UiHelpers.DefaultFont };

        public FrmBaoCao(ServiceFactory services, NguoiDungDTO currentUser) : base(services, currentUser, "Tạo báo cáo")
        {
            var root = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2 };
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            var top = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, Padding = new Padding(8) };
            _cboLoai.DataSource = new[] { "Điểm số", "Chuyên cần" };
            var btnTao = UiHelpers.Button("Tạo báo cáo");
            var btnXuat = UiHelpers.Button("Xuất file");
            btnTao.Width = 130;
            btnTao.Click += (s, e) => Generate();
            btnXuat.Click += (s, e) => Export();
            top.Controls.Add(UiHelpers.Label("Loại báo cáo"));
            top.Controls.Add(_cboLoai);
            top.Controls.Add(UiHelpers.Label("Lớp"));
            top.Controls.Add(_cboLop);
            top.Controls.Add(btnTao);
            top.Controls.Add(btnXuat);
            root.Controls.Add(top, 0, 0);
            root.Controls.Add(_txtNoiDung, 0, 1);
            AddContent(root);
            UiHelpers.BindLopHoc(_cboLop, Services);
        }

        private void Generate()
        {
            var result = Services.BaoCao.TaoBaoCao(new BaoCaoDTO
            {
                LoaiBaoCao = Convert.ToString(_cboLoai.SelectedItem),
                MaLopHoc = UiHelpers.SelectedId(_cboLop)
            }, CurrentUser.MaNguoiDung);
            if (result.Success)
            {
                _txtNoiDung.Text = result.Data;
            }
            UiHelpers.ShowResult(result);
        }

        private void Export()
        {
            using (var dialog = new SaveFileDialog { Filter = "Tệp CSV hoặc văn bản|*.csv;*.txt|Tệp Word RTF|*.rtf", FileName = "BaoCaoIELTS.csv" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var content = Path.GetExtension(dialog.FileName).Equals(".rtf", StringComparison.OrdinalIgnoreCase)
                        ? "{\\rtf1\\ansi " + _txtNoiDung.Text.Replace(Environment.NewLine, "\\line ") + "}"
                        : _txtNoiDung.Text;
                    UiHelpers.ShowResult(Services.BaoCao.XuatBaoCao(content, dialog.FileName));
                }
            }
        }
    }

    public class FrmTuVung : ModuleFormBase
    {
        private readonly DataGridView _grid = UiHelpers.Grid();
        private readonly ComboBox _cboLop = UiHelpers.ComboBox();
        private readonly TextBox _txtTu = UiHelpers.TextBox();
        private readonly TextBox _txtLoai = UiHelpers.TextBox();
        private readonly TextBox _txtPhienAm = UiHelpers.TextBox();
        private readonly TextBox _txtNghia = UiHelpers.TextBox();
        private int _selectedId;

        public FrmTuVung(ServiceFactory services, NguoiDungDTO currentUser) : base(services, currentUser, "Cập nhật kho từ vựng")
        {
            var root = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2 };
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            var form = UiHelpers.FormGrid();
            form.Controls.Add(UiHelpers.Label("Lớp"), 0, 0);
            form.Controls.Add(_cboLop, 1, 0);
            form.Controls.Add(UiHelpers.Label("Từ tiếng Anh"), 2, 0);
            form.Controls.Add(_txtTu, 3, 0);
            form.Controls.Add(UiHelpers.Label("Từ loại"), 0, 1);
            form.Controls.Add(_txtLoai, 1, 1);
            form.Controls.Add(UiHelpers.Label("Phiên âm"), 2, 1);
            form.Controls.Add(_txtPhienAm, 3, 1);
            form.Controls.Add(UiHelpers.Label("Nghĩa"), 0, 2);
            form.Controls.Add(_txtNghia, 1, 2);
            var buttons = new FlowLayoutPanel { AutoSize = true };
            var btnMoi = UiHelpers.Button("Thêm mới");
            var btnLuu = UiHelpers.Button("Lưu");
            var btnXoa = UiHelpers.Button("Xóa");
            btnMoi.Click += (s, e) => ClearForm();
            btnLuu.Click += (s, e) => Save();
            btnXoa.Click += (s, e) => Delete();
            buttons.Controls.Add(btnMoi);
            buttons.Controls.Add(btnLuu);
            buttons.Controls.Add(btnXoa);
            form.Controls.Add(buttons, 3, 2);
            _grid.SelectionChanged += (s, e) => Fill();
            root.Controls.Add(form, 0, 0);
            root.Controls.Add(_grid, 0, 1);
            AddContent(root);
            UiHelpers.BindLopHoc(_cboLop, Services);
            _cboLop.SelectedIndexChanged += (s, e) => LoadData();
            LoadData();
        }

        private void LoadData()
        {
            _grid.DataSource = Services.TuVung.LayDanhSach(UiHelpers.SelectedId(_cboLop));
        }

        private void Fill()
        {
            var item = UiHelpers.SelectedItem<TuVungDTO>(_grid);
            if (item == null) return;
            _selectedId = item.MaTuVung;
            _cboLop.SelectedValue = item.MaLopHoc;
            _txtTu.Text = item.TuTiengAnh;
            _txtLoai.Text = item.TuLoai;
            _txtPhienAm.Text = item.PhienAm;
            _txtNghia.Text = item.Nghia;
        }

        private void ClearForm()
        {
            _selectedId = 0;
            _txtTu.Clear();
            _txtLoai.Clear();
            _txtPhienAm.Clear();
            _txtNghia.Clear();
        }

        private void Save()
        {
            var result = Services.TuVung.Luu(new TuVungDTO
            {
                MaTuVung = _selectedId,
                MaLopHoc = UiHelpers.SelectedId(_cboLop),
                TuTiengAnh = _txtTu.Text.Trim(),
                TuLoai = _txtLoai.Text.Trim(),
                PhienAm = _txtPhienAm.Text.Trim(),
                Nghia = _txtNghia.Text.Trim()
            });
            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }

        private void Delete()
        {
            if (_selectedId == 0) return;
            var result = Services.TuVung.Xoa(_selectedId);
            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                ClearForm();
                LoadData();
            }
        }
    }

    public class FrmThongBao : ModuleFormBase
    {
        private readonly DataGridView _grid = UiHelpers.Grid();
        private readonly ComboBox _cboLop = UiHelpers.ComboBox();
        private readonly CheckBox _chkTatCa = new CheckBox { Text = "Gửi tất cả học viên", AutoSize = true, Checked = true };
        private readonly TextBox _txtTieuDe = UiHelpers.TextBox();
        private readonly TextBox _txtNoiDung = new TextBox { Width = 520, Height = 80, Multiline = true, ScrollBars = ScrollBars.Vertical };

        public FrmThongBao(ServiceFactory services, NguoiDungDTO currentUser) : base(services, currentUser, "Thông báo")
        {
            var root = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2 };
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            var form = UiHelpers.FormGrid();
            form.Controls.Add(UiHelpers.Label("Tiêu đề"), 0, 0);
            form.Controls.Add(_txtTieuDe, 1, 0);
            form.Controls.Add(UiHelpers.Label("Lớp nhận"), 2, 0);
            form.Controls.Add(_cboLop, 3, 0);
            form.Controls.Add(UiHelpers.Label("Nội dung"), 0, 1);
            form.Controls.Add(_txtNoiDung, 1, 1);
            form.Controls.Add(_chkTatCa, 2, 1);
            var btnGui = UiHelpers.Button("Gửi");
            btnGui.Click += (s, e) => Send();
            form.Controls.Add(btnGui, 3, 1);
            root.Controls.Add(form, 0, 0);
            root.Controls.Add(_grid, 0, 1);
            AddContent(root);
            UiHelpers.BindLopHoc(_cboLop, Services);
            LoadData();
        }

        private void LoadData()
        {
            _grid.DataSource = Services.ThongBao.LayDanhSach();
        }

        private void Send()
        {
            var result = Services.ThongBao.Gui(new ThongBaoDTO
            {
                MaNguoiGui = CurrentUser.MaNguoiDung,
                TieuDe = _txtTieuDe.Text.Trim(),
                NoiDung = _txtNoiDung.Text.Trim()
            }, _chkTatCa.Checked ? (int?)null : UiHelpers.SelectedId(_cboLop));
            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                _txtTieuDe.Clear();
                _txtNoiDung.Clear();
                LoadData();
            }
        }
    }

    public class FrmHocPhi : ModuleFormBase
    {
        private readonly DataGridView _grid = UiHelpers.Grid();
        private readonly ComboBox _cboHocVien = UiHelpers.ComboBox();
        private readonly NumericUpDown _numSoTien = new NumericUpDown { Width = 160, Minimum = 0, Maximum = 1000000000, Increment = 100000 };
        private readonly TextBox _txtNganHang = UiHelpers.TextBox();
        private readonly ComboBox _cboTrangThai = UiHelpers.ComboBox();

        public FrmHocPhi(ServiceFactory services, NguoiDungDTO currentUser) : base(services, currentUser, "Thanh toán học phí")
        {
            var root = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2 };
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            var form = UiHelpers.FormGrid();
            form.Controls.Add(UiHelpers.Label("Học viên"), 0, 0);
            form.Controls.Add(_cboHocVien, 1, 0);
            form.Controls.Add(UiHelpers.Label("Số tiền"), 2, 0);
            form.Controls.Add(_numSoTien, 3, 0);
            form.Controls.Add(UiHelpers.Label("Thông tin ngân hàng"), 0, 1);
            form.Controls.Add(_txtNganHang, 1, 1);
            form.Controls.Add(UiHelpers.Label("Trạng thái"), 2, 1);
            form.Controls.Add(_cboTrangThai, 3, 1);
            var buttons = new FlowLayoutPanel { AutoSize = true };
            var btnTao = UiHelpers.Button("Tạo yêu cầu");
            var btnCapNhat = UiHelpers.Button("Cập nhật");
            btnTao.Width = 130;
            btnTao.Click += (s, e) => CreateRequest();
            btnCapNhat.Click += (s, e) => UpdateStatus();
            buttons.Controls.Add(btnTao);
            buttons.Controls.Add(btnCapNhat);
            form.Controls.Add(buttons, 3, 2);
            root.Controls.Add(form, 0, 0);
            root.Controls.Add(_grid, 0, 1);
            AddContent(root);
            _cboHocVien.DataSource = Services.HocVien.TimKiem(null);
            _cboHocVien.DisplayMember = "HoTen";
            _cboHocVien.ValueMember = "MaNguoiDung";
            _cboTrangThai.DataSource = new[] { "Chờ thanh toán", "Đã thanh toán", "Quá hạn" };
            LoadData();
        }

        private void LoadData()
        {
            _grid.DataSource = Services.HocPhi.LayDanhSach();
        }

        private void CreateRequest()
        {
            var result = Services.HocPhi.TaoYeuCau(new ThanhToanHocPhiDTO
            {
                MaNguoiDung = UiHelpers.SelectedId(_cboHocVien),
                SoTien = _numSoTien.Value,
                ThongTinNganHang = _txtNganHang.Text.Trim()
            });
            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }

        private void UpdateStatus()
        {
            var item = UiHelpers.SelectedItem<ThanhToanHocPhiDTO>(_grid);
            if (item == null) return;
            var result = Services.HocPhi.CapNhatTrangThai(item.MaThanhToan, Convert.ToString(_cboTrangThai.SelectedItem));
            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }
    }
}
