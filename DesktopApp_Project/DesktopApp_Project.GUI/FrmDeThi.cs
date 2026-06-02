using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public partial class FrmDeThi : ModuleFormBase
    {
        private int _selectedId;
        private bool _isFilling;
        private bool _allowGridFill;

        public FrmDeThi()
        {
            InitializeComponent();
            WireEvents();
        }

        public FrmDeThi(ServiceFactory services, NguoiDungDTO currentUser)
            : this()
        {
            SetRuntimeContext(services, currentUser);
        }

        private void WireEvents()
        {
            WireClick(btnMoi, BtnMoi_Click);
            WireClick(btnLuu, BtnLuu_Click);
            WireClick(btnXoa, BtnXoa_Click);
            WireClick(btnChonFile, BtnChonFile_Click);
            WireClick(btnChonAudio, BtnChonAudio_Click);
            WireClick(btnChonAnh, BtnChonAnh_Click);
            WireClick(btnMoFile, BtnMoFile_Click);
            WireClick(btnMoAudio, BtnMoAudio_Click);
            WireSelectionChanged(grid, Grid_SelectionChanged);
            WireCellClick(grid, Grid_CellClick);
        }

        protected override void OnRuntimeLoad()
        {
            UiHelpers.BindKyNang(cboKyNang);
            cboTrangThai.DataSource = new[] { "DangTao", "DaDuyet", "NgungDung" };
            numBandLevel.Value = 5;
            LoadData();
        }

        private void LoadData()
        {
            if (!CanUseServices)
            {
                return;
            }

            grid.DataSource = SafeLoad<object>(() => Services.DeThi.LayDeThi(), null);
            ResetGridSelection();
        }

        private void FillFromGrid()
        {
            var item = UiHelpers.SelectedItem<DeThiDTO>(grid);
            if (item == null)
            {
                return;
            }

            _isFilling = true;
            try
            {
                _selectedId = item.MaDeThi;
                txtTenDe.Text = item.TenDeThi;
                cboKyNang.SelectedItem = item.KyNang;
                numBandLevel.Value = ClampBand(item.BandLevel ?? item.BandTu ?? 0);
                txtMoTa.Text = item.MoTa;
                txtFile.Text = item.FileDuLieu;
                txtAudio.Text = item.AudioPath;
                txtImage.Text = item.ImagePath;
                cboTrangThai.SelectedItem = string.IsNullOrWhiteSpace(item.TrangThai) ? "DangTao" : item.TrangThai;
                UpdateImagePreview(item.ImagePath);
            }
            finally
            {
                _isFilling = false;
            }
        }

        private void ClearForm()
        {
            _selectedId = 0;
            txtTenDe.Clear();
            txtMoTa.Clear();
            txtFile.Clear();
            txtAudio.Clear();
            txtImage.Clear();
            if (cboKyNang.Items.Count > 0) cboKyNang.SelectedIndex = 0;
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;
            numBandLevel.Value = 5;
            ClearPreview();
        }

        private void BtnMoi_Click(object sender, EventArgs e)
        {
            _selectedId = 0;
            SaveExam();
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            SaveExam();
        }

        private void SaveExam()
        {
            var result = Services.DeThi.Luu(new DeThiDTO
            {
                MaDeThi = _selectedId,
                TenDeThi = txtTenDe.Text.Trim(),
                KyNang = Convert.ToString(cboKyNang.SelectedItem),
                BandLevel = numBandLevel.Value,
                BandTu = null,
                BandDen = null,
                MoTa = txtMoTa.Text.Trim(),
                FileDuLieu = txtFile.Text.Trim(),
                AudioPath = txtAudio.Text.Trim(),
                ImagePath = txtImage.Text.Trim(),
                TrangThai = Convert.ToString(cboTrangThai.SelectedItem)
            });

            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                LoadData();
                SelectSavedRow(txtTenDe.Text.Trim(), txtFile.Text.Trim());
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedId == 0)
            {
                UiHelpers.WarnSelect("de thi");
                return;
            }

            if (!UiHelpers.ConfirmDelete("de thi"))
            {
                return;
            }

            var result = Services.DeThi.Xoa(_selectedId);
            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                ClearForm();
                LoadData();
            }
        }

        private void BtnChonFile_Click(object sender, EventArgs e)
        {
            ChooseManagedFile("File de thi|*.pdf;*.doc;*.docx;*.xlsx|Tat ca|*.*", txtFile, false);
        }

        private void BtnChonAudio_Click(object sender, EventArgs e)
        {
            ChooseManagedFile("Audio|*.mp3;*.wav|Tat ca|*.*", txtAudio, false);
        }

        private void BtnChonAnh_Click(object sender, EventArgs e)
        {
            ChooseManagedFile("Anh|*.jpg;*.jpeg;*.png|Tat ca|*.*", txtImage, true);
        }

        private void ChooseManagedFile(string filter, TextBox target, bool previewImage)
        {
            using (var dialog = new OpenFileDialog { Filter = filter })
            {
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                var result = Services.Media.CopyFileToUploadFolder(dialog.FileName, "DeThi");
                UiHelpers.ShowResult(result);
                if (!result.Success)
                {
                    return;
                }

                target.Text = result.Data.LocalPath;
                if (string.IsNullOrWhiteSpace(txtTenDe.Text) && target == txtFile)
                {
                    txtTenDe.Text = Path.GetFileNameWithoutExtension(result.Data.OriginalFileName);
                }

                if (previewImage)
                {
                    UpdateImagePreview(result.Data.LocalPath);
                }
            }
        }

        private void BtnMoFile_Click(object sender, EventArgs e)
        {
            var result = Services.Media.OpenFile(txtFile.Text);
            if (!result.Success)
            {
                UiHelpers.ShowResult(result);
            }
        }

        private void BtnMoAudio_Click(object sender, EventArgs e)
        {
            var result = Services.Media.OpenFile(txtAudio.Text);
            if (!result.Success)
            {
                UiHelpers.ShowResult(result);
            }
        }

        private void UpdateImagePreview(string path)
        {
            ClearPreview();
            if (string.IsNullOrWhiteSpace(path))
            {
                return;
            }

            var resolved = Services.Media.ResolvePath(path);
            if (!File.Exists(resolved))
            {
                return;
            }

            try
            {
                using (var image = Image.FromFile(resolved))
                {
                    picPreview.Image = new Bitmap(image);
                }
            }
            catch
            {
                ClearPreview();
            }
        }

        private void ClearPreview()
        {
            var old = picPreview.Image;
            picPreview.Image = null;
            if (old != null)
            {
                old.Dispose();
            }
        }

        private void SelectSavedRow(string name, string filePath)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                var item = row.DataBoundItem as DeThiDTO;
                if (item == null)
                {
                    continue;
                }

                if ((_selectedId > 0 && item.MaDeThi == _selectedId)
                    || string.Equals(item.TenDeThi, name, StringComparison.OrdinalIgnoreCase)
                    || (!string.IsNullOrWhiteSpace(filePath) && string.Equals(item.FileDuLieu, filePath, StringComparison.OrdinalIgnoreCase)))
                {
                    _allowGridFill = true;
                    grid.ClearSelection();
                    row.Selected = true;
                    grid.CurrentCell = row.Cells[0];
                    FillFromGrid();
                    return;
                }
            }
        }

        private static decimal ClampBand(decimal value)
        {
            if (value < 0) return 0;
            if (value > 9) return 9;
            return value;
        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            if (_isFilling || !_allowGridFill)
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
            grid.ClearSelection();
            grid.CurrentCell = null;
        }
    }
}
