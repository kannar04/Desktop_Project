using System;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public partial class FrmHocVien : ModuleFormBase
    {
        private int _selectedId;

        public FrmHocVien()
        {
            InitializeComponent();
        }

        public FrmHocVien(ServiceFactory services, NguoiDungDTO currentUser)
            : this()
        {
            SetRuntimeContext(services, currentUser);
        }

        protected override void OnRuntimeLoad()
        {
            LoadData();
        }

        private void LoadData()
        {
            _grid.DataSource = Services.HocVien.TimKiem(_txtTim.Text);
        }

        private void FillFromGrid()
        {
            var item = UiHelpers.SelectedItem<NguoiDungDTO>(_grid);
            if (item == null) return;

            _selectedId = item.MaNguoiDung;
            _txtHoTen.Text = item.HoTen;
            _dtNgaySinh.Value = item.NgaySinh ?? DateTime.Today;
            _txtSdt.Text = item.SDT;
            _txtEmail.Text = item.Email;
            _txtTrinhDo.Text = item.TrinhDoDauVao;
            _txtTaiKhoan.Text = item.TaiKhoan;
            _txtMatKhau.Text = item.MatKhau;
        }

        private void ClearForm()
        {
            _selectedId = 0;
            foreach (var text in new[] { _txtHoTen, _txtSdt, _txtEmail, _txtTrinhDo, _txtTaiKhoan, _txtMatKhau })
            {
                text.Clear();
            }
            _dtNgaySinh.Value = DateTime.Today;
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            var result = Services.HocVien.Luu(new NguoiDungDTO
            {
                MaNguoiDung = _selectedId,
                HoTen = _txtHoTen.Text.Trim(),
                NgaySinh = _dtNgaySinh.Value.Date,
                SDT = _txtSdt.Text.Trim(),
                Email = _txtEmail.Text.Trim(),
                TrinhDoDauVao = _txtTrinhDo.Text.Trim(),
                TaiKhoan = _txtTaiKhoan.Text.Trim(),
                MatKhau = _txtMatKhau.Text
            });

            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedId == 0) return;
            if (MessageBox.Show("Bạn có chắc muốn xóa học viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            var result = Services.HocVien.Xoa(_selectedId);
            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                ClearForm();
                LoadData();
            }
        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            FillFromGrid();
        }
    }
}
