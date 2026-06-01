using System.Drawing;
using System.Windows.Forms;

namespace DesktopApp_Project.GUI
{
    partial class FrmPaymentDebug
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel _root;
        private TableLayoutPanel _top;
        private GroupBox _grpInput;
        private TableLayoutPanel _inputForm;
        private GroupBox _grpDetail;
        private TableLayoutPanel _detailRoot;
        private TableLayoutPanel _detailForm;
        private FlowLayoutPanel _detailButtons;
        private GroupBox _grpGrid;
        private TableLayoutPanel _gridRoot;
        private FlowLayoutPanel _gridToolbar;
        private Label _lblStudentNameCaption;
        private Label _lblReceiverEmailCaption;
        private Label _lblClassNameCaption;
        private Label _lblAmountCaption;
        private Label _lblInvoiceCodeCaption;
        private Label _lblPaymentMethodCaption;
        private Label _lblPaymentContentCaption;
        private Label _lblDebugNoteCaption;
        private Label _lblTransactionIdCaption;
        private Label _lblExternalRefCaption;
        private Label _lblReceiverEmailCaption2;
        private Label _lblPaymentStatusCaption;
        private Label _lblTuitionStatusCaption;
        private Label _lblPaymentEmailCaption;
        private Label _lblPaymentEmailAtCaption;
        private Label _lblPaymentEmailErrorCaption;
        private Label _lblStatusEmailCaption;
        private Label _lblStatusEmailAtCaption;
        private Label _lblStatusEmailErrorCaption;
        private Label _lblUpdatedAtCaption;
        private TextBox _txtStudentName;
        private TextBox _txtReceiverEmail;
        private TextBox _txtClassName;
        private NumericUpDown _numAmount;
        private TextBox _txtInvoiceCode;
        private ComboBox _cboPaymentMethod;
        private TextBox _txtPaymentContent;
        private TextBox _txtDebugNote;
        private TextBox _txtPaymentUrl;
        private Label _lblTransactionId;
        private Label _lblExternalRef;
        private Label _lblReceiverEmail;
        private Label _lblPaymentStatus;
        private Label _lblTuitionStatus;
        private Label _lblPaymentEmail;
        private Label _lblPaymentEmailAt;
        private Label _lblPaymentEmailError;
        private Label _lblStatusEmail;
        private Label _lblStatusEmailAt;
        private Label _lblStatusEmailError;
        private Label _lblUpdatedAt;
        private Button _btnCreate;
        private Button _btnCopyUrl;
        private Button _btnOpenUrl;
        private Button _btnResend;
        private Button _btnFakeComplete;
        private Button _btnFakeExpired;
        private Button _btnFakeFailed;
        private Button _btnRefresh;
        private DataGridView _grid;
        private DataGridViewTextBoxColumn _colTransactionId;
        private DataGridViewTextBoxColumn _colStudentName;
        private DataGridViewTextBoxColumn _colReceiverEmail;
        private DataGridViewTextBoxColumn _colAmount;
        private DataGridViewTextBoxColumn _colPaymentMethod;
        private DataGridViewTextBoxColumn _colPaymentStatus;
        private DataGridViewTextBoxColumn _colPaymentUrlExists;
        private DataGridViewTextBoxColumn _colPaymentEmailSent;
        private DataGridViewTextBoxColumn _colPaymentEmailSentAt;
        private DataGridViewTextBoxColumn _colStatusEmailSent;
        private DataGridViewTextBoxColumn _colStatusEmailSentAt;
        private DataGridViewTextBoxColumn _colUpdatedAt;

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
            this._root = new System.Windows.Forms.TableLayoutPanel();
            this._top = new System.Windows.Forms.TableLayoutPanel();
            this._grpInput = new System.Windows.Forms.GroupBox();
            this._inputForm = new System.Windows.Forms.TableLayoutPanel();
            this._lblStudentNameCaption = new System.Windows.Forms.Label();
            this._txtStudentName = new System.Windows.Forms.TextBox();
            this._lblReceiverEmailCaption = new System.Windows.Forms.Label();
            this._txtReceiverEmail = new System.Windows.Forms.TextBox();
            this._lblClassNameCaption = new System.Windows.Forms.Label();
            this._txtClassName = new System.Windows.Forms.TextBox();
            this._lblAmountCaption = new System.Windows.Forms.Label();
            this._numAmount = new System.Windows.Forms.NumericUpDown();
            this._lblInvoiceCodeCaption = new System.Windows.Forms.Label();
            this._txtInvoiceCode = new System.Windows.Forms.TextBox();
            this._lblPaymentMethodCaption = new System.Windows.Forms.Label();
            this._cboPaymentMethod = new System.Windows.Forms.ComboBox();
            this._lblPaymentContentCaption = new System.Windows.Forms.Label();
            this._txtPaymentContent = new System.Windows.Forms.TextBox();
            this._lblDebugNoteCaption = new System.Windows.Forms.Label();
            this._txtDebugNote = new System.Windows.Forms.TextBox();
            this._btnCreate = new System.Windows.Forms.Button();
            this._grpDetail = new System.Windows.Forms.GroupBox();
            this._detailRoot = new System.Windows.Forms.TableLayoutPanel();
            this._detailForm = new System.Windows.Forms.TableLayoutPanel();
            this._lblTransactionIdCaption = new System.Windows.Forms.Label();
            this._lblTransactionId = new System.Windows.Forms.Label();
            this._lblExternalRefCaption = new System.Windows.Forms.Label();
            this._lblExternalRef = new System.Windows.Forms.Label();
            this._lblReceiverEmailCaption2 = new System.Windows.Forms.Label();
            this._lblReceiverEmail = new System.Windows.Forms.Label();
            this._lblPaymentStatusCaption = new System.Windows.Forms.Label();
            this._lblPaymentStatus = new System.Windows.Forms.Label();
            this._lblTuitionStatusCaption = new System.Windows.Forms.Label();
            this._lblTuitionStatus = new System.Windows.Forms.Label();
            this._lblPaymentEmailCaption = new System.Windows.Forms.Label();
            this._lblPaymentEmail = new System.Windows.Forms.Label();
            this._lblPaymentEmailAtCaption = new System.Windows.Forms.Label();
            this._lblPaymentEmailAt = new System.Windows.Forms.Label();
            this._lblPaymentEmailErrorCaption = new System.Windows.Forms.Label();
            this._lblPaymentEmailError = new System.Windows.Forms.Label();
            this._lblStatusEmailCaption = new System.Windows.Forms.Label();
            this._lblStatusEmail = new System.Windows.Forms.Label();
            this._lblStatusEmailAtCaption = new System.Windows.Forms.Label();
            this._lblStatusEmailAt = new System.Windows.Forms.Label();
            this._lblStatusEmailErrorCaption = new System.Windows.Forms.Label();
            this._lblStatusEmailError = new System.Windows.Forms.Label();
            this._lblUpdatedAtCaption = new System.Windows.Forms.Label();
            this._lblUpdatedAt = new System.Windows.Forms.Label();
            this._txtPaymentUrl = new System.Windows.Forms.TextBox();
            this._detailButtons = new System.Windows.Forms.FlowLayoutPanel();
            this._btnCopyUrl = new System.Windows.Forms.Button();
            this._btnOpenUrl = new System.Windows.Forms.Button();
            this._btnResend = new System.Windows.Forms.Button();
            this._btnFakeComplete = new System.Windows.Forms.Button();
            this._btnFakeExpired = new System.Windows.Forms.Button();
            this._btnFakeFailed = new System.Windows.Forms.Button();
            this._grpGrid = new System.Windows.Forms.GroupBox();
            this._gridRoot = new System.Windows.Forms.TableLayoutPanel();
            this._gridToolbar = new System.Windows.Forms.FlowLayoutPanel();
            this._btnRefresh = new System.Windows.Forms.Button();
            this._grid = new System.Windows.Forms.DataGridView();
            this._root.SuspendLayout();
            this._top.SuspendLayout();
            this._grpInput.SuspendLayout();
            this._inputForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numAmount)).BeginInit();
            this._grpDetail.SuspendLayout();
            this._detailRoot.SuspendLayout();
            this._detailForm.SuspendLayout();
            this._detailButtons.SuspendLayout();
            this._grpGrid.SuspendLayout();
            this._gridRoot.SuspendLayout();
            this._gridToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();
            // 
            // _root
            // 
            this._root.ColumnCount = 1;
            this._root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._root.Controls.Add(this._top, 0, 0);
            this._root.Controls.Add(this._grpGrid, 0, 1);
            this._root.Dock = System.Windows.Forms.DockStyle.Fill;
            this._root.Location = new System.Drawing.Point(0, 0);
            this._root.Name = "_root";
            this._root.Padding = new System.Windows.Forms.Padding(12);
            this._root.RowCount = 2;
            this._root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 380F));
            this._root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._root.Size = new System.Drawing.Size(1080, 720);
            this._root.TabIndex = 0;
            // 
            // _top
            // 
            this._top.ColumnCount = 2;
            this._top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this._top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this._top.Controls.Add(this._grpInput, 0, 0);
            this._top.Controls.Add(this._grpDetail, 1, 0);
            this._top.Dock = System.Windows.Forms.DockStyle.Fill;
            this._top.Location = new System.Drawing.Point(15, 15);
            this._top.Name = "_top";
            this._top.RowCount = 1;
            this._top.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._top.Size = new System.Drawing.Size(1050, 374);
            this._top.TabIndex = 0;
            // 
            // _grpInput
            // 
            this._grpInput.Controls.Add(this._inputForm);
            this._grpInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grpInput.Location = new System.Drawing.Point(3, 3);
            this._grpInput.Name = "_grpInput";
            this._grpInput.Padding = new System.Windows.Forms.Padding(10);
            this._grpInput.Size = new System.Drawing.Size(435, 368);
            this._grpInput.TabIndex = 0;
            this._grpInput.TabStop = false;
            this._grpInput.Text = "Tao thanh toan debug";
            // 
            // _inputForm
            // 
            this._inputForm.ColumnCount = 2;
            this._inputForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this._inputForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._inputForm.Controls.Add(this._lblStudentNameCaption, 0, 0);
            this._inputForm.Controls.Add(this._txtStudentName, 1, 0);
            this._inputForm.Controls.Add(this._lblReceiverEmailCaption, 0, 1);
            this._inputForm.Controls.Add(this._txtReceiverEmail, 1, 1);
            this._inputForm.Controls.Add(this._lblClassNameCaption, 0, 2);
            this._inputForm.Controls.Add(this._txtClassName, 1, 2);
            this._inputForm.Controls.Add(this._lblAmountCaption, 0, 3);
            this._inputForm.Controls.Add(this._numAmount, 1, 3);
            this._inputForm.Controls.Add(this._lblInvoiceCodeCaption, 0, 4);
            this._inputForm.Controls.Add(this._txtInvoiceCode, 1, 4);
            this._inputForm.Controls.Add(this._lblPaymentMethodCaption, 0, 5);
            this._inputForm.Controls.Add(this._cboPaymentMethod, 1, 5);
            this._inputForm.Controls.Add(this._lblPaymentContentCaption, 0, 6);
            this._inputForm.Controls.Add(this._txtPaymentContent, 1, 6);
            this._inputForm.Controls.Add(this._lblDebugNoteCaption, 0, 7);
            this._inputForm.Controls.Add(this._txtDebugNote, 1, 7);
            this._inputForm.Controls.Add(this._btnCreate, 1, 8);
            this._inputForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this._inputForm.Location = new System.Drawing.Point(10, 23);
            this._inputForm.Name = "_inputForm";
            this._inputForm.RowCount = 9;
            this._inputForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this._inputForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this._inputForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this._inputForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this._inputForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this._inputForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this._inputForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this._inputForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this._inputForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this._inputForm.Size = new System.Drawing.Size(415, 335);
            this._inputForm.TabIndex = 0;
            // 
            // _lblStudentNameCaption
            // 
            this._lblStudentNameCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblStudentNameCaption.Location = new System.Drawing.Point(3, 0);
            this._lblStudentNameCaption.Name = "_lblStudentNameCaption";
            this._lblStudentNameCaption.Size = new System.Drawing.Size(124, 34);
            this._lblStudentNameCaption.TabIndex = 0;
            this._lblStudentNameCaption.Text = "Hoc sinh";
            this._lblStudentNameCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _txtStudentName
            // 
            this._txtStudentName.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtStudentName.Location = new System.Drawing.Point(133, 3);
            this._txtStudentName.Name = "_txtStudentName";
            this._txtStudentName.Size = new System.Drawing.Size(279, 20);
            this._txtStudentName.TabIndex = 1;
            // 
            // _lblReceiverEmailCaption
            // 
            this._lblReceiverEmailCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblReceiverEmailCaption.Location = new System.Drawing.Point(3, 34);
            this._lblReceiverEmailCaption.Name = "_lblReceiverEmailCaption";
            this._lblReceiverEmailCaption.Size = new System.Drawing.Size(124, 34);
            this._lblReceiverEmailCaption.TabIndex = 2;
            this._lblReceiverEmailCaption.Text = "Email nhan";
            this._lblReceiverEmailCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _txtReceiverEmail
            // 
            this._txtReceiverEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtReceiverEmail.Location = new System.Drawing.Point(133, 37);
            this._txtReceiverEmail.Name = "_txtReceiverEmail";
            this._txtReceiverEmail.Size = new System.Drawing.Size(279, 20);
            this._txtReceiverEmail.TabIndex = 3;
            // 
            // _lblClassNameCaption
            // 
            this._lblClassNameCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblClassNameCaption.Location = new System.Drawing.Point(3, 68);
            this._lblClassNameCaption.Name = "_lblClassNameCaption";
            this._lblClassNameCaption.Size = new System.Drawing.Size(124, 34);
            this._lblClassNameCaption.TabIndex = 4;
            this._lblClassNameCaption.Text = "Lop / ghi chu";
            this._lblClassNameCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _txtClassName
            // 
            this._txtClassName.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtClassName.Location = new System.Drawing.Point(133, 71);
            this._txtClassName.Name = "_txtClassName";
            this._txtClassName.Size = new System.Drawing.Size(279, 20);
            this._txtClassName.TabIndex = 5;
            // 
            // _lblAmountCaption
            // 
            this._lblAmountCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblAmountCaption.Location = new System.Drawing.Point(3, 102);
            this._lblAmountCaption.Name = "_lblAmountCaption";
            this._lblAmountCaption.Size = new System.Drawing.Size(124, 34);
            this._lblAmountCaption.TabIndex = 6;
            this._lblAmountCaption.Text = "So tien";
            this._lblAmountCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _numAmount
            // 
            this._numAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this._numAmount.Location = new System.Drawing.Point(133, 105);
            this._numAmount.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this._numAmount.Name = "_numAmount";
            this._numAmount.Size = new System.Drawing.Size(279, 20);
            this._numAmount.TabIndex = 7;
            this._numAmount.ThousandsSeparator = true;
            this._numAmount.Value = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            // 
            // _lblInvoiceCodeCaption
            // 
            this._lblInvoiceCodeCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblInvoiceCodeCaption.Location = new System.Drawing.Point(3, 136);
            this._lblInvoiceCodeCaption.Name = "_lblInvoiceCodeCaption";
            this._lblInvoiceCodeCaption.Size = new System.Drawing.Size(124, 34);
            this._lblInvoiceCodeCaption.TabIndex = 8;
            this._lblInvoiceCodeCaption.Text = "Ma hoa don";
            this._lblInvoiceCodeCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _txtInvoiceCode
            // 
            this._txtInvoiceCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtInvoiceCode.Location = new System.Drawing.Point(133, 139);
            this._txtInvoiceCode.Name = "_txtInvoiceCode";
            this._txtInvoiceCode.Size = new System.Drawing.Size(279, 20);
            this._txtInvoiceCode.TabIndex = 9;
            // 
            // _lblPaymentMethodCaption
            // 
            this._lblPaymentMethodCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblPaymentMethodCaption.Location = new System.Drawing.Point(3, 170);
            this._lblPaymentMethodCaption.Name = "_lblPaymentMethodCaption";
            this._lblPaymentMethodCaption.Size = new System.Drawing.Size(124, 34);
            this._lblPaymentMethodCaption.TabIndex = 10;
            this._lblPaymentMethodCaption.Text = "Phuong thuc";
            this._lblPaymentMethodCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _cboPaymentMethod
            // 
            this._cboPaymentMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cboPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboPaymentMethod.FormattingEnabled = true;
            this._cboPaymentMethod.Location = new System.Drawing.Point(133, 173);
            this._cboPaymentMethod.Name = "_cboPaymentMethod";
            this._cboPaymentMethod.Size = new System.Drawing.Size(279, 21);
            this._cboPaymentMethod.TabIndex = 11;
            // 
            // _lblPaymentContentCaption
            // 
            this._lblPaymentContentCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblPaymentContentCaption.Location = new System.Drawing.Point(3, 204);
            this._lblPaymentContentCaption.Name = "_lblPaymentContentCaption";
            this._lblPaymentContentCaption.Size = new System.Drawing.Size(124, 34);
            this._lblPaymentContentCaption.TabIndex = 12;
            this._lblPaymentContentCaption.Text = "Noi dung";
            this._lblPaymentContentCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _txtPaymentContent
            // 
            this._txtPaymentContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtPaymentContent.Location = new System.Drawing.Point(133, 207);
            this._txtPaymentContent.Name = "_txtPaymentContent";
            this._txtPaymentContent.Size = new System.Drawing.Size(279, 20);
            this._txtPaymentContent.TabIndex = 13;
            // 
            // _lblDebugNoteCaption
            // 
            this._lblDebugNoteCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblDebugNoteCaption.Location = new System.Drawing.Point(3, 238);
            this._lblDebugNoteCaption.Name = "_lblDebugNoteCaption";
            this._lblDebugNoteCaption.Size = new System.Drawing.Size(124, 70);
            this._lblDebugNoteCaption.TabIndex = 14;
            this._lblDebugNoteCaption.Text = "Debug note";
            this._lblDebugNoteCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _txtDebugNote
            // 
            this._txtDebugNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtDebugNote.Location = new System.Drawing.Point(133, 241);
            this._txtDebugNote.Multiline = true;
            this._txtDebugNote.Name = "_txtDebugNote";
            this._txtDebugNote.Size = new System.Drawing.Size(279, 64);
            this._txtDebugNote.TabIndex = 15;
            // 
            // _btnCreate
            // 
            this._btnCreate.Location = new System.Drawing.Point(133, 311);
            this._btnCreate.Name = "_btnCreate";
            this._btnCreate.Size = new System.Drawing.Size(180, 28);
            this._btnCreate.TabIndex = 16;
            this._btnCreate.Text = "Tao link va gui email";
            this._btnCreate.UseVisualStyleBackColor = true;
            // 
            // _grpDetail
            // 
            this._grpDetail.Controls.Add(this._detailRoot);
            this._grpDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grpDetail.Location = new System.Drawing.Point(444, 3);
            this._grpDetail.Name = "_grpDetail";
            this._grpDetail.Padding = new System.Windows.Forms.Padding(10);
            this._grpDetail.Size = new System.Drawing.Size(603, 368);
            this._grpDetail.TabIndex = 1;
            this._grpDetail.TabStop = false;
            this._grpDetail.Text = "Ket qua thanh toan";
            // 
            // _detailRoot
            // 
            this._detailRoot.ColumnCount = 1;
            this._detailRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._detailRoot.Controls.Add(this._detailForm, 0, 0);
            this._detailRoot.Controls.Add(this._txtPaymentUrl, 0, 1);
            this._detailRoot.Controls.Add(this._detailButtons, 0, 2);
            this._detailRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this._detailRoot.Location = new System.Drawing.Point(10, 23);
            this._detailRoot.Name = "_detailRoot";
            this._detailRoot.RowCount = 3;
            this._detailRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._detailRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this._detailRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this._detailRoot.Size = new System.Drawing.Size(583, 335);
            this._detailRoot.TabIndex = 0;
            // 
            // _detailForm
            // 
            this._detailForm.ColumnCount = 4;
            this._detailForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this._detailForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._detailForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this._detailForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._detailForm.Controls.Add(this._lblTransactionIdCaption, 0, 0);
            this._detailForm.Controls.Add(this._lblTransactionId, 1, 0);
            this._detailForm.Controls.Add(this._lblExternalRefCaption, 2, 0);
            this._detailForm.Controls.Add(this._lblExternalRef, 3, 0);
            this._detailForm.Controls.Add(this._lblReceiverEmailCaption2, 0, 1);
            this._detailForm.Controls.Add(this._lblReceiverEmail, 1, 1);
            this._detailForm.Controls.Add(this._lblPaymentStatusCaption, 2, 1);
            this._detailForm.Controls.Add(this._lblPaymentStatus, 3, 1);
            this._detailForm.Controls.Add(this._lblTuitionStatusCaption, 0, 2);
            this._detailForm.Controls.Add(this._lblTuitionStatus, 1, 2);
            this._detailForm.Controls.Add(this._lblPaymentEmailCaption, 2, 2);
            this._detailForm.Controls.Add(this._lblPaymentEmail, 3, 2);
            this._detailForm.Controls.Add(this._lblPaymentEmailAtCaption, 0, 3);
            this._detailForm.Controls.Add(this._lblPaymentEmailAt, 1, 3);
            this._detailForm.Controls.Add(this._lblPaymentEmailErrorCaption, 2, 3);
            this._detailForm.Controls.Add(this._lblPaymentEmailError, 3, 3);
            this._detailForm.Controls.Add(this._lblStatusEmailCaption, 0, 4);
            this._detailForm.Controls.Add(this._lblStatusEmail, 1, 4);
            this._detailForm.Controls.Add(this._lblStatusEmailAtCaption, 2, 4);
            this._detailForm.Controls.Add(this._lblStatusEmailAt, 3, 4);
            this._detailForm.Controls.Add(this._lblStatusEmailErrorCaption, 0, 5);
            this._detailForm.Controls.Add(this._lblStatusEmailError, 1, 5);
            this._detailForm.Controls.Add(this._lblUpdatedAtCaption, 2, 5);
            this._detailForm.Controls.Add(this._lblUpdatedAt, 3, 5);
            this._detailForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this._detailForm.Location = new System.Drawing.Point(3, 3);
            this._detailForm.Name = "_detailForm";
            this._detailForm.RowCount = 6;
            this._detailForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this._detailForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this._detailForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this._detailForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this._detailForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this._detailForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this._detailForm.Size = new System.Drawing.Size(577, 211);
            this._detailForm.TabIndex = 0;
            // 
            // _lblTransactionIdCaption
            // 
            this._lblTransactionIdCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblTransactionIdCaption.Location = new System.Drawing.Point(3, 0);
            this._lblTransactionIdCaption.Name = "_lblTransactionIdCaption";
            this._lblTransactionIdCaption.Size = new System.Drawing.Size(124, 35);
            this._lblTransactionIdCaption.TabIndex = 0;
            this._lblTransactionIdCaption.Text = "Giao dich";
            // 
            // _lblTransactionId
            // 
            this._lblTransactionId.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblTransactionId.Location = new System.Drawing.Point(133, 0);
            this._lblTransactionId.Name = "_lblTransactionId";
            this._lblTransactionId.Size = new System.Drawing.Size(152, 35);
            this._lblTransactionId.TabIndex = 1;
            this._lblTransactionId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblExternalRefCaption
            // 
            this._lblExternalRefCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblExternalRefCaption.Location = new System.Drawing.Point(291, 0);
            this._lblExternalRefCaption.Name = "_lblExternalRefCaption";
            this._lblExternalRefCaption.Size = new System.Drawing.Size(124, 35);
            this._lblExternalRefCaption.TabIndex = 2;
            this._lblExternalRefCaption.Text = "Ma ngoai";
            // 
            // _lblExternalRef
            // 
            this._lblExternalRef.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblExternalRef.Location = new System.Drawing.Point(421, 0);
            this._lblExternalRef.Name = "_lblExternalRef";
            this._lblExternalRef.Size = new System.Drawing.Size(153, 35);
            this._lblExternalRef.TabIndex = 3;
            this._lblExternalRef.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblReceiverEmailCaption2
            // 
            this._lblReceiverEmailCaption2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblReceiverEmailCaption2.Location = new System.Drawing.Point(3, 35);
            this._lblReceiverEmailCaption2.Name = "_lblReceiverEmailCaption2";
            this._lblReceiverEmailCaption2.Size = new System.Drawing.Size(124, 35);
            this._lblReceiverEmailCaption2.TabIndex = 4;
            this._lblReceiverEmailCaption2.Text = "Email nhan";
            // 
            // _lblReceiverEmail
            // 
            this._lblReceiverEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblReceiverEmail.Location = new System.Drawing.Point(133, 35);
            this._lblReceiverEmail.Name = "_lblReceiverEmail";
            this._lblReceiverEmail.Size = new System.Drawing.Size(152, 35);
            this._lblReceiverEmail.TabIndex = 5;
            this._lblReceiverEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblPaymentStatusCaption
            // 
            this._lblPaymentStatusCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblPaymentStatusCaption.Location = new System.Drawing.Point(291, 35);
            this._lblPaymentStatusCaption.Name = "_lblPaymentStatusCaption";
            this._lblPaymentStatusCaption.Size = new System.Drawing.Size(124, 35);
            this._lblPaymentStatusCaption.TabIndex = 6;
            this._lblPaymentStatusCaption.Text = "GD status";
            // 
            // _lblPaymentStatus
            // 
            this._lblPaymentStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblPaymentStatus.Location = new System.Drawing.Point(421, 35);
            this._lblPaymentStatus.Name = "_lblPaymentStatus";
            this._lblPaymentStatus.Size = new System.Drawing.Size(153, 35);
            this._lblPaymentStatus.TabIndex = 7;
            this._lblPaymentStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblTuitionStatusCaption
            // 
            this._lblTuitionStatusCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblTuitionStatusCaption.Location = new System.Drawing.Point(3, 70);
            this._lblTuitionStatusCaption.Name = "_lblTuitionStatusCaption";
            this._lblTuitionStatusCaption.Size = new System.Drawing.Size(124, 35);
            this._lblTuitionStatusCaption.TabIndex = 8;
            this._lblTuitionStatusCaption.Text = "HP status";
            // 
            // _lblTuitionStatus
            // 
            this._lblTuitionStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblTuitionStatus.Location = new System.Drawing.Point(133, 70);
            this._lblTuitionStatus.Name = "_lblTuitionStatus";
            this._lblTuitionStatus.Size = new System.Drawing.Size(152, 35);
            this._lblTuitionStatus.TabIndex = 9;
            this._lblTuitionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblPaymentEmailCaption
            // 
            this._lblPaymentEmailCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblPaymentEmailCaption.Location = new System.Drawing.Point(291, 70);
            this._lblPaymentEmailCaption.Name = "_lblPaymentEmailCaption";
            this._lblPaymentEmailCaption.Size = new System.Drawing.Size(124, 35);
            this._lblPaymentEmailCaption.TabIndex = 10;
            this._lblPaymentEmailCaption.Text = "Payment email";
            // 
            // _lblPaymentEmail
            // 
            this._lblPaymentEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblPaymentEmail.Location = new System.Drawing.Point(421, 70);
            this._lblPaymentEmail.Name = "_lblPaymentEmail";
            this._lblPaymentEmail.Size = new System.Drawing.Size(153, 35);
            this._lblPaymentEmail.TabIndex = 11;
            this._lblPaymentEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblPaymentEmailAtCaption
            // 
            this._lblPaymentEmailAtCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblPaymentEmailAtCaption.Location = new System.Drawing.Point(3, 105);
            this._lblPaymentEmailAtCaption.Name = "_lblPaymentEmailAtCaption";
            this._lblPaymentEmailAtCaption.Size = new System.Drawing.Size(124, 35);
            this._lblPaymentEmailAtCaption.TabIndex = 12;
            this._lblPaymentEmailAtCaption.Text = "Gui luc";
            // 
            // _lblPaymentEmailAt
            // 
            this._lblPaymentEmailAt.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblPaymentEmailAt.Location = new System.Drawing.Point(133, 105);
            this._lblPaymentEmailAt.Name = "_lblPaymentEmailAt";
            this._lblPaymentEmailAt.Size = new System.Drawing.Size(152, 35);
            this._lblPaymentEmailAt.TabIndex = 13;
            this._lblPaymentEmailAt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblPaymentEmailErrorCaption
            // 
            this._lblPaymentEmailErrorCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblPaymentEmailErrorCaption.Location = new System.Drawing.Point(291, 105);
            this._lblPaymentEmailErrorCaption.Name = "_lblPaymentEmailErrorCaption";
            this._lblPaymentEmailErrorCaption.Size = new System.Drawing.Size(124, 35);
            this._lblPaymentEmailErrorCaption.TabIndex = 14;
            this._lblPaymentEmailErrorCaption.Text = "Loi gui";
            // 
            // _lblPaymentEmailError
            // 
            this._lblPaymentEmailError.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblPaymentEmailError.Location = new System.Drawing.Point(421, 105);
            this._lblPaymentEmailError.Name = "_lblPaymentEmailError";
            this._lblPaymentEmailError.Size = new System.Drawing.Size(153, 35);
            this._lblPaymentEmailError.TabIndex = 15;
            this._lblPaymentEmailError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblStatusEmailCaption
            // 
            this._lblStatusEmailCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblStatusEmailCaption.Location = new System.Drawing.Point(3, 140);
            this._lblStatusEmailCaption.Name = "_lblStatusEmailCaption";
            this._lblStatusEmailCaption.Size = new System.Drawing.Size(124, 35);
            this._lblStatusEmailCaption.TabIndex = 16;
            this._lblStatusEmailCaption.Text = "Status email";
            // 
            // _lblStatusEmail
            // 
            this._lblStatusEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblStatusEmail.Location = new System.Drawing.Point(133, 140);
            this._lblStatusEmail.Name = "_lblStatusEmail";
            this._lblStatusEmail.Size = new System.Drawing.Size(152, 35);
            this._lblStatusEmail.TabIndex = 17;
            this._lblStatusEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblStatusEmailAtCaption
            // 
            this._lblStatusEmailAtCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblStatusEmailAtCaption.Location = new System.Drawing.Point(291, 140);
            this._lblStatusEmailAtCaption.Name = "_lblStatusEmailAtCaption";
            this._lblStatusEmailAtCaption.Size = new System.Drawing.Size(124, 35);
            this._lblStatusEmailAtCaption.TabIndex = 18;
            this._lblStatusEmailAtCaption.Text = "Gui luc";
            // 
            // _lblStatusEmailAt
            // 
            this._lblStatusEmailAt.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblStatusEmailAt.Location = new System.Drawing.Point(421, 140);
            this._lblStatusEmailAt.Name = "_lblStatusEmailAt";
            this._lblStatusEmailAt.Size = new System.Drawing.Size(153, 35);
            this._lblStatusEmailAt.TabIndex = 19;
            this._lblStatusEmailAt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblStatusEmailErrorCaption
            // 
            this._lblStatusEmailErrorCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblStatusEmailErrorCaption.Location = new System.Drawing.Point(3, 175);
            this._lblStatusEmailErrorCaption.Name = "_lblStatusEmailErrorCaption";
            this._lblStatusEmailErrorCaption.Size = new System.Drawing.Size(124, 36);
            this._lblStatusEmailErrorCaption.TabIndex = 20;
            this._lblStatusEmailErrorCaption.Text = "Loi status";
            // 
            // _lblStatusEmailError
            // 
            this._lblStatusEmailError.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblStatusEmailError.Location = new System.Drawing.Point(133, 175);
            this._lblStatusEmailError.Name = "_lblStatusEmailError";
            this._lblStatusEmailError.Size = new System.Drawing.Size(152, 36);
            this._lblStatusEmailError.TabIndex = 21;
            this._lblStatusEmailError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblUpdatedAtCaption
            // 
            this._lblUpdatedAtCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblUpdatedAtCaption.Location = new System.Drawing.Point(291, 175);
            this._lblUpdatedAtCaption.Name = "_lblUpdatedAtCaption";
            this._lblUpdatedAtCaption.Size = new System.Drawing.Size(124, 36);
            this._lblUpdatedAtCaption.TabIndex = 22;
            this._lblUpdatedAtCaption.Text = "Cap nhat";
            // 
            // _lblUpdatedAt
            // 
            this._lblUpdatedAt.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblUpdatedAt.Location = new System.Drawing.Point(421, 175);
            this._lblUpdatedAt.Name = "_lblUpdatedAt";
            this._lblUpdatedAt.Size = new System.Drawing.Size(153, 36);
            this._lblUpdatedAt.TabIndex = 23;
            this._lblUpdatedAt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _txtPaymentUrl
            // 
            this._txtPaymentUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtPaymentUrl.Location = new System.Drawing.Point(3, 220);
            this._txtPaymentUrl.Multiline = true;
            this._txtPaymentUrl.Name = "_txtPaymentUrl";
            this._txtPaymentUrl.ReadOnly = true;
            this._txtPaymentUrl.Size = new System.Drawing.Size(577, 68);
            this._txtPaymentUrl.TabIndex = 1;
            // 
            // _detailButtons
            // 
            this._detailButtons.Controls.Add(this._btnCopyUrl);
            this._detailButtons.Controls.Add(this._btnOpenUrl);
            this._detailButtons.Controls.Add(this._btnResend);
            this._detailButtons.Controls.Add(this._btnFakeComplete);
            this._detailButtons.Controls.Add(this._btnFakeExpired);
            this._detailButtons.Controls.Add(this._btnFakeFailed);
            this._detailButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this._detailButtons.Location = new System.Drawing.Point(3, 294);
            this._detailButtons.Name = "_detailButtons";
            this._detailButtons.Size = new System.Drawing.Size(577, 38);
            this._detailButtons.TabIndex = 2;
            // 
            // _btnCopyUrl
            // 
            this._btnCopyUrl.Location = new System.Drawing.Point(3, 3);
            this._btnCopyUrl.Name = "_btnCopyUrl";
            this._btnCopyUrl.Size = new System.Drawing.Size(86, 30);
            this._btnCopyUrl.TabIndex = 0;
            this._btnCopyUrl.Text = "Copy URL";
            // 
            // _btnOpenUrl
            // 
            this._btnOpenUrl.Location = new System.Drawing.Point(95, 3);
            this._btnOpenUrl.Name = "_btnOpenUrl";
            this._btnOpenUrl.Size = new System.Drawing.Size(86, 30);
            this._btnOpenUrl.TabIndex = 1;
            this._btnOpenUrl.Text = "Open URL";
            // 
            // _btnResend
            // 
            this._btnResend.Location = new System.Drawing.Point(187, 3);
            this._btnResend.Name = "_btnResend";
            this._btnResend.Size = new System.Drawing.Size(110, 30);
            this._btnResend.TabIndex = 2;
            this._btnResend.Text = "Gui lai email";
            // 
            // _btnFakeComplete
            // 
            this._btnFakeComplete.Location = new System.Drawing.Point(303, 3);
            this._btnFakeComplete.Name = "_btnFakeComplete";
            this._btnFakeComplete.Size = new System.Drawing.Size(120, 30);
            this._btnFakeComplete.TabIndex = 3;
            this._btnFakeComplete.Text = "Fake Completed";
            // 
            // _btnFakeExpired
            // 
            this._btnFakeExpired.Location = new System.Drawing.Point(429, 3);
            this._btnFakeExpired.Name = "_btnFakeExpired";
            this._btnFakeExpired.Size = new System.Drawing.Size(110, 30);
            this._btnFakeExpired.TabIndex = 4;
            this._btnFakeExpired.Text = "Fake Expired";
            // 
            // _btnFakeFailed
            // 
            this._btnFakeFailed.Location = new System.Drawing.Point(3, 39);
            this._btnFakeFailed.Name = "_btnFakeFailed";
            this._btnFakeFailed.Size = new System.Drawing.Size(100, 30);
            this._btnFakeFailed.TabIndex = 5;
            this._btnFakeFailed.Text = "Fake Failed";
            // 
            // _grpGrid
            // 
            this._grpGrid.Controls.Add(this._gridRoot);
            this._grpGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grpGrid.Location = new System.Drawing.Point(15, 395);
            this._grpGrid.Name = "_grpGrid";
            this._grpGrid.Padding = new System.Windows.Forms.Padding(10);
            this._grpGrid.Size = new System.Drawing.Size(1050, 310);
            this._grpGrid.TabIndex = 1;
            this._grpGrid.TabStop = false;
            this._grpGrid.Text = "Giao dich debug gan day";
            // 
            // _gridRoot
            // 
            this._gridRoot.ColumnCount = 1;
            this._gridRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._gridRoot.Controls.Add(this._gridToolbar, 0, 0);
            this._gridRoot.Controls.Add(this._grid, 0, 1);
            this._gridRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gridRoot.Location = new System.Drawing.Point(10, 23);
            this._gridRoot.Name = "_gridRoot";
            this._gridRoot.RowCount = 2;
            this._gridRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this._gridRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._gridRoot.Size = new System.Drawing.Size(1030, 277);
            this._gridRoot.TabIndex = 0;
            // 
            // _gridToolbar
            // 
            this._gridToolbar.Controls.Add(this._btnRefresh);
            this._gridToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gridToolbar.Location = new System.Drawing.Point(3, 3);
            this._gridToolbar.Name = "_gridToolbar";
            this._gridToolbar.Size = new System.Drawing.Size(1024, 36);
            this._gridToolbar.TabIndex = 0;
            // 
            // _btnRefresh
            // 
            this._btnRefresh.Location = new System.Drawing.Point(3, 3);
            this._btnRefresh.Name = "_btnRefresh";
            this._btnRefresh.Size = new System.Drawing.Size(96, 30);
            this._btnRefresh.TabIndex = 0;
            this._btnRefresh.Text = "Refresh";
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._grid.ColumnHeadersHeight = 34;
            this._grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grid.Location = new System.Drawing.Point(3, 45);
            this._grid.MultiSelect = false;
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._grid.Size = new System.Drawing.Size(1024, 229);
            this._grid.TabIndex = 1;
            // 
            // FrmPaymentDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 720);
            this.Controls.Add(this._root);
            this.MinimumSize = new System.Drawing.Size(1080, 720);
            this.Name = "FrmPaymentDebug";
            this.Text = "Debug thanh toan";
            this._root.ResumeLayout(false);
            this._top.ResumeLayout(false);
            this._grpInput.ResumeLayout(false);
            this._inputForm.ResumeLayout(false);
            this._inputForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numAmount)).EndInit();
            this._grpDetail.ResumeLayout(false);
            this._detailRoot.ResumeLayout(false);
            this._detailRoot.PerformLayout();
            this._detailForm.ResumeLayout(false);
            this._detailButtons.ResumeLayout(false);
            this._grpGrid.ResumeLayout(false);
            this._gridRoot.ResumeLayout(false);
            this._gridToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
