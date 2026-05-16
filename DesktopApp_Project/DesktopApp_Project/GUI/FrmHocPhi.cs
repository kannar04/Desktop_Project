using System;
using DesktopApp_Project.BUS;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public partial class FrmHocPhi : ModuleFormBase
    {
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
            _cboHocVien.DataSource = Services.HocVien.TimKiem(null);
            _cboHocVien.DisplayMember = "HoTen";
            _cboHocVien.ValueMember = "MaNguoiDung";
            LoadData();
        }

        private void LoadData()
        {
            _grid.DataSource = Services.HocPhi.LayDanhSach();
        }

        private void BtnTao_Click(object sender, EventArgs e)
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
