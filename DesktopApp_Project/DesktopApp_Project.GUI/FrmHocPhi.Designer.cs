namespace DesktopApp_Project.GUI
{
    partial class FrmHocPhi
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label _lblTitle;
        private System.Windows.Forms.Label _lblDesigner4;
        private System.Windows.Forms.Label _lblDesigner3;
        private System.Windows.Forms.Label _lblDesigner2;
        private System.Windows.Forms.Label _lblDesigner1;
        private System.Windows.Forms.TableLayoutPanel root;
        private System.Windows.Forms.TableLayoutPanel form;
        private System.Windows.Forms.FlowLayoutPanel buttons;
        private System.Windows.Forms.Button btnTao;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.ComboBox _cboHocVien;
        private System.Windows.Forms.NumericUpDown _numSoTien;
        private System.Windows.Forms.TextBox _txtNganHang;
        private System.Windows.Forms.ComboBox _cboTrangThai;

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
            this.root = new System.Windows.Forms.TableLayoutPanel();
            this._lblTitle = new System.Windows.Forms.Label();
            this.form = new System.Windows.Forms.TableLayoutPanel();
            this._lblDesigner1 = new System.Windows.Forms.Label();
            this._cboHocVien = new System.Windows.Forms.ComboBox();
            this._lblDesigner2 = new System.Windows.Forms.Label();
            this._numSoTien = new System.Windows.Forms.NumericUpDown();
            this._lblDesigner3 = new System.Windows.Forms.Label();
            this._txtNganHang = new System.Windows.Forms.TextBox();
            this._lblDesigner4 = new System.Windows.Forms.Label();
            this._cboTrangThai = new System.Windows.Forms.ComboBox();
            this.buttons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTao = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this._grid = new System.Windows.Forms.DataGridView();
            this.root.SuspendLayout();
            this.form.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numSoTien)).BeginInit();
            this.buttons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();
            // 
            // root
            // 
            this.root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1100F));
            this.root.Controls.Add(this._lblTitle, 0, 0);
            this.root.Controls.Add(this.form, 0, 1);
            this.root.Controls.Add(this._grid, 0, 2);
            this.root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.root.Location = new System.Drawing.Point(0, 0);
            this.root.Name = "root";
            this.root.RowCount = 3;
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.root.Size = new System.Drawing.Size(1100, 720);
            this.root.TabIndex = 0;
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
            this._lblTitle.Text = "Thanh toán học phí";
            this._lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.form.Controls.Add(this._cboHocVien, 1, 0);
            this.form.Controls.Add(this._lblDesigner2, 2, 0);
            this.form.Controls.Add(this._numSoTien, 3, 0);
            this.form.Controls.Add(this._lblDesigner3, 0, 1);
            this.form.Controls.Add(this._txtNganHang, 1, 1);
            this.form.Controls.Add(this._lblDesigner4, 2, 1);
            this.form.Controls.Add(this._cboTrangThai, 3, 1);
            this.form.Controls.Add(this.buttons, 3, 2);
            this.form.Dock = System.Windows.Forms.DockStyle.Top;
            this.form.Location = new System.Drawing.Point(0, 52);
            this.form.Margin = new System.Windows.Forms.Padding(0);
            this.form.Name = "form";
            this.form.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.form.Size = new System.Drawing.Size(1100, 130);
            this.form.TabIndex = 1;
            // 
            // _lblDesigner1
            // 
            this._lblDesigner1.AutoSize = true;
            this._lblDesigner1.Location = new System.Drawing.Point(15, 10);
            this._lblDesigner1.Name = "_lblDesigner1";
            this._lblDesigner1.Size = new System.Drawing.Size(50, 13);
            this._lblDesigner1.TabIndex = 0;
            this._lblDesigner1.Text = "Học viên";
            // 
            // _cboHocVien
            // 
            this._cboHocVien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._cboHocVien.BackColor = System.Drawing.Color.White;
            this._cboHocVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboHocVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cboHocVien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._cboHocVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._cboHocVien.Location = new System.Drawing.Point(128, 14);
            this._cboHocVien.Margin = new System.Windows.Forms.Padding(4);
            this._cboHocVien.MinimumSize = new System.Drawing.Size(150, 0);
            this._cboHocVien.Name = "_cboHocVien";
            this._cboHocVien.Size = new System.Drawing.Size(443, 23);
            this._cboHocVien.TabIndex = 1;
            // 
            // _lblDesigner2
            // 
            this._lblDesigner2.AutoSize = true;
            this._lblDesigner2.Location = new System.Drawing.Point(578, 10);
            this._lblDesigner2.Name = "_lblDesigner2";
            this._lblDesigner2.Size = new System.Drawing.Size(40, 13);
            this._lblDesigner2.TabIndex = 2;
            this._lblDesigner2.Text = "Số tiền";
            // 
            // _numSoTien
            // 
            this._numSoTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._numSoTien.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this._numSoTien.Location = new System.Drawing.Point(639, 15);
            this._numSoTien.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this._numSoTien.Name = "_numSoTien";
            this._numSoTien.Size = new System.Drawing.Size(446, 20);
            this._numSoTien.TabIndex = 3;
            // 
            // _lblDesigner3
            // 
            this._lblDesigner3.AutoSize = true;
            this._lblDesigner3.Location = new System.Drawing.Point(15, 41);
            this._lblDesigner3.Name = "_lblDesigner3";
            this._lblDesigner3.Size = new System.Drawing.Size(106, 13);
            this._lblDesigner3.TabIndex = 4;
            this._lblDesigner3.Text = "Thông tin ngân hàng";
            // 
            // _txtNganHang
            // 
            this._txtNganHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtNganHang.BackColor = System.Drawing.Color.White;
            this._txtNganHang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtNganHang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtNganHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._txtNganHang.Location = new System.Drawing.Point(128, 45);
            this._txtNganHang.Margin = new System.Windows.Forms.Padding(4);
            this._txtNganHang.MinimumSize = new System.Drawing.Size(150, 2);
            this._txtNganHang.Name = "_txtNganHang";
            this._txtNganHang.Size = new System.Drawing.Size(443, 23);
            this._txtNganHang.TabIndex = 5;
            // 
            // _lblDesigner4
            // 
            this._lblDesigner4.AutoSize = true;
            this._lblDesigner4.Location = new System.Drawing.Point(578, 41);
            this._lblDesigner4.Name = "_lblDesigner4";
            this._lblDesigner4.Size = new System.Drawing.Size(55, 13);
            this._lblDesigner4.TabIndex = 6;
            this._lblDesigner4.Text = "Trạng thái";
            // 
            // _cboTrangThai
            // 
            this._cboTrangThai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._cboTrangThai.BackColor = System.Drawing.Color.White;
            this._cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboTrangThai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cboTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._cboTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._cboTrangThai.Location = new System.Drawing.Point(640, 45);
            this._cboTrangThai.Margin = new System.Windows.Forms.Padding(4);
            this._cboTrangThai.MinimumSize = new System.Drawing.Size(150, 0);
            this._cboTrangThai.Name = "_cboTrangThai";
            this._cboTrangThai.Size = new System.Drawing.Size(444, 23);
            this._cboTrangThai.TabIndex = 7;
            // 
            // buttons
            // 
            this.buttons.AutoSize = true;
            this.buttons.Controls.Add(this.btnTao);
            this.buttons.Controls.Add(this.btnCapNhat);
            this.buttons.Location = new System.Drawing.Point(639, 75);
            this.buttons.Name = "buttons";
            this.buttons.Size = new System.Drawing.Size(256, 42);
            this.buttons.TabIndex = 8;
            // 
            // btnTao
            // 
            this.btnTao.AutoEllipsis = true;
            this.btnTao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.btnTao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnTao.Location = new System.Drawing.Point(4, 4);
            this.btnTao.Margin = new System.Windows.Forms.Padding(4);
            this.btnTao.Name = "btnTao";
            this.btnTao.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnTao.Size = new System.Drawing.Size(130, 34);
            this.btnTao.TabIndex = 0;
            this.btnTao.Text = "Tạo yêu cầu";
            this.btnTao.UseVisualStyleBackColor = false;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.AutoEllipsis = true;
            this.btnCapNhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.btnCapNhat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCapNhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCapNhat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnCapNhat.Location = new System.Drawing.Point(142, 4);
            this.btnCapNhat.Margin = new System.Windows.Forms.Padding(4);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnCapNhat.Size = new System.Drawing.Size(110, 34);
            this.btnCapNhat.TabIndex = 1;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = false;
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
            this._grid.Location = new System.Drawing.Point(3, 185);
            this._grid.MinimumSize = new System.Drawing.Size(320, 180);
            this._grid.MultiSelect = false;
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.RowTemplate.Height = 30;
            this._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._grid.Size = new System.Drawing.Size(1094, 532);
            this._grid.TabIndex = 2;
            // 
            // FrmHocPhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Controls.Add(this.root);
            this.Name = "FrmHocPhi";
            this.Text = "Học phí";
            this.root.ResumeLayout(false);
            this.root.PerformLayout();
            this.form.ResumeLayout(false);
            this.form.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numSoTien)).EndInit();
            this.buttons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
    }
}
