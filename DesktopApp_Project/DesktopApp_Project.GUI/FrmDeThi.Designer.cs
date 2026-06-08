namespace DesktopApp_Project.GUI
{
	partial class FrmDeThi
	{
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TableLayoutPanel root;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.TableLayoutPanel form;
		private System.Windows.Forms.Label lblTenDe;
		private System.Windows.Forms.TextBox txtTenDe;
		private System.Windows.Forms.Label lblKyNang;
		private System.Windows.Forms.ComboBox cboKyNang;
		private System.Windows.Forms.Label lblBandLevel;
		private System.Windows.Forms.NumericUpDown numBandLevel;
		private System.Windows.Forms.Label lblMoTa;
		private System.Windows.Forms.TextBox txtMoTa;
		private System.Windows.Forms.Label lblFile;
		private System.Windows.Forms.TextBox txtFile;
		private System.Windows.Forms.Label lblAudio;
		private System.Windows.Forms.TextBox txtAudio;
		private System.Windows.Forms.Label lblImage;
		private System.Windows.Forms.TextBox txtImage;
		private System.Windows.Forms.Label lblTrangThai;
		private System.Windows.Forms.ComboBox cboTrangThai;
		private System.Windows.Forms.Label lblPreview;
		private System.Windows.Forms.PictureBox picPreview;
		private System.Windows.Forms.FlowLayoutPanel buttons;
		private System.Windows.Forms.Button btnMoi;
		private System.Windows.Forms.Button btnLuu;
		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.Button btnChonFile;
		private System.Windows.Forms.Button btnChonAudio;
		private System.Windows.Forms.Button btnChonAnh;
		private System.Windows.Forms.Button btnMoFile;
		private System.Windows.Forms.Button btnMoAudio;
		private System.Windows.Forms.DataGridView grid;

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
			this.root = new System.Windows.Forms.TableLayoutPanel();
			this.lblTitle = new System.Windows.Forms.Label();
			this.form = new System.Windows.Forms.TableLayoutPanel();
			this.lblTenDe = new System.Windows.Forms.Label();
			this.txtTenDe = new System.Windows.Forms.TextBox();
			this.lblKyNang = new System.Windows.Forms.Label();
			this.cboKyNang = new System.Windows.Forms.ComboBox();
			this.lblBandLevel = new System.Windows.Forms.Label();
			this.numBandLevel = new System.Windows.Forms.NumericUpDown();
			this.lblMoTa = new System.Windows.Forms.Label();
			this.txtMoTa = new System.Windows.Forms.TextBox();
			this.lblTrangThai = new System.Windows.Forms.Label();
			this.cboTrangThai = new System.Windows.Forms.ComboBox();
			this.lblFile = new System.Windows.Forms.Label();
			this.txtFile = new System.Windows.Forms.TextBox();
			this.lblAudio = new System.Windows.Forms.Label();
			this.txtAudio = new System.Windows.Forms.TextBox();
			this.lblImage = new System.Windows.Forms.Label();
			this.txtImage = new System.Windows.Forms.TextBox();
			this.lblPreview = new System.Windows.Forms.Label();
			this.picPreview = new System.Windows.Forms.PictureBox();
			this.buttons = new System.Windows.Forms.FlowLayoutPanel();
			this.btnMoi = new System.Windows.Forms.Button();
			this.btnLuu = new System.Windows.Forms.Button();
			this.btnXoa = new System.Windows.Forms.Button();
			this.btnChonFile = new System.Windows.Forms.Button();
			this.btnChonAudio = new System.Windows.Forms.Button();
			this.btnChonAnh = new System.Windows.Forms.Button();
			this.btnMoFile = new System.Windows.Forms.Button();
			this.btnMoAudio = new System.Windows.Forms.Button();
			this.grid = new System.Windows.Forms.DataGridView();
			this.root.SuspendLayout();
			this.form.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numBandLevel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
			this.buttons.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			this.SuspendLayout();
			// 
			// root
			// 
			this.root.ColumnCount = 1;
			this.root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.root.Controls.Add(this.lblTitle, 0, 0);
			this.root.Controls.Add(this.form, 0, 1);
			this.root.Controls.Add(this.grid, 0, 2);
			this.root.Dock = System.Windows.Forms.DockStyle.Fill;
			this.root.Location = new System.Drawing.Point(0, 0);
			this.root.Name = "root";
			this.root.RowCount = 3;
			this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
			this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 324F));
			this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.root.Size = new System.Drawing.Size(1100, 720);
			this.root.TabIndex = 0;
			// 
			// lblTitle
			// 
			this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
			this.lblTitle.Location = new System.Drawing.Point(3, 0);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
			this.lblTitle.Size = new System.Drawing.Size(1094, 52);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Quản lý đề thi";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// form
			// 
			this.form.ColumnCount = 4;
			this.form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118F));
			this.form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118F));
			this.form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.form.Controls.Add(this.lblTenDe, 0, 0);
			this.form.Controls.Add(this.txtTenDe, 1, 0);
			this.form.Controls.Add(this.lblKyNang, 2, 0);
			this.form.Controls.Add(this.cboKyNang, 3, 0);
			this.form.Controls.Add(this.lblBandLevel, 0, 1);
			this.form.Controls.Add(this.numBandLevel, 1, 1);
			this.form.Controls.Add(this.lblMoTa, 2, 1);
			this.form.Controls.Add(this.txtMoTa, 3, 1);
			this.form.Controls.Add(this.lblTrangThai, 0, 2);
			this.form.Controls.Add(this.cboTrangThai, 1, 2);
			this.form.Controls.Add(this.lblFile, 2, 2);
			this.form.Controls.Add(this.txtFile, 3, 2);
			this.form.Controls.Add(this.lblAudio, 0, 3);
			this.form.Controls.Add(this.txtAudio, 1, 3);
			this.form.Controls.Add(this.lblImage, 2, 3);
			this.form.Controls.Add(this.txtImage, 3, 3);
			this.form.Controls.Add(this.lblPreview, 0, 4);
			this.form.Controls.Add(this.picPreview, 1, 4);
			this.form.Controls.Add(this.buttons, 0, 6);
			this.form.Dock = System.Windows.Forms.DockStyle.Fill;
			this.form.Location = new System.Drawing.Point(3, 55);
			this.form.Name = "form";
			this.form.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
			this.form.RowCount = 7;
			this.form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
			this.form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
			this.form.Size = new System.Drawing.Size(1094, 318);
			this.form.TabIndex = 1;
			// 
			// lblTenDe
			// 
			this.lblTenDe.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblTenDe.Location = new System.Drawing.Point(15, 10);
			this.lblTenDe.Name = "lblTenDe";
			this.lblTenDe.Size = new System.Drawing.Size(112, 32);
			this.lblTenDe.TabIndex = 0;
			this.lblTenDe.Text = "Tên đề thi";
			this.lblTenDe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtTenDe
			// 
			this.txtTenDe.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtTenDe.Location = new System.Drawing.Point(133, 13);
			this.txtTenDe.Name = "txtTenDe";
			this.txtTenDe.Size = new System.Drawing.Size(411, 20);
			this.txtTenDe.TabIndex = 1;
			// 
			// lblKyNang
			// 
			this.lblKyNang.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblKyNang.Location = new System.Drawing.Point(550, 10);
			this.lblKyNang.Name = "lblKyNang";
			this.lblKyNang.Size = new System.Drawing.Size(112, 32);
			this.lblKyNang.TabIndex = 2;
			this.lblKyNang.Text = "Kỹ năng";
			this.lblKyNang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboKyNang
			// 
			this.cboKyNang.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cboKyNang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboKyNang.Location = new System.Drawing.Point(668, 13);
			this.cboKyNang.Name = "cboKyNang";
			this.cboKyNang.Size = new System.Drawing.Size(411, 21);
			this.cboKyNang.TabIndex = 3;
			// 
			// lblBandLevel
			// 
			this.lblBandLevel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblBandLevel.Location = new System.Drawing.Point(15, 42);
			this.lblBandLevel.Name = "lblBandLevel";
			this.lblBandLevel.Size = new System.Drawing.Size(112, 32);
			this.lblBandLevel.TabIndex = 4;
			this.lblBandLevel.Text = "BandLevel";
			this.lblBandLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numBandLevel
			// 
			this.numBandLevel.DecimalPlaces = 1;
			this.numBandLevel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.numBandLevel.Increment = new decimal(new int[] {
			5,
			0,
			0,
			65536});
			this.numBandLevel.Location = new System.Drawing.Point(133, 45);
			this.numBandLevel.Maximum = new decimal(new int[] {
			9,
			0,
			0,
			0});
			this.numBandLevel.Name = "numBandLevel";
			this.numBandLevel.Size = new System.Drawing.Size(411, 20);
			this.numBandLevel.TabIndex = 5;
			// 
			// lblMoTa
			// 
			this.lblMoTa.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblMoTa.Location = new System.Drawing.Point(550, 42);
			this.lblMoTa.Name = "lblMoTa";
			this.lblMoTa.Size = new System.Drawing.Size(112, 32);
			this.lblMoTa.TabIndex = 8;
			this.lblMoTa.Text = "Mô tả";
			this.lblMoTa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMoTa
			// 
			this.txtMoTa.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtMoTa.Location = new System.Drawing.Point(668, 45);
			this.txtMoTa.Name = "txtMoTa";
			this.txtMoTa.Size = new System.Drawing.Size(411, 20);
			this.txtMoTa.TabIndex = 9;
			// 
			// lblTrangThai
			// 
			this.lblTrangThai.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblTrangThai.Location = new System.Drawing.Point(15, 74);
			this.lblTrangThai.Name = "lblTrangThai";
			this.lblTrangThai.Size = new System.Drawing.Size(112, 32);
			this.lblTrangThai.TabIndex = 10;
			this.lblTrangThai.Text = "Trạng thái";
			this.lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboTrangThai
			// 
			this.cboTrangThai.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTrangThai.Location = new System.Drawing.Point(133, 77);
			this.cboTrangThai.Name = "cboTrangThai";
			this.cboTrangThai.Size = new System.Drawing.Size(411, 21);
			this.cboTrangThai.TabIndex = 11;
			// 
			// lblFile
			// 
			this.lblFile.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblFile.Location = new System.Drawing.Point(550, 74);
			this.lblFile.Name = "lblFile";
			this.lblFile.Size = new System.Drawing.Size(112, 32);
			this.lblFile.TabIndex = 12;
			this.lblFile.Text = "File đề thi";
			this.lblFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtFile
			// 
			this.txtFile.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtFile.Location = new System.Drawing.Point(668, 77);
			this.txtFile.Name = "txtFile";
			this.txtFile.Size = new System.Drawing.Size(411, 20);
			this.txtFile.TabIndex = 13;
			// 
			// lblAudio
			// 
			this.lblAudio.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblAudio.Location = new System.Drawing.Point(15, 106);
			this.lblAudio.Name = "lblAudio";
			this.lblAudio.Size = new System.Drawing.Size(112, 32);
			this.lblAudio.TabIndex = 14;
			this.lblAudio.Text = "Audio";
			this.lblAudio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtAudio
			// 
			this.txtAudio.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtAudio.Location = new System.Drawing.Point(133, 109);
			this.txtAudio.Name = "txtAudio";
			this.txtAudio.Size = new System.Drawing.Size(411, 20);
			this.txtAudio.TabIndex = 15;
			// 
			// lblImage
			// 
			this.lblImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblImage.Location = new System.Drawing.Point(550, 106);
			this.lblImage.Name = "lblImage";
			this.lblImage.Size = new System.Drawing.Size(112, 32);
			this.lblImage.TabIndex = 16;
			this.lblImage.Text = "Ảnh";
			this.lblImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtImage
			// 
			this.txtImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtImage.Location = new System.Drawing.Point(668, 109);
			this.txtImage.Name = "txtImage";
			this.txtImage.Size = new System.Drawing.Size(411, 20);
			this.txtImage.TabIndex = 17;
			// 
			// lblPreview
			// 
			this.lblPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblPreview.Location = new System.Drawing.Point(15, 138);
			this.lblPreview.Name = "lblPreview";
			this.lblPreview.Size = new System.Drawing.Size(112, 32);
			this.lblPreview.TabIndex = 18;
			this.lblPreview.Text = "Preview ảnh";
			this.lblPreview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// picPreview
			// 
			this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.form.SetColumnSpan(this.picPreview, 3);
			this.picPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.picPreview.Location = new System.Drawing.Point(133, 141);
			this.picPreview.Name = "picPreview";
			this.picPreview.Size = new System.Drawing.Size(946, 26);
			this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picPreview.TabIndex = 19;
			this.picPreview.TabStop = false;
			// 
			// buttons
			// 
			this.buttons.AutoSize = true;
			this.form.SetColumnSpan(this.buttons, 4);
			this.buttons.Controls.Add(this.btnMoi);
			this.buttons.Controls.Add(this.btnLuu);
			this.buttons.Controls.Add(this.btnXoa);
			this.buttons.Controls.Add(this.btnChonFile);
			this.buttons.Controls.Add(this.btnChonAudio);
			this.buttons.Controls.Add(this.btnChonAnh);
			this.buttons.Controls.Add(this.btnMoFile);
			this.buttons.Controls.Add(this.btnMoAudio);
			this.buttons.Dock = System.Windows.Forms.DockStyle.Right;
			this.buttons.Location = new System.Drawing.Point(267, 265);
			this.buttons.Name = "buttons";
			this.buttons.Size = new System.Drawing.Size(812, 40);
			this.buttons.TabIndex = 20;
			// 
			// btnMoi
			// 
			this.btnMoi.Location = new System.Drawing.Point(4, 4);
			this.btnMoi.Margin = new System.Windows.Forms.Padding(4);
			this.btnMoi.Name = "btnMoi";
			this.btnMoi.Size = new System.Drawing.Size(92, 34);
			this.btnMoi.TabIndex = 0;
			this.btnMoi.Text = "Thêm mới";
			// 
			// btnLuu
			// 
			this.btnLuu.Location = new System.Drawing.Point(104, 4);
			this.btnLuu.Margin = new System.Windows.Forms.Padding(4);
			this.btnLuu.Name = "btnLuu";
			this.btnLuu.Size = new System.Drawing.Size(92, 34);
			this.btnLuu.TabIndex = 1;
			this.btnLuu.Text = "Lưu";
			// 
			// btnXoa
			// 
			this.btnXoa.Location = new System.Drawing.Point(204, 4);
			this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new System.Drawing.Size(92, 34);
			this.btnXoa.TabIndex = 2;
			this.btnXoa.Text = "Lứu";
			// 
			// btnChonFile
			// 
			this.btnChonFile.Location = new System.Drawing.Point(304, 4);
			this.btnChonFile.Margin = new System.Windows.Forms.Padding(4);
			this.btnChonFile.Name = "btnChonFile";
			this.btnChonFile.Size = new System.Drawing.Size(92, 34);
			this.btnChonFile.TabIndex = 3;
			this.btnChonFile.Text = "Chọn file";
			// 
			// btnChonAudio
			// 
			this.btnChonAudio.Location = new System.Drawing.Point(404, 4);
			this.btnChonAudio.Margin = new System.Windows.Forms.Padding(4);
			this.btnChonAudio.Name = "btnChonAudio";
			this.btnChonAudio.Size = new System.Drawing.Size(104, 34);
			this.btnChonAudio.TabIndex = 4;
			this.btnChonAudio.Text = "Chọn audio";
			// 
			// btnChonAnh
			// 
			this.btnChonAnh.Location = new System.Drawing.Point(516, 4);
			this.btnChonAnh.Margin = new System.Windows.Forms.Padding(4);
			this.btnChonAnh.Name = "btnChonAnh";
			this.btnChonAnh.Size = new System.Drawing.Size(92, 34);
			this.btnChonAnh.TabIndex = 5;
			this.btnChonAnh.Text = "Chọn ảnh";
			// 
			// btnMoFile
			// 
			this.btnMoFile.Location = new System.Drawing.Point(616, 4);
			this.btnMoFile.Margin = new System.Windows.Forms.Padding(4);
			this.btnMoFile.Name = "btnMoFile";
			this.btnMoFile.Size = new System.Drawing.Size(92, 34);
			this.btnMoFile.TabIndex = 6;
			this.btnMoFile.Text = "Mở file";
			// 
			// btnMoAudio
			// 
			this.btnMoAudio.Location = new System.Drawing.Point(716, 4);
			this.btnMoAudio.Margin = new System.Windows.Forms.Padding(4);
			this.btnMoAudio.Name = "btnMoAudio";
			this.btnMoAudio.Size = new System.Drawing.Size(92, 34);
			this.btnMoAudio.TabIndex = 7;
			this.btnMoAudio.Text = "Mở audio";
			// 
			// grid
			// 
			this.grid.AllowUserToAddRows = false;
			this.grid.AllowUserToDeleteRows = false;
			this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.Location = new System.Drawing.Point(3, 379);
			this.grid.MultiSelect = false;
			this.grid.Name = "grid";
			this.grid.ReadOnly = true;
			this.grid.RowHeadersVisible = false;
			this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grid.Size = new System.Drawing.Size(1094, 338);
			this.grid.TabIndex = 2;
			// 
			// FrmDeThi
			// 
			this.ClientSize = new System.Drawing.Size(1100, 720);
			this.Controls.Add(this.root);
			this.Name = "FrmDeThi";
			this.Text = "Đề thi";
			this.root.ResumeLayout(false);
			this.form.ResumeLayout(false);
			this.form.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numBandLevel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
			this.buttons.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false);

		}
	}
}