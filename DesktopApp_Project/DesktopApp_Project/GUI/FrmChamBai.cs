using System;
using System.IO;
using DesktopApp_Project.BUS;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public partial class FrmChamBai : ModuleFormBase
    {
        public FrmChamBai()
        {
            InitializeComponent();
        }

        public FrmChamBai(ServiceFactory services, NguoiDungDTO currentUser)
            : this()
        {
            SetRuntimeContext(services, currentUser);
        }

        protected override void OnRuntimeLoad()
        {
            LoadAssignments();
        }

        private void LoadAssignments()
        {
            var list = Services.BaiTap.LayDanhSach(null);
            _cboBaiTap.DataSource = list;
            _cboBaiTap.DisplayMember = "TieuDe";
            _cboBaiTap.ValueMember = "MaBaiTap";
            LoadSubmissions();
        }

        private void LoadSubmissions()
        {
            var maBaiTap = UiHelpers.SelectedId(_cboBaiTap);
            if (maBaiTap > 0)
            {
                _grid.DataSource = Services.ChamBai.LayDanhSach(maBaiTap);
            }
        }

        private void PreviewSubmission()
        {
            var item = UiHelpers.SelectedItem<NopBaiDTO>(_grid);
            if (item == null) return;

            _txtNhanXet.Text = item.NhanXet;
            _numDiem.Value = item.DiemSo.HasValue ? item.DiemSo.Value : 0;
            if (!string.IsNullOrWhiteSpace(item.FileBaiLam) && File.Exists(item.FileBaiLam))
            {
                _txtPreview.Text = "Tệp bài làm: " + item.FileBaiLam + Environment.NewLine +
                                   "Có thể mở tệp bằng ứng dụng phù hợp trên máy để xem nội dung chi tiết.";
            }
            else
            {
                _txtPreview.Text = "Học viên chưa có file bài làm trong hệ thống.";
            }
        }

        private void BtnTai_Click(object sender, EventArgs e)
        {
            LoadSubmissions();
        }

        private void BtnCham_Click(object sender, EventArgs e)
        {
            var item = UiHelpers.SelectedItem<NopBaiDTO>(_grid);
            if (item == null) return;

            item.DiemSo = _numDiem.Value;
            item.NhanXet = _txtNhanXet.Text.Trim();
            var result = Services.ChamBai.Cham(item);
            UiHelpers.ShowResult(result);
            if (result.Success) LoadSubmissions();
        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            PreviewSubmission();
        }
    }
}
