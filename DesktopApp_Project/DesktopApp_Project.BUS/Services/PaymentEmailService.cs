// Dịch vụ xử lý nghiệp vụ Thư điện tử thanh toán
// Chức năng:
// - Nhận dữ liệu từ giao diện dưới dạng đối tượng truyền dữ liệu hoặc tham số lọc
// - Kiểm tra nghiệp vụ trước khi gọi tầng dữ liệu
// - Trả kết quả xử lý hoặc danh sách đối tượng truyền dữ liệu cho giao diện

using System;
using System.Configuration;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace DesktopApp_Project.BUS
{
    // Lớp hỗ trợ lưu trạng thái lỗi gửi Thư điện tử trong quá trình xử lý nghiệp vụ.
    public class EmailSendException : Exception
    {
        // Khởi tạo ngoại lệ để giữ thông tin lỗi khi gửi Thư điện tử thanh toán thất bại.
        public EmailSendException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    // Lớp xử lý nghiệp vụ Thư điện tử thanh toán, kiểm tra dữ liệu trước khi gọi kho dữ liệu/tầng dữ liệu.
    public class PaymentEmailService
    {
        // Gửi thư yêu cầu thanh toán.
        public void SendPaymentRequest(
            string toEmail,
            string studentName,
            string invoiceCode,
            decimal amount,
            string paymentUrl,
            byte[] qrImageBytes)
        {
            try
            {
                var options = LoadSmtpOptions();
                var message = CreateMessage(options, toEmail, "[DEMO] VNPAY Sandbox tuition payment");
                var builder = new BodyBuilder
                {
                    TextBody =
                        "[DEMO - VNPAY Sandbox payment]" + Environment.NewLine + Environment.NewLine +
                        "Hoc sinh: " + SafeText(studentName) + Environment.NewLine +
                        "Email nhan: " + SafeText(toEmail) + Environment.NewLine +
                        "Ma hoa don/giao dich: " + SafeText(invoiceCode) + Environment.NewLine +
                        "So tien: " + amount.ToString("N0") + " VND" + Environment.NewLine + Environment.NewLine +
                        "Link thanh toan VNPAY Sandbox:" + Environment.NewLine +
                        paymentUrl + Environment.NewLine + Environment.NewLine +
                        "Anh QR thanh toan co dinh duoc dinh kem trong email nay." + Environment.NewLine + Environment.NewLine +
                        "Day la email thanh toan VNPAY Sandbox/demo cho do an ung dung desktop. Khong phai yeu cau thanh toan san xuat."
                };

                if (qrImageBytes != null && qrImageBytes.Length > 0)
                {
                    builder.Attachments.Add("myQR.png", qrImageBytes, new ContentType("image", "png"));
                }

                message.Body = builder.ToMessageBody();
                Send(options, message);
            }
            catch (Exception ex)
            {
                throw new EmailSendException("Khong the gui email yeu cau thanh toan: " + ex.Message, ex);
            }
        }

        // Gửi thư thông báo trạng thái thanh toán.
        public void SendStatusNotification(string toEmail, string invoiceCode, decimal amount, string status)
        {
            SendStatusNotification(toEmail, string.Empty, invoiceCode, amount, status);
        }

        // Gửi thư thông báo trạng thái thanh toán.
        public void SendStatusNotification(string toEmail, string studentName, string invoiceCode, decimal amount, string status)
        {
            try
            {
                var options = LoadSmtpOptions();
                var message = CreateMessage(options, toEmail, "[DEMO] VNPAY Sandbox payment status");
                message.Body = new TextPart("plain")
                {
                    Text =
                        "[DEMO - VNPAY Sandbox payment status]" + Environment.NewLine + Environment.NewLine +
                        "Hoc sinh: " + SafeText(studentName) + Environment.NewLine +
                        "Ma hoa don/giao dich: " + SafeText(invoiceCode) + Environment.NewLine +
                        "So tien: " + amount.ToString("N0") + " VND" + Environment.NewLine +
                        "Trang thai gia lap: " + SafeText(status) + Environment.NewLine + Environment.NewLine +
                        "Day la ket qua gia lap cho do an ung dung desktop, khong phai giao dich san xuat."
                };

                Send(options, message);
            }
            catch (Exception ex)
            {
                throw new EmailSendException("Khong the gui email thong bao trang thai thanh toan: " + ex.Message, ex);
            }
        }

        // Tạo message.
        private static MimeMessage CreateMessage(SmtpOptions options, string toEmail, string subject)
        {
            if (string.IsNullOrWhiteSpace(toEmail))
            {
                throw new InvalidOperationException("Email nguoi nhan khong duoc de trong.");
            }

            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(options.SenderAddress));
            message.To.Add(MailboxAddress.Parse(toEmail.Trim()));
            message.Subject = subject;
            return message;
        }

        // Gửi thư thanh toán.
        private static void Send(SmtpOptions options, MimeMessage message)
        {
            using (var client = new SmtpClient())
            {
                client.Connect(options.Host, options.Port, SecureSocketOptions.StartTls);
                client.Authenticate(options.SenderAccount, options.AppPassword);
                client.Send(message);
                client.Disconnect(true);
            }
        }

        // Lấy smtp options.
        private static SmtpOptions LoadSmtpOptions()
        {
            var host = RequireSmtpConfig("smtp:Host");
            var senderAccount = RequireSmtpConfig("smtp:SenderAccount");
            var appPassword = RequireSmtpConfig("smtp:AppPassword");
            var senderAddress = RequireSmtpConfig("smtp:SenderAddress");
            var portText = RequireSmtpConfig("smtp:Port");
            int port;
            if (!int.TryParse(portText, out port) || port <= 0)
            {
                throw new InvalidOperationException("SMTP configuration is missing. Please update App.config.");
            }

            return new SmtpOptions
            {
                Host = host,
                Port = port,
                SenderAccount = senderAccount,
                AppPassword = appPassword,
                SenderAddress = senderAddress
            };
        }

        // Xử lý require smtp config.
        private static string RequireSmtpConfig(string key)
        {
            var value = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidOperationException("SMTP configuration is missing. Please update App.config.");
            }

            return value.Trim();
        }

        // Xử lý safe text.
        private static string SafeText(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? string.Empty : value.Trim();
        }

        // Lớp hỗ trợ lưu cấu hình máy chủ gửi thư trong quá trình xử lý nghiệp vụ.
        private class SmtpOptions
        {
            public string Host { get; set; }
            public int Port { get; set; }
            public string SenderAccount { get; set; }
            public string AppPassword { get; set; }
            public string SenderAddress { get; set; }
        }
    }
}
