using System;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public partial class FrmHocVien : ModuleFormBase
    {
        private int _selectedId;
        private TextBox _txtLienHe;
        private ComboBox _cboLopFilter;
        private ComboBox _cboTrangThaiFilter;
        private bool _allowGridFill;

        public FrmHocVien()
        {
            InitializeComponent();
            WireEvents();
        }

        public FrmHocVien(ServiceFactory services, NguoiDungDTO currentUser)
            : this()
        {
            SetRuntimeContext(services, currentUser);
        }

        private void WireEvents()
        {
            WireClick(btnTim, BtnTim_Click);
            WireClick(btnThem, BtnThem_Click);
            WireClick(btnLuu, BtnLuu_Click);
            WireClick(btnXoa, BtnXoa_Click);
            WireSelectionChanged(_grid, Grid_SelectionChanged);
            WireCellClick(_grid, Grid_CellClick);
        }

        protected override void OnRuntimeLoad()
        {
            ConfigureFilters();
            LoadData();
        }

        private void ConfigureFilters()
        {
            _lblDesigner1.Text = "Tên";
            _txtLienHe = UiHelpers.TextBox();
            _txtLienHe.Width = 180;
            _cboLopFilter = UiHelpers.ComboBox();
            _cboLopFilter.Width = 180;
            _cboTrangThaiFilter = UiHelpers.ComboBox();
            _cboTrangThaiFilter.Width = 150;

            var lopHoc = Services.LopHoc.LayDanhSach();
            lopHoc.Insert(0, new LopHocDTO { MaLopHoc = 0, TenLop = AppConstants.FilterAll });
            _cboLopFilter.DisplayMember = "TenLop";
            _cboLopFilter.ValueMember = "MaLopHoc";
            _cboLopFilter.DataSource = lopHoc;
            _cboTrangThaiFilter.DataSource = AppConstants.StudentStatusFilters;

            search.Controls.SetChildIndex(btnTim, search.Controls.Count - 1);
            search.Controls.Add(UiHelpers.Label("SĐT/Email"));
            search.Controls.Add(_txtLienHe);
            search.Controls.Add(UiHelpers.Label("Lớp"));
            search.Controls.Add(_cboLopFilter);
            search.Controls.Add(UiHelpers.Label("Trạng thái"));
            search.Controls.Add(_cboTrangThaiFilter);
            search.Controls.SetChildIndex(btnTim, search.Controls.Count - 1);
        }

        private void LoadData()
        {
            int? maLopHoc = null;
            if (_cboLopFilter != null && _cboLopFilter.SelectedValue != null)
            {
                int parsed;
                if (int.TryParse(_cboLopFilter.SelectedValue.ToString(), out parsed) && parsed > 0)
                {
                    maLopHoc = parsed;
                }
            }

            _grid.DataSource = SafeLoad<object>(() => Services.HocVien.TimKiem(new HocVienSearchCriteriaDTO
            {
                HoTen = _txtTim.Text,
                LienHe = _txtLienHe == null ? null : _txtLienHe.Text,
                MaLopHoc = maLopHoc,
                TrangThai = _cboTrangThaiFilter == null ? AppConstants.FilterAll : Convert.ToString(_cboTrangThaiFilter.SelectedItem)
            }), null);
            ResetGridSelection();
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
            if (_selectedId == 0)
            {
                UiHelpers.WarnSelect("học viên");
                return;
            }

            if (!UiHelpers.ConfirmDelete("học viên"))
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
            if (!_allowGridFill)
            {
                return;
            }

            FillFromGrid();
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            _allowGridFill = true;
            FillFromGrid();
        }

        private void ResetGridSelection()
        {
            _allowGridFill = false;
            _grid.ClearSelection();
            _grid.CurrentCell = null;
        }
    }
}
