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
            this._lblTitle.Text = "Tạo đề thi IELTS";
            this._lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lblDesigner4 = new System.Windows.Forms.Label();
            this._lblDesigner4.Text = "Đáp án";
            this._lblDesigner4.AutoSize = true;
            this._lblDesigner3 = new System.Windows.Forms.Label();
            this._lblDesigner3.Text = "Nội dung câu hỏi";
            this._lblDesigner3.AutoSize = true;
            this._lblDesigner2 = new System.Windows.Forms.Label();
            this._lblDesigner2.Text = "Tên đề thi";
            this._lblDesigner2.AutoSize = true;
            this._lblDesigner1 = new System.Windows.Forms.Label();
            this._lblDesigner1.Text = "Kỹ năng";
            this._lblDesigner1.AutoSize = true;
            this._gridCauHoi = new System.Windows.Forms.DataGridView();
            this._gridCauHoi.AutoGenerateColumns = true;
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
            this._gridCauHoi.GridColor = System.Drawing.Color.FromArgb(213, 220, 230);
            this._gridCauHoi.MinimumSize = new System.Drawing.Size(320, 180);
            this._gridCauHoi.MultiSelect = false;
            this._gridCauHoi.ReadOnly = true;
            this._gridCauHoi.RowHeadersVisible = false;
            this._gridCauHoi.RowTemplate.Height = 30;
            this._gridCauHoi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._gridDeThi = new System.Windows.Forms.DataGridView();
            this._gridDeThi.AutoGenerateColumns = true;
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
            this._gridDeThi.GridColor = System.Drawing.Color.FromArgb(213, 220, 230);
            this._gridDeThi.MinimumSize = new System.Drawing.Size(320, 180);
            this._gridDeThi.MultiSelect = false;
            this._gridDeThi.ReadOnly = true;
            this._gridDeThi.RowHeadersVisible = false;
            this._gridDeThi.RowTemplate.Height = 30;
            this._gridDeThi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._cboKyNang = new System.Windows.Forms.ComboBox();
            this._cboKyNang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._cboKyNang.BackColor = System.Drawing.Color.White;
            this._cboKyNang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboKyNang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cboKyNang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._cboKyNang.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this._cboKyNang.Margin = new System.Windows.Forms.Padding(4);
            this._cboKyNang.MinimumSize = new System.Drawing.Size(150, 0);
            this._cboKyNang.Width = 220;
            this._txtNoiDung = new System.Windows.Forms.TextBox();
            this._txtNoiDung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtNoiDung.BackColor = System.Drawing.Color.White;
            this._txtNoiDung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtNoiDung.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtNoiDung.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this._txtNoiDung.Margin = new System.Windows.Forms.Padding(4);
            this._txtNoiDung.MinimumSize = new System.Drawing.Size(150, 0);
            this._txtNoiDung.Width = 220;
            this._txtDapAn = new System.Windows.Forms.TextBox();
            this._txtDapAn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtDapAn.BackColor = System.Drawing.Color.White;
            this._txtDapAn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtDapAn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtDapAn.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this._txtDapAn.Margin = new System.Windows.Forms.Padding(4);
            this._txtDapAn.MinimumSize = new System.Drawing.Size(150, 0);
            this._txtDapAn.Width = 220;
            this._txtTenDe = new System.Windows.Forms.TextBox();
            this._txtTenDe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTenDe.BackColor = System.Drawing.Color.White;
            this._txtTenDe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtTenDe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtTenDe.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this._txtTenDe.Margin = new System.Windows.Forms.Padding(4);
            this._txtTenDe.MinimumSize = new System.Drawing.Size(150, 0);
            this._txtTenDe.Width = 220;
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
            this.btnLuuCau = new System.Windows.Forms.Button();
            this.btnLuuCau.AutoEllipsis = true;
            this.btnLuuCau.BackColor = System.Drawing.Color.FromArgb(235, 242, 252);
            this.btnLuuCau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuuCau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuCau.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLuuCau.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnLuuCau.Height = 34;
            this.btnLuuCau.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuuCau.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnLuuCau.UseVisualStyleBackColor = false;
            this.btnLuuCau.Width = 110;
            this.btnLuuCau.Text = "Lưu câu hỏi";
            this.btnXoaCau = new System.Windows.Forms.Button();
            this.btnXoaCau.AutoEllipsis = true;
            this.btnXoaCau.BackColor = System.Drawing.Color.FromArgb(235, 242, 252);
            this.btnXoaCau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaCau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaCau.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXoaCau.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnXoaCau.Height = 34;
            this.btnXoaCau.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoaCau.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnXoaCau.UseVisualStyleBackColor = false;
            this.btnXoaCau.Width = 110;
            this.btnXoaCau.Text = "Xóa câu hỏi";
            this.btnTaoDe = new System.Windows.Forms.Button();
            this.btnTaoDe.AutoEllipsis = true;
            this.btnTaoDe.BackColor = System.Drawing.Color.FromArgb(235, 242, 252);
            this.btnTaoDe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaoDe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoDe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTaoDe.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnTaoDe.Height = 34;
            this.btnTaoDe.Margin = new System.Windows.Forms.Padding(4);
            this.btnTaoDe.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnTaoDe.UseVisualStyleBackColor = false;
            this.btnTaoDe.Width = 110;
            this.btnTaoDe.Text = "Tạo đề";
            this.btnThemVaoDe = new System.Windows.Forms.Button();
            this.btnThemVaoDe.AutoEllipsis = true;
            this.btnThemVaoDe.BackColor = System.Drawing.Color.FromArgb(235, 242, 252);
            this.btnThemVaoDe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemVaoDe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemVaoDe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThemVaoDe.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnThemVaoDe.Height = 34;
            this.btnThemVaoDe.Margin = new System.Windows.Forms.Padding(4);
            this.btnThemVaoDe.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnThemVaoDe.UseVisualStyleBackColor = false;
            this.btnThemVaoDe.Width = 110;
            this.btnThemVaoDe.Text = "Gắn vào đề";
            this.root.SuspendLayout();
            this.form.SuspendLayout();
            this.buttons.SuspendLayout();
            this.SuspendLayout();

            this.root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.root.RowCount = 4;
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));

            this._txtNoiDung.Width = 430;
            this._txtNoiDung.MinimumSize = new System.Drawing.Size(240, 0);
            this._txtNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this._txtNoiDung.Multiline = true;
            this._txtNoiDung.Height = 65;
            this._txtNoiDung.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            this._txtDapAn.Width = 430;
            this._txtDapAn.MinimumSize = new System.Drawing.Size(240, 0);
            this._txtDapAn.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this._txtDapAn.Multiline = true;
            this._txtDapAn.Height = 55;
            this._txtDapAn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            this.btnThemVaoDe.Width = 120;
            this.buttons.AutoSize = true;
            this.buttons.Controls.Add(this.btnMoi);
            this.buttons.Controls.Add(this.btnLuuCau);
            this.buttons.Controls.Add(this.btnXoaCau);
            this.buttons.Controls.Add(this.btnTaoDe);
            this.buttons.Controls.Add(this.btnThemVaoDe);

            this.form.Controls.Add(this._lblDesigner1, 0, 0);
            this.form.Controls.Add(this._cboKyNang, 1, 0);
            this.form.Controls.Add(this._lblDesigner2, 2, 0);
            this.form.Controls.Add(this._txtTenDe, 3, 0);
            this.form.Controls.Add(this._lblDesigner3, 0, 1);
            this.form.Controls.Add(this._txtNoiDung, 1, 1);
            this.form.Controls.Add(this._lblDesigner4, 2, 1);
            this.form.Controls.Add(this._txtDapAn, 3, 1);
            this.form.Controls.Add(this.buttons, 3, 2);

            this.btnMoi.Click += this.BtnMoi_Click;
            this.btnLuuCau.Click += this.BtnLuuCau_Click;
            this.btnXoaCau.Click += this.BtnXoaCau_Click;
            this.btnTaoDe.Click += this.BtnTaoDe_Click;
            this.btnThemVaoDe.Click += this.BtnThemVaoDe_Click;
            this._gridCauHoi.SelectionChanged += this.GridCauHoi_SelectionChanged;
            this.root.Controls.Add(this._lblTitle, 0, 0);

            this.root.Controls.Add(this.form, 0, 1);
            this.root.Controls.Add(this._gridCauHoi, 0, 2);
            this.root.Controls.Add(this._gridDeThi, 0, 3);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Name = "FrmDeThi";
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
