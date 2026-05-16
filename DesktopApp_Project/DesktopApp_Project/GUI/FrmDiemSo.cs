using System;
using DesktopApp_Project.BUS;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public partial class FrmDiemSo : ModuleFormBase
    {
        public FrmDiemSo()
            : base("Cập nhật điểm số IELTS")
        {
            InitializeComponent();
        }
        public FrmDiemSo(ServiceFactory services, NguoiDungDTO currentUser)
            : base(services, currentUser, "Cập nhật điểm số IELTS")
        {
            InitializeComponent();
            UiHelpers.BindLopHoc(_cboLop, Services);
            LoadRoundsAndStudents();
        }

        private void LoadRoundsAndStudents()
        {
            var maLop = UiHelpers.SelectedId(_cboLop);
            if (maLop <= 0) return;

            _gridHocVien.DataSource = Services.LopHoc.LayHocVienTrongLop(maLop);
            _cboDot.DataSource = Services.DiemSo.LayDotKiemTra(maLop);
            _cboDot.DisplayMember = "TenDotKiemTra";
            _cboDot.ValueMember = "MaDotKiemTra";
            LoadScores();
        }

        private void BtnTaoDot_Click(object sender, EventArgs e)
        {
            var result = Services.DiemSo.TaoDotKiemTra(new DotKiemTraDTO
            {
                MaLopHoc = UiHelpers.SelectedId(_cboLop),
                TenDotKiemTra = _txtTenDot.Text.Trim(),
                NgayKiemTra = _dtNgay.Value.Date
            });

            UiHelpers.ShowResult(result);
            if (result.Success) LoadRoundsAndStudents();
        }

        private void LoadScores()
        {
            var maDot = UiHelpers.SelectedId(_cboDot);
            if (maDot > 0)
            {
                _gridDiem.DataSource = Services.DiemSo.LayDiemSo(maDot);
            }
        }

        private void BtnTai_Click(object sender, EventArgs e)
        {
            LoadScores();
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            var hv = UiHelpers.SelectedItem<NguoiDungDTO>(_gridHocVien);
            if (hv == null) return;

            var result = Services.DiemSo.LuuDiem(new DiemSoDTO
            {
                MaNguoiDung = hv.MaNguoiDung,
                MaDotKiemTra = UiHelpers.SelectedId(_cboDot),
                DiemL = _diemL.Value,
                DiemR = _diemR.Value,
                DiemW = _diemW.Value,
                DiemS = _diemS.Value,
                NhanXet = _txtNhanXet.Text.Trim()
            });

            UiHelpers.ShowResult(result);
            if (result.Success) LoadScores();
        }

        private void CboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRoundsAndStudents();
        }
    }
}
