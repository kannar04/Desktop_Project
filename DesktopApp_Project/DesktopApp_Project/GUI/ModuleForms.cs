using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public class FrmHocVien : ModuleFormBase
    {
        private readonly DataGridView _grid = UiHelpers.Grid();
        private readonly TextBox _txtTim = UiHelpers.TextBox();
        private readonly TextBox _txtHoTen = UiHelpers.TextBox();
        private readonly TextBox _txtSdt = UiHelpers.TextBox();
        private readonly TextBox _txtEmail = UiHelpers.TextBox();
        private readonly TextBox _txtTrinhDo = UiHelpers.TextBox();
        private readonly TextBox _txtTaiKhoan = UiHelpers.TextBox();
        private readonly TextBox _txtMatKhau = UiHelpers.TextBox();
        private readonly DateTimePicker _dtNgaySinh = new DateTimePicker { Width = 220, Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy" };
        private int _selectedId;

        public FrmHocVien(ServiceFactory services, NguoiDungDTO currentUser) : base(services, currentUser, "Quản lý hồ sơ học viên")
        {
            var root = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 3 };
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            var search = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, Padding = new Padding(8) };
            var btnTim = UiHelpers.Button("Tìm kiếm");
            btnTim.Click += (s, e) => LoadData();
            search.Controls.Add(UiHelpers.Label("Từ khóa"));
            search.Controls.Add(_txtTim);
            search.Controls.Add(btnTim);

            var form = UiHelpers.FormGrid();
            form.Controls.Add(UiHelpers.Label("Họ tên"), 0, 0);
            form.Controls.Add(_txtHoTen, 1, 0);
            form.Controls.Add(UiHelpers.Label("Ngày sinh"), 2, 0);
            form.Controls.Add(_dtNgaySinh, 3, 0);
            form.Controls.Add(UiHelpers.Label("SĐT"), 0, 1);
            form.Controls.Add(_txtSdt, 1, 1);
            form.Controls.Add(UiHelpers.Label("Email"), 2, 1);
            form.Controls.Add(_txtEmail, 3, 1);
            form.Controls.Add(UiHelpers.Label("Trình độ đầu vào"), 0, 2);
            form.Controls.Add(_txtTrinhDo, 1, 2);
            form.Controls.Add(UiHelpers.Label("Tài khoản"), 2, 2);
            form.Controls.Add(_txtTaiKhoan, 3, 2);
            form.Controls.Add(UiHelpers.Label("Mật khẩu"), 0, 3);
            form.Controls.Add(_txtMatKhau, 1, 3);

            var buttons = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true };
            var btnThem = UiHelpers.Button("Thêm mới");
            var btnLuu = UiHelpers.Button("Lưu");
            var btnXoa = UiHelpers.Button("Xóa");
            btnThem.Click += (s, e) => ClearForm();
            btnLuu.Click += (s, e) => Save();
            btnXoa.Click += (s, e) => Delete();
            buttons.Controls.Add(btnThem);
            buttons.Controls.Add(btnLuu);
            buttons.Controls.Add(btnXoa);
            form.Controls.Add(buttons, 3, 3);

            _grid.SelectionChanged += (s, e) => FillFromGrid();

            root.Controls.Add(search, 0, 0);
            root.Controls.Add(form, 0, 1);
            root.Controls.Add(_grid, 0, 2);
            AddContent(root);
            LoadData();
        }

        private void LoadData()
        {
            _grid.DataSource = Services.HocVien.TimKiem(_txtTim.Text);
        }

        private void FillFromGrid()
        {
            var item = UiHelpers.SelectedItem<NguoiDungDTO>(_grid);
            if (item == null) return;
            _selectedId = item.MaNguoiDung;
            _txtHoTen.Text = item.HoTen;
            _dtNgaySinh.Value = item.NgaySinh ?? DateTime.Today;
            _txtSdt.Text = item.SDT;
            _txtEmail.Text = item.Email;
            _txtTrinhDo.Text = item.TrinhDoDauVao;
            _txtTaiKhoan.Text = item.TaiKhoan;
            _txtMatKhau.Text = item.MatKhau;
        }

        private void ClearForm()
        {
            _selectedId = 0;
            foreach (var text in new[] { _txtHoTen, _txtSdt, _txtEmail, _txtTrinhDo, _txtTaiKhoan, _txtMatKhau })
            {
                text.Clear();
            }
            _dtNgaySinh.Value = DateTime.Today;
        }

        private void Save()
        {
            var result = Services.HocVien.Luu(new NguoiDungDTO
            {
                MaNguoiDung = _selectedId,
                HoTen = _txtHoTen.Text.Trim(),
                NgaySinh = _dtNgaySinh.Value.Date,
                SDT = _txtSdt.Text.Trim(),
                Email = _txtEmail.Text.Trim(),
                TrinhDoDauVao = _txtTrinhDo.Text.Trim(),
                TaiKhoan = _txtTaiKhoan.Text.Trim(),
                MatKhau = _txtMatKhau.Text
            });
            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }

        private void Delete()
        {
            if (_selectedId == 0) return;
            if (MessageBox.Show("Bạn có chắc muốn xóa học viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            var result = Services.HocVien.Xoa(_selectedId);
            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                ClearForm();
                LoadData();
            }
        }
    }

    public class FrmLopHoc : ModuleFormBase
    {
        private readonly DataGridView _gridLop = UiHelpers.Grid();
        private readonly DataGridView _gridTrongLop = UiHelpers.Grid();
        private readonly DataGridView _gridNgoaiLop = UiHelpers.Grid();
        private readonly TextBox _txtTenLop = UiHelpers.TextBox();
        private readonly TextBox _txtTrinhDo = UiHelpers.TextBox();
        private readonly TextBox _txtLichHoc = UiHelpers.TextBox();
        private int _selectedClassId;

        public FrmLopHoc(ServiceFactory services, NguoiDungDTO currentUser) : base(services, currentUser, "Quản lý lớp học")
        {
            var root = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 3 };
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 45));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 55));

            var form = UiHelpers.FormGrid();
            form.Controls.Add(UiHelpers.Label("Tên lớp"), 0, 0);
            form.Controls.Add(_txtTenLop, 1, 0);
            form.Controls.Add(UiHelpers.Label("Nhóm trình độ"), 2, 0);
            form.Controls.Add(_txtTrinhDo, 3, 0);
            form.Controls.Add(UiHelpers.Label("Lịch học"), 0, 1);
            form.Controls.Add(_txtLichHoc, 1, 1);

            var buttons = new FlowLayoutPanel { AutoSize = true };
            var btnThem = UiHelpers.Button("Thêm mới");
            var btnLuu = UiHelpers.Button("Lưu");
            var btnXoa = UiHelpers.Button("Xóa");
            btnThem.Click += (s, e) => ClearForm();
            btnLuu.Click += (s, e) => Save();
            btnXoa.Click += (s, e) => Delete();
            buttons.Controls.Add(btnThem);
            buttons.Controls.Add(btnLuu);
            buttons.Controls.Add(btnXoa);
            form.Controls.Add(buttons, 3, 1);

            _gridLop.SelectionChanged += (s, e) => FillClass();

            var split = new SplitContainer { Dock = DockStyle.Fill, Orientation = Orientation.Vertical, SplitterDistance = 520 };
            split.Panel1.Controls.Add(_gridTrongLop);
            split.Panel2.Controls.Add(_gridNgoaiLop);

            var assignButtons = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, Padding = new Padding(8) };
            var btnThemHv = UiHelpers.Button("Thêm vào lớp");
            var btnXoaHv = UiHelpers.Button("Xóa khỏi lớp");
            btnThemHv.Width = 130;
            btnXoaHv.Width = 130;
            btnThemHv.Click += (s, e) => AddStudent();
            btnXoaHv.Click += (s, e) => RemoveStudent();
            assignButtons.Controls.Add(new Label { Text = "Bên trái: học viên trong lớp. Bên phải: học viên chưa thuộc lớp.", AutoSize = true, Padding = new Padding(4, 9, 16, 0) });
            assignButtons.Controls.Add(btnThemHv);
            assignButtons.Controls.Add(btnXoaHv);

            var bottom = new Panel { Dock = DockStyle.Fill };
            bottom.Controls.Add(split);
            bottom.Controls.Add(assignButtons);

            root.Controls.Add(form, 0, 0);
            root.Controls.Add(_gridLop, 0, 1);
            root.Controls.Add(bottom, 0, 2);
            AddContent(root);
            LoadClasses();
        }

        private void LoadClasses()
        {
            _gridLop.DataSource = Services.LopHoc.LayDanhSach();
        }

        private void FillClass()
        {
            var item = UiHelpers.SelectedItem<LopHocDTO>(_gridLop);
            if (item == null) return;
            _selectedClassId = item.MaLopHoc;
            _txtTenLop.Text = item.TenLop;
            _txtTrinhDo.Text = item.NhomTrinhDo;
            _txtLichHoc.Text = item.LichHoc;
            LoadStudents();
        }

        private void LoadStudents()
        {
            if (_selectedClassId <= 0) return;
            _gridTrongLop.DataSource = Services.LopHoc.LayHocVienTrongLop(_selectedClassId);
            _gridNgoaiLop.DataSource = Services.LopHoc.LayHocVienChuaTrongLop(_selectedClassId);
        }

        private void ClearForm()
        {
            _selectedClassId = 0;
            _txtTenLop.Clear();
            _txtTrinhDo.Clear();
            _txtLichHoc.Clear();
        }

        private void Save()
        {
            var result = Services.LopHoc.Luu(new LopHocDTO
            {
                MaLopHoc = _selectedClassId,
                MaGiaoVien = CurrentUser.MaNguoiDung,
                TenLop = _txtTenLop.Text.Trim(),
                NhomTrinhDo = _txtTrinhDo.Text.Trim(),
                LichHoc = _txtLichHoc.Text.Trim()
            });
            UiHelpers.ShowResult(result);
            if (result.Success) LoadClasses();
        }

        private void Delete()
        {
            if (_selectedClassId == 0) return;
            var result = Services.LopHoc.Xoa(_selectedClassId);
            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                ClearForm();
                LoadClasses();
                LoadStudents();
            }
        }

        private void AddStudent()
        {
            var item = UiHelpers.SelectedItem<NguoiDungDTO>(_gridNgoaiLop);
            if (item == null || _selectedClassId == 0) return;
            var result = Services.LopHoc.ThemHocVien(item.MaNguoiDung, _selectedClassId);
            UiHelpers.ShowResult(result);
            if (result.Success) LoadStudents();
        }

        private void RemoveStudent()
        {
            var item = UiHelpers.SelectedItem<NguoiDungDTO>(_gridTrongLop);
            if (item == null || _selectedClassId == 0) return;
            var result = Services.LopHoc.XoaHocVien(item.MaNguoiDung, _selectedClassId);
            UiHelpers.ShowResult(result);
            if (result.Success) LoadStudents();
        }
    }

    public class FrmTaiLieu : ModuleFormBase
    {
        private readonly DataGridView _grid = UiHelpers.Grid();
        private readonly ComboBox _cboLop = UiHelpers.ComboBox();
        private readonly ComboBox _cboKyNang = UiHelpers.ComboBox();
        private readonly TextBox _txtChuDe = UiHelpers.TextBox();
        private readonly TextBox _txtMoTa = UiHelpers.TextBox();
        private readonly TextBox _txtFile = UiHelpers.TextBox();
        private readonly TextBox _txtVideo = UiHelpers.TextBox();
        private int _selectedId;

        public FrmTaiLieu(ServiceFactory services, NguoiDungDTO currentUser) : base(services, currentUser, "Cập nhật tài liệu giảng dạy")
        {
            var root = BuildDocumentLikeLayout("Tài liệu", Save, Delete, BrowseFile);
            AddContent(root);
            ReloadCombos();
            _cboLop.SelectedIndexChanged += (s, e) => LoadData();
            LoadData();
        }

        private Control BuildDocumentLikeLayout(string label, EventHandler save, EventHandler delete, EventHandler browse)
        {
            var root = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2 };
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            var form = UiHelpers.FormGrid();
            form.Controls.Add(UiHelpers.Label("Lớp"), 0, 0);
            form.Controls.Add(_cboLop, 1, 0);
            form.Controls.Add(UiHelpers.Label("Kỹ năng"), 2, 0);
            form.Controls.Add(_cboKyNang, 3, 0);
            form.Controls.Add(UiHelpers.Label("Chủ đề"), 0, 1);
            form.Controls.Add(_txtChuDe, 1, 1);
            form.Controls.Add(UiHelpers.Label("Mô tả"), 2, 1);
            form.Controls.Add(_txtMoTa, 3, 1);
            form.Controls.Add(UiHelpers.Label("Đường dẫn file"), 0, 2);
            form.Controls.Add(_txtFile, 1, 2);
            form.Controls.Add(UiHelpers.Label("Video link"), 2, 2);
            form.Controls.Add(_txtVideo, 3, 2);
            var buttons = new FlowLayoutPanel { AutoSize = true };
            var btnMoi = UiHelpers.Button("Thêm mới");
            var btnLuu = UiHelpers.Button("Lưu");
            var btnXoa = UiHelpers.Button("Xóa");
            var btnFile = UiHelpers.Button("Chọn file");
            btnMoi.Click += (s, e) => ClearForm();
            btnLuu.Click += save;
            btnXoa.Click += delete;
            btnFile.Click += browse;
            buttons.Controls.Add(btnMoi);
            buttons.Controls.Add(btnLuu);
            buttons.Controls.Add(btnXoa);
            buttons.Controls.Add(btnFile);
            form.Controls.Add(buttons, 3, 3);
            _grid.SelectionChanged += (s, e) => FillFromGrid();
            root.Controls.Add(form, 0, 0);
            root.Controls.Add(_grid, 0, 1);
            return root;
        }

        private void ReloadCombos()
        {
            UiHelpers.BindLopHoc(_cboLop, Services);
            UiHelpers.BindKyNang(_cboKyNang);
        }

        private void LoadData()
        {
            var maLop = UiHelpers.SelectedId(_cboLop);
            _grid.DataSource = Services.TaiLieu.LayDanhSach(maLop == 0 ? (int?)null : maLop);
        }

        private void FillFromGrid()
        {
            var item = UiHelpers.SelectedItem<TaiLieuDTO>(_grid);
            if (item == null) return;
            _selectedId = item.MaTaiLieu;
            _cboLop.SelectedValue = item.MaLopHoc;
            _cboKyNang.SelectedItem = item.NhanKyNang;
            _txtChuDe.Text = item.TenChuDe;
            _txtMoTa.Text = item.NoiDungMoTa;
            _txtFile.Text = item.DuongDanFile;
            _txtVideo.Text = item.VideoLink;
        }

        private void ClearForm()
        {
            _selectedId = 0;
            _txtChuDe.Clear();
            _txtMoTa.Clear();
            _txtFile.Clear();
            _txtVideo.Clear();
        }

        private void Save(object sender, EventArgs e)
        {
            var result = Services.TaiLieu.Luu(new TaiLieuDTO
            {
                MaTaiLieu = _selectedId,
                MaLopHoc = UiHelpers.SelectedId(_cboLop),
                TenChuDe = _txtChuDe.Text.Trim(),
                NoiDungMoTa = _txtMoTa.Text.Trim(),
                DuongDanFile = _txtFile.Text.Trim(),
                VideoLink = _txtVideo.Text.Trim(),
                NhanKyNang = Convert.ToString(_cboKyNang.SelectedItem)
            });
            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }

        private void Delete(object sender, EventArgs e)
        {
            if (_selectedId == 0) return;
            var result = Services.TaiLieu.Xoa(_selectedId);
            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                ClearForm();
                LoadData();
            }
        }

        private void BrowseFile(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog { Filter = "Tài liệu|*.pdf;*.doc;*.docx|Tất cả|*.*" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _txtFile.Text = dialog.FileName;
                }
            }
        }
    }

    public class FrmBaiTap : ModuleFormBase
    {
        private readonly DataGridView _grid = UiHelpers.Grid();
        private readonly ComboBox _cboLop = UiHelpers.ComboBox();
        private readonly TextBox _txtTieuDe = UiHelpers.TextBox();
        private readonly TextBox _txtMoTa = UiHelpers.TextBox();
        private readonly TextBox _txtFile = UiHelpers.TextBox();
        private readonly DateTimePicker _dtDeadline = new DateTimePicker { Width = 220, Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy HH:mm" };
        private int _selectedId;

        public FrmBaiTap(ServiceFactory services, NguoiDungDTO currentUser) : base(services, currentUser, "Cập nhật và giao bài tập")
        {
            var root = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2 };
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            var form = UiHelpers.FormGrid();
            form.Controls.Add(UiHelpers.Label("Lớp"), 0, 0);
            form.Controls.Add(_cboLop, 1, 0);
            form.Controls.Add(UiHelpers.Label("Deadline"), 2, 0);
            form.Controls.Add(_dtDeadline, 3, 0);
            form.Controls.Add(UiHelpers.Label("Tiêu đề"), 0, 1);
            form.Controls.Add(_txtTieuDe, 1, 1);
            form.Controls.Add(UiHelpers.Label("Mô tả"), 2, 1);
            form.Controls.Add(_txtMoTa, 3, 1);
            form.Controls.Add(UiHelpers.Label("File đính kèm"), 0, 2);
            form.Controls.Add(_txtFile, 1, 2);
            var buttons = new FlowLayoutPanel { AutoSize = true };
            var btnMoi = UiHelpers.Button("Thêm mới");
            var btnGiao = UiHelpers.Button("Giao bài");
            var btnXoa = UiHelpers.Button("Xóa");
            var btnFile = UiHelpers.Button("Chọn file");
            btnMoi.Click += (s, e) => ClearForm();
            btnGiao.Click += (s, e) => Save();
            btnXoa.Click += (s, e) => Delete();
            btnFile.Click += (s, e) => BrowseFile();
            buttons.Controls.Add(btnMoi);
            buttons.Controls.Add(btnGiao);
            buttons.Controls.Add(btnXoa);
            buttons.Controls.Add(btnFile);
            form.Controls.Add(buttons, 3, 2);
            _grid.SelectionChanged += (s, e) => FillFromGrid();
            root.Controls.Add(form, 0, 0);
            root.Controls.Add(_grid, 0, 1);
            AddContent(root);
            UiHelpers.BindLopHoc(_cboLop, Services);
            _cboLop.SelectedIndexChanged += (s, e) => LoadData();
            _dtDeadline.Value = DateTime.Now.AddDays(7);
            LoadData();
        }

        private void LoadData()
        {
            var maLop = UiHelpers.SelectedId(_cboLop);
            _grid.DataSource = Services.BaiTap.LayDanhSach(maLop == 0 ? (int?)null : maLop);
        }

        private void FillFromGrid()
        {
            var item = UiHelpers.SelectedItem<BaiTapDTO>(_grid);
            if (item == null) return;
            _selectedId = item.MaBaiTap;
            _cboLop.SelectedValue = item.MaLopHoc;
            _txtTieuDe.Text = item.TieuDe;
            _txtMoTa.Text = item.MoTa;
            _txtFile.Text = item.FileDinhKem;
            _dtDeadline.Value = item.Deadline;
        }

        private void ClearForm()
        {
            _selectedId = 0;
            _txtTieuDe.Clear();
            _txtMoTa.Clear();
            _txtFile.Clear();
            _dtDeadline.Value = DateTime.Now.AddDays(7);
        }

        private void Save()
        {
            var result = Services.BaiTap.GiaoBai(new BaiTapDTO
            {
                MaBaiTap = _selectedId,
                MaLopHoc = UiHelpers.SelectedId(_cboLop),
                TieuDe = _txtTieuDe.Text.Trim(),
                MoTa = _txtMoTa.Text.Trim(),
                Deadline = _dtDeadline.Value,
                FileDinhKem = _txtFile.Text.Trim()
            });
            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }

        private void Delete()
        {
            if (_selectedId == 0) return;
            var result = Services.BaiTap.Xoa(_selectedId);
            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                ClearForm();
                LoadData();
            }
        }

        private void BrowseFile()
        {
            using (var dialog = new OpenFileDialog { Filter = "File bài tập|*.pdf;*.doc;*.docx;*.zip;*.rar|Tất cả|*.*" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _txtFile.Text = dialog.FileName;
                }
            }
        }
    }

    public class FrmChamBai : ModuleFormBase
    {
        private readonly ComboBox _cboBaiTap = UiHelpers.ComboBox();
        private readonly DataGridView _grid = UiHelpers.Grid();
        private readonly NumericUpDown _numDiem = new NumericUpDown { Width = 100, DecimalPlaces = 1, Increment = 0.5m, Minimum = 0, Maximum = 9 };
        private readonly TextBox _txtNhanXet = UiHelpers.TextBox();
        private readonly TextBox _txtPreview = new TextBox { Dock = DockStyle.Fill, Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Both };

        public FrmChamBai(ServiceFactory services, NguoiDungDTO currentUser) : base(services, currentUser, "Quản lý nộp bài và chấm bài")
        {
            var root = new SplitContainer { Dock = DockStyle.Fill, Orientation = Orientation.Vertical, SplitterDistance = 720 };
            var left = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 3 };
            left.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            left.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            left.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            var top = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, Padding = new Padding(8) };
            var btnTai = UiHelpers.Button("Tải danh sách");
            btnTai.Width = 130;
            btnTai.Click += (s, e) => LoadSubmissions();
            top.Controls.Add(UiHelpers.Label("Bài tập"));
            top.Controls.Add(_cboBaiTap);
            top.Controls.Add(btnTai);
            var bottom = new FlowLayoutPanel { Dock = DockStyle.Bottom, AutoSize = true, Padding = new Padding(8) };
            var btnCham = UiHelpers.Button("Chấm bài");
            btnCham.Click += (s, e) => Grade();
            _txtNhanXet.Width = 360;
            bottom.Controls.Add(UiHelpers.Label("Điểm"));
            bottom.Controls.Add(_numDiem);
            bottom.Controls.Add(UiHelpers.Label("Nhận xét"));
            bottom.Controls.Add(_txtNhanXet);
            bottom.Controls.Add(btnCham);
            _grid.SelectionChanged += (s, e) => PreviewSubmission();
            left.Controls.Add(top, 0, 0);
            left.Controls.Add(_grid, 0, 1);
            left.Controls.Add(bottom, 0, 2);
            root.Panel1.Controls.Add(left);
            root.Panel2.Controls.Add(_txtPreview);
            AddContent(root);
            LoadAssignments();
        }

        private void LoadAssignments()
        {
            var list = Services.BaiTap.LayDanhSach(null);
            _cboBaiTap.DataSource = list;
            _cboBaiTap.DisplayMember = "TieuDe";
            _cboBaiTap.ValueMember = "MaBaiTap";
            LoadSubmissions();
        }

        private void LoadSubmissions()
        {
            var maBaiTap = UiHelpers.SelectedId(_cboBaiTap);
            if (maBaiTap > 0)
            {
                _grid.DataSource = Services.ChamBai.LayDanhSach(maBaiTap);
            }
        }

        private void PreviewSubmission()
        {
            var item = UiHelpers.SelectedItem<NopBaiDTO>(_grid);
            if (item == null) return;
            _txtNhanXet.Text = item.NhanXet;
            _numDiem.Value = item.DiemSo.HasValue ? item.DiemSo.Value : 0;
            if (!string.IsNullOrWhiteSpace(item.FileBaiLam) && File.Exists(item.FileBaiLam))
            {
                _txtPreview.Text = "Tệp bài làm: " + item.FileBaiLam + Environment.NewLine + "Có thể mở tệp bằng ứng dụng phù hợp trên máy để xem nội dung chi tiết.";
            }
            else
            {
                _txtPreview.Text = "Học viên chưa có file bài làm trong hệ thống.";
            }
        }

        private void Grade()
        {
            var item = UiHelpers.SelectedItem<NopBaiDTO>(_grid);
            if (item == null) return;
            item.DiemSo = _numDiem.Value;
            item.NhanXet = _txtNhanXet.Text.Trim();
            var result = Services.ChamBai.Cham(item);
            UiHelpers.ShowResult(result);
            if (result.Success) LoadSubmissions();
        }
    }
}
