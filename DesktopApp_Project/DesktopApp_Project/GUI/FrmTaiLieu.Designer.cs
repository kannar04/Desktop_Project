namespace DesktopApp_Project.GUI
{
    partial class FrmTaiLieu
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.ComboBox _cboLop;
        private System.Windows.Forms.ComboBox _cboKyNang;
        private System.Windows.Forms.TextBox _txtChuDe;
        private System.Windows.Forms.TextBox _txtMoTa;
        private System.Windows.Forms.TextBox _txtFile;
        private System.Windows.Forms.TextBox _txtVideo;

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
            this._cboKyNang = UiHelpers.ComboBox();
            this._txtChuDe = UiHelpers.TextBox();
            this._txtMoTa = UiHelpers.TextBox();
            this._txtFile = UiHelpers.TextBox();
            this._txtVideo = UiHelpers.TextBox();
            System.Windows.Forms.TableLayoutPanel root = new System.Windows.Forms.TableLayoutPanel();
            System.Windows.Forms.TableLayoutPanel form = UiHelpers.FormGrid();
            System.Windows.Forms.FlowLayoutPanel buttons = new System.Windows.Forms.FlowLayoutPanel();
            System.Windows.Forms.Button btnMoi = UiHelpers.Button("Thêm mới");
            System.Windows.Forms.Button btnLuu = UiHelpers.Button("Lưu");
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

            buttons.AutoSize = true;
            buttons.Controls.Add(btnMoi);
            buttons.Controls.Add(btnLuu);
            buttons.Controls.Add(btnXoa);
            buttons.Controls.Add(btnFile);

            form.Controls.Add(UiHelpers.Label("Lớp"), 0, 0);
            form.Controls.Add(this._cboLop, 1, 0);
            form.Controls.Add(UiHelpers.Label("Kỹ năng"), 2, 0);
            form.Controls.Add(this._cboKyNang, 3, 0);
            form.Controls.Add(UiHelpers.Label("Chủ đề"), 0, 1);
            form.Controls.Add(this._txtChuDe, 1, 1);
            form.Controls.Add(UiHelpers.Label("Mô tả"), 2, 1);
            form.Controls.Add(this._txtMoTa, 3, 1);
            form.Controls.Add(UiHelpers.Label("Đường dẫn file"), 0, 2);
            form.Controls.Add(this._txtFile, 1, 2);
            form.Controls.Add(UiHelpers.Label("Video link"), 2, 2);
            form.Controls.Add(this._txtVideo, 3, 2);
            form.Controls.Add(buttons, 3, 3);

            btnMoi.Click += this.BtnMoi_Click;
            btnLuu.Click += this.BtnLuu_Click;
            btnXoa.Click += this.BtnXoa_Click;
            btnFile.Click += this.BtnFile_Click;
            this._grid.SelectionChanged += this.Grid_SelectionChanged;
            this._cboLop.SelectedIndexChanged += this.CboLop_SelectedIndexChanged;

            root.Controls.Add(form, 0, 0);
            root.Controls.Add(this._grid, 0, 1);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Name = "FrmTaiLieu";
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
