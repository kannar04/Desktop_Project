using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{

    public partial class FrmChamBai : ModuleFormBase
    {
        private readonly ComboBox _cboBaiTap = UiHelpers.ComboBox();
        private readonly DataGridView _grid = UiHelpers.Grid();
        private readonly NumericUpDown _numDiem = new NumericUpDown { Width = 100, DecimalPlaces = 1, Increment = 0.5m, Minimum = 0, Maximum = 9 };
        private readonly TextBox _txtNhanXet = UiHelpers.TextBox();
        private readonly TextBox _txtPreview = new TextBox { Dock = DockStyle.Fill, Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Both };

        public FrmChamBai(ServiceFactory services, NguoiDungDTO currentUser) : base(services, currentUser, "Quản lý nộp bài và chấm bài")
        {
            InitializeComponent();
            var root = new SplitContainer { Dock = DockStyle.Fill, Orientation = Orientation.Vertical, SplitterDistance = 720 };
            var left = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 3 };
            left.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            left.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            left.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            var top = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, Padding = new Padding(8) };
            var btnTai = UiHelpers.Button("Tải danh sách");
            btnTai.Width = 130;
            btnTai.Click += (s, e) => LoadSubmissions();
            top.Controls.Add(UiHelpers.Label("Bài tập"));
            top.Controls.Add(_cboBaiTap);
            top.Controls.Add(btnTai);
            var bottom = new FlowLayoutPanel { Dock = DockStyle.Bottom, AutoSize = true, Padding = new Padding(8) };
            var btnCham = UiHelpers.Button("Chấm bài");
            btnCham.Click += (s, e) => Grade();
            _txtNhanXet.Width = 360;
            bottom.Controls.Add(UiHelpers.Label("Điểm"));
            bottom.Controls.Add(_numDiem);
            bottom.Controls.Add(UiHelpers.Label("Nhận xét"));
            bottom.Controls.Add(_txtNhanXet);
            bottom.Controls.Add(btnCham);
            _grid.SelectionChanged += (s, e) => PreviewSubmission();
            left.Controls.Add(top, 0, 0);
            left.Controls.Add(_grid, 0, 1);
            left.Controls.Add(bottom, 0, 2);
            root.Panel1.Controls.Add(left);
            root.Panel2.Controls.Add(_txtPreview);
            AddContent(root);
            LoadAssignments();
        }

        private void LoadAssignments()
        {
            var list = Services.BaiTap.LayDanhSach(null);
            _cboBaiTap.DataSource = list;
            _cboBaiTap.DisplayMember = "TieuDe";
            _cboBaiTap.ValueMember = "MaBaiTap";
            LoadSubmissions();
        }

        private void LoadSubmissions()
        {
            var maBaiTap = UiHelpers.SelectedId(_cboBaiTap);
            if (maBaiTap > 0)
            {
                _grid.DataSource = Services.ChamBai.LayDanhSach(maBaiTap);
            }
        }

        private void PreviewSubmission()
        {
            var item = UiHelpers.SelectedItem<NopBaiDTO>(_grid);
            if (item == null) return;
            _txtNhanXet.Text = item.NhanXet;
            _numDiem.Value = item.DiemSo.HasValue ? item.DiemSo.Value : 0;
            if (!string.IsNullOrWhiteSpace(item.FileBaiLam) && File.Exists(item.FileBaiLam))
            {
                _txtPreview.Text = "Tệp bài làm: " + item.FileBaiLam + Environment.NewLine + "Có thể mở tệp bằng ứng dụng phù hợp trên máy để xem nội dung chi tiết.";
            }
            else
            {
                _txtPreview.Text = "Học viên chưa có file bài làm trong hệ thống.";
            }
        }

        private void Grade()
        {
            var item = UiHelpers.SelectedItem<NopBaiDTO>(_grid);
            if (item == null) return;
            item.DiemSo = _numDiem.Value;
            item.NhanXet = _txtNhanXet.Text.Trim();
            var result = Services.ChamBai.Cham(item);
            UiHelpers.ShowResult(result);
            if (result.Success) LoadSubmissions();
        }
    }
}
