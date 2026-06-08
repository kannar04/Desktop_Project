namespace DesktopApp_Project.GUI
{
    partial class FrmTaiLieu
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label _lblTitle;
        private System.Windows.Forms.Label _lblDesigner1;
        private System.Windows.Forms.Label _lblDesigner2;
        private System.Windows.Forms.Label _lblDesigner3;
        private System.Windows.Forms.Label _lblDesigner4;
        private System.Windows.Forms.Label _lblDesigner5;
        private System.Windows.Forms.Label _lblDesigner6;
        private System.Windows.Forms.Label _lblAudio;
        private System.Windows.Forms.Label _lblLoaiFile;
        private System.Windows.Forms.Label _lblTenFileGoc;
        private System.Windows.Forms.Label _lblDuongDanLocal;
        private System.Windows.Forms.Label _lblCloudUrl;
        private System.Windows.Forms.Label _lblPreview;
        private System.Windows.Forms.TableLayoutPanel root;
        private System.Windows.Forms.TableLayoutPanel form;
        private System.Windows.Forms.FlowLayoutPanel buttons;
        private System.Windows.Forms.Button btnMoi;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Button btnAudio;
        private System.Windows.Forms.Button btnMoFile;
        private System.Windows.Forms.Button btnMoAudio;
        private System.Windows.Forms.Button btnUploadCloud;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.ComboBox _cboLop;
        private System.Windows.Forms.ComboBox _cboKyNang;
        private System.Windows.Forms.TextBox _txtChuDe;
        private System.Windows.Forms.TextBox _txtMoTa;
        private System.Windows.Forms.TextBox _txtFile;
        private System.Windows.Forms.TextBox _txtVideo;
        private System.Windows.Forms.TextBox _txtAudio;
        private System.Windows.Forms.TextBox _txtLoaiFile;
        private System.Windows.Forms.TextBox _txtTenFileGoc;
        private System.Windows.Forms.TextBox _txtDuongDanLocal;
        private System.Windows.Forms.TextBox _txtCloudUrl;
        private System.Windows.Forms.PictureBox _picPreview;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.root = new System.Windows.Forms.TableLayoutPanel();
            this._lblTitle = new System.Windows.Forms.Label();
            this.form = new System.Windows.Forms.TableLayoutPanel();
            this._lblDesigner1 = new System.Windows.Forms.Label();
            this._cboLop = new System.Windows.Forms.ComboBox();
            this._lblDesigner2 = new System.Windows.Forms.Label();
            this._cboKyNang = new System.Windows.Forms.ComboBox();
            this._lblDesigner3 = new System.Windows.Forms.Label();
            this._txtChuDe = new System.Windows.Forms.TextBox();
            this._lblDesigner4 = new System.Windows.Forms.Label();
            this._txtMoTa = new System.Windows.Forms.TextBox();
            this._lblDesigner5 = new System.Windows.Forms.Label();
            this._txtFile = new System.Windows.Forms.TextBox();
            this._lblDesigner6 = new System.Windows.Forms.Label();
            this._txtVideo = new System.Windows.Forms.TextBox();
            this._lblAudio = new System.Windows.Forms.Label();
            this._txtAudio = new System.Windows.Forms.TextBox();
            this._lblLoaiFile = new System.Windows.Forms.Label();
            this._txtLoaiFile = new System.Windows.Forms.TextBox();
            this._lblTenFileGoc = new System.Windows.Forms.Label();
            this._txtTenFileGoc = new System.Windows.Forms.TextBox();
            this._lblDuongDanLocal = new System.Windows.Forms.Label();
            this._txtDuongDanLocal = new System.Windows.Forms.TextBox();
            this._lblCloudUrl = new System.Windows.Forms.Label();
            this._txtCloudUrl = new System.Windows.Forms.TextBox();
            this._lblPreview = new System.Windows.Forms.Label();
            this._picPreview = new System.Windows.Forms.PictureBox();
            this.buttons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMoi = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.btnAudio = new System.Windows.Forms.Button();
            this.btnMoFile = new System.Windows.Forms.Button();
            this.btnMoAudio = new System.Windows.Forms.Button();
            this.btnUploadCloud = new System.Windows.Forms.Button();
            this._grid = new System.Windows.Forms.DataGridView();
            this.root.SuspendLayout();
            this.form.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._picPreview)).BeginInit();
            this.buttons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();
            // 
            // root
            // 
            this.root.ColumnCount = 1;
            this.root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.root.Controls.Add(this._lblTitle, 0, 0);
            this.root.Controls.Add(this.form, 0, 1);
            this.root.Controls.Add(this._grid, 0, 2);
            this.root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.root.Location = new System.Drawing.Point(0, 0);
            this.root.Name = "root";
            this.root.RowCount = 3;
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 356F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.root.Size = new System.Drawing.Size(1100, 720);
            this.root.TabIndex = 0;
            // 
            // _lblTitle
            // 
            this._lblTitle.AutoEllipsis = true;
            this._lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this._lblTitle.Location = new System.Drawing.Point(0, 0);
            this._lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this._lblTitle.Name = "_lblTitle";
            this._lblTitle.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this._lblTitle.Size = new System.Drawing.Size(1100, 52);
            this._lblTitle.TabIndex = 0;
            this._lblTitle.Text = "Quản lý tài liệu giảng dạy";
            this._lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // form
            // 
            this.form.ColumnCount = 4;
            this.form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.form.Controls.Add(this._lblDesigner1, 0, 0);
            this.form.Controls.Add(this._cboLop, 1, 0);
            this.form.Controls.Add(this._lblDesigner2, 2, 0);
            this.form.Controls.Add(this._cboKyNang, 3, 0);
            this.form.Controls.Add(this._lblDesigner3, 0, 1);
            this.form.Controls.Add(this._txtChuDe, 1, 1);
            this.form.Controls.Add(this._lblDesigner4, 2, 1);
            this.form.Controls.Add(this._txtMoTa, 3, 1);
            this.form.Controls.Add(this._lblDesigner5, 0, 2);
            this.form.Controls.Add(this._txtFile, 1, 2);
            this.form.Controls.Add(this._lblDesigner6, 2, 2);
            this.form.Controls.Add(this._txtVideo, 3, 2);
            this.form.Controls.Add(this._lblAudio, 0, 3);
            this.form.Controls.Add(this._txtAudio, 1, 3);
            this.form.Controls.Add(this._lblLoaiFile, 0, 4);
            this.form.Controls.Add(this._txtLoaiFile, 1, 4);
            this.form.Controls.Add(this._lblTenFileGoc, 2, 4);
            this.form.Controls.Add(this._txtTenFileGoc, 3, 4);
            this.form.Controls.Add(this._lblDuongDanLocal, 0, 5);
            this.form.Controls.Add(this._txtDuongDanLocal, 1, 5);
            this.form.Controls.Add(this._lblCloudUrl, 2, 5);
            this.form.Controls.Add(this._txtCloudUrl, 3, 5);
            this.form.Controls.Add(this._lblPreview, 0, 6);
            this.form.Controls.Add(this._picPreview, 1, 6);
            this.form.Controls.Add(this.buttons, 0, 7);
            this.form.Dock = System.Windows.Forms.DockStyle.Fill;
            this.form.Location = new System.Drawing.Point(0, 52);
            this.form.Margin = new System.Windows.Forms.Padding(0);
            this.form.Name = "form";
            this.form.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.form.RowCount = 8;
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.form.Size = new System.Drawing.Size(1100, 356);
            this.form.TabIndex = 1;
            // 
            // _lblDesigner1
            // 
            this._lblDesigner1.AutoEllipsis = true;
            this._lblDesigner1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblDesigner1.Location = new System.Drawing.Point(16, 14);
            this._lblDesigner1.Margin = new System.Windows.Forms.Padding(4);
            this._lblDesigner1.Name = "_lblDesigner1";
            this._lblDesigner1.Size = new System.Drawing.Size(110, 24);
            this._lblDesigner1.TabIndex = 0;
            this._lblDesigner1.Text = "Lớp";
            this._lblDesigner1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _cboLop
            // 
            this._cboLop.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboLop.Location = new System.Drawing.Point(134, 14);
            this._cboLop.Margin = new System.Windows.Forms.Padding(4);
            this._cboLop.Name = "_cboLop";
            this._cboLop.Size = new System.Drawing.Size(412, 21);
            this._cboLop.TabIndex = 1;
            // 
            // _lblDesigner2
            // 
            this._lblDesigner2.AutoEllipsis = true;
            this._lblDesigner2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblDesigner2.Location = new System.Drawing.Point(554, 14);
            this._lblDesigner2.Margin = new System.Windows.Forms.Padding(4);
            this._lblDesigner2.Name = "_lblDesigner2";
            this._lblDesigner2.Size = new System.Drawing.Size(110, 24);
            this._lblDesigner2.TabIndex = 2;
            this._lblDesigner2.Text = "Kỹ năng";
            this._lblDesigner2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _cboKyNang
            // 
            this._cboKyNang.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cboKyNang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboKyNang.Location = new System.Drawing.Point(672, 14);
            this._cboKyNang.Margin = new System.Windows.Forms.Padding(4);
            this._cboKyNang.Name = "_cboKyNang";
            this._cboKyNang.Size = new System.Drawing.Size(412, 21);
            this._cboKyNang.TabIndex = 3;
            // 
            // _lblDesigner3
            // 
            this._lblDesigner3.AutoEllipsis = true;
            this._lblDesigner3.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblDesigner3.Location = new System.Drawing.Point(16, 46);
            this._lblDesigner3.Margin = new System.Windows.Forms.Padding(4);
            this._lblDesigner3.Name = "_lblDesigner3";
            this._lblDesigner3.Size = new System.Drawing.Size(110, 24);
            this._lblDesigner3.TabIndex = 4;
            this._lblDesigner3.Text = "Chủ đề";
            this._lblDesigner3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _txtChuDe
            // 
            this._txtChuDe.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtChuDe.Location = new System.Drawing.Point(134, 46);
            this._txtChuDe.Margin = new System.Windows.Forms.Padding(4);
            this._txtChuDe.Name = "_txtChuDe";
            this._txtChuDe.Size = new System.Drawing.Size(412, 20);
            this._txtChuDe.TabIndex = 5;
            // 
            // _lblDesigner4
            // 
            this._lblDesigner4.AutoEllipsis = true;
            this._lblDesigner4.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblDesigner4.Location = new System.Drawing.Point(554, 46);
            this._lblDesigner4.Margin = new System.Windows.Forms.Padding(4);
            this._lblDesigner4.Name = "_lblDesigner4";
            this._lblDesigner4.Size = new System.Drawing.Size(110, 24);
            this._lblDesigner4.TabIndex = 6;
            this._lblDesigner4.Text = "Mô tả";
            this._lblDesigner4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _txtMoTa
            // 
            this._txtMoTa.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtMoTa.Location = new System.Drawing.Point(672, 46);
            this._txtMoTa.Margin = new System.Windows.Forms.Padding(4);
            this._txtMoTa.Name = "_txtMoTa";
            this._txtMoTa.Size = new System.Drawing.Size(412, 20);
            this._txtMoTa.TabIndex = 7;
            // 
            // _lblDesigner5
            // 
            this._lblDesigner5.AutoEllipsis = true;
            this._lblDesigner5.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblDesigner5.Location = new System.Drawing.Point(16, 78);
            this._lblDesigner5.Margin = new System.Windows.Forms.Padding(4);
            this._lblDesigner5.Name = "_lblDesigner5";
            this._lblDesigner5.Size = new System.Drawing.Size(110, 24);
            this._lblDesigner5.TabIndex = 8;
            this._lblDesigner5.Text = "Đường dẫn file";
            this._lblDesigner5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _txtFile
            // 
            this._txtFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtFile.Location = new System.Drawing.Point(134, 78);
            this._txtFile.Margin = new System.Windows.Forms.Padding(4);
            this._txtFile.Name = "_txtFile";
            this._txtFile.Size = new System.Drawing.Size(412, 20);
            this._txtFile.TabIndex = 9;
            // 
            // _lblDesigner6
            // 
            this._lblDesigner6.AutoEllipsis = true;
            this._lblDesigner6.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblDesigner6.Location = new System.Drawing.Point(554, 78);
            this._lblDesigner6.Margin = new System.Windows.Forms.Padding(4);
            this._lblDesigner6.Name = "_lblDesigner6";
            this._lblDesigner6.Size = new System.Drawing.Size(110, 24);
            this._lblDesigner6.TabIndex = 10;
            this._lblDesigner6.Text = "Video link";
            this._lblDesigner6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _txtVideo
            // 
            this._txtVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtVideo.Location = new System.Drawing.Point(672, 78);
            this._txtVideo.Margin = new System.Windows.Forms.Padding(4);
            this._txtVideo.Name = "_txtVideo";
            this._txtVideo.Size = new System.Drawing.Size(412, 20);
            this._txtVideo.TabIndex = 11;
            // 
            // _lblAudio
            // 
            this._lblAudio.AutoEllipsis = true;
            this._lblAudio.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblAudio.Location = new System.Drawing.Point(16, 110);
            this._lblAudio.Margin = new System.Windows.Forms.Padding(4);
            this._lblAudio.Name = "_lblAudio";
            this._lblAudio.Size = new System.Drawing.Size(110, 24);
            this._lblAudio.TabIndex = 12;
            this._lblAudio.Text = "Audio";
            this._lblAudio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _txtAudio
            // 
            this._txtAudio.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtAudio.Location = new System.Drawing.Point(134, 110);
            this._txtAudio.Margin = new System.Windows.Forms.Padding(4);
            this._txtAudio.Name = "_txtAudio";
            this._txtAudio.Size = new System.Drawing.Size(412, 20);
            this._txtAudio.TabIndex = 13;
            // 
            // _lblLoaiFile
            // 
            this._lblLoaiFile.AutoEllipsis = true;
            this._lblLoaiFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblLoaiFile.Location = new System.Drawing.Point(16, 142);
            this._lblLoaiFile.Margin = new System.Windows.Forms.Padding(4);
            this._lblLoaiFile.Name = "_lblLoaiFile";
            this._lblLoaiFile.Size = new System.Drawing.Size(110, 24);
            this._lblLoaiFile.TabIndex = 14;
            this._lblLoaiFile.Text = "Loại file";
            this._lblLoaiFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _txtLoaiFile
            // 
            this._txtLoaiFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtLoaiFile.Location = new System.Drawing.Point(134, 142);
            this._txtLoaiFile.Margin = new System.Windows.Forms.Padding(4);
            this._txtLoaiFile.Name = "_txtLoaiFile";
            this._txtLoaiFile.ReadOnly = true;
            this._txtLoaiFile.Size = new System.Drawing.Size(412, 20);
            this._txtLoaiFile.TabIndex = 15;
            // 
            // _lblTenFileGoc
            // 
            this._lblTenFileGoc.AutoEllipsis = true;
            this._lblTenFileGoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblTenFileGoc.Location = new System.Drawing.Point(554, 142);
            this._lblTenFileGoc.Margin = new System.Windows.Forms.Padding(4);
            this._lblTenFileGoc.Name = "_lblTenFileGoc";
            this._lblTenFileGoc.Size = new System.Drawing.Size(110, 24);
            this._lblTenFileGoc.TabIndex = 16;
            this._lblTenFileGoc.Text = "Tên file gốc";
            this._lblTenFileGoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _txtTenFileGoc
            // 
            this._txtTenFileGoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtTenFileGoc.Location = new System.Drawing.Point(672, 142);
            this._txtTenFileGoc.Margin = new System.Windows.Forms.Padding(4);
            this._txtTenFileGoc.Name = "_txtTenFileGoc";
            this._txtTenFileGoc.ReadOnly = true;
            this._txtTenFileGoc.Size = new System.Drawing.Size(412, 20);
            this._txtTenFileGoc.TabIndex = 17;
            // 
            // _lblDuongDanLocal
            // 
            this._lblDuongDanLocal.AutoEllipsis = true;
            this._lblDuongDanLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblDuongDanLocal.Location = new System.Drawing.Point(16, 174);
            this._lblDuongDanLocal.Margin = new System.Windows.Forms.Padding(4);
            this._lblDuongDanLocal.Name = "_lblDuongDanLocal";
            this._lblDuongDanLocal.Size = new System.Drawing.Size(110, 24);
            this._lblDuongDanLocal.TabIndex = 18;
            this._lblDuongDanLocal.Text = "Đường dẫn local";
            this._lblDuongDanLocal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _txtDuongDanLocal
            // 
            this._txtDuongDanLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtDuongDanLocal.Location = new System.Drawing.Point(134, 174);
            this._txtDuongDanLocal.Margin = new System.Windows.Forms.Padding(4);
            this._txtDuongDanLocal.Name = "_txtDuongDanLocal";
            this._txtDuongDanLocal.ReadOnly = true;
            this._txtDuongDanLocal.Size = new System.Drawing.Size(412, 20);
            this._txtDuongDanLocal.TabIndex = 19;
            // 
            // _lblCloudUrl
            // 
            this._lblCloudUrl.AutoEllipsis = true;
            this._lblCloudUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblCloudUrl.Location = new System.Drawing.Point(554, 174);
            this._lblCloudUrl.Margin = new System.Windows.Forms.Padding(4);
            this._lblCloudUrl.Name = "_lblCloudUrl";
            this._lblCloudUrl.Size = new System.Drawing.Size(110, 24);
            this._lblCloudUrl.TabIndex = 20;
            this._lblCloudUrl.Text = "Cloud URL";
            this._lblCloudUrl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _txtCloudUrl
            // 
            this._txtCloudUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtCloudUrl.Location = new System.Drawing.Point(672, 174);
            this._txtCloudUrl.Margin = new System.Windows.Forms.Padding(4);
            this._txtCloudUrl.Name = "_txtCloudUrl";
            this._txtCloudUrl.ReadOnly = true;
            this._txtCloudUrl.Size = new System.Drawing.Size(412, 20);
            this._txtCloudUrl.TabIndex = 21;
            // 
            // _lblPreview
            // 
            this._lblPreview.AutoEllipsis = true;
            this._lblPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblPreview.Location = new System.Drawing.Point(16, 206);
            this._lblPreview.Margin = new System.Windows.Forms.Padding(4);
            this._lblPreview.Name = "_lblPreview";
            this._lblPreview.Size = new System.Drawing.Size(110, 84);
            this._lblPreview.TabIndex = 20;
            this._lblPreview.Text = "Preview";
            this._lblPreview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _picPreview
            // 
            this._picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.form.SetColumnSpan(this._picPreview, 3);
            this._picPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this._picPreview.Location = new System.Drawing.Point(134, 206);
            this._picPreview.Margin = new System.Windows.Forms.Padding(4);
            this._picPreview.Name = "_picPreview";
            this._picPreview.Size = new System.Drawing.Size(950, 84);
            this._picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._picPreview.TabIndex = 22;
            this._picPreview.TabStop = false;
            // 
            // buttons
            // 
            this.buttons.AutoSize = true;
            this.form.SetColumnSpan(this.buttons, 4);
            this.buttons.Controls.Add(this.btnMoi);
            this.buttons.Controls.Add(this.btnLuu);
            this.buttons.Controls.Add(this.btnXoa);
            this.buttons.Controls.Add(this.btnFile);
            this.buttons.Controls.Add(this.btnAudio);
            this.buttons.Controls.Add(this.btnMoFile);
            this.buttons.Controls.Add(this.btnMoAudio);
            this.buttons.Controls.Add(this.btnUploadCloud);
            this.buttons.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttons.Location = new System.Drawing.Point(196, 298);
            this.buttons.Margin = new System.Windows.Forms.Padding(4);
            this.buttons.Name = "buttons";
            this.buttons.Size = new System.Drawing.Size(888, 44);
            this.buttons.TabIndex = 23;
            // 
            // btnMoi
            // 
            this.btnMoi.AutoEllipsis = true;
            this.btnMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoi.Location = new System.Drawing.Point(4, 4);
            this.btnMoi.Margin = new System.Windows.Forms.Padding(4);
            this.btnMoi.Name = "btnMoi";
            this.btnMoi.Size = new System.Drawing.Size(92, 34);
            this.btnMoi.TabIndex = 0;
            this.btnMoi.Text = "Thêm mới";
            this.btnMoi.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            this.btnLuu.AutoEllipsis = true;
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Location = new System.Drawing.Point(104, 4);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(92, 34);
            this.btnLuu.TabIndex = 1;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.AutoEllipsis = true;
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Location = new System.Drawing.Point(204, 4);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(92, 34);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnFile
            // 
            this.btnFile.AutoEllipsis = true;
            this.btnFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFile.Location = new System.Drawing.Point(304, 4);
            this.btnFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(100, 34);
            this.btnFile.TabIndex = 3;
            this.btnFile.Text = "Chọn file";
            this.btnFile.UseVisualStyleBackColor = true;
            // 
            // btnAudio
            // 
            this.btnAudio.AutoEllipsis = true;
            this.btnAudio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAudio.Location = new System.Drawing.Point(412, 4);
            this.btnAudio.Margin = new System.Windows.Forms.Padding(4);
            this.btnAudio.Name = "btnAudio";
            this.btnAudio.Size = new System.Drawing.Size(100, 34);
            this.btnAudio.TabIndex = 4;
            this.btnAudio.Text = "Chọn audio";
            this.btnAudio.UseVisualStyleBackColor = true;
            // 
            // btnMoFile
            // 
            this.btnMoFile.AutoEllipsis = true;
            this.btnMoFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoFile.Location = new System.Drawing.Point(520, 4);
            this.btnMoFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnMoFile.Name = "btnMoFile";
            this.btnMoFile.Size = new System.Drawing.Size(92, 34);
            this.btnMoFile.TabIndex = 5;
            this.btnMoFile.Text = "Mở file";
            this.btnMoFile.UseVisualStyleBackColor = true;
            // 
            // btnMoAudio
            // 
            this.btnMoAudio.AutoEllipsis = true;
            this.btnMoAudio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoAudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoAudio.Location = new System.Drawing.Point(620, 4);
            this.btnMoAudio.Margin = new System.Windows.Forms.Padding(4);
            this.btnMoAudio.Name = "btnMoAudio";
            this.btnMoAudio.Size = new System.Drawing.Size(96, 34);
            this.btnMoAudio.TabIndex = 6;
            this.btnMoAudio.Text = "Mở audio";
            this.btnMoAudio.UseVisualStyleBackColor = true;
            // 
            // btnUploadCloud
            // 
            this.btnUploadCloud.AutoEllipsis = true;
            this.btnUploadCloud.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUploadCloud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadCloud.Location = new System.Drawing.Point(724, 4);
            this.btnUploadCloud.Margin = new System.Windows.Forms.Padding(4);
            this.btnUploadCloud.Name = "btnUploadCloud";
            this.btnUploadCloud.Size = new System.Drawing.Size(160, 34);
            this.btnUploadCloud.TabIndex = 7;
            this.btnUploadCloud.Text = "Upload cloud giả lập";
            this.btnUploadCloud.UseVisualStyleBackColor = true;
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._grid.ColumnHeadersHeight = 34;
            this._grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grid.EnableHeadersVisualStyles = false;
            this._grid.Location = new System.Drawing.Point(3, 411);
            this._grid.MinimumSize = new System.Drawing.Size(320, 180);
            this._grid.MultiSelect = false;
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.RowTemplate.Height = 30;
            this._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._grid.Size = new System.Drawing.Size(1094, 306);
            this._grid.TabIndex = 2;
            // 
            // FrmTaiLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Controls.Add(this.root);
            this.Name = "FrmTaiLieu";
            this.Text = "Tài liệu";
            this.root.ResumeLayout(false);
            this.form.ResumeLayout(false);
            this.form.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._picPreview)).EndInit();
            this.buttons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
