using System;
// Thành phần hỗ trợ kiểm tra dữ liệu đầu vào
// Chức năng:
// - Kiểm tra chuỗi rỗng, địa chỉ thư điện tử và số điện thoại
// - Hỗ trợ tầng nghiệp vụ xác thực dữ liệu trước khi gọi tầng dữ liệu

using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace DesktopApp_Project.Common
{
    // Lớp hỗ trợ gom các hàm kiểm tra dữ liệu dùng lại ở tầng nghiệp vụ.
    public static class ValidationHelper
        {
            // Kiểm tra tính hợp lệ của dữ liệu đầu vào.
            public static bool IsBlank(string value)
            {
                return string.IsNullOrWhiteSpace(value);
            }
    
            // Kiểm tra tính hợp lệ của dữ liệu đầu vào.
            public static bool IsValidEmail(string email)
            {
                if (IsBlank(email))
                {
                    return false;
                }
    
                try
                {
                    var address = new MailAddress(email.Trim());
                    return address.Address == email.Trim();
                }
                catch
                {
                    return false;
                }
            }
    
            // Kiểm tra tính hợp lệ của dữ liệu đầu vào.
            public static bool IsValidVideoLink(string link)
            {
                if (IsBlank(link))
                {
                    return true;
                }
    
                Uri uri;
                return Uri.TryCreate(link.Trim(), UriKind.Absolute, out uri)
                       && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
            }
    
            // Kiểm tra tính hợp lệ của dữ liệu đầu vào.
            public static bool IsValidSkill(string skill)
            {
                return AppConstants.SkillLabels.Any(x => string.Equals(x, skill, StringComparison.OrdinalIgnoreCase));
            }
    
            // Kiểm tra tính hợp lệ của dữ liệu đầu vào.
            public static bool IsValidIeltsScore(decimal? score)
            {
                if (!score.HasValue)
                {
                    return true;
                }
    
                return score.Value >= AppConstants.IeltsMinScore
                       && score.Value <= AppConstants.IeltsMaxScore
                       && (score.Value * 10m) % 5m == 0m;
            }
    
            // Thực hiện xử lý dùng chung cho kiểm tra dữ liệu dùng chung.
            public static bool IsSupportedFile(string filePath, IEnumerable<string> allowedExtensions)
            {
                if (IsBlank(filePath))
                {
                    return true;
                }
    
                var extension = System.IO.Path.GetExtension(filePath).ToLowerInvariant();
                return allowedExtensions.Select(x => x.ToLowerInvariant()).Contains(extension);
            }
        }
}

