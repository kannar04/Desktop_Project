using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;
using DesktopApp_Project.GUI.Shared.Themes;

namespace DesktopApp_Project.GUI
{
	public partial class FrmTuVung : ModuleFormBase
	{
		private int _selectedId;
		private BindingList<SearchConditionRow> _advancedConditions = new BindingList<SearchConditionRow>();
		private int _pendingOpenParentheses;
		private int _pendingCloseParentheses;
		private bool _isFilling;
		private bool _allowGridFill;

		public FrmTuVung()
		{
			InitializeComponent();
			WireEvents();
		}

		public FrmTuVung(ServiceFactory services, NguoiDungDTO currentUser)
			: this()
		{
			SetRuntimeContext(services, currentUser);
		}

		private void WireEvents()
		{
			WireClick(btnMoi, BtnMoi_Click);
			WireClick(btnLuu, BtnLuu_Click);
			WireClick(btnXoa, BtnXoa_Click);
			WireSelectionChanged(_grid, Grid_SelectionChanged);
			WireCellClick(_grid, Grid_CellClick);
			WireSelectedIndexChanged(_cboLop, CboLop_SelectedIndexChanged);
		}

		protected override void OnRuntimeLoad()
		{
			UiHelpers.BindLopHoc(_cboLop, Services);
			ConfigureFilters();
			ConfigureAdvancedSearch();
			LoadData();
		}

		private void ConfigureFilters()
		{
			_cboLoaiFilter.DataSource = new[] { AppConstants.FilterAll }.Concat(AppConstants.WordTypes).ToList();
			_cboCapDoFilter.DataSource = new[] { AppConstants.FilterAll }.Concat(AppConstants.CefrLevels).ToList();
			_cboChuDeFilter.DataSource = new[] { AppConstants.FilterAll }.Concat(AppConstants.VocabularyTopics).ToList();
			_cboChuCaiFilter.DataSource = new[] { AppConstants.FilterAll }.Concat(Enumerable.Range('A', 26).Select(x => ((char)x).ToString())).ToList();

			btnLoc.Click += (sender, e) => SafeRun(() => BtnLoc_Click(sender, e));
			_btnToggleAdvancedSearch.Click += (sender, e) => SafeRun(() => ToggleAdvancedSearch());
		}

		private void ConfigureAdvancedSearch()
		{
			_cboAdvancedJoin.DataSource = GetAdvancedJoinOptions();
			_btnAdvancedOpenParenthesis.Click += (sender, e) => SafeRun(() => IncrementPendingParenthesis(true));
			_cboAdvancedField.DataSource = GetAdvancedFieldOptions();
			_btnAdvancedCloseParenthesis.Click += (sender, e) => SafeRun(() => IncrementPendingParenthesis(false));
			_btnAddAdvancedCondition.Click += (sender, e) => SafeRun(() => AddAdvancedCondition());

			_gridAdvancedConditions.DataSource = _advancedConditions;
			ThemeManager.ApplyTheme(_gridAdvancedConditions);

			_btnRemoveAdvancedCondition.Click += (sender, e) => SafeRun(() => RemoveAdvancedCondition());
			_btnClearAdvancedConditions.Click += (sender, e) => SafeRun(() => ClearAdvancedConditions());
			_btnRunAdvancedSearch.Click += (sender, e) => SafeRun(() => RunAdvancedSearch());

			_cboAdvancedField.SelectedIndexChanged += (sender, e) => SafeRun(() => UpdateAdvancedValueInput());
			UpdateAdvancedValueInput();
			UpdateAdvancedJoinInput();
		}

		private void ToggleAdvancedSearch()
		{
			_advancedSearchPanel.Visible = !_advancedSearchPanel.Visible;
			_btnToggleAdvancedSearch.Text = _advancedSearchPanel.Visible ? "Ẩn tìm kiếm nâng cao" : "Tìm kiếm nâng cao";
		}

		private void LoadData()
		{
			_grid.DataSource = SafeLoad<object>(() => Services.TuVung.TimKiem(new TuVungSearchCriteriaDTO
			{
				MaLopHoc = UiHelpers.SelectedId(_cboLop),
				Keyword = _txtTuKhoa == null ? null : _txtTuKhoa.Text,
				TuLoai = _cboLoaiFilter == null ? AppConstants.FilterAll : Convert.ToString(_cboLoaiFilter.SelectedItem),
				CapDo = _cboCapDoFilter == null ? AppConstants.FilterAll : Convert.ToString(_cboCapDoFilter.SelectedItem),
				ChuDe = _cboChuDeFilter == null ? AppConstants.FilterAll : Convert.ToString(_cboChuDeFilter.SelectedItem),
				ChuCaiDau = _cboChuCaiFilter == null ? AppConstants.FilterAll : Convert.ToString(_cboChuCaiFilter.SelectedItem)
			}), null);
			ResetGridSelection();
		}

