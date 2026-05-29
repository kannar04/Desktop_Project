using System.Drawing;

namespace DesktopApp_Project.GUI.Shared.Themes
{
    public sealed class AppThemeAdapter : ITheme
    {
        public string Name
        {
            get { return "AppTheme"; }
        }

        public Color BackgroundDark
        {
            get { return AppTheme.BackgroundColor; }
        }

        public Color PanelDark
        {
            get { return AppTheme.SurfaceColor; }
        }

        public Color ControlBackground
        {
            get { return AppTheme.SurfaceAltColor; }
        }

        public Color BorderColor
        {
            get { return AppTheme.BorderColor; }
        }

        public Color PrimaryText
        {
            get { return AppTheme.TextColor; }
        }

        public Color SecondaryText
        {
            get { return AppTheme.MutedTextColor; }
        }

        public Color Accent
        {
            get { return AppTheme.AccentColor; }
        }

        public Color AccentHover
        {
            get { return AppTheme.AccentSoftColor; }
        }

        public Color AccentPressed
        {
            get { return AppTheme.AccentColor; }
        }

        public Color Success
        {
            get { return AppTheme.SuccessColor; }
        }

        public Color Warning
        {
            get { return AppTheme.WarningColor; }
        }

        public Color Danger
        {
            get { return Color.FromArgb(220, 80, 80); }
        }

        public Font TitleFont
        {
            get { return new Font("Segoe UI", 14F, FontStyle.Bold); }
        }

        public Font BodyFont
        {
            get { return new Font("Segoe UI", 10F, FontStyle.Regular); }
        }
    }
}
