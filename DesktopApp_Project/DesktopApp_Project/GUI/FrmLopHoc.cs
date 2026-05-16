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

    public partial class FrmLopHoc : ModuleFormBase
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
            InitializeComponent();
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
}
