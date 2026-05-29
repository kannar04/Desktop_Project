using System.Drawing;

namespace DesktopApp_Project.GUI.Shared.Themes
{
    public interface ITheme
    {
        string Name { get; }

        Color BackgroundDark { get; }
        Color PanelDark { get; }
        Color ControlBackground { get; }
        Color BorderColor { get; }
        Color PrimaryText { get; }
        Color SecondaryText { get; }
        Color Accent { get; }
        Color AccentHover { get; }
        Color AccentPressed { get; }
        Color Success { get; }
        Color Warning { get; }
        Color Danger { get; }

        Font TitleFont { get; }
        Font BodyFont { get; }
    }
}
