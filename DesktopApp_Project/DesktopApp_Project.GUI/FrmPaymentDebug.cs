using System;
using System.Diagnostics;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public partial class FrmPaymentDebug : ModuleFormBase
    {
        private PaymentDebugResultDTO _currentDetail;

        public FrmPaymentDebug()
        {
            InitializeComponent();
            WireEvents();
        }

        public FrmPaymentDebug(ServiceFactory services, NguoiDungDTO currentUser)
            : this()
        {
            SetRuntimeContext(services, currentUser);
        }

        protected override void OnRuntimeLoad()
        {
            _cboPaymentMethod.Items.Clear();
            _cboPaymentMethod.Items.Add(AppConstants.PaymentMethodVNPay);
            _cboPaymentMethod.SelectedIndex = 0;
            SetTransactionActions(false);
            RefreshGrid();
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
