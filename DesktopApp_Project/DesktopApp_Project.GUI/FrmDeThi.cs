// Biểu mẫu quản lý đề thi IELTS
// Chức năng:
// - Hiển thị và nhập dữ liệu đề thi IELTS
// - Gọi tầng nghiệp vụ để tải, lưu hoặc xóa dữ liệu
// - Cập nhật trạng thái giao diện sau thao tác của người dùng

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
	// Lớp biểu mẫu Windows Forms chịu trách nhiệm hiển thị đề thi IELTS và gọi tầng nghiệp vụ khi người dùng thao tác.
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

		// Đăng ký các hàm xử lý sự kiện cho điều khiển trên biểu mẫu.
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

		// Nạp dữ liệu và thiết lập trạng thái ban đầu khi biểu mẫu được mở.
		protected override void OnRuntimeLoad()
		{
			UiHelpers.BindKyNang(cboKyNang);
			// Xóa dữ liệu đang hiển thị trên ô chọn trạng thái khi chưa đủ điều kiện tải.
			cboTrangThai.DataSource = new[] { "DangTao", "DaDuyet", "NgungDung" };
			numBandLevel.Value = 5;
			LoadData();
		}

		// tải dữ liệu.
		private void LoadData()
		{
			if (!CanUseServices)
			{
				return;
			}

			// Nạp danh sách đề thi vào bảng.
			grid.DataSource = SafeLoad<object>(() => Services.DeThi.LayDeThi(), null);
			ResetGridSelection();
		}

		// Đưa dữ liệu từ dòng đang chọn trên lưới lên các ô nhập liệu.
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

		// Xóa dữ liệu nhập và đưa biểu mẫu về trạng thái thao tác mới.
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

		// Xử lý sự kiện người dùng nhấn nút Mới.
		private void BtnMoi_Click(object sender, EventArgs e)
		{
			_selectedId = 0;
			SaveExam();
		}

		// Xử lý sự kiện người dùng nhấn nút Lưu.
		private void BtnLuu_Click(object sender, EventArgs e)
		{
			SaveExam();
		}

		// Lưu exam.
		private void SaveExam()
		{
			// Gọi tầng nghiệp vụ để lưu dữ liệu đang nhập.
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

		// Xử lý sự kiện người dùng nhấn nút Xóa.
		private void BtnXoa_Click(object sender, EventArgs e)
		{
			// Kiểm tra đã chọn bản ghi trên lưới trước khi cập nhật hoặc xóa.
			if (_selectedId == 0)
			{
				UiHelpers.WarnSelect("de thi");
				return;
			}

			// Xác nhận với người dùng trước khi xóa dữ liệu.
			if (!UiHelpers.ConfirmDelete("de thi"))
			{
				return;
			}

			// Gọi tầng nghiệp vụ để xóa bản ghi đang chọn.
			var result = Services.DeThi.Xoa(_selectedId);
			UiHelpers.ShowResult(result);
			if (result.Success)
			{
				ClearForm();
				LoadData();
			}
		}

		// Xử lý sự kiện người dùng nhấn nút Chọn tệp.
		private void BtnChonFile_Click(object sender, EventArgs e)
		{
			ChooseManagedFile("File de thi|*.pdf;*.doc;*.docx;*.xlsx|Tat ca|*.*", txtFile, false);
		}

		// Xử lý sự kiện người dùng nhấn nút Chọn âm thanh.
		private void BtnChonAudio_Click(object sender, EventArgs e)
		{
			ChooseManagedFile("Audio|*.mp3;*.wav|Tat ca|*.*", txtAudio, false);
		}

		// Xử lý sự kiện người dùng nhấn nút Chọn ảnh.
		private void BtnChonAnh_Click(object sender, EventArgs e)
		{
			ChooseManagedFile("Anh|*.jpg;*.jpeg;*.png|Tat ca|*.*", txtImage, true);
		}

		// Xử lý choose managed tệp.
		private void ChooseManagedFile(string filter, TextBox target, bool previewImage)
		{
			using (var dialog = new OpenFileDialog { Filter = filter })
			{
				if (dialog.ShowDialog(this) != DialogResult.OK)
				{
					return;
				}

				// Gọi tầng nghiệp vụ để xử lý tệp vào thư mục tải lên.
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

		// Xử lý sự kiện người dùng nhấn nút Mở tệp.
		private void BtnMoFile_Click(object sender, EventArgs e)
		{
			// Gọi tầng nghiệp vụ để hiển thị tệp.
			var result = Services.Media.OpenFile(txtFile.Text);
			if (!result.Success)
			{
				UiHelpers.ShowResult(result);
			}
		}

		// Xử lý sự kiện người dùng nhấn nút Mở âm thanh.
		private void BtnMoAudio_Click(object sender, EventArgs e)
		{
			// Gọi tầng nghiệp vụ để hiển thị tệp.
			var result = Services.Media.OpenFile(txtAudio.Text);
			if (!result.Success)
			{
				UiHelpers.ShowResult(result);
			}
		}

		// Cập nhật phần hiển thị xem trước dựa trên dữ liệu đang chọn.
		private void UpdateImagePreview(string path)
		{
			ClearPreview();
			if (string.IsNullOrWhiteSpace(path))
			{
				return;
			}

			// Gọi tầng nghiệp vụ để xử lý đường dẫn tệp thực tế.
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

		// Xóa dữ liệu nhập và đưa biểu mẫu về trạng thái thao tác mới.
		private void ClearPreview()
		{
			var old = picPreview.Image;
			picPreview.Image = null;
			if (old != null)
			{
				old.Dispose();
			}
		}

		// Chọn lại dòng vừa lưu trên bảng.
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

		// Xử lý clamp band.
		private static decimal ClampBand(decimal value)
		{
			if (value < 0) return 0;
			if (value > 9) return 9;
			return value;
		}

		// Xử lý khi người dùng chọn dữ liệu trên bảng dữ liệu.
		private void Grid_SelectionChanged(object sender, EventArgs e)
		{
			if (_isFilling || !_allowGridFill)
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

		// Xóa trạng thái chọn dòng trên bảng.
		private void ResetGridSelection()
		{
			_allowGridFill = false;
			grid.ClearSelection();
			grid.CurrentCell = null;
		}
	}
}
