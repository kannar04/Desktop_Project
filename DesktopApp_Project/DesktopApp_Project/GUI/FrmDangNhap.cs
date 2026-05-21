using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using FontAwesome.Sharp;

namespace DesktopApp_Project.GUI
{
    public partial class FrmDangNhap : Form
    {
        private readonly ServiceFactory _services = new ServiceFactory();

        public FrmDangNhap()
        {
            InitializeComponent();
            ApplyBaseStyle();
            txtUsername.Focus();
            AcceptButton = btnLogin;
        }

        private void ApplyBaseStyle()
        {
            Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            BackColor = Color.FromArgb(31, 30, 68);
            FormBorderStyle = FormBorderStyle.None;
            ForeColor = Color.Gainsboro;
            StartPosition = FormStartPosition.CenterScreen;
            DoubleBuffered = true;
            Text = "Đăng nhập - Quản lý lớp IELTS";
        }

        private void DrawGradientBackground(object sender, PaintEventArgs e)
        {
            var ctrl = sender as Control;
            if (ctrl == null || ctrl.ClientSize.Width == 0 || ctrl.ClientSize.Height == 0)
            {
                return;
            }

            var color1 = ColorTranslator.FromHtml("#060531");
            var color2 = ColorTranslator.FromHtml("#1B1448");
            const float angle = 45f;

            using (var brush = new LinearGradientBrush(ctrl.ClientRectangle, color1, color2, angle))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillRectangle(brush, ctrl.ClientRectangle);
            }
        }

        private void FrmDangNhap_Paint(object sender, PaintEventArgs e)
        {
            DrawGradientBackground(sender, e);
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {
            if (lblUsername.Location.Y >= txtUsername.Location.Y)
            {
                lblUsername.Location = new Point(lblUsername.Location.X, lblUsername.Location.Y - 20);
            }
            lblUsername.ForeColor = Color.FromArgb(253, 138, 114);
            txtUsername.ForeColor = Color.FromArgb(253, 138, 114);
            txtUsername.Focus();
            pnlUnder1.BackColor = Color.FromArgb(253, 138, 114);
            icoUsername.IconColor = Color.FromArgb(253, 138, 114);
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            lblUsername.ForeColor = Color.Gainsboro;
            txtUsername.ForeColor = Color.Gainsboro;
            pnlUnder1.BackColor = Color.FromArgb(224, 224, 224);
            icoUsername.IconColor = Color.Gainsboro;
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                lblUsername.Location = new Point(lblUsername.Location.X, lblUsername.Location.Y + 20);
            }
        }

        private void icoShowPass_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
                icoShowPass.IconChar = IconChar.EyeSlash;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                icoShowPass.IconChar = IconChar.Eye;
            }
        }

        private void lblPassword_Click(object sender, EventArgs e)
        {
            if (lblPassword.Location.Y >= txtPassword.Location.Y)
            {
                lblPassword.Location = new Point(lblPassword.Location.X, lblPassword.Location.Y - 20);
            }
            lblPassword.ForeColor = Color.FromArgb(253, 138, 114);
            txtPassword.ForeColor = Color.FromArgb(253, 138, 114);
            txtPassword.Focus();
            pnlUnder2.BackColor = Color.FromArgb(253, 138, 114);
            icoPassword.IconColor = Color.FromArgb(253, 138, 114);
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            lblPassword.ForeColor = Color.Gainsboro;
            pnlUnder2.BackColor = Color.FromArgb(224, 224, 224);
            icoPassword.IconColor = Color.Gainsboro;
            txtPassword.ForeColor = Color.Gainsboro;
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                lblPassword.Location = new Point(lblPassword.Location.X, lblPassword.Location.Y + 20);
            }
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (lblUsername.Location.Y >= txtUsername.Location.Y)
            {
                lblUsername.Location = new Point(lblUsername.Location.X, lblUsername.Location.Y - 20);
            }
            lblUsername.ForeColor = Color.FromArgb(253, 138, 114);
            txtUsername.ForeColor = Color.FromArgb(253, 138, 114);
            txtUsername.Focus();
            pnlUnder1.BackColor = Color.FromArgb(253, 138, 114);
            icoUsername.IconColor = Color.FromArgb(253, 138, 114);
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (lblPassword.Location.Y >= txtPassword.Location.Y)
            {
                lblPassword.Location = new Point(lblPassword.Location.X, lblPassword.Location.Y - 20);
            }
            lblPassword.ForeColor = Color.FromArgb(253, 138, 114);
            txtPassword.ForeColor = Color.FromArgb(253, 138, 114);
            txtPassword.Focus();
            pnlUnder2.BackColor = Color.FromArgb(253, 138, 114);
            icoPassword.IconColor = Color.FromArgb(253, 138, 114);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var result = _services.Auth.DangNhap(txtUsername.Text, txtPassword.Text);
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
