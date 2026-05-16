namespace DesktopApp_Project.GUI
{
    partial class FrmBaoCao
    {
        private System.ComponentModel.IContainer components = null;
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._cboLoai = UiHelpers.ComboBox();
            this._cboLop = UiHelpers.ComboBox();
            this._txtNoiDung = new System.Windows.Forms.TextBox();
            System.Windows.Forms.TableLayoutPanel root = new System.Windows.Forms.TableLayoutPanel();
            System.Windows.Forms.FlowLayoutPanel top = new System.Windows.Forms.FlowLayoutPanel();
            System.Windows.Forms.Button btnTao = UiHelpers.Button("Tạo báo cáo");
            System.Windows.Forms.Button btnXuat = UiHelpers.Button("Xuất file");
            root.SuspendLayout();
            top.SuspendLayout();
            this.SuspendLayout();

            root.Dock = System.Windows.Forms.DockStyle.Fill;
            root.RowCount = 2;
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            this._cboLoai.DataSource = new[] { "Điểm số", "Chuyên cần" };

            btnTao.Width = 130;
            btnTao.Click += this.BtnTao_Click;
            btnXuat.Click += this.BtnXuat_Click;
            top.Dock = System.Windows.Forms.DockStyle.Top;
            top.AutoSize = true;
            top.Padding = new System.Windows.Forms.Padding(8);
            top.Controls.Add(UiHelpers.Label("Loại báo cáo"));
            top.Controls.Add(this._cboLoai);
            top.Controls.Add(UiHelpers.Label("Lớp"));
            top.Controls.Add(this._cboLop);
            top.Controls.Add(btnTao);
            top.Controls.Add(btnXuat);

            this._txtNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtNoiDung.Multiline = true;
            this._txtNoiDung.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._txtNoiDung.Font = UiHelpers.DefaultFont;

            root.Controls.Add(top, 0, 0);
            root.Controls.Add(this._txtNoiDung, 0, 1);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Name = "FrmBaoCao";
            AddContent(root);

            root.ResumeLayout(false);
            root.PerformLayout();
            top.ResumeLayout(false);
            top.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
