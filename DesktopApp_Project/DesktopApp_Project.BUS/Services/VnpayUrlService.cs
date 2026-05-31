using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace DesktopApp_Project.BUS
{
    public class VnpayUrlService
    {
        public string BuildPaymentUrl(string txnRef, decimal amount, string orderInfo, string ipAddr)
        {
            if (string.IsNullOrWhiteSpace(txnRef))
            {
                throw new ArgumentException("Ma giao dich VNPAY khong hop le.", "txnRef");
            }

            if (amount <= 0)
            {
                throw new ArgumentException("So tien thanh toan phai lon hon 0.", "amount");
            }

            var payUrl = RequireVnpayConfig("vnpay:PayUrl");
            var tmnCode = RequireVnpayConfig("vnpay:TmnCode");
            var hashSecret = RequireVnpayConfig("vnpay:HashSecret");
            var returnUrl = RequireVnpayConfig("vnpay:ReturnUrl");

            var createDate = DateTime.Now;
            var amountForVnpay = (long)(amount * 100m);
            var parameters = new SortedDictionary<string, string>(StringComparer.Ordinal)
            {
                { "vnp_Version", "2.1.0" },
                { "vnp_Command", "pay" },
                { "vnp_TmnCode", tmnCode },
                { "vnp_Amount", amountForVnpay.ToString(CultureInfo.InvariantCulture) },
                { "vnp_CurrCode", "VND" },
                { "vnp_TxnRef", txnRef.Trim() },
                { "vnp_OrderInfo", SanitizeOrderInfo(orderInfo) },
                { "vnp_OrderType", "other" },
                { "vnp_Locale", "vn" },
                { "vnp_ReturnUrl", returnUrl },
                { "vnp_IpAddr", string.IsNullOrWhiteSpace(ipAddr) ? "127.0.0.1" : ipAddr.Trim() },
                { "vnp_CreateDate", createDate.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture) },
                { "vnp_ExpireDate", createDate.AddMinutes(15).ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture) },
                { "vnp_BankCode", "VNPAYQR" }
            };

            var rawHash = string.Join("&", parameters.Select(x => x.Key + "=" + x.Value));
            var secureHash = Sign(rawHash, hashSecret);
            var query = string.Join("&", parameters.Select(x => UrlEncode(x.Key) + "=" + UrlEncode(x.Value)));
            var separator = payUrl.Contains("?") ? "&" : "?";

            return payUrl + separator + query + "&vnp_SecureHash=" + secureHash;
        }

        private static string RequireVnpayConfig(string key)
        {
            var value = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidOperationException("VNPAY configuration is missing. Please update App.config.");
            }

            return value.Trim();
        }

        private static string SanitizeOrderInfo(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return "Thanh toan hoc phi";
            }

            var normalized = value.Replace('đ', 'd').Replace('Đ', 'D').Normalize(NormalizationForm.FormD);
            var builder = new StringBuilder();
            foreach (var c in normalized)
            {
                var category = CharUnicodeInfo.GetUnicodeCategory(c);
                if (category == UnicodeCategory.NonSpacingMark)
                {
                    continue;
                }

                if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '-' || c == '_' || c == '.')
                {
                    builder.Append(c);
                }
                else
                {
                    builder.Append(' ');
                }
            }

            var sanitized = Regex.Replace(builder.ToString().Normalize(NormalizationForm.FormC), @"\s+", " ").Trim();
            return string.IsNullOrWhiteSpace(sanitized) ? "Thanh toan hoc phi" : sanitized;
        }

        private static string Sign(string rawHash, string hashSecret)
        {
            var keyBytes = Encoding.UTF8.GetBytes(hashSecret);
            var dataBytes = Encoding.UTF8.GetBytes(rawHash);
            using (var hmac = new HMACSHA512(keyBytes))
            {
                var hashBytes = hmac.ComputeHash(dataBytes);
                return BitConverter.ToString(hashBytes).Replace("-", string.Empty).ToLowerInvariant();
            }
        }

        private static string UrlEncode(string value)
        {
            return Uri.EscapeDataString(value ?? string.Empty);
        }
    }
}
