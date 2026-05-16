namespace DesktopApp_Project.GUI
{
    partial class FrmDeThi
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView _gridCauHoi;
        private System.Windows.Forms.DataGridView _gridDeThi;
        private System.Windows.Forms.ComboBox _cboKyNang;
        private System.Windows.Forms.TextBox _txtNoiDung;
        private System.Windows.Forms.TextBox _txtDapAn;
        private System.Windows.Forms.TextBox _txtTenDe;

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
            this._gridCauHoi = UiHelpers.Grid();
            this._gridDeThi = UiHelpers.Grid();
            this._cboKyNang = UiHelpers.ComboBox();
            this._txtNoiDung = new System.Windows.Forms.TextBox();
            this._txtDapAn = new System.Windows.Forms.TextBox();
            this._txtTenDe = UiHelpers.TextBox();
            System.Windows.Forms.TableLayoutPanel root = new System.Windows.Forms.TableLayoutPanel();
            System.Windows.Forms.TableLayoutPanel form = UiHelpers.FormGrid();
            System.Windows.Forms.FlowLayoutPanel buttons = new System.Windows.Forms.FlowLayoutPanel();
            System.Windows.Forms.Button btnMoi = UiHelpers.Button("Thêm mới");
            System.Windows.Forms.Button btnLuuCau = UiHelpers.Button("Lưu câu hỏi");
            System.Windows.Forms.Button btnXoaCau = UiHelpers.Button("Xóa câu hỏi");
            System.Windows.Forms.Button btnTaoDe = UiHelpers.Button("Tạo đề");
            System.Windows.Forms.Button btnThemVaoDe = UiHelpers.Button("Gắn vào đề");
            root.SuspendLayout();
            form.SuspendLayout();
            buttons.SuspendLayout();
            this.SuspendLayout();

            root.Dock = System.Windows.Forms.DockStyle.Fill;
            root.RowCount = 3;
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));

            this._txtNoiDung.Width = 430;
            this._txtNoiDung.MinimumSize = new System.Drawing.Size(240, 0);
            this._txtNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this._txtNoiDung.Multiline = true;
            this._txtNoiDung.Height = 65;
            this._txtNoiDung.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            this._txtDapAn.Width = 430;
            this._txtDapAn.MinimumSize = new System.Drawing.Size(240, 0);
            this._txtDapAn.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this._txtDapAn.Multiline = true;
            this._txtDapAn.Height = 55;
            this._txtDapAn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            btnThemVaoDe.Width = 120;
            buttons.AutoSize = true;
            buttons.Controls.Add(btnMoi);
            buttons.Controls.Add(btnLuuCau);
            buttons.Controls.Add(btnXoaCau);
            buttons.Controls.Add(btnTaoDe);
            buttons.Controls.Add(btnThemVaoDe);

            form.Controls.Add(UiHelpers.Label("Kỹ năng"), 0, 0);
            form.Controls.Add(this._cboKyNang, 1, 0);
            form.Controls.Add(UiHelpers.Label("Tên đề thi"), 2, 0);
            form.Controls.Add(this._txtTenDe, 3, 0);
            form.Controls.Add(UiHelpers.Label("Nội dung câu hỏi"), 0, 1);
            form.Controls.Add(this._txtNoiDung, 1, 1);
            form.Controls.Add(UiHelpers.Label("Đáp án"), 2, 1);
            form.Controls.Add(this._txtDapAn, 3, 1);
            form.Controls.Add(buttons, 3, 2);

            btnMoi.Click += this.BtnMoi_Click;
            btnLuuCau.Click += this.BtnLuuCau_Click;
            btnXoaCau.Click += this.BtnXoaCau_Click;
            btnTaoDe.Click += this.BtnTaoDe_Click;
            btnThemVaoDe.Click += this.BtnThemVaoDe_Click;
            this._gridCauHoi.SelectionChanged += this.GridCauHoi_SelectionChanged;

            root.Controls.Add(form, 0, 0);
            root.Controls.Add(this._gridCauHoi, 0, 1);
            root.Controls.Add(this._gridDeThi, 0, 2);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Name = "FrmDeThi";
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
