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
            WireEvents();
        }

        public FrmHocPhi(ServiceFactory services, NguoiDungDTO currentUser)
            : this()
        {
            SetRuntimeContext(services, currentUser);
        }

        private void WireEvents()
        {
            WireClick(btnTao, BtnTao_Click);
            WireClick(btnCapNhat, BtnCapNhat_Click);
            WireSelectedIndexChanged(_cboHocVien, CboHocVien_SelectedIndexChanged);
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
            WireClick(_btnTaoPhieu, BtnTaoPhieu_Click);
            buttons.Controls.Add(_btnTaoPhieu);
        }

        private void LoadData()
        {
            _grid.DataSource = SafeLoad<object>(() => Services.HocPhi.LayDanhSach(UiHelpers.SelectedId(_cboHocVien)), null);
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

        private void CboHocVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
