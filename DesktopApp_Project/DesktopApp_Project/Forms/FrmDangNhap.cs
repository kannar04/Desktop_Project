using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DesktopApp_Project.Forms
{
    public partial class FrmDangNhap : FormBase
    {
        public FrmDangNhap()
        {
            InitializeComponent();
            txtUsername.Focus(); 

        }

        //Methods
        // Tạo gradient background cho Form và Panel
        private void DrawGradientBackground(object sender, PaintEventArgs e)
        {
            // 1. Xác định xem ai đang gọi hàm này (Form hay Panel)
            Control ctrl = sender as Control;
            if (ctrl == null || ctrl.ClientSize.Width == 0 || ctrl.ClientSize.Height == 0) return;

            // 2. Lấy 2 mã màu từ ảnh của bro
            Color color1 = ColorTranslator.FromHtml("#060531");
            Color color2 = ColorTranslator.FromHtml("#1B1448");

            // 3. Thiết lập góc chéo (45 độ là góc chéo từ trên-trái xuống dưới-phải)
            float angle = 45f;

            // 4. Tạo bút vẽ Gradient (LinearGradientBrush)
            using (LinearGradientBrush brush = new LinearGradientBrush(ctrl.ClientRectangle, color1, color2, angle))
            {
                // Làm mịn màu (tùy chọn nhưng nên có để màu chuyển mượt hơn)
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Tiến hành tô kín bề mặt Control
                e.Graphics.FillRectangle(brush, ctrl.ClientRectangle);
            }
        }

        private void FrmDangNhap_Paint(object sender, PaintEventArgs e)
        {
            DrawGradientBackground(sender, e);
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {
            if (lblUsername.Location.Y >= txtUsername.Location.Y) // Kiểm tra nếu label chưa được di chuyển lên trên
                lblUsername.Location = new Point(lblUsername.Location.X, lblUsername.Location.Y - 20); // Di chuyển label lên trên
            lblUsername.ForeColor = Color.FromArgb(253, 138, 114); // Thay đổi màu sắc của label
            txtUsername.ForeColor = Color.FromArgb(253, 138, 114); // Thay đổi màu sắc của TextBox
            txtUsername.Focus(); // Đặt focus vào TextBox
            pnlUnder1.BackColor = Color.FromArgb(253, 138, 114); // Thay đổi màu sắc của panel dưới
            icoUsername.IconColor = Color.FromArgb(253, 138, 114); // Thay đổi màu sắc của icon
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            lblUsername.ForeColor = Color.Gainsboro; // Trả lại màu sắc ban đầu cho label
            txtUsername.ForeColor = Color.Gainsboro; // Trả lại màu sắc ban đầu cho TextBox
            pnlUnder1.BackColor = Color.FromArgb(224, 224, 224); // Trả lại màu sắc ban đầu cho panel dưới
            icoUsername.IconColor = Color.Gainsboro; // Trả lại màu sắc ban đầu cho icon
            if (string.IsNullOrEmpty(txtUsername.Text)) // Nếu TextBox rỗng, di chuyển label về vị trí ban đầu
            {
                lblUsername.Location = new Point(lblUsername.Location.X, lblUsername.Location.Y + 20); // Di chuyển label về vị trí ban đầu
            }
        }

        private void icoShowPass_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false; // Hiển thị mật khẩu
                icoShowPass.IconChar = FontAwesome.Sharp.IconChar.EyeSlash; // Thay đổi icon thành "ẩn"
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true; // Ẩn mật khẩu
                icoShowPass.IconChar = FontAwesome.Sharp.IconChar.Eye; // Thay đổi icon thành "hiện"
            }
        }

        private void lblPassword_Click(object sender, EventArgs e)
        {
            if ( lblPassword.Location.Y >= txtPassword.Location.Y) 
                lblPassword.Location = new Point(lblPassword.Location.X, lblPassword.Location.Y - 20); 
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
            if (string.IsNullOrEmpty(txtPassword.Text)) // Nếu TextBox rỗng, di chuyển label về vị trí ban đầu
                {
                    lblPassword.Location = new Point(lblPassword.Location.X, lblPassword.Location.Y + 20); // Di chuyển label về vị trí ban đầu
            }
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if ( lblUsername.Location.Y >= txtUsername.Location.Y) 
                lblUsername.Location = new Point(lblUsername.Location.X, lblUsername.Location.Y - 20); 
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
                FrmChinh frmChinh = new FrmChinh();
                frmChinh.Show();
                this.Hide();
        }
    }
}
