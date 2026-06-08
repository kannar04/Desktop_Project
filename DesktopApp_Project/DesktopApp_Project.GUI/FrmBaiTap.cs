using System;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public partial class FrmBaiTap : ModuleFormBase
    {
        private int _selectedId;
        private bool _isFilling;
        private bool _allowGridFill;

        public FrmBaiTap()
        {
            InitializeComponent();
            WireEvents();
        }

        public FrmBaiTap(ServiceFactory services, NguoiDungDTO currentUser)
            : this()
        {
            SetRuntimeContext(services, currentUser);
        }

        private void WireEvents()
        {
            WireClick(btnMoi, BtnMoi_Click);
            WireClick(btnGiao, BtnGiao_Click);
            WireClick(btnXoa, BtnXoa_Click);
            WireClick(btnFile, BtnFile_Click);
            WireSelectionChanged(_grid, Grid_SelectionChanged);
            WireCellClick(_grid, Grid_CellClick);
            WireSelectedIndexChanged(_cboLop, CboLop_SelectedIndexChanged);
        }

        protected override void OnRuntimeLoad()
        {
            UiHelpers.BindLopHoc(_cboLop, Services);
            _dtDeadline.Value = DateTime.Now.AddDays(7);
            LoadData();
        }

        private void LoadData()
        {
            var maLop = UiHelpers.SelectedId(_cboLop);
            _grid.DataSource = SafeLoad<object>(() => Services.BaiTap.LayDanhSach(maLop == 0 ? (int?)null : maLop), null);
            ResetGridSelection();
        }

        private void FillFromGrid()
        {
            var item = UiHelpers.SelectedItem<BaiTapDTO>(_grid);
            if (item == null) return;

            _isFilling = true;
            try
            {
                _selectedId = item.MaBaiTap;
                if (!string.IsNullOrEmpty(_cboLop.ValueMember))
                {
                    _cboLop.SelectedValue = item.MaLopHoc;
                }
                _txtTieuDe.Text = item.TieuDe;
                _txtMoTa.Text = item.MoTa;
                _txtFile.Text = item.FileDinhKem;
                _dtDeadline.Value = item.Deadline;
            }
            finally
            {
                _isFilling = false;
            }
        }

        private void ClearForm()
        {
            _selectedId = 0;
            _txtTieuDe.Clear();
            _txtMoTa.Clear();
            _txtFile.Clear();
            _dtDeadline.Value = DateTime.Now.AddDays(7);
        }

        private void BtnMoi_Click(object sender, EventArgs e)
        {
            var result = Services.BaiTap.GiaoBai(BuildDto(0));
            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                LoadData();
                ClearForm();
                ResetGridSelection();
                _txtTieuDe.Focus();
            }
        }

        private void BtnGiao_Click(object sender, EventArgs e)
        {
            if (_selectedId == 0)
            {
                UiHelpers.WarnSelect("bai tap");
                return;
            }

            var result = Services.BaiTap.GiaoBai(BuildDto(_selectedId));

            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }

        private BaiTapDTO BuildDto(int maBaiTap)
        {
            return new BaiTapDTO
            {
                MaBaiTap = maBaiTap,
                MaLopHoc = UiHelpers.SelectedId(_cboLop),
                TieuDe = _txtTieuDe.Text.Trim(),
                MoTa = _txtMoTa.Text.Trim(),
                Deadline = _dtDeadline.Value,
                FileDinhKem = _txtFile.Text.Trim()
            };
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedId == 0)
            {
                UiHelpers.WarnSelect("bài tập");
                return;
            }

            if (!UiHelpers.ConfirmDelete("bài tập"))
            {
                return;
            }

            var result = Services.BaiTap.Xoa(_selectedId);
            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                ClearForm();
                LoadData();
            }
        }

        private void BtnFile_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog { Filter = "File bài tập|*.pdf;*.doc;*.docx;*.zip;*.rar|Tất cả|*.*" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _txtFile.Text = ManagedFileStorage.CopyToManagedFolder(dialog.FileName, "BaiTap");
                }
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

        private void CboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFilling)
            {
                return;
            }

            ClearForm();
            LoadData();
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
