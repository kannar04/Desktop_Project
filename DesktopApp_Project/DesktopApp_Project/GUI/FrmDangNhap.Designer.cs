namespace DesktopApp_Project.GUI
{
    partial class FrmDangNhap
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox _txtTaiKhoan;
        private System.Windows.Forms.TextBox _txtMatKhau;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._txtTaiKhoan = UiHelpers.TextBox();
            this._txtMatKhau = UiHelpers.TextBox();
            System.Windows.Forms.Label title = new System.Windows.Forms.Label();
            System.Windows.Forms.TableLayoutPanel panel = new System.Windows.Forms.TableLayoutPanel();
            System.Windows.Forms.Button btnDangNhap = UiHelpers.Button("Đăng nhập");
            panel.SuspendLayout();
            this.SuspendLayout();

            this.Text = "Đăng nhập - Quản lý lớp IELTS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ClientSize = new System.Drawing.Size(430, 270);
            this.Font = UiHelpers.DefaultFont;
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.BackColor = UiHelpers.AppBackgroundColor;

            title.Text = "QUẢN LÝ LỚP IELTS";
            title.Dock = System.Windows.Forms.DockStyle.Top;
            title.Height = 58;
            title.Font = UiHelpers.TitleFont;
            title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            title.ForeColor = System.Drawing.Color.White;
            title.BackColor = UiHelpers.AccentColor;

            panel.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Padding = new System.Windows.Forms.Padding(28, 18, 28, 12);
            panel.BackColor = UiHelpers.SurfaceColor;
            panel.ColumnCount = 2;
            panel.RowCount = 4;
            panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));

            this._txtMatKhau.PasswordChar = '*';
            this._txtTaiKhoan.Text = "admin";

            btnDangNhap.Width = 140;
            btnDangNhap.Click += this.BtnDangNhap_Click;
            this.AcceptButton = btnDangNhap;

            panel.Controls.Add(UiHelpers.Label("Tài khoản"), 0, 0);
            panel.Controls.Add(this._txtTaiKhoan, 1, 0);
            panel.Controls.Add(UiHelpers.Label("Mật khẩu"), 0, 1);
            panel.Controls.Add(this._txtMatKhau, 1, 1);
            panel.Controls.Add(new System.Windows.Forms.Label
            {
                Text = "Tài khoản mẫu sau khi chạy Schema.sql: admin/admin hoặc giaovien/123456.",
                AutoSize = true,
                ForeColor = System.Drawing.Color.DimGray,
                Padding = new System.Windows.Forms.Padding(0, 8, 0, 8)
            }, 1, 2);
            panel.Controls.Add(btnDangNhap, 1, 3);

            this.Controls.Add(panel);
            this.Controls.Add(title);
            this.Name = "FrmDangNhap";
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            panel.ResumeLayout(false);
            panel.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
