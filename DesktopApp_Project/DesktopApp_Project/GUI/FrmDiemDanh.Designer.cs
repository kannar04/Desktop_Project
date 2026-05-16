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
            this._lblTitle.Text = "Điểm danh và báo cáo chuyên cần";
            this._lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lblDesigner4 = new System.Windows.Forms.Label();
            this._lblDesigner4.Text = "Lý do vắng";
            this._lblDesigner4.AutoSize = true;
            this._lblDesigner3 = new System.Windows.Forms.Label();
            this._lblDesigner3.Text = "Trạng thái";
            this._lblDesigner3.AutoSize = true;
            this._lblDesigner2 = new System.Windows.Forms.Label();
            this._lblDesigner2.Text = "Ngày học";
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
            this._dtNgay = new System.Windows.Forms.DateTimePicker();
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
            this._cboTrangThai = new System.Windows.Forms.ComboBox();
            this._cboTrangThai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._cboTrangThai.BackColor = System.Drawing.Color.White;
            this._cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboTrangThai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cboTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._cboTrangThai.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this._cboTrangThai.Margin = new System.Windows.Forms.Padding(4);
            this._cboTrangThai.MinimumSize = new System.Drawing.Size(150, 0);
            this._cboTrangThai.Width = 220;
            this._txtLyDo = new System.Windows.Forms.TextBox();
            this._txtLyDo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtLyDo.BackColor = System.Drawing.Color.White;
            this._txtLyDo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtLyDo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtLyDo.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this._txtLyDo.Margin = new System.Windows.Forms.Padding(4);
            this._txtLyDo.MinimumSize = new System.Drawing.Size(150, 0);
            this._txtLyDo.Width = 220;
            this.root = new System.Windows.Forms.TableLayoutPanel();
            this.top = new System.Windows.Forms.FlowLayoutPanel();
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
            this.btnTai.Text = "Tải lớp";
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
            this.btnLuu.Text = "Lưu điểm danh";
            this.root.SuspendLayout();
            this.top.SuspendLayout();
            this.bottom.SuspendLayout();
            this.SuspendLayout();

            this.root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.root.RowCount = 4;
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));

            this._dtNgay.Width = 150;
            this._dtNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtNgay.CustomFormat = "dd/MM/yyyy";

            this.btnTai.Click += this.BtnTai_Click;
            this.top.Dock = System.Windows.Forms.DockStyle.Top;
            this.top.AutoSize = true;
            this.top.Padding = new System.Windows.Forms.Padding(8);
            this.top.Controls.Add(this._lblDesigner1);
            this.top.Controls.Add(this._cboLop);
            this.top.Controls.Add(this._lblDesigner2);
            this.top.Controls.Add(this._dtNgay);
            this.top.Controls.Add(this.btnTai);

            this._cboTrangThai.DataSource = DesktopApp_Project.Common.AppConstants.AttendanceStatuses;
            this._txtLyDo.Width = 320;
            this.btnLuu.Width = 140;
            this.btnLuu.Click += this.BtnLuu_Click;
            this.bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottom.AutoSize = true;
            this.bottom.Padding = new System.Windows.Forms.Padding(8);
            this.bottom.Controls.Add(this._lblDesigner3);
            this.bottom.Controls.Add(this._cboTrangThai);
            this.bottom.Controls.Add(this._lblDesigner4);
            this.bottom.Controls.Add(this._txtLyDo);
            this.bottom.Controls.Add(this.btnLuu);

            this._grid.SelectionChanged += this.Grid_SelectionChanged;
            this.root.Controls.Add(this._lblTitle, 0, 0);

            this.root.Controls.Add(this.top, 0, 1);
            this.root.Controls.Add(this._grid, 0, 2);
            this.root.Controls.Add(this.bottom, 0, 3);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Name = "FrmDiemDanh";
            this.Controls.Add(this.root);

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