		private static List<SearchOption> GetAdvancedFieldOptions()
		{
			return new List<SearchOption>
			{
				new SearchOption("Keyword", "Từ khóa"),
				new SearchOption("ChuDe", "Chủ đề"),
				new SearchOption("ChuCaiDau", "Chữ cái đầu"),
				new SearchOption("CapDo", "Trình độ"),
				new SearchOption("TuLoai", "Loại từ")
			};
		}

		private static List<SearchOption> GetAdvancedJoinOptions()
		{
			return new List<SearchOption>
			{
				new SearchOption("And", "AND"),
				new SearchOption("Or", "OR")
			};
		}

		private void UpdateAdvancedJoinInput()
		{
			if (_cboAdvancedJoin == null)
			{
				return;
			}

			_cboAdvancedJoin.Enabled = _advancedConditions.Count > 0;
			if (!_cboAdvancedJoin.Enabled)
			{
				_cboAdvancedJoin.SelectedIndex = _cboAdvancedJoin.Items.Count > 0 ? 0 : -1;
			}
		}

		private void NormalizeAdvancedConditionJoins()
		{
			for (var i = 0; i < _advancedConditions.Count; i++)
			{
				var condition = _advancedConditions[i];
				if (i == 0)
				{
					condition.JoinOperator = null;
					condition.JoinLabel = string.Empty;
				}
				else
				{
					condition.JoinOperator = condition.JoinOperator ?? SearchJoinOperator.And;
					condition.JoinLabel = condition.JoinOperator == SearchJoinOperator.Or ? "OR" : "AND";
				}
			}

			_advancedConditions.ResetBindings();
			UpdateAdvancedJoinInput();
		}

		private void ClearAdvancedConditions()
		{
			_advancedConditions.Clear();
			UpdateAdvancedJoinInput();
			ResetPendingParentheses();
		}

		private bool AutoCloseAdvancedParentheses()
		{
			var balance = 0;
			foreach (var condition in _advancedConditions)
			{
				balance += Math.Max(0, condition.OpenParentheses);
				balance -= Math.Max(0, condition.CloseParentheses);
				if (balance < 0)
				{
					UiHelpers.ShowResult(ServiceResult.Fail("Biểu thức ngoặc không hợp lệ."));
					return false;
				}
			}

			if (balance > 0 && _advancedConditions.Count > 0)
			{
				_advancedConditions[_advancedConditions.Count - 1].CloseParentheses += balance;
				_advancedConditions.ResetBindings();
			}

			return true;
		}

		private void UpdateAdvancedValueInput()
		{
			var field = SelectedOptionValue(_cboAdvancedField);

			var values = GetAdvancedValues(field);
			var useCombo = values.Count > 0;
			_txtAdvancedValue.Visible = !useCombo;
			_cboAdvancedValue.Visible = useCombo;
			if (useCombo)
			{
				_cboAdvancedValue.DataSource = values;
			}
			else
			{
				_txtAdvancedValue.Clear();
				_cboAdvancedValue.DataSource = null;
			}
		}

		private static List<string> GetAdvancedValues(string field)
		{
			if (field == "ChuDe")
			{
				return AppConstants.VocabularyTopics.ToList();
			}

			if (field == "ChuCaiDau")
			{
				return Enumerable.Range('A', 26).Select(x => ((char)x).ToString()).ToList();
			}

			if (field == "CapDo")
			{
				return AppConstants.CefrLevels.ToList();
			}

			if (field == "TuLoai")
			{
				return AppConstants.WordTypes.ToList();
			}

			return new List<string>();
		}

