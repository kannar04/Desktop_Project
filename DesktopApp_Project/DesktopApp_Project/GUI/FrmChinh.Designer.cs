namespace DesktopApp_Project.GUI
{
    partial class FrmChinh
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel _shell;
        private System.Windows.Forms.TableLayoutPanel _body;
        private System.Windows.Forms.Label _lblHeader;
        private System.Windows.Forms.Panel _contentPanel;
        private System.Windows.Forms.FlowLayoutPanel _menuPanel;
        private System.Windows.Forms.Button btnHocVien;
        private System.Windows.Forms.Button btnLopHoc;
        private System.Windows.Forms.Button btnTaiLieu;
        private System.Windows.Forms.Button btnBaiTap;
        private System.Windows.Forms.Button btnChamBai;
        private System.Windows.Forms.Button btnDiemSo;
        private System.Windows.Forms.Button btnDiemDanh;
        private System.Windows.Forms.Button btnDeThi;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Button btnTuVung;
        private System.Windows.Forms.Button btnThongBao;
        private System.Windows.Forms.Button btnHocPhi;

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
            this._shell = new System.Windows.Forms.TableLayoutPanel();
            this._body = new System.Windows.Forms.TableLayoutPanel();
            this._lblHeader = new System.Windows.Forms.Label();
            this._contentPanel = new System.Windows.Forms.Panel();
            this._menuPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnHocVien = new System.Windows.Forms.Button();
            this.btnLopHoc = new System.Windows.Forms.Button();
            this.btnTaiLieu = new System.Windows.Forms.Button();
            this.btnBaiTap = new System.Windows.Forms.Button();
            this.btnChamBai = new System.Windows.Forms.Button();
            this.btnDiemSo = new System.Windows.Forms.Button();
            this.btnDiemDanh = new System.Windows.Forms.Button();
            this.btnDeThi = new System.Windows.Forms.Button();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.btnTuVung = new System.Windows.Forms.Button();
            this.btnThongBao = new System.Windows.Forms.Button();
            this.btnHocPhi = new System.Windows.Forms.Button();
            this._shell.SuspendLayout();
            this._body.SuspendLayout();
            this._menuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _shell
            // 
            this._shell.BackColor = System.Drawing.Color.FromArgb(246, 248, 251);
            this._shell.ColumnCount = 1;
            this._shell.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._shell.Controls.Add(this._lblHeader, 0, 0);
            this._shell.Controls.Add(this._body, 0, 1);
            this._shell.Dock = System.Windows.Forms.DockStyle.Fill;
            this._shell.Location = new System.Drawing.Point(0, 0);
            this._shell.Margin = new System.Windows.Forms.Padding(0);
            this._shell.Name = "_shell";
            this._shell.RowCount = 2;
            this._shell.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this._shell.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._shell.Size = new System.Drawing.Size(1200, 760);
            this._shell.TabIndex = 0;
            // 
            // _body
            // 
            this._body.BackColor = System.Drawing.Color.FromArgb(246, 248, 251);
            this._body.ColumnCount = 2;
            this._body.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this._body.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._body.Controls.Add(this._menuPanel, 0, 0);
            this._body.Controls.Add(this._contentPanel, 1, 0);
            this._body.Dock = System.Windows.Forms.DockStyle.Fill;
            this._body.Location = new System.Drawing.Point(0, 44);
            this._body.Margin = new System.Windows.Forms.Padding(0);
            this._body.Name = "_body";
            this._body.RowCount = 1;
            this._body.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._body.Size = new System.Drawing.Size(1200, 716);
            this._body.TabIndex = 1;
            // 
            // _lblHeader
            // 
            this._lblHeader.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this._lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblHeader.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this._lblHeader.ForeColor = System.Drawing.Color.White;
            this._lblHeader.Location = new System.Drawing.Point(0, 0);
            this._lblHeader.Margin = new System.Windows.Forms.Padding(0);
            this._lblHeader.Name = "_lblHeader";
            this._lblHeader.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this._lblHeader.Size = new System.Drawing.Size(1200, 44);
            this._lblHeader.TabIndex = 0;
            this._lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _contentPanel
            // 
            this._contentPanel.AutoScroll = true;
            this._contentPanel.BackColor = System.Drawing.Color.FromArgb(246, 248, 251);
            this._contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._contentPanel.Location = new System.Drawing.Point(230, 0);
            this._contentPanel.Margin = new System.Windows.Forms.Padding(0);
            this._contentPanel.Name = "_contentPanel";
            this._contentPanel.Size = new System.Drawing.Size(970, 716);
            this._contentPanel.TabIndex = 1;
            // 
            // _menuPanel
            // 
            this._menuPanel.AutoScroll = true;
            this._menuPanel.BackColor = System.Drawing.Color.White;
            this._menuPanel.Controls.Add(this.btnHocVien);
            this._menuPanel.Controls.Add(this.btnLopHoc);
            this._menuPanel.Controls.Add(this.btnTaiLieu);
            this._menuPanel.Controls.Add(this.btnBaiTap);
            this._menuPanel.Controls.Add(this.btnChamBai);
            this._menuPanel.Controls.Add(this.btnDiemSo);
            this._menuPanel.Controls.Add(this.btnDiemDanh);
            this._menuPanel.Controls.Add(this.btnDeThi);
            this._menuPanel.Controls.Add(this.btnBaoCao);
            this._menuPanel.Controls.Add(this.btnTuVung);
            this._menuPanel.Controls.Add(this.btnThongBao);
            this._menuPanel.Controls.Add(this.btnHocPhi);
            this._menuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._menuPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._menuPanel.Location = new System.Drawing.Point(0, 0);
            this._menuPanel.Margin = new System.Windows.Forms.Padding(0);
            this._menuPanel.Name = "_menuPanel";
            this._menuPanel.Padding = new System.Windows.Forms.Padding(8);
            this._menuPanel.Size = new System.Drawing.Size(230, 716);
            this._menuPanel.TabIndex = 0;
            this._menuPanel.WrapContents = false;
            // 
            // menu buttons
            // 
            this.btnHocVien.Text = "Hồ sơ học viên";
            this.btnHocVien.Click += new System.EventHandler(this.BtnHocVien_Click);
            this.btnLopHoc.Text = "Lớp học";
            this.btnLopHoc.Click += new System.EventHandler(this.BtnLopHoc_Click);
            this.btnTaiLieu.Text = "Tài liệu";
            this.btnTaiLieu.Click += new System.EventHandler(this.BtnTaiLieu_Click);
            this.btnBaiTap.Text = "Bài tập";
            this.btnBaiTap.Click += new System.EventHandler(this.BtnBaiTap_Click);
            this.btnChamBai.Text = "Chấm bài";
            this.btnChamBai.Click += new System.EventHandler(this.BtnChamBai_Click);
            this.btnDiemSo.Text = "Điểm số";
            this.btnDiemSo.Click += new System.EventHandler(this.BtnDiemSo_Click);
            this.btnDiemDanh.Text = "Điểm danh";
            this.btnDiemDanh.Click += new System.EventHandler(this.BtnDiemDanh_Click);
            this.btnDeThi.Text = "Đề thi";
            this.btnDeThi.Click += new System.EventHandler(this.BtnDeThi_Click);
            this.btnBaoCao.Text = "Báo cáo";
            this.btnBaoCao.Click += new System.EventHandler(this.BtnBaoCao_Click);
            this.btnTuVung.Text = "Từ vựng";
            this.btnTuVung.Click += new System.EventHandler(this.BtnTuVung_Click);
            this.btnThongBao.Text = "Thông báo";
            this.btnThongBao.Click += new System.EventHandler(this.BtnThongBao_Click);
            this.btnHocPhi.Text = "Học phí";
            this.btnHocPhi.Click += new System.EventHandler(this.BtnHocPhi_Click);
            this.btnHocVien.AutoEllipsis = true;
            this.btnHocVien.BackColor = System.Drawing.Color.White;
            this.btnHocVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHocVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHocVien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHocVien.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnHocVien.Height = 38;
            this.btnHocVien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 2);
            this.btnHocVien.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnHocVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocVien.Width = 205;
            this.btnLopHoc.AutoEllipsis = true;
            this.btnLopHoc.BackColor = System.Drawing.Color.White;
            this.btnLopHoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLopHoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLopHoc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLopHoc.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnLopHoc.Height = 38;
            this.btnLopHoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 2);
            this.btnLopHoc.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnLopHoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLopHoc.Width = 205;
            this.btnTaiLieu.AutoEllipsis = true;
            this.btnTaiLieu.BackColor = System.Drawing.Color.White;
            this.btnTaiLieu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaiLieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiLieu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTaiLieu.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnTaiLieu.Height = 38;
            this.btnTaiLieu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 2);
            this.btnTaiLieu.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnTaiLieu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaiLieu.Width = 205;
            this.btnBaiTap.AutoEllipsis = true;
            this.btnBaiTap.BackColor = System.Drawing.Color.White;
            this.btnBaiTap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaiTap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaiTap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBaiTap.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnBaiTap.Height = 38;
            this.btnBaiTap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 2);
            this.btnBaiTap.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnBaiTap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaiTap.Width = 205;
            this.btnChamBai.AutoEllipsis = true;
            this.btnChamBai.BackColor = System.Drawing.Color.White;
            this.btnChamBai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChamBai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChamBai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnChamBai.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnChamBai.Height = 38;
            this.btnChamBai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 2);
            this.btnChamBai.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnChamBai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChamBai.Width = 205;
            this.btnDiemSo.AutoEllipsis = true;
            this.btnDiemSo.BackColor = System.Drawing.Color.White;
            this.btnDiemSo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDiemSo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiemSo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDiemSo.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnDiemSo.Height = 38;
            this.btnDiemSo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 2);
            this.btnDiemSo.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnDiemSo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiemSo.Width = 205;
            this.btnDiemDanh.AutoEllipsis = true;
            this.btnDiemDanh.BackColor = System.Drawing.Color.White;
            this.btnDiemDanh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDiemDanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiemDanh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDiemDanh.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnDiemDanh.Height = 38;
            this.btnDiemDanh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 2);
            this.btnDiemDanh.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnDiemDanh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiemDanh.Width = 205;
            this.btnDeThi.AutoEllipsis = true;
            this.btnDeThi.BackColor = System.Drawing.Color.White;
            this.btnDeThi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeThi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeThi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDeThi.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnDeThi.Height = 38;
            this.btnDeThi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 2);
            this.btnDeThi.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnDeThi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeThi.Width = 205;
            this.btnBaoCao.AutoEllipsis = true;
            this.btnBaoCao.BackColor = System.Drawing.Color.White;
            this.btnBaoCao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaoCao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBaoCao.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnBaoCao.Height = 38;
            this.btnBaoCao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 2);
            this.btnBaoCao.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnBaoCao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCao.Width = 205;
            this.btnTuVung.AutoEllipsis = true;
            this.btnTuVung.BackColor = System.Drawing.Color.White;
            this.btnTuVung.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTuVung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTuVung.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTuVung.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnTuVung.Height = 38;
            this.btnTuVung.Margin = new System.Windows.Forms.Padding(4, 4, 4, 2);
            this.btnTuVung.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnTuVung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTuVung.Width = 205;
            this.btnThongBao.AutoEllipsis = true;
            this.btnThongBao.BackColor = System.Drawing.Color.White;
            this.btnThongBao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThongBao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongBao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThongBao.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnThongBao.Height = 38;
            this.btnThongBao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 2);
            this.btnThongBao.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnThongBao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongBao.Width = 205;
            this.btnHocPhi.AutoEllipsis = true;
            this.btnHocPhi.BackColor = System.Drawing.Color.White;
            this.btnHocPhi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHocPhi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHocPhi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHocPhi.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnHocPhi.Height = 38;
            this.btnHocPhi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 2);
            this.btnHocPhi.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnHocPhi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocPhi.Width = 205;
            // 
            // FrmChinh
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 760);
            this.Controls.Add(this._shell);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1050, 700);
            this.Name = "FrmChinh";
            this.Text = "Quản lý lớp IELTS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._menuPanel.ResumeLayout(false);
            this._body.ResumeLayout(false);
            this._shell.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}