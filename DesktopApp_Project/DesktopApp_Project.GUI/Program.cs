using System;
using System.Windows.Forms;
using DesktopApp_Project.GUI;
using DesktopApp_Project.GUI.Shared.Themes;

namespace DesktopApp_Project
{
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
