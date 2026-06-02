using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;
using DesktopApp_Project.GUI.Shared.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace DesktopApp_Project.GUI
{
    public static class AppTheme
    {
        private static readonly Color[] AccentPalette =
        {
            ColorTranslator.FromHtml("#F9B17A"),
            ColorTranslator.FromHtml("#4CAF50"),
            ColorTranslator.FromHtml("#29B6F6"),
            ColorTranslator.FromHtml("#FFB74D")
        };

        public static readonly string[] AccentNames =
        {
            "Tím",
            "Xanh ngọc",
            "Hổ phách",
            "Xanh dương"
        };

        static AppTheme()
        {
            DarkMode = true;
            AccentIndex = 0;
            Load();
        }

        public static bool DarkMode { get; private set; }
        public static int AccentIndex { get; private set; }
        public static string Language { get; private set; }

        public static Color BackgroundColor
        {
            get
            {
                return ThemeManager.Current.BackgroundDark;
            }
        }
        public static Color SurfaceColor
        {
            get
            {
                return ThemeManager.Current.PanelDark;
            }
        }
        public static Color SurfaceAltColor
        {
            get
            {
                return DarkMode
                    ? ColorTranslator.FromHtml("#424769")
                    : ColorTranslator.FromHtml("#F8FAFC");
            }
        }
        public static Color BorderColor
        {
            get
            {
                return ThemeManager.Current.BorderColor;
            }
        }
        public static Color TextColor
        {
            get
            {
                return ThemeManager.Current.PrimaryText;
            }
        }
        public static Color MutedTextColor
        {
            get
            {
                return ThemeManager.Current.SecondaryText;
            }
        }
        public static Color AccentColor
        {
            get
            {
                return ThemeManager.Current.Accent;
            }
        }
        public static Color AccentSoftColor
        {
            get
            {
                return DarkMode
                    ? ColorTranslator.FromHtml("#FFC28F")
                    : Color.FromArgb(230, 222, 247);
            }
        }
        public static Color SuccessColor
        {
            get { return ColorTranslator.FromHtml("#4CAF50"); }
        }
        public static Color WarningColor
        {
            get { return ColorTranslator.FromHtml("#FFB74D"); }
        }

        public static void Apply(bool darkMode, int accentIndex, string language)
        {
            DarkMode = darkMode;
            AccentIndex = Math.Max(0, Math.Min(accentIndex, AccentPalette.Length - 1));
            Language = string.IsNullOrWhiteSpace(language) ? "Vietnamese" : language;
            Save();
        }

        public static void Load()
        {
            Language = "Vietnamese";
            var path = SettingsPath;
            if (!File.Exists(path))
            {
                return;
            }

            foreach (var line in File.ReadAllLines(path))
            {
                var parts = line.Split(new[] { '=' }, 2);
                if (parts.Length != 2)
                {
                    continue;
                }

                var key = parts[0].Trim();
                var value = parts[1].Trim();
                if (key == "Theme")
                {
                    DarkMode = !string.Equals(value, "Light", StringComparison.OrdinalIgnoreCase);
                }
                else if (key == "Accent")
                {
                    int index;
                    if (int.TryParse(value, out index))
                    {
                        AccentIndex = Math.Max(0, Math.Min(index, AccentPalette.Length - 1));
                    }
                }
                else if (key == "Language")
                {
                    Language = value;
                }
            }
        }

        private static void Save()
        {
            var dir = Path.GetDirectoryName(SettingsPath);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            File.WriteAllLines(SettingsPath, new[]
            {
                "Theme=" + (DarkMode ? "Dark" : "Light"),
                "Accent=" + AccentIndex,
                "Language=" + Language
            });
        }

        private static string SettingsPath
        {
            get
            {
                return Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "QuanLyLopIELTS",
                    "settings.ini");
            }
        }
    }

    public static class UiHelpers
    {
        public static readonly Font DefaultFont = new Font("Segoe UI", 9F, FontStyle.Regular);
        public static readonly Font TitleFont = new Font("Segoe UI", 13F, FontStyle.Bold);
        public static Color AccentColor { get { return AppTheme.AccentColor; } }
        public static Color AccentSoftColor { get { return AppTheme.AccentSoftColor; } }
        public static Color AppBackgroundColor { get { return AppTheme.BackgroundColor; } }
        public static Color SurfaceColor { get { return AppTheme.SurfaceColor; } }
        public static Color SurfaceAltColor { get { return AppTheme.SurfaceAltColor; } }
        public static Color BorderColor { get { return AppTheme.BorderColor; } }
        public static Color TextColor { get { return AppTheme.TextColor; } }
        public static Color MutedTextColor { get { return AppTheme.MutedTextColor; } }
        public static Color SuccessColor { get { return AppTheme.SuccessColor; } }
        public static Color WarningColor { get { return AppTheme.WarningColor; } }

        public static Button Button(string text)
        {
            var button = new Button
            {
                Text = text,
                AutoSize = false,
                Height = 34,
                Width = 110,
                Font = DefaultFont,
                BackColor = ThemeManager.Current.Accent,
                ForeColor = ThemeManager.Current.PrimaryText,
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
            button.FlatAppearance.MouseDownBackColor = AccentColor;
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

        public static void WarnSelect(string itemName)
        {
            MessageBox.Show("Vui lòng chọn " + itemName + ".", "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public static bool ConfirmDelete(string itemName)
        {
            return MessageBox.Show("Bạn có chắc muốn xóa " + itemName + " này?", "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static void BindLopHoc(ComboBox combo, ServiceFactory services)
        {
            combo.BeginUpdate();
            combo.DataSource = null;
            combo.DisplayMember = "TenLop";
            combo.ValueMember = "MaLopHoc";
            combo.DataSource = services.LopHoc.LayDanhSach();
            combo.EndUpdate();
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
            grid.AlternatingRowsDefaultCellStyle.BackColor = SurfaceAltColor;
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

    public static class ManagedFileStorage
    {
        private const string AppFolderName = "QuanLyLopIELTS";
        private const string UploadsFolderName = "Uploads";

        public static string CopyToManagedFolder(string sourcePath, string category)
        {
            if (string.IsNullOrWhiteSpace(sourcePath))
            {
                return string.Empty;
            }

            if (!File.Exists(sourcePath))
            {
                return sourcePath;
            }

            var safeCategory = SanitizePathSegment(category);
            var targetFolder = Path.Combine(AppRoot, UploadsFolderName, safeCategory);
            Directory.CreateDirectory(targetFolder);

            var originalName = SanitizeFileName(Path.GetFileName(sourcePath));
            var storedName = Guid.NewGuid().ToString("N") + "_" + originalName;
            var targetPath = Path.Combine(targetFolder, storedName);
            File.Copy(sourcePath, targetPath, false);

            return UploadsFolderName + "/" + safeCategory + "/" + storedName;
        }

        public static string ResolvePath(string storedPath)
        {
            if (string.IsNullOrWhiteSpace(storedPath))
            {
                return storedPath;
            }

            if (Path.IsPathRooted(storedPath))
            {
                return storedPath;
            }

            var normalized = storedPath.Replace('/', Path.DirectorySeparatorChar).Replace('\\', Path.DirectorySeparatorChar);
            return Path.Combine(AppRoot, normalized);
        }

        private static string AppRoot
        {
            get
            {
                return Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    AppFolderName);
            }
        }

        private static string SanitizePathSegment(string value)
        {
            value = string.IsNullOrWhiteSpace(value) ? "General" : value.Trim();
            foreach (var invalid in Path.GetInvalidFileNameChars())
            {
                value = value.Replace(invalid, '_');
            }

            return value;
        }

        private static string SanitizeFileName(string value)
        {
            value = string.IsNullOrWhiteSpace(value) ? "upload" : value.Trim();
            foreach (var invalid in Path.GetInvalidFileNameChars())
            {
                value = value.Replace(invalid, '_');
            }

            return value;
        }
    }

    public class ModuleFormBase : Form
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
                //UiHelpers.ApplyDarkTheme(this);
                Shared.Themes.ThemeManager.ApplyTheme(this);
            }

            if (_runtimeLoaded || !CanUseServices)
            {
                return;
            }

            _runtimeLoaded = true;
            SafeRun(OnRuntimeLoad);
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

        protected bool SafeRun(Action action)
        {
            try
            {
                if (action != null)
                {
                    action();
                }

                return true;
            }
            catch (Exception ex)
            {
                ShowRuntimeError(ex);
                return false;
            }
        }

        protected T SafeLoad<T>(Func<T> action, T fallback)
        {
            try
            {
                return action == null ? fallback : action();
            }
            catch (Exception ex)
            {
                ShowRuntimeError(ex);
                return fallback;
            }
        }

        protected bool HasCurrentUser()
        {
            if (CurrentUser != null)
            {
                return true;
            }

            Info("Không có thông tin người dùng hiện tại. Vui lòng đăng nhập lại.");
            return false;
        }

        protected void WireClick(Control control, EventHandler handler)
        {
            if (control == null || handler == null)
            {
                return;
            }

            control.Click -= handler;
            control.Click += (sender, e) => SafeRun(() => handler(sender, e));
        }

        protected void WireSelectedIndexChanged(ComboBox combo, EventHandler handler)
        {
            if (combo == null || handler == null)
            {
                return;
            }

            combo.SelectedIndexChanged -= handler;
            combo.SelectedIndexChanged += (sender, e) => SafeRun(() => handler(sender, e));
        }

        protected void WireSelectionChanged(DataGridView grid, EventHandler handler)
        {
            if (grid == null || handler == null)
            {
                return;
            }

            grid.SelectionChanged -= handler;
            grid.SelectionChanged += (sender, e) => SafeRun(() => handler(sender, e));
        }

        protected void WireCellClick(DataGridView grid, DataGridViewCellEventHandler handler)
        {
            if (grid == null || handler == null)
            {
                return;
            }

            grid.CellClick -= handler;
            grid.CellClick += (sender, e) => SafeRun(() => handler(sender, e));
        }

        protected void Info(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowRuntimeError(Exception ex)
        {
            var message = ex == null ? "Lỗi không xác định." : ex.Message;
            MessageBox.Show("Không thể xử lý yêu cầu. Chi tiết: " + message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }
}
