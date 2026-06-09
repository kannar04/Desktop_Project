// Biểu mẫu quản lý thanh toán học phí
// Chức năng:
// - Hiển thị và nhập dữ liệu thanh toán học phí
// - Gọi tầng nghiệp vụ để tải, lưu hoặc xóa dữ liệu
// - Cập nhật trạng thái giao diện sau thao tác của người dùng

using System;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    // Lớp biểu mẫu Windows Forms chịu trách nhiệm hiển thị thanh toán học phí và gọi tầng nghiệp vụ khi người dùng thao tác.
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

        // Đăng ký các hàm xử lý sự kiện cho điều khiển trên biểu mẫu.
        private void WireEvents()
        {
            WireClick(btnTaoThanhToan, BtnTaoThanhToan_Click);
            WireClick(btnFakeComplete, BtnFakeComplete_Click);
            WireClick(btnFakeExpired, BtnFakeExpired_Click);
            WireClick(btnFakeFailed, BtnFakeFailed_Click);
            WireClick(btnDong, (s, e) => Close());
        }

        // Nạp dữ liệu và thiết lập trạng thái ban đầu khi biểu mẫu được mở.
        protected override void OnRuntimeLoad()
        {
            // Xóa dữ liệu đang hiển thị trên ô chọn phương thức khi chưa đủ điều kiện tải.
            cboPhuongThuc.DataSource = AppConstants.PaymentMethods;
            SetFakeButtonsEnabled(false);
            LoadInvoice();
        }

        // Lấy hóa đơn.
        private void LoadInvoice()
        {
            // Gọi tầng nghiệp vụ để tạo hóa đơn học phí.
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

        // Xử lý sự kiện người dùng nhấn nút Tạo thanh toán.
        private void BtnTaoThanhToan_Click(object sender, EventArgs e)
        {
            if (_invoice == null) return;

            var amount = _invoice.SoTienCuoi.HasValue ? _invoice.SoTienCuoi.Value : _invoice.SoTien;
            // Gọi tầng nghiệp vụ để tạo giao dịch thanh toán.
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

        // Xử lý sự kiện người dùng nhấn nút Giả lập thành công.
        private void BtnFakeComplete_Click(object sender, EventArgs e)
        {
            SimulatePaymentStatus("Complete");
        }

        // Xử lý sự kiện người dùng nhấn nút Giả lập hết hạn.
        private void BtnFakeExpired_Click(object sender, EventArgs e)
        {
            SimulatePaymentStatus("Expired");
        }

        // Xử lý sự kiện người dùng nhấn nút Giả lập thất bại.
        private void BtnFakeFailed_Click(object sender, EventArgs e)
        {
            SimulatePaymentStatus("Failed");
        }

        // Xử lý mô phỏng trạng thái thanh toán.
        private void SimulatePaymentStatus(string fakeStatus)
        {
            if (_maGiaoDich <= 0)
            {
                Info("Vui long tao thanh toan truoc.");
                return;
            }

            // Gọi tầng nghiệp vụ để mô phỏng trạng thái thanh toán.
            var result = Services.Payment.SimulatePaymentStatus(_maGiaoDich, fakeStatus, txtReceiverEmail.Text.Trim());
            UiHelpers.ShowResult(result);
            if (result.Success)
            {
                HasPaymentChanged = true;
                LoadInvoice();
            }
        }

        // Xử lý trạng thái nút mô phỏng thanh toán.
        private void SetFakeButtonsEnabled(bool enabled)
        {
            btnFakeComplete.Enabled = enabled;
            btnFakeExpired.Enabled = enabled;
            btnFakeFailed.Enabled = enabled;
        }
    }
}
