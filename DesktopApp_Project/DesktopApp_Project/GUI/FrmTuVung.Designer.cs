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
            this._lblTitle.Text = "Cập nhật kho từ vựng";
            this._lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lblDesigner5 = new System.Windows.Forms.Label();
            this._lblDesigner5.Text = "Nghĩa";
            this._lblDesigner5.AutoSize = true;
            this._lblDesigner4 = new System.Windows.Forms.Label();
            this._lblDesigner4.Text = "Phiên âm";
            this._lblDesigner4.AutoSize = true;
            this._lblDesigner3 = new System.Windows.Forms.Label();
            this._lblDesigner3.Text = "Từ loại";
            this._lblDesigner3.AutoSize = true;
            this._lblDesigner2 = new System.Windows.Forms.Label();
            this._lblDesigner2.Text = "Từ tiếng Anh";
            this._lblDesigner2.AutoSize = true;
            this._lblDesigner1 = new System.Windows.Forms.Label();
            this._lblDesigner1.Text = "Lớp";
            this._lblDesigner1.AutoSize = true;
            this._grid = new System.Windows.Forms.DataGridView();
            this._grid.AutoGenerateColumns = true;
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
            this._grid.GridColor = System.Drawing.Color.FromArgb(213, 220, 230);
            this._grid.MinimumSize = new System.Drawing.Size(320, 180);
            this._grid.MultiSelect = false;
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.RowTemplate.Height = 30;
            this._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
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
            this._txtTu = new System.Windows.Forms.TextBox();
            this._txtTu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTu.BackColor = System.Drawing.Color.White;
            this._txtTu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtTu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtTu.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this._txtTu.Margin = new System.Windows.Forms.Padding(4);
            this._txtTu.MinimumSize = new System.Drawing.Size(150, 0);
            this._txtTu.Width = 220;
            this._txtLoai = new System.Windows.Forms.TextBox();
            this._txtLoai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtLoai.BackColor = System.Drawing.Color.White;
            this._txtLoai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtLoai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtLoai.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this._txtLoai.Margin = new System.Windows.Forms.Padding(4);
            this._txtLoai.MinimumSize = new System.Drawing.Size(150, 0);
            this._txtLoai.Width = 220;
            this._txtPhienAm = new System.Windows.Forms.TextBox();
            this._txtPhienAm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtPhienAm.BackColor = System.Drawing.Color.White;
            this._txtPhienAm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtPhienAm.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtPhienAm.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this._txtPhienAm.Margin = new System.Windows.Forms.Padding(4);
            this._txtPhienAm.MinimumSize = new System.Drawing.Size(150, 0);
            this._txtPhienAm.Width = 220;
            this._txtNghia = new System.Windows.Forms.TextBox();
            this._txtNghia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtNghia.BackColor = System.Drawing.Color.White;
            this._txtNghia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtNghia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtNghia.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this._txtNghia.Margin = new System.Windows.Forms.Padding(4);
            this._txtNghia.MinimumSize = new System.Drawing.Size(150, 0);
            this._txtNghia.Width = 220;
            this.root = new System.Windows.Forms.TableLayoutPanel();
            this.form = new System.Windows.Forms.TableLayoutPanel();
            this.form.AutoSize = true;
            this.form.BackColor = System.Drawing.Color.White;
            this.form.ColumnCount = 4;
            this.form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.form.Dock = System.Windows.Forms.DockStyle.Top;
            this.form.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddRows;
            this.form.Margin = new System.Windows.Forms.Padding(0);
            this.form.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.buttons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMoi = new System.Windows.Forms.Button();
            this.btnMoi.AutoEllipsis = true;
            this.btnMoi.BackColor = System.Drawing.Color.FromArgb(235, 242, 252);
            this.btnMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMoi.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnMoi.Height = 34;
            this.btnMoi.Margin = new System.Windows.Forms.Padding(4);
            this.btnMoi.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnMoi.UseVisualStyleBackColor = false;
            this.btnMoi.Width = 110;
            this.btnMoi.Text = "Thêm mới";
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
            this.btnLuu.Text = "Lưu";
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnXoa.AutoEllipsis = true;
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(235, 242, 252);
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXoa.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnXoa.Height = 34;
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Width = 110;
            this.btnXoa.Text = "Xóa";
            this.root.SuspendLayout();
            this.form.SuspendLayout();
            this.buttons.SuspendLayout();
            this.SuspendLayout();

            this.root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.root.RowCount = 3;
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            this.buttons.AutoSize = true;
            this.buttons.Controls.Add(this.btnMoi);
            this.buttons.Controls.Add(this.btnLuu);
            this.buttons.Controls.Add(this.btnXoa);

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

            this.btnMoi.Click += this.BtnMoi_Click;
            this.btnLuu.Click += this.BtnLuu_Click;
            this.btnXoa.Click += this.BtnXoa_Click;
            this._grid.SelectionChanged += this.Grid_SelectionChanged;
            this._cboLop.SelectedIndexChanged += this.CboLop_SelectedIndexChanged;
            this.root.Controls.Add(this._lblTitle, 0, 0);

            this.root.Controls.Add(this.form, 0, 1);
            this.root.Controls.Add(this._grid, 0, 2);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Name = "FrmTuVung";
            this.Controls.Add(this.root);

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
