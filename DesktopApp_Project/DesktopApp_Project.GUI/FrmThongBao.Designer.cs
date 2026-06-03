namespace DesktopApp_Project.GUI
{
    partial class FrmThongBao
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label _lblTitle;
        private System.Windows.Forms.Label _lblDesigner3;
        private System.Windows.Forms.Label _lblDesigner2;
        private System.Windows.Forms.Label _lblDesigner1;
        private System.Windows.Forms.TableLayoutPanel root;
        private System.Windows.Forms.TableLayoutPanel form;
        private System.Windows.Forms.Button btnGui;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.ComboBox _cboLop;
        private System.Windows.Forms.CheckBox _chkTatCa;
        private System.Windows.Forms.TextBox _txtTieuDe;
        private System.Windows.Forms.TextBox _txtNoiDung;

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
            this._grid = new System.Windows.Forms.DataGridView();
            this._cboLop = new System.Windows.Forms.ComboBox();
            this._chkTatCa = new System.Windows.Forms.CheckBox();
            this._txtTieuDe = new System.Windows.Forms.TextBox();
            this._txtNoiDung = new System.Windows.Forms.TextBox();
            this.root = new System.Windows.Forms.TableLayoutPanel();
            this.form = new System.Windows.Forms.TableLayoutPanel();
            this.btnGui = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.root.SuspendLayout();
            this.form.SuspendLayout();
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
            this._lblTitle.Text = "Thông báo";
            this._lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblDesigner3
            // 
            this._lblDesigner3.AutoSize = true;
            this._lblDesigner3.Location = new System.Drawing.Point(15, 41);
            this._lblDesigner3.Name = "_lblDesigner3";
            this._lblDesigner3.Size = new System.Drawing.Size(50, 13);
            this._lblDesigner3.TabIndex = 4;
            this._lblDesigner3.Text = "Nội dung";
            // 
            // _lblDesigner2
            // 
            this._lblDesigner2.AutoSize = true;
            this._lblDesigner2.Location = new System.Drawing.Point(519, 10);
            this._lblDesigner2.Name = "_lblDesigner2";
            this._lblDesigner2.Size = new System.Drawing.Size(52, 13);
            this._lblDesigner2.TabIndex = 2;
            this._lblDesigner2.Text = "Lớp nhận";
            // 
            // _lblDesigner1
            // 
            this._lblDesigner1.AutoSize = true;
            this._lblDesigner1.Location = new System.Drawing.Point(15, 10);
            this._lblDesigner1.Name = "_lblDesigner1";
            this._lblDesigner1.Size = new System.Drawing.Size(44, 13);
            this._lblDesigner1.TabIndex = 0;
            this._lblDesigner1.Text = "Tiêu đề";
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
            this._grid.Location = new System.Drawing.Point(3, 209);
            this._grid.MinimumSize = new System.Drawing.Size(320, 180);
            this._grid.MultiSelect = false;
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.RowTemplate.Height = 30;
            this._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._grid.Size = new System.Drawing.Size(1094, 508);
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
            this._cboLop.Location = new System.Drawing.Point(644, 14);
            this._cboLop.Margin = new System.Windows.Forms.Padding(4);
            this._cboLop.MinimumSize = new System.Drawing.Size(150, 0);
            this._cboLop.Name = "_cboLop";
            this._cboLop.Size = new System.Drawing.Size(440, 23);
            this._cboLop.TabIndex = 3;
            // 
            // _chkTatCa
            // 
            this._chkTatCa.AutoSize = true;
            this._chkTatCa.Checked = true;
            this._chkTatCa.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkTatCa.Location = new System.Drawing.Point(520, 49);
            this._chkTatCa.Margin = new System.Windows.Forms.Padding(4, 8, 4, 2);
            this._chkTatCa.Name = "_chkTatCa";
            this._chkTatCa.Size = new System.Drawing.Size(116, 17);
            this._chkTatCa.TabIndex = 6;
            this._chkTatCa.Text = "Gửi tất cả học viên";
            // 
            // _txtTieuDe
            // 
            this._txtTieuDe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTieuDe.BackColor = System.Drawing.Color.White;
            this._txtTieuDe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtTieuDe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._txtTieuDe.Location = new System.Drawing.Point(72, 14);
            this._txtTieuDe.Margin = new System.Windows.Forms.Padding(4);
            this._txtTieuDe.MinimumSize = new System.Drawing.Size(150, 2);
            this._txtTieuDe.Name = "_txtTieuDe";
            this._txtTieuDe.Size = new System.Drawing.Size(440, 23);
            this._txtTieuDe.TabIndex = 1;
            // 
            // _txtNoiDung
            // 
            this._txtNoiDung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtNoiDung.BackColor = System.Drawing.Color.White;
            this._txtNoiDung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtNoiDung.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtNoiDung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._txtNoiDung.Location = new System.Drawing.Point(72, 45);
            this._txtNoiDung.Margin = new System.Windows.Forms.Padding(4);
            this._txtNoiDung.MinimumSize = new System.Drawing.Size(260, 2);
            this._txtNoiDung.Multiline = true;
            this._txtNoiDung.Name = "_txtNoiDung";
            this._txtNoiDung.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtNoiDung.Size = new System.Drawing.Size(440, 95);
            this._txtNoiDung.TabIndex = 5;
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
            this.form.Controls.Add(this._txtTieuDe, 1, 0);
            this.form.Controls.Add(this._lblDesigner2, 2, 0);
            this.form.Controls.Add(this._cboLop, 3, 0);
            this.form.Controls.Add(this._lblDesigner3, 0, 1);
            this.form.Controls.Add(this._txtNoiDung, 1, 1);
            this.form.Controls.Add(this._chkTatCa, 2, 1);
            this.form.Controls.Add(this.btnGui, 3, 1);
            this.form.Dock = System.Windows.Forms.DockStyle.Top;
            this.form.Location = new System.Drawing.Point(0, 52);
            this.form.Margin = new System.Windows.Forms.Padding(0);
            this.form.Name = "form";
            this.form.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.form.Size = new System.Drawing.Size(1100, 154);
            this.form.TabIndex = 1;
            // 
            // btnGui
            // 
            this.btnGui.AutoEllipsis = true;
            this.btnGui.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.btnGui.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGui.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGui.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGui.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnGui.Location = new System.Drawing.Point(644, 45);
            this.btnGui.Margin = new System.Windows.Forms.Padding(4);
            this.btnGui.Name = "btnGui";
            this.btnGui.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnGui.Size = new System.Drawing.Size(110, 29);
            this.btnGui.TabIndex = 7;
            this.btnGui.Text = "Gửi";
            this.btnGui.UseVisualStyleBackColor = false;
            // 
            // FrmThongBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Controls.Add(this.root);
            this.Name = "FrmThongBao";
            this.Text = "Thông báo";
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.root.ResumeLayout(false);
            this.root.PerformLayout();
            this.form.ResumeLayout(false);
            this.form.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
    }
}
