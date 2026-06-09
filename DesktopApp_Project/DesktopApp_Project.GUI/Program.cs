using System;
// Điểm khởi động ứng dụng Windows Forms
// Chức năng:
// - Cấu hình giao diện ban đầu
// - Mở biểu mẫu đăng nhập để bắt đầu phiên làm việc

using System.Windows.Forms;
using DesktopApp_Project.GUI;
using DesktopApp_Project.GUI.Shared.Themes;

namespace DesktopApp_Project
{
    // Lớp hỗ trợ giao diện lưu dữ liệu điểm khởi động ứng dụng cho biểu mẫu sử dụng nội bộ.
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ThemeManager.SetTheme("AppTheme");
            Application.Run(new FrmDangNhap());
        }
    }
}
