namespace DesktopApp_Project.GUI
{
    partial class FrmLopHoc
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label _lblTitle;
        private System.Windows.Forms.Label _lblDesigner3;
        private System.Windows.Forms.Label _lblDesigner2;
        private System.Windows.Forms.Label _lblDesigner1;
        private System.Windows.Forms.Label _lblHuongDanPhanLop;
        private System.Windows.Forms.TableLayoutPanel root;
        private System.Windows.Forms.TableLayoutPanel form;
        private System.Windows.Forms.FlowLayoutPanel buttons;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Panel bottom;
        private System.Windows.Forms.TableLayoutPanel split;
        private System.Windows.Forms.FlowLayoutPanel assignButtons;
        private System.Windows.Forms.Button btnThemHv;
        private System.Windows.Forms.Button btnXoaHv;
        private System.Windows.Forms.DataGridView _gridLop;
        private System.Windows.Forms.DataGridView _gridTrongLop;
        private System.Windows.Forms.DataGridView _gridNgoaiLop;
        private System.Windows.Forms.TextBox _txtTenLop;
        private System.Windows.Forms.TextBox _txtTrinhDo;
        private System.Windows.Forms.TextBox _txtLichHoc;

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
            this._lblDesigner3 = new System.Windows.Forms.Label();
            this._lblDesigner2 = new System.Windows.Forms.Label();
            this._lblDesigner1 = new System.Windows.Forms.Label();
            this._lblHuongDanPhanLop = new System.Windows.Forms.Label();
            this._gridLop = new System.Windows.Forms.DataGridView();
            this._gridTrongLop = new System.Windows.Forms.DataGridView();
            this._gridNgoaiLop = new System.Windows.Forms.DataGridView();
            this._txtTenLop = new System.Windows.Forms.TextBox();
            this._txtTrinhDo = new System.Windows.Forms.TextBox();
            this._txtLichHoc = new System.Windows.Forms.TextBox();
            this.root = new System.Windows.Forms.TableLayoutPanel();
            this.form = new System.Windows.Forms.TableLayoutPanel();
            this.buttons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.bottom = new System.Windows.Forms.Panel();
            this.split = new System.Windows.Forms.TableLayoutPanel();
            this.assignButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThemHv = new System.Windows.Forms.Button();
            this.btnXoaHv = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._gridLop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridTrongLop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridNgoaiLop)).BeginInit();
            this.root.SuspendLayout();
            this.form.SuspendLayout();
            this.buttons.SuspendLayout();
            this.bottom.SuspendLayout();
            this.split.SuspendLayout();
            this.assignButtons.SuspendLayout();
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
            this._lblTitle.Text = "Quản lý lớp học";
            this._lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblDesigner3
            // 
            this._lblDesigner3.AutoSize = true;
            this._lblDesigner3.Location = new System.Drawing.Point(15, 41);
            this._lblDesigner3.Name = "_lblDesigner3";
            this._lblDesigner3.Size = new System.Drawing.Size(48, 13);
            this._lblDesigner3.TabIndex = 4;
            this._lblDesigner3.Text = "Lịch học";
            // 
            // _lblDesigner2
            // 
            this._lblDesigner2.AutoSize = true;
            this._lblDesigner2.Location = new System.Drawing.Point(540, 10);
            this._lblDesigner2.Name = "_lblDesigner2";
            this._lblDesigner2.Size = new System.Drawing.Size(74, 13);
            this._lblDesigner2.TabIndex = 2;
            this._lblDesigner2.Text = "Nhóm trình độ";
            // 
            // _lblDesigner1
            // 
            this._lblDesigner1.AutoSize = true;
            this._lblDesigner1.Location = new System.Drawing.Point(15, 10);
            this._lblDesigner1.Name = "_lblDesigner1";
            this._lblDesigner1.Size = new System.Drawing.Size(43, 13);
            this._lblDesigner1.TabIndex = 0;
            this._lblDesigner1.Text = "Tên lớp";
            // 
            // _lblHuongDanPhanLop
            // 
            this._lblHuongDanPhanLop.AutoSize = true;
            this._lblHuongDanPhanLop.Location = new System.Drawing.Point(11, 8);
            this._lblHuongDanPhanLop.Name = "_lblHuongDanPhanLop";
            this._lblHuongDanPhanLop.Padding = new System.Windows.Forms.Padding(4, 9, 16, 0);
            this._lblHuongDanPhanLop.Size = new System.Drawing.Size(326, 22);
            this._lblHuongDanPhanLop.TabIndex = 0;
            this._lblHuongDanPhanLop.Text = "Bên trái: học viên trong lớp. Bên phải: học viên chưa thuộc lớp.";
            // 
            // _gridLop
            // 
            this._gridLop.AllowUserToAddRows = false;
            this._gridLop.AllowUserToDeleteRows = false;
            this._gridLop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._gridLop.BackgroundColor = System.Drawing.Color.White;
            this._gridLop.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._gridLop.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._gridLop.ColumnHeadersHeight = 34;
            this._gridLop.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gridLop.EnableHeadersVisualStyles = false;
            this._gridLop.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._gridLop.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this._gridLop.Location = new System.Drawing.Point(3, 154);
            this._gridLop.MinimumSize = new System.Drawing.Size(320, 180);
            this._gridLop.MultiSelect = false;
            this._gridLop.Name = "_gridLop";
            this._gridLop.ReadOnly = true;
            this._gridLop.RowHeadersVisible = false;
            this._gridLop.RowTemplate.Height = 30;
            this._gridLop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._gridLop.Size = new System.Drawing.Size(1094, 250);
            this._gridLop.TabIndex = 2;
            // 
            // _gridTrongLop
            // 
            this._gridTrongLop.AllowUserToAddRows = false;
            this._gridTrongLop.AllowUserToDeleteRows = false;
            this._gridTrongLop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._gridTrongLop.BackgroundColor = System.Drawing.Color.White;
            this._gridTrongLop.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._gridTrongLop.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._gridTrongLop.ColumnHeadersHeight = 34;
            this._gridTrongLop.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gridTrongLop.EnableHeadersVisualStyles = false;
            this._gridTrongLop.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._gridTrongLop.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this._gridTrongLop.Location = new System.Drawing.Point(3, 3);
            this._gridTrongLop.MinimumSize = new System.Drawing.Size(320, 180);
            this._gridTrongLop.MultiSelect = false;
            this._gridTrongLop.Name = "_gridTrongLop";
            this._gridTrongLop.ReadOnly = true;
            this._gridTrongLop.RowHeadersVisible = false;
            this._gridTrongLop.RowTemplate.Height = 30;
            this._gridTrongLop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._gridTrongLop.Size = new System.Drawing.Size(541, 243);
            this._gridTrongLop.TabIndex = 0;
            // 
            // _gridNgoaiLop
            // 
            this._gridNgoaiLop.AllowUserToAddRows = false;
            this._gridNgoaiLop.AllowUserToDeleteRows = false;
            this._gridNgoaiLop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._gridNgoaiLop.BackgroundColor = System.Drawing.Color.White;
            this._gridNgoaiLop.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._gridNgoaiLop.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._gridNgoaiLop.ColumnHeadersHeight = 34;
            this._gridNgoaiLop.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gridNgoaiLop.EnableHeadersVisualStyles = false;
            this._gridNgoaiLop.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._gridNgoaiLop.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this._gridNgoaiLop.Location = new System.Drawing.Point(550, 3);
            this._gridNgoaiLop.MinimumSize = new System.Drawing.Size(320, 180);
            this._gridNgoaiLop.MultiSelect = false;
            this._gridNgoaiLop.Name = "_gridNgoaiLop";
            this._gridNgoaiLop.ReadOnly = true;
            this._gridNgoaiLop.RowHeadersVisible = false;
            this._gridNgoaiLop.RowTemplate.Height = 30;
            this._gridNgoaiLop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._gridNgoaiLop.Size = new System.Drawing.Size(541, 243);
            this._gridNgoaiLop.TabIndex = 1;
            // 
            // _txtTenLop
            // 
            this._txtTenLop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTenLop.BackColor = System.Drawing.Color.White;
            this._txtTenLop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtTenLop.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtTenLop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._txtTenLop.Location = new System.Drawing.Point(70, 14);
            this._txtTenLop.Margin = new System.Windows.Forms.Padding(4);
            this._txtTenLop.MinimumSize = new System.Drawing.Size(150, 2);
            this._txtTenLop.Name = "_txtTenLop";
            this._txtTenLop.Size = new System.Drawing.Size(463, 23);
            this._txtTenLop.TabIndex = 1;
            // 
            // _txtTrinhDo
            // 
            this._txtTrinhDo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTrinhDo.BackColor = System.Drawing.Color.White;
            this._txtTrinhDo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtTrinhDo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtTrinhDo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._txtTrinhDo.Location = new System.Drawing.Point(621, 14);
            this._txtTrinhDo.Margin = new System.Windows.Forms.Padding(4);
            this._txtTrinhDo.MinimumSize = new System.Drawing.Size(150, 2);
            this._txtTrinhDo.Name = "_txtTrinhDo";
            this._txtTrinhDo.Size = new System.Drawing.Size(463, 23);
            this._txtTrinhDo.TabIndex = 3;
            // 
            // _txtLichHoc
            // 
            this._txtLichHoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtLichHoc.BackColor = System.Drawing.Color.White;
            this._txtLichHoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtLichHoc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtLichHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._txtLichHoc.Location = new System.Drawing.Point(70, 53);
            this._txtLichHoc.Margin = new System.Windows.Forms.Padding(4);
            this._txtLichHoc.MinimumSize = new System.Drawing.Size(150, 2);
            this._txtLichHoc.Name = "_txtLichHoc";
            this._txtLichHoc.Size = new System.Drawing.Size(463, 23);
            this._txtLichHoc.TabIndex = 5;
            // 
            // root
            // 
            this.root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1100F));
            this.root.Controls.Add(this._lblTitle, 0, 0);
            this.root.Controls.Add(this.form, 0, 1);
            this.root.Controls.Add(this._gridLop, 0, 2);
            this.root.Controls.Add(this.bottom, 0, 3);
            this.root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.root.Location = new System.Drawing.Point(0, 0);
            this.root.Name = "root";
            this.root.RowCount = 4;
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.root.Size = new System.Drawing.Size(1100, 720);
            this.root.TabIndex = 0;
            // 
            // form
            // 
            this.form.AutoSize = true;
            this.form.BackColor = System.Drawing.Color.White;
            this.form.ColumnCount = 4;
            this.form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.form.Controls.Add(this._lblDesigner1, 0, 0);
            this.form.Controls.Add(this._txtTenLop, 1, 0);
            this.form.Controls.Add(this._lblDesigner2, 2, 0);
            this.form.Controls.Add(this._txtTrinhDo, 3, 0);
            this.form.Controls.Add(this._lblDesigner3, 0, 1);
            this.form.Controls.Add(this._txtLichHoc, 1, 1);
            this.form.Controls.Add(this.buttons, 3, 1);
            this.form.Dock = System.Windows.Forms.DockStyle.Top;
            this.form.Location = new System.Drawing.Point(0, 52);
            this.form.Margin = new System.Windows.Forms.Padding(0);
            this.form.Name = "form";
            this.form.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.form.Size = new System.Drawing.Size(1100, 99);
            this.form.TabIndex = 1;
            // 
            // buttons
            // 
            this.buttons.AutoSize = true;
            this.buttons.Controls.Add(this.btnThem);
            this.buttons.Controls.Add(this.btnLuu);
            this.buttons.Controls.Add(this.btnXoa);
            this.buttons.Location = new System.Drawing.Point(620, 44);
            this.buttons.Name = "buttons";
            this.buttons.Size = new System.Drawing.Size(354, 42);
            this.buttons.TabIndex = 6;
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
            // bottom
            // 
            this.bottom.Controls.Add(this.split);
            this.bottom.Controls.Add(this.assignButtons);
            this.bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottom.Location = new System.Drawing.Point(3, 410);
            this.bottom.Name = "bottom";
            this.bottom.Size = new System.Drawing.Size(1094, 307);
            this.bottom.TabIndex = 3;
            // 
            // split
            // 
            this.split.ColumnCount = 2;
            this.split.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.split.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.split.Controls.Add(this._gridTrongLop, 0, 0);
            this.split.Controls.Add(this._gridNgoaiLop, 1, 0);
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.Location = new System.Drawing.Point(0, 58);
            this.split.Name = "split";
            this.split.RowCount = 1;
            this.split.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.split.Size = new System.Drawing.Size(1094, 249);
            this.split.TabIndex = 0;
            // 
            // assignButtons
            // 
            this.assignButtons.AutoSize = true;
            this.assignButtons.Controls.Add(this._lblHuongDanPhanLop);
            this.assignButtons.Controls.Add(this.btnThemHv);
            this.assignButtons.Controls.Add(this.btnXoaHv);
            this.assignButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.assignButtons.Location = new System.Drawing.Point(0, 0);
            this.assignButtons.Name = "assignButtons";
            this.assignButtons.Padding = new System.Windows.Forms.Padding(8);
            this.assignButtons.Size = new System.Drawing.Size(1094, 58);
            this.assignButtons.TabIndex = 1;
            // 
            // btnThemHv
            // 
            this.btnThemHv.AutoEllipsis = true;
            this.btnThemHv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.btnThemHv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemHv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemHv.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThemHv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnThemHv.Location = new System.Drawing.Point(344, 12);
            this.btnThemHv.Margin = new System.Windows.Forms.Padding(4);
            this.btnThemHv.Name = "btnThemHv";
            this.btnThemHv.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnThemHv.Size = new System.Drawing.Size(130, 34);
            this.btnThemHv.TabIndex = 1;
            this.btnThemHv.Text = "Thêm vào lớp";
            this.btnThemHv.UseVisualStyleBackColor = false;
            // 
            // btnXoaHv
            // 
            this.btnXoaHv.AutoEllipsis = true;
            this.btnXoaHv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.btnXoaHv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaHv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaHv.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXoaHv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnXoaHv.Location = new System.Drawing.Point(482, 12);
            this.btnXoaHv.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoaHv.Name = "btnXoaHv";
            this.btnXoaHv.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnXoaHv.Size = new System.Drawing.Size(130, 34);
            this.btnXoaHv.TabIndex = 2;
            this.btnXoaHv.Text = "Xóa khỏi lớp";
            this.btnXoaHv.UseVisualStyleBackColor = false;
            // 
            // FrmLopHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Controls.Add(this.root);
            this.Name = "FrmLopHoc";
            this.Text = "Lớp học";
            ((System.ComponentModel.ISupportInitialize)(this._gridLop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridTrongLop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridNgoaiLop)).EndInit();
            this.root.ResumeLayout(false);
            this.root.PerformLayout();
            this.form.ResumeLayout(false);
            this.form.PerformLayout();
            this.buttons.ResumeLayout(false);
            this.bottom.ResumeLayout(false);
            this.bottom.PerformLayout();
            this.split.ResumeLayout(false);
            this.assignButtons.ResumeLayout(false);
            this.assignButtons.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
    }
}
