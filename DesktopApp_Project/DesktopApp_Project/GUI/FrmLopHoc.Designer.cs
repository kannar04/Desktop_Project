namespace DesktopApp_Project.GUI
{
    partial class FrmLopHoc
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView _gridLop;
        private System.Windows.Forms.DataGridView _gridTrongLop;
        private System.Windows.Forms.DataGridView _gridNgoaiLop;
        private System.Windows.Forms.TextBox _txtTenLop;
        private System.Windows.Forms.TextBox _txtTrinhDo;
        private System.Windows.Forms.TextBox _txtLichHoc;

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
            this._gridLop = UiHelpers.Grid();
            this._gridTrongLop = UiHelpers.Grid();
            this._gridNgoaiLop = UiHelpers.Grid();
            this._txtTenLop = UiHelpers.TextBox();
            this._txtTrinhDo = UiHelpers.TextBox();
            this._txtLichHoc = UiHelpers.TextBox();
            System.Windows.Forms.TableLayoutPanel root = new System.Windows.Forms.TableLayoutPanel();
            System.Windows.Forms.TableLayoutPanel form = UiHelpers.FormGrid();
            System.Windows.Forms.FlowLayoutPanel buttons = new System.Windows.Forms.FlowLayoutPanel();
            System.Windows.Forms.Button btnThem = UiHelpers.Button("Thêm mới");
            System.Windows.Forms.Button btnLuu = UiHelpers.Button("Lưu");
            System.Windows.Forms.Button btnXoa = UiHelpers.Button("Xóa");
            System.Windows.Forms.Panel bottom = new System.Windows.Forms.Panel();
            System.Windows.Forms.TableLayoutPanel split = new System.Windows.Forms.TableLayoutPanel();
            System.Windows.Forms.FlowLayoutPanel assignButtons = new System.Windows.Forms.FlowLayoutPanel();
            System.Windows.Forms.Button btnThemHv = UiHelpers.Button("Thêm vào lớp");
            System.Windows.Forms.Button btnXoaHv = UiHelpers.Button("Xóa khỏi lớp");
            root.SuspendLayout();
            form.SuspendLayout();
            buttons.SuspendLayout();
            bottom.SuspendLayout();
            split.SuspendLayout();
            assignButtons.SuspendLayout();
            this.SuspendLayout();

            root.Dock = System.Windows.Forms.DockStyle.Fill;
            root.RowCount = 3;
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));

            buttons.AutoSize = true;
            buttons.Controls.Add(btnThem);
            buttons.Controls.Add(btnLuu);
            buttons.Controls.Add(btnXoa);

            form.Controls.Add(UiHelpers.Label("Tên lớp"), 0, 0);
            form.Controls.Add(this._txtTenLop, 1, 0);
            form.Controls.Add(UiHelpers.Label("Nhóm trình độ"), 2, 0);
            form.Controls.Add(this._txtTrinhDo, 3, 0);
            form.Controls.Add(UiHelpers.Label("Lịch học"), 0, 1);
            form.Controls.Add(this._txtLichHoc, 1, 1);
            form.Controls.Add(buttons, 3, 1);

            split.Dock = System.Windows.Forms.DockStyle.Fill;
            split.ColumnCount = 2;
            split.RowCount = 1;
            split.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            split.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            split.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            split.Controls.Add(this._gridTrongLop, 0, 0);
            split.Controls.Add(this._gridNgoaiLop, 1, 0);

            btnThemHv.Width = 130;
            btnXoaHv.Width = 130;
            assignButtons.Dock = System.Windows.Forms.DockStyle.Top;
            assignButtons.AutoSize = true;
            assignButtons.Padding = new System.Windows.Forms.Padding(8);
            assignButtons.Controls.Add(new System.Windows.Forms.Label
            {
                Text = "Bên trái: học viên trong lớp. Bên phải: học viên chưa thuộc lớp.",
                AutoSize = true,
                Padding = new System.Windows.Forms.Padding(4, 9, 16, 0)
            });
            assignButtons.Controls.Add(btnThemHv);
            assignButtons.Controls.Add(btnXoaHv);

            bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            bottom.Controls.Add(split);
            bottom.Controls.Add(assignButtons);

            btnThem.Click += this.BtnThem_Click;
            btnLuu.Click += this.BtnLuu_Click;
            btnXoa.Click += this.BtnXoa_Click;
            btnThemHv.Click += this.BtnThemHv_Click;
            btnXoaHv.Click += this.BtnXoaHv_Click;
            this._gridLop.SelectionChanged += this.GridLop_SelectionChanged;

            root.Controls.Add(form, 0, 0);
            root.Controls.Add(this._gridLop, 0, 1);
            root.Controls.Add(bottom, 0, 2);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Name = "FrmLopHoc";
            AddContent(root);

            root.ResumeLayout(false);
            root.PerformLayout();
            form.ResumeLayout(false);
            form.PerformLayout();
            buttons.ResumeLayout(false);
            bottom.ResumeLayout(false);
            bottom.PerformLayout();
            split.ResumeLayout(false);
            assignButtons.ResumeLayout(false);
            assignButtons.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
