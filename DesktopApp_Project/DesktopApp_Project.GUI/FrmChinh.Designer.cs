using DesktopApp_Project.GUI.Shared.Themes;

namespace DesktopApp_Project.GUI
{
    partial class FrmChinh
    {
        private System.ComponentModel.IContainer components = null;

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
            this.pnlSideMenu = new System.Windows.Forms.Panel();
            this.pnlMenuItems = new System.Windows.Forms.Panel();
            this.btnPaymentDebug = new FontAwesome.Sharp.IconButton();
            this.btnThongBao = new FontAwesome.Sharp.IconButton();
            this.btnFlashcard = new FontAwesome.Sharp.IconButton();
            this.btnTuVung = new FontAwesome.Sharp.IconButton();
            this.btnTaiLieu = new FontAwesome.Sharp.IconButton();
            this.btnLopHoc = new FontAwesome.Sharp.IconButton();
            this.btnHocVien = new FontAwesome.Sharp.IconButton();
            this.btnHocPhi = new FontAwesome.Sharp.IconButton();
            this.btnDiemSo = new FontAwesome.Sharp.IconButton();
            this.btnDiemDanh = new FontAwesome.Sharp.IconButton();
            this.btnDeThi = new FontAwesome.Sharp.IconButton();
            this.btnChamBai = new FontAwesome.Sharp.IconButton();
            this.btnBaoCao = new FontAwesome.Sharp.IconButton();
            this.btnBaiTap = new FontAwesome.Sharp.IconButton();
            this.btnChinh = new FontAwesome.Sharp.IconButton();
            this.btnSetting = new FontAwesome.Sharp.IconButton();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.pnlTittleBar = new System.Windows.Forms.Panel();
            this.icoTittle = new FontAwesome.Sharp.IconPictureBox();
            this.lblTitleChildForm = new System.Windows.Forms.Label();
            this.pnlMovingForm = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlDesktop = new System.Windows.Forms.Panel();
            this.pnlSideMenu.SuspendLayout();
            this.pnlMenuItems.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.pnlTittleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icoTittle)).BeginInit();
            this.pnlMovingForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSideMenu
            // 
            this.pnlSideMenu.BackColor = new AppThemeAdapter().BackgroundDark;
            this.pnlSideMenu.Controls.Add(this.pnlMenuItems);
            this.pnlSideMenu.Controls.Add(this.btnSetting);
            this.pnlSideMenu.Controls.Add(this.pnlLogo);
            this.pnlSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideMenu.Location = new System.Drawing.Point(2, 2);
            this.pnlSideMenu.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSideMenu.Name = "pnlSideMenu";
            this.pnlSideMenu.Size = new System.Drawing.Size(240, 896);
            this.pnlSideMenu.TabIndex = 0;
            this.pnlSideMenu.AutoScroll = false;
            // 
            // pnlMenuItems
            // 
            this.pnlMenuItems.AutoScroll = true;
            this.pnlMenuItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.pnlMenuItems.Controls.Add(this.btnPaymentDebug);
            this.pnlMenuItems.Controls.Add(this.btnThongBao);
            this.pnlMenuItems.Controls.Add(this.btnFlashcard);
            this.pnlMenuItems.Controls.Add(this.btnTuVung);
            this.pnlMenuItems.Controls.Add(this.btnTaiLieu);
            this.pnlMenuItems.Controls.Add(this.btnLopHoc);
            this.pnlMenuItems.Controls.Add(this.btnHocVien);
            this.pnlMenuItems.Controls.Add(this.btnHocPhi);
            this.pnlMenuItems.Controls.Add(this.btnDiemSo);
            this.pnlMenuItems.Controls.Add(this.btnDiemDanh);
            this.pnlMenuItems.Controls.Add(this.btnDeThi);
            this.pnlMenuItems.Controls.Add(this.btnChamBai);
            this.pnlMenuItems.Controls.Add(this.btnBaoCao);
            this.pnlMenuItems.Controls.Add(this.btnBaiTap);
            this.pnlMenuItems.Controls.Add(this.btnChinh);
            this.pnlMenuItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenuItems.Location = new System.Drawing.Point(0, 100);
            this.pnlMenuItems.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMenuItems.Name = "pnlMenuItems";
            this.pnlMenuItems.Size = new System.Drawing.Size(240, 736);
            this.pnlMenuItems.TabIndex = 14;
            //
            // btnPaymentDebug
            //
            this.btnPaymentDebug.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPaymentDebug.FlatAppearance.BorderSize = 0;
            this.btnPaymentDebug.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaymentDebug.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnPaymentDebug.IconChar = FontAwesome.Sharp.IconChar.Wallet;
            this.btnPaymentDebug.IconColor = System.Drawing.Color.Gainsboro;
            this.btnPaymentDebug.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPaymentDebug.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPaymentDebug.Location = new System.Drawing.Point(0, 840);
            this.btnPaymentDebug.Margin = new System.Windows.Forms.Padding(2);
            this.btnPaymentDebug.Name = "btnPaymentDebug";
            this.btnPaymentDebug.Padding = new System.Windows.Forms.Padding(7, 0, 13, 0);
            this.btnPaymentDebug.Size = new System.Drawing.Size(223, 60);
            this.btnPaymentDebug.TabIndex = 15;
            this.btnPaymentDebug.Text = "Debug thanh toan";
            this.btnPaymentDebug.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPaymentDebug.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPaymentDebug.UseVisualStyleBackColor = true;
            this.btnPaymentDebug.Visible = false;
            this.btnPaymentDebug.Click += new System.EventHandler(this.btnPaymentDebug_Click);
            //
            // btnThongBao
            //
            this.btnThongBao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThongBao.FlatAppearance.BorderSize = 0;
            this.btnThongBao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongBao.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnThongBao.IconChar = FontAwesome.Sharp.IconChar.Bell;
            this.btnThongBao.IconColor = System.Drawing.Color.Gainsboro;
            this.btnThongBao.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThongBao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongBao.Location = new System.Drawing.Point(0, 780);
            this.btnThongBao.Margin = new System.Windows.Forms.Padding(2);
            this.btnThongBao.Name = "btnThongBao";
            this.btnThongBao.Padding = new System.Windows.Forms.Padding(7, 0, 13, 0);
            this.btnThongBao.Size = new System.Drawing.Size(223, 60);
            this.btnThongBao.TabIndex = 12;
            this.btnThongBao.Text = "Thông Báo";
            this.btnThongBao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongBao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThongBao.UseVisualStyleBackColor = true;
            this.btnThongBao.Click += new System.EventHandler(this.btnThongBao_Click);
            //
            // btnFlashcard
            //
            this.btnFlashcard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFlashcard.FlatAppearance.BorderSize = 0;
            this.btnFlashcard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlashcard.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnFlashcard.IconChar = FontAwesome.Sharp.IconChar.Wpforms;
            this.btnFlashcard.IconColor = System.Drawing.Color.Gainsboro;
            this.btnFlashcard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFlashcard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFlashcard.Location = new System.Drawing.Point(0, 720);
            this.btnFlashcard.Margin = new System.Windows.Forms.Padding(2);
            this.btnFlashcard.Name = "btnFlashcard";
            this.btnFlashcard.Padding = new System.Windows.Forms.Padding(7, 0, 13, 0);
            this.btnFlashcard.Size = new System.Drawing.Size(223, 60);
            this.btnFlashcard.TabIndex = 14;
            this.btnFlashcard.Text = "Flashcard";
            this.btnFlashcard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFlashcard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFlashcard.UseVisualStyleBackColor = true;
            this.btnFlashcard.Click += new System.EventHandler(this.btnFlashcard_Click);
            //
            // btnTuVung
            //
            this.btnTuVung.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTuVung.FlatAppearance.BorderSize = 0;
            this.btnTuVung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTuVung.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnTuVung.IconChar = FontAwesome.Sharp.IconChar.Wpforms;
            this.btnTuVung.IconColor = System.Drawing.Color.Gainsboro;
            this.btnTuVung.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTuVung.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTuVung.Location = new System.Drawing.Point(0, 660);
            this.btnTuVung.Margin = new System.Windows.Forms.Padding(2);
            this.btnTuVung.Name = "btnTuVung";
            this.btnTuVung.Padding = new System.Windows.Forms.Padding(7, 0, 13, 0);
            this.btnTuVung.Size = new System.Drawing.Size(223, 60);
            this.btnTuVung.TabIndex = 11;
            this.btnTuVung.Text = "Từ Vựng";
            this.btnTuVung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTuVung.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTuVung.UseVisualStyleBackColor = true;
            this.btnTuVung.Click += new System.EventHandler(this.btnTuVung_Click);
            // 
            // btnTaiLieu
            // 
            this.btnTaiLieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTaiLieu.FlatAppearance.BorderSize = 0;
            this.btnTaiLieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiLieu.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnTaiLieu.IconChar = FontAwesome.Sharp.IconChar.BookOpen;
            this.btnTaiLieu.IconColor = System.Drawing.Color.Gainsboro;
            this.btnTaiLieu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTaiLieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaiLieu.Location = new System.Drawing.Point(0, 600);
            this.btnTaiLieu.Margin = new System.Windows.Forms.Padding(2);
            this.btnTaiLieu.Name = "btnTaiLieu";
            this.btnTaiLieu.Padding = new System.Windows.Forms.Padding(7, 0, 13, 0);
            this.btnTaiLieu.Size = new System.Drawing.Size(223, 60);
            this.btnTaiLieu.TabIndex = 10;
            this.btnTaiLieu.Text = "Tài Liệu";
            this.btnTaiLieu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaiLieu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTaiLieu.UseVisualStyleBackColor = true;
            this.btnTaiLieu.Click += new System.EventHandler(this.btnTaiLieu_Click);
            // 
            // btnLopHoc
            // 
            this.btnLopHoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLopHoc.FlatAppearance.BorderSize = 0;
            this.btnLopHoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLopHoc.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnLopHoc.IconChar = FontAwesome.Sharp.IconChar.School;
            this.btnLopHoc.IconColor = System.Drawing.Color.Gainsboro;
            this.btnLopHoc.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLopHoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLopHoc.Location = new System.Drawing.Point(0, 540);
            this.btnLopHoc.Margin = new System.Windows.Forms.Padding(2);
            this.btnLopHoc.Name = "btnLopHoc";
            this.btnLopHoc.Padding = new System.Windows.Forms.Padding(7, 0, 13, 0);
            this.btnLopHoc.Size = new System.Drawing.Size(223, 60);
            this.btnLopHoc.TabIndex = 9;
            this.btnLopHoc.Text = "Lớp Học";
            this.btnLopHoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLopHoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLopHoc.UseVisualStyleBackColor = true;
            this.btnLopHoc.Click += new System.EventHandler(this.btnLopHoc_Click);
            // 
            // btnHocVien
            // 
            this.btnHocVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHocVien.FlatAppearance.BorderSize = 0;
            this.btnHocVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHocVien.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnHocVien.IconChar = FontAwesome.Sharp.IconChar.UserGraduate;
            this.btnHocVien.IconColor = System.Drawing.Color.Gainsboro;
            this.btnHocVien.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHocVien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocVien.Location = new System.Drawing.Point(0, 480);
            this.btnHocVien.Margin = new System.Windows.Forms.Padding(2);
            this.btnHocVien.Name = "btnHocVien";
            this.btnHocVien.Padding = new System.Windows.Forms.Padding(7, 0, 13, 0);
            this.btnHocVien.Size = new System.Drawing.Size(223, 60);
            this.btnHocVien.TabIndex = 8;
            this.btnHocVien.Text = "Học Viên";
            this.btnHocVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocVien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHocVien.UseVisualStyleBackColor = true;
            this.btnHocVien.Click += new System.EventHandler(this.btnHocVien_Click);
            // 
            // btnHocPhi
            // 
            this.btnHocPhi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHocPhi.FlatAppearance.BorderSize = 0;
            this.btnHocPhi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHocPhi.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnHocPhi.IconChar = FontAwesome.Sharp.IconChar.Wallet;
            this.btnHocPhi.IconColor = System.Drawing.Color.Gainsboro;
            this.btnHocPhi.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHocPhi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocPhi.Location = new System.Drawing.Point(0, 420);
            this.btnHocPhi.Margin = new System.Windows.Forms.Padding(2);
            this.btnHocPhi.Name = "btnHocPhi";
            this.btnHocPhi.Padding = new System.Windows.Forms.Padding(7, 0, 13, 0);
            this.btnHocPhi.Size = new System.Drawing.Size(223, 60);
            this.btnHocPhi.TabIndex = 7;
            this.btnHocPhi.Text = "Học Phí";
            this.btnHocPhi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocPhi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHocPhi.UseVisualStyleBackColor = true;
            this.btnHocPhi.Click += new System.EventHandler(this.btnHocPhi_Click);
            // 
            // btnDiemSo
            // 
            this.btnDiemSo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDiemSo.FlatAppearance.BorderSize = 0;
            this.btnDiemSo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiemSo.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDiemSo.IconChar = FontAwesome.Sharp.IconChar.A;
            this.btnDiemSo.IconColor = System.Drawing.Color.Gainsboro;
            this.btnDiemSo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDiemSo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiemSo.Location = new System.Drawing.Point(0, 360);
            this.btnDiemSo.Margin = new System.Windows.Forms.Padding(2);
            this.btnDiemSo.Name = "btnDiemSo";
            this.btnDiemSo.Padding = new System.Windows.Forms.Padding(7, 0, 13, 0);
            this.btnDiemSo.Size = new System.Drawing.Size(223, 60);
            this.btnDiemSo.TabIndex = 6;
            this.btnDiemSo.Text = "Điểm Số";
            this.btnDiemSo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiemSo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDiemSo.UseVisualStyleBackColor = true;
            this.btnDiemSo.Click += new System.EventHandler(this.btnDiemSo_Click);
            // 
            // btnDiemDanh
            // 
            this.btnDiemDanh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDiemDanh.FlatAppearance.BorderSize = 0;
            this.btnDiemDanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiemDanh.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDiemDanh.IconChar = FontAwesome.Sharp.IconChar.CalendarCheck;
            this.btnDiemDanh.IconColor = System.Drawing.Color.Gainsboro;
            this.btnDiemDanh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDiemDanh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiemDanh.Location = new System.Drawing.Point(0, 300);
            this.btnDiemDanh.Margin = new System.Windows.Forms.Padding(2);
            this.btnDiemDanh.Name = "btnDiemDanh";
            this.btnDiemDanh.Padding = new System.Windows.Forms.Padding(7, 0, 13, 0);
            this.btnDiemDanh.Size = new System.Drawing.Size(223, 60);
            this.btnDiemDanh.TabIndex = 5;
            this.btnDiemDanh.Text = "Điểm Danh";
            this.btnDiemDanh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiemDanh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDiemDanh.UseVisualStyleBackColor = true;
            this.btnDiemDanh.Click += new System.EventHandler(this.btnDiemDanh_Click);
            // 
            // btnDeThi
            // 
            this.btnDeThi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDeThi.FlatAppearance.BorderSize = 0;
            this.btnDeThi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeThi.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDeThi.IconChar = FontAwesome.Sharp.IconChar.Clipboard;
            this.btnDeThi.IconColor = System.Drawing.Color.Gainsboro;
            this.btnDeThi.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDeThi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeThi.Location = new System.Drawing.Point(0, 240);
            this.btnDeThi.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeThi.Name = "btnDeThi";
            this.btnDeThi.Padding = new System.Windows.Forms.Padding(7, 0, 13, 0);
            this.btnDeThi.Size = new System.Drawing.Size(223, 60);
            this.btnDeThi.TabIndex = 4;
            this.btnDeThi.Text = "Đề Thi";
            this.btnDeThi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeThi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeThi.UseVisualStyleBackColor = true;
            this.btnDeThi.Click += new System.EventHandler(this.btnDeThi_Click);
            // 
            // btnChamBai
            // 
            this.btnChamBai.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChamBai.FlatAppearance.BorderSize = 0;
            this.btnChamBai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChamBai.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnChamBai.IconChar = FontAwesome.Sharp.IconChar.PenFancy;
            this.btnChamBai.IconColor = System.Drawing.Color.Gainsboro;
            this.btnChamBai.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnChamBai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChamBai.Location = new System.Drawing.Point(0, 180);
            this.btnChamBai.Margin = new System.Windows.Forms.Padding(2);
            this.btnChamBai.Name = "btnChamBai";
            this.btnChamBai.Padding = new System.Windows.Forms.Padding(7, 0, 13, 0);
            this.btnChamBai.Size = new System.Drawing.Size(223, 60);
            this.btnChamBai.TabIndex = 3;
            this.btnChamBai.Text = "Chấm Bài";
            this.btnChamBai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChamBai.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChamBai.UseVisualStyleBackColor = true;
            this.btnChamBai.Click += new System.EventHandler(this.btnChamBai_Click);
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBaoCao.FlatAppearance.BorderSize = 0;
            this.btnBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaoCao.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBaoCao.IconChar = FontAwesome.Sharp.IconChar.Envelope;
            this.btnBaoCao.IconColor = System.Drawing.Color.Gainsboro;
            this.btnBaoCao.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBaoCao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCao.Location = new System.Drawing.Point(0, 120);
            this.btnBaoCao.Margin = new System.Windows.Forms.Padding(2);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Padding = new System.Windows.Forms.Padding(7, 0, 13, 0);
            this.btnBaoCao.Size = new System.Drawing.Size(223, 60);
            this.btnBaoCao.TabIndex = 2;
            this.btnBaoCao.Text = "Báo Cáo";
            this.btnBaoCao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBaoCao.UseVisualStyleBackColor = true;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // btnBaiTap
            // 
            this.btnBaiTap.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBaiTap.FlatAppearance.BorderSize = 0;
            this.btnBaiTap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaiTap.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBaiTap.IconChar = FontAwesome.Sharp.IconChar.Book;
            this.btnBaiTap.IconColor = System.Drawing.Color.Gainsboro;
            this.btnBaiTap.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBaiTap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaiTap.Location = new System.Drawing.Point(0, 60);
            this.btnBaiTap.Margin = new System.Windows.Forms.Padding(2);
            this.btnBaiTap.Name = "btnBaiTap";
            this.btnBaiTap.Padding = new System.Windows.Forms.Padding(7, 0, 13, 0);
            this.btnBaiTap.Size = new System.Drawing.Size(223, 60);
            this.btnBaiTap.TabIndex = 1;
            this.btnBaiTap.Text = "Bài Tập";
            this.btnBaiTap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaiTap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBaiTap.UseVisualStyleBackColor = true;
            this.btnBaiTap.Click += new System.EventHandler(this.btnBaiTap_Click);
            // 
            // btnChinh
            // 
            this.btnChinh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChinh.FlatAppearance.BorderSize = 0;
            this.btnChinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChinh.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnChinh.IconChar = FontAwesome.Sharp.IconChar.Kaaba;
            this.btnChinh.IconColor = System.Drawing.Color.Gainsboro;
            this.btnChinh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnChinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChinh.Location = new System.Drawing.Point(0, 0);
            this.btnChinh.Margin = new System.Windows.Forms.Padding(2);
            this.btnChinh.Name = "btnChinh";
            this.btnChinh.Padding = new System.Windows.Forms.Padding(7, 0, 13, 0);
            this.btnChinh.Size = new System.Drawing.Size(223, 60);
            this.btnChinh.TabIndex = 0;
            this.btnChinh.Text = "Trang chủ";
            this.btnChinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChinh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChinh.UseVisualStyleBackColor = true;
            this.btnChinh.Click += new System.EventHandler(this.btnChinh_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSetting.FlatAppearance.BorderSize = 0;
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSetting.IconChar = FontAwesome.Sharp.IconChar.List;
            this.btnSetting.IconColor = System.Drawing.Color.Gainsboro;
            this.btnSetting.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetting.Location = new System.Drawing.Point(0, 836);
            this.btnSetting.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Padding = new System.Windows.Forms.Padding(7, 0, 13, 0);
            this.btnSetting.Size = new System.Drawing.Size(240, 60);
            this.btnSetting.TabIndex = 13;
            this.btnSetting.Text = "Cài Đặt";
            this.btnSetting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // pnlLogo
            // 
            this.pnlLogo.Controls.Add(this.lblLogo);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Margin = new System.Windows.Forms.Padding(2);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(240, 100);
            this.pnlLogo.TabIndex = 0;
            // 
            // lblLogo
            // 
            this.lblLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogo.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblLogo.Location = new System.Drawing.Point(0, 0);
            this.lblLogo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(240, 100);
            this.lblLogo.TabIndex = 2;
            this.lblLogo.Text = "QUẢN LÝ LỚP IELTS";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLogo.Click += new System.EventHandler(this.lblLogo_Click);
            // 
            // pnlTittleBar
            // 
            this.pnlTittleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.pnlTittleBar.Controls.Add(this.icoTittle);
            this.pnlTittleBar.Controls.Add(this.lblTitleChildForm);
            this.pnlTittleBar.Controls.Add(this.pnlMovingForm);
            this.pnlTittleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTittleBar.Location = new System.Drawing.Point(242, 2);
            this.pnlTittleBar.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTittleBar.Name = "pnlTittleBar";
            this.pnlTittleBar.Size = new System.Drawing.Size(1122, 100);
            this.pnlTittleBar.TabIndex = 1;
            // 
            // icoTittle
            // 
            this.icoTittle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.icoTittle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.icoTittle.ForeColor = System.Drawing.Color.Gainsboro;
            this.icoTittle.IconChar = FontAwesome.Sharp.IconChar.Kaaba;
            this.icoTittle.IconColor = System.Drawing.Color.Gainsboro;
            this.icoTittle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icoTittle.Location = new System.Drawing.Point(40, 46);
            this.icoTittle.Margin = new System.Windows.Forms.Padding(2);
            this.icoTittle.Name = "icoTittle";
            this.icoTittle.Size = new System.Drawing.Size(32, 32);
            this.icoTittle.TabIndex = 2;
            this.icoTittle.TabStop = false;
            // 
            // lblTitleChildForm
            // 
            this.lblTitleChildForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTitleChildForm.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleChildForm.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTitleChildForm.Location = new System.Drawing.Point(76, 28);
            this.lblTitleChildForm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitleChildForm.Name = "lblTitleChildForm";
            this.lblTitleChildForm.Size = new System.Drawing.Size(280, 68);
            this.lblTitleChildForm.TabIndex = 1;
            this.lblTitleChildForm.Text = "Trang Chủ";
            this.lblTitleChildForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMovingForm
            // 
            this.pnlMovingForm.Controls.Add(this.btnMinimize);
            this.pnlMovingForm.Controls.Add(this.btnMaximize);
            this.pnlMovingForm.Controls.Add(this.btnClose);
            this.pnlMovingForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMovingForm.Location = new System.Drawing.Point(0, 0);
            this.pnlMovingForm.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMovingForm.Name = "pnlMovingForm";
            this.pnlMovingForm.Size = new System.Drawing.Size(1122, 25);
            this.pnlMovingForm.TabIndex = 0;
            this.pnlMovingForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMovingForm_MouseDown);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMinimize.Location = new System.Drawing.Point(1041, 0);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(2);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(27, 25);
            this.btnMinimize.TabIndex = 2;
            this.btnMinimize.Text = "—";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaximize.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMaximize.Location = new System.Drawing.Point(1068, 0);
            this.btnMaximize.Margin = new System.Windows.Forms.Padding(2);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(27, 25);
            this.btnMaximize.TabIndex = 1;
            this.btnMaximize.Text = "◻";
            this.btnMaximize.UseVisualStyleBackColor = true;
            this.btnMaximize.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnClose.Location = new System.Drawing.Point(1095, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(27, 25);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlDesktop
            // 
            this.pnlDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.pnlDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDesktop.Location = new System.Drawing.Point(242, 102);
            this.pnlDesktop.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDesktop.Name = "pnlDesktop";
            this.pnlDesktop.Size = new System.Drawing.Size(1122, 796);
            this.pnlDesktop.TabIndex = 2;
            // 
            // FrmChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1366, 900);
            this.Controls.Add(this.pnlDesktop);
            this.Controls.Add(this.pnlTittleBar);
            this.Controls.Add(this.pnlSideMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmChinh";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "FrmChinh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlSideMenu.ResumeLayout(false);
            this.pnlMenuItems.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.pnlTittleBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icoTittle)).EndInit();
            this.pnlMovingForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSideMenu;
        private System.Windows.Forms.Panel pnlMenuItems;
        private System.Windows.Forms.Panel pnlTittleBar;
        private System.Windows.Forms.Panel pnlMovingForm;
        private System.Windows.Forms.Panel pnlLogo;
        private FontAwesome.Sharp.IconButton btnChinh;
        private FontAwesome.Sharp.IconButton btnHocVien;
        private FontAwesome.Sharp.IconButton btnHocPhi;
        private FontAwesome.Sharp.IconButton btnDiemSo;
        private FontAwesome.Sharp.IconButton btnDiemDanh;
        private FontAwesome.Sharp.IconButton btnDeThi;
        private FontAwesome.Sharp.IconButton btnChamBai;
        private FontAwesome.Sharp.IconButton btnBaoCao;
        private FontAwesome.Sharp.IconButton btnBaiTap;
        private FontAwesome.Sharp.IconButton btnThongBao;
        private FontAwesome.Sharp.IconButton btnFlashcard;
        private FontAwesome.Sharp.IconButton btnPaymentDebug;
        private FontAwesome.Sharp.IconButton btnTuVung;
        private FontAwesome.Sharp.IconButton btnTaiLieu;
        private FontAwesome.Sharp.IconButton btnLopHoc;
        private System.Windows.Forms.Panel pnlDesktop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnMaximize;
        private System.Windows.Forms.Label lblTitleChildForm;
        private System.Windows.Forms.Label lblLogo;
        private FontAwesome.Sharp.IconPictureBox icoTittle;
        private FontAwesome.Sharp.IconButton btnSetting;
    }
}
