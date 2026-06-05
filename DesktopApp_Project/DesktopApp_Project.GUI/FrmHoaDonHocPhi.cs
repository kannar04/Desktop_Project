using System;
using System.Diagnostics;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
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

        private void WireEvents()
        {
            WireClick(btnXuatHtml, BtnXuatHtml_Click);
            WireClick(btnIn, BtnIn_Click);
            WireClick(btnDong, (s, e) => Close());
        }

        protected override void OnRuntimeLoad()
        {
            var result = Services.BaoCao.TaoHoaDonHocPhiHtml(_maThanhToan);
            if (!result.Success)
            {
                UiHelpers.ShowResult(result);
                return;
            }

            browser.DocumentText = result.Data;
            txtFallback.Text = result.Data;
        }

        private void BtnXuatHtml_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                var result = Services.BaoCao.XuatHoaDonHocPhiHtml(_maThanhToan, dialog.SelectedPath);
                UiHelpers.ShowResult(result);
                if (result.Success)
                {
                    Process.Start(new ProcessStartInfo(result.Data) { UseShellExecute = true });
                }
            }
        }

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
