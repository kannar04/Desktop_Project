namespace DesktopApp_Project.GUI
{
	partial class FrmTuVung
	{
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label _lblTitle;
		private System.Windows.Forms.Label _lblDesigner5;
		private System.Windows.Forms.Label _lblDesigner4;
		private System.Windows.Forms.Label _lblDesigner3;
		private System.Windows.Forms.Label _lblDesigner2;
		private System.Windows.Forms.Label _lblDesigner1;
		private System.Windows.Forms.TableLayoutPanel root;
		private System.Windows.Forms.TableLayoutPanel form;
		private System.Windows.Forms.FlowLayoutPanel buttons;
		private System.Windows.Forms.Button btnMoi;
		private System.Windows.Forms.Button btnLuu;
		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.DataGridView _grid;
		private System.Windows.Forms.ComboBox _cboLop;
		private System.Windows.Forms.TextBox _txtTu;
		private System.Windows.Forms.TextBox _txtLoai;
		private System.Windows.Forms.TextBox _txtPhienAm;
		private System.Windows.Forms.TextBox _txtNghia;
		private System.Windows.Forms.Label _lblFilterKeyword;
		private System.Windows.Forms.TextBox _txtTuKhoa;
		private System.Windows.Forms.Label _lblFilterType;
		private System.Windows.Forms.ComboBox _cboLoaiFilter;
		private System.Windows.Forms.Label _lblFilterLevel;
		private System.Windows.Forms.ComboBox _cboCapDoFilter;
		private System.Windows.Forms.Label _lblFilterTopic;
		private System.Windows.Forms.ComboBox _cboChuDeFilter;
		private System.Windows.Forms.Label _lblFilterLetter;
		private System.Windows.Forms.ComboBox _cboChuCaiFilter;
		private System.Windows.Forms.Button btnLoc;
		private System.Windows.Forms.Button _btnToggleAdvancedSearch;
		private System.Windows.Forms.TableLayoutPanel _advancedSearchPanel;
		private System.Windows.Forms.FlowLayoutPanel _advancedEditRow;
		private System.Windows.Forms.Label _lblAdvancedJoin;
		private System.Windows.Forms.ComboBox _cboAdvancedJoin;
		private System.Windows.Forms.Button _btnAdvancedOpenParenthesis;
		private System.Windows.Forms.Label _lblAdvancedField;
		private System.Windows.Forms.ComboBox _cboAdvancedField;
		private System.Windows.Forms.Label _lblAdvancedValue;
		private System.Windows.Forms.TextBox _txtAdvancedValue;
		private System.Windows.Forms.ComboBox _cboAdvancedValue;
		private System.Windows.Forms.Button _btnAdvancedCloseParenthesis;
		private System.Windows.Forms.Button _btnAddAdvancedCondition;
		private System.Windows.Forms.DataGridView _gridAdvancedConditions;
		private System.Windows.Forms.DataGridViewTextBoxColumn _colAdvancedJoin;
		private System.Windows.Forms.DataGridViewTextBoxColumn _colAdvancedCondition;
		private System.Windows.Forms.FlowLayoutPanel _advancedActionRow;
		private System.Windows.Forms.Button _btnRemoveAdvancedCondition;
		private System.Windows.Forms.Button _btnClearAdvancedConditions;
		private System.Windows.Forms.Button _btnRunAdvancedSearch;

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
			this._lblTitle = new System.Windows.Forms.Label();
			this._lblDesigner5 = new System.Windows.Forms.Label();
			this._lblDesigner4 = new System.Windows.Forms.Label();
			this._lblDesigner3 = new System.Windows.Forms.Label();
			this._lblDesigner2 = new System.Windows.Forms.Label();
			this._lblDesigner1 = new System.Windows.Forms.Label();
			this._grid = new System.Windows.Forms.DataGridView();
			this._cboLop = new System.Windows.Forms.ComboBox();
			this._txtTu = new System.Windows.Forms.TextBox();
			this._txtLoai = new System.Windows.Forms.TextBox();
			this._txtPhienAm = new System.Windows.Forms.TextBox();
			this._txtNghia = new System.Windows.Forms.TextBox();
			this.root = new System.Windows.Forms.TableLayoutPanel();
			this.form = new System.Windows.Forms.TableLayoutPanel();
			this.buttons = new System.Windows.Forms.FlowLayoutPanel();
			this.btnMoi = new System.Windows.Forms.Button();
			this.btnLuu = new System.Windows.Forms.Button();
			this.btnXoa = new System.Windows.Forms.Button();
			this._lblFilterKeyword = new System.Windows.Forms.Label();
			this._txtTuKhoa = new System.Windows.Forms.TextBox();
			this._lblFilterType = new System.Windows.Forms.Label();
			this._cboLoaiFilter = new System.Windows.Forms.ComboBox();
			this._lblFilterLevel = new System.Windows.Forms.Label();
			this._cboCapDoFilter = new System.Windows.Forms.ComboBox();
			this._lblFilterTopic = new System.Windows.Forms.Label();
			this._cboChuDeFilter = new System.Windows.Forms.ComboBox();
			this._lblFilterLetter = new System.Windows.Forms.Label();
			this._cboChuCaiFilter = new System.Windows.Forms.ComboBox();
			this.btnLoc = new System.Windows.Forms.Button();
			this._btnToggleAdvancedSearch = new System.Windows.Forms.Button();
			this._advancedSearchPanel = new System.Windows.Forms.TableLayoutPanel();
			this._advancedEditRow = new System.Windows.Forms.FlowLayoutPanel();
			this._lblAdvancedJoin = new System.Windows.Forms.Label();
			this._cboAdvancedJoin = new System.Windows.Forms.ComboBox();
			this._btnAdvancedOpenParenthesis = new System.Windows.Forms.Button();
			this._lblAdvancedField = new System.Windows.Forms.Label();
			this._cboAdvancedField = new System.Windows.Forms.ComboBox();
			this._lblAdvancedValue = new System.Windows.Forms.Label();
			this._txtAdvancedValue = new System.Windows.Forms.TextBox();
			this._cboAdvancedValue = new System.Windows.Forms.ComboBox();
			this._btnAdvancedCloseParenthesis = new System.Windows.Forms.Button();
			this._btnAddAdvancedCondition = new System.Windows.Forms.Button();
			this._gridAdvancedConditions = new System.Windows.Forms.DataGridView();
			this._advancedActionRow = new System.Windows.Forms.FlowLayoutPanel();
			this._btnRemoveAdvancedCondition = new System.Windows.Forms.Button();
			this._btnClearAdvancedConditions = new System.Windows.Forms.Button();
			this._btnRunAdvancedSearch = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
			this.root.SuspendLayout();
			this.form.SuspendLayout();
			this.buttons.SuspendLayout();
			this._advancedSearchPanel.SuspendLayout();
			this._advancedEditRow.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._gridAdvancedConditions)).BeginInit();
			this._advancedActionRow.SuspendLayout();
			this.SuspendLayout();
			// 
			// _lblTitle
			// 
			this._lblTitle.AutoEllipsis = true;
			this._lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
			this._lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this._lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
			this._lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
			this._lblTitle.Location = new System.Drawing.Point(0, 0);
			this._lblTitle.Margin = new System.Windows.Forms.Padding(0);
			this._lblTitle.Name = "_lblTitle";
			this._lblTitle.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
			this._lblTitle.Size = new System.Drawing.Size(1100, 52);
			this._lblTitle.TabIndex = 0;
			this._lblTitle.Text = "Cập nhật kho từ vựng";
			this._lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// _lblDesigner5
			// 
			this._lblDesigner5.AutoSize = true;
			this._lblDesigner5.Location = new System.Drawing.Point(15, 72);
			this._lblDesigner5.Name = "_lblDesigner5";
			this._lblDesigner5.Size = new System.Drawing.Size(38, 13);
			this._lblDesigner5.TabIndex = 8;
			this._lblDesigner5.Text = "Nghĩa";
			// 
			// _lblDesigner4
			// 
			this._lblDesigner4.AutoSize = true;
			this._lblDesigner4.Location = new System.Drawing.Point(538, 41);
			this._lblDesigner4.Name = "_lblDesigner4";
			this._lblDesigner4.Size = new System.Drawing.Size(51, 13);
			this._lblDesigner4.TabIndex = 6;
			this._lblDesigner4.Text = "Phiên âm";
			// 
			// _lblDesigner3
			// 
			this._lblDesigner3.AutoSize = true;
			this._lblDesigner3.Location = new System.Drawing.Point(15, 41);
			this._lblDesigner3.Name = "_lblDesigner3";
			this._lblDesigner3.Size = new System.Drawing.Size(39, 13);
			this._lblDesigner3.TabIndex = 4;
			this._lblDesigner3.Text = "Từ loại";
			// 
			// _lblDesigner2
			// 
			this._lblDesigner2.AutoSize = true;
			this._lblDesigner2.Location = new System.Drawing.Point(538, 10);
			this._lblDesigner2.Name = "_lblDesigner2";
			this._lblDesigner2.Size = new System.Drawing.Size(68, 13);
			this._lblDesigner2.TabIndex = 2;
			this._lblDesigner2.Text = "Từ tiếng Anh";
			// 
			// _lblDesigner1
			// 
			this._lblDesigner1.AutoSize = true;
			this._lblDesigner1.Location = new System.Drawing.Point(15, 10);
			this._lblDesigner1.Name = "_lblDesigner1";
			this._lblDesigner1.Size = new System.Drawing.Size(25, 13);
			this._lblDesigner1.TabIndex = 0;
			this._lblDesigner1.Text = "Lớp";
			// 
			// _grid
			// 
			this._grid.AllowUserToAddRows = false;
			this._grid.AllowUserToDeleteRows = false;
			this._grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this._grid.BackgroundColor = System.Drawing.Color.White;
			this._grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this._grid.ColumnHeadersHeight = 34;
			this._grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this._grid.EnableHeadersVisualStyles = false;
			this._grid.Font = new System.Drawing.Font("Segoe UI", 9F);
			this._grid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
			this._grid.Location = new System.Drawing.Point(3, 539);
			this._grid.MinimumSize = new System.Drawing.Size(320, 180);
			this._grid.MultiSelect = false;
			this._grid.Name = "_grid";
			this._grid.ReadOnly = true;
			this._grid.RowHeadersVisible = false;
			this._grid.RowTemplate.Height = 30;
			this._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this._grid.Size = new System.Drawing.Size(1094, 180);
			this._grid.TabIndex = 2;
			// 
			// _cboLop
			// 
			this._cboLop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this._cboLop.BackColor = System.Drawing.Color.White;
			this._cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._cboLop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._cboLop.Font = new System.Drawing.Font("Segoe UI", 9F);
			this._cboLop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
			this._cboLop.Location = new System.Drawing.Point(61, 14);
			this._cboLop.Margin = new System.Windows.Forms.Padding(4);
			this._cboLop.MinimumSize = new System.Drawing.Size(150, 0);
			this._cboLop.Name = "_cboLop";
			this._cboLop.Size = new System.Drawing.Size(470, 23);
			this._cboLop.TabIndex = 1;
			// 
			// _txtTu
			// 
			this._txtTu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this._txtTu.BackColor = System.Drawing.Color.White;
			this._txtTu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtTu.Font = new System.Drawing.Font("Segoe UI", 9F);
			this._txtTu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
			this._txtTu.Location = new System.Drawing.Point(613, 14);
			this._txtTu.Margin = new System.Windows.Forms.Padding(4);
			this._txtTu.MinimumSize = new System.Drawing.Size(150, 2);
			this._txtTu.Name = "_txtTu";
			this._txtTu.Size = new System.Drawing.Size(471, 23);
			this._txtTu.TabIndex = 3;
			// 
			// _txtLoai
			// 
			this._txtLoai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this._txtLoai.BackColor = System.Drawing.Color.White;
			this._txtLoai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtLoai.Font = new System.Drawing.Font("Segoe UI", 9F);
			this._txtLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
			this._txtLoai.Location = new System.Drawing.Point(61, 45);
			this._txtLoai.Margin = new System.Windows.Forms.Padding(4);
			this._txtLoai.MinimumSize = new System.Drawing.Size(150, 2);
			this._txtLoai.Name = "_txtLoai";
			this._txtLoai.Size = new System.Drawing.Size(470, 23);
			this._txtLoai.TabIndex = 5;
			// 
			// _txtPhienAm
			// 
			this._txtPhienAm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this._txtPhienAm.BackColor = System.Drawing.Color.White;
			this._txtPhienAm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtPhienAm.Font = new System.Drawing.Font("Segoe UI", 9F);
			this._txtPhienAm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
			this._txtPhienAm.Location = new System.Drawing.Point(613, 45);
			this._txtPhienAm.Margin = new System.Windows.Forms.Padding(4);
			this._txtPhienAm.MinimumSize = new System.Drawing.Size(150, 2);
			this._txtPhienAm.Name = "_txtPhienAm";
			this._txtPhienAm.Size = new System.Drawing.Size(471, 23);
			this._txtPhienAm.TabIndex = 7;
			// 
			// _txtNghia
			// 
			this._txtNghia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this._txtNghia.BackColor = System.Drawing.Color.White;
			this._txtNghia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtNghia.Font = new System.Drawing.Font("Segoe UI", 9F);
			this._txtNghia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
			this._txtNghia.Location = new System.Drawing.Point(61, 142);
			this._txtNghia.Margin = new System.Windows.Forms.Padding(4);
			this._txtNghia.MinimumSize = new System.Drawing.Size(150, 2);
			this._txtNghia.Name = "_txtNghia";
			this._txtNghia.Size = new System.Drawing.Size(470, 23);
			this._txtNghia.TabIndex = 9;
			// 
			// root
			// 
			this.root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1100F));
			this.root.Controls.Add(this._lblTitle, 0, 0);
			this.root.Controls.Add(this.form, 0, 1);
			this.root.Controls.Add(this._advancedSearchPanel, 0, 2);
			this.root.Controls.Add(this._grid, 0, 3);
			this.root.Dock = System.Windows.Forms.DockStyle.Fill;
			this.root.Location = new System.Drawing.Point(0, 0);
			this.root.Name = "root";
			this.root.RowCount = 4;
			this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
			this.root.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.root.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.root.Size = new System.Drawing.Size(1100, 720);
			this.root.TabIndex = 0;
			// 
			// form
			// 
			this.form.AutoSize = true;
			this.form.BackColor = System.Drawing.Color.White;
			this.form.ColumnCount = 4;
			this.form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.form.Controls.Add(this._lblDesigner1, 0, 0);
			this.form.Controls.Add(this._cboLop, 1, 0);
			this.form.Controls.Add(this._lblDesigner2, 2, 0);
			this.form.Controls.Add(this._txtTu, 3, 0);
			this.form.Controls.Add(this._lblDesigner3, 0, 1);
			this.form.Controls.Add(this._txtLoai, 1, 1);
			this.form.Controls.Add(this._lblDesigner4, 2, 1);
			this.form.Controls.Add(this._txtPhienAm, 3, 1);
			this.form.Controls.Add(this._lblDesigner5, 0, 2);
			this.form.Controls.Add(this._txtNghia, 1, 2);
			this.form.Controls.Add(this.buttons, 3, 2);
			this.form.Dock = System.Windows.Forms.DockStyle.Top;
			this.form.Location = new System.Drawing.Point(0, 52);
			this.form.Margin = new System.Windows.Forms.Padding(0);
			this.form.Name = "form";
			this.form.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
			this.form.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.form.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.form.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.form.Size = new System.Drawing.Size(1100, 245);
			this.form.TabIndex = 1;
			// 
			// buttons
			// 
			this.buttons.AutoSize = true;
			this.buttons.Controls.Add(this.btnMoi);
			this.buttons.Controls.Add(this.btnLuu);
			this.buttons.Controls.Add(this.btnXoa);
			this.buttons.Controls.Add(this._lblFilterKeyword);
			this.buttons.Controls.Add(this._txtTuKhoa);
			this.buttons.Controls.Add(this._lblFilterType);
			this.buttons.Controls.Add(this._cboLoaiFilter);
			this.buttons.Controls.Add(this._lblFilterLevel);
			this.buttons.Controls.Add(this._cboCapDoFilter);
			this.buttons.Controls.Add(this._lblFilterTopic);
			this.buttons.Controls.Add(this._cboChuDeFilter);
			this.buttons.Controls.Add(this._lblFilterLetter);
			this.buttons.Controls.Add(this._cboChuCaiFilter);
			this.buttons.Controls.Add(this.btnLoc);
			this.buttons.Controls.Add(this._btnToggleAdvancedSearch);
			this.buttons.Location = new System.Drawing.Point(612, 75);
			this.buttons.Name = "buttons";
			this.buttons.Size = new System.Drawing.Size(472, 157);
			this.buttons.TabIndex = 10;
			// 
			// btnMoi
			// 
			this.btnMoi.AutoEllipsis = true;
			this.btnMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
			this.btnMoi.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnMoi.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
			this.btnMoi.Location = new System.Drawing.Point(4, 4);
			this.btnMoi.Margin = new System.Windows.Forms.Padding(4);
			this.btnMoi.Name = "btnMoi";
			this.btnMoi.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.btnMoi.Size = new System.Drawing.Size(110, 34);
			this.btnMoi.TabIndex = 0;
			this.btnMoi.Text = "Thêm mới";
			this.btnMoi.UseVisualStyleBackColor = false;
			// 
			// btnLuu
			// 
			this.btnLuu.AutoEllipsis = true;
			this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
			this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnLuu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
			this.btnLuu.Location = new System.Drawing.Point(122, 4);
			this.btnLuu.Margin = new System.Windows.Forms.Padding(4);
			this.btnLuu.Name = "btnLuu";
			this.btnLuu.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.btnLuu.Size = new System.Drawing.Size(110, 34);
			this.btnLuu.TabIndex = 1;
			this.btnLuu.Text = "Lưu";
			this.btnLuu.UseVisualStyleBackColor = false;
			// 
			// btnXoa
			// 
			this.btnXoa.AutoEllipsis = true;
			this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
			this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnXoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
			this.btnXoa.Location = new System.Drawing.Point(240, 4);
			this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.btnXoa.Size = new System.Drawing.Size(110, 34);
			this.btnXoa.TabIndex = 2;
			this.btnXoa.Text = "Xóa";
			this.btnXoa.UseVisualStyleBackColor = false;
			// 
			// _lblFilterKeyword
			// 
			this._lblFilterKeyword.AutoSize = true;
			this._lblFilterKeyword.Location = new System.Drawing.Point(358, 8);
			this._lblFilterKeyword.Margin = new System.Windows.Forms.Padding(4, 8, 4, 2);
			this._lblFilterKeyword.Name = "_lblFilterKeyword";
			this._lblFilterKeyword.Size = new System.Drawing.Size(47, 13);
			this._lblFilterKeyword.TabIndex = 3;
			this._lblFilterKeyword.Text = "Từ khóa";
			// 
			// _txtTuKhoa
			// 
			this._txtTuKhoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtTuKhoa.Font = new System.Drawing.Font("Segoe UI", 9F);
			this._txtTuKhoa.Location = new System.Drawing.Point(4, 46);
			this._txtTuKhoa.Margin = new System.Windows.Forms.Padding(4);
			this._txtTuKhoa.MinimumSize = new System.Drawing.Size(150, 2);
			this._txtTuKhoa.Name = "_txtTuKhoa";
			this._txtTuKhoa.Size = new System.Drawing.Size(160, 23);
			this._txtTuKhoa.TabIndex = 4;
			// 
			// _lblFilterType
			// 
			this._lblFilterType.AutoSize = true;
			this._lblFilterType.Location = new System.Drawing.Point(172, 50);
			this._lblFilterType.Margin = new System.Windows.Forms.Padding(4, 8, 4, 2);
			this._lblFilterType.Name = "_lblFilterType";
			this._lblFilterType.Size = new System.Drawing.Size(27, 13);
			this._lblFilterType.TabIndex = 5;
			this._lblFilterType.Text = "Loại";
			// 
			// _cboLoaiFilter
			// 
			this._cboLoaiFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._cboLoaiFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._cboLoaiFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
			this._cboLoaiFilter.Location = new System.Drawing.Point(207, 46);
			this._cboLoaiFilter.Margin = new System.Windows.Forms.Padding(4);
			this._cboLoaiFilter.MinimumSize = new System.Drawing.Size(120, 0);
			this._cboLoaiFilter.Name = "_cboLoaiFilter";
			this._cboLoaiFilter.Size = new System.Drawing.Size(120, 23);
			this._cboLoaiFilter.TabIndex = 6;
			// 
			// _lblFilterLevel
			// 
			this._lblFilterLevel.AutoSize = true;
			this._lblFilterLevel.Location = new System.Drawing.Point(335, 50);
			this._lblFilterLevel.Margin = new System.Windows.Forms.Padding(4, 8, 4, 2);
			this._lblFilterLevel.Name = "_lblFilterLevel";
			this._lblFilterLevel.Size = new System.Drawing.Size(35, 13);
			this._lblFilterLevel.TabIndex = 7;
			this._lblFilterLevel.Text = "CEFR";
			// 
			// _cboCapDoFilter
			// 
			this._cboCapDoFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._cboCapDoFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._cboCapDoFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
			this._cboCapDoFilter.Location = new System.Drawing.Point(378, 46);
			this._cboCapDoFilter.Margin = new System.Windows.Forms.Padding(4);
			this._cboCapDoFilter.MinimumSize = new System.Drawing.Size(90, 0);
			this._cboCapDoFilter.Name = "_cboCapDoFilter";
			this._cboCapDoFilter.Size = new System.Drawing.Size(90, 23);
			this._cboCapDoFilter.TabIndex = 8;
			// 
			// _lblFilterTopic
			// 
			this._lblFilterTopic.AutoSize = true;
			this._lblFilterTopic.Location = new System.Drawing.Point(4, 81);
			this._lblFilterTopic.Margin = new System.Windows.Forms.Padding(4, 8, 4, 2);
			this._lblFilterTopic.Name = "_lblFilterTopic";
			this._lblFilterTopic.Size = new System.Drawing.Size(42, 13);
			this._lblFilterTopic.TabIndex = 9;
			this._lblFilterTopic.Text = "Chủ đề";
			// 
			// _cboChuDeFilter
			// 
			this._cboChuDeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._cboChuDeFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._cboChuDeFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
			this._cboChuDeFilter.Location = new System.Drawing.Point(54, 77);
			this._cboChuDeFilter.Margin = new System.Windows.Forms.Padding(4);
			this._cboChuDeFilter.MinimumSize = new System.Drawing.Size(150, 0);
			this._cboChuDeFilter.Name = "_cboChuDeFilter";
			this._cboChuDeFilter.Size = new System.Drawing.Size(180, 23);
			this._cboChuDeFilter.TabIndex = 10;
			// 
			// _lblFilterLetter
			// 
			this._lblFilterLetter.AutoSize = true;
			this._lblFilterLetter.Location = new System.Drawing.Point(242, 81);
			this._lblFilterLetter.Margin = new System.Windows.Forms.Padding(4, 8, 4, 2);
			this._lblFilterLetter.Name = "_lblFilterLetter";
			this._lblFilterLetter.Size = new System.Drawing.Size(24, 13);
			this._lblFilterLetter.TabIndex = 11;
			this._lblFilterLetter.Text = "A-Z";
			// 
			// _cboChuCaiFilter
			// 
			this._cboChuCaiFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._cboChuCaiFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._cboChuCaiFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
			this._cboChuCaiFilter.Location = new System.Drawing.Point(274, 77);
			this._cboChuCaiFilter.Margin = new System.Windows.Forms.Padding(4);
			this._cboChuCaiFilter.MinimumSize = new System.Drawing.Size(80, 0);
			this._cboChuCaiFilter.Name = "_cboChuCaiFilter";
			this._cboChuCaiFilter.Size = new System.Drawing.Size(80, 23);
			this._cboChuCaiFilter.TabIndex = 12;
			// 
			// btnLoc
			// 
			this.btnLoc.AutoEllipsis = true;
			this.btnLoc.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLoc.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnLoc.Location = new System.Drawing.Point(362, 77);
			this.btnLoc.Margin = new System.Windows.Forms.Padding(4);
			this.btnLoc.Name = "btnLoc";
			this.btnLoc.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.btnLoc.Size = new System.Drawing.Size(70, 34);
			this.btnLoc.TabIndex = 13;
			this.btnLoc.Text = "Lọc";
			this.btnLoc.UseVisualStyleBackColor = false;
			// 
			// _btnToggleAdvancedSearch
			// 
			this._btnToggleAdvancedSearch.AutoEllipsis = true;
			this._btnToggleAdvancedSearch.Cursor = System.Windows.Forms.Cursors.Hand;
			this._btnToggleAdvancedSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._btnToggleAdvancedSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
			this._btnToggleAdvancedSearch.Location = new System.Drawing.Point(4, 119);
			this._btnToggleAdvancedSearch.Margin = new System.Windows.Forms.Padding(4);
			this._btnToggleAdvancedSearch.Name = "_btnToggleAdvancedSearch";
			this._btnToggleAdvancedSearch.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this._btnToggleAdvancedSearch.Size = new System.Drawing.Size(150, 34);
			this._btnToggleAdvancedSearch.TabIndex = 14;
			this._btnToggleAdvancedSearch.Text = "Tìm kiếm nâng cao";
			this._btnToggleAdvancedSearch.UseVisualStyleBackColor = false;
			// 
			// _advancedSearchPanel
			// 
			this._advancedSearchPanel.AutoSize = true;
			this._advancedSearchPanel.ColumnCount = 1;
			this._advancedSearchPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this._advancedSearchPanel.Controls.Add(this._advancedEditRow, 0, 0);
			this._advancedSearchPanel.Controls.Add(this._gridAdvancedConditions, 0, 1);
			this._advancedSearchPanel.Controls.Add(this._advancedActionRow, 0, 2);
			this._advancedSearchPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this._advancedSearchPanel.Location = new System.Drawing.Point(3, 300);
			this._advancedSearchPanel.Name = "_advancedSearchPanel";
			this._advancedSearchPanel.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
			this._advancedSearchPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this._advancedSearchPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this._advancedSearchPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this._advancedSearchPanel.Size = new System.Drawing.Size(1094, 233);
			this._advancedSearchPanel.TabIndex = 2;
			this._advancedSearchPanel.Visible = false;
			// 
			// _advancedEditRow
			// 
			this._advancedEditRow.AutoSize = true;
			this._advancedEditRow.Controls.Add(this._lblAdvancedJoin);
			this._advancedEditRow.Controls.Add(this._cboAdvancedJoin);
			this._advancedEditRow.Controls.Add(this._btnAdvancedOpenParenthesis);
			this._advancedEditRow.Controls.Add(this._lblAdvancedField);
			this._advancedEditRow.Controls.Add(this._cboAdvancedField);
			this._advancedEditRow.Controls.Add(this._lblAdvancedValue);
			this._advancedEditRow.Controls.Add(this._txtAdvancedValue);
			this._advancedEditRow.Controls.Add(this._cboAdvancedValue);
			this._advancedEditRow.Controls.Add(this._btnAdvancedCloseParenthesis);
			this._advancedEditRow.Controls.Add(this._btnAddAdvancedCondition);
			this._advancedEditRow.Dock = System.Windows.Forms.DockStyle.Top;
			this._advancedEditRow.Location = new System.Drawing.Point(15, 11);
			this._advancedEditRow.Name = "_advancedEditRow";
			this._advancedEditRow.Size = new System.Drawing.Size(1064, 42);
			this._advancedEditRow.TabIndex = 0;
			// 
			// _lblAdvancedJoin
			// 
			this._lblAdvancedJoin.AutoSize = true;
			this._lblAdvancedJoin.Location = new System.Drawing.Point(4, 8);
			this._lblAdvancedJoin.Margin = new System.Windows.Forms.Padding(4, 8, 4, 2);
			this._lblAdvancedJoin.Name = "_lblAdvancedJoin";
			this._lblAdvancedJoin.Size = new System.Drawing.Size(44, 13);
			this._lblAdvancedJoin.TabIndex = 0;
			this._lblAdvancedJoin.Text = "Kết hợp";
			// 
			// _cboAdvancedJoin
			// 
			this._cboAdvancedJoin.DisplayMember = "Label";
			this._cboAdvancedJoin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._cboAdvancedJoin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._cboAdvancedJoin.Font = new System.Drawing.Font("Segoe UI", 9F);
			this._cboAdvancedJoin.Location = new System.Drawing.Point(56, 4);
			this._cboAdvancedJoin.Margin = new System.Windows.Forms.Padding(4);
			this._cboAdvancedJoin.MinimumSize = new System.Drawing.Size(80, 0);
			this._cboAdvancedJoin.Name = "_cboAdvancedJoin";
			this._cboAdvancedJoin.Size = new System.Drawing.Size(80, 23);
			this._cboAdvancedJoin.TabIndex = 1;
			this._cboAdvancedJoin.ValueMember = "Value";
			// 
			// _btnAdvancedOpenParenthesis
			// 
			this._btnAdvancedOpenParenthesis.AutoEllipsis = true;
			this._btnAdvancedOpenParenthesis.Cursor = System.Windows.Forms.Cursors.Hand;
			this._btnAdvancedOpenParenthesis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._btnAdvancedOpenParenthesis.Font = new System.Drawing.Font("Segoe UI", 9F);
			this._btnAdvancedOpenParenthesis.Location = new System.Drawing.Point(144, 4);
			this._btnAdvancedOpenParenthesis.Margin = new System.Windows.Forms.Padding(4);
			this._btnAdvancedOpenParenthesis.Name = "_btnAdvancedOpenParenthesis";
			this._btnAdvancedOpenParenthesis.Size = new System.Drawing.Size(46, 34);
			this._btnAdvancedOpenParenthesis.TabIndex = 2;
			this._btnAdvancedOpenParenthesis.Text = "(";
			this._btnAdvancedOpenParenthesis.UseVisualStyleBackColor = false;
			// 
			// _lblAdvancedField
			// 
			this._lblAdvancedField.AutoSize = true;
			this._lblAdvancedField.Location = new System.Drawing.Point(198, 8);
			this._lblAdvancedField.Margin = new System.Windows.Forms.Padding(4, 8, 4, 2);
			this._lblAdvancedField.Name = "_lblAdvancedField";
			this._lblAdvancedField.Size = new System.Drawing.Size(41, 13);
			this._lblAdvancedField.TabIndex = 3;
			this._lblAdvancedField.Text = "Trường";
			// 
			// _cboAdvancedField
			// 
			this._cboAdvancedField.DisplayMember = "Label";
			this._cboAdvancedField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._cboAdvancedField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._cboAdvancedField.Font = new System.Drawing.Font("Segoe UI", 9F);
			this._cboAdvancedField.Location = new System.Drawing.Point(247, 4);
			this._cboAdvancedField.Margin = new System.Windows.Forms.Padding(4);
			this._cboAdvancedField.MinimumSize = new System.Drawing.Size(140, 0);
			this._cboAdvancedField.Name = "_cboAdvancedField";
			this._cboAdvancedField.Size = new System.Drawing.Size(140, 23);
			this._cboAdvancedField.TabIndex = 4;
			this._cboAdvancedField.ValueMember = "Value";
			// 
			// _lblAdvancedValue
			// 
			this._lblAdvancedValue.AutoSize = true;
			this._lblAdvancedValue.Location = new System.Drawing.Point(395, 8);
			this._lblAdvancedValue.Margin = new System.Windows.Forms.Padding(4, 8, 4, 2);
			this._lblAdvancedValue.Name = "_lblAdvancedValue";
			this._lblAdvancedValue.Size = new System.Drawing.Size(34, 13);
			this._lblAdvancedValue.TabIndex = 5;
			this._lblAdvancedValue.Text = "Giá trị";
			// 
			// _txtAdvancedValue
			// 
			this._txtAdvancedValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtAdvancedValue.Font = new System.Drawing.Font("Segoe UI", 9F);
			this._txtAdvancedValue.Location = new System.Drawing.Point(437, 4);
			this._txtAdvancedValue.Margin = new System.Windows.Forms.Padding(4);
			this._txtAdvancedValue.MinimumSize = new System.Drawing.Size(150, 2);
			this._txtAdvancedValue.Name = "_txtAdvancedValue";
			this._txtAdvancedValue.Size = new System.Drawing.Size(180, 23);
			this._txtAdvancedValue.TabIndex = 6;
			// 
			// _cboAdvancedValue
			// 
			this._cboAdvancedValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._cboAdvancedValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._cboAdvancedValue.Font = new System.Drawing.Font("Segoe UI", 9F);
			this._cboAdvancedValue.Location = new System.Drawing.Point(625, 4);
			this._cboAdvancedValue.Margin = new System.Windows.Forms.Padding(4);
			this._cboAdvancedValue.MinimumSize = new System.Drawing.Size(150, 0);
			this._cboAdvancedValue.Name = "_cboAdvancedValue";
			this._cboAdvancedValue.Size = new System.Drawing.Size(180, 23);
			this._cboAdvancedValue.TabIndex = 7;
			// 
			// _btnAdvancedCloseParenthesis
			// 
			this._btnAdvancedCloseParenthesis.AutoEllipsis = true;
			this._btnAdvancedCloseParenthesis.Cursor = System.Windows.Forms.Cursors.Hand;
			this._btnAdvancedCloseParenthesis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._btnAdvancedCloseParenthesis.Font = new System.Drawing.Font("Segoe UI", 9F);
			this._btnAdvancedCloseParenthesis.Location = new System.Drawing.Point(813, 4);
			this._btnAdvancedCloseParenthesis.Margin = new System.Windows.Forms.Padding(4);
			this._btnAdvancedCloseParenthesis.Name = "_btnAdvancedCloseParenthesis";
			this._btnAdvancedCloseParenthesis.Size = new System.Drawing.Size(46, 34);
			this._btnAdvancedCloseParenthesis.TabIndex = 8;
			this._btnAdvancedCloseParenthesis.Text = ")";
			this._btnAdvancedCloseParenthesis.UseVisualStyleBackColor = false;
			// 
			// _btnAddAdvancedCondition
			// 
			this._btnAddAdvancedCondition.AutoEllipsis = true;
			this._btnAddAdvancedCondition.Cursor = System.Windows.Forms.Cursors.Hand;
			this._btnAddAdvancedCondition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._btnAddAdvancedCondition.Font = new System.Drawing.Font("Segoe UI", 9F);
			this._btnAddAdvancedCondition.Location = new System.Drawing.Point(867, 4);
			this._btnAddAdvancedCondition.Margin = new System.Windows.Forms.Padding(4);
			this._btnAddAdvancedCondition.Name = "_btnAddAdvancedCondition";
			this._btnAddAdvancedCondition.Size = new System.Drawing.Size(130, 34);
			this._btnAddAdvancedCondition.TabIndex = 9;
			this._btnAddAdvancedCondition.Text = "Thêm điều kiện";
			this._btnAddAdvancedCondition.UseVisualStyleBackColor = false;
			// 
			// _gridAdvancedConditions
			// 
			this._gridAdvancedConditions.AllowUserToAddRows = false;
			this._gridAdvancedConditions.AllowUserToDeleteRows = false;
			this._gridAdvancedConditions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this._gridAdvancedConditions.BackgroundColor = System.Drawing.Color.White;
			this._gridAdvancedConditions.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._gridAdvancedConditions.ColumnHeadersHeight = 34;
			this._gridAdvancedConditions.Dock = System.Windows.Forms.DockStyle.Top;
			this._gridAdvancedConditions.Location = new System.Drawing.Point(15, 59);
			this._gridAdvancedConditions.MinimumSize = new System.Drawing.Size(320, 90);
			this._gridAdvancedConditions.MultiSelect = false;
			this._gridAdvancedConditions.Name = "_gridAdvancedConditions";
			this._gridAdvancedConditions.ReadOnly = true;
			this._gridAdvancedConditions.RowHeadersVisible = false;
			this._gridAdvancedConditions.RowTemplate.Height = 30;
			this._gridAdvancedConditions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this._gridAdvancedConditions.Size = new System.Drawing.Size(1064, 115);
			this._gridAdvancedConditions.TabIndex = 1;
			// 
			// _advancedActionRow
			// 
			this._advancedActionRow.AutoSize = true;
			this._advancedActionRow.Controls.Add(this._btnRemoveAdvancedCondition);
			this._advancedActionRow.Controls.Add(this._btnClearAdvancedConditions);
			this._advancedActionRow.Controls.Add(this._btnRunAdvancedSearch);
			this._advancedActionRow.Dock = System.Windows.Forms.DockStyle.Top;
			this._advancedActionRow.Location = new System.Drawing.Point(15, 180);
			this._advancedActionRow.Name = "_advancedActionRow";
			this._advancedActionRow.Size = new System.Drawing.Size(1064, 42);
			this._advancedActionRow.TabIndex = 2;
			// 
			// _btnRemoveAdvancedCondition
			// 
			this._btnRemoveAdvancedCondition.AutoEllipsis = true;
			this._btnRemoveAdvancedCondition.Cursor = System.Windows.Forms.Cursors.Hand;
			this._btnRemoveAdvancedCondition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._btnRemoveAdvancedCondition.Font = new System.Drawing.Font("Segoe UI", 9F);
			this._btnRemoveAdvancedCondition.Location = new System.Drawing.Point(4, 4);
			this._btnRemoveAdvancedCondition.Margin = new System.Windows.Forms.Padding(4);
			this._btnRemoveAdvancedCondition.Name = "_btnRemoveAdvancedCondition";
			this._btnRemoveAdvancedCondition.Size = new System.Drawing.Size(120, 34);
			this._btnRemoveAdvancedCondition.TabIndex = 0;
			this._btnRemoveAdvancedCondition.Text = "Xóa điều kiện";
			this._btnRemoveAdvancedCondition.UseVisualStyleBackColor = false;
			// 
			// _btnClearAdvancedConditions
			// 
			this._btnClearAdvancedConditions.AutoEllipsis = true;
			this._btnClearAdvancedConditions.Cursor = System.Windows.Forms.Cursors.Hand;
			this._btnClearAdvancedConditions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._btnClearAdvancedConditions.Font = new System.Drawing.Font("Segoe UI", 9F);
			this._btnClearAdvancedConditions.Location = new System.Drawing.Point(132, 4);
			this._btnClearAdvancedConditions.Margin = new System.Windows.Forms.Padding(4);
			this._btnClearAdvancedConditions.Name = "_btnClearAdvancedConditions";
			this._btnClearAdvancedConditions.Size = new System.Drawing.Size(110, 34);
			this._btnClearAdvancedConditions.TabIndex = 1;
			this._btnClearAdvancedConditions.Text = "Xóa tất cả";
			this._btnClearAdvancedConditions.UseVisualStyleBackColor = false;
			// 
			// _btnRunAdvancedSearch
			// 
			this._btnRunAdvancedSearch.AutoEllipsis = true;
			this._btnRunAdvancedSearch.Cursor = System.Windows.Forms.Cursors.Hand;
			this._btnRunAdvancedSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._btnRunAdvancedSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
			this._btnRunAdvancedSearch.Location = new System.Drawing.Point(250, 4);
			this._btnRunAdvancedSearch.Margin = new System.Windows.Forms.Padding(4);
			this._btnRunAdvancedSearch.Name = "_btnRunAdvancedSearch";
			this._btnRunAdvancedSearch.Size = new System.Drawing.Size(110, 34);
			this._btnRunAdvancedSearch.TabIndex = 2;
			this._btnRunAdvancedSearch.Text = "Tìm kiếm";
			this._btnRunAdvancedSearch.UseVisualStyleBackColor = false;
			// 
			// FrmTuVung
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1100, 720);
			this.Controls.Add(this.root);
			this.Name = "FrmTuVung";
			this.Text = "Cập nhật kho từ vựng";
			((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
			this.root.ResumeLayout(false);
			this.root.PerformLayout();
			this.form.ResumeLayout(false);
			this.form.PerformLayout();
			this.buttons.ResumeLayout(false);
			this.buttons.PerformLayout();
			this._advancedSearchPanel.ResumeLayout(false);
			this._advancedSearchPanel.PerformLayout();
			this._advancedEditRow.ResumeLayout(false);
			this._advancedEditRow.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this._gridAdvancedConditions)).EndInit();
			this._advancedActionRow.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}