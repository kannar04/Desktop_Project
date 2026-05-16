using System;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public partial class FrmChinh : Form
    {
        private ServiceFactory _services;
        private NguoiDungDTO _currentUser;
        private bool _runtimeLoaded;

        public FrmChinh()
        {
            InitializeComponent();
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
                _lblHeader.Text = "Quản lý lớp IELTS";
                return;
            }

            _lblHeader.Text = "Quản lý lớp IELTS - Xin chào " + _currentUser.HoTen + " (" + AppConstants.GetDisplayRole(_currentUser.VaiTro) + ")";
            OpenModule(new FrmHocVien(_services, _currentUser));
        }

        private void OpenModule(Form form)
        {
            if (_services == null || _currentUser == null)
            {
                return;
            }

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

        private void BtnHocVien_Click(object sender, EventArgs e) { OpenModule(new FrmHocVien(_services, _currentUser)); }
        private void BtnLopHoc_Click(object sender, EventArgs e) { OpenModule(new FrmLopHoc(_services, _currentUser)); }
        private void BtnTaiLieu_Click(object sender, EventArgs e) { OpenModule(new FrmTaiLieu(_services, _currentUser)); }
        private void BtnBaiTap_Click(object sender, EventArgs e) { OpenModule(new FrmBaiTap(_services, _currentUser)); }
        private void BtnChamBai_Click(object sender, EventArgs e) { OpenModule(new FrmChamBai(_services, _currentUser)); }
        private void BtnDiemSo_Click(object sender, EventArgs e) { OpenModule(new FrmDiemSo(_services, _currentUser)); }
        private void BtnDiemDanh_Click(object sender, EventArgs e) { OpenModule(new FrmDiemDanh(_services, _currentUser)); }
        private void BtnDeThi_Click(object sender, EventArgs e) { OpenModule(new FrmDeThi(_services, _currentUser)); }
        private void BtnBaoCao_Click(object sender, EventArgs e) { OpenModule(new FrmBaoCao(_services, _currentUser)); }
        private void BtnTuVung_Click(object sender, EventArgs e) { OpenModule(new FrmTuVung(_services, _currentUser)); }
        private void BtnThongBao_Click(object sender, EventArgs e) { OpenModule(new FrmThongBao(_services, _currentUser)); }
        private void BtnHocPhi_Click(object sender, EventArgs e) { OpenModule(new FrmHocPhi(_services, _currentUser)); }
    }
}
