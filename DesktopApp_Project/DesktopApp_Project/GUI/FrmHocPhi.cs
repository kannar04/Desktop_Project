using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{

    public partial class FrmHocPhi : ModuleFormBase
    {
        private readonly DataGridView _grid = UiHelpers.Grid();
        private readonly ComboBox _cboHocVien = UiHelpers.ComboBox();
        private readonly NumericUpDown _numSoTien = new NumericUpDown { Width = 160, Minimum = 0, Maximum = 1000000000, Increment = 100000 };
        private readonly TextBox _txtNganHang = UiHelpers.TextBox();
        private readonly ComboBox _cboTrangThai = UiHelpers.ComboBox();

        public FrmHocPhi(ServiceFactory services, NguoiDungDTO currentUser) : base(services, currentUser, "Thanh toán học phí")
        {
            InitializeComponent();
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
