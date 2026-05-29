namespace DesktopApp_Project.GUI
{
    partial class FrmDiemSo
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label _lblTitle;
        private System.Windows.Forms.Label _lblDesigner9;
        private System.Windows.Forms.Label _lblDesigner8;
        private System.Windows.Forms.Label _lblDesigner7;
        private System.Windows.Forms.Label _lblDesigner6;
        private System.Windows.Forms.Label _lblDesigner5;
        private System.Windows.Forms.Label _lblDesigner4;
        private System.Windows.Forms.Label _lblDesigner3;
        private System.Windows.Forms.Label _lblDesigner2;
        private System.Windows.Forms.Label _lblDesigner1;
        private System.Windows.Forms.TableLayoutPanel root;
        private System.Windows.Forms.FlowLayoutPanel top;
        private System.Windows.Forms.Button btnTaoDot;
        private System.Windows.Forms.Button btnTai;
        private System.Windows.Forms.TableLayoutPanel middle;
        private System.Windows.Forms.FlowLayoutPanel bottom;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.ComboBox _cboLop;
        private System.Windows.Forms.ComboBox _cboDot;
        private System.Windows.Forms.DataGridView _gridHocVien;
        private System.Windows.Forms.DataGridView _gridDiem;
        private System.Windows.Forms.TextBox _txtTenDot;
        private System.Windows.Forms.DateTimePicker _dtNgay;
        private System.Windows.Forms.NumericUpDown _diemL;
        private System.Windows.Forms.NumericUpDown _diemR;
        private System.Windows.Forms.NumericUpDown _diemW;
        private System.Windows.Forms.NumericUpDown _diemS;
        private System.Windows.Forms.TextBox _txtNhanXet;

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
            this._lblDesigner9 = new System.Windows.Forms.Label();
            this._lblDesigner8 = new System.Windows.Forms.Label();
            this._lblDesigner7 = new System.Windows.Forms.Label();
            this._lblDesigner6 = new System.Windows.Forms.Label();
            this._lblDesigner5 = new System.Windows.Forms.Label();
            this._lblDesigner4 = new System.Windows.Forms.Label();
            this._lblDesigner3 = new System.Windows.Forms.Label();
            this._lblDesigner2 = new System.Windows.Forms.Label();
            this._lblDesigner1 = new System.Windows.Forms.Label();
            this._cboLop = new System.Windows.Forms.ComboBox();
            this._cboDot = new System.Windows.Forms.ComboBox();
            this._gridHocVien = new System.Windows.Forms.DataGridView();
            this._gridDiem = new System.Windows.Forms.DataGridView();
            this._txtTenDot = new System.Windows.Forms.TextBox();
            this._dtNgay = new System.Windows.Forms.DateTimePicker();
            this._diemL = new System.Windows.Forms.NumericUpDown();
            this._diemR = new System.Windows.Forms.NumericUpDown();
            this._diemW = new System.Windows.Forms.NumericUpDown();
            this._diemS = new System.Windows.Forms.NumericUpDown();
            this._txtNhanXet = new System.Windows.Forms.TextBox();
            this.root = new System.Windows.Forms.TableLayoutPanel();
            this.top = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTaoDot = new System.Windows.Forms.Button();
            this.btnTai = new System.Windows.Forms.Button();
            this.middle = new System.Windows.Forms.TableLayoutPanel();
            this.bottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLuu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._gridHocVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridDiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._diemL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._diemR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._diemW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._diemS)).BeginInit();
            this.root.SuspendLayout();
            this.top.SuspendLayout();
            this.middle.SuspendLayout();
            this.bottom.SuspendLayout();
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
            this._lblTitle.Text = "Cập nhật điểm số IELTS";
            this._lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblDesigner9
            // 
            this._lblDesigner9.AutoSize = true;
            this._lblDesigner9.Location = new System.Drawing.Point(351, 8);
            this._lblDesigner9.Name = "_lblDesigner9";
            this._lblDesigner9.Size = new System.Drawing.Size(50, 13);
            this._lblDesigner9.TabIndex = 8;
            this._lblDesigner9.Text = "Nhận xét";
            // 
            // _lblDesigner8
            // 
            this._lblDesigner8.AutoSize = true;
            this._lblDesigner8.Location = new System.Drawing.Point(267, 8);
            this._lblDesigner8.Name = "_lblDesigner8";
            this._lblDesigner8.Size = new System.Drawing.Size(14, 13);
            this._lblDesigner8.TabIndex = 6;
            this._lblDesigner8.Text = "S";
            // 
            // _lblDesigner7
            // 
            this._lblDesigner7.AutoSize = true;
            this._lblDesigner7.Location = new System.Drawing.Point(179, 8);
            this._lblDesigner7.Name = "_lblDesigner7";
            this._lblDesigner7.Size = new System.Drawing.Size(18, 13);
            this._lblDesigner7.TabIndex = 4;
            this._lblDesigner7.Text = "W";
            // 
            // _lblDesigner6
            // 
            this._lblDesigner6.AutoSize = true;
            this._lblDesigner6.Location = new System.Drawing.Point(94, 8);
            this._lblDesigner6.Name = "_lblDesigner6";
            this._lblDesigner6.Size = new System.Drawing.Size(15, 13);
            this._lblDesigner6.TabIndex = 2;
            this._lblDesigner6.Text = "R";
            // 
            // _lblDesigner5
            // 
            this._lblDesigner5.AutoSize = true;
            this._lblDesigner5.Location = new System.Drawing.Point(11, 8);
            this._lblDesigner5.Name = "_lblDesigner5";
            this._lblDesigner5.Size = new System.Drawing.Size(13, 13);
            this._lblDesigner5.TabIndex = 0;
            this._lblDesigner5.Text = "L";
            // 
            // _lblDesigner4
            // 
            this._lblDesigner4.AutoSize = true;
            this._lblDesigner4.Location = new System.Drawing.Point(861, 8);
            this._lblDesigner4.Name = "_lblDesigner4";
            this._lblDesigner4.Size = new System.Drawing.Size(64, 13);
            this._lblDesigner4.TabIndex = 7;
            this._lblDesigner4.Text = "Đợt kiểm tra";
            // 
            // _lblDesigner3
            // 
            this._lblDesigner3.AutoSize = true;
            this._lblDesigner3.Location = new System.Drawing.Point(549, 8);
            this._lblDesigner3.Name = "_lblDesigner3";
            this._lblDesigner3.Size = new System.Drawing.Size(32, 13);
            this._lblDesigner3.TabIndex = 4;
            this._lblDesigner3.Text = "Ngày";
            // 
            // _lblDesigner2
            // 
            this._lblDesigner2.AutoSize = true;
            this._lblDesigner2.Location = new System.Drawing.Point(270, 8);
            this._lblDesigner2.Name = "_lblDesigner2";
            this._lblDesigner2.Size = new System.Drawing.Size(45, 13);
            this._lblDesigner2.TabIndex = 2;
            this._lblDesigner2.Text = "Tên đợt";
            // 
            // _lblDesigner1
            // 
            this._lblDesigner1.AutoSize = true;
            this._lblDesigner1.Location = new System.Drawing.Point(11, 8);
            this._lblDesigner1.Name = "_lblDesigner1";
            this._lblDesigner1.Size = new System.Drawing.Size(25, 13);
            this._lblDesigner1.TabIndex = 0;
            this._lblDesigner1.Text = "Lớp";
            // 
            // _cboLop
            // 
            this._cboLop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._cboLop.BackColor = System.Drawing.Color.White;
            this._cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboLop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cboLop.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._cboLop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._cboLop.Location = new System.Drawing.Point(43, 17);
            this._cboLop.Margin = new System.Windows.Forms.Padding(4);
            this._cboLop.MinimumSize = new System.Drawing.Size(150, 0);
            this._cboLop.Name = "_cboLop";
            this._cboLop.Size = new System.Drawing.Size(220, 23);
            this._cboLop.TabIndex = 1;
            // 
            // _cboDot
            // 
            this._cboDot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._cboDot.BackColor = System.Drawing.Color.White;
            this._cboDot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboDot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cboDot.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._cboDot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._cboDot.Location = new System.Drawing.Point(12, 59);
            this._cboDot.Margin = new System.Windows.Forms.Padding(4);
            this._cboDot.MinimumSize = new System.Drawing.Size(150, 0);
            this._cboDot.Name = "_cboDot";
            this._cboDot.Size = new System.Drawing.Size(220, 23);
            this._cboDot.TabIndex = 8;
            // 
            // _gridHocVien
            // 
            this._gridHocVien.AllowUserToAddRows = false;
            this._gridHocVien.AllowUserToDeleteRows = false;
            this._gridHocVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._gridHocVien.BackgroundColor = System.Drawing.Color.White;
            this._gridHocVien.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._gridHocVien.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._gridHocVien.ColumnHeadersHeight = 34;
            this._gridHocVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gridHocVien.EnableHeadersVisualStyles = false;
            this._gridHocVien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._gridHocVien.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this._gridHocVien.Location = new System.Drawing.Point(3, 3);
            this._gridHocVien.MinimumSize = new System.Drawing.Size(320, 180);
            this._gridHocVien.MultiSelect = false;
            this._gridHocVien.Name = "_gridHocVien";
            this._gridHocVien.ReadOnly = true;
            this._gridHocVien.RowHeadersVisible = false;
            this._gridHocVien.RowTemplate.Height = 30;
            this._gridHocVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._gridHocVien.Size = new System.Drawing.Size(453, 325);
            this._gridHocVien.TabIndex = 0;
            // 
            // _gridDiem
            // 
            this._gridDiem.AllowUserToAddRows = false;
            this._gridDiem.AllowUserToDeleteRows = false;
            this._gridDiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._gridDiem.BackgroundColor = System.Drawing.Color.White;
            this._gridDiem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._gridDiem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._gridDiem.ColumnHeadersHeight = 34;
            this._gridDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gridDiem.EnableHeadersVisualStyles = false;
            this._gridDiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._gridDiem.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this._gridDiem.Location = new System.Drawing.Point(462, 3);
            this._gridDiem.MinimumSize = new System.Drawing.Size(320, 180);
            this._gridDiem.MultiSelect = false;
            this._gridDiem.Name = "_gridDiem";
            this._gridDiem.ReadOnly = true;
            this._gridDiem.RowHeadersVisible = false;
            this._gridDiem.RowTemplate.Height = 30;
            this._gridDiem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._gridDiem.Size = new System.Drawing.Size(629, 325);
            this._gridDiem.TabIndex = 1;
            // 
            // _txtTenDot
            // 
            this._txtTenDot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTenDot.BackColor = System.Drawing.Color.White;
            this._txtTenDot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtTenDot.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtTenDot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._txtTenDot.Location = new System.Drawing.Point(322, 17);
            this._txtTenDot.Margin = new System.Windows.Forms.Padding(4);
            this._txtTenDot.MinimumSize = new System.Drawing.Size(150, 2);
            this._txtTenDot.Name = "_txtTenDot";
            this._txtTenDot.Size = new System.Drawing.Size(220, 23);
            this._txtTenDot.TabIndex = 3;
            // 
            // _dtNgay
            // 
            this._dtNgay.CustomFormat = "dd/MM/yyyy";
            this._dtNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtNgay.Location = new System.Drawing.Point(587, 11);
            this._dtNgay.Name = "_dtNgay";
            this._dtNgay.Size = new System.Drawing.Size(150, 20);
            this._dtNgay.TabIndex = 5;
            // 
            // _diemL
            // 
            this._diemL.DecimalPlaces = 1;
            this._diemL.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this._diemL.Location = new System.Drawing.Point(30, 11);
            this._diemL.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this._diemL.Name = "_diemL";
            this._diemL.Size = new System.Drawing.Size(58, 20);
            this._diemL.TabIndex = 1;
            // 
            // _diemR
            // 
            this._diemR.DecimalPlaces = 1;
            this._diemR.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this._diemR.Location = new System.Drawing.Point(115, 11);
            this._diemR.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this._diemR.Name = "_diemR";
            this._diemR.Size = new System.Drawing.Size(58, 20);
            this._diemR.TabIndex = 3;
            // 
            // _diemW
            // 
            this._diemW.DecimalPlaces = 1;
            this._diemW.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this._diemW.Location = new System.Drawing.Point(203, 11);
            this._diemW.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this._diemW.Name = "_diemW";
            this._diemW.Size = new System.Drawing.Size(58, 20);
            this._diemW.TabIndex = 5;
            // 
            // _diemS
            // 
            this._diemS.DecimalPlaces = 1;
            this._diemS.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this._diemS.Location = new System.Drawing.Point(287, 11);
            this._diemS.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this._diemS.Name = "_diemS";
            this._diemS.Size = new System.Drawing.Size(58, 20);
            this._diemS.TabIndex = 7;
            // 
            // _txtNhanXet
            // 
            this._txtNhanXet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtNhanXet.BackColor = System.Drawing.Color.White;
            this._txtNhanXet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtNhanXet.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtNhanXet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._txtNhanXet.Location = new System.Drawing.Point(408, 17);
            this._txtNhanXet.Margin = new System.Windows.Forms.Padding(4);
            this._txtNhanXet.MinimumSize = new System.Drawing.Size(150, 2);
            this._txtNhanXet.Name = "_txtNhanXet";
            this._txtNhanXet.Size = new System.Drawing.Size(320, 23);
            this._txtNhanXet.TabIndex = 9;
            // 
            // root
            // 
            this.root.ColumnCount = 1;
            this.root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.root.Controls.Add(this._lblTitle, 0, 0);
            this.root.Controls.Add(this.top, 0, 1);
            this.root.Controls.Add(this.middle, 0, 2);
            this.root.Controls.Add(this.bottom, 0, 3);
            this.root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.root.Location = new System.Drawing.Point(0, 0);
            this.root.Name = "root";
            this.root.RowCount = 4;
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.root.Size = new System.Drawing.Size(1100, 720);
            this.root.TabIndex = 0;
            // 
            // top
            // 
            this.top.AutoSize = true;
            this.top.Controls.Add(this._lblDesigner1);
            this.top.Controls.Add(this._cboLop);
            this.top.Controls.Add(this._lblDesigner2);
            this.top.Controls.Add(this._txtTenDot);
            this.top.Controls.Add(this._lblDesigner3);
            this.top.Controls.Add(this._dtNgay);
            this.top.Controls.Add(this.btnTaoDot);
            this.top.Controls.Add(this._lblDesigner4);
            this.top.Controls.Add(this._cboDot);
            this.top.Controls.Add(this.btnTai);
            this.top.Dock = System.Windows.Forms.DockStyle.Top;
            this.top.Location = new System.Drawing.Point(3, 55);
            this.top.Name = "top";
            this.top.Padding = new System.Windows.Forms.Padding(8);
            this.top.Size = new System.Drawing.Size(1094, 100);
            this.top.TabIndex = 1;
            // 
            // btnTaoDot
            // 
            this.btnTaoDot.AutoEllipsis = true;
            this.btnTaoDot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.btnTaoDot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaoDot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoDot.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTaoDot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnTaoDot.Location = new System.Drawing.Point(744, 12);
            this.btnTaoDot.Margin = new System.Windows.Forms.Padding(4);
            this.btnTaoDot.Name = "btnTaoDot";
            this.btnTaoDot.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnTaoDot.Size = new System.Drawing.Size(110, 34);
            this.btnTaoDot.TabIndex = 6;
            this.btnTaoDot.Text = "Tạo đợt";
            this.btnTaoDot.UseVisualStyleBackColor = false;
            // 
            // btnTai
            // 
            this.btnTai.AutoEllipsis = true;
            this.btnTai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.btnTai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnTai.Location = new System.Drawing.Point(240, 54);
            this.btnTai.Margin = new System.Windows.Forms.Padding(4);
            this.btnTai.Name = "btnTai";
            this.btnTai.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnTai.Size = new System.Drawing.Size(110, 34);
            this.btnTai.TabIndex = 9;
            this.btnTai.Text = "Tải điểm";
            this.btnTai.UseVisualStyleBackColor = false;
            // 
            // middle
            // 
            this.middle.ColumnCount = 2;
            this.middle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.middle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.middle.Controls.Add(this._gridHocVien, 0, 0);
            this.middle.Controls.Add(this._gridDiem, 1, 0);
            this.middle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.middle.Location = new System.Drawing.Point(3, 161);
            this.middle.Name = "middle";
            this.middle.RowCount = 1;
            this.middle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.middle.Size = new System.Drawing.Size(1094, 331);
            this.middle.TabIndex = 2;
            // 
            // bottom
            // 
            this.bottom.AutoSize = true;
            this.bottom.Controls.Add(this._lblDesigner5);
            this.bottom.Controls.Add(this._diemL);
            this.bottom.Controls.Add(this._lblDesigner6);
            this.bottom.Controls.Add(this._diemR);
            this.bottom.Controls.Add(this._lblDesigner7);
            this.bottom.Controls.Add(this._diemW);
            this.bottom.Controls.Add(this._lblDesigner8);
            this.bottom.Controls.Add(this._diemS);
            this.bottom.Controls.Add(this._lblDesigner9);
            this.bottom.Controls.Add(this._txtNhanXet);
            this.bottom.Controls.Add(this.btnLuu);
            this.bottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.bottom.Location = new System.Drawing.Point(3, 498);
            this.bottom.Name = "bottom";
            this.bottom.Padding = new System.Windows.Forms.Padding(8);
            this.bottom.Size = new System.Drawing.Size(1094, 58);
            this.bottom.TabIndex = 3;
            // 
            // btnLuu
            // 
            this.btnLuu.AutoEllipsis = true;
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLuu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnLuu.Location = new System.Drawing.Point(736, 12);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnLuu.Size = new System.Drawing.Size(110, 34);
            this.btnLuu.TabIndex = 10;
            this.btnLuu.Text = "Lưu điểm";
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // FrmDiemSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Controls.Add(this.root);
            this.Name = "FrmDiemSo";
            ((System.ComponentModel.ISupportInitialize)(this._gridHocVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridDiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._diemL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._diemR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._diemW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._diemS)).EndInit();
            this.root.ResumeLayout(false);
            this.root.PerformLayout();
            this.top.ResumeLayout(false);
            this.top.PerformLayout();
            this.middle.ResumeLayout(false);
            this.bottom.ResumeLayout(false);
            this.bottom.PerformLayout();
            this.ResumeLayout(false);

        }

        
        #endregion
    }
}
