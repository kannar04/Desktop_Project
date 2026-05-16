using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{

    public partial class FrmDiemSo : ModuleFormBase
    {
        private readonly ComboBox _cboLop = UiHelpers.ComboBox();
        private readonly ComboBox _cboDot = UiHelpers.ComboBox();
        private readonly DataGridView _gridHocVien = UiHelpers.Grid();
        private readonly DataGridView _gridDiem = UiHelpers.Grid();
        private readonly TextBox _txtTenDot = UiHelpers.TextBox();
        private readonly DateTimePicker _dtNgay = new DateTimePicker { Width = 150, Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy" };
        private readonly NumericUpDown _diemL = ScoreBox();
        private readonly NumericUpDown _diemR = ScoreBox();
        private readonly NumericUpDown _diemW = ScoreBox();
        private readonly NumericUpDown _diemS = ScoreBox();
        private readonly TextBox _txtNhanXet = UiHelpers.TextBox();

        public FrmDiemSo(ServiceFactory services, NguoiDungDTO currentUser) : base(services, currentUser, "Cập nhật điểm số IELTS")
        {
            InitializeComponent();
            var root = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 3 };
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 60));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 40));

            var top = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, Padding = new Padding(8) };
            var btnTaoDot = UiHelpers.Button("Tạo đợt");
            var btnTai = UiHelpers.Button("Tải điểm");
            btnTaoDot.Click += (s, e) => CreateExamRound();
            btnTai.Click += (s, e) => LoadScores();
            top.Controls.Add(UiHelpers.Label("Lớp"));
            top.Controls.Add(_cboLop);
            top.Controls.Add(UiHelpers.Label("Tên đợt"));
            top.Controls.Add(_txtTenDot);
            top.Controls.Add(UiHelpers.Label("Ngày"));
            top.Controls.Add(_dtNgay);
            top.Controls.Add(btnTaoDot);
            top.Controls.Add(UiHelpers.Label("Đợt kiểm tra"));
            top.Controls.Add(_cboDot);
            top.Controls.Add(btnTai);

            var middle = new SplitContainer { Dock = DockStyle.Fill, Orientation = Orientation.Vertical, SplitterDistance = 520 };
            middle.Panel1.Controls.Add(_gridHocVien);
            middle.Panel2.Controls.Add(_gridDiem);

            var bottom = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, Padding = new Padding(8) };
            var btnLuu = UiHelpers.Button("Lưu điểm");
            btnLuu.Click += (s, e) => SaveScore();
            _txtNhanXet.Width = 320;
            bottom.Controls.Add(UiHelpers.Label("L"));
            bottom.Controls.Add(_diemL);
            bottom.Controls.Add(UiHelpers.Label("R"));
            bottom.Controls.Add(_diemR);
            bottom.Controls.Add(UiHelpers.Label("W"));
            bottom.Controls.Add(_diemW);
            bottom.Controls.Add(UiHelpers.Label("S"));
            bottom.Controls.Add(_diemS);
            bottom.Controls.Add(UiHelpers.Label("Nhận xét"));
            bottom.Controls.Add(_txtNhanXet);
            bottom.Controls.Add(btnLuu);

            root.Controls.Add(top, 0, 0);
            root.Controls.Add(middle, 0, 1);
            root.Controls.Add(bottom, 0, 2);
            AddContent(root);
            UiHelpers.BindLopHoc(_cboLop, Services);
            _cboLop.SelectedIndexChanged += (s, e) => LoadRoundsAndStudents();
            LoadRoundsAndStudents();
        }

        private static NumericUpDown ScoreBox()
        {
            return new NumericUpDown { Width = 58, DecimalPlaces = 1, Increment = 0.5m, Minimum = 0, Maximum = 9 };
        }

        private void LoadRoundsAndStudents()
        {
            var maLop = UiHelpers.SelectedId(_cboLop);
            if (maLop <= 0) return;
            _gridHocVien.DataSource = Services.LopHoc.LayHocVienTrongLop(maLop);
            _cboDot.DataSource = Services.DiemSo.LayDotKiemTra(maLop);
            _cboDot.DisplayMember = "TenDotKiemTra";
            _cboDot.ValueMember = "MaDotKiemTra";
            LoadScores();
        }

        private void CreateExamRound()
        {
            var result = Services.DiemSo.TaoDotKiemTra(new DotKiemTraDTO
            {
                MaLopHoc = UiHelpers.SelectedId(_cboLop),
                TenDotKiemTra = _txtTenDot.Text.Trim(),
                NgayKiemTra = _dtNgay.Value.Date
            });
            UiHelpers.ShowResult(result);
            if (result.Success) LoadRoundsAndStudents();
        }

        private void LoadScores()
        {
            var maDot = UiHelpers.SelectedId(_cboDot);
            if (maDot > 0)
            {
                _gridDiem.DataSource = Services.DiemSo.LayDiemSo(maDot);
            }
        }

        private void SaveScore()
        {
            var hv = UiHelpers.SelectedItem<NguoiDungDTO>(_gridHocVien);
            if (hv == null) return;
            var result = Services.DiemSo.LuuDiem(new DiemSoDTO
            {
                MaNguoiDung = hv.MaNguoiDung,
                MaDotKiemTra = UiHelpers.SelectedId(_cboDot),
                DiemL = _diemL.Value,
                DiemR = _diemR.Value,
                DiemW = _diemW.Value,
                DiemS = _diemS.Value,
                NhanXet = _txtNhanXet.Text.Trim()
            });
            UiHelpers.ShowResult(result);
            if (result.Success) LoadScores();
        }
    }
}
