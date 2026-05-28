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

        public static readonly string[] SupportedRoles =
        {
            RoleAdmin,
            RoleTeacher,
            RoleStudent,
            RoleStaff
        };

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

        public const string FilterAll = "Tất cả";
        public const string AttendancePresent = "Có mặt";
        public const string AttendanceAbsent = "Vắng";
        public const string AttendanceLate = "Đi trễ";

        public static readonly string[] AttendanceStatuses =
        {
            AttendancePresent,
            AttendanceAbsent,
            AttendanceLate
        };

        public const string EnrollmentActive = "Đang học";
        public const string EnrollmentPaused = "Tạm nghỉ";
        public const string EnrollmentStopped = "Đã nghỉ";

        public static readonly string[] EnrollmentStatuses =
        {
            EnrollmentActive,
            EnrollmentPaused,
            EnrollmentStopped
        };

        public static readonly string[] StudentStatusFilters =
        {
            FilterAll,
            EnrollmentActive,
            EnrollmentPaused,
            EnrollmentStopped
        };

        public const string PaymentPending = "Chờ thanh toán";
        public const string PaymentPaid = "Đã thanh toán";
        public const string PaymentOverdue = "Quá hạn";

        public static readonly string[] PaymentStatuses =
        {
            PaymentPending,
            PaymentPaid,
            PaymentOverdue
        };

        public static readonly string[] SubmissionStatuses =
        {
            "Chưa nộp",
            "Đã nộp",
            "Đã chấm"
        };

        public static readonly string[] WordTypes =
        {
            "noun",
            "verb",
            "adjective",
            "adverb",
            "phrase"
        };

        public static readonly string[] CefrLevels =
        {
            "B1",
            "B2",
            "C1",
            "C2"
        };

        public static readonly string[] VocabularyTopics =
        {
            "Technology",
            "Sports",
            "Education",
            "Health",
            "Business",
            "Environment",
            "Travel",
            "Food/Fruits",
            "Academic/IELTS General"
        };

        public static readonly string[] ReportTypes =
        {
            "Điểm số",
            "Bài tập",
            "Chuyên cần",
            "Cuối kỳ"
        };

        public const decimal IeltsMinScore = 0m;
        public const decimal IeltsMaxScore = 9m;
        public const int HocPhiDeadlineDays = 10;
        public const decimal LongTermTuitionDiscountPercent = 20m;
        public const int LongTermTuitionDiscountYears = 2;

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
