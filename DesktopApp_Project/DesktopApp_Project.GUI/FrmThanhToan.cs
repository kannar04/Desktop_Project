using System;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public partial class FrmThanhToan : ModuleFormBase
    {
        private readonly int _maThanhToan;
        private HoaDonHocPhiDTO _invoice;
        private int _maGiaoDich;

        public bool HasPaymentChanged { get; private set; }

        public FrmThanhToan()
        {
            InitializeComponent();
            WireEvents();
        }

        public FrmThanhToan(ServiceFactory services, NguoiDungDTO currentUser, int maThanhToan)
            : this()
        {
            _maThanhToan = maThanhToan;
            SetRuntimeContext(services, currentUser);
        }

        private void WireEvents()
        {
            WireClick(btnTaoThanhToan, BtnTaoThanhToan_Click);
            WireClick(btnFakeComplete, BtnFakeComplete_Click);
            WireClick(btnFakeExpired, BtnFakeExpired_Click);
            WireClick(btnFakeFailed, BtnFakeFailed_Click);
            WireClick(btnDong, (s, e) => Close());
        }

        protected override void OnRuntimeLoad()
        {
            cboPhuongThuc.DataSource = AppConstants.PaymentMethods;
            SetFakeButtonsEnabled(false);
            LoadInvoice();
        }

        private void LoadInvoice()
        {
            var result = Services.BaoCao.TaoHoaDonHocPhi(_maThanhToan);
            if (!result.Success)
            {
                UiHelpers.ShowResult(result);
                return;
            }

            _invoice = result.Data;
            lblHocVienValue.Text = _invoice.HoTen;
            lblLopValue.Text = _invoice.TenLop;
            lblSoTienValue.Text = (_invoice.SoTienCuoi.HasValue ? _invoice.SoTienCuoi.Value : _invoice.SoTien).ToString("#,##0") + " VND";
            lblTrangThaiValue.Text = _invoice.TrangThai;
            lblHanValue.Text = _invoice.HanThanhToan.ToString("dd/MM/yyyy");
        }

        private void BtnTaoThanhToan_Click(object sender, EventArgs e)
        {
            if (_invoice == null) return;

            var amount = _invoice.SoTienCuoi.HasValue ? _invoice.SoTienCuoi.Value : _invoice.SoTien;
            var result = Services.Payment.TaoThanhToan(new PaymentRequestDTO
            {
                MaThanhToan = _invoice.MaThanhToan,
                SoTien = amount,
                PhuongThuc = Convert.ToString(cboPhuongThuc.SelectedItem),
                NoiDungThanhToan = "Thanh toan hoc phi " + _invoice.MaHoaDon,
                EmailNguoiNhan = txtReceiverEmail.Text.Trim()
            });

            UiHelpers.ShowResult(result);
            if (!result.Success && result.Data == null)
            {
                return;
            }

            _maGiaoDich = result.Data.MaGiaoDich;
            txtPaymentUrl.Text = result.Data.PaymentUrl;
            txtQrContent.Text = result.Data.QrContent;
            SetFakeButtonsEnabled(true);
            HasPaymentChanged = true;
            LoadInvoice();
        }

        private void BtnFakeComplete_Click(object sender, EventArgs e)
        {
            SimulatePaymentStatus("Complete");
        }

        private void BtnFakeExpired_Click(object sender, EventArgs e)
        {
            SimulatePaymentStatus("Expired");
        }

        private void BtnFakeFailed_Click(object sender, EventArgs e)
        {
            SimulatePaymentStatus("Failed");
        }

        private void SimulatePaymentStatus(string fakeStatus)
        {
            if (_maGiaoDich <= 0)
            {
                Info("Vui long tao thanh toan truoc.");
                return;
            }

            var result = Services.Payment.SimulatePaymentStatus(_maGiaoDich, fakeStatus, txtReceiverEmail.Text.Trim());
            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                HasPaymentChanged = true;
                LoadInvoice();
            }
        }

        private void SetFakeButtonsEnabled(bool enabled)
        {
            btnFakeComplete.Enabled = enabled;
            btnFakeExpired.Enabled = enabled;
            btnFakeFailed.Enabled = enabled;
        }
    }
}
