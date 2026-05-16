using System;
using System.Windows.Forms;
using DesktopApp_Project.BUS;

namespace DesktopApp_Project.GUI
{
    public partial class FrmDangNhap : Form
    {
        private readonly ServiceFactory _services = new ServiceFactory();

        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private void BtnDangNhap_Click(object sender, EventArgs e)
        {
            var result = _services.Auth.DangNhap(_txtTaiKhoan.Text, _txtMatKhau.Text);
            if (!result.Success)
            {
                UiHelpers.ShowResult(result);
                return;
            }

            Hide();
            using (var frm = new FrmChinh(_services, result.Data))
            {
                frm.ShowDialog(this);
            }
            Close();
        }
    }
}
