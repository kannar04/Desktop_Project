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
            this._lblTitle.Text = "Quản lý nộp bài và chấm bài";
            this._lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lblDesigner3 = new System.Windows.Forms.Label();
            this._lblDesigner3.Text = "Nhận xét";
            this._lblDesigner3.AutoSize = true;
            this._lblDesigner2 = new System.Windows.Forms.Label();
            this._lblDesigner2.Text = "Điểm";
            this._lblDesigner2.AutoSize = true;
            this._lblDesigner1 = new System.Windows.Forms.Label();
            this._lblDesigner1.Text = "Bài tập";
            this._lblDesigner1.AutoSize = true;
            this._cboBaiTap = new System.Windows.Forms.ComboBox();
            this._cboBaiTap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._cboBaiTap.BackColor = System.Drawing.Color.White;
            this._cboBaiTap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboBaiTap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cboBaiTap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._cboBaiTap.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this._cboBaiTap.Margin = new System.Windows.Forms.Padding(4);
            this._cboBaiTap.MinimumSize = new System.Drawing.Size(150, 0);
            this._cboBaiTap.Width = 220;
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
            this._numDiem = new System.Windows.Forms.NumericUpDown();
            this._txtNhanXet = new System.Windows.Forms.TextBox();
            this._txtNhanXet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtNhanXet.BackColor = System.Drawing.Color.White;
            this._txtNhanXet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtNhanXet.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtNhanXet.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this._txtNhanXet.Margin = new System.Windows.Forms.Padding(4);
            this._txtNhanXet.MinimumSize = new System.Drawing.Size(150, 0);
            this._txtNhanXet.Width = 220;
            this._txtPreview = new System.Windows.Forms.TextBox();
            this._txtPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtPreview.BackColor = System.Drawing.Color.White;
            this._txtPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtPreview.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtPreview.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this._txtPreview.Margin = new System.Windows.Forms.Padding(4);
            this._txtPreview.MinimumSize = new System.Drawing.Size(150, 0);
            this._txtPreview.Width = 220;
            this.root = new System.Windows.Forms.TableLayoutPanel();
            this.left = new System.Windows.Forms.TableLayoutPanel();
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
            this.btnTai.Text = "Tải danh sách";
            this.bottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCham = new System.Windows.Forms.Button();
            this.btnCham.AutoEllipsis = true;
            this.btnCham.BackColor = System.Drawing.Color.FromArgb(235, 242, 252);
            this.btnCham.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCham.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCham.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnCham.Height = 34;
            this.btnCham.Margin = new System.Windows.Forms.Padding(4);
            this.btnCham.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnCham.UseVisualStyleBackColor = false;
            this.btnCham.Width = 110;
            this.btnCham.Text = "Chấm bài";
            ((System.ComponentModel.ISupportInitialize)(this._numDiem)).BeginInit();
            this.root.SuspendLayout();
            this.left.SuspendLayout();
            this.top.SuspendLayout();
            this.bottom.SuspendLayout();
            this.SuspendLayout();

            this.root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.root.ColumnCount = 2;
            this.root.RowCount = 2;
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            this.left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.left.RowCount = 3;
            this.left.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.left.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.left.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));

            this.btnTai.Width = 130;
            this.btnTai.Click += this.BtnTai_Click;
            this.top.Dock = System.Windows.Forms.DockStyle.Top;
            this.top.AutoSize = true;
            this.top.Padding = new System.Windows.Forms.Padding(8);
            this.top.Controls.Add(this._lblDesigner1);
            this.top.Controls.Add(this._cboBaiTap);
            this.top.Controls.Add(this.btnTai);

            this._numDiem.Width = 100;
            this._numDiem.DecimalPlaces = 1;
            this._numDiem.Increment = 0.5M;
            this._numDiem.Minimum = 0;
            this._numDiem.Maximum = 9;
            this._txtNhanXet.Width = 360;

            this.btnCham.Click += this.BtnCham_Click;
            this.bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottom.AutoSize = true;
            this.bottom.Padding = new System.Windows.Forms.Padding(8);
            this.bottom.Controls.Add(this._lblDesigner2);
            this.bottom.Controls.Add(this._numDiem);
            this.bottom.Controls.Add(this._lblDesigner3);
            this.bottom.Controls.Add(this._txtNhanXet);
            this.bottom.Controls.Add(this.btnCham);

            this._txtPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtPreview.Multiline = true;
            this._txtPreview.ReadOnly = true;
            this._txtPreview.ScrollBars = System.Windows.Forms.ScrollBars.Both;

            this._grid.SelectionChanged += this.Grid_SelectionChanged;

            this.left.Controls.Add(this.top, 0, 0);
            this.left.Controls.Add(this._grid, 0, 1);
            this.left.Controls.Add(this.bottom, 0, 2);
            this.root.Controls.Add(this._lblTitle, 0, 0);
            this.root.Controls.Add(this.left, 0, 1);
            this.root.Controls.Add(this._txtPreview, 1, 0);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Name = "FrmChamBai";
            this.Controls.Add(this.root);

            ((System.ComponentModel.ISupportInitialize)(this._numDiem)).EndInit();
            this.root.ResumeLayout(false);
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
