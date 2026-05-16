namespace DesktopApp_Project.GUI
{
    partial class FrmHocVien
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.TextBox _txtTim;
        private System.Windows.Forms.TextBox _txtHoTen;
        private System.Windows.Forms.TextBox _txtSdt;
        private System.Windows.Forms.TextBox _txtEmail;
        private System.Windows.Forms.TextBox _txtTrinhDo;
        private System.Windows.Forms.TextBox _txtTaiKhoan;
        private System.Windows.Forms.TextBox _txtMatKhau;
        private System.Windows.Forms.DateTimePicker _dtNgaySinh;

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
            this._txtTim = UiHelpers.TextBox();
            this._txtHoTen = UiHelpers.TextBox();
            this._txtSdt = UiHelpers.TextBox();
            this._txtEmail = UiHelpers.TextBox();
            this._txtTrinhDo = UiHelpers.TextBox();
            this._txtTaiKhoan = UiHelpers.TextBox();
            this._txtMatKhau = UiHelpers.TextBox();
            this._dtNgaySinh = new System.Windows.Forms.DateTimePicker();
            System.Windows.Forms.TableLayoutPanel root = new System.Windows.Forms.TableLayoutPanel();
            System.Windows.Forms.FlowLayoutPanel search = new System.Windows.Forms.FlowLayoutPanel();
            System.Windows.Forms.Button btnTim = UiHelpers.Button("Tìm kiếm");
            System.Windows.Forms.TableLayoutPanel form = UiHelpers.FormGrid();
            System.Windows.Forms.FlowLayoutPanel buttons = new System.Windows.Forms.FlowLayoutPanel();
            System.Windows.Forms.Button btnThem = UiHelpers.Button("Thêm mới");
            System.Windows.Forms.Button btnLuu = UiHelpers.Button("Lưu");
            System.Windows.Forms.Button btnXoa = UiHelpers.Button("Xóa");
            root.SuspendLayout();
            search.SuspendLayout();
            form.SuspendLayout();
            buttons.SuspendLayout();
            this.SuspendLayout();

            root.Dock = System.Windows.Forms.DockStyle.Fill;
            root.RowCount = 3;
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            search.Dock = System.Windows.Forms.DockStyle.Top;
            search.AutoSize = true;
            search.Padding = new System.Windows.Forms.Padding(8);
            search.Controls.Add(UiHelpers.Label("Từ khóa"));
            search.Controls.Add(this._txtTim);
            search.Controls.Add(btnTim);

            this._dtNgaySinh.Width = 220;
            this._dtNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtNgaySinh.CustomFormat = "dd/MM/yyyy";
            this._dtNgaySinh.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            form.Controls.Add(UiHelpers.Label("Họ tên"), 0, 0);
            form.Controls.Add(this._txtHoTen, 1, 0);
            form.Controls.Add(UiHelpers.Label("Ngày sinh"), 2, 0);
            form.Controls.Add(this._dtNgaySinh, 3, 0);
            form.Controls.Add(UiHelpers.Label("SĐT"), 0, 1);
            form.Controls.Add(this._txtSdt, 1, 1);
            form.Controls.Add(UiHelpers.Label("Email"), 2, 1);
            form.Controls.Add(this._txtEmail, 3, 1);
            form.Controls.Add(UiHelpers.Label("Trình độ đầu vào"), 0, 2);
            form.Controls.Add(this._txtTrinhDo, 1, 2);
            form.Controls.Add(UiHelpers.Label("Tài khoản"), 2, 2);
            form.Controls.Add(this._txtTaiKhoan, 3, 2);
            form.Controls.Add(UiHelpers.Label("Mật khẩu"), 0, 3);
            form.Controls.Add(this._txtMatKhau, 1, 3);

            buttons.Dock = System.Windows.Forms.DockStyle.Top;
            buttons.AutoSize = true;
            buttons.Controls.Add(btnThem);
            buttons.Controls.Add(btnLuu);
            buttons.Controls.Add(btnXoa);
            form.Controls.Add(buttons, 3, 3);

            btnTim.Click += this.BtnTim_Click;
            btnThem.Click += this.BtnThem_Click;
            btnLuu.Click += this.BtnLuu_Click;
            btnXoa.Click += this.BtnXoa_Click;
            this._grid.SelectionChanged += this.Grid_SelectionChanged;

            root.Controls.Add(search, 0, 0);
            root.Controls.Add(form, 0, 1);
            root.Controls.Add(this._grid, 0, 2);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Name = "FrmHocVien";
            AddContent(root);

            root.ResumeLayout(false);
            root.PerformLayout();
            search.ResumeLayout(false);
            search.PerformLayout();
            form.ResumeLayout(false);
            form.PerformLayout();
            buttons.ResumeLayout(false);
            buttons.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
