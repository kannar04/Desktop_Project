using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{

    public partial class FrmThongBao : ModuleFormBase
    {
        private readonly DataGridView _grid = UiHelpers.Grid();
        private readonly ComboBox _cboLop = UiHelpers.ComboBox();
        private readonly CheckBox _chkTatCa = new CheckBox { Text = "Gửi tất cả học viên", AutoSize = true, Checked = true };
        private readonly TextBox _txtTieuDe = UiHelpers.TextBox();
        private readonly TextBox _txtNoiDung = new TextBox { Width = 520, Height = 80, Multiline = true, ScrollBars = ScrollBars.Vertical };

        public FrmThongBao(ServiceFactory services, NguoiDungDTO currentUser) : base(services, currentUser, "Thông báo")
        {
            InitializeComponent();
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
}
