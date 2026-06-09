// Biểu mẫu quản lý flashcard từ vựng
// Chức năng:
// - Hiển thị và nhập dữ liệu flashcard từ vựng
// - Gọi tầng nghiệp vụ để tải, lưu hoặc xóa dữ liệu
// - Cập nhật trạng thái giao diện sau thao tác của người dùng

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
	// Lớp biểu mẫu Windows Forms chịu trách nhiệm hiển thị flashcard từ vựng và gọi tầng nghiệp vụ khi người dùng thao tác.
	public partial class FrmFlashcard : ModuleFormBase
	{
		private readonly Random _random = new Random();
		private List<TuVungDTO> _cards = new List<TuVungDTO>();
		private int _currentIndex;
		private bool _showBack;
		private bool _isLoading;

		public FrmFlashcard()
		{
			InitializeComponent();
			WireEvents();
		}

		public FrmFlashcard(ServiceFactory services, NguoiDungDTO currentUser)
			: this()
		{
			SetRuntimeContext(services, currentUser);
		}

		// Đăng ký các hàm xử lý sự kiện cho điều khiển trên biểu mẫu.
		private void WireEvents()
		{
			WireClick(btnLatThe, BtnLatThe_Click);
			WireClick(btnTiepTheo, BtnTiepTheo_Click);
			WireClick(btnTruoc, BtnTruoc_Click);
			WireClick(btnXaoTron, BtnXaoTron_Click);
			WireSelectedIndexChanged(_cboLop, Filter_Changed);
			WireSelectedIndexChanged(_cboCapDo, Filter_Changed);
			WireSelectedIndexChanged(_cboChuDe, Filter_Changed);
		}

		// Nạp dữ liệu và thiết lập trạng thái ban đầu khi biểu mẫu được mở.
		protected override void OnRuntimeLoad()
		{
			_isLoading = true;
			try
			{
				UiHelpers.BindLopHoc(_cboLop, Services);
				// Xóa dữ liệu đang hiển thị trên ô chọn cấp độ khi chưa đủ điều kiện tải.
				_cboCapDo.DataSource = new[] { AppConstants.FilterAll }.Concat(AppConstants.CefrLevels).ToList();
				// Xóa dữ liệu đang hiển thị trên ô chọn chủ đề khi chưa đủ điều kiện tải.
				_cboChuDe.DataSource = new[] { AppConstants.FilterAll }.Concat(AppConstants.VocabularyTopics).ToList();
			}
			finally
			{
				_isLoading = false;
			}

			ApplyFlashcardVisualStyle();
			LoadCards();
		}

		// Lấy thẻ flashcard.
		private void LoadCards()
		{
			if (!CanUseServices || _isLoading)
			{
				return;
			}

			// Gọi tầng nghiệp vụ để lấy danh sách flashcard.
			var result = Services.TuVung.LayDanhSachFlashcard(new TuVungSearchCriteriaDTO
			{
				MaLopHoc = UiHelpers.SelectedId(_cboLop),
				CapDo = SelectedFilter(_cboCapDo),
				ChuDe = SelectedFilter(_cboChuDe),
				TuLoai = AppConstants.FilterAll,
				ChuCaiDau = AppConstants.FilterAll
			});

			if (!result.Success)
			{
				UiHelpers.ShowResult(result);
				_cards = new List<TuVungDTO>();
			}
			else
			{
				_cards = result.Data ?? new List<TuVungDTO>();
			}

			_currentIndex = 0;
			_showBack = false;
			DisplayCard();
		}

		// Cập nhật phần hiển thị xem trước dựa trên dữ liệu đang chọn.
		private void DisplayCard()
		{
			var hasCards = _cards.Count > 0;
			btnLatThe.Enabled = hasCards;
			btnXaoTron.Enabled = hasCards;
			btnTruoc.Enabled = hasCards && _currentIndex > 0;
			btnTiepTheo.Enabled = hasCards && _currentIndex < _cards.Count - 1;
			lblCounter.Text = hasCards
				? "Thẻ " + (_currentIndex + 1).ToString("N0") + " / " + _cards.Count.ToString("N0")
				: "Thẻ 0 / 0";

			if (!hasCards)
			{
				lblSide.Text = "Flashcard";
				lblCardTitle.Text = "Chưa có từ vựng";
				lblCardValue.Text = "Thêm từ vựng hoặc chọn bộ lọc khác.";
				lblCardMeta.Text = string.Empty;
				return;
			}

			var card = _cards[_currentIndex];
			if (_showBack)
			{
				lblSide.Text = "Mặt sau";
				lblCardTitle.Text = "Nghĩa: " + SafeText(card.Nghia);
				lblCardValue.Text = "Từ vựng: " + SafeText(card.TuTiengAnh) + Environment.NewLine +
									"Phiên âm: " + SafeText(card.PhienAm);
			}
			else
			{
				lblSide.Text = "Mặt trước";
				lblCardTitle.Text = SafeText(card.TuTiengAnh);
				lblCardValue.Text = "Phiên âm: " + SafeText(card.PhienAm);
			}

			lblCardMeta.Text = SafeText(card.TuLoai) + "  |  " + SafeText(card.CapDo) + "  |  " + SafeText(card.ChuDe);
		}

		// Xử lý sự kiện người dùng nhấn nút Lật thẻ.
		private void BtnLatThe_Click(object sender, EventArgs e)
		{
			if (_cards.Count == 0)
			{
				return;
			}

			_showBack = !_showBack;
			if (_showBack && CurrentUser != null)
			{
				// Gọi tầng nghiệp vụ để ghi nhận flashcard đã học.
				var result = Services.TuVung.GhiNhanFlashcardDaHoc(CurrentUser.MaNguoiDung, _cards[_currentIndex].MaTuVung);
				if (!result.Success)
				{
					UiHelpers.ShowResult(result);
				}
			}

			DisplayCard();
		}

		// Xử lý sự kiện người dùng nhấn nút Tiếp theo.
		private void BtnTiepTheo_Click(object sender, EventArgs e)
		{
			if (_currentIndex < _cards.Count - 1)
			{
				_currentIndex++;
				_showBack = false;
				DisplayCard();
			}
		}

		// Xử lý sự kiện người dùng nhấn nút Trước.
		private void BtnTruoc_Click(object sender, EventArgs e)
		{
			if (_currentIndex > 0)
			{
				_currentIndex--;
				_showBack = false;
				DisplayCard();
			}
		}

		// Xử lý sự kiện người dùng nhấn nút Xáo trộn.
		private void BtnXaoTron_Click(object sender, EventArgs e)
		{
			if (_cards.Count <= 1)
			{
				return;
			}

			// Lọc hoặc sắp xếp dữ liệu hiển thị bằng LINQ.
			_cards = _cards.OrderBy(x => _random.Next()).ToList();
			_currentIndex = 0;
			_showBack = false;
			DisplayCard();
		}

		// Xử lý khi người dùng thay đổi lựa chọn trên bộ lọc hoặc combobox.
		private void Filter_Changed(object sender, EventArgs e)
		{
			LoadCards();
		}

		// Cập nhật màu sắc và bố cục của thẻ flashcard hiện tại.
		private void ApplyFlashcardVisualStyle()
		{
			cardPanel.BackColor = UiHelpers.SurfaceAltColor;
			lblTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
			lblSide.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
			lblSide.ForeColor = UiHelpers.AccentColor;
			lblCardTitle.Font = new Font("Segoe UI", 34F, FontStyle.Bold);
			lblCardValue.Font = new Font("Segoe UI", 17F, FontStyle.Regular);
			lblCardMeta.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
			foreach (Control control in buttons.Controls)
			{
				var button = control as Button;
				if (button != null)
				{
					button.Height = 38;
					button.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
				}
			}

			UiHelpers.EnableDoubleBuffering(cardPanel);
		}

		// Lấy loại từ vựng đang được chọn trong bộ lọc.
		private static string SelectedFilter(ComboBox combo)
		{
			var value = combo == null ? null : Convert.ToString(combo.SelectedItem);
			return string.IsNullOrWhiteSpace(value) ? AppConstants.FilterAll : value;
		}

		// Xử lý tiện ích giao diện và thao tác tệp an toàn cho người dùng.
		private static string SafeText(string value)
		{
			return string.IsNullOrWhiteSpace(value) ? "-" : value.Trim();
		}
	}
}
