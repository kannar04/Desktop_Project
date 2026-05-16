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
            this.components = new System.ComponentModel.Container();
            this._lblTitle = new System.Windows.Forms.Label();
            this._lblTitle.AutoEllipsis = true;
            this._lblTitle.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this._lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this._lblTitle.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this._lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this._lblTitle.Name = "_lblTitle";
            this._lblTitle.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this._lblTitle.Text = "Cập nhật điểm số IELTS";
            this._lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lblDesigner9 = new System.Windows.Forms.Label();
            this._lblDesigner9.Text = "Nhận xét";
            this._lblDesigner9.AutoSize = true;
            this._lblDesigner8 = new System.Windows.Forms.Label();
            this._lblDesigner8.Text = "S";
            this._lblDesigner8.AutoSize = true;
            this._lblDesigner7 = new System.Windows.Forms.Label();
            this._lblDesigner7.Text = "W";
            this._lblDesigner7.AutoSize = true;
            this._lblDesigner6 = new System.Windows.Forms.Label();
            this._lblDesigner6.Text = "R";
            this._lblDesigner6.AutoSize = true;
            this._lblDesigner5 = new System.Windows.Forms.Label();
            this._lblDesigner5.Text = "L";
            this._lblDesigner5.AutoSize = true;
            this._lblDesigner4 = new System.Windows.Forms.Label();
            this._lblDesigner4.Text = "Đợt kiểm tra";
            this._lblDesigner4.AutoSize = true;
            this._lblDesigner3 = new System.Windows.Forms.Label();
            this._lblDesigner3.Text = "Ngày";
            this._lblDesigner3.AutoSize = true;
            this._lblDesigner2 = new System.Windows.Forms.Label();
            this._lblDesigner2.Text = "Tên đợt";
            this._lblDesigner2.AutoSize = true;
            this._lblDesigner1 = new System.Windows.Forms.Label();
            this._lblDesigner1.Text = "Lớp";
            this._lblDesigner1.AutoSize = true;
            this._cboLop = new System.Windows.Forms.ComboBox();
            this._cboLop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._cboLop.BackColor = System.Drawing.Color.White;
            this._cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboLop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cboLop.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._cboLop.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this._cboLop.Margin = new System.Windows.Forms.Padding(4);
            this._cboLop.MinimumSize = new System.Drawing.Size(150, 0);
            this._cboLop.Width = 220;
            this._cboDot = new System.Windows.Forms.ComboBox();
            this._cboDot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._cboDot.BackColor = System.Drawing.Color.White;
            this._cboDot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboDot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cboDot.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._cboDot.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this._cboDot.Margin = new System.Windows.Forms.Padding(4);
            this._cboDot.MinimumSize = new System.Drawing.Size(150, 0);
            this._cboDot.Width = 220;
            this._gridHocVien = new System.Windows.Forms.DataGridView();
            this._gridHocVien.AutoGenerateColumns = true;
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
            this._gridHocVien.GridColor = System.Drawing.Color.FromArgb(213, 220, 230);
            this._gridHocVien.MinimumSize = new System.Drawing.Size(320, 180);
            this._gridHocVien.MultiSelect = false;
            this._gridHocVien.ReadOnly = true;
            this._gridHocVien.RowHeadersVisible = false;
            this._gridHocVien.RowTemplate.Height = 30;
            this._gridHocVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._gridDiem = new System.Windows.Forms.DataGridView();
            this._gridDiem.AutoGenerateColumns = true;
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
            this._gridDiem.GridColor = System.Drawing.Color.FromArgb(213, 220, 230);
            this._gridDiem.MinimumSize = new System.Drawing.Size(320, 180);
            this._gridDiem.MultiSelect = false;
            this._gridDiem.ReadOnly = true;
            this._gridDiem.RowHeadersVisible = false;
            this._gridDiem.RowTemplate.Height = 30;
            this._gridDiem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._txtTenDot = new System.Windows.Forms.TextBox();
            this._txtTenDot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTenDot.BackColor = System.Drawing.Color.White;
            this._txtTenDot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtTenDot.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtTenDot.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this._txtTenDot.Margin = new System.Windows.Forms.Padding(4);
            this._txtTenDot.MinimumSize = new System.Drawing.Size(150, 0);
            this._txtTenDot.Width = 220;
            this._dtNgay = new System.Windows.Forms.DateTimePicker();
            this._diemL = new System.Windows.Forms.NumericUpDown();
            this._diemR = new System.Windows.Forms.NumericUpDown();
            this._diemW = new System.Windows.Forms.NumericUpDown();
            this._diemS = new System.Windows.Forms.NumericUpDown();
            this._txtNhanXet = new System.Windows.Forms.TextBox();
            this._txtNhanXet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtNhanXet.BackColor = System.Drawing.Color.White;
            this._txtNhanXet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtNhanXet.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtNhanXet.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this._txtNhanXet.Margin = new System.Windows.Forms.Padding(4);
            this._txtNhanXet.MinimumSize = new System.Drawing.Size(150, 0);
            this._txtNhanXet.Width = 220;
            this.root = new System.Windows.Forms.TableLayoutPanel();
            this.top = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTaoDot = new System.Windows.Forms.Button();
            this.btnTaoDot.AutoEllipsis = true;
            this.btnTaoDot.BackColor = System.Drawing.Color.FromArgb(235, 242, 252);
            this.btnTaoDot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaoDot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoDot.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTaoDot.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnTaoDot.Height = 34;
            this.btnTaoDot.Margin = new System.Windows.Forms.Padding(4);
            this.btnTaoDot.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnTaoDot.UseVisualStyleBackColor = false;
            this.btnTaoDot.Width = 110;
            this.btnTaoDot.Text = "Tạo đợt";
            this.btnTai = new System.Windows.Forms.Button();
            this.btnTai.AutoEllipsis = true;
            this.btnTai.BackColor = System.Drawing.Color.FromArgb(235, 242, 252);
            this.btnTai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTai.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnTai.Height = 34;
            this.btnTai.Margin = new System.Windows.Forms.Padding(4);
            this.btnTai.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnTai.UseVisualStyleBackColor = false;
            this.btnTai.Width = 110;
            this.btnTai.Text = "Tải điểm";
            this.middle = new System.Windows.Forms.TableLayoutPanel();
            this.bottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnLuu.AutoEllipsis = true;
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(235, 242, 252);
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLuu.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnLuu.Height = 34;
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuu.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Width = 110;
            this.btnLuu.Text = "Lưu điểm";
            ((System.ComponentModel.ISupportInitialize)(this._diemL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._diemR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._diemW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._diemS)).BeginInit();
            this.root.SuspendLayout();
            this.top.SuspendLayout();
            this.middle.SuspendLayout();
            this.bottom.SuspendLayout();
            this.SuspendLayout();

            this.root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.root.RowCount = 4;
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));

            this._dtNgay.Width = 150;
            this._dtNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtNgay.CustomFormat = "dd/MM/yyyy";

            this._diemL.Width = 58;
            this._diemL.DecimalPlaces = 1;
            this._diemL.Increment = 0.5M;
            this._diemL.Minimum = 0;
            this._diemL.Maximum = 9;
            this._diemR.Width = 58;
            this._diemR.DecimalPlaces = 1;
            this._diemR.Increment = 0.5M;
            this._diemR.Minimum = 0;
            this._diemR.Maximum = 9;
            this._diemW.Width = 58;
            this._diemW.DecimalPlaces = 1;
            this._diemW.Increment = 0.5M;
            this._diemW.Minimum = 0;
            this._diemW.Maximum = 9;
            this._diemS.Width = 58;
            this._diemS.DecimalPlaces = 1;
            this._diemS.Increment = 0.5M;
            this._diemS.Minimum = 0;
            this._diemS.Maximum = 9;

            this.btnTaoDot.Click += this.BtnTaoDot_Click;
            this.btnTai.Click += this.BtnTai_Click;
            this.top.Dock = System.Windows.Forms.DockStyle.Top;
            this.top.AutoSize = true;
            this.top.Padding = new System.Windows.Forms.Padding(8);
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

            this.middle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.middle.ColumnCount = 2;
            this.middle.RowCount = 1;
            this.middle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.middle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.middle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.middle.Controls.Add(this._gridHocVien, 0, 0);
            this.middle.Controls.Add(this._gridDiem, 1, 0);

            this._txtNhanXet.Width = 320;
            this.btnLuu.Click += this.BtnLuu_Click;
            this.bottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.bottom.AutoSize = true;
            this.bottom.Padding = new System.Windows.Forms.Padding(8);
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

            this._cboLop.SelectedIndexChanged += this.CboLop_SelectedIndexChanged;
            this.root.Controls.Add(this._lblTitle, 0, 0);

            this.root.Controls.Add(this.top, 0, 1);
            this.root.Controls.Add(this.middle, 0, 2);
            this.root.Controls.Add(this.bottom, 0, 3);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Name = "FrmDiemSo";
            this.Controls.Add(this.root);

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
