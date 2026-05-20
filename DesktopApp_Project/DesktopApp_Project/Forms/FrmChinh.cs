using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp_Project.Forms
{
    public partial class FrmChinh : FormBase
    {
        //
        // 1. Định nghĩa các hằng số của Windows API
        private const int WM_NCHITTEST = 0x0084; // Message khi chuột di chuyển trên form
        private const int resizeAreaSize = 10;   // Độ rộng của vùng cho phép kéo thả resize (10px)

        // Các mã trả về cho biết chuột đang ở vị trí nào
        private const int HTCLIENT = 1;      // Chuột ở vùng bình thường
        private const int HTCAPTION = 2;     // Chuột ở vùng Title Bar (cho phép nắm kéo)

        // Các mã cho việc Resize
        private const int HTLEFT = 10;
        private const int HTRIGHT = 11;
        private const int HTTOP = 12;
        private const int HTTOPLEFT = 13;
        private const int HTTOPRIGHT = 14;
        private const int HTBOTTOM = 15;
        private const int HTBOTTOMLEFT = 16;
        private const int HTBOTTOMRIGHT = 17;

        // biến làm đẹp nút
        private IconButton currentBtn;
        private Panel leftBorderBtn;

        private Form currentChildForm; // Biến lưu trữ Form con hiện tại đang mở



        private class RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        //Constructor
        public FrmChinh()
        {
            InitializeComponent();

            // Cấu hình FrmChinh
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.MinimumSize = new Size(1366, 900);

            // Khởi tạo panel làm đẹp bên trái nút
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            pnlSideMenu.Controls.Add(leftBorderBtn);

        }

        //Methods
        // ============ Form Move ============
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlMovingForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture(); // Giải phóng bắt chuột hiện tại
                SendMessage(this.Handle, 0x112, 0xf012, 0); // Gửi lệnh cho Windows: "Người dùng đang nắm thanh TitleBar, hãy di chuyển Form đi!"
            }
        }
        // ============ Drag ============
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            // Bắt sự kiện chuột di chuyển trên form
            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)
            {
                // Lấy tọa độ chuột hiện tại
                Point screenPoint = new Point(m.LParam.ToInt32());
                Point clientPoint = this.PointToClient(screenPoint);

                // --- XỬ LÝ RESIZE ---
                // Kiểm tra xem chuột có nằm ở các cạnh hay góc của form không (trong phạm vi 10px)
                if (clientPoint.Y <= resizeAreaSize)
                {
                    if (clientPoint.X <= resizeAreaSize) m.Result = (IntPtr)HTTOPLEFT; // Góc trên trái
                    else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) m.Result = (IntPtr)HTTOP; // Cạnh trên
                    else m.Result = (IntPtr)HTTOPRIGHT; // Góc trên phải
                }
                else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize))
                {
                    if (clientPoint.X <= resizeAreaSize) m.Result = (IntPtr)HTLEFT; // Cạnh trái
                    else if (clientPoint.X > (this.Width - resizeAreaSize)) m.Result = (IntPtr)HTRIGHT; // Cạnh phải

                    // --- XỬ LÝ DRAG (NẮM KÉO FORM) ---
                    // Giả sử vùng Title Bar ảo của bro cao 40px
                    else if (clientPoint.Y <= 40)
                    {
                        m.Result = (IntPtr)HTCAPTION; // Báo cho Windows biết đây là Title Bar để cho phép nắm kéo
                    }
                }
                else
                {
                    if (clientPoint.X <= resizeAreaSize) m.Result = (IntPtr)HTBOTTOMLEFT; // Góc dưới trái
                    else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) m.Result = (IntPtr)HTBOTTOM; // Cạnh dưới
                    else m.Result = (IntPtr)HTBOTTOMRIGHT; // Góc dưới phải
                }
            }            
        }
        // ============ ========== ============
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kiểm tra trạng thái hiện tại của Form
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                // Đổi icon thành 2 ô vuông chồng lên nhau (hoặc chữ O) để biểu thị nút Restore
                btnMaximize.Text = "❐";
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                // Đổi lại icon hình 1 ô vuông để biểu thị nút Maximize
                btnMaximize.Text = "◻";
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        // Hàm xử lý việc mở nhúng Form con vào pnlDesktopPanel
        private void OpenChildForm(Form childForm)
        {
            // 1. Nếu đang có một form mở trong panel, đóng nó lại để giải phóng bộ nhớ
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            // Cập nhật lại form hiện tại
            currentChildForm = childForm;

            // 2. Thiết lập các thuộc tính để "ép" Form hoạt động như một Control
            childForm.TopLevel = false; // Bắt buộc: Tước quyền làm cửa sổ cấp cao nhất (TopLevel)
            childForm.FormBorderStyle = FormBorderStyle.None; // Xóa viền của form con
            childForm.Dock = DockStyle.Fill; // Cho form con lấp đầy pnlDesktopPanel

            // 3. Thêm form con vào danh sách control của Panel và hiển thị lên
            pnlDesktop.Controls.Add(childForm);
            pnlDesktop.Tag = childForm; // Lưu trữ data form vào Tag của panel (dùng khi cần)
            childForm.BringToFront(); // Đưa form lên lớp trên cùng để không bị che
            childForm.Show(); // Hiển thị form
            lblTitleChildForm.Text = childForm.Text; // Cập nhật tiêu đề của form con lên lblTitleChildForm

        }

        private void btnChinh_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
        }

        private void btnBaiTap_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new FrmBaiTap());
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new FrmBaoCao());
        }

        private void btnChamBai_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new FrmChamBai());
        }

        private void btnDeThi_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            OpenChildForm(new FrmDeThi());
        }

        private void btnDiemDanh_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FrmDiemDanh());
        }

        private void btnDiemSo_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new FrmDiemSo());
        }

        private void btnHocPhi_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new FrmHocPhi()); 
        }

        private void btnHocVien_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new FrmHocVien());
        }

        private void btnLopHoc_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new FrmLopHoc());
        }

        private void btnTuVung_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            OpenChildForm(new FrmTuVung());
        }
    }
}