		private void AddAdvancedCondition()
		{
			var field = SelectedOptionValue(_cboAdvancedField);
			var fieldLabel = SelectedOptionLabel(_cboAdvancedField);
			var value = _cboAdvancedValue.Visible
				? Convert.ToString(_cboAdvancedValue.SelectedItem)
				: _txtAdvancedValue.Text.Trim();

			if (string.IsNullOrWhiteSpace(field))
			{
				UiHelpers.ShowResult(ServiceResult.Fail("Vui lòng chọn trường cần tìm kiếm."));
				return;
			}

			if (string.IsNullOrWhiteSpace(value))
			{
				UiHelpers.ShowResult(ServiceResult.Fail("Vui lòng nhập hoặc chọn giá trị tìm kiếm."));
				return;
			}

			var joinOperator = _advancedConditions.Count == 0
				? (SearchJoinOperator?)null
				: SelectedJoinOperator(_cboAdvancedJoin);
			var openParentheses = _pendingOpenParentheses;
			var closeParentheses = _pendingCloseParentheses;

			_advancedConditions.Add(new SearchConditionRow
			{
				JoinOperator = joinOperator,
				JoinLabel = joinOperator == SearchJoinOperator.Or ? "OR" : joinOperator == SearchJoinOperator.And ? "AND" : string.Empty,
				Field = field,
				FieldLabel = fieldLabel,
				Value = value,
				OpenParentheses = openParentheses,
				CloseParentheses = closeParentheses
			});
			UpdateAdvancedJoinInput();
			ResetPendingParentheses();
		}

		private void RemoveAdvancedCondition()
		{
			var row = UiHelpers.SelectedItem<SearchConditionRow>(_gridAdvancedConditions);
			if (row == null)
			{
				UiHelpers.WarnSelect("điều kiện tìm kiếm");
				return;
			}

			_advancedConditions.Remove(row);
			NormalizeAdvancedConditionJoins();
		}

		private void RunAdvancedSearch()
		{
			if (!AutoCloseAdvancedParentheses())
			{
				return;
			}

			var result = Services.TuVung.TimKiemNangCao(
				UiHelpers.SelectedId(_cboLop),
				_advancedConditions.Select(x => x.ToDto()).ToList());

			UiHelpers.ShowResult(result);
			if (result.Success)
			{
				_grid.DataSource = result.Data;
				ResetGridSelection();
			}
		}

		private static string SelectedOptionValue(ComboBox combo)
		{
			var option = combo == null ? null : combo.SelectedItem as SearchOption;
			return option == null ? string.Empty : option.Value;
		}

		private static string SelectedOptionLabel(ComboBox combo)
		{
			var option = combo == null ? null : combo.SelectedItem as SearchOption;
			return option == null ? string.Empty : option.Label;
		}

		private static SearchJoinOperator SelectedJoinOperator(ComboBox combo)
		{
			return SelectedOptionValue(combo) == "Or" ? SearchJoinOperator.Or : SearchJoinOperator.And;
		}

		private void IncrementPendingParenthesis(bool open)
		{
			if (open)
			{
				_pendingOpenParentheses++;
			}
			else
			{
				_pendingCloseParentheses++;
			}

			RefreshPendingParenthesisButtons();
		}

		private void ResetPendingParentheses()
		{
			_pendingOpenParentheses = 0;
			_pendingCloseParentheses = 0;
			RefreshPendingParenthesisButtons();
		}

		private void RefreshPendingParenthesisButtons()
		{
			if (_btnAdvancedOpenParenthesis != null)
			{
				_btnAdvancedOpenParenthesis.Text = _pendingOpenParentheses > 1
					? new string('(', _pendingOpenParentheses)
					: "(";
			}

			if (_btnAdvancedCloseParenthesis != null)
			{
				_btnAdvancedCloseParenthesis.Text = _pendingCloseParentheses > 1
					? new string(')', _pendingCloseParentheses)
					: ")";
			}
		}

		private void Fill()
		{
			var item = UiHelpers.SelectedItem<TuVungDTO>(_grid);
			if (item == null) return;

			_isFilling = true;
			try
			{
				_selectedId = item.MaTuVung;
				if (!string.IsNullOrEmpty(_cboLop.ValueMember))
				{
					_cboLop.SelectedValue = item.MaLopHoc;
				}
				_txtTu.Text = item.TuTiengAnh;
				_txtLoai.Text = item.TuLoai;
				_txtPhienAm.Text = item.PhienAm;
				_txtNghia.Text = item.Nghia;
				if (_cboCapDoFilter != null && !string.IsNullOrWhiteSpace(item.CapDo)) _cboCapDoFilter.SelectedItem = item.CapDo;
				if (_cboChuDeFilter != null && !string.IsNullOrWhiteSpace(item.ChuDe)) _cboChuDeFilter.SelectedItem = item.ChuDe;
			}
			finally
			{
				_isFilling = false;
			}
		}

		private void ClearForm()
		{
			_selectedId = 0;
			_txtTu.Clear();
			_txtLoai.Clear();
			_txtPhienAm.Clear();
			_txtNghia.Clear();
		}

