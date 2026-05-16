namespace DesktopApp_Project.GUI
{
    partial class FrmBaiTap
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.ComboBox _cboLop;
        private System.Windows.Forms.TextBox _txtTieuDe;
        private System.Windows.Forms.TextBox _txtMoTa;
        private System.Windows.Forms.TextBox _txtFile;
        private System.Windows.Forms.DateTimePicker _dtDeadline;

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
            this._grid = UiHelpers.Grid();
            this._cboLop = UiHelpers.ComboBox();
            this._txtTieuDe = UiHelpers.TextBox();
            this._txtMoTa = UiHelpers.TextBox();
            this._txtFile = UiHelpers.TextBox();
            this._dtDeadline = new System.Windows.Forms.DateTimePicker();
            System.Windows.Forms.TableLayoutPanel root = new System.Windows.Forms.TableLayoutPanel();
            System.Windows.Forms.TableLayoutPanel form = UiHelpers.FormGrid();
            System.Windows.Forms.FlowLayoutPanel buttons = new System.Windows.Forms.FlowLayoutPanel();
            System.Windows.Forms.Button btnMoi = UiHelpers.Button("Thêm mới");
            System.Windows.Forms.Button btnGiao = UiHelpers.Button("Giao bài");
            System.Windows.Forms.Button btnXoa = UiHelpers.Button("Xóa");
            System.Windows.Forms.Button btnFile = UiHelpers.Button("Chọn file");
            root.SuspendLayout();
            form.SuspendLayout();
            buttons.SuspendLayout();
            this.SuspendLayout();

            root.Dock = System.Windows.Forms.DockStyle.Fill;
            root.RowCount = 2;
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            this._dtDeadline.Width = 220;
            this._dtDeadline.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtDeadline.CustomFormat = "dd/MM/yyyy HH:mm";
            this._dtDeadline.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            buttons.AutoSize = true;
            buttons.Controls.Add(btnMoi);
            buttons.Controls.Add(btnGiao);
            buttons.Controls.Add(btnXoa);
            buttons.Controls.Add(btnFile);

            form.Controls.Add(UiHelpers.Label("Lớp"), 0, 0);
            form.Controls.Add(this._cboLop, 1, 0);
            form.Controls.Add(UiHelpers.Label("Deadline"), 2, 0);
            form.Controls.Add(this._dtDeadline, 3, 0);
            form.Controls.Add(UiHelpers.Label("Tiêu đề"), 0, 1);
            form.Controls.Add(this._txtTieuDe, 1, 1);
            form.Controls.Add(UiHelpers.Label("Mô tả"), 2, 1);
            form.Controls.Add(this._txtMoTa, 3, 1);
            form.Controls.Add(UiHelpers.Label("File đính kèm"), 0, 2);
            form.Controls.Add(this._txtFile, 1, 2);
            form.Controls.Add(buttons, 3, 2);

            btnMoi.Click += this.BtnMoi_Click;
            btnGiao.Click += this.BtnGiao_Click;
            btnXoa.Click += this.BtnXoa_Click;
            btnFile.Click += this.BtnFile_Click;
            this._grid.SelectionChanged += this.Grid_SelectionChanged;
            this._cboLop.SelectedIndexChanged += this.CboLop_SelectedIndexChanged;

            root.Controls.Add(form, 0, 0);
            root.Controls.Add(this._grid, 0, 1);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Name = "FrmBaiTap";
            AddContent(root);

            root.ResumeLayout(false);
            root.PerformLayout();
            form.ResumeLayout(false);
            form.PerformLayout();
            buttons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
