using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace DesktopApp_Project.Common
{
    public static class ValidationHelper
        {
            public static bool IsBlank(string value)
            {
                return string.IsNullOrWhiteSpace(value);
            }
    
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
    
            public static bool IsValidSkill(string skill)
            {
                return AppConstants.SkillLabels.Any(x => string.Equals(x, skill, StringComparison.OrdinalIgnoreCase));
            }
    
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

