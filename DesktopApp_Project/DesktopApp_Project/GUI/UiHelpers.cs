using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
        public static readonly Color AccentColor = Color.FromArgb(37, 99, 235);
        public static readonly Color AccentSoftColor = Color.FromArgb(219, 234, 254);
        public static readonly Color AppBackgroundColor = Color.FromArgb(246, 248, 251);
        public static readonly Color SurfaceColor = Color.White;
        public static readonly Color BorderColor = Color.FromArgb(213, 220, 230);
        public static readonly Color TextColor = Color.FromArgb(31, 41, 55);
        public static readonly Color MutedTextColor = Color.FromArgb(100, 116, 139);

        public static Button Button(string text)
        {
            var button = new Button
            {
                Text = text,
                AutoSize = false,
                Height = 34,
                Width = 110,
                Font = DefaultFont,
                BackColor = Color.FromArgb(235, 242, 252),
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
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(191, 219, 254);
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
                BackColor = SurfaceColor,
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
                BackColor = SurfaceColor,
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
                BackgroundColor = Color.White,
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
            foreach (Control control in EnumerateControls(root))
            {
                control.Font = DefaultFont;

                var button = control as Button;
                if (button != null)
                {
                    ApplyButtonStyle(button);
                }

                if (control is TableLayoutPanel || control is FlowLayoutPanel)
                {
                    control.BackColor = SurfaceColor;
                }

                var grid = control as DataGridView;
                if (grid != null)
                {
                    ApplyGridStyle(grid);
                }

                var date = control as DateTimePicker;
                if (date != null)
                {
                    date.Font = DefaultFont;
                }

                var numeric = control as NumericUpDown;
                if (numeric != null)
                {
                    numeric.Font = DefaultFont;
                    numeric.BorderStyle = BorderStyle.FixedSingle;
                }

                var textBox = control as TextBox;
                if (textBox != null)
                {
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                }
            }
        }

        private static void ApplyGridStyle(DataGridView grid)
        {
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(238, 242, 247);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = TextColor;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font(DefaultFont, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(238, 242, 247);
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = TextColor;
            grid.DefaultCellStyle.BackColor = SurfaceColor;
            grid.DefaultCellStyle.ForeColor = TextColor;
            grid.DefaultCellStyle.SelectionBackColor = AccentSoftColor;
            grid.DefaultCellStyle.SelectionForeColor = TextColor;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
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
    }

    public abstract class ModuleFormBase : Form
    {
        protected readonly ServiceFactory Services;
        protected readonly NguoiDungDTO CurrentUser;
        private readonly TableLayoutPanel _shell;
        private readonly Label _title;
        private readonly Panel _contentHost;

        protected ModuleFormBase()
            : this("Thiết kế")
        {
        }

        protected ModuleFormBase(string title)
            : this(null, CreateDesignerUser(), title)
        {
        }

        protected ModuleFormBase(ServiceFactory services, NguoiDungDTO currentUser, string title)
        {
            Services = services;
            CurrentUser = currentUser;
            var designSurface = services == null || LicenseManager.UsageMode == LicenseUsageMode.Designtime;
            Font = UiHelpers.DefaultFont;
            Text = title;
            Dock = designSurface ? DockStyle.None : DockStyle.Fill;
            TopLevel = designSurface;
            FormBorderStyle = designSurface ? FormBorderStyle.Sizable : FormBorderStyle.None;
            BackColor = UiHelpers.AppBackgroundColor;

            _shell = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                BackColor = UiHelpers.AppBackgroundColor
            };
            _shell.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _shell.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            _shell.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            _title = new Label
            {
                Text = title,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = UiHelpers.TitleFont,
                Padding = new Padding(12, 0, 0, 0),
                Margin = Padding.Empty,
                AutoEllipsis = true,
                ForeColor = UiHelpers.TextColor,
                BackColor = Color.FromArgb(248, 250, 252)
            };

            _contentHost = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = UiHelpers.AppBackgroundColor,
                Margin = Padding.Empty,
                Padding = new Padding(10)
            };

            _shell.Controls.Add(_title, 0, 0);
            _shell.Controls.Add(_contentHost, 0, 1);
            Controls.Add(_shell);
        }

        protected void AddContent(Control control)
        {
            control.Dock = DockStyle.Fill;
            control.MinimumSize = new Size(
                0,
                Math.Max(control.MinimumSize.Height, 560));
            NormalizeScrollableLayout(control);
            UiHelpers.ApplyPolish(control);

            _contentHost.AutoScrollMinSize = control.MinimumSize;
            _contentHost.Controls.Clear();
            _contentHost.Controls.Add(control);
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

        private static void NormalizeScrollableLayout(Control control)
        {
            var flow = control as FlowLayoutPanel;
            if (flow != null)
            {
                flow.WrapContents = true;
                flow.AutoSize = true;
                flow.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                AttachFlowPanelWidth(flow);
            }

            foreach (Control child in control.Controls)
            {
                NormalizeScrollableLayout(child);
            }
        }

        private static void AttachFlowPanelWidth(FlowLayoutPanel flow)
        {
            EventHandler updateWidth = delegate { ConstrainFlowPanelWidth(flow); };

            flow.ParentChanged += delegate
            {
                if (flow.Parent != null)
                {
                    flow.Parent.SizeChanged += updateWidth;
                    ConstrainFlowPanelWidth(flow);
                }
            };

            if (flow.Parent != null)
            {
                flow.Parent.SizeChanged += updateWidth;
                ConstrainFlowPanelWidth(flow);
            }
        }

        private static void ConstrainFlowPanelWidth(FlowLayoutPanel flow)
        {
            if (flow.Parent == null)
            {
                return;
            }

            var width = Math.Max(160, flow.Parent.ClientSize.Width - flow.Margin.Horizontal);
            flow.MaximumSize = new Size(width, 0);
        }

        private static NguoiDungDTO CreateDesignerUser()
        {
            return new NguoiDungDTO
            {
                MaNguoiDung = 0,
                HoTen = "Thiết kế",
                VaiTro = AppConstants.RoleAdmin
            };
        }
    }
}
