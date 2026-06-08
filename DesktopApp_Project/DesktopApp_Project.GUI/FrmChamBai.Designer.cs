// in development, currently not in use, may be deleted in the future

namespace DesktopApp_Project.GUI
{
    partial class FrmChamBai
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label _lblTitle;
        private System.Windows.Forms.Label _lblDesigner3;
        private System.Windows.Forms.Label _lblDesigner2;
        private System.Windows.Forms.Label _lblDesigner1;
        private System.Windows.Forms.TableLayoutPanel root;
        private System.Windows.Forms.TableLayoutPanel left;
        private System.Windows.Forms.FlowLayoutPanel top;
        private System.Windows.Forms.Button btnTai;
        private System.Windows.Forms.FlowLayoutPanel bottom;
        private System.Windows.Forms.Button btnCham;
        private System.Windows.Forms.ComboBox _cboBaiTap;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.NumericUpDown _numDiem;
        private System.Windows.Forms.TextBox _txtNhanXet;
        private System.Windows.Forms.TextBox _txtPreview;

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
            this._cboBaiTap = new System.Windows.Forms.ComboBox();
            this._grid = new System.Windows.Forms.DataGridView();
            this._numDiem = new System.Windows.Forms.NumericUpDown();
            this._txtNhanXet = new System.Windows.Forms.TextBox();
            this._txtPreview = new System.Windows.Forms.TextBox();
            this.root = new System.Windows.Forms.TableLayoutPanel();
            this.left = new System.Windows.Forms.TableLayoutPanel();
            this.top = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTai = new System.Windows.Forms.Button();
            this.bottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCham = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numDiem)).BeginInit();
            this.root.SuspendLayout();
            this.left.SuspendLayout();
            this.top.SuspendLayout();
            this.bottom.SuspendLayout();
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
            this._lblTitle.Size = new System.Drawing.Size(638, 52);
            this._lblTitle.TabIndex = 0;
            this._lblTitle.Text = "Quản lý nộp bài và chấm bài";
            this._lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblDesigner3
            // 
            this._lblDesigner3.AutoSize = true;
            this._lblDesigner3.Location = new System.Drawing.Point(154, 8);
            this._lblDesigner3.Name = "_lblDesigner3";
            this._lblDesigner3.Size = new System.Drawing.Size(50, 13);
            this._lblDesigner3.TabIndex = 2;
            this._lblDesigner3.Text = "Nhận xét";
            // 
            // _lblDesigner2
            // 
            this._lblDesigner2.AutoSize = true;
            this._lblDesigner2.Location = new System.Drawing.Point(11, 8);
            this._lblDesigner2.Name = "_lblDesigner2";
            this._lblDesigner2.Size = new System.Drawing.Size(31, 13);
            this._lblDesigner2.TabIndex = 0;
            this._lblDesigner2.Text = "Điểm";
            // 
            // _lblDesigner1
            // 
            this._lblDesigner1.AutoSize = true;
            this._lblDesigner1.Location = new System.Drawing.Point(11, 8);
            this._lblDesigner1.Name = "_lblDesigner1";
            this._lblDesigner1.Size = new System.Drawing.Size(40, 13);
            this._lblDesigner1.TabIndex = 0;
            this._lblDesigner1.Text = "Bài tập";
            // 
            // _cboBaiTap
            // 
            this._cboBaiTap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._cboBaiTap.BackColor = System.Drawing.Color.White;
            this._cboBaiTap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboBaiTap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cboBaiTap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._cboBaiTap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._cboBaiTap.Location = new System.Drawing.Point(58, 17);
            this._cboBaiTap.Margin = new System.Windows.Forms.Padding(4);
            this._cboBaiTap.MinimumSize = new System.Drawing.Size(150, 0);
            this._cboBaiTap.Name = "_cboBaiTap";
            this._cboBaiTap.Size = new System.Drawing.Size(220, 23);
            this._cboBaiTap.TabIndex = 1;
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
            this._grid.Location = new System.Drawing.Point(3, 67);
            this._grid.MinimumSize = new System.Drawing.Size(320, 180);
            this._grid.MultiSelect = false;
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.RowTemplate.Height = 30;
            this._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._grid.Size = new System.Drawing.Size(626, 497);
            this._grid.TabIndex = 1;
            // 
            // _numDiem
            // 
            this._numDiem.DecimalPlaces = 1;
            this._numDiem.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this._numDiem.Location = new System.Drawing.Point(48, 11);
            this._numDiem.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this._numDiem.Name = "_numDiem";
            this._numDiem.Size = new System.Drawing.Size(100, 20);
            this._numDiem.TabIndex = 1;
            // 
            // _txtNhanXet
            // 
            this._txtNhanXet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtNhanXet.BackColor = System.Drawing.Color.White;
            this._txtNhanXet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtNhanXet.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtNhanXet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._txtNhanXet.Location = new System.Drawing.Point(211, 12);
            this._txtNhanXet.Margin = new System.Windows.Forms.Padding(4);
            this._txtNhanXet.MinimumSize = new System.Drawing.Size(150, 2);
            this._txtNhanXet.Name = "_txtNhanXet";
            this._txtNhanXet.Size = new System.Drawing.Size(360, 23);
            this._txtNhanXet.TabIndex = 3;
            // 
            // _txtPreview
            // 
            this._txtPreview.BackColor = System.Drawing.Color.White;
            this._txtPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtPreview.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this._txtPreview.Location = new System.Drawing.Point(642, 4);
            this._txtPreview.Margin = new System.Windows.Forms.Padding(4);
            this._txtPreview.MinimumSize = new System.Drawing.Size(150, 2);
            this._txtPreview.Multiline = true;
            this._txtPreview.Name = "_txtPreview";
            this._txtPreview.ReadOnly = true;
            this._txtPreview.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._txtPreview.Size = new System.Drawing.Size(454, 44);
            this._txtPreview.TabIndex = 2;
            // 
            // root
            // 
            this.root.ColumnCount = 2;
            this.root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.root.Controls.Add(this._lblTitle, 0, 0);
            this.root.SetColumnSpan(this._lblTitle, 2);
            this.root.Controls.Add(this.left, 0, 1);
            this.root.Controls.Add(this._txtPreview, 1, 1);
            this.root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.root.Location = new System.Drawing.Point(0, 0);
            this.root.Name = "root";
            this.root.RowCount = 2;
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.root.Size = new System.Drawing.Size(1100, 720);
            this.root.TabIndex = 0;
            // 
            // left
            // 
            this.left.ColumnCount = 1;
            this.left.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.left.Controls.Add(this.top, 0, 0);
            this.left.Controls.Add(this._grid, 0, 1);
            this.left.Controls.Add(this.bottom, 0, 2);
            this.left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.left.Location = new System.Drawing.Point(3, 55);
            this.left.Name = "left";
            this.left.RowCount = 3;
            this.left.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.left.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.left.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.left.Size = new System.Drawing.Size(632, 662);
            this.left.TabIndex = 1;
            // 
            // top
            // 
            this.top.AutoSize = true;
            this.top.Controls.Add(this._lblDesigner1);
            this.top.Controls.Add(this._cboBaiTap);
            this.top.Controls.Add(this.btnTai);
            this.top.Dock = System.Windows.Forms.DockStyle.Top;
            this.top.Location = new System.Drawing.Point(3, 3);
            this.top.Name = "top";
            this.top.Padding = new System.Windows.Forms.Padding(8);
            this.top.Size = new System.Drawing.Size(626, 58);
            this.top.TabIndex = 0;
            // 
            // btnTai
            // 
            this.btnTai.AutoEllipsis = true;
            this.btnTai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.btnTai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnTai.Location = new System.Drawing.Point(286, 12);
            this.btnTai.Margin = new System.Windows.Forms.Padding(4);
            this.btnTai.Name = "btnTai";
            this.btnTai.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnTai.Size = new System.Drawing.Size(130, 34);
            this.btnTai.TabIndex = 2;
            this.btnTai.Text = "Tải danh sách";
            this.btnTai.UseVisualStyleBackColor = false;
            // 
            // bottom
            // 
            this.bottom.AutoSize = true;
            this.bottom.Controls.Add(this._lblDesigner2);
            this.bottom.Controls.Add(this._numDiem);
            this.bottom.Controls.Add(this._lblDesigner3);
            this.bottom.Controls.Add(this._txtNhanXet);
            this.bottom.Controls.Add(this.btnCham);
            this.bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottom.Location = new System.Drawing.Point(3, 570);
            this.bottom.Name = "bottom";
            this.bottom.Padding = new System.Windows.Forms.Padding(8);
            this.bottom.Size = new System.Drawing.Size(626, 89);
            this.bottom.TabIndex = 2;
            // 
            // btnCham
            // 
            this.btnCham.AutoEllipsis = true;
            this.btnCham.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.btnCham.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCham.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCham.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnCham.Location = new System.Drawing.Point(12, 43);
            this.btnCham.Margin = new System.Windows.Forms.Padding(4);
            this.btnCham.Name = "btnCham";
            this.btnCham.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnCham.Size = new System.Drawing.Size(110, 34);
            this.btnCham.TabIndex = 4;
            this.btnCham.Text = "Chấm bài";
            this.btnCham.UseVisualStyleBackColor = false;
            // 
            // FrmChamBai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Controls.Add(this.root);
            this.Name = "FrmChamBai";
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numDiem)).EndInit();
            this.root.ResumeLayout(false);
            this.root.PerformLayout();
            this.left.ResumeLayout(false);
            this.left.PerformLayout();
            this.top.ResumeLayout(false);
            this.top.PerformLayout();
            this.bottom.ResumeLayout(false);
            this.bottom.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
    }
}
