using System;
using System.Linq;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public partial class FrmDeThi : ModuleFormBase
    {
        private int _selectedQuestionId;
        private ComboBox _cboLocKyNang;
        private NumericUpDown _numBandTu;
        private NumericUpDown _numBandDen;
        private TextBox _txtTuKhoa;

        public FrmDeThi()
        {
            InitializeComponent();
        }

        public FrmDeThi(ServiceFactory services, NguoiDungDTO currentUser)
            : this()
        {
            SetRuntimeContext(services, currentUser);
        }

        protected override void OnRuntimeLoad()
        {
            UiHelpers.BindKyNang(_cboKyNang);
            ConfigureFilters();
            LoadData();
        }

        private void ConfigureFilters()
        {
            _cboLocKyNang = UiHelpers.ComboBox();
            _cboLocKyNang.Width = 140;
            _cboLocKyNang.DataSource = new[] { AppConstants.FilterAll }.Concat(AppConstants.SkillLabels).ToList();

            _numBandTu = new NumericUpDown { Width = 70, DecimalPlaces = 1, Minimum = 0, Maximum = 9, Increment = 0.5M };
            _numBandDen = new NumericUpDown { Width = 70, DecimalPlaces = 1, Minimum = 0, Maximum = 9, Increment = 0.5M, Value = 9 };
            _txtTuKhoa = UiHelpers.TextBox();
            _txtTuKhoa.Width = 180;
            var btnLoc = UiHelpers.Button("Lọc");
            btnLoc.Width = 70;
            btnLoc.Click += BtnLoc_Click;

            buttons.Controls.Add(UiHelpers.Label("Kỹ năng"));
            buttons.Controls.Add(_cboLocKyNang);
            buttons.Controls.Add(UiHelpers.Label("Band"));
            buttons.Controls.Add(_numBandTu);
            buttons.Controls.Add(_numBandDen);
            buttons.Controls.Add(UiHelpers.Label("Từ khóa"));
            buttons.Controls.Add(_txtTuKhoa);
            buttons.Controls.Add(btnLoc);
        }

        private void LoadData()
        {
            var result = Services.DeThi.LayCauHoi(new CauHoiSearchCriteriaDTO
            {
                NhanKyNang = _cboLocKyNang == null ? AppConstants.FilterAll : Convert.ToString(_cboLocKyNang.SelectedItem),
                BandTu = _numBandTu == null ? (decimal?)null : _numBandTu.Value,
                BandDen = _numBandDen == null ? (decimal?)null : _numBandDen.Value,
                Keyword = _txtTuKhoa == null ? null : _txtTuKhoa.Text
            });
            _gridCauHoi.DataSource = result.Success ? result.Data : Services.DeThi.LayCauHoi((string)null);
            _gridDeThi.DataSource = Services.DeThi.LayDeThi();
        }

        private void FillQuestion()
        {
            var item = UiHelpers.SelectedItem<CauHoiDTO>(_gridCauHoi);
            if (item == null) return;

            _selectedQuestionId = item.MaCauHoi;
            _txtNoiDung.Text = item.NoiDung;
            _txtDapAn.Text = item.DapAn;
            _cboKyNang.SelectedItem = item.NhanKyNang;
        }

        private void BtnLoc_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ClearQuestion()
        {
            _selectedQuestionId = 0;
            _txtNoiDung.Clear();
            _txtDapAn.Clear();
        }

        private void BtnMoi_Click(object sender, EventArgs e)
        {
            ClearQuestion();
        }

        private void BtnLuuCau_Click(object sender, EventArgs e)
        {
            var result = Services.DeThi.LuuCauHoi(new CauHoiDTO
            {
                MaCauHoi = _selectedQuestionId,
                NoiDung = _txtNoiDung.Text.Trim(),
                DapAn = _txtDapAn.Text.Trim(),
                NhanKyNang = Convert.ToString(_cboKyNang.SelectedItem)
            });

            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }

        private void BtnXoaCau_Click(object sender, EventArgs e)
        {
            if (_selectedQuestionId == 0) return;

            var result = Services.DeThi.XoaCauHoi(_selectedQuestionId);
            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }

        private void BtnTaoDe_Click(object sender, EventArgs e)
        {
            var result = Services.DeThi.TaoDeThi(new DeThiDTO { TenDeThi = _txtTenDe.Text.Trim() });
            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }

        private void BtnThemVaoDe_Click(object sender, EventArgs e)
        {
            var exam = UiHelpers.SelectedItem<DeThiDTO>(_gridDeThi);
            var question = UiHelpers.SelectedItem<CauHoiDTO>(_gridCauHoi);
            if (exam == null || question == null) return;

            var result = Services.DeThi.ThemCauHoiVaoDeThi(exam.MaDeThi, question.MaCauHoi);
            UiHelpers.ShowResult(result);
        }

        private void GridCauHoi_SelectionChanged(object sender, EventArgs e)
        {
            FillQuestion();
        }
    }
}
