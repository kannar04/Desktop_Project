using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace DesktopApp_Project.GUI.Shared.Themes
{
    public static class ThemeManager
    {
        private static readonly Dictionary<string, Func<ITheme>> _registry =
            new Dictionary<string, Func<ITheme>>(StringComparer.OrdinalIgnoreCase)
            {
                { "AppTheme", delegate { return new AppThemeAdapter(); } },
                { "Default", delegate { return new AppThemeAdapter(); } },
                { "Test1", delegate { return new Test1Theme(); } }
            };

        static ThemeManager()
        {
            Current = new AppThemeAdapter();
        }

        public static event EventHandler ThemeChanged;

        public static ITheme Current { get; private set; }

        public static void SetTheme(string name)
        {
            Func<ITheme> factory;
            if (string.IsNullOrWhiteSpace(name) || !_registry.TryGetValue(name, out factory))
            {
                throw new ArgumentException("Theme khong ton tai: " + name, "name");
            }

            Current = factory();
            var handler = ThemeChanged;
            if (handler != null)
            {
                handler(null, EventArgs.Empty);
            }
        }

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
                control.Font = Current.BodyFont;
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
                groupBox.BackColor = Current.PanelDark;
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

        private static void ApplyLabel(Label label)
        {
            label.BackColor = Color.Transparent;
            label.ForeColor = IsSecondaryLabel(label) ? Current.SecondaryText : Current.PrimaryText;
            label.Font = IsTitleLabel(label) ? Current.TitleFont : Current.BodyFont;
        }

        private static bool IsSecondaryLabel(Label label)
        {
            var name = (label.Name ?? string.Empty).TrimStart('_');
            return !IsTitleLabel(label)
                   && !string.IsNullOrEmpty(name)
                   && name.StartsWith("lbl", StringComparison.OrdinalIgnoreCase);
        }

        private static bool IsTitleLabel(Label label)
        {
            var name = (label.Name ?? string.Empty).TrimStart('_');
            return label.Dock == DockStyle.Top
                   || label.Height >= 40
                   || (!string.IsNullOrEmpty(name)
                       && name.IndexOf("Title", StringComparison.OrdinalIgnoreCase) >= 0);
        }

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

        private static void ApplyButton(Button button)
        {
            if (!CanUse(button))
            {
                return;
            }

            button.FlatStyle = FlatStyle.Flat;
            button.UseVisualStyleBackColor = false;
            button.BackColor = Current.Accent;
            button.ForeColor = GetReadableTextColor(Current.Accent);
            button.Font = Current.BodyFont;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = Current.AccentHover;
            button.FlatAppearance.MouseDownBackColor = Current.AccentPressed;

            button.MouseEnter -= Button_MouseEnter;
            button.MouseLeave -= Button_MouseLeave;
            button.MouseDown -= Button_MouseDown;
            button.MouseUp -= Button_MouseUp;
            button.MouseEnter += Button_MouseEnter;
            button.MouseLeave += Button_MouseLeave;
            button.MouseDown += Button_MouseDown;
            button.MouseUp += Button_MouseUp;
        }

        private static void ApplyIconButton(IconButton button)
        {
            if (!CanUse(button))
            {
                return;
            }

            button.FlatStyle = FlatStyle.Flat;
            button.UseVisualStyleBackColor = false;
            button.BackColor = Color.Transparent;
            button.ForeColor = Current.PrimaryText;
            button.IconColor = Current.Accent;
            button.Font = Current.BodyFont;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = Current.ControlBackground;
            button.FlatAppearance.MouseDownBackColor = Current.AccentPressed;
        }

        private static void ApplyGrid(DataGridView grid)
        {
            grid.BackgroundColor = Current.BackgroundDark;
            grid.GridColor = Current.BorderColor;
            grid.EnableHeadersVisualStyles = false;
            grid.BorderStyle = BorderStyle.None;
            grid.Font = Current.BodyFont;
            grid.RowTemplate.DefaultCellStyle.BackColor = Current.ControlBackground;
            grid.RowTemplate.DefaultCellStyle.ForeColor = Current.PrimaryText;
            grid.RowTemplate.DefaultCellStyle.SelectionBackColor = Current.Accent;
            grid.RowTemplate.DefaultCellStyle.SelectionForeColor = Current.BackgroundDark;

            grid.ColumnHeadersDefaultCellStyle.BackColor = Current.PanelDark;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Current.PrimaryText;
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Current.PanelDark;
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Current.PrimaryText;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font(Current.BodyFont, FontStyle.Bold);

            grid.DefaultCellStyle.BackColor = Current.ControlBackground;
            grid.DefaultCellStyle.ForeColor = Current.PrimaryText;
            grid.DefaultCellStyle.SelectionBackColor = Current.Accent;
            grid.DefaultCellStyle.SelectionForeColor = GetReadableTextColor(Current.Accent);

            grid.AlternatingRowsDefaultCellStyle.BackColor = Current.PanelDark;
            grid.AlternatingRowsDefaultCellStyle.ForeColor = Current.PrimaryText;
            grid.AlternatingRowsDefaultCellStyle.SelectionBackColor = Current.Accent;
            grid.AlternatingRowsDefaultCellStyle.SelectionForeColor = GetReadableTextColor(Current.Accent);
        }

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

        private static void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            var tabControl = sender as TabControl;
            if (!CanUse(tabControl) || e.Index < 0 || e.Index >= tabControl.TabPages.Count)
            {
                return;
            }

            var selected = e.Index == tabControl.SelectedIndex;
            var bounds = tabControl.GetTabRect(e.Index);
            var backColor = selected ? Current.Accent : Current.PanelDark;
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

        private static void Button_MouseEnter(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (CanUse(button) && Current != null)
            {
                button.BackColor = Current.AccentHover;
            }
        }

        private static void Button_MouseLeave(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (CanUse(button) && Current != null)
            {
                button.BackColor = Current.Accent;
            }
        }

        private static void Button_MouseDown(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            if (CanUse(button) && Current != null)
            {
                button.BackColor = Current.AccentPressed;
            }
        }

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

        private static bool CanUse(Control control)
        {
            return control != null && !control.IsDisposed && !control.Disposing;
        }

        public static Color GetReadableTextColor(Color background)
        {
            var luminance = (0.299 * background.R) + (0.587 * background.G) + (0.114 * background.B);
            return luminance >= 150 ? Color.FromArgb(21, 28, 46) : Color.White;
        }
    }
}
