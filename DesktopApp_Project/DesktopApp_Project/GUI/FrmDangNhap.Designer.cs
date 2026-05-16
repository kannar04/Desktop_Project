namespace DesktopApp_Project.GUI
{
    partial class FrmDangNhap
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label _lblDesigner2;
        private System.Windows.Forms.Label _lblDesigner1;
        private System.Windows.Forms.Label _lblHuongDan;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.TableLayoutPanel panel;
        private System.Windows.Forms.Button btnDangNhap;
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._lblDesigner2 = new System.Windows.Forms.Label();
            this._lblDesigner2.Text = "Mật khẩu";
            this._lblDesigner2.AutoSize = true;
            this._lblDesigner1 = new System.Windows.Forms.Label();
            this._lblDesigner1.Text = "Tài khoản";
            this._lblDesigner1.AutoSize = true;
            this._lblHuongDan = new System.Windows.Forms.Label();
            this._lblHuongDan.Text = "Tài khoản mẫu sau khi chạy Schema.sql: admin/admin hoặc giaovien/123456.";
            this._lblHuongDan.AutoSize = true;
            this._lblHuongDan.ForeColor = System.Drawing.Color.DimGray;
            this._lblHuongDan.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this._txtTaiKhoan = new System.Windows.Forms.TextBox();
            this._txtTaiKhoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTaiKhoan.BackColor = System.Drawing.Color.White;
            this._txtTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtTaiKhoan.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this._txtTaiKhoan.Margin = new System.Windows.Forms.Padding(4);
            this._txtTaiKhoan.MinimumSize = new System.Drawing.Size(150, 0);
            this._txtTaiKhoan.Width = 220;
            this._txtMatKhau = new System.Windows.Forms.TextBox();
            this._txtMatKhau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtMatKhau.BackColor = System.Drawing.Color.White;
            this._txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtMatKhau.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtMatKhau.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this._txtMatKhau.Margin = new System.Windows.Forms.Padding(4);
            this._txtMatKhau.MinimumSize = new System.Drawing.Size(150, 0);
            this._txtMatKhau.Width = 220;
            this.title = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.TableLayoutPanel();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.btnDangNhap.AutoEllipsis = true;
            this.btnDangNhap.BackColor = System.Drawing.Color.FromArgb(235, 242, 252);
            this.btnDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangNhap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDangNhap.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnDangNhap.Height = 34;
            this.btnDangNhap.Margin = new System.Windows.Forms.Padding(4);
            this.btnDangNhap.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Width = 110;
            this.btnDangNhap.Text = "Đăng nhập";
            this.panel.SuspendLayout();
            this.SuspendLayout();

            this.Text = "Đăng nhập - Quản lý lớp IELTS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ClientSize = new System.Drawing.Size(430, 270);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.BackColor = System.Drawing.Color.FromArgb(246, 248, 251);

            this.title.Text = "QUẢN LÝ LỚP IELTS";
            this.title.Dock = System.Windows.Forms.DockStyle.Top;
            this.title.Height = 58;
            this.title.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);

            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Padding = new System.Windows.Forms.Padding(28, 18, 28, 12);
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.ColumnCount = 2;
            this.panel.RowCount = 4;
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));

            this._txtMatKhau.PasswordChar = '*';
            this._txtTaiKhoan.Text = "admin";

            this.btnDangNhap.Width = 140;
            this.btnDangNhap.Click += this.BtnDangNhap_Click;
            this.AcceptButton = btnDangNhap;

            this.panel.Controls.Add(this._lblDesigner1, 0, 0);
            this.panel.Controls.Add(this._txtTaiKhoan, 1, 0);
            this.panel.Controls.Add(this._lblDesigner2, 0, 1);
            this.panel.Controls.Add(this._txtMatKhau, 1, 1);
            this.panel.Controls.Add(this._lblHuongDan, 1, 2);
            this.panel.Controls.Add(this.btnDangNhap, 1, 3);

            this.Controls.Add(this.panel);
            this.Controls.Add(this.title);
            this.Name = "FrmDangNhap";
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion
    }
}
