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
            this._lblTitle = new System.Windows.Forms.Label();
            this._lblDesigner2 = new System.Windows.Forms.Label();
            this._lblDesigner1 = new System.Windows.Forms.Label();
            this._cboLoai = new System.Windows.Forms.ComboBox();
            this._cboLop = new System.Windows.Forms.ComboBox();
            this._txtNoiDung = new System.Windows.Forms.TextBox();
            this.root = new System.Windows.Forms.TableLayoutPanel();
            this.top = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTao = new System.Windows.Forms.Button();
            this.btnXuat = new System.Windows.Forms.Button();
            this.root.SuspendLayout();
            this.top.SuspendLayout();
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
            this._lblTitle.Text = "Tạo báo cáo";
            this._lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblDesigner2
            // 
            this._lblDesigner2.AutoSize = true;
            this._lblDesigner2.Location = new System.Drawing.Point(314, 8);
            this._lblDesigner2.Name = "_lblDesigner2";
            this._lblDesigner2.Size = new System.Drawing.Size(25, 13);
            this._lblDesigner2.TabIndex = 2;
            this._lblDesigner2.Text = "Lớp";
            // 
            // _lblDesigner1
            // 
            this._lblDesigner1.AutoSize = true;
            this._lblDesigner1.Location = new System.Drawing.Point(11, 8);
            this._lblDesigner1.Name = "_lblDesigner1";
            this._lblDesigner1.Size = new System.Drawing.Size(69, 13);
            this._lblDesigner1.TabIndex = 0;
            this._lblDesigner1.Text = "Loại báo cáo";
            // 
            // _cboLoai
            // 
            this._cboLoai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._cboLoai.BackColor = System.Drawing.Color.White;
            this._cboLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboLoai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cboLoai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._cboLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._cboLoai.Location = new System.Drawing.Point(87, 17);
            this._cboLoai.Margin = new System.Windows.Forms.Padding(4);
            this._cboLoai.MinimumSize = new System.Drawing.Size(150, 0);
            this._cboLoai.Name = "_cboLoai";
            this._cboLoai.Size = new System.Drawing.Size(220, 23);
            this._cboLoai.TabIndex = 1;
            // 
            // _cboLop
            // 
            this._cboLop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._cboLop.BackColor = System.Drawing.Color.White;
            this._cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboLop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cboLop.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._cboLop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._cboLop.Location = new System.Drawing.Point(346, 17);
            this._cboLop.Margin = new System.Windows.Forms.Padding(4);
            this._cboLop.MinimumSize = new System.Drawing.Size(150, 0);
            this._cboLop.Name = "_cboLop";
            this._cboLop.Size = new System.Drawing.Size(220, 23);
            this._cboLop.TabIndex = 3;
            // 
            // _txtNoiDung
            // 
            this._txtNoiDung.BackColor = System.Drawing.Color.White;
            this._txtNoiDung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtNoiDung.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtNoiDung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._txtNoiDung.Location = new System.Drawing.Point(4, 120);
            this._txtNoiDung.Margin = new System.Windows.Forms.Padding(4);
            this._txtNoiDung.MinimumSize = new System.Drawing.Size(150, 2);
            this._txtNoiDung.Multiline = true;
            this._txtNoiDung.Name = "_txtNoiDung";
            this._txtNoiDung.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._txtNoiDung.Size = new System.Drawing.Size(1092, 596);
            this._txtNoiDung.TabIndex = 2;
            // 
            // root
            // 
            this.root.ColumnCount = 1;
            this.root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.root.Controls.Add(this._lblTitle, 0, 0);
            this.root.Controls.Add(this.top, 0, 1);
            this.root.Controls.Add(this._txtNoiDung, 0, 2);
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
            // top
            // 
            this.top.AutoSize = true;
            this.top.Controls.Add(this._lblDesigner1);
            this.top.Controls.Add(this._cboLoai);
            this.top.Controls.Add(this._lblDesigner2);
            this.top.Controls.Add(this._cboLop);
            this.top.Controls.Add(this.btnTao);
            this.top.Controls.Add(this.btnXuat);
            this.top.Dock = System.Windows.Forms.DockStyle.Top;
            this.top.Location = new System.Drawing.Point(3, 55);
            this.top.Name = "top";
            this.top.Padding = new System.Windows.Forms.Padding(8);
            this.top.Size = new System.Drawing.Size(1094, 58);
            this.top.TabIndex = 1;
            // 
            // btnTao
            // 
            this.btnTao.AutoEllipsis = true;
            this.btnTao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.btnTao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnTao.Location = new System.Drawing.Point(574, 12);
            this.btnTao.Margin = new System.Windows.Forms.Padding(4);
            this.btnTao.Name = "btnTao";
            this.btnTao.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnTao.Size = new System.Drawing.Size(130, 34);
            this.btnTao.TabIndex = 4;
            this.btnTao.Text = "Tạo báo cáo";
            this.btnTao.UseVisualStyleBackColor = false;
            // 
            // btnXuat
            // 
            this.btnXuat.AutoEllipsis = true;
            this.btnXuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.btnXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXuat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnXuat.Location = new System.Drawing.Point(712, 12);
            this.btnXuat.Margin = new System.Windows.Forms.Padding(4);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnXuat.Size = new System.Drawing.Size(110, 34);
            this.btnXuat.TabIndex = 5;
            this.btnXuat.Text = "Xuất file";
            this.btnXuat.UseVisualStyleBackColor = false;
            // 
            // FrmBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Controls.Add(this.root);
            this.Name = "FrmBaoCao";
            this.Text = "Báo cáo";
            this.root.ResumeLayout(false);
            this.root.PerformLayout();
            this.top.ResumeLayout(false);
            this.top.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
    }
}
