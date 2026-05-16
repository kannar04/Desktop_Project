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

    public partial class FrmBaiTap : ModuleFormBase
    {
        private readonly DataGridView _grid = UiHelpers.Grid();
        private readonly ComboBox _cboLop = UiHelpers.ComboBox();
        private readonly TextBox _txtTieuDe = UiHelpers.TextBox();
        private readonly TextBox _txtMoTa = UiHelpers.TextBox();
        private readonly TextBox _txtFile = UiHelpers.TextBox();
        private readonly DateTimePicker _dtDeadline = new DateTimePicker { Width = 220, Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy HH:mm" };
        private int _selectedId;

        public FrmBaiTap(ServiceFactory services, NguoiDungDTO currentUser) : base(services, currentUser, "Cập nhật và giao bài tập")
        {
            InitializeComponent();
            var root = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2 };
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            var form = UiHelpers.FormGrid();
            form.Controls.Add(UiHelpers.Label("Lớp"), 0, 0);
            form.Controls.Add(_cboLop, 1, 0);
            form.Controls.Add(UiHelpers.Label("Deadline"), 2, 0);
            form.Controls.Add(_dtDeadline, 3, 0);
            form.Controls.Add(UiHelpers.Label("Tiêu đề"), 0, 1);
            form.Controls.Add(_txtTieuDe, 1, 1);
            form.Controls.Add(UiHelpers.Label("Mô tả"), 2, 1);
            form.Controls.Add(_txtMoTa, 3, 1);
            form.Controls.Add(UiHelpers.Label("File đính kèm"), 0, 2);
            form.Controls.Add(_txtFile, 1, 2);
            var buttons = new FlowLayoutPanel { AutoSize = true };
            var btnMoi = UiHelpers.Button("Thêm mới");
            var btnGiao = UiHelpers.Button("Giao bài");
            var btnXoa = UiHelpers.Button("Xóa");
            var btnFile = UiHelpers.Button("Chọn file");
            btnMoi.Click += (s, e) => ClearForm();
            btnGiao.Click += (s, e) => Save();
            btnXoa.Click += (s, e) => Delete();
            btnFile.Click += (s, e) => BrowseFile();
            buttons.Controls.Add(btnMoi);
            buttons.Controls.Add(btnGiao);
            buttons.Controls.Add(btnXoa);
            buttons.Controls.Add(btnFile);
            form.Controls.Add(buttons, 3, 2);
            _grid.SelectionChanged += (s, e) => FillFromGrid();
            root.Controls.Add(form, 0, 0);
            root.Controls.Add(_grid, 0, 1);
            AddContent(root);
            UiHelpers.BindLopHoc(_cboLop, Services);
            _cboLop.SelectedIndexChanged += (s, e) => LoadData();
            _dtDeadline.Value = DateTime.Now.AddDays(7);
            LoadData();
        }

        private void LoadData()
        {
            var maLop = UiHelpers.SelectedId(_cboLop);
            _grid.DataSource = Services.BaiTap.LayDanhSach(maLop == 0 ? (int?)null : maLop);
        }

        private void FillFromGrid()
        {
            var item = UiHelpers.SelectedItem<BaiTapDTO>(_grid);
            if (item == null) return;
            _selectedId = item.MaBaiTap;
            _cboLop.SelectedValue = item.MaLopHoc;
            _txtTieuDe.Text = item.TieuDe;
            _txtMoTa.Text = item.MoTa;
            _txtFile.Text = item.FileDinhKem;
            _dtDeadline.Value = item.Deadline;
        }

        private void ClearForm()
        {
            _selectedId = 0;
            _txtTieuDe.Clear();
            _txtMoTa.Clear();
            _txtFile.Clear();
            _dtDeadline.Value = DateTime.Now.AddDays(7);
        }

        private void Save()
        {
            var result = Services.BaiTap.GiaoBai(new BaiTapDTO
            {
                MaBaiTap = _selectedId,
                MaLopHoc = UiHelpers.SelectedId(_cboLop),
                TieuDe = _txtTieuDe.Text.Trim(),
                MoTa = _txtMoTa.Text.Trim(),
                Deadline = _dtDeadline.Value,
                FileDinhKem = _txtFile.Text.Trim()
            });
            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }

        private void Delete()
        {
            if (_selectedId == 0) return;
            var result = Services.BaiTap.Xoa(_selectedId);
            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                ClearForm();
                LoadData();
            }
        }

        private void BrowseFile()
        {
            using (var dialog = new OpenFileDialog { Filter = "File bài tập|*.pdf;*.doc;*.docx;*.zip;*.rar|Tất cả|*.*" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _txtFile.Text = dialog.FileName;
                }
            }
        }
    }
}
