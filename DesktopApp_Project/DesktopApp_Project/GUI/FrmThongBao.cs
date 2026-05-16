using System;
using DesktopApp_Project.BUS;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public partial class FrmThongBao : ModuleFormBase
    {
        public FrmThongBao()
        {
            InitializeComponent();
        }

        public FrmThongBao(ServiceFactory services, NguoiDungDTO currentUser)
            : this()
        {
            SetRuntimeContext(services, currentUser);
        }

        protected override void OnRuntimeLoad()
        {
            UiHelpers.BindLopHoc(_cboLop, Services);
            LoadData();
        }

        private void LoadData()
        {
            _grid.DataSource = Services.ThongBao.LayDanhSach();
        }

        private void BtnGui_Click(object sender, EventArgs e)
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
