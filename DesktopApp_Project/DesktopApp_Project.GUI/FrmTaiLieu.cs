using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public partial class FrmTaiLieu : ModuleFormBase
    {
        private int _selectedId;
        private bool _isFilling;
        private bool _allowGridFill;

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
            WireClick(btnMoFile, BtnMoFile_Click);
            WireClick(btnUploadCloud, BtnUploadCloud_Click);
            WireSelectionChanged(_grid, Grid_SelectionChanged);
            WireCellClick(_grid, Grid_CellClick);
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
            ResetGridSelection();
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
                _txtLoaiFile.Text = item.LoaiFile;
                _txtTenFileGoc.Text = item.TenFileGoc;
                _txtDuongDanLocal.Text = item.DuongDanLocal;
                _txtCloudUrl.Text = item.DuongDanCloud;
                UpdatePreview(item.DuongDanLocal);
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
            if (_txtLoaiFile != null) _txtLoaiFile.Clear();
            if (_txtTenFileGoc != null) _txtTenFileGoc.Clear();
            if (_txtDuongDanLocal != null) _txtDuongDanLocal.Clear();
            if (_txtCloudUrl != null) _txtCloudUrl.Clear();
            ClearPreview();
        }

        private void BtnMoi_Click(object sender, EventArgs e)
        {
            _selectedId = 0;
            SaveCurrentDocument();
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            SaveCurrentDocument();
        }

        private void SaveCurrentDocument()
        {
            var localPath = !string.IsNullOrWhiteSpace(_txtDuongDanLocal.Text) ? _txtDuongDanLocal.Text.Trim() : _txtFile.Text.Trim();
            var topic = _txtChuDe.Text.Trim();
            if (string.IsNullOrWhiteSpace(topic) && !string.IsNullOrWhiteSpace(_txtTenFileGoc.Text))
            {
                topic = Path.GetFileNameWithoutExtension(_txtTenFileGoc.Text.Trim());
                _txtChuDe.Text = topic;
            }

            var result = Services.TaiLieu.Luu(new TaiLieuDTO
            {
                MaTaiLieu = _selectedId,
                MaLopHoc = UiHelpers.SelectedId(_cboLop),
                TenChuDe = topic,
                NoiDungMoTa = _txtMoTa.Text.Trim(),
                DuongDanFile = string.IsNullOrWhiteSpace(_txtFile.Text) ? localPath : _txtFile.Text.Trim(),
                VideoLink = _txtVideo.Text.Trim(),
                NhanKyNang = Convert.ToString(_cboKyNang.SelectedItem),
                LoaiFile = _txtLoaiFile.Text.Trim(),
                TenFileGoc = _txtTenFileGoc.Text.Trim(),
                DuongDanLocal = localPath,
                DuongDanCloud = _txtCloudUrl.Text.Trim(),
                ThumbnailPath = Services.Media.IsImage(localPath) ? localPath : string.Empty
            });

            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                LoadData();
                SelectSavedRow(localPath, topic);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedId == 0)
            {
                UiHelpers.WarnSelect("tai lieu");
                return;
            }

            if (!UiHelpers.ConfirmDelete("tai lieu"))
            {
                return;
            }

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
            using (var dialog = new OpenFileDialog { Filter = "Tai lieu va media|*.pdf;*.doc;*.docx;*.ppt;*.pptx;*.xls;*.xlsx;*.txt;*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.mp3;*.wav;*.m4a;*.mp4;*.mov;*.avi;*.mkv|Tat ca|*.*" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var result = Services.Media.CopyFileToUploadFolder(dialog.FileName, "TaiLieu");
                    UiHelpers.ShowResult(result);
                    if (!result.Success)
                    {
                        return;
                    }

                    _txtFile.Text = result.Data.LocalPath;
                    _txtDuongDanLocal.Text = result.Data.LocalPath;
                    _txtLoaiFile.Text = result.Data.FileType;
                    _txtTenFileGoc.Text = result.Data.OriginalFileName;
                    if (string.IsNullOrWhiteSpace(_txtChuDe.Text))
                    {
                        _txtChuDe.Text = Path.GetFileNameWithoutExtension(result.Data.OriginalFileName);
                    }
                    UpdatePreview(result.Data.LocalPath);
                }
            }
        }

        private void BtnMoFile_Click(object sender, EventArgs e)
        {
            var path = !string.IsNullOrWhiteSpace(_txtDuongDanLocal.Text) ? _txtDuongDanLocal.Text : _txtFile.Text;
            UiHelpers.ShowResult(Services.Media.OpenFile(path));
        }

        private void BtnUploadCloud_Click(object sender, EventArgs e)
        {
            var path = !string.IsNullOrWhiteSpace(_txtDuongDanLocal.Text) ? _txtDuongDanLocal.Text : _txtFile.Text;
            var result = Services.Media.UploadToFakeCloud(path, "TaiLieu");
            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                _txtCloudUrl.Text = result.Data;
            }
        }

        private void SelectSavedRow(string localPath, string topic)
        {
            foreach (DataGridViewRow row in _grid.Rows)
            {
                var item = row.DataBoundItem as TaiLieuDTO;
                if (item == null)
                {
                    continue;
                }

                var samePath = !string.IsNullOrWhiteSpace(localPath)
                    && (string.Equals(item.DuongDanLocal, localPath, StringComparison.OrdinalIgnoreCase)
                        || string.Equals(item.DuongDanFile, localPath, StringComparison.OrdinalIgnoreCase));
                var sameTopic = !string.IsNullOrWhiteSpace(topic)
                    && string.Equals(item.TenChuDe, topic, StringComparison.OrdinalIgnoreCase);

                if ((_selectedId > 0 && item.MaTaiLieu == _selectedId) || samePath || sameTopic)
                {
                    _allowGridFill = true;
                    _grid.ClearSelection();
                    row.Selected = true;
                    _grid.CurrentCell = row.Cells[0];
                    FillFromGrid();
                    return;
                }
            }
        }

        private void UpdatePreview(string localPath)
        {
            ClearPreview();
            if (_picPreview == null)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(localPath))
            {
                SetPreviewMessage("Chua chon file", "Hay bam Chon file de them tai lieu.");
                return;
            }

            var resolved = Services.Media.ResolvePath(localPath);
            if (!File.Exists(resolved))
            {
                SetPreviewMessage("Khong tim thay file", localPath);
                return;
            }

            if (!Services.Media.IsImage(localPath))
            {
                var fileName = Path.GetFileName(resolved);
                var fileType = Services.Media.GetFileType(localPath);
                SetPreviewMessage(fileType + ": " + fileName, "File nay khong phai anh nen khong co preview hinh.");
                return;
            }

            try
            {
                using (var image = Image.FromFile(resolved))
                {
                    _picPreview.Image = new Bitmap(image);
                }
            }
            catch
            {
                SetPreviewMessage("Khong the doc anh", localPath);
            }
        }

        private void ClearPreview()
        {
            if (_picPreview == null)
            {
                return;
            }

            var old = _picPreview.Image;
            _picPreview.Image = null;
            if (old != null)
            {
                old.Dispose();
            }
        }

        private void SetPreviewMessage(string title, string detail)
        {
            if (_picPreview == null)
            {
                return;
            }

            var width = Math.Max(360, _picPreview.Width);
            var height = Math.Max(120, _picPreview.Height);
            var bitmap = new Bitmap(width, height);
            using (var graphics = Graphics.FromImage(bitmap))
            using (var titleFont = new Font("Segoe UI", 11F, FontStyle.Bold))
            using (var detailFont = new Font("Segoe UI", 9F, FontStyle.Regular))
            using (var background = new SolidBrush(Color.FromArgb(36, 36, 54)))
            using (var titleBrush = new SolidBrush(Color.White))
            using (var detailBrush = new SolidBrush(Color.FromArgb(190, 190, 210)))
            using (var borderPen = new Pen(Color.FromArgb(90, 90, 115)))
            {
                graphics.Clear(Color.FromArgb(36, 36, 54));
                graphics.FillRectangle(background, 0, 0, width, height);
                graphics.DrawRectangle(borderPen, 0, 0, width - 1, height - 1);
                graphics.DrawString(title ?? string.Empty, titleFont, titleBrush, new RectangleF(16, 24, width - 32, 28));
                graphics.DrawString(detail ?? string.Empty, detailFont, detailBrush, new RectangleF(16, 58, width - 32, height - 70));
            }

            _picPreview.Image = bitmap;
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
            _allowGridFill = false;
            _grid.ClearSelection();
            _grid.CurrentCell = null;
        }
    }
}
