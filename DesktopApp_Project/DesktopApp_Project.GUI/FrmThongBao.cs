// Biểu mẫu quản lý thông báo
// Chức năng:
// - Hiển thị và nhập dữ liệu thông báo
// - Gọi tầng nghiệp vụ để tải, lưu hoặc xóa dữ liệu
// - Cập nhật trạng thái giao diện sau thao tác của người dùng

using System;
using DesktopApp_Project.BUS;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    // Lớp biểu mẫu Windows Forms chịu trách nhiệm hiển thị thông báo và gọi tầng nghiệp vụ khi người dùng thao tác.
    public partial class FrmThongBao : ModuleFormBase
    {
        public FrmThongBao()
        {
            InitializeComponent();
            WireEvents();
        }

        public FrmThongBao(ServiceFactory services, NguoiDungDTO currentUser)
            : this()
        {
            SetRuntimeContext(services, currentUser);
        }

        // Đăng ký các hàm xử lý sự kiện cho điều khiển trên biểu mẫu.
        private void WireEvents()
        {
            WireClick(btnGui, BtnGui_Click);
        }

        // Nạp dữ liệu và thiết lập trạng thái ban đầu khi biểu mẫu được mở.
        protected override void OnRuntimeLoad()
        {
            UiHelpers.BindLopHoc(_cboLop, Services);
            LoadData();
        }

        // tải dữ liệu.
        private void LoadData()
        {
            // Nạp danh sách vào bảng hiển thị.
            _grid.DataSource = SafeLoad<object>(() => Services.ThongBao.LayDanhSach(), null);
        }

        // Xử lý sự kiện người dùng nhấn nút Gửi.
        private void BtnGui_Click(object sender, EventArgs e)
        {
            if (!HasCurrentUser())
            {
                return;
            }

            // Gọi tầng nghiệp vụ để gửi thông báo.
            var result = Services.ThongBao.Gui(new ThongBaoDTO
            {
                MaNguoiGui = CurrentUser.MaNguoiDung,
                TieuDe = _txtTieuDe.Text.Trim(),
                NoiDung = _txtNoiDung.Text.Trim()
            }, _chkTatCa.Checked ? (int?)null : UiHelpers.SelectedId(_cboLop));

            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                _txtTieuDe.Clear();
                _txtNoiDung.Clear();
                LoadData();
            }
        }
    }
}
