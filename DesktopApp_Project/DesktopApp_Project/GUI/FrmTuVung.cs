using System;
using System.Linq;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public partial class FrmTuVung : ModuleFormBase
    {
        private int _selectedId;
        private TextBox _txtTuKhoa;
        private ComboBox _cboLoaiFilter;
        private ComboBox _cboCapDoFilter;
        private ComboBox _cboChuDeFilter;
        private ComboBox _cboChuCaiFilter;
        private bool _isFilling;

        public FrmTuVung()
        {
            InitializeComponent();
        }

        public FrmTuVung(ServiceFactory services, NguoiDungDTO currentUser)
            : this()
        {
            SetRuntimeContext(services, currentUser);
        }

        protected override void OnRuntimeLoad()
        {
            UiHelpers.BindLopHoc(_cboLop, Services);
            ConfigureFilters();
            LoadData();
        }

        private void ConfigureFilters()
        {
            _txtTuKhoa = UiHelpers.TextBox();
            _txtTuKhoa.Width = 160;
            _cboLoaiFilter = UiHelpers.ComboBox();
            _cboLoaiFilter.Width = 120;
            _cboLoaiFilter.DataSource = new[] { AppConstants.FilterAll }.Concat(AppConstants.WordTypes).ToList();
            _cboCapDoFilter = UiHelpers.ComboBox();
            _cboCapDoFilter.Width = 90;
            _cboCapDoFilter.DataSource = new[] { AppConstants.FilterAll }.Concat(AppConstants.CefrLevels).ToList();
            _cboChuDeFilter = UiHelpers.ComboBox();
            _cboChuDeFilter.Width = 180;
            _cboChuDeFilter.DataSource = new[] { AppConstants.FilterAll }.Concat(AppConstants.VocabularyTopics).ToList();
            _cboChuCaiFilter = UiHelpers.ComboBox();
            _cboChuCaiFilter.Width = 80;
            _cboChuCaiFilter.DataSource = new[] { AppConstants.FilterAll }.Concat(Enumerable.Range('A', 26).Select(x => ((char)x).ToString())).ToList();

            var btnLoc = UiHelpers.Button("Lọc");
            btnLoc.Width = 70;
            btnLoc.Click += BtnLoc_Click;
            buttons.Controls.Add(UiHelpers.Label("Từ khóa"));
            buttons.Controls.Add(_txtTuKhoa);
            buttons.Controls.Add(UiHelpers.Label("Loại"));
            buttons.Controls.Add(_cboLoaiFilter);
            buttons.Controls.Add(UiHelpers.Label("CEFR"));
            buttons.Controls.Add(_cboCapDoFilter);
            buttons.Controls.Add(UiHelpers.Label("Chủ đề"));
            buttons.Controls.Add(_cboChuDeFilter);
            buttons.Controls.Add(UiHelpers.Label("A-Z"));
            buttons.Controls.Add(_cboChuCaiFilter);
            buttons.Controls.Add(btnLoc);
        }

        private void LoadData()
        {
            _grid.DataSource = Services.TuVung.TimKiem(new TuVungSearchCriteriaDTO
            {
                MaLopHoc = UiHelpers.SelectedId(_cboLop),
                Keyword = _txtTuKhoa == null ? null : _txtTuKhoa.Text,
                TuLoai = _cboLoaiFilter == null ? AppConstants.FilterAll : Convert.ToString(_cboLoaiFilter.SelectedItem),
                CapDo = _cboCapDoFilter == null ? AppConstants.FilterAll : Convert.ToString(_cboCapDoFilter.SelectedItem),
                ChuDe = _cboChuDeFilter == null ? AppConstants.FilterAll : Convert.ToString(_cboChuDeFilter.SelectedItem),
                ChuCaiDau = _cboChuCaiFilter == null ? AppConstants.FilterAll : Convert.ToString(_cboChuCaiFilter.SelectedItem)
            });
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
            ClearForm();
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            var result = Services.TuVung.Luu(new TuVungDTO
            {
                MaTuVung = _selectedId,
                MaLopHoc = UiHelpers.SelectedId(_cboLop),
                TuTiengAnh = _txtTu.Text.Trim(),
                TuLoai = _txtLoai.Text.Trim(),
                PhienAm = _txtPhienAm.Text.Trim(),
                Nghia = _txtNghia.Text.Trim(),
                CapDo = SelectedOrDefault(_cboCapDoFilter, "B1"),
                ChuDe = SelectedOrDefault(_cboChuDeFilter, "Academic/IELTS General")
            });

            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedId == 0) return;

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

            LoadData();
        }
    }
}
