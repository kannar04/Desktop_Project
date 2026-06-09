// Biểu mẫu quản lý tài liệu học tập
// Chức năng:
// - Hiển thị và nhập dữ liệu tài liệu học tập
// - Gọi tầng nghiệp vụ để tải, lưu hoặc xóa dữ liệu
// - Cập nhật trạng thái giao diện sau thao tác của người dùng

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    // Lớp biểu mẫu Windows Forms chịu trách nhiệm hiển thị tài liệu học tập và gọi tầng nghiệp vụ khi người dùng thao tác.
    public partial class FrmTaiLieu : ModuleFormBase
    {
        private int _selectedId;
        private bool _isFilling;
        private bool _allowGridFill;
        private static readonly string[] SupportedAudioExtensions = { ".mp3", ".wav", ".m4a", ".aac", ".flac" };

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

        // Đăng ký các hàm xử lý sự kiện cho điều khiển trên biểu mẫu.
        private void WireEvents()
        {
            WireClick(btnMoi, BtnMoi_Click);
            WireClick(btnLuu, BtnLuu_Click);
            WireClick(btnXoa, BtnXoa_Click);
            WireClick(btnFile, BtnFile_Click);
            WireClick(btnAudio, BtnAudio_Click);
            WireClick(btnMoFile, BtnMoFile_Click);
            WireClick(btnMoAudio, BtnMoAudio_Click);
            WireClick(btnUploadCloud, BtnUploadCloud_Click);
            WireSelectionChanged(_grid, Grid_SelectionChanged);
            WireCellClick(_grid, Grid_CellClick);
            WireSelectedIndexChanged(_cboLop, CboLop_SelectedIndexChanged);
        }

        // Nạp dữ liệu và thiết lập trạng thái ban đầu khi biểu mẫu được mở.
        protected override void OnRuntimeLoad()
        {
            UiHelpers.BindLopHoc(_cboLop, Services);
            UiHelpers.BindKyNang(_cboKyNang);
            LoadData();
        }

        // tải dữ liệu.
        private void LoadData()
        {
            var maLop = UiHelpers.SelectedId(_cboLop);
            // Nạp danh sách vào bảng hiển thị.
            _grid.DataSource = SafeLoad<object>(() => Services.TaiLieu.LayDanhSach(maLop == 0 ? (int?)null : maLop), null);
            ResetGridSelection();
        }

        // Đưa dữ liệu từ dòng đang chọn trên lưới lên các ô nhập liệu.
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
                _txtAudio.Text = item.AudioPath;
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

        // Xóa dữ liệu nhập và đưa biểu mẫu về trạng thái thao tác mới.
        private void ClearForm()
        {
            _selectedId = 0;
            _txtChuDe.Clear();
            _txtMoTa.Clear();
            _txtFile.Clear();
            _txtVideo.Clear();
            if (_txtAudio != null) _txtAudio.Clear();
            if (_txtLoaiFile != null) _txtLoaiFile.Clear();
            if (_txtTenFileGoc != null) _txtTenFileGoc.Clear();
            if (_txtDuongDanLocal != null) _txtDuongDanLocal.Clear();
            if (_txtCloudUrl != null) _txtCloudUrl.Clear();
            ClearPreview();
        }

        // Xử lý sự kiện người dùng nhấn nút Mới.
        private void BtnMoi_Click(object sender, EventArgs e)
        {
            _selectedId = 0;
            SaveCurrentDocument();
        }

        // Xử lý sự kiện người dùng nhấn nút Lưu.
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            SaveCurrentDocument();
        }

        // Lưu tài liệu hiện tại.
        private void SaveCurrentDocument()
        {
            var localPath = !string.IsNullOrWhiteSpace(_txtDuongDanLocal.Text) ? _txtDuongDanLocal.Text.Trim() : _txtFile.Text.Trim();
            var audioPath = _txtAudio == null ? string.Empty : _txtAudio.Text.Trim();
            var topic = _txtChuDe.Text.Trim();
            if (string.IsNullOrWhiteSpace(topic) && !string.IsNullOrWhiteSpace(_txtTenFileGoc.Text))
            {
                topic = Path.GetFileNameWithoutExtension(_txtTenFileGoc.Text.Trim());
                _txtChuDe.Text = topic;
            }

            if (!ValidateAudioPath(audioPath))
            {
                return;
            }

            // Gọi tầng nghiệp vụ để lưu dữ liệu đang nhập.
            var result = Services.TaiLieu.Luu(new TaiLieuDTO
            {
                MaTaiLieu = _selectedId,
                MaLopHoc = UiHelpers.SelectedId(_cboLop),
                TenChuDe = topic,
                NoiDungMoTa = _txtMoTa.Text.Trim(),
                DuongDanFile = string.IsNullOrWhiteSpace(_txtFile.Text) ? localPath : _txtFile.Text.Trim(),
                VideoLink = _txtVideo.Text.Trim(),
                AudioPath = audioPath,
                NhanKyNang = Convert.ToString(_cboKyNang.SelectedItem),
                LoaiFile = _txtLoaiFile.Text.Trim(),
                TenFileGoc = _txtTenFileGoc.Text.Trim(),
                DuongDanLocal = localPath,
                DuongDanCloud = _txtCloudUrl.Text.Trim(),
                // Gọi tầng nghiệp vụ để xử lý tệp hình ảnh.
                ThumbnailPath = Services.Media.IsImage(localPath) ? localPath : string.Empty
            });

            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                LoadData();
                SelectSavedRow(localPath, topic);
            }
        }

        // Xử lý sự kiện người dùng nhấn nút Xóa.
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn bản ghi trên lưới trước khi cập nhật hoặc xóa.
            if (_selectedId == 0)
            {
                UiHelpers.WarnSelect("tai lieu");
                return;
            }

            // Xác nhận với người dùng trước khi xóa dữ liệu.
            if (!UiHelpers.ConfirmDelete("tai lieu"))
            {
                return;
            }

            // Gọi tầng nghiệp vụ để xóa bản ghi đang chọn.
            var result = Services.TaiLieu.Xoa(_selectedId);
            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                ClearForm();
                LoadData();
            }
        }

        // Xử lý sự kiện người dùng nhấn nút Chọn tệp.
        private void BtnFile_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog { Filter = "Tai lieu va media|*.pdf;*.doc;*.docx;*.ppt;*.pptx;*.xls;*.xlsx;*.txt;*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.mp3;*.wav;*.m4a;*.aac;*.flac;*.mp4;*.mov;*.avi;*.mkv|Tat ca|*.*" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Gọi tầng nghiệp vụ để xử lý tệp vào thư mục tải lên.
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

        // Xử lý sự kiện người dùng nhấn nút chọn âm thanh.
        private void BtnAudio_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog { Filter = "Audio|*.mp3;*.wav;*.m4a;*.aac;*.flac|Tat ca|*.*" })
            {
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                if (!IsSupportedAudioPath(dialog.FileName))
                {
                    UiHelpers.ShowResult(ServiceResult.Fail("Audio chi ho tro .mp3, .wav, .m4a, .aac, .flac."));
                    return;
                }

                // Gọi tầng nghiệp vụ để xử lý tệp vào thư mục tải lên.
                var result = Services.Media.CopyFileToUploadFolder(dialog.FileName, "TaiLieu");
                UiHelpers.ShowResult(result);
                if (result.Success)
                {
                    _txtAudio.Text = result.Data.LocalPath;
                }
            }
        }

        // Xử lý sự kiện người dùng nhấn nút Mở tệp.
        private void BtnMoFile_Click(object sender, EventArgs e)
        {
            var path = !string.IsNullOrWhiteSpace(_txtDuongDanLocal.Text) ? _txtDuongDanLocal.Text : _txtFile.Text;
            // Gọi tầng nghiệp vụ để hiển thị tệp.
            UiHelpers.ShowResult(Services.Media.OpenFile(path));
        }

        // Xử lý sự kiện người dùng nhấn nút Mở âm thanh.
        private void BtnMoAudio_Click(object sender, EventArgs e)
        {
            // Gọi tầng nghiệp vụ để hiển thị tệp.
            UiHelpers.ShowResult(Services.Media.OpenFile(_txtAudio.Text));
        }

        // Xử lý sự kiện người dùng nhấn nút tải lên đám mây.
        private void BtnUploadCloud_Click(object sender, EventArgs e)
        {
            var path = !string.IsNullOrWhiteSpace(_txtDuongDanLocal.Text) ? _txtDuongDanLocal.Text : _txtFile.Text;
            // Gọi tầng nghiệp vụ để xử lý tệp lên kho đám mây giả lập.
            var result = Services.Media.UploadToFakeCloud(path, "TaiLieu");
            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                _txtCloudUrl.Text = result.Data;
            }
        }

        // Chọn lại dòng vừa lưu trên bảng.
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

        // Kiểm tra âm thanh đường dẫn.
        private bool ValidateAudioPath(string audioPath)
        {
            if (string.IsNullOrWhiteSpace(audioPath))
            {
                return true;
            }

            if (!IsSupportedAudioPath(audioPath))
            {
                UiHelpers.ShowResult(ServiceResult.Fail("Audio chi ho tro .mp3, .wav, .m4a, .aac, .flac."));
                return false;
            }

            // Gọi tầng nghiệp vụ để xử lý đường dẫn tệp thực tế.
            var resolved = Services.Media.ResolvePath(audioPath);
            if (!File.Exists(resolved))
            {
                UiHelpers.ShowResult(ServiceResult.Fail("Khong tim thay file audio da chon."));
                return false;
            }

            return true;
        }

        // Xử lý định dạng âm thanh được hỗ trợ đường dẫn.
        private static bool IsSupportedAudioPath(string path)
        {
            var extension = Path.GetExtension(path);
            foreach (var allowed in SupportedAudioExtensions)
            {
                if (string.Equals(extension, allowed, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        // Cập nhật phần hiển thị xem trước dựa trên dữ liệu đang chọn.
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

            // Gọi tầng nghiệp vụ để xử lý đường dẫn tệp thực tế.
            var resolved = Services.Media.ResolvePath(localPath);
            if (!File.Exists(resolved))
            {
                SetPreviewMessage("Khong tim thay file", localPath);
                return;
            }

            // Gọi tầng nghiệp vụ để xử lý tệp hình ảnh.
            if (!Services.Media.IsImage(localPath))
            {
                var fileName = Path.GetFileName(resolved);
                // Gọi tầng nghiệp vụ để lấy loại tệp.
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

        // Xóa dữ liệu nhập và đưa biểu mẫu về trạng thái thao tác mới.
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

        // Cập nhật phần hiển thị xem trước dựa trên dữ liệu đang chọn.
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

        // Xử lý khi người dùng chọn dữ liệu trên bảng dữ liệu.
        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            if (!_allowGridFill)
            {
                return;
            }

            FillFromGrid();
        }

        // Xử lý khi người dùng chọn dữ liệu trên bảng dữ liệu.
        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            _allowGridFill = true;
            FillFromGrid();
        }

        // Xử lý khi người dùng thay đổi lựa chọn trên bộ lọc hoặc combobox.
        private void CboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFilling)
            {
                return;
            }

            ClearForm();
            LoadData();
        }

        // Xóa trạng thái chọn dòng trên bảng.
        private void ResetGridSelection()
        {
            _allowGridFill = false;
            _grid.ClearSelection();
            _grid.CurrentCell = null;
        }
    }
}
