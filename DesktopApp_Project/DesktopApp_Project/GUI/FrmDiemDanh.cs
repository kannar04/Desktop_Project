using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public partial class FrmDiemDanh : ModuleFormBase
    {
        private readonly ComboBox _cboLop = UiHelpers.ComboBox();
        private readonly DateTimePicker _dtNgay = new DateTimePicker { Width = 150, Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy" };
        private readonly DataGridView _grid = UiHelpers.Grid();
        private readonly ComboBox _cboTrangThai = UiHelpers.ComboBox();
        private readonly TextBox _txtLyDo = UiHelpers.TextBox();

        public FrmDiemDanh(ServiceFactory services, NguoiDungDTO currentUser) : base(services, currentUser, "Điểm danh và báo cáo chuyên cần")
        {
            InitializeComponent();
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
}
