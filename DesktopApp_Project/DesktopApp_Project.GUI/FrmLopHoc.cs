using System;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public partial class FrmLopHoc : ModuleFormBase
    {
        private int _selectedClassId;

        public FrmLopHoc()
        {
            InitializeComponent();
            WireEvents();
        }

        public FrmLopHoc(ServiceFactory services, NguoiDungDTO currentUser)
            : this()
        {
            SetRuntimeContext(services, currentUser);
        }

        private void WireEvents()
        {
            WireClick(btnThem, BtnThem_Click);
            WireClick(btnLuu, BtnLuu_Click);
            WireClick(btnXoa, BtnXoa_Click);
            WireClick(btnThemHv, BtnThemHv_Click);
            WireClick(btnXoaHv, BtnXoaHv_Click);
            WireSelectionChanged(_gridLop, GridLop_SelectionChanged);
        }

        protected override void OnRuntimeLoad()
        {
            LoadClasses();
        }

        private void LoadClasses()
        {
            _gridLop.DataSource = SafeLoad<object>(() => Services.LopHoc.LayDanhSach(), null);
        }

        private void FillClass()
        {
            var item = UiHelpers.SelectedItem<LopHocDTO>(_gridLop);
            if (item == null) return;

            _selectedClassId = item.MaLopHoc;
            _txtTenLop.Text = item.TenLop;
            _txtTrinhDo.Text = item.NhomTrinhDo;
            _txtLichHoc.Text = item.LichHoc;
            LoadStudents();
        }

        private void LoadStudents()
        {
            if (_selectedClassId <= 0)
            {
                _gridTrongLop.DataSource = null;
                _gridNgoaiLop.DataSource = null;
                return;
            }

            _gridTrongLop.DataSource = SafeLoad<object>(() => Services.LopHoc.LayHocVienTrongLop(_selectedClassId), null);
            _gridNgoaiLop.DataSource = SafeLoad<object>(() => Services.LopHoc.LayHocVienChuaTrongLop(_selectedClassId), null);
        }

        private void ClearForm()
        {
            _selectedClassId = 0;
            _txtTenLop.Clear();
            _txtTrinhDo.Clear();
            _txtLichHoc.Clear();
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (!HasCurrentUser())
            {
                return;
            }

            var result = Services.LopHoc.Luu(new LopHocDTO
            {
                MaLopHoc = _selectedClassId,
                MaGiaoVien = CurrentUser.MaNguoiDung,
                TenLop = _txtTenLop.Text.Trim(),
                NhomTrinhDo = _txtTrinhDo.Text.Trim(),
                LichHoc = _txtLichHoc.Text.Trim()
            });

            UiHelpers.ShowResult(result);
            if (result.Success) LoadClasses();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedClassId == 0)
            {
                UiHelpers.WarnSelect("lớp học");
                return;
            }

            if (!UiHelpers.ConfirmDelete("lớp học"))
            {
                return;
            }

            var result = Services.LopHoc.Xoa(_selectedClassId);
            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                ClearForm();
                LoadClasses();
                LoadStudents();
            }
        }

        private void BtnThemHv_Click(object sender, EventArgs e)
        {
            var item = UiHelpers.SelectedItem<NguoiDungDTO>(_gridNgoaiLop);
            if (item == null || _selectedClassId == 0) return;

            var result = Services.LopHoc.ThemHocVien(item.MaNguoiDung, _selectedClassId);
            UiHelpers.ShowResult(result);
            if (result.Success) LoadStudents();
        }

        private void BtnXoaHv_Click(object sender, EventArgs e)
        {
            var item = UiHelpers.SelectedItem<NguoiDungDTO>(_gridTrongLop);
            if (item == null || _selectedClassId == 0)
            {
                UiHelpers.WarnSelect("học viên trong lớp");
                return;
            }

            if (!UiHelpers.ConfirmDelete("học viên khỏi lớp"))
            {
                return;
            }

            var result = Services.LopHoc.XoaHocVien(item.MaNguoiDung, _selectedClassId);
            UiHelpers.ShowResult(result);
            if (result.Success) LoadStudents();
        }

        private void GridLop_SelectionChanged(object sender, EventArgs e)
        {
            FillClass();
        }
    }
}
