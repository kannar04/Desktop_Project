// Biểu mẫu quản lý học viên
// Chức năng:
// - Hiển thị và nhập dữ liệu học viên
// - Gọi tầng nghiệp vụ để tải, lưu hoặc xóa dữ liệu
// - Cập nhật trạng thái giao diện sau thao tác của người dùng

using System;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    // Lớp biểu mẫu Windows Forms chịu trách nhiệm hiển thị học viên và gọi tầng nghiệp vụ khi người dùng thao tác.
    public partial class FrmHocVien : ModuleFormBase
    {
        private int _selectedId;
        private bool _allowGridFill;

        public FrmHocVien()
        {
            InitializeComponent();
            WireEvents();
        }

        public FrmHocVien(ServiceFactory services, NguoiDungDTO currentUser)
            : this()
        {
            SetRuntimeContext(services, currentUser);
        }

        // Đăng ký các hàm xử lý sự kiện cho điều khiển trên biểu mẫu.
        private void WireEvents()
        {
            WireClick(btnTim, BtnTim_Click);
            WireClick(btnThem, BtnThem_Click);
            WireClick(btnLuu, BtnLuu_Click);
            WireClick(btnXoa, BtnXoa_Click);
            WireSelectionChanged(_grid, Grid_SelectionChanged);
            WireCellClick(_grid, Grid_CellClick);
        }

        // Nạp dữ liệu và thiết lập trạng thái ban đầu khi biểu mẫu được mở.
        protected override void OnRuntimeLoad()
        {
            ConfigureFilters();
            ConfigureClassSelector();
            LoadData();
        }

        // Xử lý bộ lọc tìm kiếm.
        private void ConfigureFilters()
        {
            _lblDesigner1.Text = "Tên";
            // Gọi tầng nghiệp vụ để lấy danh sách hiển thị.
            var lopHoc = Services.LopHoc.LayDanhSach();
            lopHoc.Insert(0, new LopHocDTO { MaLopHoc = 0, TenLop = AppConstants.FilterAll });
            _cboLopFilter.DisplayMember = "TenLop";
            _cboLopFilter.ValueMember = "MaLopHoc";
            // Xóa dữ liệu đang hiển thị trên ô chọn lớp khi chưa đủ điều kiện tải.
            _cboLopFilter.DataSource = lopHoc;
            // Xóa dữ liệu đang hiển thị trên ô chọn trạng thái khi chưa đủ điều kiện tải.
            _cboTrangThaiFilter.DataSource = AppConstants.StudentStatusFilters;
        }

        // Xử lý ô chọn lớp.
        private void ConfigureClassSelector()
        {
            LoadClassSelector();
        }

        // Lấy danh sách lớp trong ô chọn.
        private void LoadClassSelector()
        {
            if (_cboLop == null)
            {
                return;
            }

            // Gọi tầng nghiệp vụ để lấy danh sách hiển thị.
            var lopHoc = Services.LopHoc.LayDanhSach();
            lopHoc.Insert(0, new LopHocDTO { MaLopHoc = 0, TenLop = "-- Chọn lớp --" });
            _cboLop.DisplayMember = "TenLop";
            _cboLop.ValueMember = "MaLopHoc";
            // Xóa dữ liệu đang hiển thị trên ô chọn lớp khi chưa đủ điều kiện tải.
            _cboLop.DataSource = lopHoc;
        }

        // Xử lý lớp đang chọn.
        private void SelectClass(int maLopHoc)
        {
            if (_cboLop == null)
            {
                return;
            }

            foreach (var item in _cboLop.Items)
            {
                var lopHoc = item as LopHocDTO;
                if (lopHoc != null && lopHoc.MaLopHoc == maLopHoc)
                {
                    _cboLop.SelectedValue = maLopHoc;
                    return;
                }
            }

            _cboLop.SelectedValue = 0;
        }

        // tải dữ liệu.
        private void LoadData()
        {
            int? maLopHoc = null;
            if (_cboLopFilter != null && _cboLopFilter.SelectedValue != null)
            {
                int parsed;
                if (int.TryParse(_cboLopFilter.SelectedValue.ToString(), out parsed) && parsed > 0)
                {
                    maLopHoc = parsed;
                }
            }

            // Nạp kết quả tìm kiếm vào bảng.
            _grid.DataSource = SafeLoad<object>(() => Services.HocVien.TimKiem(new HocVienSearchCriteriaDTO
            {
                HoTen = _txtTim.Text,
                LienHe = _txtLienHe == null ? null : _txtLienHe.Text,
                MaLopHoc = maLopHoc,
                TrangThai = _cboTrangThaiFilter == null ? AppConstants.FilterAll : Convert.ToString(_cboTrangThaiFilter.SelectedItem)
            }), null);
            ResetGridSelection();
        }

        // Đưa dữ liệu từ dòng đang chọn trên lưới lên các ô nhập liệu.
        private void FillFromGrid()
        {
            var item = UiHelpers.SelectedItem<NguoiDungDTO>(_grid);
            if (item == null) return;

            _selectedId = item.MaNguoiDung;
            _txtHoTen.Text = item.HoTen;
            _dtNgaySinh.Value = item.NgaySinh ?? DateTime.Today;
            _txtSdt.Text = item.SDT;
            _txtEmail.Text = item.Email;
            _txtTrinhDo.Text = item.TrinhDoDauVao;
            _txtTaiKhoan.Text = item.TaiKhoan;
            _txtMatKhau.Text = item.MatKhau;
            // Gọi tầng nghiệp vụ để lấy lớp đang học.
            var maLopHoc = SafeLoad<int?>(() => Services.HocVien.LayLopDangHoc(item.MaNguoiDung), null);
            SelectClass(maLopHoc.HasValue ? maLopHoc.Value : 0);
        }

        // Xóa dữ liệu nhập và đưa biểu mẫu về trạng thái thao tác mới.
        private void ClearForm()
        {
            _selectedId = 0;
            foreach (var text in new[] { _txtHoTen, _txtSdt, _txtEmail, _txtTrinhDo, _txtTaiKhoan, _txtMatKhau })
            {
                text.Clear();
            }
            _dtNgaySinh.Value = DateTime.Today;
            if (_cboLop != null)
            {
                SelectClass(0);
            }
        }

        // Xử lý sự kiện người dùng nhấn nút Tìm.
        private void BtnTim_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        // Xử lý sự kiện người dùng nhấn nút Thêm.
        private void BtnThem_Click(object sender, EventArgs e)
        {
            // Gọi tầng nghiệp vụ để lưu học viên kèm lớp học.
            var result = Services.HocVien.LuuVoiLop(BuildDto(0), UiHelpers.SelectedId(_cboLop));
            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                LoadData();
                ClearForm();
                ResetGridSelection();
                _txtHoTen.Focus();
            }
        }

        // Xử lý sự kiện người dùng nhấn nút Lưu.
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn bản ghi trên lưới trước khi cập nhật hoặc xóa.
            if (_selectedId == 0)
            {
                UiHelpers.WarnSelect("hoc vien");
                return;
            }

            // Gọi tầng nghiệp vụ để lưu học viên kèm lớp học.
            var result = Services.HocVien.LuuVoiLop(BuildDto(_selectedId), UiHelpers.SelectedId(_cboLop));

            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }

        // Tạo đối tượng truyền dữ liệu từ dữ liệu người dùng nhập trên biểu mẫu để gửi xuống tầng nghiệp vụ.
        private NguoiDungDTO BuildDto(int maNguoiDung)
        {
            // Đóng gói dữ liệu trên biểu mẫu vào đối tượng truyền dữ liệu trước khi chuyển xuống tầng nghiệp vụ.
            return new NguoiDungDTO
            {
                MaNguoiDung = maNguoiDung,
                HoTen = _txtHoTen.Text.Trim(),
                NgaySinh = _dtNgaySinh.Value.Date,
                SDT = _txtSdt.Text.Trim(),
                Email = _txtEmail.Text.Trim(),
                TrinhDoDauVao = _txtTrinhDo.Text.Trim(),
                TaiKhoan = _txtTaiKhoan.Text.Trim(),
                MatKhau = _txtMatKhau.Text
            };
        }

        // Xử lý sự kiện người dùng nhấn nút Xóa.
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn bản ghi trên lưới trước khi cập nhật hoặc xóa.
            if (_selectedId == 0)
            {
                UiHelpers.WarnSelect("học viên");
                return;
            }

            // Xác nhận với người dùng trước khi xóa dữ liệu.
            if (!UiHelpers.ConfirmDelete("học viên"))
            {
                return;
            }

            // Gọi tầng nghiệp vụ để xóa bản ghi đang chọn.
            var result = Services.HocVien.Xoa(_selectedId);
            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                ClearForm();
                LoadData();
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
