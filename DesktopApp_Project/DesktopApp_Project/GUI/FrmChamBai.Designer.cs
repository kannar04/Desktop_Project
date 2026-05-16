namespace DesktopApp_Project.GUI
{
    partial class FrmChamBai
    {
        private System.ComponentModel.IContainer components = null;
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._cboBaiTap = UiHelpers.ComboBox();
            this._grid = UiHelpers.Grid();
            this._numDiem = new System.Windows.Forms.NumericUpDown();
            this._txtNhanXet = UiHelpers.TextBox();
            this._txtPreview = new System.Windows.Forms.TextBox();
            System.Windows.Forms.TableLayoutPanel root = new System.Windows.Forms.TableLayoutPanel();
            System.Windows.Forms.TableLayoutPanel left = new System.Windows.Forms.TableLayoutPanel();
            System.Windows.Forms.FlowLayoutPanel top = new System.Windows.Forms.FlowLayoutPanel();
            System.Windows.Forms.Button btnTai = UiHelpers.Button("Tải danh sách");
            System.Windows.Forms.FlowLayoutPanel bottom = new System.Windows.Forms.FlowLayoutPanel();
            System.Windows.Forms.Button btnCham = UiHelpers.Button("Chấm bài");
            ((System.ComponentModel.ISupportInitialize)(this._numDiem)).BeginInit();
            root.SuspendLayout();
            left.SuspendLayout();
            top.SuspendLayout();
            bottom.SuspendLayout();
            this.SuspendLayout();

            root.Dock = System.Windows.Forms.DockStyle.Fill;
            root.ColumnCount = 2;
            root.RowCount = 1;
            root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58F));
            root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            left.Dock = System.Windows.Forms.DockStyle.Fill;
            left.RowCount = 3;
            left.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            left.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            left.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));

            btnTai.Width = 130;
            btnTai.Click += this.BtnTai_Click;
            top.Dock = System.Windows.Forms.DockStyle.Top;
            top.AutoSize = true;
            top.Padding = new System.Windows.Forms.Padding(8);
            top.Controls.Add(UiHelpers.Label("Bài tập"));
            top.Controls.Add(this._cboBaiTap);
            top.Controls.Add(btnTai);

            this._numDiem.Width = 100;
            this._numDiem.DecimalPlaces = 1;
            this._numDiem.Increment = 0.5M;
            this._numDiem.Minimum = 0;
            this._numDiem.Maximum = 9;
            this._txtNhanXet.Width = 360;

            btnCham.Click += this.BtnCham_Click;
            bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            bottom.AutoSize = true;
            bottom.Padding = new System.Windows.Forms.Padding(8);
            bottom.Controls.Add(UiHelpers.Label("Điểm"));
            bottom.Controls.Add(this._numDiem);
            bottom.Controls.Add(UiHelpers.Label("Nhận xét"));
            bottom.Controls.Add(this._txtNhanXet);
            bottom.Controls.Add(btnCham);

            this._txtPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtPreview.Multiline = true;
            this._txtPreview.ReadOnly = true;
            this._txtPreview.ScrollBars = System.Windows.Forms.ScrollBars.Both;

            this._grid.SelectionChanged += this.Grid_SelectionChanged;

            left.Controls.Add(top, 0, 0);
            left.Controls.Add(this._grid, 0, 1);
            left.Controls.Add(bottom, 0, 2);
            root.Controls.Add(left, 0, 0);
            root.Controls.Add(this._txtPreview, 1, 0);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Name = "FrmChamBai";
            AddContent(root);

            ((System.ComponentModel.ISupportInitialize)(this._numDiem)).EndInit();
            root.ResumeLayout(false);
            left.ResumeLayout(false);
            left.PerformLayout();
            top.ResumeLayout(false);
            top.PerformLayout();
            bottom.ResumeLayout(false);
            bottom.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
