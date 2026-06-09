// Biểu mẫu quản lý hóa đơn học phí
// Chức năng:
// - Hiển thị và nhập dữ liệu hóa đơn học phí
// - Gọi tầng nghiệp vụ để tải, lưu hoặc xóa dữ liệu
// - Cập nhật trạng thái giao diện sau thao tác của người dùng

using System;
using System.Diagnostics;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    // Lớp biểu mẫu Windows Forms chịu trách nhiệm hiển thị hóa đơn học phí và gọi tầng nghiệp vụ khi người dùng thao tác.
    public partial class FrmHoaDonHocPhi : ModuleFormBase
    {
        private readonly int _maThanhToan;

        public FrmHoaDonHocPhi()
        {
            InitializeComponent();
            WireEvents();
        }

        public FrmHoaDonHocPhi(ServiceFactory services, NguoiDungDTO currentUser, int maThanhToan)
            : this()
        {
            _maThanhToan = maThanhToan;
            SetRuntimeContext(services, currentUser);
        }

        // Đăng ký các hàm xử lý sự kiện cho điều khiển trên biểu mẫu.
        private void WireEvents()
        {
            WireClick(btnXuatHtml, BtnXuatHtml_Click);
            WireClick(btnIn, BtnIn_Click);
            WireClick(btnDong, (s, e) => Close());
        }

        // Nạp dữ liệu và thiết lập trạng thái ban đầu khi biểu mẫu được mở.
        protected override void OnRuntimeLoad()
        {
            // Gọi tầng nghiệp vụ để tạo hóa đơn học phí dạng HTML.
            var result = Services.BaoCao.TaoHoaDonHocPhiHtml(_maThanhToan);
            if (!result.Success)
            {
                UiHelpers.ShowResult(result);
                return;
            }

            browser.DocumentText = result.Data;
            txtFallback.Text = result.Data;
        }

        // Xử lý sự kiện người dùng nhấn nút xuất tệp HTML.
        private void BtnXuatHtml_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                // Gọi tầng nghiệp vụ để xuất hóa đơn học phí dạng HTML.
                var result = Services.BaoCao.XuatHoaDonHocPhiHtml(_maThanhToan, dialog.SelectedPath);
                UiHelpers.ShowResult(result);
                if (result.Success)
                {
                    Process.Start(new ProcessStartInfo(result.Data) { UseShellExecute = true });
                }
            }
        }

        // Xử lý sự kiện người dùng nhấn nút In.
        private void BtnIn_Click(object sender, EventArgs e)
        {
            if (browser.Document != null)
            {
                browser.Print();
                return;
            }

            Info("Chuc nang in chi ho tro khi hien thi bang WebBrowser.");
        }
    }
}
