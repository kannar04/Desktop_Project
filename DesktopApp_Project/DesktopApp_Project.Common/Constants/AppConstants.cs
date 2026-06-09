// Hằng số dùng chung của ứng dụng
// Chức năng:
// - Tập trung vai trò, trạng thái, cấu hình nghiệp vụ và danh mục lựa chọn
// - Chuẩn hóa giá trị hiển thị giữa giao diện, tầng nghiệp vụ và tầng dữ liệu

using System.Collections.Generic;
using System.Text;

namespace DesktopApp_Project.Common
{
    // Lớp chứa hằng số và danh mục nghiệp vụ dùng chung toàn ứng dụng.
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

            // Chuẩn hóa alias để so khớp dữ liệu tiếng Việt cũ và mới.
            public static readonly string[] AttendancePresentAliases = BuildAliases(AttendancePresent);
            // Chuẩn hóa alias để so khớp dữ liệu tiếng Việt cũ và mới.
            public static readonly string[] AttendanceLateAliases = BuildAliases(AttendanceLate);
    
            public const string EnrollmentActive = "Đang học";
            public const string EnrollmentPaused = "Tạm nghỉ";
            public const string EnrollmentStopped = "Đã nghỉ";
    
            // Chuẩn hóa alias để so khớp dữ liệu tiếng Việt cũ và mới.
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
            public const string PaymentExpired = "Hết hạn"; // Added for VNPAY demo.
            public const string PaymentFailed = "Thất bại"; // Added for VNPAY demo.
            public const string PaymentMethodMoMo = "MoMo";
            public const string PaymentMethodVNPay = "VNPay";
    
            public static readonly string[] PaymentStatuses =
            {
                PaymentPending,
                PaymentPaid,
                PaymentOverdue,
                PaymentExpired,
                PaymentFailed
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
                ".aac",
                ".flac",
                ".mp4",
                ".mov",
                ".avi",
                ".mkv"
            };

            // Chuẩn hóa alias để so khớp dữ liệu tiếng Việt cũ và mới.
            public static readonly string[] PaymentPaidAliases = BuildAliases(PaymentPaid);
    
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
    
            // Chuẩn hóa giá trị dùng chung để các tầng xử lý thống nhất.
            public static string[] GetTextAliases(string value)
            {
                // Chuẩn hóa alias để so khớp dữ liệu tiếng Việt cũ và mới.
                return BuildAliases(value);
            }

            // Chuẩn hóa giá trị dùng chung để các tầng xử lý thống nhất.
            private static string[] BuildAliases(params string[] values)
            {
                var result = new List<string>();
                foreach (var value in values)
                {
                    AddAlias(result, value);
                    // Chuẩn hóa alias để so khớp dữ liệu tiếng Việt cũ và mới.
                    AddAlias(result, ToLegacyMojibake(value));
                }

                return result.ToArray();
            }

            // Chuẩn hóa giá trị dùng chung để các tầng xử lý thống nhất.
            private static void AddAlias(List<string> result, string value)
            {
                if (!string.IsNullOrEmpty(value) && !result.Contains(value))
                {
                    result.Add(value);
                }
            }

            // Thực hiện xử lý dùng chung cho hằng số dùng chung.
            private static string ToLegacyMojibake(string value)
            {
                return Encoding.GetEncoding(1252).GetString(Encoding.UTF8.GetBytes(value));
            }

            // Chuẩn hóa giá trị dùng chung để các tầng xử lý thống nhất.
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
