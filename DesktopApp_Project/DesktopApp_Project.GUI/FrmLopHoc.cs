// Biểu mẫu quản lý lớp học
// Chức năng:
// - Hiển thị và nhập dữ liệu lớp học
// - Gọi tầng nghiệp vụ để tải, lưu hoặc xóa dữ liệu
// - Cập nhật trạng thái giao diện sau thao tác của người dùng

using System;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    // Lớp biểu mẫu Windows Forms chịu trách nhiệm hiển thị lớp học và gọi tầng nghiệp vụ khi người dùng thao tác.
    public partial class FrmLopHoc : ModuleFormBase
    {
        private int _selectedClassId;
        private bool _allowGridFill;

        public FrmLopHoc()
        {
            InitializeComponent();
            WireEvents();
        }

        public FrmLopHoc(ServiceFactory services, NguoiDungDTO currentUser)
            : this()
        {
            SetRuntimeContext(services, currentUser);
        }

        // Đăng ký các hàm xử lý sự kiện cho điều khiển trên biểu mẫu.
        private void WireEvents()
        {
            WireClick(btnThem, BtnThem_Click);
            WireClick(btnLuu, BtnLuu_Click);
            WireClick(btnXoa, BtnXoa_Click);
            WireSelectionChanged(_gridLop, GridLop_SelectionChanged);
            WireCellClick(_gridLop, GridLop_CellClick);
        }

        // Nạp dữ liệu và thiết lập trạng thái ban đầu khi biểu mẫu được mở.
        protected override void OnRuntimeLoad()
        {
            LoadClasses();
        }

        // Lấy danh sách lớp.
        private void LoadClasses()
        {
            // Nạp danh sách vào bảng lớp.
            _gridLop.DataSource = SafeLoad<object>(() => Services.LopHoc.LayDanhSach(), null);
            ClearForm();
            LoadStudents();
            ResetClassGridSelection();
        }

        // Đưa dữ liệu từ dòng đang chọn trên lưới lên các ô nhập liệu.
        private void FillClass()
        {
            var item = UiHelpers.SelectedItem<LopHocDTO>(_gridLop);
            if (item == null) return;

            _selectedClassId = item.MaLopHoc;
            _txtTenLop.Text = item.TenLop;
            _txtTrinhDo.Text = item.NhomTrinhDo;
            _txtLichHoc.Text = item.LichHoc;
            LoadStudents();
        }

        // Lấy danh sách học viên.
        private void LoadStudents()
        {
            if (_selectedClassId <= 0)
            {
                // Xóa dữ liệu đang hiển thị trên bảng học viên trong lớp khi chưa đủ điều kiện tải.
                _gridTrongLop.DataSource = null;
                return;
            }

            // Nạp danh sách học viên trong lớp vào bảng trong lớp.
            _gridTrongLop.DataSource = SafeLoad<object>(() => Services.LopHoc.LayHocVienTrongLop(_selectedClassId), null);
        }

        // Xóa dữ liệu nhập và đưa biểu mẫu về trạng thái thao tác mới.
        private void ClearForm()
        {
            _selectedClassId = 0;
            _txtTenLop.Clear();
            _txtTrinhDo.Clear();
            _txtLichHoc.Clear();
        }

        // Xử lý sự kiện người dùng nhấn nút Thêm.
        private void BtnThem_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        // Xử lý sự kiện người dùng nhấn nút Lưu.
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (!HasCurrentUser())
            {
                return;
            }

            // Gọi tầng nghiệp vụ để lưu dữ liệu đang nhập.
            var result = Services.LopHoc.Luu(new LopHocDTO
            {
                MaLopHoc = _selectedClassId,
                MaGiaoVien = CurrentUser.MaNguoiDung,
                TenLop = _txtTenLop.Text.Trim(),
                NhomTrinhDo = _txtTrinhDo.Text.Trim(),
                LichHoc = _txtLichHoc.Text.Trim()
            });

            UiHelpers.ShowResult(result);
            if (result.Success) LoadClasses();
        }

        // Xử lý sự kiện người dùng nhấn nút Xóa.
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedClassId == 0)
            {
                UiHelpers.WarnSelect("lớp học");
                return;
            }

            // Xác nhận với người dùng trước khi xóa dữ liệu.
            if (!UiHelpers.ConfirmDelete("lớp học"))
            {
                return;
            }

            // Gọi tầng nghiệp vụ để xóa bản ghi đang chọn.
            var result = Services.LopHoc.Xoa(_selectedClassId);
            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                ClearForm();
                LoadClasses();
                LoadStudents();
            }
        }

        // Xử lý khi người dùng chọn dữ liệu trên bảng dữ liệu.
        private void GridLop_SelectionChanged(object sender, EventArgs e)
        {
            if (!_allowGridFill)
            {
                return;
            }

            FillClass();
        }

        // Xử lý khi người dùng chọn dữ liệu trên bảng dữ liệu.
        private void GridLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            _allowGridFill = true;
            FillClass();
        }

        // Xóa trạng thái class chọn dòng trên bảng.
        private void ResetClassGridSelection()
        {
            _allowGridFill = false;
            _gridLop.ClearSelection();
            _gridLop.CurrentCell = null;
        }
    }
}
