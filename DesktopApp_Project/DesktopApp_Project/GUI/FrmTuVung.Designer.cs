namespace DesktopApp_Project.GUI
{
    partial class FrmTuVung
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.ComboBox _cboLop;
        private System.Windows.Forms.TextBox _txtTu;
        private System.Windows.Forms.TextBox _txtLoai;
        private System.Windows.Forms.TextBox _txtPhienAm;
        private System.Windows.Forms.TextBox _txtNghia;

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
            this._txtTu = UiHelpers.TextBox();
            this._txtLoai = UiHelpers.TextBox();
            this._txtPhienAm = UiHelpers.TextBox();
            this._txtNghia = UiHelpers.TextBox();
            System.Windows.Forms.TableLayoutPanel root = new System.Windows.Forms.TableLayoutPanel();
            System.Windows.Forms.TableLayoutPanel form = UiHelpers.FormGrid();
            System.Windows.Forms.FlowLayoutPanel buttons = new System.Windows.Forms.FlowLayoutPanel();
            System.Windows.Forms.Button btnMoi = UiHelpers.Button("Thêm mới");
            System.Windows.Forms.Button btnLuu = UiHelpers.Button("Lưu");
            System.Windows.Forms.Button btnXoa = UiHelpers.Button("Xóa");
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

            form.Controls.Add(UiHelpers.Label("Lớp"), 0, 0);
            form.Controls.Add(this._cboLop, 1, 0);
            form.Controls.Add(UiHelpers.Label("Từ tiếng Anh"), 2, 0);
            form.Controls.Add(this._txtTu, 3, 0);
            form.Controls.Add(UiHelpers.Label("Từ loại"), 0, 1);
            form.Controls.Add(this._txtLoai, 1, 1);
            form.Controls.Add(UiHelpers.Label("Phiên âm"), 2, 1);
            form.Controls.Add(this._txtPhienAm, 3, 1);
            form.Controls.Add(UiHelpers.Label("Nghĩa"), 0, 2);
            form.Controls.Add(this._txtNghia, 1, 2);
            form.Controls.Add(buttons, 3, 2);

            btnMoi.Click += this.BtnMoi_Click;
            btnLuu.Click += this.BtnLuu_Click;
            btnXoa.Click += this.BtnXoa_Click;
            this._grid.SelectionChanged += this.Grid_SelectionChanged;
            this._cboLop.SelectedIndexChanged += this.CboLop_SelectedIndexChanged;

            root.Controls.Add(form, 0, 0);
            root.Controls.Add(this._grid, 0, 1);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Name = "FrmTuVung";
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
