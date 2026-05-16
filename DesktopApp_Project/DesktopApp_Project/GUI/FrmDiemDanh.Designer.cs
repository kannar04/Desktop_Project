namespace DesktopApp_Project.GUI
{
    partial class FrmDiemDanh
    {
        private System.ComponentModel.IContainer components = null;
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._cboLop = UiHelpers.ComboBox();
            this._dtNgay = new System.Windows.Forms.DateTimePicker();
            this._grid = UiHelpers.Grid();
            this._cboTrangThai = UiHelpers.ComboBox();
            this._txtLyDo = UiHelpers.TextBox();
            System.Windows.Forms.TableLayoutPanel root = new System.Windows.Forms.TableLayoutPanel();
            System.Windows.Forms.FlowLayoutPanel top = new System.Windows.Forms.FlowLayoutPanel();
            System.Windows.Forms.Button btnTai = UiHelpers.Button("Tải lớp");
            System.Windows.Forms.FlowLayoutPanel bottom = new System.Windows.Forms.FlowLayoutPanel();
            System.Windows.Forms.Button btnLuu = UiHelpers.Button("Lưu điểm danh");
            root.SuspendLayout();
            top.SuspendLayout();
            bottom.SuspendLayout();
            this.SuspendLayout();

            root.Dock = System.Windows.Forms.DockStyle.Fill;
            root.RowCount = 3;
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));

            this._dtNgay.Width = 150;
            this._dtNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtNgay.CustomFormat = "dd/MM/yyyy";

            btnTai.Click += this.BtnTai_Click;
            top.Dock = System.Windows.Forms.DockStyle.Top;
            top.AutoSize = true;
            top.Padding = new System.Windows.Forms.Padding(8);
            top.Controls.Add(UiHelpers.Label("Lớp"));
            top.Controls.Add(this._cboLop);
            top.Controls.Add(UiHelpers.Label("Ngày học"));
            top.Controls.Add(this._dtNgay);
            top.Controls.Add(btnTai);

            this._cboTrangThai.DataSource = DesktopApp_Project.Common.AppConstants.AttendanceStatuses;
            this._txtLyDo.Width = 320;
            btnLuu.Width = 140;
            btnLuu.Click += this.BtnLuu_Click;
            bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            bottom.AutoSize = true;
            bottom.Padding = new System.Windows.Forms.Padding(8);
            bottom.Controls.Add(UiHelpers.Label("Trạng thái"));
            bottom.Controls.Add(this._cboTrangThai);
            bottom.Controls.Add(UiHelpers.Label("Lý do vắng"));
            bottom.Controls.Add(this._txtLyDo);
            bottom.Controls.Add(btnLuu);

            this._grid.SelectionChanged += this.Grid_SelectionChanged;

            root.Controls.Add(top, 0, 0);
            root.Controls.Add(this._grid, 0, 1);
            root.Controls.Add(bottom, 0, 2);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Name = "FrmDiemDanh";
            AddContent(root);

            root.ResumeLayout(false);
            root.PerformLayout();
            top.ResumeLayout(false);
            top.PerformLayout();
            bottom.ResumeLayout(false);
            bottom.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
