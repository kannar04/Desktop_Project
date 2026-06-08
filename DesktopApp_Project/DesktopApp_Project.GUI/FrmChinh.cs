using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;
using DesktopApp_Project.GUI.Shared.Themes;
using FontAwesome.Sharp;

namespace DesktopApp_Project.GUI
{
    public partial class FrmChinh : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        private const int WM_NCHITTEST = 0x0084;
        private const int ResizeAreaSize = 10;

        private const int HTCLIENT = 1;
        private const int HTCAPTION = 2;
        private const int HTLEFT = 10;
        private const int HTRIGHT = 11;
        private const int HTTOP = 12;
        private const int HTTOPLEFT = 13;
        private const int HTTOPRIGHT = 14;
        private const int HTBOTTOM = 15;
        private const int HTBOTTOMLEFT = 16;
        private const int HTBOTTOMRIGHT = 17;

        private ServiceFactory _services;
        private NguoiDungDTO _currentUser;
        private bool _runtimeLoaded;
        private bool _allowClose;
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        private class RGBColors
        {
            public static Color color1 { get { return ThemeManager.Current.Accent; } }
            public static Color color2 { get { return ThemeManager.Current.Success; } }
            public static Color color3 { get { return ThemeManager.Current.Warning; } }
            public static Color color4 { get { return ThemeManager.Current.Accent; } }
            public static Color color5 { get { return ThemeManager.Current.Success; } }
            public static Color color6 { get { return ThemeManager.Current.Warning; } }
        }

        public FrmChinh()
        {
            InitializeComponent();
            ConfigureShell();
        }

        public FrmChinh(ServiceFactory services, NguoiDungDTO currentUser)
            : this()
        {
            _services = services;
            _currentUser = currentUser;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (_runtimeLoaded)
            {
                return;
            }

            _runtimeLoaded = true;
            if (_services == null || _currentUser == null)
            {
                ActivateButton(btnChinh, RGBColors.color1);
                ShowHome();
                return;
            }

            Text = "Quản lý lớp IELTS - Xin chào " + _currentUser.HoTen + " (" + AppConstants.GetDisplayRole(_currentUser.VaiTro) + ")";
            ActivateButton(btnChinh, RGBColors.color1);
            ShowHome();
        }

        private void ConfigureShell()
        {
            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            MaximizedBounds = Screen.FromHandle(Handle).WorkingArea;
            MinimumSize = new Size(1366, 900);
            ControlBox = false;
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            DisableChamBaiNavigation();
            ThemeManager.ThemeChanged -= ThemeManager_ThemeChanged;
            ThemeManager.ThemeChanged += ThemeManager_ThemeChanged;
            ApplyShellTheme();

            UiHelpers.EnableDoubleBuffering(this);
            UiHelpers.EnableDoubleBuffering(pnlSideMenu);
            UiHelpers.EnableDoubleBuffering(pnlMenuItems);
            UiHelpers.EnableDoubleBuffering(pnlDesktop);
            UiHelpers.EnableDoubleBuffering(pnlTittleBar);
            UiHelpers.EnableDoubleBuffering(pnlMovingForm);

            leftBorderBtn = new Panel
            {
                Size = new Size(7, 60)
            };
            leftBorderBtn.Visible = false;
            pnlMenuItems.Controls.Add(leftBorderBtn);
        }

        private void ApplyShellTheme()
        {
            var theme = ThemeManager.Current;

            BackColor = theme.BackgroundDark;
            pnlSideMenu.BackColor = theme.PanelDark;
            pnlMenuItems.BackColor = theme.PanelDark;
            pnlDesktop.BackColor = theme.BackgroundDark;
            pnlTittleBar.BackColor = theme.PanelDark;
            pnlMovingForm.BackColor = theme.PanelDark;
            pnlLogo.BackColor = theme.PanelDark;
            lblLogo.ForeColor = theme.Accent;
            lblTitleChildForm.ForeColor = currentBtn == null ? theme.PrimaryText : theme.Accent;
            icoTittle.BackColor = theme.PanelDark;
            icoTittle.IconColor = currentBtn == null ? theme.PrimaryText : theme.Accent;
            StyleShellWindowButton(btnMinimize);
            StyleShellWindowButton(btnMaximize);
            StyleShellWindowButton(btnClose);
            ApplySidebarTheme();
        }

