namespace DesktopApp_Project.GUI
{
    partial class FrmDeThi
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
        private System.Windows.Forms.Button btnMoi;
        private System.Windows.Forms.Button btnLuuCau;
        private System.Windows.Forms.Button btnXoaCau;
        private System.Windows.Forms.Button btnTaoDe;
        private System.Windows.Forms.Button btnThemVaoDe;
        private System.Windows.Forms.DataGridView _gridCauHoi;
        private System.Windows.Forms.DataGridView _gridDeThi;
        private System.Windows.Forms.ComboBox _cboKyNang;
        private System.Windows.Forms.TextBox _txtNoiDung;
        private System.Windows.Forms.TextBox _txtDapAn;
        private System.Windows.Forms.TextBox _txtTenDe;

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
            this._gridCauHoi = new System.Windows.Forms.DataGridView();
            this._gridDeThi = new System.Windows.Forms.DataGridView();
            this._cboKyNang = new System.Windows.Forms.ComboBox();
            this._txtNoiDung = new System.Windows.Forms.TextBox();
            this._txtDapAn = new System.Windows.Forms.TextBox();
            this._txtTenDe = new System.Windows.Forms.TextBox();
            this.root = new System.Windows.Forms.TableLayoutPanel();
            this.form = new System.Windows.Forms.TableLayoutPanel();
            this.buttons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMoi = new System.Windows.Forms.Button();
            this.btnLuuCau = new System.Windows.Forms.Button();
            this.btnXoaCau = new System.Windows.Forms.Button();
            this.btnTaoDe = new System.Windows.Forms.Button();
            this.btnThemVaoDe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._gridCauHoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridDeThi)).BeginInit();
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
            this._lblTitle.Text = "Tạo đề thi IELTS";
            this._lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblDesigner4
            // 
            this._lblDesigner4.AutoSize = true;
            this._lblDesigner4.Location = new System.Drawing.Point(569, 41);
            this._lblDesigner4.Name = "_lblDesigner4";
            this._lblDesigner4.Size = new System.Drawing.Size(42, 13);
            this._lblDesigner4.TabIndex = 6;
            this._lblDesigner4.Text = "Đáp án";
            // 
            // _lblDesigner3
            // 
            this._lblDesigner3.AutoSize = true;
            this._lblDesigner3.Location = new System.Drawing.Point(15, 41);
            this._lblDesigner3.Name = "_lblDesigner3";
            this._lblDesigner3.Size = new System.Drawing.Size(88, 13);
            this._lblDesigner3.TabIndex = 4;
            this._lblDesigner3.Text = "Nội dung câu hỏi";
            // 
            // _lblDesigner2
            // 
            this._lblDesigner2.AutoSize = true;
            this._lblDesigner2.Location = new System.Drawing.Point(569, 10);
            this._lblDesigner2.Name = "_lblDesigner2";
            this._lblDesigner2.Size = new System.Drawing.Size(56, 13);
            this._lblDesigner2.TabIndex = 2;
            this._lblDesigner2.Text = "Tên đề thi";
            // 
            // _lblDesigner1
            // 
            this._lblDesigner1.AutoSize = true;
            this._lblDesigner1.Location = new System.Drawing.Point(15, 10);
            this._lblDesigner1.Name = "_lblDesigner1";
            this._lblDesigner1.Size = new System.Drawing.Size(46, 13);
            this._lblDesigner1.TabIndex = 0;
            this._lblDesigner1.Text = "Kỹ năng";
            // 
            // _gridCauHoi
            // 
            this._gridCauHoi.AllowUserToAddRows = false;
            this._gridCauHoi.AllowUserToDeleteRows = false;
            this._gridCauHoi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._gridCauHoi.BackgroundColor = System.Drawing.Color.White;
            this._gridCauHoi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._gridCauHoi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._gridCauHoi.ColumnHeadersHeight = 34;
            this._gridCauHoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gridCauHoi.EnableHeadersVisualStyles = false;
            this._gridCauHoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._gridCauHoi.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this._gridCauHoi.Location = new System.Drawing.Point(3, 237);
            this._gridCauHoi.MinimumSize = new System.Drawing.Size(320, 180);
            this._gridCauHoi.MultiSelect = false;
            this._gridCauHoi.Name = "_gridCauHoi";
            this._gridCauHoi.ReadOnly = true;
            this._gridCauHoi.RowHeadersVisible = false;
            this._gridCauHoi.RowTemplate.Height = 30;
            this._gridCauHoi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._gridCauHoi.Size = new System.Drawing.Size(1094, 261);
            this._gridCauHoi.TabIndex = 2;
            // 
            // _gridDeThi
            // 
            this._gridDeThi.AllowUserToAddRows = false;
            this._gridDeThi.AllowUserToDeleteRows = false;
            this._gridDeThi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._gridDeThi.BackgroundColor = System.Drawing.Color.White;
            this._gridDeThi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._gridDeThi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._gridDeThi.ColumnHeadersHeight = 34;
            this._gridDeThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gridDeThi.EnableHeadersVisualStyles = false;
            this._gridDeThi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._gridDeThi.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this._gridDeThi.Location = new System.Drawing.Point(3, 504);
            this._gridDeThi.MinimumSize = new System.Drawing.Size(320, 180);
            this._gridDeThi.MultiSelect = false;
            this._gridDeThi.Name = "_gridDeThi";
            this._gridDeThi.ReadOnly = true;
            this._gridDeThi.RowHeadersVisible = false;
            this._gridDeThi.RowTemplate.Height = 30;
            this._gridDeThi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._gridDeThi.Size = new System.Drawing.Size(1094, 213);
            this._gridDeThi.TabIndex = 3;
            // 
            // _cboKyNang
            // 
            this._cboKyNang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._cboKyNang.BackColor = System.Drawing.Color.White;
            this._cboKyNang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboKyNang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cboKyNang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._cboKyNang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._cboKyNang.Location = new System.Drawing.Point(110, 14);
            this._cboKyNang.Margin = new System.Windows.Forms.Padding(4);
            this._cboKyNang.MinimumSize = new System.Drawing.Size(150, 0);
            this._cboKyNang.Name = "_cboKyNang";
            this._cboKyNang.Size = new System.Drawing.Size(452, 23);
            this._cboKyNang.TabIndex = 1;
            // 
            // _txtNoiDung
            // 
            this._txtNoiDung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtNoiDung.BackColor = System.Drawing.Color.White;
            this._txtNoiDung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtNoiDung.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtNoiDung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._txtNoiDung.Location = new System.Drawing.Point(110, 45);
            this._txtNoiDung.Margin = new System.Windows.Forms.Padding(4);
            this._txtNoiDung.MinimumSize = new System.Drawing.Size(240, 2);
            this._txtNoiDung.Multiline = true;
            this._txtNoiDung.Name = "_txtNoiDung";
            this._txtNoiDung.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtNoiDung.Size = new System.Drawing.Size(452, 33);
            this._txtNoiDung.TabIndex = 5;
            // 
            // _txtDapAn
            // 
            this._txtDapAn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtDapAn.BackColor = System.Drawing.Color.White;
            this._txtDapAn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtDapAn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtDapAn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._txtDapAn.Location = new System.Drawing.Point(632, 45);
            this._txtDapAn.Margin = new System.Windows.Forms.Padding(4);
            this._txtDapAn.MinimumSize = new System.Drawing.Size(240, 2);
            this._txtDapAn.Multiline = true;
            this._txtDapAn.Name = "_txtDapAn";
            this._txtDapAn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtDapAn.Size = new System.Drawing.Size(452, 32);
            this._txtDapAn.TabIndex = 7;
            // 
            // _txtTenDe
            // 
            this._txtTenDe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTenDe.BackColor = System.Drawing.Color.White;
            this._txtTenDe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtTenDe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtTenDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._txtTenDe.Location = new System.Drawing.Point(632, 14);
            this._txtTenDe.Margin = new System.Windows.Forms.Padding(4);
            this._txtTenDe.MinimumSize = new System.Drawing.Size(150, 2);
            this._txtTenDe.Name = "_txtTenDe";
            this._txtTenDe.Size = new System.Drawing.Size(452, 23);
            this._txtTenDe.TabIndex = 3;
            // 
            // root
            // 
            this.root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1100F));
            this.root.Controls.Add(this._lblTitle, 0, 0);
            this.root.Controls.Add(this.form, 0, 1);
            this.root.Controls.Add(this._gridCauHoi, 0, 2);
            this.root.Controls.Add(this._gridDeThi, 0, 3);
            this.root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.root.Location = new System.Drawing.Point(0, 0);
            this.root.Name = "root";
            this.root.RowCount = 4;
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
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
            this.form.Controls.Add(this._cboKyNang, 1, 0);
            this.form.Controls.Add(this._lblDesigner2, 2, 0);
            this.form.Controls.Add(this._txtTenDe, 3, 0);
            this.form.Controls.Add(this._lblDesigner3, 0, 1);
            this.form.Controls.Add(this._txtNoiDung, 1, 1);
            this.form.Controls.Add(this._lblDesigner4, 2, 1);
            this.form.Controls.Add(this._txtDapAn, 3, 1);
            this.form.Controls.Add(this.buttons, 3, 2);
            this.form.Dock = System.Windows.Forms.DockStyle.Top;
            this.form.Location = new System.Drawing.Point(0, 52);
            this.form.Margin = new System.Windows.Forms.Padding(0);
            this.form.Name = "form";
            this.form.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.form.Size = new System.Drawing.Size(1100, 182);
            this.form.TabIndex = 1;
            // 
            // buttons
            // 
            this.buttons.AutoSize = true;
            this.buttons.Controls.Add(this.btnMoi);
            this.buttons.Controls.Add(this.btnLuuCau);
            this.buttons.Controls.Add(this.btnXoaCau);
            this.buttons.Controls.Add(this.btnTaoDe);
            this.buttons.Controls.Add(this.btnThemVaoDe);
            this.buttons.Location = new System.Drawing.Point(631, 85);
            this.buttons.Name = "buttons";
            this.buttons.Size = new System.Drawing.Size(354, 84);
            this.buttons.TabIndex = 8;
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
            // btnLuuCau
            // 
            this.btnLuuCau.AutoEllipsis = true;
            this.btnLuuCau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.btnLuuCau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuuCau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuCau.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLuuCau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnLuuCau.Location = new System.Drawing.Point(122, 4);
            this.btnLuuCau.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuuCau.Name = "btnLuuCau";
            this.btnLuuCau.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnLuuCau.Size = new System.Drawing.Size(110, 34);
            this.btnLuuCau.TabIndex = 1;
            this.btnLuuCau.Text = "Lưu câu hỏi";
            this.btnLuuCau.UseVisualStyleBackColor = false;
            // 
            // btnXoaCau
            // 
            this.btnXoaCau.AutoEllipsis = true;
            this.btnXoaCau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.btnXoaCau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaCau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaCau.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXoaCau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnXoaCau.Location = new System.Drawing.Point(240, 4);
            this.btnXoaCau.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoaCau.Name = "btnXoaCau";
            this.btnXoaCau.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnXoaCau.Size = new System.Drawing.Size(110, 34);
            this.btnXoaCau.TabIndex = 2;
            this.btnXoaCau.Text = "Xóa câu hỏi";
            this.btnXoaCau.UseVisualStyleBackColor = false;
            // 
            // btnTaoDe
            // 
            this.btnTaoDe.AutoEllipsis = true;
            this.btnTaoDe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.btnTaoDe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaoDe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoDe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTaoDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnTaoDe.Location = new System.Drawing.Point(4, 46);
            this.btnTaoDe.Margin = new System.Windows.Forms.Padding(4);
            this.btnTaoDe.Name = "btnTaoDe";
            this.btnTaoDe.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnTaoDe.Size = new System.Drawing.Size(110, 34);
            this.btnTaoDe.TabIndex = 3;
            this.btnTaoDe.Text = "Tạo đề";
            this.btnTaoDe.UseVisualStyleBackColor = false;
            // 
            // btnThemVaoDe
            // 
            this.btnThemVaoDe.AutoEllipsis = true;
            this.btnThemVaoDe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.btnThemVaoDe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemVaoDe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemVaoDe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThemVaoDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnThemVaoDe.Location = new System.Drawing.Point(122, 46);
            this.btnThemVaoDe.Margin = new System.Windows.Forms.Padding(4);
            this.btnThemVaoDe.Name = "btnThemVaoDe";
            this.btnThemVaoDe.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnThemVaoDe.Size = new System.Drawing.Size(120, 34);
            this.btnThemVaoDe.TabIndex = 4;
            this.btnThemVaoDe.Text = "Gắn vào đề";
            this.btnThemVaoDe.UseVisualStyleBackColor = false;
            // 
            // FrmDeThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Controls.Add(this.root);
            this.Name = "FrmDeThi";
            ((System.ComponentModel.ISupportInitialize)(this._gridCauHoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridDeThi)).EndInit();
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
