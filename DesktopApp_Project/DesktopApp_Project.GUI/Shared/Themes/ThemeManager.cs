// Thành phần chủ đề giao diện cho giao diện Windows Forms
// Chức năng:
// - Khai báo hoặc áp dụng màu sắc, phông chữ và trạng thái giao diện
// - Hỗ trợ các biểu mẫu dùng chung một phong cách hiển thị

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace DesktopApp_Project.GUI.Shared.Themes
{
    // Lớp quản lý chủ đề giao diện dùng chung cho các biểu mẫu trong ứng dụng.
    public static class ThemeManager
    {
        private static readonly Dictionary<string, Func<ITheme>> _registry =
    new Dictionary<string, Func<ITheme>>
        {
            { "AppTheme", () => new AppThemeAdapter() }
        };

        static ThemeManager()
        {
            Current = new AppThemeAdapter();
        }

        public static event EventHandler ThemeChanged;

        public static ITheme Current { get; private set; }

        // Xử lý chọn chủ đề giao diện.
        public static void SetTheme(string name)
        {
            Func<ITheme> factory;
            if (string.IsNullOrWhiteSpace(name) || !_registry.TryGetValue(name, out factory))
            {
                throw new ArgumentException("Theme không tồn tại: " + name, "name");
            }

            Current = factory();
            var handler = ThemeChanged;
            if (handler != null)
            {
                handler(null, EventArgs.Empty);
            }
        }

        // Áp dụng chủ đề hiện tại cho toàn bộ cây điều khiển.
        public static void ApplyTheme(Control root)
        {
            if (!CanUse(root) || Current == null)
            {
                return;
            }

            root.SuspendLayout();
            try
            {
                ApplyControl(root);

                var tabControl = root as TabControl;
                if (tabControl != null)
                {
                    foreach (TabPage page in tabControl.TabPages)
                    {
                        ApplyTheme(page);
                    }
                }

                var children = new List<Control>();
                foreach (Control child in root.Controls)
                {
                    children.Add(child);
                }

                foreach (Control child in children)
                {
                    ApplyTheme(child);
                }

                if (CanUse(root))
                {
                    root.Invalidate(true);
                }
            }
            finally
            {
                if (CanUse(root))
                {
                    root.ResumeLayout(false);
                }
            }
        }

        // Áp dụng màu sắc và phông chữ phù hợp cho từng điều khiển theo chủ đề hiện tại.
        private static void ApplyControl(Control control)
        {
            if (!CanUse(control))
            {
                return;
            }

            if (control is Form)
            {
                control.BackColor = Current.BackgroundDark;
                control.ForeColor = Current.PrimaryText;

                // Không gán phông chữ cho biểu mẫu tại đây vì Windows Forms sẽ kích hoạt AutoScale theo phông chữ.
                // Khi đổi chủ đề nhiều lần, AutoScale có thể phóng to các điều khiển con và làm sai kích thước giao diện.
                // Nếu cần đổi phông chữ cho nút, nhãn hoặc ô nhập liệu, hãy gán riêng cho từng điều khiển.
                // (control.Font = Current.BodyFont);
            }

            var panel = control as Panel;
            if (panel != null)
            {
                panel.BackColor = Current.PanelDark;
            }

            var table = control as TableLayoutPanel;
            if (table != null)
            {
                table.BackColor = Current.PanelDark;
            }

            var flow = control as FlowLayoutPanel;
            if (flow != null)
            {
                flow.BackColor = Current.PanelDark;
            }

            var groupBox = control as GroupBox;
            if (groupBox != null)
            {
                groupBox.BackColor = ColorTranslator.FromHtml("#353B5C");
                groupBox.ForeColor = Current.PrimaryText;
                groupBox.Font = Current.BodyFont;
            }

            var label = control as Label;
            if (label != null)
            {
                ApplyLabel(label);
            }

            var iconButton = control as IconButton;
            if (iconButton != null)
            {
                ApplyIconButton(iconButton);
                return;
            }

            var button = control as Button;
            if (button != null)
            {
                ApplyButton(button);
            }

            var iconPicture = control as IconPictureBox;
            if (iconPicture != null)
            {
                iconPicture.BackColor = Color.Transparent;
                iconPicture.ForeColor = Current.Accent;
                iconPicture.IconColor = Current.Accent;
            }

            var textBox = control as TextBox;
            if (textBox != null)
            {
                textBox.BackColor = Current.ControlBackground;
                textBox.ForeColor = Current.PrimaryText;
                textBox.BorderStyle = BorderStyle.FixedSingle;
                textBox.Font = Current.BodyFont;
            }

            var richTextBox = control as RichTextBox;
            if (richTextBox != null)
            {
                richTextBox.BackColor = Current.ControlBackground;
                richTextBox.ForeColor = Current.PrimaryText;
                richTextBox.BorderStyle = BorderStyle.FixedSingle;
                richTextBox.Font = Current.BodyFont;
            }

            var comboBox = control as ComboBox;
            if (comboBox != null)
            {
                comboBox.BackColor = Current.ControlBackground;
                comboBox.ForeColor = Current.PrimaryText;
                comboBox.FlatStyle = FlatStyle.Flat;
                comboBox.Font = Current.BodyFont;
            }

            var grid = control as DataGridView;
            if (grid != null)
            {
                ApplyGrid(grid);
            }

            var tabControl = control as TabControl;
            if (tabControl != null)
            {
                ApplyTabControl(tabControl);
            }

            var tabPage = control as TabPage;
            if (tabPage != null)
            {
                tabPage.UseVisualStyleBackColor = false;
                tabPage.BackColor = Current.PanelDark;
                tabPage.ForeColor = Current.PrimaryText;
                tabPage.Font = Current.BodyFont;
            }

            var date = control as DateTimePicker;
            if (date != null)
            {
                date.BackColor = Current.ControlBackground;
                date.ForeColor = Current.PrimaryText;
                date.CalendarMonthBackground = Current.PanelDark;
                date.CalendarForeColor = Current.PrimaryText;
                date.CalendarTitleBackColor = Current.PanelDark;
                date.CalendarTitleForeColor = Current.PrimaryText;
                date.Font = Current.BodyFont;
            }

            var checkedListBox = control as CheckedListBox;
            if (checkedListBox != null)
            {
                checkedListBox.BackColor = Current.ControlBackground;
                checkedListBox.ForeColor = Current.PrimaryText;
                checkedListBox.Font = Current.BodyFont;
            }

            var listBox = control as ListBox;
            if (listBox != null)
            {
                listBox.BackColor = Current.ControlBackground;
                listBox.ForeColor = Current.PrimaryText;
                listBox.Font = Current.BodyFont;
            }
        }

        // Áp dụng màu nền, màu chữ và phông chữ cho nhãn theo vai trò tiêu đề hoặc nội dung.
        private static void ApplyLabel(Label label)
        {
            if (label == null)
                return;

            label.BackColor =
                label.Parent != null
                    ? label.Parent.BackColor
                    : Current.PanelDark;

            // Xác định vai trò của nhãn theo tên hoặc ý nghĩa thay vì chỉ dựa vào cỡ phông chữ hiện tại.
            if (IsTitleLabel(label))
            {
                // Chỉ ghi đè phông chữ khi việc này không làm nhỏ phông chữ lớn đã được thiết kế chủ ý.
                if (ShouldOverrideFont(label.Font, Current.TitleFont))
                {
                    label.ForeColor = Current.PrimaryText;
                    label.Font = Current.TitleFont;
                }
                else
                {
                    // Giữ phông chữ lớn từ Designer nhưng vẫn cập nhật màu theo chủ đề hiện tại.
                    label.ForeColor = Current.PrimaryText;
                }
            }
            else
            {
                // Chỉ áp dụng phông chữ nội dung khi không làm giảm kích thước phông chữ tùy chỉnh.
                if (ShouldOverrideFont(label.Font, Current.BodyFont))
                {
                    label.ForeColor = Current.SecondaryText;
                    label.Font = Current.BodyFont;
                }
                else
                {
                    // Giữ phông chữ lớn có chủ ý nhưng cập nhật màu hiển thị.
                    label.ForeColor = Current.SecondaryText;
                }
            }
        }

        // Xác định có thể ghi đè phông chữ mà không làm nhỏ phông chữ lớn đã được thiết kế chủ ý hay không.
        private static bool ShouldOverrideFont(Font current, Font target)
        {
            if (current == null || target == null)
                return true;

            // Giữ các phông chữ tùy chỉnh lớn; chỉ ghi đè khi phông chữ hiện tại không lớn hơn phông chữ mục tiêu.
            return current.SizeInPoints <= target.SizeInPoints + 0.001f;
        }

        // Xác định nhãn phụ để áp dụng màu chữ và phông chữ nội dung.
        private static bool IsSecondaryLabel(Label label)
        {
            var name = (label.Name ?? string.Empty).TrimStart('_');
            return !IsTitleLabel(label)
                   && !string.IsNullOrEmpty(name)
                   && name.StartsWith("lbl", StringComparison.OrdinalIgnoreCase);
        }

        // Không chỉ dựa vào cỡ phông chữ hiện tại để nhận diện nhãn tiêu đề.
        // Ưu tiên tên điều khiển từ Designer, chỉ dùng cỡ phông chữ khi tên không đủ thông tin.
        private static bool IsTitleLabel(Label label)
        {
            if (label == null)
                return false;

            var name = (label.Name ?? string.Empty);

            // Ưu tiên các tên thể hiện rõ vai trò tiêu đề như lblTitle hoặc lblHeader.
            if (name.IndexOf("Title", StringComparison.OrdinalIgnoreCase) >= 0 ||
                name.IndexOf("Header", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return true;
            }

            // Nếu nhãn có Tag = "Title" thì cũng xem là nhãn tiêu đề.
            if (label.Tag != null && string.Equals(Convert.ToString(label.Tag), "Title", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            // Trường hợp dự phòng: phông chữ rất lớn từ Designer được xem là tiêu đề, còn cỡ trung bình thì không đủ chắc chắn.
            return label.Font != null && label.Font.SizeInPoints >= 18f;
        }

        // Áp dụng màu sắc, phông chữ và cách vẽ thủ công cho TabControl theo chủ đề hiện tại.
        private static void ApplyTabControl(TabControl tabControl)
        {
            tabControl.BackColor = Current.BackgroundDark;
            tabControl.ForeColor = Current.PrimaryText;
            tabControl.Font = Current.BodyFont;
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.SizeMode = TabSizeMode.Fixed;
            tabControl.ItemSize = new Size(Math.Max(120, tabControl.ItemSize.Width), Math.Max(32, tabControl.ItemSize.Height));

            tabControl.DrawItem -= TabControl_DrawItem;
            tabControl.DrawItem += TabControl_DrawItem;
            tabControl.SelectedIndexChanged -= TabControl_SelectedIndexChanged;
            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;

            foreach (TabPage page in tabControl.TabPages)
            {
                page.UseVisualStyleBackColor = false;
                page.BackColor = Current.PanelDark;
                page.ForeColor = Current.PrimaryText;
                page.Font = Current.BodyFont;
            }
        }

        // Áp dụng kiểu nút chính với màu nhấn và trạng thái hover/click.
        private static void ApplyButton(Button button)
        {
            if (button == null)
                return;

            button.FlatStyle = FlatStyle.Flat;
            button.UseVisualStyleBackColor = false;

            button.FlatAppearance.BorderSize = 0;

            button.BackColor =
                Current.Accent;

            button.ForeColor =
                Current.ButtonText;

            button.Font =
                Current.BodyFont;

            button.Cursor =
                Cursors.Hand;

            button.FlatAppearance.MouseOverBackColor =
                Current.AccentHover;

            button.FlatAppearance.MouseDownBackColor =
                Current.AccentPressed;
        }

        // Áp dụng kiểu nút phụ với viền và nền trung tính theo chủ đề.
        private static void ApplySecondaryButton(Button button)
        {
            if (button == null)
                return;

            button.FlatStyle = FlatStyle.Flat;

            button.FlatAppearance.BorderSize = 1;

            button.FlatAppearance.BorderColor =
                Current.BorderColor;

            button.BackColor =
                Current.ControlBackground;

            button.ForeColor =
                Current.PrimaryText;

            button.Font =
                Current.BodyFont;

            button.Cursor =
                Cursors.Hand;
        }

        // Áp dụng màu sắc cho nút có biểu tượng FontAwesome trong menu và thanh công cụ.
        private static void ApplyIconButton(IconButton button)
        {
            if (!CanUse(button))
            {
                return;
            }

            button.FlatStyle = FlatStyle.Flat;
            button.UseVisualStyleBackColor = false;
            button.BackColor = Current.PanelDark;
            button.ForeColor = Current.PrimaryText;
            button.IconColor = Current.Accent;
            button.Font = Current.BodyFont;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = Current.ControlBackground;
            button.FlatAppearance.MouseDownBackColor = Current.AccentPressed;
        }

        // Áp dụng giao diện tối và màu chữ cho bảng dữ liệu.
        private static void ApplyGrid(DataGridView grid)
        {
            grid.SuspendLayout();

            grid.EnableHeadersVisualStyles = false;

            // Thiết lập giao diện nền của bảng.
            grid.BackgroundColor = Current.BackgroundDark;
            grid.BorderStyle = BorderStyle.None;
            grid.GridColor = Current.BorderColor;

            grid.Font = Current.BodyFont;

            grid.RowHeadersVisible = false;

            grid.AllowUserToResizeRows = false;

            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            grid.MultiSelect = false;

            // Header
            grid.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;

            grid.ColumnHeadersHeight = 40;

            grid.ColumnHeadersDefaultCellStyle.BackColor =
                Current.GridHeader;

            grid.ColumnHeadersDefaultCellStyle.ForeColor =
                Current.PrimaryText;

            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Current.GridHeader;

            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                Current.PrimaryText;

            grid.ColumnHeadersDefaultCellStyle.Font =
                new Font(Current.BodyFont, FontStyle.Bold);

            grid.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            // Rows
            grid.DefaultCellStyle.BackColor =
                Current.GridRow;

            grid.DefaultCellStyle.ForeColor =
                Current.PrimaryText;

            grid.DefaultCellStyle.SelectionBackColor =
                Current.GridSelectedRow;

            grid.DefaultCellStyle.SelectionForeColor =
                Current.GridSelectedText;

            grid.DefaultCellStyle.Padding =
                new Padding(4);

            // Alternate Rows
            grid.AlternatingRowsDefaultCellStyle.BackColor =
                Current.GridAlternateRow;

            grid.AlternatingRowsDefaultCellStyle.ForeColor =
                Current.PrimaryText;

            grid.AlternatingRowsDefaultCellStyle.SelectionBackColor =
                Current.GridSelectedRow;

            grid.AlternatingRowsDefaultCellStyle.SelectionForeColor =
                Current.GridSelectedText;

            // Row Style
            grid.RowTemplate.Height = 36;

            grid.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            // Remove ugly blue focus rectangle
            grid.DefaultCellStyle.WrapMode =
                DataGridViewTriState.False;

            // Better visual
            grid.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            grid.RowHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            grid.ResumeLayout();
        }

        // Xử lý khi người dùng thay đổi lựa chọn trên bộ lọc hoặc combobox.
        private static void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tabControl = sender as TabControl;
            if (!CanUse(tabControl))
            {
                return;
            }

            foreach (TabPage page in tabControl.TabPages)
            {
                ApplyTheme(page);
            }

            tabControl.Invalidate();
        }

        // Xử lý vẽ tab đang hiển thị.
        private static void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            var tabControl = sender as TabControl;
            if (!CanUse(tabControl) || e.Index < 0 || e.Index >= tabControl.TabPages.Count)
            {
                return;
            }

            var selected = e.Index == tabControl.SelectedIndex;
            var bounds = tabControl.GetTabRect(e.Index);
            var backColor = selected ? Current.Accent : ColorTranslator.FromHtml("#353B5C");
            var textColor = selected ? GetReadableTextColor(Current.Accent) : Current.PrimaryText;

            using (var backBrush = new SolidBrush(backColor))
            using (var textBrush = new SolidBrush(textColor))
            using (var borderPen = new Pen(Current.BorderColor))
            using (var textFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                e.Graphics.FillRectangle(backBrush, bounds);
                e.Graphics.DrawRectangle(borderPen, bounds.X, bounds.Y, bounds.Width - 1, bounds.Height - 1);
                e.Graphics.DrawString(tabControl.TabPages[e.Index].Text, Current.BodyFont, textBrush, bounds, textFormat);
            }
        }

        // Xử lý khi rê chuột vào nút.
        private static void Button_MouseEnter(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (CanUse(button) && Current != null)
            {
                button.BackColor = Current.AccentHover;
            }
        }

        // Xử lý khi rời chuột khỏi nút.
        private static void Button_MouseLeave(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (CanUse(button) && Current != null)
            {
                button.BackColor = Current.Accent;
            }
        }

        // Xử lý khi nhấn chuột xuống nút.
        private static void Button_MouseDown(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            if (CanUse(button) && Current != null)
            {
                button.BackColor = Current.AccentPressed;
            }
        }

        // Xử lý khi thả chuột trên nút.
        private static void Button_MouseUp(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            if (!CanUse(button) || Current == null)
            {
                return;
            }

            try
            {
                button.BackColor = button.ClientRectangle.Contains(button.PointToClient(Cursor.Position))
                    ? Current.AccentHover
                    : Current.Accent;
            }
            catch (ObjectDisposedException)
            {
                return;
            }
        }

        // Kiểm tra điều khiển còn sử dụng được trước khi áp dụng chủ đề.
        private static bool CanUse(Control control)
        {
            return control != null && !control.IsDisposed && !control.Disposing;
        }

        // Chọn màu chữ dễ đọc dựa trên độ sáng của màu nền.
        public static Color GetReadableTextColor(Color background)
        {
            double brightness =
                (background.R * 0.299) +
                (background.G * 0.587) +
                (background.B * 0.114);

            return brightness > 186
                ? Color.FromArgb(16, 27, 58)
                : Color.White;
        }
    }
}
