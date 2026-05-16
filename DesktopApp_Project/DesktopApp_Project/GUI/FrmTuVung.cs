using System;
using DesktopApp_Project.BUS;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public partial class FrmTuVung : ModuleFormBase
    {
        private int _selectedId;

        public FrmTuVung()
            : base("Cập nhật kho từ vựng")
        {
            InitializeComponent();
        }
        public FrmTuVung(ServiceFactory services, NguoiDungDTO currentUser)
            : base(services, currentUser, "Cập nhật kho từ vựng")
        {
            InitializeComponent();
            UiHelpers.BindLopHoc(_cboLop, Services);
            LoadData();
        }

        private void LoadData()
        {
            _grid.DataSource = Services.TuVung.LayDanhSach(UiHelpers.SelectedId(_cboLop));
        }

        private void Fill()
        {
            var item = UiHelpers.SelectedItem<TuVungDTO>(_grid);
            if (item == null) return;

            _selectedId = item.MaTuVung;
            _cboLop.SelectedValue = item.MaLopHoc;
            _txtTu.Text = item.TuTiengAnh;
            _txtLoai.Text = item.TuLoai;
            _txtPhienAm.Text = item.PhienAm;
            _txtNghia.Text = item.Nghia;
        }

        private void ClearForm()
        {
            _selectedId = 0;
            _txtTu.Clear();
            _txtLoai.Clear();
            _txtPhienAm.Clear();
            _txtNghia.Clear();
        }

        private void BtnMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            var result = Services.TuVung.Luu(new TuVungDTO
            {
                MaTuVung = _selectedId,
                MaLopHoc = UiHelpers.SelectedId(_cboLop),
                TuTiengAnh = _txtTu.Text.Trim(),
                TuLoai = _txtLoai.Text.Trim(),
                PhienAm = _txtPhienAm.Text.Trim(),
                Nghia = _txtNghia.Text.Trim()
            });

            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedId == 0) return;

            var result = Services.TuVung.Xoa(_selectedId);
            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                ClearForm();
                LoadData();
            }
        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            Fill();
        }

        private void CboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
