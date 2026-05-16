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
            this._lblTitle.Text = "Thông báo";
            this._lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lblDesigner3 = new System.Windows.Forms.Label();
            this._lblDesigner3.Text = "Nội dung";
            this._lblDesigner3.AutoSize = true;
            this._lblDesigner2 = new System.Windows.Forms.Label();
            this._lblDesigner2.Text = "Lớp nhận";
            this._lblDesigner2.AutoSize = true;
            this._lblDesigner1 = new System.Windows.Forms.Label();
            this._lblDesigner1.Text = "Tiêu đề";
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
            this._chkTatCa = new System.Windows.Forms.CheckBox();
            this._txtTieuDe = new System.Windows.Forms.TextBox();
            this._txtTieuDe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTieuDe.BackColor = System.Drawing.Color.White;
            this._txtTieuDe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtTieuDe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtTieuDe.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this._txtTieuDe.Margin = new System.Windows.Forms.Padding(4);
            this._txtTieuDe.MinimumSize = new System.Drawing.Size(150, 0);
            this._txtTieuDe.Width = 220;
            this._txtNoiDung = new System.Windows.Forms.TextBox();
            this._txtNoiDung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtNoiDung.BackColor = System.Drawing.Color.White;
            this._txtNoiDung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtNoiDung.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtNoiDung.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this._txtNoiDung.Margin = new System.Windows.Forms.Padding(4);
            this._txtNoiDung.MinimumSize = new System.Drawing.Size(150, 0);
            this._txtNoiDung.Width = 220;
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
            this.btnGui = new System.Windows.Forms.Button();
            this.btnGui.AutoEllipsis = true;
            this.btnGui.BackColor = System.Drawing.Color.FromArgb(235, 242, 252);
            this.btnGui.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGui.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGui.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGui.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnGui.Height = 34;
            this.btnGui.Margin = new System.Windows.Forms.Padding(4);
            this.btnGui.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnGui.UseVisualStyleBackColor = false;
            this.btnGui.Width = 110;
            this.btnGui.Text = "Gửi";
            this.root.SuspendLayout();
            this.form.SuspendLayout();
            this.SuspendLayout();

            this.root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.root.RowCount = 3;
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            this._chkTatCa.Text = "Gửi tất cả học viên";
            this._chkTatCa.AutoSize = true;
            this._chkTatCa.Checked = true;
            this._chkTatCa.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkTatCa.Margin = new System.Windows.Forms.Padding(4, 8, 4, 2);

            this._txtNoiDung.Width = 520;
            this._txtNoiDung.MinimumSize = new System.Drawing.Size(260, 0);
            this._txtNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this._txtNoiDung.Height = 80;
            this._txtNoiDung.Multiline = true;
            this._txtNoiDung.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            this.form.Controls.Add(this._lblDesigner1, 0, 0);
            this.form.Controls.Add(this._txtTieuDe, 1, 0);
            this.form.Controls.Add(this._lblDesigner2, 2, 0);
            this.form.Controls.Add(this._cboLop, 3, 0);
            this.form.Controls.Add(this._lblDesigner3, 0, 1);
            this.form.Controls.Add(this._txtNoiDung, 1, 1);
            this.form.Controls.Add(this._chkTatCa, 2, 1);
            this.form.Controls.Add(this.btnGui, 3, 1);

            this.btnGui.Click += this.BtnGui_Click;
            this.root.Controls.Add(this._lblTitle, 0, 0);

            this.root.Controls.Add(this.form, 0, 1);
            this.root.Controls.Add(this._grid, 0, 2);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Name = "FrmThongBao";
            this.Controls.Add(this.root);

            this.root.ResumeLayout(false);
            this.root.PerformLayout();
            this.form.ResumeLayout(false);
            this.form.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion
    }
}
