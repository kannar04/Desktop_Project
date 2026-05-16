using System;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public partial class FrmBaiTap : ModuleFormBase
    {
        private int _selectedId;

        public FrmBaiTap()
            : base("Cập nhật và giao bài tập")
        {
            InitializeComponent();
        }
        public FrmBaiTap(ServiceFactory services, NguoiDungDTO currentUser)
            : base(services, currentUser, "Cập nhật và giao bài tập")
        {
            InitializeComponent();
            UiHelpers.BindLopHoc(_cboLop, Services);
            _dtDeadline.Value = DateTime.Now.AddDays(7);
            LoadData();
        }

        private void LoadData()
        {
            var maLop = UiHelpers.SelectedId(_cboLop);
            _grid.DataSource = Services.BaiTap.LayDanhSach(maLop == 0 ? (int?)null : maLop);
        }

        private void FillFromGrid()
        {
            var item = UiHelpers.SelectedItem<BaiTapDTO>(_grid);
            if (item == null) return;

            _selectedId = item.MaBaiTap;
            _cboLop.SelectedValue = item.MaLopHoc;
            _txtTieuDe.Text = item.TieuDe;
            _txtMoTa.Text = item.MoTa;
            _txtFile.Text = item.FileDinhKem;
            _dtDeadline.Value = item.Deadline;
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
            ClearForm();
        }

        private void BtnGiao_Click(object sender, EventArgs e)
        {
            var result = Services.BaiTap.GiaoBai(new BaiTapDTO
            {
                MaBaiTap = _selectedId,
                MaLopHoc = UiHelpers.SelectedId(_cboLop),
                TieuDe = _txtTieuDe.Text.Trim(),
                MoTa = _txtMoTa.Text.Trim(),
                Deadline = _dtDeadline.Value,
                FileDinhKem = _txtFile.Text.Trim()
            });

            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedId == 0) return;

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
