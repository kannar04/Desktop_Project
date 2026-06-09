// Biểu mẫu quản lý màn hình đăng nhập
// Chức năng:
// - Hiển thị và nhập dữ liệu màn hình đăng nhập
// - Gọi tầng nghiệp vụ để tải, lưu hoặc xóa dữ liệu
// - Cập nhật trạng thái giao diện sau thao tác của người dùng

using DesktopApp_Project.BUS;
using DesktopApp_Project.GUI.Shared.Themes;
using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DesktopApp_Project.GUI
{
    // Lớp biểu mẫu Windows Forms chịu trách nhiệm hiển thị màn hình đăng nhập và gọi tầng nghiệp vụ khi người dùng thao tác.
    public partial class FrmDangNhap : Form
    {
        private readonly ServiceFactory _services = new ServiceFactory();
        private bool _allowClose;

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

        public FrmDangNhap()
        {
            InitializeComponent();
            ApplyBaseStyle();
            Load += FrmDangNhap_Load;
            Resize += FrmDangNhap_Resize;
            pnlUsername.Paint -= InputPanel_Paint;
            pnlUsername.Paint += InputPanel_Paint;
            panel1.Paint -= InputPanel_Paint;
            panel1.Paint += InputPanel_Paint;
            AcceptButton = btnLogin;
        }

        // Áp dụng kiểu nền của màn hình đăng nhập.
        private void ApplyBaseStyle()
        {
            Font = ThemeManager.Current.BodyFont;
            BackColor = ThemeManager.Current.BackgroundDark;
            FormBorderStyle = FormBorderStyle.None;
            ForeColor = ThemeManager.Current.PrimaryText;
            StartPosition = FormStartPosition.CenterScreen;
            DoubleBuffered = true;
            MinimumSize = new Size(760, 500);
            Text = "Đăng nhập - Quản lý lớp IELTS";
        }

        // Xử lý khi màn hình đăng nhập được nạp.
        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            ApplyLoginTheme();
        }

        // Xử lý khi màn hình đăng nhập đổi kích thước.
        private void FrmDangNhap_Resize(object sender, EventArgs e)
        {
            ApplyLoginTheme();
            Invalidate();
        }

        // Xử lý nền khi vẽ lại biểu mẫu.
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (ClientSize.Width == 0 || ClientSize.Height == 0)
            {
                return;
            }

            using (var brush = new LinearGradientBrush(ClientRectangle,
                ThemeManager.Current.BackgroundDark,
                ThemeManager.Current.PanelDark,
                LinearGradientMode.ForwardDiagonal))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }
        }

        // Xử lý nội dung vẽ của màn hình đăng nhập.
        private void FrmDangNhap_Paint(object sender, PaintEventArgs e)
        {
            DrawCardShadow(e.Graphics);
        }

        // Áp dụng chủ đề của màn hình đăng nhập.
        private void ApplyLoginTheme()
        {
            var theme = ThemeManager.Current;

            SuspendLayout();
            BackColor = theme.BackgroundDark;
            ForeColor = theme.PrimaryText;
            Font = theme.BodyFont;

            pnlMovingForm.BackColor = Color.Transparent;
            StyleWindowButton(btnMinimize);
            StyleWindowButton(btnClose);

            label1.Visible = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label1.ForeColor = theme.PrimaryText;
            label1.BackColor = Color.Transparent;
            label1.TextAlign = ContentAlignment.MiddleLeft;

            label2.Visible = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Regular);
            label2.ForeColor = theme.SecondaryText;
            label2.BackColor = Color.Transparent;
            label2.TextAlign = ContentAlignment.TopLeft;

            pnlLogin.BackColor = theme.PanelDark;
            SetRoundedRegion(pnlLogin, 18);

            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label3.ForeColor = theme.Accent;
            label3.BackColor = Color.Transparent;
            label3.TextAlign = ContentAlignment.MiddleCenter;

            pnlUsername.BackColor = theme.ControlBackground;
            SetRoundedRegion(pnlUsername, 8);

            panel1.BackColor = theme.ControlBackground;
            SetRoundedRegion(panel1, 8);

            StyleTextInput(txtUsername, lblUsername, pnlUnder1, icoUsername);
            StyleTextInput(txtPassword, lblPassword, pnlUnder2, icoPassword);
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.PasswordChar = '*';

            icoShowPass.BackColor = Color.Transparent;
            icoShowPass.IconColor = theme.Accent;
            icoShowPass.ForeColor = theme.Accent;
            icoShowPass.Cursor = Cursors.Hand;

            btnLogin.BackColor = theme.Accent;
            btnLogin.ForeColor = theme.ButtonText;
            btnLogin.IconColor = theme.ButtonText;
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogin.ImageAlign = ContentAlignment.MiddleRight;
            btnLogin.TextAlign = ContentAlignment.MiddleCenter;
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.MouseEnter -= LoginButton_MouseEnter;
            btnLogin.MouseLeave -= LoginButton_MouseLeave;
            btnLogin.MouseDown -= LoginButton_MouseDown;
            btnLogin.MouseUp -= LoginButton_MouseUp;
            btnLogin.MouseEnter += LoginButton_MouseEnter;
            btnLogin.MouseLeave += LoginButton_MouseLeave;
            btnLogin.MouseDown += LoginButton_MouseDown;
            btnLogin.MouseUp += LoginButton_MouseUp;

            pnlUsername.Invalidate();
            panel1.Invalidate();
            ResumeLayout();
        }

        // Xử lý kiểu ô nhập đăng nhập.
        private void StyleTextInput(TextBox textBox, Label placeholder, Panel underline, IconPictureBox icon)
        {
            var theme = ThemeManager.Current;

            placeholder.BackColor = Color.Transparent;
            placeholder.ForeColor = string.IsNullOrEmpty(textBox.Text) ? theme.SecondaryText : theme.Accent;
            placeholder.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            textBox.BorderStyle = BorderStyle.None;
            textBox.BackColor = theme.ControlBackground;
            textBox.ForeColor = theme.PrimaryText;
            textBox.Font = theme.BodyFont;

            underline.BackColor = theme.PrimaryText;

            icon.BackColor = Color.Transparent;
            icon.ForeColor = theme.Accent;
            icon.IconColor = theme.Accent;
        }

        // Xử lý kiểu nút cửa sổ.
        private void StyleWindowButton(Button button)
        {
            button.BackColor = Color.Transparent;
            button.ForeColor = ThemeManager.Current.PrimaryText;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.UseVisualStyleBackColor = false;
        }

        // Vẽ bóng đổ cho khung đăng nhập.
        private void DrawCardShadow(Graphics graphics)
        {
            if (pnlLogin == null || !pnlLogin.Visible)
            {
                return;
            }

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var shadowBounds = new Rectangle(pnlLogin.Left + 10, pnlLogin.Top + 12, pnlLogin.Width, pnlLogin.Height);
            using (var path = CreateRoundRectPath(shadowBounds, 18))
            using (var brush = new SolidBrush(Color.FromArgb(90, ThemeManager.Current.BackgroundDark)))
            {
                graphics.FillPath(brush, path);
            }
        }

        // Xử lý viền dưới của ô nhập.
        private void InputPanel_Paint(object sender, PaintEventArgs e)
        {
            var panel = sender as Panel;
            if (panel == null)
            {
                return;
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = CreateRoundRectPath(new Rectangle(0, 0, panel.Width - 1, panel.Height - 1), 8))
            using (var pen = new Pen(ThemeManager.Current.BorderColor))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        // Xử lý bo góc biểu mẫu.
        private void SetRoundedRegion(Control control, int radius)
        {
            if (control.Width <= 0 || control.Height <= 0)
            {
                return;
            }

            if (control.Region != null)
            {
                control.Region.Dispose();
            }

            control.Region = new Region(CreateRoundRectPath(new Rectangle(0, 0, control.Width, control.Height), radius));
        }

        // Tạo đường vẽ hình chữ nhật bo góc.
        private GraphicsPath CreateRoundRectPath(Rectangle bounds, int radius)
        {
            var path = new GraphicsPath();
            var diameter = radius * 2;
            path.AddArc(bounds.Left, bounds.Top, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Top, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.Left, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        // Đổi màu nút đăng nhập khi người dùng rê chuột vào.
        private void LoginButton_MouseEnter(object sender, EventArgs e)
        {
            if (!CanUse(btnLogin))
            {
                return;
            }

            btnLogin.BackColor = ThemeManager.Current.AccentHover;
        }

        // Khôi phục màu nút đăng nhập khi chuột rời khỏi nút.
        private void LoginButton_MouseLeave(object sender, EventArgs e)
        {
            if (!CanUse(btnLogin))
            {
                return;
            }

            btnLogin.BackColor = ThemeManager.Current.Accent;
        }

        // Đổi màu nút đăng nhập khi người dùng nhấn chuột.
        private void LoginButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (!CanUse(btnLogin))
            {
                return;
            }

            btnLogin.BackColor = ThemeManager.Current.AccentPressed;
        }

        // Khôi phục trạng thái nút đăng nhập sau khi thả chuột.
        private void LoginButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (!CanUse(btnLogin))
            {
                return;
            }

            try
            {
                btnLogin.BackColor = btnLogin.ClientRectangle.Contains(btnLogin.PointToClient(Cursor.Position))
                    ? ThemeManager.Current.AccentHover
                    : ThemeManager.Current.Accent;
            }
            catch (ObjectDisposedException)
            {
                return;
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        // Xử lý nhả bắt chuột khi kéo cửa sổ.
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        // Xử lý gửi thông điệp kéo cửa sổ.
        private static extern void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        // Xử lý xử lý thông điệp cửa sổ.
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

        // Xử lý thao tác bấm trên điều khiển giao diện để cập nhật trạng thái biểu mẫu.
        private void lblUsername_Click(object sender, EventArgs e)
        {
            FocusInput(txtUsername, lblUsername, pnlUnder1, icoUsername);
        }

        // Xử lý khi rời ô tài khoản.
        private void txtUsername_Leave(object sender, EventArgs e)
        {
            LeaveInput(txtUsername, lblUsername, pnlUnder1, icoUsername);
        }

        // Xử lý thao tác bấm trên điều khiển giao diện để cập nhật trạng thái biểu mẫu.
        private void icoShowPass_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.PasswordChar = '\0';
                icoShowPass.IconChar = IconChar.EyeSlash;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.PasswordChar = '*';
                icoShowPass.IconChar = IconChar.Eye;
            }
        }

        // Xử lý thao tác bấm trên điều khiển giao diện để cập nhật trạng thái biểu mẫu.
        private void lblPassword_Click(object sender, EventArgs e)
        {
            FocusInput(txtPassword, lblPassword, pnlUnder2, icoPassword);
        }

        // Xử lý khi rời ô mật khẩu.
        private void txtPassword_Leave(object sender, EventArgs e)
        {
            LeaveInput(txtPassword, lblPassword, pnlUnder2, icoPassword);
        }

        // Làm nổi bật ô tài khoản khi người dùng bắt đầu nhập.
        private void txtUsername_Enter(object sender, EventArgs e)
        {
            FocusInput(txtUsername, lblUsername, pnlUnder1, icoUsername);
        }

        // Làm nổi bật ô mật khẩu khi người dùng bắt đầu nhập.
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            FocusInput(txtPassword, lblPassword, pnlUnder2, icoPassword);
        }

        // Đổi màu nhãn, gạch chân và biểu tượng khi ô nhập được focus.
        private void FocusInput(TextBox textBox, Label placeholder, Panel underline, IconPictureBox icon)
        {
            placeholder.Location = new Point(placeholder.Location.X, 4);
            placeholder.ForeColor = ThemeManager.Current.Accent;
            textBox.ForeColor = ThemeManager.Current.PrimaryText;
            underline.BackColor = ThemeManager.Current.Accent;
            icon.IconColor = ThemeManager.Current.Accent;
            textBox.Focus();
        }

        // Khôi phục màu nhãn, gạch chân và biểu tượng khi ô nhập mất focus.
        private void LeaveInput(TextBox textBox, Label placeholder, Panel underline, IconPictureBox icon)
        {
            placeholder.ForeColor = ThemeManager.Current.SecondaryText;
            textBox.ForeColor = ThemeManager.Current.PrimaryText;
            underline.BackColor = ThemeManager.Current.BorderColor;
            icon.IconColor = ThemeManager.Current.Accent;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                placeholder.Location = new Point(placeholder.Location.X, 20);
            }
        }

        // Xử lý sự kiện người dùng nhấn nút Đăng nhập.
        private void btnLogin_Click(object sender, EventArgs e)
        {
            var result = _services.Auth.DangNhap(txtUsername.Text, txtPassword.Text);
            if (!result.Success)
            {
                UiHelpers.ShowResult(result);
                return;
            }

            Hide();
            using (var frm = new FrmChinh(_services, result.Data))
            {
                frm.ShowDialog(this);
            }
            _allowClose = true;
            Close();
        }

        // Xử lý kéo cửa sổ từ thanh tiêu đề tùy biến.
        private void pnlMovingForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        // Xử lý sự kiện người dùng nhấn nút Thu nhỏ.
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Xử lý sự kiện người dùng nhấn nút Đóng.
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!ConfirmExit())
            {
                return;
            }

            _allowClose = true;
            Application.Exit();
        }

        // Xử lý khi đóng màn hình đăng nhập.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!_allowClose && e.CloseReason == CloseReason.UserClosing && !ConfirmExit())
            {
                e.Cancel = true;
                return;
            }

            base.OnFormClosing(e);
        }

        // Xử lý xác nhận thoát ứng dụng.
        private bool ConfirmExit()
        {
            return MessageBox.Show(
                "Bạn có muốn tắt ứng dụng?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }

        // Xử lý điều khiển còn sử dụng được.
        private static bool CanUse(Control control)
        {
            return control != null && !control.IsDisposed && !control.Disposing;
        }
    }
}
