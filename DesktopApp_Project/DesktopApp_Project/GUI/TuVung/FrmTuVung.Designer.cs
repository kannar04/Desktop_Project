namespace DesktopApp_Project.GUI
{
    partial class FrmTuVung
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label _lblTitle;
        private System.Windows.Forms.Label _lblDesigner5;
        private System.Windows.Forms.Label _lblDesigner4;
        private System.Windows.Forms.Label _lblDesigner3;
        private System.Windows.Forms.Label _lblDesigner2;
        private System.Windows.Forms.Label _lblDesigner1;
        private System.Windows.Forms.TableLayoutPanel root;
        private System.Windows.Forms.TableLayoutPanel form;
        private System.Windows.Forms.FlowLayoutPanel buttons;
        private System.Windows.Forms.Button btnMoi;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.ComboBox _cboLop;
        private System.Windows.Forms.TextBox _txtTu;
        private System.Windows.Forms.TextBox _txtLoai;
        private System.Windows.Forms.TextBox _txtPhienAm;
        private System.Windows.Forms.TextBox _txtNghia;

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
            this._lblDesigner5 = new System.Windows.Forms.Label();
            this._lblDesigner4 = new System.Windows.Forms.Label();
            this._lblDesigner3 = new System.Windows.Forms.Label();
            this._lblDesigner2 = new System.Windows.Forms.Label();
            this._lblDesigner1 = new System.Windows.Forms.Label();
            this._grid = new System.Windows.Forms.DataGridView();
            this._cboLop = new System.Windows.Forms.ComboBox();
            this._txtTu = new System.Windows.Forms.TextBox();
            this._txtLoai = new System.Windows.Forms.TextBox();
            this._txtPhienAm = new System.Windows.Forms.TextBox();
            this._txtNghia = new System.Windows.Forms.TextBox();
            this.root = new System.Windows.Forms.TableLayoutPanel();
            this.form = new System.Windows.Forms.TableLayoutPanel();
            this.buttons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMoi = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.root.SuspendLayout();
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
            this._lblTitle.Text = "Cập nhật kho từ vựng";
            this._lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblDesigner5
            // 
            this._lblDesigner5.AutoSize = true;
            this._lblDesigner5.Location = new System.Drawing.Point(15, 72);
            this._lblDesigner5.Name = "_lblDesigner5";
            this._lblDesigner5.Size = new System.Drawing.Size(38, 13);
            this._lblDesigner5.TabIndex = 8;
            this._lblDesigner5.Text = "Nghĩa";
            // 
            // _lblDesigner4
            // 
            this._lblDesigner4.AutoSize = true;
            this._lblDesigner4.Location = new System.Drawing.Point(538, 41);
            this._lblDesigner4.Name = "_lblDesigner4";
            this._lblDesigner4.Size = new System.Drawing.Size(51, 13);
            this._lblDesigner4.TabIndex = 6;
            this._lblDesigner4.Text = "Phiên âm";
            // 
            // _lblDesigner3
            // 
            this._lblDesigner3.AutoSize = true;
            this._lblDesigner3.Location = new System.Drawing.Point(15, 41);
            this._lblDesigner3.Name = "_lblDesigner3";
            this._lblDesigner3.Size = new System.Drawing.Size(39, 13);
            this._lblDesigner3.TabIndex = 4;
            this._lblDesigner3.Text = "Từ loại";
            // 
            // _lblDesigner2
            // 
            this._lblDesigner2.AutoSize = true;
            this._lblDesigner2.Location = new System.Drawing.Point(538, 10);
            this._lblDesigner2.Name = "_lblDesigner2";
            this._lblDesigner2.Size = new System.Drawing.Size(68, 13);
            this._lblDesigner2.TabIndex = 2;
            this._lblDesigner2.Text = "Từ tiếng Anh";
            // 
            // _lblDesigner1
            // 
            this._lblDesigner1.AutoSize = true;
            this._lblDesigner1.Location = new System.Drawing.Point(15, 10);
            this._lblDesigner1.Name = "_lblDesigner1";
            this._lblDesigner1.Size = new System.Drawing.Size(25, 13);
            this._lblDesigner1.TabIndex = 0;
            this._lblDesigner1.Text = "Lớp";
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
            // _cboLop
            // 
            this._cboLop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._cboLop.BackColor = System.Drawing.Color.White;
            this._cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboLop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cboLop.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._cboLop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._cboLop.Location = new System.Drawing.Point(61, 14);
            this._cboLop.Margin = new System.Windows.Forms.Padding(4);
            this._cboLop.MinimumSize = new System.Drawing.Size(150, 0);
            this._cboLop.Name = "_cboLop";
            this._cboLop.Size = new System.Drawing.Size(470, 23);
            this._cboLop.TabIndex = 1;
            // 
            // _txtTu
            // 
            this._txtTu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTu.BackColor = System.Drawing.Color.White;
            this._txtTu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtTu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtTu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._txtTu.Location = new System.Drawing.Point(613, 14);
            this._txtTu.Margin = new System.Windows.Forms.Padding(4);
            this._txtTu.MinimumSize = new System.Drawing.Size(150, 2);
            this._txtTu.Name = "_txtTu";
            this._txtTu.Size = new System.Drawing.Size(471, 23);
            this._txtTu.TabIndex = 3;
            // 
            // _txtLoai
            // 
            this._txtLoai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtLoai.BackColor = System.Drawing.Color.White;
            this._txtLoai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtLoai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._txtLoai.Location = new System.Drawing.Point(61, 45);
            this._txtLoai.Margin = new System.Windows.Forms.Padding(4);
            this._txtLoai.MinimumSize = new System.Drawing.Size(150, 2);
            this._txtLoai.Name = "_txtLoai";
            this._txtLoai.Size = new System.Drawing.Size(470, 23);
            this._txtLoai.TabIndex = 5;
            // 
            // _txtPhienAm
            // 
            this._txtPhienAm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtPhienAm.BackColor = System.Drawing.Color.White;
            this._txtPhienAm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtPhienAm.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtPhienAm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._txtPhienAm.Location = new System.Drawing.Point(613, 45);
            this._txtPhienAm.Margin = new System.Windows.Forms.Padding(4);
            this._txtPhienAm.MinimumSize = new System.Drawing.Size(150, 2);
            this._txtPhienAm.Name = "_txtPhienAm";
            this._txtPhienAm.Size = new System.Drawing.Size(471, 23);
            this._txtPhienAm.TabIndex = 7;
            // 
            // _txtNghia
            // 
            this._txtNghia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtNghia.BackColor = System.Drawing.Color.White;
            this._txtNghia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtNghia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtNghia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._txtNghia.Location = new System.Drawing.Point(61, 84);
            this._txtNghia.Margin = new System.Windows.Forms.Padding(4);
            this._txtNghia.MinimumSize = new System.Drawing.Size(150, 2);
            this._txtNghia.Name = "_txtNghia";
            this._txtNghia.Size = new System.Drawing.Size(470, 23);
            this._txtNghia.TabIndex = 9;
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
            this.form.Controls.Add(this._cboLop, 1, 0);
            this.form.Controls.Add(this._lblDesigner2, 2, 0);
            this.form.Controls.Add(this._txtTu, 3, 0);
            this.form.Controls.Add(this._lblDesigner3, 0, 1);
            this.form.Controls.Add(this._txtLoai, 1, 1);
            this.form.Controls.Add(this._lblDesigner4, 2, 1);
            this.form.Controls.Add(this._txtPhienAm, 3, 1);
            this.form.Controls.Add(this._lblDesigner5, 0, 2);
            this.form.Controls.Add(this._txtNghia, 1, 2);
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
            // buttons
            // 
            this.buttons.AutoSize = true;
            this.buttons.Controls.Add(this.btnMoi);
            this.buttons.Controls.Add(this.btnLuu);
            this.buttons.Controls.Add(this.btnXoa);
            this.buttons.Location = new System.Drawing.Point(612, 75);
            this.buttons.Name = "buttons";
            this.buttons.Size = new System.Drawing.Size(354, 42);
            this.buttons.TabIndex = 10;
            // 
            // btnMoi
            // 
            this.btnMoi.AutoEllipsis = true;
            this.btnMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.btnMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnMoi.Location = new System.Drawing.Point(4, 4);
            this.btnMoi.Margin = new System.Windows.Forms.Padding(4);
            this.btnMoi.Name = "btnMoi";
            this.btnMoi.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnMoi.Size = new System.Drawing.Size(110, 34);
            this.btnMoi.TabIndex = 0;
            this.btnMoi.Text = "Thêm mới";
            this.btnMoi.UseVisualStyleBackColor = false;
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
            // FrmTuVung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Controls.Add(this.root);
            this.Name = "FrmTuVung";
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.root.ResumeLayout(false);
            this.root.PerformLayout();
            this.form.ResumeLayout(false);
            this.form.PerformLayout();
            this.buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
    }
}
