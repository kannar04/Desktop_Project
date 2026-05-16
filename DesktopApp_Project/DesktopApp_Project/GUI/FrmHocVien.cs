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
    public partial class FrmHocVien : ModuleFormBase
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
            InitializeComponent();
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
}
