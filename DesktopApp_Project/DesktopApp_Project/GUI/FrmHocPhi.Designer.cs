namespace DesktopApp_Project.GUI
{
    partial class FrmHocPhi
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.ComboBox _cboHocVien;
        private System.Windows.Forms.NumericUpDown _numSoTien;
        private System.Windows.Forms.TextBox _txtNganHang;
        private System.Windows.Forms.ComboBox _cboTrangThai;

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
            this._cboHocVien = UiHelpers.ComboBox();
            this._numSoTien = new System.Windows.Forms.NumericUpDown();
            this._txtNganHang = UiHelpers.TextBox();
            this._cboTrangThai = UiHelpers.ComboBox();
            System.Windows.Forms.TableLayoutPanel root = new System.Windows.Forms.TableLayoutPanel();
            System.Windows.Forms.TableLayoutPanel form = UiHelpers.FormGrid();
            System.Windows.Forms.FlowLayoutPanel buttons = new System.Windows.Forms.FlowLayoutPanel();
            System.Windows.Forms.Button btnTao = UiHelpers.Button("Tạo yêu cầu");
            System.Windows.Forms.Button btnCapNhat = UiHelpers.Button("Cập nhật");
            ((System.ComponentModel.ISupportInitialize)(this._numSoTien)).BeginInit();
            root.SuspendLayout();
            form.SuspendLayout();
            buttons.SuspendLayout();
            this.SuspendLayout();

            root.Dock = System.Windows.Forms.DockStyle.Fill;
            root.RowCount = 2;
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            this._numSoTien.Width = 160;
            this._numSoTien.Minimum = 0;
            this._numSoTien.Maximum = 1000000000;
            this._numSoTien.Increment = 100000;
            this._numSoTien.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this._cboTrangThai.DataSource = new[] { "Chờ thanh toán", "Đã thanh toán", "Quá hạn" };

            btnTao.Width = 130;
            btnTao.Click += this.BtnTao_Click;
            btnCapNhat.Click += this.BtnCapNhat_Click;
            buttons.AutoSize = true;
            buttons.Controls.Add(btnTao);
            buttons.Controls.Add(btnCapNhat);

            form.Controls.Add(UiHelpers.Label("Học viên"), 0, 0);
            form.Controls.Add(this._cboHocVien, 1, 0);
            form.Controls.Add(UiHelpers.Label("Số tiền"), 2, 0);
            form.Controls.Add(this._numSoTien, 3, 0);
            form.Controls.Add(UiHelpers.Label("Thông tin ngân hàng"), 0, 1);
            form.Controls.Add(this._txtNganHang, 1, 1);
            form.Controls.Add(UiHelpers.Label("Trạng thái"), 2, 1);
            form.Controls.Add(this._cboTrangThai, 3, 1);
            form.Controls.Add(buttons, 3, 2);

            root.Controls.Add(form, 0, 0);
            root.Controls.Add(this._grid, 0, 1);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Name = "FrmHocPhi";
            AddContent(root);

            ((System.ComponentModel.ISupportInitialize)(this._numSoTien)).EndInit();
            root.ResumeLayout(false);
            root.PerformLayout();
            form.ResumeLayout(false);
            form.PerformLayout();
            buttons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
