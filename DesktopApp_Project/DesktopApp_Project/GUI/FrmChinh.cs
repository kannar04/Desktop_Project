using System;
using System.Drawing;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public partial class FrmChinh : Form
    {
        private readonly ServiceFactory _services;
        private readonly NguoiDungDTO _currentUser;
        private readonly Panel _contentPanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };

        public FrmChinh(ServiceFactory services, NguoiDungDTO currentUser)
        {
            InitializeComponent();
            _services = services;
            _currentUser = currentUser;

            Text = "Quản lý lớp IELTS";
            WindowState = FormWindowState.Maximized;
            Font = UiHelpers.DefaultFont;

            var header = new Label
            {
                Text = "Quản lý lớp IELTS - Xin chào " + currentUser.HoTen + " (" + AppConstants.GetDisplayRole(currentUser.VaiTro) + ")",
                Dock = DockStyle.Top,
                Height = 44,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(14, 0, 0, 0),
                Font = UiHelpers.TitleFont,
                BackColor = Color.FromArgb(235, 242, 252)
            };

            var menu = new FlowLayoutPanel
            {
                Dock = DockStyle.Left,
                Width = 230,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(8),
                BackColor = Color.FromArgb(248, 249, 251),
                AutoScroll = true
            };

            AddMenu(menu, "Hồ sơ học viên", () => new FrmHocVien(_services, _currentUser));
            AddMenu(menu, "Lớp học", () => new FrmLopHoc(_services, _currentUser));
            AddMenu(menu, "Tài liệu", () => new FrmTaiLieu(_services, _currentUser));
            AddMenu(menu, "Bài tập", () => new FrmBaiTap(_services, _currentUser));
            AddMenu(menu, "Chấm bài", () => new FrmChamBai(_services, _currentUser));
            AddMenu(menu, "Điểm số", () => new FrmDiemSo(_services, _currentUser));
            AddMenu(menu, "Điểm danh", () => new FrmDiemDanh(_services, _currentUser));
            AddMenu(menu, "Đề thi", () => new FrmDeThi(_services, _currentUser));
            AddMenu(menu, "Báo cáo", () => new FrmBaoCao(_services, _currentUser));
            AddMenu(menu, "Từ vựng", () => new FrmTuVung(_services, _currentUser));
            AddMenu(menu, "Thông báo", () => new FrmThongBao(_services, _currentUser));
            AddMenu(menu, "Học phí", () => new FrmHocPhi(_services, _currentUser));

            Controls.Add(_contentPanel);
            Controls.Add(menu);
            Controls.Add(header);

            OpenModule(new FrmHocVien(_services, _currentUser));
        }

        private void AddMenu(FlowLayoutPanel menu, string text, Func<Form> formFactory)
        {
            var button = UiHelpers.Button(text);
            button.Width = 205;
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.Click += (sender, args) => OpenModule(formFactory());
            menu.Controls.Add(button);
        }

        private void OpenModule(Form form)
        {
            foreach (Control control in _contentPanel.Controls)
            {
                control.Dispose();
            }
            _contentPanel.Controls.Clear();

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            _contentPanel.Controls.Add(form);
            form.Show();
        }
    }
}
