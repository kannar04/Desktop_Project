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
            ConfigureClassSelector();
            LoadData();
        }

        private void ConfigureFilters()
        {
            _lblDesigner1.Text = "Tên";
            var lopHoc = Services.LopHoc.LayDanhSach();
            lopHoc.Insert(0, new LopHocDTO { MaLopHoc = 0, TenLop = AppConstants.FilterAll });
            _cboLopFilter.DisplayMember = "TenLop";
            _cboLopFilter.ValueMember = "MaLopHoc";
            _cboLopFilter.DataSource = lopHoc;
            _cboTrangThaiFilter.DataSource = AppConstants.StudentStatusFilters;
        }

        private void ConfigureClassSelector()
        {
            LoadClassSelector();
        }

        private void LoadClassSelector()
        {
            if (_cboLop == null)
            {
                return;
            }

            var lopHoc = Services.LopHoc.LayDanhSach();
            lopHoc.Insert(0, new LopHocDTO { MaLopHoc = 0, TenLop = "-- Chọn lớp --" });
            _cboLop.DisplayMember = "TenLop";
            _cboLop.ValueMember = "MaLopHoc";
            _cboLop.DataSource = lopHoc;
        }

        private void SelectClass(int maLopHoc)
        {
            if (_cboLop == null)
            {
                return;
            }

            foreach (var item in _cboLop.Items)
            {
                var lopHoc = item as LopHocDTO;
                if (lopHoc != null && lopHoc.MaLopHoc == maLopHoc)
                {
                    _cboLop.SelectedValue = maLopHoc;
                    return;
                }
            }

            _cboLop.SelectedValue = 0;
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
            var maLopHoc = SafeLoad<int?>(() => Services.HocVien.LayLopDangHoc(item.MaNguoiDung), null);
            SelectClass(maLopHoc.HasValue ? maLopHoc.Value : 0);
        }

        private void ClearForm()
        {
            _selectedId = 0;
            foreach (var text in new[] { _txtHoTen, _txtSdt, _txtEmail, _txtTrinhDo, _txtTaiKhoan, _txtMatKhau })
            {
                text.Clear();
            }
            _dtNgaySinh.Value = DateTime.Today;
            if (_cboLop != null)
            {
                SelectClass(0);
            }
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            var result = Services.HocVien.LuuVoiLop(BuildDto(0), UiHelpers.SelectedId(_cboLop));
            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                LoadData();
                ClearForm();
                ResetGridSelection();
                _txtHoTen.Focus();
            }
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (_selectedId == 0)
            {
                UiHelpers.WarnSelect("hoc vien");
                return;
            }

            var result = Services.HocVien.LuuVoiLop(BuildDto(_selectedId), UiHelpers.SelectedId(_cboLop));

            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }

        private NguoiDungDTO BuildDto(int maNguoiDung)
        {
            return new NguoiDungDTO
            {
                MaNguoiDung = maNguoiDung,
                HoTen = _txtHoTen.Text.Trim(),
                NgaySinh = _dtNgaySinh.Value.Date,
                SDT = _txtSdt.Text.Trim(),
                Email = _txtEmail.Text.Trim(),
                TrinhDoDauVao = _txtTrinhDo.Text.Trim(),
                TaiKhoan = _txtTaiKhoan.Text.Trim(),
                MatKhau = _txtMatKhau.Text
            };
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
            _selectedId = 0;
            _allowGridFill = false;
            _grid.ClearSelection();
            _grid.CurrentCell = null;
        }
    }
}