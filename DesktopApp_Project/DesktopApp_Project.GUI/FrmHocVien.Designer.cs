namespace DesktopApp_Project.GUI
{
    partial class FrmHocVien
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label _lblTitle;
        private System.Windows.Forms.Label _lblDesigner8;
        private System.Windows.Forms.Label _lblDesigner7;
        private System.Windows.Forms.Label _lblDesigner6;
        private System.Windows.Forms.Label _lblDesigner5;
        private System.Windows.Forms.Label _lblDesigner4;
        private System.Windows.Forms.Label _lblDesigner3;
        private System.Windows.Forms.Label _lblDesigner2;
        private System.Windows.Forms.Label _lblDesigner1;
        private System.Windows.Forms.TableLayoutPanel root;
        private System.Windows.Forms.FlowLayoutPanel search;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TableLayoutPanel form;
        private System.Windows.Forms.FlowLayoutPanel buttons;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.TextBox _txtTim;
        private System.Windows.Forms.TextBox _txtHoTen;
        private System.Windows.Forms.TextBox _txtSdt;
        private System.Windows.Forms.TextBox _txtEmail;
        private System.Windows.Forms.TextBox _txtTrinhDo;
        private System.Windows.Forms.TextBox _txtTaiKhoan;
        private System.Windows.Forms.TextBox _txtMatKhau;
        private System.Windows.Forms.DateTimePicker _dtNgaySinh;
        private System.Windows.Forms.Label _lblLienHeFilter;
        private System.Windows.Forms.TextBox _txtLienHe;
        private System.Windows.Forms.Label _lblLopFilter;
        private System.Windows.Forms.ComboBox _cboLopFilter;
        private System.Windows.Forms.Label _lblTrangThaiFilter;
        private System.Windows.Forms.ComboBox _cboTrangThaiFilter;
        private System.Windows.Forms.Label _lblLop;
        private System.Windows.Forms.ComboBox _cboLop;

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
            this._lblTitle = new System.Windows.Forms.Label();
            this._lblDesigner8 = new System.Windows.Forms.Label();
            this._lblDesigner7 = new System.Windows.Forms.Label();
            this._lblDesigner6 = new System.Windows.Forms.Label();
            this._lblDesigner5 = new System.Windows.Forms.Label();
            this._lblDesigner4 = new System.Windows.Forms.Label();
            this._lblDesigner3 = new System.Windows.Forms.Label();
            this._lblDesigner2 = new System.Windows.Forms.Label();
            this._lblDesigner1 = new System.Windows.Forms.Label();
            this._grid = new System.Windows.Forms.DataGridView();
            this._txtTim = new System.Windows.Forms.TextBox();
            this._txtHoTen = new System.Windows.Forms.TextBox();
            this._txtSdt = new System.Windows.Forms.TextBox();
            this._txtEmail = new System.Windows.Forms.TextBox();
            this._txtTrinhDo = new System.Windows.Forms.TextBox();
            this._txtTaiKhoan = new System.Windows.Forms.TextBox();
            this._txtMatKhau = new System.Windows.Forms.TextBox();
            this._dtNgaySinh = new System.Windows.Forms.DateTimePicker();
            this._lblLienHeFilter = new System.Windows.Forms.Label();
            this._txtLienHe = new System.Windows.Forms.TextBox();
            this._lblLopFilter = new System.Windows.Forms.Label();
            this._cboLopFilter = new System.Windows.Forms.ComboBox();
            this._lblTrangThaiFilter = new System.Windows.Forms.Label();
            this._cboTrangThaiFilter = new System.Windows.Forms.ComboBox();
            this._lblLop = new System.Windows.Forms.Label();
            this._cboLop = new System.Windows.Forms.ComboBox();
            this.root = new System.Windows.Forms.TableLayoutPanel();
            this.search = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTim = new System.Windows.Forms.Button();
            this.form = new System.Windows.Forms.TableLayoutPanel();
            this.buttons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.root.SuspendLayout();
            this.search.SuspendLayout();
            this.form.SuspendLayout();
            this.buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // _lblTitle
            // 
            this._lblTitle.AutoEllipsis = true;
            this._lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this._lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this._lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._lblTitle.Location = new System.Drawing.Point(0, 0);
            this._lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this._lblTitle.Name = "_lblTitle";
            this._lblTitle.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this._lblTitle.Size = new System.Drawing.Size(1100, 52);
            this._lblTitle.TabIndex = 0;
            this._lblTitle.Text = "Quản lý hồ sơ học viên";
            this._lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblDesigner8
            // 
            this._lblDesigner8.AutoSize = true;
            this._lblDesigner8.Location = new System.Drawing.Point(15, 103);
            this._lblDesigner8.Name = "_lblDesigner8";
            this._lblDesigner8.Size = new System.Drawing.Size(52, 13);
            this._lblDesigner8.TabIndex = 12;
            this._lblDesigner8.Text = "Mật khẩu";
            // 
            // _lblDesigner7
            // 
            this._lblDesigner7.AutoSize = true;
            this._lblDesigner7.Location = new System.Drawing.Point(570, 72);
            this._lblDesigner7.Name = "_lblDesigner7";
            this._lblDesigner7.Size = new System.Drawing.Size(55, 13);
            this._lblDesigner7.TabIndex = 10;
            this._lblDesigner7.Text = "Tài khoản";
            // 
            // _lblDesigner6
            // 
            this._lblDesigner6.AutoSize = true;
            this._lblDesigner6.Location = new System.Drawing.Point(15, 72);
            this._lblDesigner6.Name = "_lblDesigner6";
            this._lblDesigner6.Size = new System.Drawing.Size(90, 13);
            this._lblDesigner6.TabIndex = 8;
            this._lblDesigner6.Text = "Trình độ đầu vào";
            // 
            // _lblDesigner5
            // 
            this._lblDesigner5.AutoSize = true;
            this._lblDesigner5.Location = new System.Drawing.Point(570, 41);
            this._lblDesigner5.Name = "_lblDesigner5";
            this._lblDesigner5.Size = new System.Drawing.Size(32, 13);
            this._lblDesigner5.TabIndex = 6;
            this._lblDesigner5.Text = "Email";
            // 
            // _lblDesigner4
            // 
            this._lblDesigner4.AutoSize = true;
            this._lblDesigner4.Location = new System.Drawing.Point(15, 41);
            this._lblDesigner4.Name = "_lblDesigner4";
            this._lblDesigner4.Size = new System.Drawing.Size(29, 13);
            this._lblDesigner4.TabIndex = 4;
            this._lblDesigner4.Text = "SĐT";
            // 
            // _lblDesigner3
            // 
            this._lblDesigner3.AutoSize = true;
            this._lblDesigner3.Location = new System.Drawing.Point(570, 10);
            this._lblDesigner3.Name = "_lblDesigner3";
            this._lblDesigner3.Size = new System.Drawing.Size(54, 13);
            this._lblDesigner3.TabIndex = 2;
            this._lblDesigner3.Text = "Ngày sinh";
            // 
            // _lblDesigner2
            // 
            this._lblDesigner2.AutoSize = true;
            this._lblDesigner2.Location = new System.Drawing.Point(15, 10);
            this._lblDesigner2.Name = "_lblDesigner2";
            this._lblDesigner2.Size = new System.Drawing.Size(39, 13);
            this._lblDesigner2.TabIndex = 0;
            this._lblDesigner2.Text = "Họ tên";
            // 
            // _lblDesigner1
            // 
            this._lblDesigner1.AutoSize = true;
            this._lblDesigner1.Location = new System.Drawing.Point(11, 8);
            this._lblDesigner1.Name = "_lblDesigner1";
            this._lblDesigner1.Size = new System.Drawing.Size(47, 13);
            this._lblDesigner1.TabIndex = 0;
            this._lblDesigner1.Text = "Từ khóa";
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._grid.BackgroundColor = System.Drawing.Color.White;
            this._grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._grid.ColumnHeadersHeight = 34;
            this._grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grid.EnableHeadersVisualStyles = false;
            this._grid.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._grid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this._grid.Location = new System.Drawing.Point(3, 280);
            this._grid.MinimumSize = new System.Drawing.Size(320, 180);
            this._grid.MultiSelect = false;
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.RowTemplate.Height = 30;
            this._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._grid.Size = new System.Drawing.Size(1094, 437);
            this._grid.TabIndex = 3;
            // 
            // _txtTim
            // 
            this._txtTim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTim.BackColor = System.Drawing.Color.White;
            this._txtTim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtTim.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtTim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._txtTim.Location = new System.Drawing.Point(65, 17);
            this._txtTim.Margin = new System.Windows.Forms.Padding(4);
            this._txtTim.MinimumSize = new System.Drawing.Size(150, 2);
            this._txtTim.Name = "_txtTim";
            this._txtTim.Size = new System.Drawing.Size(220, 23);
            this._txtTim.TabIndex = 1;
            // 
            // _txtHoTen
            // 
            this._txtHoTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtHoTen.BackColor = System.Drawing.Color.White;
            this._txtHoTen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtHoTen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtHoTen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._txtHoTen.Location = new System.Drawing.Point(112, 14);
            this._txtHoTen.Margin = new System.Windows.Forms.Padding(4);
            this._txtHoTen.MinimumSize = new System.Drawing.Size(150, 2);
            this._txtHoTen.Name = "_txtHoTen";
            this._txtHoTen.Size = new System.Drawing.Size(451, 23);
            this._txtHoTen.TabIndex = 1;
            // 
            // _txtSdt
            // 
            this._txtSdt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSdt.BackColor = System.Drawing.Color.White;
            this._txtSdt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtSdt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtSdt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._txtSdt.Location = new System.Drawing.Point(112, 45);
            this._txtSdt.Margin = new System.Windows.Forms.Padding(4);
            this._txtSdt.MinimumSize = new System.Drawing.Size(150, 2);
            this._txtSdt.Name = "_txtSdt";
            this._txtSdt.Size = new System.Drawing.Size(451, 23);
            this._txtSdt.TabIndex = 5;
            // 
            // _txtEmail
            // 
            this._txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtEmail.BackColor = System.Drawing.Color.White;
            this._txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._txtEmail.Location = new System.Drawing.Point(632, 45);
            this._txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this._txtEmail.MinimumSize = new System.Drawing.Size(150, 2);
            this._txtEmail.Name = "_txtEmail";
            this._txtEmail.Size = new System.Drawing.Size(452, 23);
            this._txtEmail.TabIndex = 7;
            // 
            // _txtTrinhDo
            // 
            this._txtTrinhDo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTrinhDo.BackColor = System.Drawing.Color.White;
            this._txtTrinhDo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtTrinhDo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtTrinhDo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._txtTrinhDo.Location = new System.Drawing.Point(112, 76);
            this._txtTrinhDo.Margin = new System.Windows.Forms.Padding(4);
            this._txtTrinhDo.MinimumSize = new System.Drawing.Size(150, 2);
            this._txtTrinhDo.Name = "_txtTrinhDo";
            this._txtTrinhDo.Size = new System.Drawing.Size(451, 23);
            this._txtTrinhDo.TabIndex = 9;
            // 
            // _txtTaiKhoan
            // 
            this._txtTaiKhoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTaiKhoan.BackColor = System.Drawing.Color.White;
            this._txtTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtTaiKhoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._txtTaiKhoan.Location = new System.Drawing.Point(632, 76);
            this._txtTaiKhoan.Margin = new System.Windows.Forms.Padding(4);
            this._txtTaiKhoan.MinimumSize = new System.Drawing.Size(150, 2);
            this._txtTaiKhoan.Name = "_txtTaiKhoan";
            this._txtTaiKhoan.Size = new System.Drawing.Size(452, 23);
            this._txtTaiKhoan.TabIndex = 11;
            // 
            // _txtMatKhau
            // 
            this._txtMatKhau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtMatKhau.BackColor = System.Drawing.Color.White;
            this._txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtMatKhau.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtMatKhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._txtMatKhau.Location = new System.Drawing.Point(112, 115);
            this._txtMatKhau.Margin = new System.Windows.Forms.Padding(4);
            this._txtMatKhau.MinimumSize = new System.Drawing.Size(150, 2);
            this._txtMatKhau.Name = "_txtMatKhau";
            this._txtMatKhau.Size = new System.Drawing.Size(451, 23);
            this._txtMatKhau.TabIndex = 13;
            // 
            // _dtNgaySinh
            // 
            this._dtNgaySinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._dtNgaySinh.CustomFormat = "dd/MM/yyyy";
            this._dtNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtNgaySinh.Location = new System.Drawing.Point(631, 15);
            this._dtNgaySinh.Name = "_dtNgaySinh";
            this._dtNgaySinh.Size = new System.Drawing.Size(454, 20);
            this._dtNgaySinh.TabIndex = 3;
            // 
            // _lblLienHeFilter
            // 
            this._lblLienHeFilter.AutoSize = true;
            this._lblLienHeFilter.Location = new System.Drawing.Point(293, 8);
            this._lblLienHeFilter.Margin = new System.Windows.Forms.Padding(4, 8, 4, 2);
            this._lblLienHeFilter.Name = "_lblLienHeFilter";
            this._lblLienHeFilter.Size = new System.Drawing.Size(55, 13);
            this._lblLienHeFilter.TabIndex = 2;
            this._lblLienHeFilter.Text = "SĐT/Email";
            // 
            // _txtLienHe
            // 
            this._txtLienHe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtLienHe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtLienHe.Location = new System.Drawing.Point(356, 4);
            this._txtLienHe.Margin = new System.Windows.Forms.Padding(4);
            this._txtLienHe.MinimumSize = new System.Drawing.Size(150, 2);
            this._txtLienHe.Name = "_txtLienHe";
            this._txtLienHe.Size = new System.Drawing.Size(180, 23);
            this._txtLienHe.TabIndex = 3;
            // 
            // _lblLopFilter
            // 
            this._lblLopFilter.AutoSize = true;
            this._lblLopFilter.Location = new System.Drawing.Point(544, 8);
            this._lblLopFilter.Margin = new System.Windows.Forms.Padding(4, 8, 4, 2);
            this._lblLopFilter.Name = "_lblLopFilter";
            this._lblLopFilter.Size = new System.Drawing.Size(25, 13);
            this._lblLopFilter.TabIndex = 4;
            this._lblLopFilter.Text = "Lớp";
            // 
            // _cboLopFilter
            // 
            this._cboLopFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboLopFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cboLopFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._cboLopFilter.Location = new System.Drawing.Point(577, 4);
            this._cboLopFilter.Margin = new System.Windows.Forms.Padding(4);
            this._cboLopFilter.MinimumSize = new System.Drawing.Size(150, 0);
            this._cboLopFilter.Name = "_cboLopFilter";
            this._cboLopFilter.Size = new System.Drawing.Size(180, 23);
            this._cboLopFilter.TabIndex = 5;
            // 
            // _lblTrangThaiFilter
            // 
            this._lblTrangThaiFilter.AutoSize = true;
            this._lblTrangThaiFilter.Location = new System.Drawing.Point(765, 8);
            this._lblTrangThaiFilter.Margin = new System.Windows.Forms.Padding(4, 8, 4, 2);
            this._lblTrangThaiFilter.Name = "_lblTrangThaiFilter";
            this._lblTrangThaiFilter.Size = new System.Drawing.Size(55, 13);
            this._lblTrangThaiFilter.TabIndex = 6;
            this._lblTrangThaiFilter.Text = "Trạng thái";
            // 
            // _cboTrangThaiFilter
            // 
            this._cboTrangThaiFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboTrangThaiFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cboTrangThaiFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._cboTrangThaiFilter.Location = new System.Drawing.Point(828, 4);
            this._cboTrangThaiFilter.Margin = new System.Windows.Forms.Padding(4);
            this._cboTrangThaiFilter.MinimumSize = new System.Drawing.Size(150, 0);
            this._cboTrangThaiFilter.Name = "_cboTrangThaiFilter";
            this._cboTrangThaiFilter.Size = new System.Drawing.Size(150, 23);
            this._cboTrangThaiFilter.TabIndex = 7;
            // 
            // _lblLop
            // 
            this._lblLop.AutoSize = true;
            this._lblLop.Location = new System.Drawing.Point(570, 103);
            this._lblLop.Name = "_lblLop";
            this._lblLop.Size = new System.Drawing.Size(25, 13);
            this._lblLop.TabIndex = 14;
            this._lblLop.Text = "Lớp";
            // 
            // _cboLop
            // 
            this._cboLop.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboLop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cboLop.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._cboLop.Location = new System.Drawing.Point(632, 107);
            this._cboLop.Margin = new System.Windows.Forms.Padding(4);
            this._cboLop.MinimumSize = new System.Drawing.Size(150, 0);
            this._cboLop.Name = "_cboLop";
            this._cboLop.Size = new System.Drawing.Size(452, 23);
            this._cboLop.TabIndex = 15;
            // 
            // root
            // 
            this.root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1100F));
            this.root.Controls.Add(this._lblTitle, 0, 0);
            this.root.Controls.Add(this.search, 0, 1);
            this.root.Controls.Add(this.form, 0, 2);
            this.root.Controls.Add(this._grid, 0, 3);
            this.root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.root.Location = new System.Drawing.Point(0, 0);
            this.root.Name = "root";
            this.root.RowCount = 4;
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.root.Size = new System.Drawing.Size(1100, 720);
            this.root.TabIndex = 0;
            // 
            // search
            // 
            this.search.AutoSize = true;
            this.search.Controls.Add(this._lblDesigner1);
            this.search.Controls.Add(this._txtTim);
            this.search.Controls.Add(this._lblLienHeFilter);
            this.search.Controls.Add(this._txtLienHe);
            this.search.Controls.Add(this._lblLopFilter);
            this.search.Controls.Add(this._cboLopFilter);
            this.search.Controls.Add(this._lblTrangThaiFilter);
            this.search.Controls.Add(this._cboTrangThaiFilter);
            this.search.Controls.Add(this.btnTim);
            this.search.Dock = System.Windows.Forms.DockStyle.Top;
            this.search.Location = new System.Drawing.Point(3, 55);
            this.search.Name = "search";
            this.search.Padding = new System.Windows.Forms.Padding(8);
            this.search.Size = new System.Drawing.Size(1094, 58);
            this.search.TabIndex = 1;
            // 
            // btnTim
            // 
            this.btnTim.AutoEllipsis = true;
            this.btnTim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.btnTim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnTim.Location = new System.Drawing.Point(293, 12);
            this.btnTim.Margin = new System.Windows.Forms.Padding(4);
            this.btnTim.Name = "btnTim";
            this.btnTim.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnTim.Size = new System.Drawing.Size(110, 34);
            this.btnTim.TabIndex = 2;
            this.btnTim.Text = "Tìm kiếm";
            this.btnTim.UseVisualStyleBackColor = false;
            // 
            // form
            // 
            this.form.AutoSize = true;
            this.form.BackColor = System.Drawing.Color.White;
            this.form.ColumnCount = 4;
            this.form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.form.Controls.Add(this._lblDesigner2, 0, 0);
            this.form.Controls.Add(this._txtHoTen, 1, 0);
            this.form.Controls.Add(this._lblDesigner3, 2, 0);
            this.form.Controls.Add(this._dtNgaySinh, 3, 0);
            this.form.Controls.Add(this._lblDesigner4, 0, 1);
            this.form.Controls.Add(this._txtSdt, 1, 1);
            this.form.Controls.Add(this._lblDesigner5, 2, 1);
            this.form.Controls.Add(this._txtEmail, 3, 1);
            this.form.Controls.Add(this._lblDesigner6, 0, 2);
            this.form.Controls.Add(this._txtTrinhDo, 1, 2);
            this.form.Controls.Add(this._lblDesigner7, 2, 2);
            this.form.Controls.Add(this._txtTaiKhoan, 3, 2);
            this.form.Controls.Add(this._lblDesigner8, 0, 3);
            this.form.Controls.Add(this._txtMatKhau, 1, 3);
            this.form.Controls.Add(this._lblLop, 2, 3);
            this.form.Controls.Add(this._cboLop, 3, 3);
            this.form.Controls.Add(this.buttons, 3, 4);
            this.form.Dock = System.Windows.Forms.DockStyle.Top;
            this.form.Location = new System.Drawing.Point(0, 116);
            this.form.Margin = new System.Windows.Forms.Padding(0);
            this.form.Name = "form";
            this.form.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.form.RowCount = 5;
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.form.Size = new System.Drawing.Size(1100, 192);
            this.form.TabIndex = 2;
            // 
            // buttons
            // 
            this.buttons.AutoSize = true;
            this.buttons.Controls.Add(this.btnThem);
            this.buttons.Controls.Add(this.btnLuu);
            this.buttons.Controls.Add(this.btnXoa);
            this.buttons.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttons.Location = new System.Drawing.Point(631, 106);
            this.buttons.Name = "buttons";
            this.buttons.Size = new System.Drawing.Size(454, 42);
            this.buttons.TabIndex = 14;
            // 
            // btnThem
            // 
            this.btnThem.AutoEllipsis = true;
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnThem.Location = new System.Drawing.Point(4, 4);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnThem.Size = new System.Drawing.Size(110, 34);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm mới";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            this.btnLuu.AutoEllipsis = true;
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLuu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnLuu.Location = new System.Drawing.Point(122, 4);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnLuu.Size = new System.Drawing.Size(110, 34);
            this.btnLuu.TabIndex = 1;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.AutoEllipsis = true;
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnXoa.Location = new System.Drawing.Point(240, 4);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnXoa.Size = new System.Drawing.Size(110, 34);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // FrmHocVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Controls.Add(this.root);
            this.Name = "FrmHocVien";
            this.Text = "Hồ sơ học viên";
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.root.ResumeLayout(false);
            this.root.PerformLayout();
            this.search.ResumeLayout(false);
            this.search.PerformLayout();
            this.form.ResumeLayout(false);
            this.form.PerformLayout();
            this.buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
    }
}
