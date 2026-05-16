using System;
using DesktopApp_Project.BUS;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public partial class FrmDiemDanh : ModuleFormBase
    {
        public FrmDiemDanh()
        {
            InitializeComponent();
        }

        public FrmDiemDanh(ServiceFactory services, NguoiDungDTO currentUser)
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

        private void BtnTai_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            var item = UiHelpers.SelectedItem<DiemDanhDTO>(_grid);
            if (item == null) return;

            item.TrangThai = Convert.ToString(_cboTrangThai.SelectedItem);
            item.LyDoVang = _txtLyDo.Text.Trim();
            var result = Services.DiemDanh.Luu(item);
            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            Fill();
        }
    }
}
