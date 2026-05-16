using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{

    public partial class FrmBaoCao : ModuleFormBase
    {
        private readonly ComboBox _cboLoai = UiHelpers.ComboBox();
        private readonly ComboBox _cboLop = UiHelpers.ComboBox();
        private readonly TextBox _txtNoiDung = new TextBox { Dock = DockStyle.Fill, Multiline = true, ScrollBars = ScrollBars.Both, Font = UiHelpers.DefaultFont };

        public FrmBaoCao(ServiceFactory services, NguoiDungDTO currentUser) : base(services, currentUser, "Tạo báo cáo")
        {
            InitializeComponent();
            var root = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2 };
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            var top = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, Padding = new Padding(8) };
            _cboLoai.DataSource = new[] { "Điểm số", "Chuyên cần" };
            var btnTao = UiHelpers.Button("Tạo báo cáo");
            var btnXuat = UiHelpers.Button("Xuất file");
            btnTao.Width = 130;
            btnTao.Click += (s, e) => Generate();
            btnXuat.Click += (s, e) => Export();
            top.Controls.Add(UiHelpers.Label("Loại báo cáo"));
            top.Controls.Add(_cboLoai);
            top.Controls.Add(UiHelpers.Label("Lớp"));
            top.Controls.Add(_cboLop);
            top.Controls.Add(btnTao);
            top.Controls.Add(btnXuat);
            root.Controls.Add(top, 0, 0);
            root.Controls.Add(_txtNoiDung, 0, 1);
            AddContent(root);
            UiHelpers.BindLopHoc(_cboLop, Services);
        }

        private void Generate()
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

        private void Export()
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
