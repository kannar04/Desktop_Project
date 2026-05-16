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

    public partial class FrmTaiLieu : ModuleFormBase
    {
        private readonly DataGridView _grid = UiHelpers.Grid();
        private readonly ComboBox _cboLop = UiHelpers.ComboBox();
        private readonly ComboBox _cboKyNang = UiHelpers.ComboBox();
        private readonly TextBox _txtChuDe = UiHelpers.TextBox();
        private readonly TextBox _txtMoTa = UiHelpers.TextBox();
        private readonly TextBox _txtFile = UiHelpers.TextBox();
        private readonly TextBox _txtVideo = UiHelpers.TextBox();
        private int _selectedId;

        public FrmTaiLieu(ServiceFactory services, NguoiDungDTO currentUser) : base(services, currentUser, "Cập nhật tài liệu giảng dạy")
        {
            InitializeComponent();
            var root = BuildDocumentLikeLayout("Tài liệu", Save, Delete, BrowseFile);
            AddContent(root);
            ReloadCombos();
            _cboLop.SelectedIndexChanged += (s, e) => LoadData();
            LoadData();
        }

        private Control BuildDocumentLikeLayout(string label, EventHandler save, EventHandler delete, EventHandler browse)
        {
            var root = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2 };
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            var form = UiHelpers.FormGrid();
            form.Controls.Add(UiHelpers.Label("Lớp"), 0, 0);
            form.Controls.Add(_cboLop, 1, 0);
            form.Controls.Add(UiHelpers.Label("Kỹ năng"), 2, 0);
            form.Controls.Add(_cboKyNang, 3, 0);
            form.Controls.Add(UiHelpers.Label("Chủ đề"), 0, 1);
            form.Controls.Add(_txtChuDe, 1, 1);
            form.Controls.Add(UiHelpers.Label("Mô tả"), 2, 1);
            form.Controls.Add(_txtMoTa, 3, 1);
            form.Controls.Add(UiHelpers.Label("Đường dẫn file"), 0, 2);
            form.Controls.Add(_txtFile, 1, 2);
            form.Controls.Add(UiHelpers.Label("Video link"), 2, 2);
            form.Controls.Add(_txtVideo, 3, 2);
            var buttons = new FlowLayoutPanel { AutoSize = true };
            var btnMoi = UiHelpers.Button("Thêm mới");
            var btnLuu = UiHelpers.Button("Lưu");
            var btnXoa = UiHelpers.Button("Xóa");
            var btnFile = UiHelpers.Button("Chọn file");
            btnMoi.Click += (s, e) => ClearForm();
            btnLuu.Click += save;
            btnXoa.Click += delete;
            btnFile.Click += browse;
            buttons.Controls.Add(btnMoi);
            buttons.Controls.Add(btnLuu);
            buttons.Controls.Add(btnXoa);
            buttons.Controls.Add(btnFile);
            form.Controls.Add(buttons, 3, 3);
            _grid.SelectionChanged += (s, e) => FillFromGrid();
            root.Controls.Add(form, 0, 0);
            root.Controls.Add(_grid, 0, 1);
            return root;
        }

        private void ReloadCombos()
        {
            UiHelpers.BindLopHoc(_cboLop, Services);
            UiHelpers.BindKyNang(_cboKyNang);
        }

        private void LoadData()
        {
            var maLop = UiHelpers.SelectedId(_cboLop);
            _grid.DataSource = Services.TaiLieu.LayDanhSach(maLop == 0 ? (int?)null : maLop);
        }

        private void FillFromGrid()
        {
            var item = UiHelpers.SelectedItem<TaiLieuDTO>(_grid);
            if (item == null) return;
            _selectedId = item.MaTaiLieu;
            _cboLop.SelectedValue = item.MaLopHoc;
            _cboKyNang.SelectedItem = item.NhanKyNang;
            _txtChuDe.Text = item.TenChuDe;
            _txtMoTa.Text = item.NoiDungMoTa;
            _txtFile.Text = item.DuongDanFile;
            _txtVideo.Text = item.VideoLink;
        }

        private void ClearForm()
        {
            _selectedId = 0;
            _txtChuDe.Clear();
            _txtMoTa.Clear();
            _txtFile.Clear();
            _txtVideo.Clear();
        }

        private void Save(object sender, EventArgs e)
        {
            var result = Services.TaiLieu.Luu(new TaiLieuDTO
            {
                MaTaiLieu = _selectedId,
                MaLopHoc = UiHelpers.SelectedId(_cboLop),
                TenChuDe = _txtChuDe.Text.Trim(),
                NoiDungMoTa = _txtMoTa.Text.Trim(),
                DuongDanFile = _txtFile.Text.Trim(),
                VideoLink = _txtVideo.Text.Trim(),
                NhanKyNang = Convert.ToString(_cboKyNang.SelectedItem)
            });
            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }

        private void Delete(object sender, EventArgs e)
        {
            if (_selectedId == 0) return;
            var result = Services.TaiLieu.Xoa(_selectedId);
            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                ClearForm();
                LoadData();
            }
        }

        private void BrowseFile(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog { Filter = "Tài liệu|*.pdf;*.doc;*.docx|Tất cả|*.*" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _txtFile.Text = dialog.FileName;
                }
            }
        }
    }
}