        private void ApplySidebarTheme()
        {
            var buttons = new[]
            {
                btnChinh,
                btnBaiTap,
                btnBaoCao,
                btnChamBai,
                btnDeThi,
                btnDiemDanh,
                btnDiemSo,
                btnHocPhi,
                btnHocVien,
                btnLopHoc,
                btnTaiLieu,
                btnTuVung,
                btnFlashcard,
                btnThongBao,
                btnSetting
            };

            foreach (var button in buttons)
            {
                if (button != null)
                {
                    StyleMenuButton(button, button == currentBtn);
                }
            }
        }

        private void DisableChamBaiNavigation()
        {
            // Cham Bai module disabled by request. Keep form source for future restoration.
            if (btnChamBai != null)
            {
                btnChamBai.Visible = false;
                btnChamBai.Enabled = false;
            }
        }

        private void StyleMenuButton(IconButton button, bool active)
        {
            var theme = ThemeManager.Current;

            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.UseVisualStyleBackColor = false;
            button.Font = theme.BodyFont;
            button.Cursor = Cursors.Hand;
            button.BackColor = active ? theme.Accent : Color.Transparent;
            button.ForeColor = active ? theme.ButtonText : theme.PrimaryText;
            button.IconColor = active ? theme.ButtonText : theme.Accent;
            button.FlatAppearance.MouseOverBackColor = active ? theme.Accent : theme.ControlBackground;
            button.FlatAppearance.MouseDownBackColor = active ? theme.AccentPressed : theme.ControlBackground;

            button.MouseEnter -= SidebarButton_MouseEnter;
            button.MouseLeave -= SidebarButton_MouseLeave;
            button.MouseEnter += SidebarButton_MouseEnter;
            button.MouseLeave += SidebarButton_MouseLeave;
        }

        private void SidebarButton_MouseEnter(object sender, EventArgs e)
        {
            var button = sender as IconButton;
            if (button == null || button == currentBtn)
            {
                return;
            }

            button.BackColor = ThemeManager.Current.ControlBackground;
            button.ForeColor = ThemeManager.Current.PrimaryText;
            button.IconColor = ThemeManager.Current.Accent;
        }

        private void SidebarButton_MouseLeave(object sender, EventArgs e)
        {
            var button = sender as IconButton;
            if (button == null || button == currentBtn)
            {
                return;
            }

            button.BackColor = Color.Transparent;
            button.ForeColor = ThemeManager.Current.PrimaryText;
            button.IconColor = ThemeManager.Current.Accent;
        }

        private void StyleShellWindowButton(Button button)
        {
            button.BackColor = Color.Transparent;
            button.ForeColor = ThemeManager.Current.PrimaryText;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.UseVisualStyleBackColor = false;
        }

