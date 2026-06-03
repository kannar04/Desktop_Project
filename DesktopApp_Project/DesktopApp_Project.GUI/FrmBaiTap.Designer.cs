namespace DesktopApp_Project.GUI
{
    partial class FrmBaiTap
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel _root;
        private System.Windows.Forms.Label _lblTitle;
        private System.Windows.Forms.TableLayoutPanel _form;
        private System.Windows.Forms.FlowLayoutPanel _buttons;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.ComboBox _cboLop;
        private System.Windows.Forms.TextBox _txtTieuDe;
        private System.Windows.Forms.TextBox _txtMoTa;
        private System.Windows.Forms.TextBox _txtFile;
        private System.Windows.Forms.DateTimePicker _dtDeadline;
        private System.Windows.Forms.Label _lblLop;
        private System.Windows.Forms.Label _lblDeadline;
        private System.Windows.Forms.Label _lblTieuDe;
        private System.Windows.Forms.Label _lblMoTa;
        private System.Windows.Forms.Label _lblFile;
        private System.Windows.Forms.Button btnMoi;
        private System.Windows.Forms.Button btnGiao;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnFile;

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
            this._root = new System.Windows.Forms.TableLayoutPanel();
            this._lblTitle = new System.Windows.Forms.Label();
            this._form = new System.Windows.Forms.TableLayoutPanel();
            this._buttons = new System.Windows.Forms.FlowLayoutPanel();
            this._grid = new System.Windows.Forms.DataGridView();
            this._cboLop = new System.Windows.Forms.ComboBox();
            this._txtTieuDe = new System.Windows.Forms.TextBox();
            this._txtMoTa = new System.Windows.Forms.TextBox();
            this._txtFile = new System.Windows.Forms.TextBox();
            this._dtDeadline = new System.Windows.Forms.DateTimePicker();
            this._lblLop = new System.Windows.Forms.Label();
            this._lblDeadline = new System.Windows.Forms.Label();
            this._lblTieuDe = new System.Windows.Forms.Label();
            this._lblMoTa = new System.Windows.Forms.Label();
            this._lblFile = new System.Windows.Forms.Label();
            this.btnMoi = new System.Windows.Forms.Button();
            this.btnGiao = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this._root.SuspendLayout();
            this._form.SuspendLayout();
            this._buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // _root
            // 
            this._root.BackColor = System.Drawing.Color.FromArgb(246, 248, 251);
            this._root.ColumnCount = 1;
            this._root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._root.Controls.Add(this._lblTitle, 0, 0);
            this._root.Controls.Add(this._form, 0, 1);
            this._root.Controls.Add(this._grid, 0, 2);
            this._root.Dock = System.Windows.Forms.DockStyle.Fill;
            this._root.Location = new System.Drawing.Point(0, 0);
            this._root.Margin = new System.Windows.Forms.Padding(0);
            this._root.Name = "_root";
            this._root.Padding = new System.Windows.Forms.Padding(10);
            this._root.RowCount = 3;
            this._root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this._root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this._root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._root.Size = new System.Drawing.Size(1100, 720);
            this._root.TabIndex = 0;
            // 
            // _lblTitle
            // 
            this._lblTitle.AutoEllipsis = true;
            this._lblTitle.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this._lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this._lblTitle.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this._lblTitle.Location = new System.Drawing.Point(10, 10);
            this._lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this._lblTitle.Name = "_lblTitle";
            this._lblTitle.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this._lblTitle.Size = new System.Drawing.Size(1080, 52);
            this._lblTitle.TabIndex = 0;
            this._lblTitle.Text = "Cập nhật và giao bài tập";
            this._lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _form
            // 
            this._form.AutoSize = true;
            this._form.BackColor = System.Drawing.Color.White;
            this._form.ColumnCount = 4;
            this._form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this._form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this._form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._form.Controls.Add(this._lblLop, 0, 0);
            this._form.Controls.Add(this._cboLop, 1, 0);
            this._form.Controls.Add(this._lblDeadline, 2, 0);
            this._form.Controls.Add(this._dtDeadline, 3, 0);
            this._form.Controls.Add(this._lblTieuDe, 0, 1);
            this._form.Controls.Add(this._txtTieuDe, 1, 1);
            this._form.Controls.Add(this._lblMoTa, 2, 1);
            this._form.Controls.Add(this._txtMoTa, 3, 1);
            this._form.Controls.Add(this._lblFile, 0, 2);
            this._form.Controls.Add(this._txtFile, 1, 2);
            this._form.Controls.Add(this._buttons, 3, 2);
            this._form.Dock = System.Windows.Forms.DockStyle.Top;
            this._form.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddRows;
            this._form.Location = new System.Drawing.Point(10, 62);
            this._form.Margin = new System.Windows.Forms.Padding(0);
            this._form.Name = "_form";
            this._form.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this._form.RowCount = 3;
            this._form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this._form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this._form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this._form.Size = new System.Drawing.Size(1080, 126);
            this._form.TabIndex = 1;
            // 
            // _buttons
            // 
            this._buttons.AutoSize = true;
            this._buttons.Controls.Add(this.btnMoi);
            this._buttons.Controls.Add(this.btnGiao);
            this._buttons.Controls.Add(this.btnXoa);
            this._buttons.Controls.Add(this.btnFile);
            this._buttons.Location = new System.Drawing.Point(623, 78);
            this._buttons.Margin = new System.Windows.Forms.Padding(4);
            this._buttons.Name = "_buttons";
            this._buttons.Size = new System.Drawing.Size(472, 42);
            this._buttons.TabIndex = 10;
            this._buttons.WrapContents = true;
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AutoGenerateColumns = true;
            this._grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._grid.BackgroundColor = System.Drawing.Color.White;
            this._grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._grid.ColumnHeadersHeight = 34;
            this._grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grid.EnableHeadersVisualStyles = false;
            this._grid.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._grid.GridColor = System.Drawing.Color.FromArgb(213, 220, 230);
            this._grid.Location = new System.Drawing.Point(10, 188);
            this._grid.Margin = new System.Windows.Forms.Padding(0);
            this._grid.MinimumSize = new System.Drawing.Size(320, 180);
            this._grid.MultiSelect = false;
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.RowTemplate.Height = 30;
            this._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._grid.Size = new System.Drawing.Size(1080, 522);
            this._grid.TabIndex = 2;
            this._grid.SelectionChanged += new System.EventHandler(this.Grid_SelectionChanged);
            // 
            // _cboLop
            // 
            this._cboLop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._cboLop.BackColor = System.Drawing.Color.White;
            this._cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboLop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cboLop.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._cboLop.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this._cboLop.Location = new System.Drawing.Point(103, 14);
            this._cboLop.Margin = new System.Windows.Forms.Padding(4);
            this._cboLop.MinimumSize = new System.Drawing.Size(150, 0);
            this._cboLop.Name = "_cboLop";
            this._cboLop.Size = new System.Drawing.Size(402, 23);
            this._cboLop.TabIndex = 1;
            this._cboLop.SelectedIndexChanged += new System.EventHandler(this.CboLop_SelectedIndexChanged);
            // 
            // _txtTieuDe
            // 
            this._txtTieuDe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTieuDe.BackColor = System.Drawing.Color.White;
            this._txtTieuDe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtTieuDe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtTieuDe.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this._txtTieuDe.Location = new System.Drawing.Point(103, 45);
            this._txtTieuDe.Margin = new System.Windows.Forms.Padding(4);
            this._txtTieuDe.MinimumSize = new System.Drawing.Size(150, 0);
            this._txtTieuDe.Name = "_txtTieuDe";
            this._txtTieuDe.Size = new System.Drawing.Size(402, 23);
            this._txtTieuDe.TabIndex = 5;
            // 
            // _txtMoTa
            // 
            this._txtMoTa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtMoTa.BackColor = System.Drawing.Color.White;
            this._txtMoTa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtMoTa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtMoTa.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this._txtMoTa.Location = new System.Drawing.Point(623, 45);
            this._txtMoTa.Margin = new System.Windows.Forms.Padding(4);
            this._txtMoTa.MinimumSize = new System.Drawing.Size(150, 0);
            this._txtMoTa.Name = "_txtMoTa";
            this._txtMoTa.Size = new System.Drawing.Size(441, 23);
            this._txtMoTa.TabIndex = 7;
            // 
            // _txtFile
            // 
            this._txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtFile.BackColor = System.Drawing.Color.White;
            this._txtFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtFile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtFile.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this._txtFile.Location = new System.Drawing.Point(103, 83);
            this._txtFile.Margin = new System.Windows.Forms.Padding(4);
            this._txtFile.MinimumSize = new System.Drawing.Size(150, 0);
            this._txtFile.Name = "_txtFile";
            this._txtFile.Size = new System.Drawing.Size(402, 23);
            this._txtFile.TabIndex = 9;
            // 
            // _dtDeadline
            // 
            this._dtDeadline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._dtDeadline.CustomFormat = "dd/MM/yyyy HH:mm";
            this._dtDeadline.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._dtDeadline.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtDeadline.Location = new System.Drawing.Point(623, 14);
            this._dtDeadline.Margin = new System.Windows.Forms.Padding(4);
            this._dtDeadline.Name = "_dtDeadline";
            this._dtDeadline.Size = new System.Drawing.Size(441, 23);
            this._dtDeadline.TabIndex = 3;
            // 
            // labels
            // 
            this._lblLop.AutoSize = true;
            this._lblLop.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblLop.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this._lblLop.Margin = new System.Windows.Forms.Padding(4, 8, 4, 2);
            this._lblLop.Name = "_lblLop";
            this._lblLop.Text = "Lớp";
            this._lblDeadline.AutoSize = true;
            this._lblDeadline.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblDeadline.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this._lblDeadline.Margin = new System.Windows.Forms.Padding(4, 8, 4, 2);
            this._lblDeadline.Name = "_lblDeadline";
            this._lblDeadline.Text = "Deadline";
            this._lblTieuDe.AutoSize = true;
            this._lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this._lblTieuDe.Margin = new System.Windows.Forms.Padding(4, 8, 4, 2);
            this._lblTieuDe.Name = "_lblTieuDe";
            this._lblTieuDe.Text = "Tiêu đề";
            this._lblMoTa.AutoSize = true;
            this._lblMoTa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblMoTa.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this._lblMoTa.Margin = new System.Windows.Forms.Padding(4, 8, 4, 2);
            this._lblMoTa.Name = "_lblMoTa";
            this._lblMoTa.Text = "Mô tả";
            this._lblFile.AutoSize = true;
            this._lblFile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblFile.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this._lblFile.Margin = new System.Windows.Forms.Padding(4, 8, 4, 2);
            this._lblFile.Name = "_lblFile";
            this._lblFile.Text = "File đính kèm";
            // 
            // buttons
            // 
            this.btnMoi.AutoEllipsis = true;
            this.btnMoi.BackColor = System.Drawing.Color.FromArgb(235, 242, 252);
            this.btnMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMoi.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnMoi.Location = new System.Drawing.Point(4, 4);
            this.btnMoi.Margin = new System.Windows.Forms.Padding(4);
            this.btnMoi.Name = "btnMoi";
            this.btnMoi.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnMoi.Size = new System.Drawing.Size(110, 34);
            this.btnMoi.TabIndex = 0;
            this.btnMoi.Text = "Thêm mới";
            this.btnMoi.UseVisualStyleBackColor = false;
            this.btnMoi.Click += new System.EventHandler(this.BtnMoi_Click);
            this.btnGiao.AutoEllipsis = true;
            this.btnGiao.BackColor = System.Drawing.Color.FromArgb(235, 242, 252);
            this.btnGiao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGiao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGiao.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnGiao.Location = new System.Drawing.Point(122, 4);
            this.btnGiao.Margin = new System.Windows.Forms.Padding(4);
            this.btnGiao.Name = "btnGiao";
            this.btnGiao.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnGiao.Size = new System.Drawing.Size(110, 34);
            this.btnGiao.TabIndex = 1;
            this.btnGiao.Text = "L\u01b0u";
            this.btnGiao.UseVisualStyleBackColor = false;
            this.btnGiao.Click += new System.EventHandler(this.BtnGiao_Click);
            this.btnXoa.AutoEllipsis = true;
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(235, 242, 252);
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXoa.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnXoa.Location = new System.Drawing.Point(240, 4);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnXoa.Size = new System.Drawing.Size(110, 34);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.BtnXoa_Click);
            this.btnFile.AutoEllipsis = true;
            this.btnFile.BackColor = System.Drawing.Color.FromArgb(235, 242, 252);
            this.btnFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFile.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnFile.Location = new System.Drawing.Point(358, 4);
            this.btnFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnFile.Name = "btnFile";
            this.btnFile.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnFile.Size = new System.Drawing.Size(110, 34);
            this.btnFile.TabIndex = 3;
            this.btnFile.Text = "Chọn file";
            this.btnFile.UseVisualStyleBackColor = false;
            this.btnFile.Click += new System.EventHandler(this.BtnFile_Click);
            // 
            // FrmBaiTap
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(246, 248, 251);
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Controls.Add(this._root);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmBaiTap";
            this.Text = "Cập nhật và giao bài tập";
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this._root.ResumeLayout(false);
            this._root.PerformLayout();
            this._form.ResumeLayout(false);
            this._form.PerformLayout();
            this._buttons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
