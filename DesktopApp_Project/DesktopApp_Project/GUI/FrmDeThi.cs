using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{

    public partial class FrmDeThi : ModuleFormBase
    {
        private readonly DataGridView _gridCauHoi = UiHelpers.Grid();
        private readonly DataGridView _gridDeThi = UiHelpers.Grid();
        private readonly ComboBox _cboKyNang = UiHelpers.ComboBox();
        private readonly TextBox _txtNoiDung = new TextBox { Width = 430, Multiline = true, Height = 65, ScrollBars = ScrollBars.Vertical };
        private readonly TextBox _txtDapAn = new TextBox { Width = 430, Multiline = true, Height = 55, ScrollBars = ScrollBars.Vertical };
        private readonly TextBox _txtTenDe = UiHelpers.TextBox();
        private int _selectedQuestionId;

        public FrmDeThi(ServiceFactory services, NguoiDungDTO currentUser) : base(services, currentUser, "Tạo đề thi IELTS")
        {
            InitializeComponent();
            var root = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 3 };
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 55));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 45));
            var form = UiHelpers.FormGrid();
            UiHelpers.BindKyNang(_cboKyNang);
            form.Controls.Add(UiHelpers.Label("Kỹ năng"), 0, 0);
            form.Controls.Add(_cboKyNang, 1, 0);
            form.Controls.Add(UiHelpers.Label("Tên đề thi"), 2, 0);
            form.Controls.Add(_txtTenDe, 3, 0);
            form.Controls.Add(UiHelpers.Label("Nội dung câu hỏi"), 0, 1);
            form.Controls.Add(_txtNoiDung, 1, 1);
            form.Controls.Add(UiHelpers.Label("Đáp án"), 2, 1);
            form.Controls.Add(_txtDapAn, 3, 1);
            var buttons = new FlowLayoutPanel { AutoSize = true };
            var btnMoi = UiHelpers.Button("Thêm mới");
            var btnLuuCau = UiHelpers.Button("Lưu câu hỏi");
            var btnXoaCau = UiHelpers.Button("Xóa câu hỏi");
            var btnTaoDe = UiHelpers.Button("Tạo đề");
            var btnThemVaoDe = UiHelpers.Button("Gắn vào đề");
            btnThemVaoDe.Width = 120;
            btnMoi.Click += (s, e) => ClearQuestion();
            btnLuuCau.Click += (s, e) => SaveQuestion();
            btnXoaCau.Click += (s, e) => DeleteQuestion();
            btnTaoDe.Click += (s, e) => CreateExam();
            btnThemVaoDe.Click += (s, e) => AttachQuestion();
            buttons.Controls.Add(btnMoi);
            buttons.Controls.Add(btnLuuCau);
            buttons.Controls.Add(btnXoaCau);
            buttons.Controls.Add(btnTaoDe);
            buttons.Controls.Add(btnThemVaoDe);
            form.Controls.Add(buttons, 3, 2);
            _gridCauHoi.SelectionChanged += (s, e) => FillQuestion();
            root.Controls.Add(form, 0, 0);
            root.Controls.Add(_gridCauHoi, 0, 1);
            root.Controls.Add(_gridDeThi, 0, 2);
            AddContent(root);
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

        private void SaveQuestion()
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

        private void DeleteQuestion()
        {
            if (_selectedQuestionId == 0) return;
            var result = Services.DeThi.XoaCauHoi(_selectedQuestionId);
            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }

        private void CreateExam()
        {
            var result = Services.DeThi.TaoDeThi(new DeThiDTO { TenDeThi = _txtTenDe.Text.Trim() });
            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }

        private void AttachQuestion()
        {
            var exam = UiHelpers.SelectedItem<DeThiDTO>(_gridDeThi);
            var question = UiHelpers.SelectedItem<CauHoiDTO>(_gridCauHoi);
            if (exam == null || question == null) return;
            var result = Services.DeThi.ThemCauHoiVaoDeThi(exam.MaDeThi, question.MaCauHoi);
            UiHelpers.ShowResult(result);
        }
    }
}
