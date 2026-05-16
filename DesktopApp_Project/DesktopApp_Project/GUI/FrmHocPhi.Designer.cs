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
            this._lblTitle.Text = "Thanh toán học phí";
            this._lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lblDesigner4 = new System.Windows.Forms.Label();
            this._lblDesigner4.Text = "Trạng thái";
            this._lblDesigner4.AutoSize = true;
            this._lblDesigner3 = new System.Windows.Forms.Label();
            this._lblDesigner3.Text = "Thông tin ngân hàng";
            this._lblDesigner3.AutoSize = true;
            this._lblDesigner2 = new System.Windows.Forms.Label();
            this._lblDesigner2.Text = "Số tiền";
            this._lblDesigner2.AutoSize = true;
            this._lblDesigner1 = new System.Windows.Forms.Label();
            this._lblDesigner1.Text = "Học viên";
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
            this._cboHocVien = new System.Windows.Forms.ComboBox();
            this._cboHocVien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._cboHocVien.BackColor = System.Drawing.Color.White;
            this._cboHocVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboHocVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cboHocVien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._cboHocVien.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this._cboHocVien.Margin = new System.Windows.Forms.Padding(4);
            this._cboHocVien.MinimumSize = new System.Drawing.Size(150, 0);
            this._cboHocVien.Width = 220;
            this._numSoTien = new System.Windows.Forms.NumericUpDown();
            this._txtNganHang = new System.Windows.Forms.TextBox();
            this._txtNganHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtNganHang.BackColor = System.Drawing.Color.White;
            this._txtNganHang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtNganHang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtNganHang.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this._txtNganHang.Margin = new System.Windows.Forms.Padding(4);
            this._txtNganHang.MinimumSize = new System.Drawing.Size(150, 0);
            this._txtNganHang.Width = 220;
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
            this.btnTao = new System.Windows.Forms.Button();
            this.btnTao.AutoEllipsis = true;
            this.btnTao.BackColor = System.Drawing.Color.FromArgb(235, 242, 252);
            this.btnTao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTao.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnTao.Height = 34;
            this.btnTao.Margin = new System.Windows.Forms.Padding(4);
            this.btnTao.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnTao.UseVisualStyleBackColor = false;
            this.btnTao.Width = 110;
            this.btnTao.Text = "Tạo yêu cầu";
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnCapNhat.AutoEllipsis = true;
            this.btnCapNhat.BackColor = System.Drawing.Color.FromArgb(235, 242, 252);
            this.btnCapNhat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCapNhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCapNhat.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnCapNhat.Height = 34;
            this.btnCapNhat.Margin = new System.Windows.Forms.Padding(4);
            this.btnCapNhat.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnCapNhat.UseVisualStyleBackColor = false;
            this.btnCapNhat.Width = 110;
            this.btnCapNhat.Text = "Cập nhật";
            ((System.ComponentModel.ISupportInitialize)(this._numSoTien)).BeginInit();
            this.root.SuspendLayout();
            this.form.SuspendLayout();
            this.buttons.SuspendLayout();
            this.SuspendLayout();

            this.root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.root.RowCount = 3;
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            this._numSoTien.Width = 160;
            this._numSoTien.Minimum = 0;
            this._numSoTien.Maximum = 1000000000;
            this._numSoTien.Increment = 100000;
            this._numSoTien.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this._cboTrangThai.DataSource = new[] { "Chờ thanh toán", "Đã thanh toán", "Quá hạn" };

            this.btnTao.Width = 130;
            this.btnTao.Click += this.BtnTao_Click;
            this.btnCapNhat.Click += this.BtnCapNhat_Click;
            this.buttons.AutoSize = true;
            this.buttons.Controls.Add(this.btnTao);
            this.buttons.Controls.Add(this.btnCapNhat);

            this.form.Controls.Add(this._lblDesigner1, 0, 0);
            this.form.Controls.Add(this._cboHocVien, 1, 0);
            this.form.Controls.Add(this._lblDesigner2, 2, 0);
            this.form.Controls.Add(this._numSoTien, 3, 0);
            this.form.Controls.Add(this._lblDesigner3, 0, 1);
            this.form.Controls.Add(this._txtNganHang, 1, 1);
            this.form.Controls.Add(this._lblDesigner4, 2, 1);
            this.form.Controls.Add(this._cboTrangThai, 3, 1);
            this.form.Controls.Add(this.buttons, 3, 2);
            this.root.Controls.Add(this._lblTitle, 0, 0);

            this.root.Controls.Add(this.form, 0, 1);
            this.root.Controls.Add(this._grid, 0, 2);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Name = "FrmHocPhi";
            this.Controls.Add(this.root);

            ((System.ComponentModel.ISupportInitialize)(this._numSoTien)).EndInit();
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
