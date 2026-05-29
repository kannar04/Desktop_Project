using System.Drawing;

namespace DesktopApp_Project.GUI.Shared.Themes
{
    public sealed class Test1Theme : ITheme
    {
        public string Name
        {
            get { return "Test1"; }
        }

        public Color BackgroundDark
        {
            get { return ColorTranslator.FromHtml("#151C2E"); }
        }

        public Color PanelDark
        {
            get { return ColorTranslator.FromHtml("#2D3250"); }
        }

        public Color ControlBackground
        {
            get { return ColorTranslator.FromHtml("#424769"); }
        }

        public Color BorderColor
        {
            get { return ColorTranslator.FromHtml("#676F9D"); }
        }

        public Color PrimaryText
        {
            get { return ColorTranslator.FromHtml("#FFFFFF"); }
        }

        public Color SecondaryText
        {
            get { return ColorTranslator.FromHtml("#C8D0E0"); }
        }

        public Color Accent
        {
            get { return ColorTranslator.FromHtml("#F9B17A"); }
        }

        public Color AccentHover
        {
            get { return ColorTranslator.FromHtml("#FFC994"); }
        }

        public Color AccentPressed
        {
            get { return ColorTranslator.FromHtml("#E09A60"); }
        }

        public Color Success
        {
            get { return ColorTranslator.FromHtml("#63D297"); }
        }

        public Color Warning
        {
            get { return ColorTranslator.FromHtml("#F9B17A"); }
        }

        public Color Danger
        {
            get { return ColorTranslator.FromHtml("#F26D6D"); }
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
