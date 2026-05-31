using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public class FrmPaymentDebug : ModuleFormBase
    {
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
        private PaymentDebugResultDTO _currentDetail;

        public FrmPaymentDebug(ServiceFactory services, NguoiDungDTO currentUser)
            : base(services, currentUser, "Debug thanh toan")
        {
            InitializeDebugUi();
            WireEvents();
        }

        protected override void OnRuntimeLoad()
        {
            _cboPaymentMethod.Items.Clear();
            _cboPaymentMethod.Items.Add(AppConstants.PaymentMethodVNPay);
            _cboPaymentMethod.SelectedIndex = 0;
            SetTransactionActions(false);
            RefreshGrid();
        }

        private void InitializeDebugUi()
        {
            Text = "Debug thanh toan";
            MinimumSize = new Size(1080, 720);

            var root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                Padding = new Padding(12)
            };
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 380F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            var top = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1
            };
            top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
            top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));

            top.Controls.Add(CreateInputPanel(), 0, 0);
            top.Controls.Add(CreateDetailPanel(), 1, 0);
            root.Controls.Add(top, 0, 0);
            root.Controls.Add(CreateGridPanel(), 0, 1);
            Controls.Add(root);
        }

        private Control CreateInputPanel()
        {
            var group = new GroupBox { Text = "Tao thanh toan debug", Dock = DockStyle.Fill, Padding = new Padding(10) };
            var form = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 9 };
            form.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            form.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            _txtStudentName = UiHelpers.TextBox();
            _txtReceiverEmail = UiHelpers.TextBox();
            _txtClassName = UiHelpers.TextBox();
            _numAmount = new NumericUpDown
            {
                Dock = DockStyle.Fill,
                Maximum = 1000000000m,
                Minimum = 0m,
                DecimalPlaces = 0,
                ThousandsSeparator = true,
                Value = 1000000m
            };
            _txtInvoiceCode = UiHelpers.TextBox();
            _cboPaymentMethod = UiHelpers.ComboBox();
            _txtPaymentContent = UiHelpers.TextBox();
            _txtDebugNote = UiHelpers.TextBox();
            _txtDebugNote.Multiline = true;
            _txtDebugNote.Height = 56;

            AddRow(form, 0, "Hoc sinh", _txtStudentName);
            AddRow(form, 1, "Email nhan", _txtReceiverEmail);
            AddRow(form, 2, "Lop / ghi chu", _txtClassName);
            AddRow(form, 3, "So tien", _numAmount);
            AddRow(form, 4, "Ma hoa don", _txtInvoiceCode);
            AddRow(form, 5, "Phuong thuc", _cboPaymentMethod);
            AddRow(form, 6, "Noi dung", _txtPaymentContent);
            AddRow(form, 7, "Debug note", _txtDebugNote);

            _btnCreate = UiHelpers.Button("Tao link va gui email");
            _btnCreate.Width = 180;
            form.Controls.Add(_btnCreate, 1, 8);
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            form.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));

            group.Controls.Add(form);
            return group;
        }

        private Control CreateDetailPanel()
        {
            var group = new GroupBox { Text = "Ket qua thanh toan", Dock = DockStyle.Fill, Padding = new Padding(10) };
            var root = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 3 };
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 74F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));

            var detail = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 4, RowCount = 6 };
            detail.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            detail.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            detail.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            detail.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            _lblTransactionId = ValueLabel();
            _lblExternalRef = ValueLabel();
            _lblReceiverEmail = ValueLabel();
            _lblPaymentStatus = ValueLabel();
            _lblTuitionStatus = ValueLabel();
            _lblPaymentEmail = ValueLabel();
            _lblPaymentEmailAt = ValueLabel();
            _lblPaymentEmailError = ValueLabel();
            _lblStatusEmail = ValueLabel();
            _lblStatusEmailAt = ValueLabel();
            _lblStatusEmailError = ValueLabel();
            _lblUpdatedAt = ValueLabel();

            AddDetailRow(detail, 0, "Giao dich", _lblTransactionId, "Ma ngoai", _lblExternalRef);
            AddDetailRow(detail, 1, "Email nhan", _lblReceiverEmail, "GD status", _lblPaymentStatus);
            AddDetailRow(detail, 2, "HP status", _lblTuitionStatus, "Payment email", _lblPaymentEmail);
            AddDetailRow(detail, 3, "Gui luc", _lblPaymentEmailAt, "Loi gui", _lblPaymentEmailError);
            AddDetailRow(detail, 4, "Status email", _lblStatusEmail, "Gui luc", _lblStatusEmailAt);
            AddDetailRow(detail, 5, "Loi status", _lblStatusEmailError, "Cap nhat", _lblUpdatedAt);

            _txtPaymentUrl = UiHelpers.TextBox();
            _txtPaymentUrl.Multiline = true;
            _txtPaymentUrl.ReadOnly = true;
            _txtPaymentUrl.Dock = DockStyle.Fill;
            root.Controls.Add(detail, 0, 0);
            root.Controls.Add(_txtPaymentUrl, 0, 1);
            root.Controls.Add(CreateDetailButtons(), 0, 2);

            group.Controls.Add(root);
            return group;
        }

        private Control CreateDetailButtons()
        {
            var buttons = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.LeftToRight };
            _btnCopyUrl = UiHelpers.Button("Copy URL");
            _btnOpenUrl = UiHelpers.Button("Open URL");
            _btnResend = UiHelpers.Button("Gui lai email");
            _btnFakeComplete = UiHelpers.Button("Fake Completed");
            _btnFakeExpired = UiHelpers.Button("Fake Expired");
            _btnFakeFailed = UiHelpers.Button("Fake Failed");
            buttons.Controls.Add(_btnCopyUrl);
            buttons.Controls.Add(_btnOpenUrl);
            buttons.Controls.Add(_btnResend);
            buttons.Controls.Add(_btnFakeComplete);
            buttons.Controls.Add(_btnFakeExpired);
            buttons.Controls.Add(_btnFakeFailed);
            return buttons;
        }

        private Control CreateGridPanel()
        {
            var group = new GroupBox { Text = "Giao dich debug gan day", Dock = DockStyle.Fill, Padding = new Padding(10) };
            var root = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 2 };
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            _btnRefresh = UiHelpers.Button("Refresh");
            var toolbar = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.LeftToRight };
            toolbar.Controls.Add(_btnRefresh);

            _grid = UiHelpers.Grid();
            _grid.AutoGenerateColumns = false;
            _grid.Columns.Add(GridColumn("TransactionId", "GD", 60));
            _grid.Columns.Add(GridColumn("StudentName", "Hoc sinh", 140));
            _grid.Columns.Add(GridColumn("ReceiverEmail", "Email", 170));
            _grid.Columns.Add(GridColumn("Amount", "So tien", 90));
            _grid.Columns.Add(GridColumn("PaymentMethod", "PT", 70));
            _grid.Columns.Add(GridColumn("PaymentStatus", "Trang thai", 100));
            _grid.Columns.Add(GridColumn("PaymentUrlExists", "Co URL", 70));
            _grid.Columns.Add(GridColumn("PaymentEmailSent", "Email TT", 80));
            _grid.Columns.Add(GridColumn("PaymentEmailSentAt", "Email TT luc", 130));
            _grid.Columns.Add(GridColumn("StatusEmailSent", "Email KQ", 80));
            _grid.Columns.Add(GridColumn("StatusEmailSentAt", "Email KQ luc", 130));
            _grid.Columns.Add(GridColumn("UpdatedAt", "Cap nhat", 130));

            root.Controls.Add(toolbar, 0, 0);
            root.Controls.Add(_grid, 0, 1);
            group.Controls.Add(root);
            return group;
        }

        private void WireEvents()
        {
            WireClick(_btnCreate, BtnCreate_Click);
            WireClick(_btnCopyUrl, BtnCopyUrl_Click);
            WireClick(_btnOpenUrl, BtnOpenUrl_Click);
            WireClick(_btnResend, BtnResend_Click);
            WireClick(_btnFakeComplete, (s, e) => SimulateStatus("Complete"));
            WireClick(_btnFakeExpired, (s, e) => SimulateStatus("Expired"));
            WireClick(_btnFakeFailed, (s, e) => SimulateStatus("Failed"));
            WireClick(_btnRefresh, (s, e) => RefreshGrid());
            WireSelectionChanged(_grid, Grid_SelectionChanged);
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            var result = Services.Payment.CreateDebugPayment(new PaymentDebugRequestDTO
            {
                StudentName = _txtStudentName.Text,
                ReceiverEmail = _txtReceiverEmail.Text,
                ClassName = _txtClassName.Text,
                Amount = _numAmount.Value,
                InvoiceCode = _txtInvoiceCode.Text,
                PaymentMethod = Convert.ToString(_cboPaymentMethod.SelectedItem),
                PaymentContent = _txtPaymentContent.Text,
                DebugNote = _txtDebugNote.Text,
                IsDebugPayment = true
            });

            ShowResultAndDetail(result);
            RefreshGrid();
        }

        private void BtnCopyUrl_Click(object sender, EventArgs e)
        {
            if (_currentDetail == null || string.IsNullOrWhiteSpace(_currentDetail.PaymentUrl))
            {
                Info("Chua co payment URL.");
                return;
            }

            Clipboard.SetText(_currentDetail.PaymentUrl);
            Info("Da copy payment URL.");
        }

        private void BtnOpenUrl_Click(object sender, EventArgs e)
        {
            if (_currentDetail == null || string.IsNullOrWhiteSpace(_currentDetail.PaymentUrl))
            {
                Info("Chua co payment URL.");
                return;
            }

            Process.Start(_currentDetail.PaymentUrl);
        }

        private void BtnResend_Click(object sender, EventArgs e)
        {
            if (!HasTransaction()) return;

            var result = Services.Payment.ResendPaymentEmail(_currentDetail.TransactionId);
            ShowResultAndDetail(result);
            RefreshGrid();
        }

        private void SimulateStatus(string status)
        {
            if (!HasTransaction()) return;

            var result = Services.Payment.SimulatePaymentStatus(_currentDetail.TransactionId, status, _currentDetail.ReceiverEmail);
            ShowResultAndDetail(result);
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            var result = Services.Payment.GetRecentDebugPayments();
            if (!result.Success)
            {
                UiHelpers.ShowResult(result);
                return;
            }

            _grid.DataSource = result.Data;
        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            var row = _grid.CurrentRow == null ? null : _grid.CurrentRow.DataBoundItem as PaymentDebugResultDTO;
            if (row == null)
            {
                return;
            }

            var result = Services.Payment.GetPaymentDebugDetail(row.TransactionId);
            if (result.Success && result.Data != null)
            {
                LoadDetail(result.Data);
            }
        }

        private void ShowResultAndDetail(ServiceResult<PaymentDebugResultDTO> result)
        {
            UiHelpers.ShowResult(result);
            if (result.Data != null)
            {
                LoadDetail(result.Data);
            }
        }

        private void LoadDetail(PaymentDebugResultDTO detail)
        {
            _currentDetail = detail;
            _lblTransactionId.Text = detail.TransactionId.ToString();
            _lblExternalRef.Text = SafeText(detail.ExternalTransactionRef);
            _lblReceiverEmail.Text = SafeText(detail.ReceiverEmail);
            _lblPaymentStatus.Text = SafeText(detail.PaymentStatus);
            _lblTuitionStatus.Text = SafeText(detail.TuitionStatus);
            _lblPaymentEmail.Text = FormatEmailStatus(detail.PaymentEmailSent, detail.PaymentEmailError);
            _lblPaymentEmailAt.Text = FormatDate(detail.PaymentEmailSentAt);
            _lblPaymentEmailError.Text = SafeText(detail.PaymentEmailError);
            _lblStatusEmail.Text = FormatEmailStatus(detail.StatusEmailSent, detail.StatusEmailError);
            _lblStatusEmailAt.Text = FormatDate(detail.StatusEmailSentAt);
            _lblStatusEmailError.Text = SafeText(detail.StatusEmailError);
            _lblUpdatedAt.Text = FormatDate(detail.UpdatedAt);
            _txtPaymentUrl.Text = SafeText(detail.PaymentUrl);
            SetTransactionActions(detail.TransactionId > 0);
        }

        private bool HasTransaction()
        {
            if (_currentDetail != null && _currentDetail.TransactionId > 0)
            {
                return true;
            }

            Info("Vui long tao hoac chon giao dich truoc.");
            return false;
        }

        private void SetTransactionActions(bool enabled)
        {
            _btnCopyUrl.Enabled = enabled;
            _btnOpenUrl.Enabled = enabled;
            _btnResend.Enabled = enabled;
            _btnFakeComplete.Enabled = enabled;
            _btnFakeExpired.Enabled = enabled;
            _btnFakeFailed.Enabled = enabled;
        }

        private static void AddRow(TableLayoutPanel table, int row, string label, Control control)
        {
            table.Controls.Add(UiHelpers.Label(label), 0, row);
            control.Dock = DockStyle.Fill;
            table.Controls.Add(control, 1, row);
        }

        private static void AddDetailRow(TableLayoutPanel table, int row, string label1, Label value1, string label2, Label value2)
        {
            table.Controls.Add(UiHelpers.Label(label1), 0, row);
            table.Controls.Add(value1, 1, row);
            table.Controls.Add(UiHelpers.Label(label2), 2, row);
            table.Controls.Add(value2, 3, row);
        }

        private static Label ValueLabel()
        {
            return new Label
            {
                AutoEllipsis = true,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };
        }

        private static DataGridViewColumn GridColumn(string property, string header, int width)
        {
            return new DataGridViewTextBoxColumn
            {
                DataPropertyName = property,
                HeaderText = header,
                Width = width,
                MinimumWidth = Math.Min(width, 80)
            };
        }

        private static string FormatEmailStatus(bool sent, string error)
        {
            if (sent)
            {
                return "Sent";
            }

            return string.IsNullOrWhiteSpace(error) ? "No" : "Failed";
        }

        private static string FormatDate(DateTime? value)
        {
            return value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
        }

        private static string SafeText(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? string.Empty : value.Trim();
        }
    }
}
