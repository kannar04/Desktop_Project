namespace DesktopApp_Project.GUI
{
    partial class FrmBaoCao
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label _lblTitle;
        private System.Windows.Forms.Label _lblDesigner2;
        private System.Windows.Forms.Label _lblDesigner1;
        private System.Windows.Forms.TableLayoutPanel root;
        private System.Windows.Forms.FlowLayoutPanel top;
        private System.Windows.Forms.Button btnTao;
        private System.Windows.Forms.Button btnXuat;
        private System.Windows.Forms.ComboBox _cboLoai;
        private System.Windows.Forms.ComboBox _cboLop;
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
            this._lblTitle.Text = "Tạo báo cáo";
            this._lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lblDesigner2 = new System.Windows.Forms.Label();
            this._lblDesigner2.Text = "Lớp";
            this._lblDesigner2.AutoSize = true;
            this._lblDesigner1 = new System.Windows.Forms.Label();
            this._lblDesigner1.Text = "Loại báo cáo";
            this._lblDesigner1.AutoSize = true;
            this._cboLoai = new System.Windows.Forms.ComboBox();
            this._cboLoai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._cboLoai.BackColor = System.Drawing.Color.White;
            this._cboLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboLoai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cboLoai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._cboLoai.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this._cboLoai.Margin = new System.Windows.Forms.Padding(4);
            this._cboLoai.MinimumSize = new System.Drawing.Size(150, 0);
            this._cboLoai.Width = 220;
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
            this.top = new System.Windows.Forms.FlowLayoutPanel();
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
            this.btnTao.Text = "Tạo báo cáo";
            this.btnXuat = new System.Windows.Forms.Button();
            this.btnXuat.AutoEllipsis = true;
            this.btnXuat.BackColor = System.Drawing.Color.FromArgb(235, 242, 252);
            this.btnXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXuat.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnXuat.Height = 34;
            this.btnXuat.Margin = new System.Windows.Forms.Padding(4);
            this.btnXuat.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnXuat.UseVisualStyleBackColor = false;
            this.btnXuat.Width = 110;
            this.btnXuat.Text = "Xuất file";
            this.root.SuspendLayout();
            this.top.SuspendLayout();
            this.SuspendLayout();

            this.root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.root.RowCount = 3;
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            this._cboLoai.DataSource = new[] { "Điểm số", "Chuyên cần" };

            this.btnTao.Width = 130;
            this.btnTao.Click += this.BtnTao_Click;
            this.btnXuat.Click += this.BtnXuat_Click;
            this.top.Dock = System.Windows.Forms.DockStyle.Top;
            this.top.AutoSize = true;
            this.top.Padding = new System.Windows.Forms.Padding(8);
            this.top.Controls.Add(this._lblDesigner1);
            this.top.Controls.Add(this._cboLoai);
            this.top.Controls.Add(this._lblDesigner2);
            this.top.Controls.Add(this._cboLop);
            this.top.Controls.Add(this.btnTao);
            this.top.Controls.Add(this.btnXuat);

            this._txtNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtNoiDung.Multiline = true;
            this._txtNoiDung.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._txtNoiDung.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.root.Controls.Add(this._lblTitle, 0, 0);

            this.root.Controls.Add(this.top, 0, 1);
            this.root.Controls.Add(this._txtNoiDung, 0, 2);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Name = "FrmBaoCao";
            this.Controls.Add(this.root);

            this.root.ResumeLayout(false);
            this.root.PerformLayout();
            this.top.ResumeLayout(false);
            this.top.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion
    }
}
