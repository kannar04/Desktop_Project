namespace DesktopApp_Project.GUI
{
    partial class FrmChinh
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label _lblHeader;
        private System.Windows.Forms.Panel _contentPanel;
        private System.Windows.Forms.FlowLayoutPanel _menuPanel;

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
            this._lblHeader = new System.Windows.Forms.Label();
            this._contentPanel = new System.Windows.Forms.Panel();
            this._menuPanel = new System.Windows.Forms.FlowLayoutPanel();
            System.Windows.Forms.TableLayoutPanel shell = new System.Windows.Forms.TableLayoutPanel();
            System.Windows.Forms.TableLayoutPanel body = new System.Windows.Forms.TableLayoutPanel();
            System.Windows.Forms.Button btnHocVien = MenuButton("Hồ sơ học viên");
            System.Windows.Forms.Button btnLopHoc = MenuButton("Lớp học");
            System.Windows.Forms.Button btnTaiLieu = MenuButton("Tài liệu");
            System.Windows.Forms.Button btnBaiTap = MenuButton("Bài tập");
            System.Windows.Forms.Button btnChamBai = MenuButton("Chấm bài");
            System.Windows.Forms.Button btnDiemSo = MenuButton("Điểm số");
            System.Windows.Forms.Button btnDiemDanh = MenuButton("Điểm danh");
            System.Windows.Forms.Button btnDeThi = MenuButton("Đề thi");
            System.Windows.Forms.Button btnBaoCao = MenuButton("Báo cáo");
            System.Windows.Forms.Button btnTuVung = MenuButton("Từ vựng");
            System.Windows.Forms.Button btnThongBao = MenuButton("Thông báo");
            System.Windows.Forms.Button btnHocPhi = MenuButton("Học phí");
            shell.SuspendLayout();
            body.SuspendLayout();
            this._menuPanel.SuspendLayout();
            this.SuspendLayout();

            this.Text = "Quản lý lớp IELTS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MinimumSize = new System.Drawing.Size(1050, 700);
            this.Font = UiHelpers.DefaultFont;

            shell.Dock = System.Windows.Forms.DockStyle.Fill;
            shell.ColumnCount = 1;
            shell.RowCount = 2;
            shell.Margin = System.Windows.Forms.Padding.Empty;
            shell.BackColor = UiHelpers.AppBackgroundColor;
            shell.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            shell.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            shell.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            body.Dock = System.Windows.Forms.DockStyle.Fill;
            body.ColumnCount = 2;
            body.RowCount = 1;
            body.Margin = System.Windows.Forms.Padding.Empty;
            body.BackColor = UiHelpers.AppBackgroundColor;
            body.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            body.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            body.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            this._lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lblHeader.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this._lblHeader.Font = UiHelpers.TitleFont;
            this._lblHeader.ForeColor = System.Drawing.Color.White;
            this._lblHeader.BackColor = UiHelpers.AccentColor;
            this._lblHeader.Margin = System.Windows.Forms.Padding.Empty;

            this._contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._contentPanel.BackColor = UiHelpers.AppBackgroundColor;
            this._contentPanel.AutoScroll = true;
            this._contentPanel.Margin = System.Windows.Forms.Padding.Empty;

            this._menuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._menuPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._menuPanel.WrapContents = false;
            this._menuPanel.Padding = new System.Windows.Forms.Padding(8);
            this._menuPanel.BackColor = UiHelpers.SurfaceColor;
            this._menuPanel.AutoScroll = true;
            this._menuPanel.Margin = System.Windows.Forms.Padding.Empty;

            btnHocVien.Click += this.BtnHocVien_Click;
            btnLopHoc.Click += this.BtnLopHoc_Click;
            btnTaiLieu.Click += this.BtnTaiLieu_Click;
            btnBaiTap.Click += this.BtnBaiTap_Click;
            btnChamBai.Click += this.BtnChamBai_Click;
            btnDiemSo.Click += this.BtnDiemSo_Click;
            btnDiemDanh.Click += this.BtnDiemDanh_Click;
            btnDeThi.Click += this.BtnDeThi_Click;
            btnBaoCao.Click += this.BtnBaoCao_Click;
            btnTuVung.Click += this.BtnTuVung_Click;
            btnThongBao.Click += this.BtnThongBao_Click;
            btnHocPhi.Click += this.BtnHocPhi_Click;

            this._menuPanel.Controls.Add(btnHocVien);
            this._menuPanel.Controls.Add(btnLopHoc);
            this._menuPanel.Controls.Add(btnTaiLieu);
            this._menuPanel.Controls.Add(btnBaiTap);
            this._menuPanel.Controls.Add(btnChamBai);
            this._menuPanel.Controls.Add(btnDiemSo);
            this._menuPanel.Controls.Add(btnDiemDanh);
            this._menuPanel.Controls.Add(btnDeThi);
            this._menuPanel.Controls.Add(btnBaoCao);
            this._menuPanel.Controls.Add(btnTuVung);
            this._menuPanel.Controls.Add(btnThongBao);
            this._menuPanel.Controls.Add(btnHocPhi);

            body.Controls.Add(this._menuPanel, 0, 0);
            body.Controls.Add(this._contentPanel, 1, 0);
            shell.Controls.Add(this._lblHeader, 0, 0);
            shell.Controls.Add(body, 0, 1);
            this.Controls.Add(shell);
            this.Name = "FrmChinh";
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 760);

            this._menuPanel.ResumeLayout(false);
            body.ResumeLayout(false);
            shell.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private static System.Windows.Forms.Button MenuButton(string text)
        {
            System.Windows.Forms.Button button = UiHelpers.Button(text);
            button.Width = 205;
            button.Height = 38;
            button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 2);
            button.BackColor = UiHelpers.SurfaceColor;
            button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            return button;
        }
    }
}
