using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace DesktopApp_Project.Common
{
    public static class AppConstants
    {
        public const string RoleAdmin = "Admin";
        public const string RoleTeacher = "GiaoVien";
        public const string RoleStudent = "HocSinh";
        public const string RoleStaff = "NhanVien";

        public static readonly string[] AdminRoles =
        {
            RoleAdmin,
            RoleTeacher,
            RoleStaff
        };

        public static readonly string[] SkillLabels =
        {
            "Listening",
            "Reading",
            "Writing",
            "Speaking"
        };

        public static readonly string[] AttendanceStatuses =
        {
            "Có mặt",
            "Vắng",
            "Đi trễ"
        };

        public const decimal IeltsMinScore = 0m;
        public const decimal IeltsMaxScore = 9m;
        public const int HocPhiDeadlineDays = 10;

        public static string GetDisplayRole(string role)
        {
            if (role == RoleAdmin)
            {
                return "Quản trị";
            }

            if (role == RoleTeacher)
            {
                return "Giáo viên";
            }

            if (role == RoleStudent)
            {
                return "Học sinh";
            }

            if (role == RoleStaff)
            {
                return "Nhân viên";
            }

            return role;
        }
    }

    public class ServiceResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public static ServiceResult Ok(string message)
        {
            return new ServiceResult { Success = true, Message = message };
        }

        public static ServiceResult Fail(string message)
        {
            return new ServiceResult { Success = false, Message = message };
        }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T Data { get; set; }

        public static ServiceResult<T> Ok(T data, string message)
        {
            return new ServiceResult<T> { Success = true, Data = data, Message = message };
        }

        public new static ServiceResult<T> Fail(string message)
        {
            return new ServiceResult<T> { Success = false, Message = message };
        }
    }

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
