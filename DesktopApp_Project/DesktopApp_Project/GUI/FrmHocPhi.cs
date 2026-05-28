using System;
using System.ComponentModel;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public partial class FrmHocPhi : ModuleFormBase
    {
        private System.Windows.Forms.Button _btnTaoPhieu;
        private BindingList<HocPhiTinhDTO> _previewRows = new BindingList<HocPhiTinhDTO>();

        public FrmHocPhi()
        {
            InitializeComponent();
        }

        public FrmHocPhi(ServiceFactory services, NguoiDungDTO currentUser)
            : this()
        {
            SetRuntimeContext(services, currentUser);
        }

        protected override void OnRuntimeLoad()
        {
            ConfigureClassTuitionMode();
            UiHelpers.BindLopHoc(_cboHocVien, Services);
            LoadData();
        }

        private void ConfigureClassTuitionMode()
        {
            _lblDesigner1.Text = "Lớp";
            _lblDesigner2.Text = "Số tiền gốc";
            btnTao.Text = "Tính học phí";
            btnTao.Width = 130;
            _cboTrangThai.DataSource = AppConstants.PaymentStatuses;

            _btnTaoPhieu = UiHelpers.Button("Tạo phiếu");
            _btnTaoPhieu.Width = 120;
            _btnTaoPhieu.Click += BtnTaoPhieu_Click;
            buttons.Controls.Add(_btnTaoPhieu);
        }

        private void LoadData()
        {
            _grid.DataSource = Services.HocPhi.LayDanhSach(UiHelpers.SelectedId(_cboHocVien));
        }

        private void BtnTao_Click(object sender, EventArgs e)
        {
            var result = Services.HocPhi.TinhTheoLop(UiHelpers.SelectedId(_cboHocVien), _numSoTien.Value);
            if (result.Success)
            {
                _previewRows = new BindingList<HocPhiTinhDTO>(result.Data);
                _grid.DataSource = _previewRows;
            }

            UiHelpers.ShowResult(result);
        }

        private void BtnTaoPhieu_Click(object sender, EventArgs e)
        {
            var result = Services.HocPhi.TaoYeuCauTheoLop(
                UiHelpers.SelectedId(_cboHocVien),
                _numSoTien.Value,
                _txtNganHang.Text.Trim());

            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                LoadData();
            }
        }

        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            var item = UiHelpers.SelectedItem<ThanhToanHocPhiDTO>(_grid);
            if (item == null) return;

            var result = Services.HocPhi.CapNhatTrangThai(item.MaThanhToan, Convert.ToString(_cboTrangThai.SelectedItem));
            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }
    }
}
