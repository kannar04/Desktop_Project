using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;
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
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        private class RGBColors
        {
            public static readonly Color color1 = Color.FromArgb(172, 126, 241);
            public static readonly Color color2 = Color.FromArgb(249, 118, 176);
            public static readonly Color color3 = Color.FromArgb(253, 138, 114);
            public static readonly Color color4 = Color.FromArgb(95, 77, 221);
            public static readonly Color color5 = Color.FromArgb(249, 88, 155);
            public static readonly Color color6 = Color.FromArgb(24, 161, 251);
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
            currentBtn.BackColor = Color.FromArgb(37, 36, 81);
            currentBtn.ForeColor = color;
            currentBtn.TextAlign = ContentAlignment.MiddleCenter;
            currentBtn.IconColor = color;
            currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
            currentBtn.ImageAlign = ContentAlignment.MiddleRight;

            leftBorderBtn.BackColor = color;
            leftBorderBtn.Height = currentBtn.Height;
            leftBorderBtn.Location = new Point(0, currentBtn.Top);
            leftBorderBtn.Visible = true;
            leftBorderBtn.BringToFront();

            lblTitleChildForm.Text = currentBtn.Text;
            lblTitleChildForm.ForeColor = color;
            icoTittle.IconChar = currentBtn.IconChar;
            icoTittle.IconColor = color;
        }

        private void DisableButton()
        {
            if (currentBtn == null)
            {
                return;
            }

            currentBtn.BackColor = Color.FromArgb(31, 30, 68);
            currentBtn.ForeColor = Color.Gainsboro;
            currentBtn.TextAlign = ContentAlignment.MiddleLeft;
            currentBtn.IconColor = Color.Gainsboro;
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
            ClearDesktop();

            var container = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = UiHelpers.AppBackgroundColor,
                Padding = new Padding(16)
            };

            var header = new Label
            {
                Text = "Trang chủ",
                Dock = DockStyle.Top,
                Height = 56,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = UiHelpers.TextColor,
                BackColor = UiHelpers.SurfaceAltColor,
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
                AutoSize = false,
                Height = 40,
                Font = new Font("Segoe UI", 11F, FontStyle.Regular),
                ForeColor = UiHelpers.MutedTextColor,
                Padding = new Padding(18, 12, 0, 0)
            };

            container.Controls.Add(subtitle);
            container.Controls.Add(header);
            pnlDesktop.Controls.Add(container);
            UiHelpers.ApplyDarkTheme(container);
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
            ActivateButton(sender, RGBColors.color4);
            OpenModule(new FrmChamBai(_services, _currentUser));
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
        }
    }
}
