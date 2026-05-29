using System;
using System.Diagnostics;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public partial class FrmBaoCao : ModuleFormBase
    {
        public FrmBaoCao()
        {
            InitializeComponent();
            WireEvents();
        }

        public FrmBaoCao(ServiceFactory services, NguoiDungDTO currentUser)
            : this()
        {
            SetRuntimeContext(services, currentUser);
        }

        private void WireEvents()
        {
            WireClick(btnTao, BtnTao_Click);
            WireClick(btnXuat, BtnXuat_Click);
        }

        protected override void OnRuntimeLoad()
        {
            _cboLoai.DataSource = AppConstants.ReportTypes;
            UiHelpers.BindLopHoc(_cboLop, Services);
        }

        private void BtnTao_Click(object sender, EventArgs e)
        {
            if (!HasCurrentUser())
            {
                return;
            }

            var result = Services.BaoCao.TaoBaoCao(new BaoCaoDTO
            {
                LoaiBaoCao = Convert.ToString(_cboLoai.SelectedItem),
                MaLopHoc = UiHelpers.SelectedId(_cboLop)
            }, CurrentUser.MaNguoiDung);

            if (result.Success)
            {
                _txtNoiDung.Text = result.Data;
            }
            UiHelpers.ShowResult(result);
        }

        private void BtnXuat_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "HTML report|*.html", FileName = "BaoCaoIELTS.html" })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                var result = Services.BaoCao.XuatBaoCao(_txtNoiDung.Text, dialog.FileName);
                UiHelpers.ShowResult(result);
                if (result.Success)
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = dialog.FileName,
                        UseShellExecute = true
                    });
                }
            }
        }
    }
}
