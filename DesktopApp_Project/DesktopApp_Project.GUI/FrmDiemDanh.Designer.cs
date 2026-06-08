namespace DesktopApp_Project.GUI
{
    partial class FrmDiemDanh
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label _lblTitle;
        private System.Windows.Forms.Label _lblDesigner4;
        private System.Windows.Forms.Label _lblDesigner3;
        private System.Windows.Forms.Label _lblDesigner2;
        private System.Windows.Forms.Label _lblDesigner1;
        private System.Windows.Forms.TableLayoutPanel root;
        private System.Windows.Forms.FlowLayoutPanel top;
        private System.Windows.Forms.Button btnTai;
        private System.Windows.Forms.FlowLayoutPanel bottom;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.ComboBox _cboLop;
        private System.Windows.Forms.DateTimePicker _dtNgay;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.ComboBox _cboTrangThai;
        private System.Windows.Forms.TextBox _txtLyDo;

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
            this._lblDesigner4 = new System.Windows.Forms.Label();
            this._lblDesigner3 = new System.Windows.Forms.Label();
            this._lblDesigner2 = new System.Windows.Forms.Label();
            this._lblDesigner1 = new System.Windows.Forms.Label();
            this._cboLop = new System.Windows.Forms.ComboBox();
            this._dtNgay = new System.Windows.Forms.DateTimePicker();
            this._grid = new System.Windows.Forms.DataGridView();
            this._cboTrangThai = new System.Windows.Forms.ComboBox();
            this._txtLyDo = new System.Windows.Forms.TextBox();
            this.root = new System.Windows.Forms.TableLayoutPanel();
            this.top = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTai = new System.Windows.Forms.Button();
            this.bottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLuu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.root.SuspendLayout();
            this.top.SuspendLayout();
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
            this._lblTitle.Text = "Điểm danh và báo cáo chuyên cần";
            this._lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblDesigner4
            // 
            this._lblDesigner4.AutoSize = true;
            this._lblDesigner4.Location = new System.Drawing.Point(300, 8);
            this._lblDesigner4.Name = "_lblDesigner4";
            this._lblDesigner4.Size = new System.Drawing.Size(60, 13);
            this._lblDesigner4.TabIndex = 2;
            this._lblDesigner4.Text = "Lý do vắng";
            // 
            // _lblDesigner3
            // 
            this._lblDesigner3.AutoSize = true;
            this._lblDesigner3.Location = new System.Drawing.Point(11, 8);
            this._lblDesigner3.Name = "_lblDesigner3";
            this._lblDesigner3.Size = new System.Drawing.Size(55, 13);
            this._lblDesigner3.TabIndex = 0;
            this._lblDesigner3.Text = "Trạng thái";
            // 
            // _lblDesigner2
            // 
            this._lblDesigner2.AutoSize = true;
            this._lblDesigner2.Location = new System.Drawing.Point(270, 8);
            this._lblDesigner2.Name = "_lblDesigner2";
            this._lblDesigner2.Size = new System.Drawing.Size(53, 13);
            this._lblDesigner2.TabIndex = 2;
            this._lblDesigner2.Text = "Ngày học";
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
            // _dtNgay
            // 
            this._dtNgay.CustomFormat = "dd/MM/yyyy";
            this._dtNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtNgay.Location = new System.Drawing.Point(329, 11);
            this._dtNgay.Name = "_dtNgay";
            this._dtNgay.Size = new System.Drawing.Size(150, 20);
            this._dtNgay.TabIndex = 3;
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
            this._grid.Location = new System.Drawing.Point(3, 119);
            this._grid.MinimumSize = new System.Drawing.Size(320, 180);
            this._grid.MultiSelect = false;
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.RowTemplate.Height = 30;
            this._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._grid.Size = new System.Drawing.Size(1094, 534);
            this._grid.TabIndex = 2;
            // 
            // _cboTrangThai
            // 
            this._cboTrangThai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._cboTrangThai.BackColor = System.Drawing.Color.White;
            this._cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboTrangThai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cboTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._cboTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._cboTrangThai.Items.AddRange(new object[] {
            "Có mặt",
            "Vắng",
            "Đi trễ"});
            this._cboTrangThai.Location = new System.Drawing.Point(73, 17);
            this._cboTrangThai.Margin = new System.Windows.Forms.Padding(4);
            this._cboTrangThai.MinimumSize = new System.Drawing.Size(150, 0);
            this._cboTrangThai.Name = "_cboTrangThai";
            this._cboTrangThai.Size = new System.Drawing.Size(220, 23);
            this._cboTrangThai.TabIndex = 1;
            // 
            // _txtLyDo
            // 
            this._txtLyDo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtLyDo.BackColor = System.Drawing.Color.White;
            this._txtLyDo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtLyDo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtLyDo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._txtLyDo.Location = new System.Drawing.Point(367, 17);
            this._txtLyDo.Margin = new System.Windows.Forms.Padding(4);
            this._txtLyDo.MinimumSize = new System.Drawing.Size(150, 2);
            this._txtLyDo.Name = "_txtLyDo";
            this._txtLyDo.Size = new System.Drawing.Size(320, 23);
            this._txtLyDo.TabIndex = 3;
            // 
            // root
            // 
            this.root.ColumnCount = 1;
            this.root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.root.Controls.Add(this._lblTitle, 0, 0);
            this.root.Controls.Add(this.top, 0, 1);
            this.root.Controls.Add(this._grid, 0, 2);
            this.root.Controls.Add(this.bottom, 0, 3);
            this.root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.root.Location = new System.Drawing.Point(0, 0);
            this.root.Name = "root";
            this.root.RowCount = 4;
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.root.Size = new System.Drawing.Size(1100, 720);
            this.root.TabIndex = 0;
            // 
            // top
            // 
            this.top.AutoSize = true;
            this.top.Controls.Add(this._lblDesigner1);
            this.top.Controls.Add(this._cboLop);
            this.top.Controls.Add(this._lblDesigner2);
            this.top.Controls.Add(this._dtNgay);
            this.top.Controls.Add(this.btnTai);
            this.top.Dock = System.Windows.Forms.DockStyle.Top;
            this.top.Location = new System.Drawing.Point(3, 55);
            this.top.Name = "top";
            this.top.Padding = new System.Windows.Forms.Padding(8);
            this.top.Size = new System.Drawing.Size(1094, 58);
            this.top.TabIndex = 1;
            // 
            // btnTai
            // 
            this.btnTai.AutoEllipsis = true;
            this.btnTai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.btnTai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnTai.Location = new System.Drawing.Point(486, 12);
            this.btnTai.Margin = new System.Windows.Forms.Padding(4);
            this.btnTai.Name = "btnTai";
            this.btnTai.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnTai.Size = new System.Drawing.Size(110, 34);
            this.btnTai.TabIndex = 4;
            this.btnTai.Text = "Tải lớp";
            this.btnTai.UseVisualStyleBackColor = false;
            // 
            // bottom
            // 
            this.bottom.AutoSize = true;
            this.bottom.Controls.Add(this._lblDesigner3);
            this.bottom.Controls.Add(this._cboTrangThai);
            this.bottom.Controls.Add(this._lblDesigner4);
            this.bottom.Controls.Add(this._txtLyDo);
            this.bottom.Controls.Add(this.btnLuu);
            this.bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottom.Location = new System.Drawing.Point(3, 659);
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
            this.btnLuu.Location = new System.Drawing.Point(695, 12);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnLuu.Size = new System.Drawing.Size(140, 34);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu điểm danh";
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // FrmDiemDanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Controls.Add(this.root);
            this.Name = "FrmDiemDanh";
            this.Text = "Điểm danh";
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.root.ResumeLayout(false);
            this.root.PerformLayout();
            this.top.ResumeLayout(false);
            this.top.PerformLayout();
            this.bottom.ResumeLayout(false);
            this.bottom.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
    }
}
