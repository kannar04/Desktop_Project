namespace DesktopApp_Project.GUI
{
    partial class FrmDiemSo
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox _cboLop;
        private System.Windows.Forms.ComboBox _cboDot;
        private System.Windows.Forms.DataGridView _gridHocVien;
        private System.Windows.Forms.DataGridView _gridDiem;
        private System.Windows.Forms.TextBox _txtTenDot;
        private System.Windows.Forms.DateTimePicker _dtNgay;
        private System.Windows.Forms.NumericUpDown _diemL;
        private System.Windows.Forms.NumericUpDown _diemR;
        private System.Windows.Forms.NumericUpDown _diemW;
        private System.Windows.Forms.NumericUpDown _diemS;
        private System.Windows.Forms.TextBox _txtNhanXet;

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
            this._cboDot = UiHelpers.ComboBox();
            this._gridHocVien = UiHelpers.Grid();
            this._gridDiem = UiHelpers.Grid();
            this._txtTenDot = UiHelpers.TextBox();
            this._dtNgay = new System.Windows.Forms.DateTimePicker();
            this._diemL = ScoreBox();
            this._diemR = ScoreBox();
            this._diemW = ScoreBox();
            this._diemS = ScoreBox();
            this._txtNhanXet = UiHelpers.TextBox();
            System.Windows.Forms.TableLayoutPanel root = new System.Windows.Forms.TableLayoutPanel();
            System.Windows.Forms.FlowLayoutPanel top = new System.Windows.Forms.FlowLayoutPanel();
            System.Windows.Forms.Button btnTaoDot = UiHelpers.Button("Tạo đợt");
            System.Windows.Forms.Button btnTai = UiHelpers.Button("Tải điểm");
            System.Windows.Forms.TableLayoutPanel middle = new System.Windows.Forms.TableLayoutPanel();
            System.Windows.Forms.FlowLayoutPanel bottom = new System.Windows.Forms.FlowLayoutPanel();
            System.Windows.Forms.Button btnLuu = UiHelpers.Button("Lưu điểm");
            ((System.ComponentModel.ISupportInitialize)(this._diemL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._diemR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._diemW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._diemS)).BeginInit();
            root.SuspendLayout();
            top.SuspendLayout();
            middle.SuspendLayout();
            bottom.SuspendLayout();
            this.SuspendLayout();

            root.Dock = System.Windows.Forms.DockStyle.Fill;
            root.RowCount = 3;
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));

            this._dtNgay.Width = 150;
            this._dtNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtNgay.CustomFormat = "dd/MM/yyyy";

            btnTaoDot.Click += this.BtnTaoDot_Click;
            btnTai.Click += this.BtnTai_Click;
            top.Dock = System.Windows.Forms.DockStyle.Top;
            top.AutoSize = true;
            top.Padding = new System.Windows.Forms.Padding(8);
            top.Controls.Add(UiHelpers.Label("Lớp"));
            top.Controls.Add(this._cboLop);
            top.Controls.Add(UiHelpers.Label("Tên đợt"));
            top.Controls.Add(this._txtTenDot);
            top.Controls.Add(UiHelpers.Label("Ngày"));
            top.Controls.Add(this._dtNgay);
            top.Controls.Add(btnTaoDot);
            top.Controls.Add(UiHelpers.Label("Đợt kiểm tra"));
            top.Controls.Add(this._cboDot);
            top.Controls.Add(btnTai);

            middle.Dock = System.Windows.Forms.DockStyle.Fill;
            middle.ColumnCount = 2;
            middle.RowCount = 1;
            middle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            middle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58F));
            middle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            middle.Controls.Add(this._gridHocVien, 0, 0);
            middle.Controls.Add(this._gridDiem, 1, 0);

            this._txtNhanXet.Width = 320;
            btnLuu.Click += this.BtnLuu_Click;
            bottom.Dock = System.Windows.Forms.DockStyle.Top;
            bottom.AutoSize = true;
            bottom.Padding = new System.Windows.Forms.Padding(8);
            bottom.Controls.Add(UiHelpers.Label("L"));
            bottom.Controls.Add(this._diemL);
            bottom.Controls.Add(UiHelpers.Label("R"));
            bottom.Controls.Add(this._diemR);
            bottom.Controls.Add(UiHelpers.Label("W"));
            bottom.Controls.Add(this._diemW);
            bottom.Controls.Add(UiHelpers.Label("S"));
            bottom.Controls.Add(this._diemS);
            bottom.Controls.Add(UiHelpers.Label("Nhận xét"));
            bottom.Controls.Add(this._txtNhanXet);
            bottom.Controls.Add(btnLuu);

            this._cboLop.SelectedIndexChanged += this.CboLop_SelectedIndexChanged;

            root.Controls.Add(top, 0, 0);
            root.Controls.Add(middle, 0, 1);
            root.Controls.Add(bottom, 0, 2);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Name = "FrmDiemSo";
            AddContent(root);

            ((System.ComponentModel.ISupportInitialize)(this._diemL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._diemR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._diemW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._diemS)).EndInit();
            root.ResumeLayout(false);
            root.PerformLayout();
            top.ResumeLayout(false);
            top.PerformLayout();
            middle.ResumeLayout(false);
            bottom.ResumeLayout(false);
            bottom.PerformLayout();
            this.ResumeLayout(false);
        }

        private static System.Windows.Forms.NumericUpDown ScoreBox()
        {
            return new System.Windows.Forms.NumericUpDown
            {
                Width = 58,
                DecimalPlaces = 1,
                Increment = 0.5M,
                Minimum = 0,
                Maximum = 9
            };
        }
    }
}