		private void BtnMoi_Click(object sender, EventArgs e)
		{
			var result = Services.TuVung.Luu(BuildDto(0));
			UiHelpers.ShowResult(result);
			if (result.Success)
			{
				LoadData();
				ClearForm();
				ResetGridSelection();
				_txtTu.Focus();
			}
		}

		private void BtnLuu_Click(object sender, EventArgs e)
		{
			if (_selectedId == 0)
			{
				UiHelpers.WarnSelect("tu vung");
				return;
			}

			var result = Services.TuVung.Luu(BuildDto(_selectedId));

			UiHelpers.ShowResult(result);
			if (result.Success)
			{
				ResetComboToAll(_cboChuDeFilter);
				LoadData();
			}
		}

		private TuVungDTO BuildDto(int maTuVung)
		{
			return new TuVungDTO
			{
				MaTuVung = maTuVung,
				MaLopHoc = UiHelpers.SelectedId(_cboLop),
				TuTiengAnh = _txtTu.Text.Trim(),
				TuLoai = _txtLoai.Text.Trim(),
				PhienAm = _txtPhienAm.Text.Trim(),
				Nghia = _txtNghia.Text.Trim(),
				CapDo = SelectedOrDefault(_cboCapDoFilter, "B1"),
				ChuDe = SelectedOrDefault(_cboChuDeFilter, "Academic/IELTS General")
			};
		}

		private void BtnXoa_Click(object sender, EventArgs e)
		{
			if (_selectedId == 0)
			{
				UiHelpers.WarnSelect("từ vựng");
				return;
			}

			if (!UiHelpers.ConfirmDelete("từ vựng"))
			{
				return;
			}

			var result = Services.TuVung.Xoa(_selectedId);
			UiHelpers.ShowResult(result);
			if (result.Success)
			{
				ClearForm();
				LoadData();
			}
		}

		private void Grid_SelectionChanged(object sender, EventArgs e)
		{
			if (!_allowGridFill)
			{
				return;
			}

			Fill();
		}

		private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
			{
				return;
			}

			_allowGridFill = true;
			Fill();
		}

		private void BtnLoc_Click(object sender, EventArgs e)
		{
			LoadData();
		}

		private string SelectedOrDefault(ComboBox combo, string defaultValue)
		{
			var value = combo == null ? null : Convert.ToString(combo.SelectedItem);
			return string.IsNullOrWhiteSpace(value) || value == AppConstants.FilterAll ? defaultValue : value;
		}

		private void CboLop_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_isFilling)
			{
				return;
			}

			ClearForm();
			ResetSearchFilters();
			LoadData();
		}

		private void ResetSearchFilters()
		{
			if (_txtTuKhoa != null)
			{
				_txtTuKhoa.Clear();
			}

			ResetComboToAll(_cboLoaiFilter);
			ResetComboToAll(_cboCapDoFilter);
			ResetComboToAll(_cboChuDeFilter);
			ResetComboToAll(_cboChuCaiFilter);
			if (_advancedConditions != null)
			{
				ClearAdvancedConditions();
			}
		}

		private static void ResetComboToAll(ComboBox combo)
		{
			if (combo != null && combo.Items.Count > 0)
			{
				combo.SelectedIndex = 0;
			}
		}

		private void ResetGridSelection()
		{
			_selectedId = 0;
			_allowGridFill = false;
			_grid.ClearSelection();
			_grid.CurrentCell = null;
		}

		private class SearchOption
		{
			public SearchOption(string value, string label)
			{
				Value = value;
				Label = label;
			}

			public string Value { get; private set; }
			public string Label { get; private set; }
		}

		private class SearchConditionRow
		{
			public SearchJoinOperator? JoinOperator { get; set; }
			public string JoinLabel { get; set; }
			public string Field { get; set; }
			public string FieldLabel { get; set; }
			public string Value { get; set; }
			public int OpenParentheses { get; set; }
			public int CloseParentheses { get; set; }

			public string ConditionLabel
			{
				get
				{
					return new string('(', Math.Max(0, OpenParentheses))
						+ string.Format("{0}: {1}", FieldLabel, Value)
						+ new string(')', Math.Max(0, CloseParentheses));
				}
			}

			public SearchConditionDTO ToDto()
			{
				return new SearchConditionDTO
				{
					Field = Field,
					Value = Value,
					JoinOperator = JoinOperator,
					OpenParentheses = OpenParentheses,
					CloseParentheses = CloseParentheses
				};
			}
		}
	}
}