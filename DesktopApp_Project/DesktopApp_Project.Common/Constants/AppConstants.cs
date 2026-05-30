using System.Collections.Generic;
using System.Text;

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

            public static readonly string[] IeltsQuestionTypes =
            {
                "Multiple Choice",
                "Matching",
                "True/False/Not Given",
                "Fill in the Blank",
                "Short Answer"
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

            public static readonly string[] AttendancePresentAliases = BuildAliases(AttendancePresent);
            public static readonly string[] AttendanceLateAliases = BuildAliases(AttendanceLate);
    
            public const string EnrollmentActive = "Đang học";
            public const string EnrollmentPaused = "Tạm nghỉ";
            public const string EnrollmentStopped = "Đã nghỉ";
    
            public static readonly string[] EnrollmentStatuses =
            {
                EnrollmentActive,
                EnrollmentPaused,
                EnrollmentStopped
            };

            public static readonly string[] EnrollmentActiveAliases = BuildAliases(EnrollmentActive);
    
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
            public const string PaymentCancelled = "Đã hủy";
            public const string PaymentMethodMoMo = "MoMo";
            public const string PaymentMethodVNPay = "VNPay";
    
            public static readonly string[] PaymentStatuses =
            {
                PaymentPending,
                PaymentPaid,
                PaymentOverdue
            };

            public static readonly string[] PaymentMethods =
            {
                PaymentMethodMoMo,
                PaymentMethodVNPay
            };

            public static readonly string[] SupportedMediaExtensions =
            {
                ".pdf",
                ".doc",
                ".docx",
                ".ppt",
                ".pptx",
                ".xls",
                ".xlsx",
                ".txt",
                ".jpg",
                ".jpeg",
                ".png",
                ".gif",
                ".bmp",
                ".mp3",
                ".wav",
                ".m4a",
                ".mp4",
                ".mov",
                ".avi",
                ".mkv"
            };

            public static readonly string[] PaymentPaidAliases = BuildAliases(PaymentPaid);
    
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
                "A1",
                "A2",
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
    
            public static string[] GetTextAliases(string value)
            {
                return BuildAliases(value);
            }

            private static string[] BuildAliases(params string[] values)
            {
                var result = new List<string>();
                foreach (var value in values)
                {
                    AddAlias(result, value);
                    AddAlias(result, ToLegacyMojibake(value));
                }

                return result.ToArray();
            }

            private static void AddAlias(List<string> result, string value)
            {
                if (!string.IsNullOrEmpty(value) && !result.Contains(value))
                {
                    result.Add(value);
                }
            }

            private static string ToLegacyMojibake(string value)
            {
                return Encoding.GetEncoding(1252).GetString(Encoding.UTF8.GetBytes(value));
            }

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
}
