using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Linq;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public static class UiHelpers
    {
        public static readonly Font DefaultFont = new Font("Segoe UI", 9F, FontStyle.Regular);
        public static readonly Font TitleFont = new Font("Segoe UI", 13F, FontStyle.Bold);
        public static readonly Color AccentColor = Color.FromArgb(95, 77, 221);
        public static readonly Color AccentSoftColor = Color.FromArgb(54, 48, 104);
        public static readonly Color AppBackgroundColor = Color.FromArgb(31, 30, 68);
        public static readonly Color SurfaceColor = Color.FromArgb(37, 36, 81);
        public static readonly Color SurfaceAltColor = Color.FromArgb(26, 25, 62);
        public static readonly Color BorderColor = Color.FromArgb(55, 54, 92);
        public static readonly Color TextColor = Color.Gainsboro;
        public static readonly Color MutedTextColor = Color.FromArgb(174, 174, 196);

        public static Button Button(string text)
        {
            var button = new Button
            {
                Text = text,
                AutoSize = false,
                Height = 34,
                Width = 110,
                Font = DefaultFont,
                BackColor = SurfaceColor,
                ForeColor = TextColor,
                FlatStyle = FlatStyle.Flat,
                Margin = new Padding(4),
                Padding = new Padding(8, 0, 8, 0),
                AutoEllipsis = true,
                Cursor = Cursors.Hand
            };
            ApplyButtonStyle(button);
            return button;
        }

        public static void ApplyButtonStyle(Button button)
        {
            button.FlatAppearance.BorderColor = BorderColor;
            button.FlatAppearance.MouseOverBackColor = AccentSoftColor;
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(77, 68, 140);
        }

        public static Label Label(string text)
        {
            return new Label
            {
                Text = text,
                AutoSize = true,
                Font = DefaultFont,
                ForeColor = MutedTextColor,
                Margin = new Padding(4, 8, 4, 2)
            };
        }

        public static TextBox TextBox()
        {
            return new TextBox
            {
                Width = 220,
                MinimumSize = new Size(150, 0),
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                Font = DefaultFont,
                ForeColor = TextColor,
                BackColor = SurfaceAltColor,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(4)
            };
        }

        public static ComboBox ComboBox()
        {
            return new ComboBox
            {
                Width = 220,
                MinimumSize = new Size(150, 0),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = DefaultFont,
                ForeColor = TextColor,
                BackColor = SurfaceAltColor,
                FlatStyle = FlatStyle.Flat,
                Margin = new Padding(4),
                Anchor = AnchorStyles.Left | AnchorStyles.Right
            };
        }

        public static DataGridView Grid()
        {
            return new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                BackgroundColor = AppBackgroundColor,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Font = DefaultFont,
                BorderStyle = BorderStyle.None,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                GridColor = BorderColor,
                RowHeadersVisible = false,
                EnableHeadersVisualStyles = false,
                ColumnHeadersHeight = 34,
                RowTemplate = { Height = 30 },
                MinimumSize = new Size(320, 180)
            };
        }

        public static int SelectedId(ComboBox combo)
        {
            if (combo.SelectedValue == null)
            {
                return 0;
            }

            int id;
            return int.TryParse(combo.SelectedValue.ToString(), out id) ? id : 0;
        }

        public static T SelectedItem<T>(DataGridView grid) where T : class
        {
            if (grid.CurrentRow == null)
            {
                return null;
            }

            return grid.CurrentRow.DataBoundItem as T;
        }

        public static void ShowResult(ServiceResult result)
        {
            MessageBox.Show(result.Message, result.Success ? "Thông báo" : "Lỗi",
                MessageBoxButtons.OK,
                result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }

        public static void BindLopHoc(ComboBox combo, ServiceFactory services)
        {
            combo.DataSource = null;
            combo.DataSource = services.LopHoc.LayDanhSach();
            combo.DisplayMember = "TenLop";
            combo.ValueMember = "MaLopHoc";
        }

        public static void BindKyNang(ComboBox combo)
        {
            combo.DataSource = AppConstants.SkillLabels.ToList();
        }

        public static TableLayoutPanel FormGrid()
        {
            var panel = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 4,
                Padding = new Padding(12, 10, 12, 10),
                Margin = new Padding(0),
                BackColor = SurfaceColor,
                GrowStyle = TableLayoutPanelGrowStyle.AddRows
            };
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            return panel;
        }

        public static void ApplyPolish(Control root)
        {
            ApplyDarkTheme(root);
        }

        public static void ApplyDarkTheme(Control root)
        {
            if (root == null)
            {
                return;
            }

            foreach (Control control in EnumerateControls(root))
            {
                ApplyControlTheme(control);
            }
        }

        private static void ApplyControlTheme(Control control)
        {
            if (control is Form)
            {
                control.BackColor = AppBackgroundColor;
                control.ForeColor = TextColor;
            }

            if (control is TableLayoutPanel || control is FlowLayoutPanel)
            {
                control.BackColor = control.Parent is Form ? AppBackgroundColor : SurfaceColor;
            }

            var panel = control as Panel;
            if (panel != null)
            {
                panel.BackColor = panel.Parent is Form ? AppBackgroundColor : SurfaceColor;
            }

            var label = control as Label;
            if (label != null)
            {
                label.ForeColor = TextColor;
                if (label.Dock == DockStyle.Top || label.Height >= 40)
                {
                    label.BackColor = SurfaceAltColor;
                }
                else if (label.BackColor != Color.Transparent)
                {
                    label.BackColor = Color.Transparent;
                }
            }

            var button = control as Button;
            if (button != null)
            {
                button.Font = DefaultFont;
                button.BackColor = SurfaceColor;
                button.ForeColor = TextColor;
                button.FlatStyle = FlatStyle.Flat;
                ApplyButtonStyle(button);
            }

            var textBox = control as TextBox;
            if (textBox != null)
            {
                textBox.Font = DefaultFont;
                textBox.BackColor = SurfaceAltColor;
                textBox.ForeColor = TextColor;
                textBox.BorderStyle = BorderStyle.FixedSingle;
            }

            var comboBox = control as ComboBox;
            if (comboBox != null)
            {
                comboBox.Font = DefaultFont;
                comboBox.BackColor = SurfaceAltColor;
                comboBox.ForeColor = TextColor;
                comboBox.FlatStyle = FlatStyle.Flat;
            }

            var date = control as DateTimePicker;
            if (date != null)
            {
                date.Font = DefaultFont;
                date.BackColor = SurfaceAltColor;
                date.ForeColor = TextColor;
                date.CalendarMonthBackground = SurfaceAltColor;
                date.CalendarForeColor = TextColor;
                date.CalendarTitleBackColor = SurfaceColor;
                date.CalendarTitleForeColor = TextColor;
            }

            var numeric = control as NumericUpDown;
            if (numeric != null)
            {
                numeric.Font = DefaultFont;
                numeric.BackColor = SurfaceAltColor;
                numeric.ForeColor = TextColor;
                numeric.BorderStyle = BorderStyle.FixedSingle;
            }

            var checkBox = control as CheckBox;
            if (checkBox != null)
            {
                checkBox.ForeColor = TextColor;
            }

            var grid = control as DataGridView;
            if (grid != null)
            {
                ApplyGridStyle(grid);
            }
        }

        private static void ApplyGridStyle(DataGridView grid)
        {
            grid.BackgroundColor = AppBackgroundColor;
            grid.GridColor = BorderColor;
            grid.ColumnHeadersDefaultCellStyle.BackColor = SurfaceAltColor;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = TextColor;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font(DefaultFont, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = SurfaceAltColor;
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = TextColor;
            grid.DefaultCellStyle.BackColor = SurfaceColor;
            grid.DefaultCellStyle.ForeColor = TextColor;
            grid.DefaultCellStyle.SelectionBackColor = AccentSoftColor;
            grid.DefaultCellStyle.SelectionForeColor = TextColor;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(41, 40, 84);
        }

        private static IEnumerable<Control> EnumerateControls(Control root)
        {
            yield return root;

            foreach (Control child in root.Controls)
            {
                foreach (var descendant in EnumerateControls(child))
                {
                    yield return descendant;
                }
            }
        }

        public static void EnableDoubleBuffering(Control control)
        {
            if (control == null)
            {
                return;
            }

            var property = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            if (property != null)
            {
                property.SetValue(control, true, null);
            }
        }
    }

    public abstract class ModuleFormBase : Form
    {
        protected ServiceFactory Services;
        protected NguoiDungDTO CurrentUser;
        private bool _runtimeLoaded;

        protected ModuleFormBase()
        {
        }

        protected ModuleFormBase(string title)
        {
            Text = title;
        }

        protected ModuleFormBase(ServiceFactory services, NguoiDungDTO currentUser, string title)
            : this(title)
        {
            SetRuntimeContext(services, currentUser);
        }

        protected void SetRuntimeContext(ServiceFactory services, NguoiDungDTO currentUser)
        {
            Services = services;
            CurrentUser = currentUser;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!IsInDesignMode)
            {
                UiHelpers.ApplyDarkTheme(this);
            }

            if (_runtimeLoaded || !CanUseServices)
            {
                return;
            }

            _runtimeLoaded = true;
            OnRuntimeLoad();
        }

        protected virtual void OnRuntimeLoad()
        {
        }

        protected bool CanUseServices
        {
            get { return Services != null && !IsInDesignMode; }
        }

        protected bool IsInDesignMode
        {
            get
            {
                return LicenseManager.UsageMode == LicenseUsageMode.Designtime
                       || DesignMode
                       || (Site != null && Site.DesignMode);
            }
        }

        protected void Info(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}