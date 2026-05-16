using System;
using System.IO;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public partial class FrmBaoCao : ModuleFormBase
    {
        public FrmBaoCao()
        {
            InitializeComponent();
        }

        public FrmBaoCao(ServiceFactory services, NguoiDungDTO currentUser)
            : this()
        {
            SetRuntimeContext(services, currentUser);
        }

        protected override void OnRuntimeLoad()
        {
            UiHelpers.BindLopHoc(_cboLop, Services);
        }

        private void BtnTao_Click(object sender, EventArgs e)
        {
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
            using (var dialog = new SaveFileDialog { Filter = "Tệp CSV hoặc văn bản|*.csv;*.txt|Tệp Word RTF|*.rtf", FileName = "BaoCaoIELTS.csv" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var content = Path.GetExtension(dialog.FileName).Equals(".rtf", StringComparison.OrdinalIgnoreCase)
                        ? "{\\rtf1\\ansi " + _txtNoiDung.Text.Replace(Environment.NewLine, "\\line ") + "}"
                        : _txtNoiDung.Text;
                    UiHelpers.ShowResult(Services.BaoCao.XuatBaoCao(content, dialog.FileName));
                }
            }
        }
    }
}
