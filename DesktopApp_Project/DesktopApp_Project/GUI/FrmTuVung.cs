using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{

    public partial class FrmTuVung : ModuleFormBase
    {
        private readonly DataGridView _grid = UiHelpers.Grid();
        private readonly ComboBox _cboLop = UiHelpers.ComboBox();
        private readonly TextBox _txtTu = UiHelpers.TextBox();
        private readonly TextBox _txtLoai = UiHelpers.TextBox();
        private readonly TextBox _txtPhienAm = UiHelpers.TextBox();
        private readonly TextBox _txtNghia = UiHelpers.TextBox();
        private int _selectedId;

        public FrmTuVung(ServiceFactory services, NguoiDungDTO currentUser) : base(services, currentUser, "Cập nhật kho từ vựng")
        {
            InitializeComponent();
            var root = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2 };
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            var form = UiHelpers.FormGrid();
            form.Controls.Add(UiHelpers.Label("Lớp"), 0, 0);
            form.Controls.Add(_cboLop, 1, 0);
            form.Controls.Add(UiHelpers.Label("Từ tiếng Anh"), 2, 0);
            form.Controls.Add(_txtTu, 3, 0);
            form.Controls.Add(UiHelpers.Label("Từ loại"), 0, 1);
            form.Controls.Add(_txtLoai, 1, 1);
            form.Controls.Add(UiHelpers.Label("Phiên âm"), 2, 1);
            form.Controls.Add(_txtPhienAm, 3, 1);
            form.Controls.Add(UiHelpers.Label("Nghĩa"), 0, 2);
            form.Controls.Add(_txtNghia, 1, 2);
            var buttons = new FlowLayoutPanel { AutoSize = true };
            var btnMoi = UiHelpers.Button("Thêm mới");
            var btnLuu = UiHelpers.Button("Lưu");
            var btnXoa = UiHelpers.Button("Xóa");
            btnMoi.Click += (s, e) => ClearForm();
            btnLuu.Click += (s, e) => Save();
            btnXoa.Click += (s, e) => Delete();
            buttons.Controls.Add(btnMoi);
            buttons.Controls.Add(btnLuu);
            buttons.Controls.Add(btnXoa);
            form.Controls.Add(buttons, 3, 2);
            _grid.SelectionChanged += (s, e) => Fill();
            root.Controls.Add(form, 0, 0);
            root.Controls.Add(_grid, 0, 1);
            AddContent(root);
            UiHelpers.BindLopHoc(_cboLop, Services);
            _cboLop.SelectedIndexChanged += (s, e) => LoadData();
            LoadData();
        }

        private void LoadData()
        {
            _grid.DataSource = Services.TuVung.LayDanhSach(UiHelpers.SelectedId(_cboLop));
        }

        private void Fill()
        {
            var item = UiHelpers.SelectedItem<TuVungDTO>(_grid);
            if (item == null) return;
            _selectedId = item.MaTuVung;
            _cboLop.SelectedValue = item.MaLopHoc;
            _txtTu.Text = item.TuTiengAnh;
            _txtLoai.Text = item.TuLoai;
            _txtPhienAm.Text = item.PhienAm;
            _txtNghia.Text = item.Nghia;
        }

        private void ClearForm()
        {
            _selectedId = 0;
            _txtTu.Clear();
            _txtLoai.Clear();
            _txtPhienAm.Clear();
            _txtNghia.Clear();
        }

        private void Save()
        {
            var result = Services.TuVung.Luu(new TuVungDTO
            {
                MaTuVung = _selectedId,
                MaLopHoc = UiHelpers.SelectedId(_cboLop),
                TuTiengAnh = _txtTu.Text.Trim(),
                TuLoai = _txtLoai.Text.Trim(),
                PhienAm = _txtPhienAm.Text.Trim(),
                Nghia = _txtNghia.Text.Trim()
            });
            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }

        private void Delete()
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
    }
}
