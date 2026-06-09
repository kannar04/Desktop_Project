// Biểu mẫu quản lý báo cáo
// Chức năng:
// - Hiển thị và nhập dữ liệu báo cáo
// - Gọi tầng nghiệp vụ để tải, lưu hoặc xóa dữ liệu
// - Cập nhật trạng thái giao diện sau thao tác của người dùng

using System;
using System.Diagnostics;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    // Lớp biểu mẫu Windows Forms chịu trách nhiệm hiển thị báo cáo và gọi tầng nghiệp vụ khi người dùng thao tác.
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

        // Đăng ký các hàm xử lý sự kiện cho điều khiển trên biểu mẫu.
        private void WireEvents()
        {
            WireClick(btnTao, BtnTao_Click);
            WireClick(btnXuat, BtnXuat_Click);
        }

        // Nạp dữ liệu và thiết lập trạng thái ban đầu khi biểu mẫu được mở.
        protected override void OnRuntimeLoad()
        {
            // Cập nhật dữ liệu hiển thị trên ô chọn loại báo cáo.
            _cboLoai.DataSource = AppConstants.ReportTypes;
            UiHelpers.BindLopHoc(_cboLop, Services);
        }

        // Xử lý sự kiện người dùng nhấn nút Tính.
        private void BtnTao_Click(object sender, EventArgs e)
        {
            if (!HasCurrentUser())
            {
                return;
            }

            // Gọi tầng nghiệp vụ để tạo báo cáo.
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

        // Xử lý sự kiện người dùng nhấn nút Xuất.
        private void BtnXuat_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "HTML report|*.html", FileName = "BaoCaoIELTS.html" })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                // Gọi tầng nghiệp vụ để xuất báo cáo.
                var result = Services.BaoCao.XuatBaoCao(_txtNoiDung.Text, dialog.FileName);
                UiHelpers.ShowResult(result);
                if (result.Success)
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = dialog.FileName,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xuất báo cáo nhưng không thể mở file tự động. Chi tiết: " + ex.Message,
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
