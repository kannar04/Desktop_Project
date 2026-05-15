using System;
using System.Drawing;
using System.Windows.Forms;
using DesktopApp_Project.BUS;

namespace DesktopApp_Project.GUI
{
    public class FrmDangNhap : Form
    {
        private readonly ServiceFactory _services = new ServiceFactory();
        private readonly TextBox _txtTaiKhoan = UiHelpers.TextBox();
        private readonly TextBox _txtMatKhau = UiHelpers.TextBox();

        public FrmDangNhap()
        {
            Text = "Đăng nhập - Quản lý lớp IELTS";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(430, 270);
            Font = UiHelpers.DefaultFont;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            var title = new Label
            {
                Text = "QUẢN LÝ LỚP IELTS",
                Dock = DockStyle.Top,
                Height = 58,
                Font = UiHelpers.TitleFont,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var panel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(28, 12, 28, 12),
                ColumnCount = 2,
                RowCount = 4
            };
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            _txtMatKhau.PasswordChar = '*';
            _txtTaiKhoan.Text = "admin";

            var btnDangNhap = UiHelpers.Button("Đăng nhập");
            btnDangNhap.Width = 140;
            btnDangNhap.Click += DangNhap;
            AcceptButton = btnDangNhap;

            panel.Controls.Add(UiHelpers.Label("Tài khoản"), 0, 0);
            panel.Controls.Add(_txtTaiKhoan, 1, 0);
            panel.Controls.Add(UiHelpers.Label("Mật khẩu"), 0, 1);
            panel.Controls.Add(_txtMatKhau, 1, 1);
            panel.Controls.Add(new Label
            {
                Text = "Tài khoản mẫu sau khi chạy Schema.sql: admin/admin hoặc giaovien/123456.",
                AutoSize = true,
                ForeColor = Color.DimGray,
                Padding = new Padding(0, 8, 0, 8)
            }, 1, 2);
            panel.Controls.Add(btnDangNhap, 1, 3);

            Controls.Add(panel);
            Controls.Add(title);
        }

        private void DangNhap(object sender, EventArgs e)
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
