// Biểu mẫu quản lý bài tập
// Chức năng:
// - Hiển thị và nhập dữ liệu bài tập
// - Gọi tầng nghiệp vụ để tải, lưu hoặc xóa dữ liệu
// - Cập nhật trạng thái giao diện sau thao tác của người dùng

using System;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    // Lớp biểu mẫu Windows Forms chịu trách nhiệm hiển thị bài tập và gọi tầng nghiệp vụ khi người dùng thao tác.
    public partial class FrmBaiTap : ModuleFormBase
    {
        private int _selectedId;
        private bool _isFilling;
        private bool _allowGridFill;

        public FrmBaiTap()
        {
            InitializeComponent();
            WireEvents();
        }

        public FrmBaiTap(ServiceFactory services, NguoiDungDTO currentUser)
            : this()
        {
            SetRuntimeContext(services, currentUser);
        }

        // Đăng ký các hàm xử lý sự kiện cho điều khiển trên biểu mẫu.
        private void WireEvents()
        {
            WireClick(btnMoi, BtnMoi_Click);
            WireClick(btnGiao, BtnGiao_Click);
            WireClick(btnXoa, BtnXoa_Click);
            WireClick(btnFile, BtnFile_Click);
            WireSelectionChanged(_grid, Grid_SelectionChanged);
            WireCellClick(_grid, Grid_CellClick);
            WireSelectedIndexChanged(_cboLop, CboLop_SelectedIndexChanged);
        }

        // Nạp dữ liệu và thiết lập trạng thái ban đầu khi biểu mẫu được mở.
        protected override void OnRuntimeLoad()
        {
            UiHelpers.BindLopHoc(_cboLop, Services);
            _dtDeadline.Value = DateTime.Now.AddDays(7);
            LoadData();
        }

        // tải dữ liệu.
        private void LoadData()
        {
            var maLop = UiHelpers.SelectedId(_cboLop);
            // Nạp danh sách vào bảng hiển thị.
            _grid.DataSource = SafeLoad<object>(() => Services.BaiTap.LayDanhSach(maLop == 0 ? (int?)null : maLop), null);
            ResetGridSelection();
        }

        // Đưa dữ liệu từ dòng đang chọn trên lưới lên các ô nhập liệu.
        private void FillFromGrid()
        {
            var item = UiHelpers.SelectedItem<BaiTapDTO>(_grid);
            if (item == null) return;

            _isFilling = true;
            try
            {
                _selectedId = item.MaBaiTap;
                if (!string.IsNullOrEmpty(_cboLop.ValueMember))
                {
                    _cboLop.SelectedValue = item.MaLopHoc;
                }
                _txtTieuDe.Text = item.TieuDe;
                _txtMoTa.Text = item.MoTa;
                _txtFile.Text = item.FileDinhKem;
                _dtDeadline.Value = item.Deadline;
            }
            finally
            {
                _isFilling = false;
            }
        }

        // Xóa dữ liệu nhập và đưa biểu mẫu về trạng thái thao tác mới.
        private void ClearForm()
        {
            _selectedId = 0;
            _txtTieuDe.Clear();
            _txtMoTa.Clear();
            _txtFile.Clear();
            _dtDeadline.Value = DateTime.Now.AddDays(7);
        }

        // Xử lý sự kiện người dùng nhấn nút Mới.
        private void BtnMoi_Click(object sender, EventArgs e)
        {
            // Gọi tầng nghiệp vụ để xử lý bài tập cho lớp.
            var result = Services.BaiTap.GiaoBai(BuildDto(0));
            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                LoadData();
                ClearForm();
                ResetGridSelection();
                _txtTieuDe.Focus();
            }
        }

        // Xử lý sự kiện người dùng nhấn nút Giao bài.
        private void BtnGiao_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn bản ghi trên lưới trước khi cập nhật hoặc xóa.
            if (_selectedId == 0)
            {
                UiHelpers.WarnSelect("bai tap");
                return;
            }

            // Gọi tầng nghiệp vụ để xử lý bài tập cho lớp.
            var result = Services.BaiTap.GiaoBai(BuildDto(_selectedId));

            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }

        // Tạo đối tượng truyền dữ liệu từ dữ liệu người dùng nhập trên biểu mẫu để gửi xuống tầng nghiệp vụ.
        private BaiTapDTO BuildDto(int maBaiTap)
        {
            // Đóng gói dữ liệu trên biểu mẫu vào đối tượng truyền dữ liệu trước khi chuyển xuống tầng nghiệp vụ.
            return new BaiTapDTO
            {
                MaBaiTap = maBaiTap,
                MaLopHoc = UiHelpers.SelectedId(_cboLop),
                TieuDe = _txtTieuDe.Text.Trim(),
                MoTa = _txtMoTa.Text.Trim(),
                Deadline = _dtDeadline.Value,
                FileDinhKem = _txtFile.Text.Trim()
            };
        }

        // Xử lý sự kiện người dùng nhấn nút Xóa.
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn bản ghi trên lưới trước khi cập nhật hoặc xóa.
            if (_selectedId == 0)
            {
                UiHelpers.WarnSelect("bài tập");
                return;
            }

            // Xác nhận với người dùng trước khi xóa dữ liệu.
            if (!UiHelpers.ConfirmDelete("bài tập"))
            {
                return;
            }

            // Gọi tầng nghiệp vụ để xóa bản ghi đang chọn.
            var result = Services.BaiTap.Xoa(_selectedId);
            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                ClearForm();
                LoadData();
            }
        }

        // Xử lý sự kiện người dùng nhấn nút Chọn tệp.
        private void BtnFile_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog { Filter = "File bài tập|*.pdf;*.doc;*.docx;*.zip;*.rar|Tất cả|*.*" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _txtFile.Text = ManagedFileStorage.CopyToManagedFolder(dialog.FileName, "BaiTap");
                }
            }
        }

        // Xử lý khi người dùng chọn dữ liệu trên bảng dữ liệu.
        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            if (!_allowGridFill)
            {
                return;
            }

            FillFromGrid();
        }

        // Xử lý khi người dùng chọn dữ liệu trên bảng dữ liệu.
        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            _allowGridFill = true;
            FillFromGrid();
        }

        // Xử lý khi người dùng thay đổi lựa chọn trên bộ lọc hoặc combobox.
        private void CboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFilling)
            {
                return;
            }

            ClearForm();
            LoadData();
        }

        // Xóa trạng thái chọn dòng trên bảng.
        private void ResetGridSelection()
        {
            _selectedId = 0;
            _allowGridFill = false;
            _grid.ClearSelection();
            _grid.CurrentCell = null;
        }
    }
}
