using System;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public partial class FrmTaiLieu : ModuleFormBase
    {
        private int _selectedId;
        private bool _isFilling;

        public FrmTaiLieu()
        {
            InitializeComponent();
            WireEvents();
        }

        public FrmTaiLieu(ServiceFactory services, NguoiDungDTO currentUser)
            : this()
        {
            SetRuntimeContext(services, currentUser);
        }

        private void WireEvents()
        {
            WireClick(btnMoi, BtnMoi_Click);
            WireClick(btnLuu, BtnLuu_Click);
            WireClick(btnXoa, BtnXoa_Click);
            WireClick(btnFile, BtnFile_Click);
            WireSelectionChanged(_grid, Grid_SelectionChanged);
            WireSelectedIndexChanged(_cboLop, CboLop_SelectedIndexChanged);
        }

        protected override void OnRuntimeLoad()
        {
            UiHelpers.BindLopHoc(_cboLop, Services);
            UiHelpers.BindKyNang(_cboKyNang);
            LoadData();
        }

        private void LoadData()
        {
            var maLop = UiHelpers.SelectedId(_cboLop);
            _grid.DataSource = SafeLoad<object>(() => Services.TaiLieu.LayDanhSach(maLop == 0 ? (int?)null : maLop), null);
        }

        private void FillFromGrid()
        {
            var item = UiHelpers.SelectedItem<TaiLieuDTO>(_grid);
            if (item == null) return;

            _isFilling = true;
            try
            {
                _selectedId = item.MaTaiLieu;
                if (!string.IsNullOrEmpty(_cboLop.ValueMember))
                {
                    _cboLop.SelectedValue = item.MaLopHoc;
                }
                _cboKyNang.SelectedItem = item.NhanKyNang;
                _txtChuDe.Text = item.TenChuDe;
                _txtMoTa.Text = item.NoiDungMoTa;
                _txtFile.Text = item.DuongDanFile;
                _txtVideo.Text = item.VideoLink;
            }
            finally
            {
                _isFilling = false;
            }
        }

        private void ClearForm()
        {
            _selectedId = 0;
            _txtChuDe.Clear();
            _txtMoTa.Clear();
            _txtFile.Clear();
            _txtVideo.Clear();
        }

        private void BtnMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            var result = Services.TaiLieu.Luu(new TaiLieuDTO
            {
                MaTaiLieu = _selectedId,
                MaLopHoc = UiHelpers.SelectedId(_cboLop),
                TenChuDe = _txtChuDe.Text.Trim(),
                NoiDungMoTa = _txtMoTa.Text.Trim(),
                DuongDanFile = _txtFile.Text.Trim(),
                VideoLink = _txtVideo.Text.Trim(),
                NhanKyNang = Convert.ToString(_cboKyNang.SelectedItem)
            });

            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedId == 0) return;

            var result = Services.TaiLieu.Xoa(_selectedId);
            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                ClearForm();
                LoadData();
            }
        }

        private void BtnFile_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog { Filter = "Tài liệu|*.pdf;*.doc;*.docx|Tất cả|*.*" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _txtFile.Text = ManagedFileStorage.CopyToManagedFolder(dialog.FileName, "TaiLieu");
                }
            }
        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            FillFromGrid();
        }

        private void CboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFilling)
            {
                return;
            }

            LoadData();
        }
    }
}
