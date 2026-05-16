using System;
using DesktopApp_Project.BUS;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public partial class FrmDeThi : ModuleFormBase
    {
        private int _selectedQuestionId;

        public FrmDeThi()
            : base("Tạo đề thi IELTS")
        {
            InitializeComponent();
        }
        public FrmDeThi(ServiceFactory services, NguoiDungDTO currentUser)
            : base(services, currentUser, "Tạo đề thi IELTS")
        {
            InitializeComponent();
            UiHelpers.BindKyNang(_cboKyNang);
            LoadData();
        }

        private void LoadData()
        {
            _gridCauHoi.DataSource = Services.DeThi.LayCauHoi(null);
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
