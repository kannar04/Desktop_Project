// Thành phần chủ đề giao diện cho giao diện Windows Forms
// Chức năng:
// - Khai báo hoặc áp dụng màu sắc, phông chữ và trạng thái giao diện
// - Hỗ trợ các biểu mẫu dùng chung một phong cách hiển thị

using System.Drawing;

namespace DesktopApp_Project.GUI.Shared.Themes
{
    // Hợp đồng mô tả cấu hình chủ đề giao diện để ThemeManager áp dụng cho giao diện.
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
        Color ButtonText { get; }
        Color Success { get; }
        Color Warning { get; }
        Color Danger { get; }

        Font TitleFont { get; }
        Font BodyFont { get; }
        Color GridHeader { get; }
        Color GridRow { get; }
        Color GridAlternateRow { get; }
        Color GridSelectedRow { get; }
        Color GridSelectedText { get; }
    }
}