        private void ThemeManager_ThemeChanged(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            ApplyShellTheme();
            if (currentChildForm != null)
            {
                ThemeManager.ApplyTheme(currentChildForm);
            }
            pnlDesktop.Invalidate(true);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ThemeManager.ThemeChanged -= ThemeManager_ThemeChanged;
            base.OnFormClosed(e);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlMovingForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0x112, 0xf012, 0);
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)
            {
                var screenPoint = new Point(m.LParam.ToInt32());
                var clientPoint = PointToClient(screenPoint);

                if (clientPoint.Y <= ResizeAreaSize)
                {
                    if (clientPoint.X <= ResizeAreaSize)
                    {
                        m.Result = (IntPtr)HTTOPLEFT;
                    }
                    else if (clientPoint.X < Size.Width - ResizeAreaSize)
                    {
                        m.Result = (IntPtr)HTTOP;
                    }
                    else
                    {
                        m.Result = (IntPtr)HTTOPRIGHT;
                    }
                }
                else if (clientPoint.Y <= Size.Height - ResizeAreaSize)
                {
                    if (clientPoint.X <= ResizeAreaSize)
                    {
                        m.Result = (IntPtr)HTLEFT;
                    }
                    else if (clientPoint.X > Width - ResizeAreaSize)
                    {
                        m.Result = (IntPtr)HTRIGHT;
                    }
                    else if (clientPoint.Y <= 40)
                    {
                        m.Result = (IntPtr)HTCAPTION;
                    }
                }
                else
                {
                    if (clientPoint.X <= ResizeAreaSize)
                    {
                        m.Result = (IntPtr)HTBOTTOMLEFT;
                    }
                    else if (clientPoint.X < Size.Width - ResizeAreaSize)
                    {
                        m.Result = (IntPtr)HTBOTTOM;
                    }
                    else
                    {
                        m.Result = (IntPtr)HTBOTTOMRIGHT;
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!ConfirmExit())
            {
                return;
            }

            _allowClose = true;
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                btnMaximize.Text = "❐";
            }
            else
            {
                WindowState = FormWindowState.Normal;
                btnMaximize.Text = "◻";
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn == null)
            {
                return;
            }

            DisableButton();
            currentBtn = (IconButton)senderBtn;
            currentBtn.BackColor = ThemeManager.Current.Accent;
            currentBtn.ForeColor = ThemeManager.Current.ButtonText;
            currentBtn.TextAlign = ContentAlignment.MiddleCenter;
            currentBtn.IconColor = ThemeManager.Current.ButtonText;
            currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
            currentBtn.ImageAlign = ContentAlignment.MiddleRight;

            leftBorderBtn.BackColor = ThemeManager.Current.Accent;
            leftBorderBtn.Height = currentBtn.Height;
            leftBorderBtn.Location = new Point(0, currentBtn.Top);
            leftBorderBtn.Visible = true;
            leftBorderBtn.BringToFront();

            lblTitleChildForm.Text = currentBtn.Text;
            lblTitleChildForm.ForeColor = ThemeManager.Current.Accent;
            icoTittle.IconChar = currentBtn.IconChar;
            icoTittle.IconColor = ThemeManager.Current.Accent;
        }

        private void DisableButton()
        {
            if (currentBtn == null)
            {
                return;
            }

            currentBtn.BackColor = Color.Transparent;
            currentBtn.ForeColor = ThemeManager.Current.PrimaryText;
            currentBtn.TextAlign = ContentAlignment.MiddleLeft;
            currentBtn.IconColor = ThemeManager.Current.Accent;
            currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            leftBorderBtn.Visible = false;
        }

        private void ClearDesktop()
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                currentChildForm = null;
            }

            foreach (Control control in pnlDesktop.Controls)
            {
                control.Dispose();
            }
            pnlDesktop.Controls.Clear();
        }

        private void ShowHome()
        {
            if (pnlDesktop != null)
            {
                ShowDashboard();
                return;
            }

            ClearDesktop();

            var container = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ThemeManager.Current.BackgroundDark,
                Padding = new Padding(16)
            };

            var header = new Label
            {
                Text = "Trang chủ",
                Dock = DockStyle.Top,
                Height = 56,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = ThemeManager.Current.PrimaryText,
                BackColor = ThemeManager.Current.PanelDark,
                Padding = new Padding(16, 0, 0, 0),
                TextAlign = ContentAlignment.MiddleLeft
            };

            var greetingText = _currentUser == null
                ? "Chọn chức năng từ menu bên trái để bắt đầu."
                : "Xin chào " + _currentUser.HoTen + ", chọn chức năng từ menu bên trái để bắt đầu.";

            var subtitle = new Label
            {
                Text = greetingText,
                Dock = DockStyle.Top,
                AutoSize = true,
                Height = 40,
                Font = new Font("Segoe UI", 11F, FontStyle.Regular),
                ForeColor = ThemeManager.Current.SecondaryText,
                Padding = new Padding(18, 12, 0, 0)
            };

            container.Controls.Add(subtitle);
            container.Controls.Add(header);
            pnlDesktop.Controls.Add(container);
            ThemeManager.ApplyTheme(container);
        }

        private void ShowDashboard()
        {
            ClearDesktop();
            ApplyShellTheme();

            var container = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ThemeManager.Current.BackgroundDark,
                Padding = new Padding(18)
            };

            var title = new Label
            {
                Text = "Xin chào Admin",
                Dock = DockStyle.Top,
                AutoSize = true,
                Height = 44,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = ThemeManager.Current.PrimaryText,
                BackColor = ThemeManager.Current.BackgroundDark,
                Padding = new Padding(10, 0, 0, 0),
                TextAlign = ContentAlignment.MiddleLeft
            };

            var subtitle = new Label
            {
                Text = "Xin chào, Admin !!!",
                Dock = DockStyle.Top,
                AutoSize = true,
                Height = 34,
                Font = new Font("Segoe UI", 10F),
                ForeColor = ThemeManager.Current.SecondaryText,
                BackColor = ThemeManager.Current.BackgroundDark,
                Padding = new Padding(12, 0, 0, 8),
                TextAlign = ContentAlignment.MiddleLeft
            };

            var summaryResult = _services == null ? null : _services.Dashboard.LayTongQuan();
            var revenueResult = _services == null ? null : _services.Dashboard.LayDoanhThuThang(6);
            var scheduleResult = _services == null ? null : _services.Dashboard.LayLichHocTuan();
            var summary = summaryResult != null && summaryResult.Success ? summaryResult.Data : new DashboardSummaryDTO();
            var revenue = revenueResult != null && revenueResult.Success ? revenueResult.Data : new List<MonthlyRevenueDTO>();
            var schedule = scheduleResult != null && scheduleResult.Success ? scheduleResult.Data : new List<WeeklyScheduleDTO>();

            var body = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 2,
                BackColor = ThemeManager.Current.BackgroundDark,
                Padding = new Padding(0, 12, 0, 0)
            };
            body.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            body.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            body.RowStyles.Add(new RowStyle(SizeType.Absolute, 130F));
            body.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            var cards = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 1,
                BackColor = ThemeManager.Current.BackgroundDark,
                Margin = new Padding(0, 0, 0, 12)
            };
            for (var i = 0; i < 4; i++)
            {
                cards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            }

            cards.Controls.Add(CreateMetricCard("Tổng học viên", summary.TongHocVien.ToString("N0"), ThemeManager.Current.Accent), 0, 0);
            cards.Controls.Add(CreateMetricCard("Đang học", summary.HocVienDangHoc.ToString("N0"), ThemeManager.Current.Success), 1, 0);
            cards.Controls.Add(CreateMetricCard("Doanh thu tháng", FormatMoney(summary.DoanhThuThangNay), ThemeManager.Current.Warning), 2, 0);
            cards.Controls.Add(CreateMetricCard("Lớp học", summary.TongLopHoc.ToString("N0"), ThemeManager.Current.Accent), 3, 0);

            body.Controls.Add(cards, 0, 0);
            body.SetColumnSpan(cards, 2);
            body.Controls.Add(CreateRevenueChart(revenue), 0, 1);
            body.Controls.Add(CreateScheduleGrid(schedule), 1, 1);

            container.Controls.Add(body);
            container.Controls.Add(title);
            pnlDesktop.Controls.Add(container);
            ThemeManager.ApplyTheme(container);
            ApplyShellTheme();
        }

        private Control CreateMetricCard(string label, string value, Color accent)
        {
            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ThemeManager.Current.PanelDark,
                Padding = new Padding(14),
                Margin = new Padding(6)
            };
            panel.Paint += MetricCard_Paint;
            panel.Controls.Add(new Label
            {
                Text = value,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = accent,
                TextAlign = ContentAlignment.MiddleLeft
            });
            panel.Controls.Add(new Label
            {
                Text = label,
                Dock = DockStyle.Top,
                Height = 28,
                Font = new Font("Segoe UI", 9F),
                ForeColor = ThemeManager.Current.SecondaryText,
                TextAlign = ContentAlignment.MiddleLeft
            });
            return panel;
        }

        private void MetricCard_Paint(object sender, PaintEventArgs e)
        {
            var panel = sender as Panel;
            if (panel == null)
            {
                return;
            }

            using (var pen = new Pen(ThemeManager.Current.BorderColor))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
            }
        }

        private Control CreateRevenueChart(List<MonthlyRevenueDTO> rows)
        {
            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ThemeManager.Current.BackgroundDark,
                Padding = new Padding(18),
                Margin = new Padding(6)
            };
            panel.Paint += (sender, e) => PaintRevenueChart((Panel)sender, e.Graphics, rows);
            return panel;
        }

        private void PaintRevenueChart(Panel panel, Graphics graphics, List<MonthlyRevenueDTO> rows)
        {
            graphics.Clear(ThemeManager.Current.BackgroundDark);
            using (var titleBrush = new SolidBrush(ThemeManager.Current.PrimaryText))
            using (var mutedBrush = new SolidBrush(ThemeManager.Current.SecondaryText))
            using (var barBrush = new SolidBrush(ThemeManager.Current.Accent))
            using (var linePen = new Pen(ThemeManager.Current.BorderColor))
            {
                graphics.DrawString("Doanh thu 6 tháng", new Font("Segoe UI", 12F, FontStyle.Bold), titleBrush, 18, 16);
                var area = new Rectangle(24, 58, Math.Max(10, panel.Width - 56), Math.Max(10, panel.Height - 98));
                graphics.DrawLine(linePen, area.Left, area.Bottom, area.Right, area.Bottom);
                if (rows == null || rows.Count == 0)
                {
                    graphics.DrawString("Chưa có dữ liệu", UiHelpers.DefaultFont, mutedBrush, area.Left, area.Top + 20);
                    return;
                }

                var max = Math.Max(1m, rows.Max(x => x.TongTien));
                var barWidth = Math.Max(16, area.Width / rows.Count - 18);
                for (var i = 0; i < rows.Count; i++)
                {
                    var height = (int)(area.Height * (rows[i].TongTien / max));
                    var x = area.Left + i * (area.Width / rows.Count) + 8;
                    var y = area.Bottom - height;
                    graphics.FillRectangle(barBrush, x, y, barWidth, height);
                    graphics.DrawString(rows[i].Nhan, UiHelpers.DefaultFont, mutedBrush, x - 4, area.Bottom + 6);
                }
            }
        }

        private Control CreateScheduleGrid(List<WeeklyScheduleDTO> rows)
        {
            var grid = UiHelpers.Grid();
            grid.Margin = new Padding(6);
            grid.ReadOnly = true;
            grid.DataSource = rows.Select(x => new
            {
                Ngày = x.NgayHoc.ToString("dd/MM/yyyy"),
                Thứ = x.ThuTrongTuan,
                Lớp = x.TenLop,
                Lịch = x.LichHoc
            }).ToList();
            return grid;
        }

        private static string FormatMoney(decimal value)
        {
            return value.ToString("N0") + " đ";
        }

        private void OpenModule(Form childForm)
        {
            if (_services == null || _currentUser == null)
            {
                return;
            }

            ClearDesktop();

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlDesktop.Controls.Add(childForm);
            pnlDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnChinh_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            ShowHome();
        }

        private void btnBaiTap_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenModule(new FrmBaiTap(_services, _currentUser));
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenModule(new FrmBaoCao(_services, _currentUser));
        }

        private void btnChamBai_Click(object sender, EventArgs e)
        {
            // Cham Bai module disabled by request. Keep handler as no-op for designer compatibility.
        }

        private void btnDeThi_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            OpenModule(new FrmDeThi(_services, _currentUser));
        }

        private void btnDiemDanh_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenModule(new FrmDiemDanh(_services, _currentUser));
        }

        private void btnDiemSo_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenModule(new FrmDiemSo(_services, _currentUser));
        }

        private void btnHocPhi_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenModule(new FrmHocPhi(_services, _currentUser));
        }

        private void btnHocVien_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenModule(new FrmHocVien(_services, _currentUser));
        }

        private void btnLopHoc_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenModule(new FrmLopHoc(_services, _currentUser));
        }

        private void btnTaiLieu_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            OpenModule(new FrmTaiLieu(_services, _currentUser));
        }

        private void btnTuVung_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            OpenModule(new FrmTuVung(_services, _currentUser));
        }

        private void btnFlashcard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            OpenModule(new FrmFlashcard(_services, _currentUser));
        }

        private void btnThongBao_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenModule(new FrmThongBao(_services, _currentUser));
        }

        private void lblLogo_Click(object sender, EventArgs e)
        {
            ActivateButton(btnChinh, RGBColors.color1);
            ShowHome();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, ThemeManager.Current.Accent);
            ShowSettings();
        }

        private void ShowSettings()
        {
            ClearDesktop();

            var panel = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 2,
                BackColor = ThemeManager.Current.PanelDark,
                Padding = new Padding(24),
                Margin = new Padding(24)
            };
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 260F));

            var cboTheme = UiHelpers.ComboBox();
            cboTheme.Items.AddRange(new object[] { "Dark", "Light" });
            cboTheme.SelectedIndex = AppTheme.DarkMode ? 0 : 1;

            var cboAccent = UiHelpers.ComboBox();
            cboAccent.Items.AddRange(AppTheme.AccentNames.Cast<object>().ToArray());
            cboAccent.SelectedIndex = cboAccent.Items.Count == 0 ? -1 : Math.Max(0, Math.Min(AppTheme.AccentIndex, cboAccent.Items.Count - 1));

            var cboLanguage = UiHelpers.ComboBox();
            cboLanguage.Items.AddRange(new object[] { "Vietnamese", "English" });
            cboLanguage.SelectedIndex = string.Equals(AppTheme.Language, "English", StringComparison.OrdinalIgnoreCase) ? 1 : 0;

            var btnSave = UiHelpers.Button("Lưu");
            btnSave.Click += (s, e) =>
            {
                var oldLanguage = AppTheme.Language;
                AppTheme.Apply(Convert.ToString(cboTheme.SelectedItem) == "Dark", Math.Max(0, cboAccent.SelectedIndex), Convert.ToString(cboLanguage.SelectedItem));
                ThemeManager.SetTheme("AppTheme");
                ThemeManager.ApplyTheme(this);
                ApplyShellTheme();
                MessageBox.Show(oldLanguage == AppTheme.Language ? "Đã lưu cài đặt." : "Đã lưu cài đặt. Vui lòng khởi động lại để áp dụng ngôn ngữ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowSettings();
            };

            panel.Controls.Add(UiHelpers.Label("Theme"), 0, 0);
            panel.Controls.Add(cboTheme, 1, 0);
            panel.Controls.Add(UiHelpers.Label("Accent"), 0, 1);
            panel.Controls.Add(cboAccent, 1, 1);
            panel.Controls.Add(UiHelpers.Label("Language"), 0, 2);
            panel.Controls.Add(cboLanguage, 1, 2);
            panel.Controls.Add(btnSave, 1, 3);

            var container = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ThemeManager.Current.BackgroundDark,
                Padding = new Padding(18)
            };
            container.Controls.Add(panel);
            pnlDesktop.Controls.Add(container);
            ThemeManager.ApplyTheme(container);
            ApplyShellTheme();

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!_allowClose && e.CloseReason == CloseReason.UserClosing && !ConfirmExit())
            {
                e.Cancel = true;
                return;
            }

            base.OnFormClosing(e);
        }

        private bool ConfirmExit()
        {
            return MessageBox.Show(
                "Bạn có muốn tắt ứng dụng?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}
