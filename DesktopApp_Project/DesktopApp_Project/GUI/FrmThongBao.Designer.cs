namespace DesktopApp_Project.GUI
{
    partial class FrmThongBao
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.ComboBox _cboLop;
        private System.Windows.Forms.CheckBox _chkTatCa;
        private System.Windows.Forms.TextBox _txtTieuDe;
        private System.Windows.Forms.TextBox _txtNoiDung;

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
            this._chkTatCa = new System.Windows.Forms.CheckBox();
            this._txtTieuDe = UiHelpers.TextBox();
            this._txtNoiDung = new System.Windows.Forms.TextBox();
            System.Windows.Forms.TableLayoutPanel root = new System.Windows.Forms.TableLayoutPanel();
            System.Windows.Forms.TableLayoutPanel form = UiHelpers.FormGrid();
            System.Windows.Forms.Button btnGui = UiHelpers.Button("Gửi");
            root.SuspendLayout();
            form.SuspendLayout();
            this.SuspendLayout();

            root.Dock = System.Windows.Forms.DockStyle.Fill;
            root.RowCount = 2;
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            this._chkTatCa.Text = "Gửi tất cả học viên";
            this._chkTatCa.AutoSize = true;
            this._chkTatCa.Checked = true;
            this._chkTatCa.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkTatCa.Margin = new System.Windows.Forms.Padding(4, 8, 4, 2);

            this._txtNoiDung.Width = 520;
            this._txtNoiDung.MinimumSize = new System.Drawing.Size(260, 0);
            this._txtNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this._txtNoiDung.Height = 80;
            this._txtNoiDung.Multiline = true;
            this._txtNoiDung.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            form.Controls.Add(UiHelpers.Label("Tiêu đề"), 0, 0);
            form.Controls.Add(this._txtTieuDe, 1, 0);
            form.Controls.Add(UiHelpers.Label("Lớp nhận"), 2, 0);
            form.Controls.Add(this._cboLop, 3, 0);
            form.Controls.Add(UiHelpers.Label("Nội dung"), 0, 1);
            form.Controls.Add(this._txtNoiDung, 1, 1);
            form.Controls.Add(this._chkTatCa, 2, 1);
            form.Controls.Add(btnGui, 3, 1);

            btnGui.Click += this.BtnGui_Click;

            root.Controls.Add(form, 0, 0);
            root.Controls.Add(this._grid, 0, 1);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Name = "FrmThongBao";
            AddContent(root);

            root.ResumeLayout(false);
            root.PerformLayout();
            form.ResumeLayout(false);
            form.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
