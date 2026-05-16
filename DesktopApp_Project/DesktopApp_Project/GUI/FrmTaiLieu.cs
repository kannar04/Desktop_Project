using System;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public partial class FrmTaiLieu : ModuleFormBase
    {
        private int _selectedId;

        public FrmTaiLieu()
            : base("Cập nhật tài liệu giảng dạy")
        {
            InitializeComponent();
        }
        public FrmTaiLieu(ServiceFactory services, NguoiDungDTO currentUser)
            : base(services, currentUser, "Cập nhật tài liệu giảng dạy")
        {
            InitializeComponent();
            UiHelpers.BindLopHoc(_cboLop, Services);
            UiHelpers.BindKyNang(_cboKyNang);
            LoadData();
        }

        private void LoadData()
        {
            var maLop = UiHelpers.SelectedId(_cboLop);
            _grid.DataSource = Services.TaiLieu.LayDanhSach(maLop == 0 ? (int?)null : maLop);
        }

        private void FillFromGrid()
        {
            var item = UiHelpers.SelectedItem<TaiLieuDTO>(_grid);
            if (item == null) return;

            _selectedId = item.MaTaiLieu;
            _cboLop.SelectedValue = item.MaLopHoc;
            _cboKyNang.SelectedItem = item.NhanKyNang;
            _txtChuDe.Text = item.TenChuDe;
            _txtMoTa.Text = item.NoiDungMoTa;
            _txtFile.Text = item.DuongDanFile;
            _txtVideo.Text = item.VideoLink;
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
                    _txtFile.Text = dialog.FileName;
                }
            }
        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            FillFromGrid();
        }

        private void CboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
