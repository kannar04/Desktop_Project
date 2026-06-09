// Thành phần chủ đề giao diện cho giao diện Windows Forms
// Chức năng:
// - Khai báo hoặc áp dụng màu sắc, phông chữ và trạng thái giao diện
// - Hỗ trợ các biểu mẫu dùng chung một phong cách hiển thị

using System.Drawing;

namespace DesktopApp_Project.GUI.Shared.Themes
{
    // Lớp chuyển cấu hình AppTheme cũ sang hợp đồng chủ đề dùng chung cho giao diện.
    public sealed class AppThemeAdapter : ITheme
    {
        public string Name
        {
            get { return "AppTheme"; }
        }

        // =========================
        // BACKGROUND / SURFACE
        // =========================

        public Color BackgroundDark
        {
            get
            {
                return AppTheme.DarkMode
                    ? ColorTranslator.FromHtml("#101B3A")
                    : ColorTranslator.FromHtml("#EEF2F6");
            }
        }

        public Color PanelDark
        {
            get
            {
                return AppTheme.DarkMode
                    ? ColorTranslator.FromHtml("#2D3250")
                    : ColorTranslator.FromHtml("#DCE3EB");
            }
        }

        public Color ControlBackground
        {
            get
            {
                return AppTheme.DarkMode
                    ? ColorTranslator.FromHtml("#424769")
                    : ColorTranslator.FromHtml("#F5F7FA");
            }
        }

        public Color BorderColor
        {
            get
            {
                return AppTheme.DarkMode
                    ? ColorTranslator.FromHtml("#515A87")
                    : ColorTranslator.FromHtml("#CBD5E1");
            }
        }

        // =========================
        // TEXT
        // =========================

        public Color PrimaryText
        {
            get
            {
                return AppTheme.DarkMode
                    ? Color.White
                    : ColorTranslator.FromHtml("#1E293B");
            }
        }

        public Color SecondaryText
        {
            get
            {
                return AppTheme.DarkMode
                    ? ColorTranslator.FromHtml("#D8D9E6")
                    : ColorTranslator.FromHtml("#718096");
            }
        }

        // =========================
        // ACCENT
        // =========================

        public Color Accent
        {
            get
            {
                return AppTheme.DarkMode
                    ? ColorTranslator.FromHtml("#F9B17A")
                    : ColorTranslator.FromHtml("#4A5D7A");
            }
        }

        public Color AccentHover
        {
            get
            {
                return AppTheme.DarkMode
                    ? ColorTranslator.FromHtml("#FFC28F")
                    : ColorTranslator.FromHtml("#5B6B8C");
            }
        }

        public Color AccentPressed
        {
            get
            {
                return AppTheme.DarkMode
                    ? ColorTranslator.FromHtml("#E79C65")
                    : ColorTranslator.FromHtml("#3B4A63");
            }
        }

        public Color ButtonText
        {
            get
            {
                return AppTheme.DarkMode
                    ? ColorTranslator.FromHtml("#101B3A")
                    : Color.White;
            }
        }

        // =========================
        // MÀU TRẠNG THÁI
        // =========================

        public Color Success
        {
            get { return ColorTranslator.FromHtml("#4CAF50"); }
        }

        public Color Warning
        {
            get { return ColorTranslator.FromHtml("#FFB74D"); }
        }

        public Color Danger
        {
            get { return ColorTranslator.FromHtml("#EF5350"); }
        }

        // =========================
        // PHÔNG CHỮ
        // =========================

        public Font TitleFont
        {
            get
            {
                return new Font(
                    "Segoe UI",
                    14F,
                    FontStyle.Bold);
            }
        }

        public Font BodyFont
        {
            get
            {
                return new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Regular);
            }
        }

        // =========================
        // bảng dữ liệu
        // =========================

        public Color GridHeader
        {
            get
            {
                return AppTheme.DarkMode
                    ? ColorTranslator.FromHtml("#2D3250")
                    : ColorTranslator.FromHtml("#DCE3EB");
            }
        }

        public Color GridRow
        {
            get
            {
                return AppTheme.DarkMode
                    ? ColorTranslator.FromHtml("#424769")
                    : Color.White;
            }
        }

        public Color GridAlternateRow
        {
            get
            {
                return AppTheme.DarkMode
                    ? ColorTranslator.FromHtml("#3A4060")
                    : ColorTranslator.FromHtml("#F5F7FA");
            }
        }

        public Color GridSelectedRow
        {
            get
            {
                return AppTheme.DarkMode
                    ? ColorTranslator.FromHtml("#F9B17A")
                    : ColorTranslator.FromHtml("#4A5D7A");
            }
        }

        public Color GridSelectedText
        {
            get
            {
                return AppTheme.DarkMode
                    ? ColorTranslator.FromHtml("#101B3A")
                    : Color.White;
            }
        }
    }
}
