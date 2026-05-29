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
            WireEvents();
        }

        public FrmChamBai(ServiceFactory services, NguoiDungDTO currentUser)
            : this()
        {
            SetRuntimeContext(services, currentUser);
        }

        private void WireEvents()
        {
            WireClick(btnTai, BtnTai_Click);
            WireClick(btnCham, BtnCham_Click);
            WireSelectionChanged(_grid, Grid_SelectionChanged);
            WireSelectedIndexChanged(_cboBaiTap, CboBaiTap_SelectedIndexChanged);
        }

        protected override void OnRuntimeLoad()
        {
            LoadAssignments();
        }

        private void LoadAssignments()
        {
            var list = SafeLoad<object>(() => Services.BaiTap.LayDanhSach(null), null);
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
                _grid.DataSource = SafeLoad<object>(() => Services.ChamBai.LayDanhSach(maBaiTap), null);
            }
            else
            {
                _grid.DataSource = null;
            }
        }

        private void PreviewSubmission()
        {
            var item = UiHelpers.SelectedItem<NopBaiDTO>(_grid);
            if (item == null) return;

            _txtNhanXet.Text = item.NhanXet;
            _numDiem.Value = item.DiemSo.HasValue ? item.DiemSo.Value : 0;

            var resolvedPath = ManagedFileStorage.ResolvePath(item.FileBaiLam);
            if (!string.IsNullOrWhiteSpace(resolvedPath) && File.Exists(resolvedPath))
            {
                _txtPreview.Text = "Tep bai lam: " + resolvedPath + Environment.NewLine +
                                   "Co the mo tep bang ung dung phu hop tren may de xem noi dung chi tiet.";
            }
            else if (!string.IsNullOrWhiteSpace(item.FileBaiLam))
            {
                _txtPreview.Text = "Khong tim thay file bai lam: " + item.FileBaiLam;
            }
            else
            {
                _txtPreview.Text = "Hoc vien chua co file bai lam trong he thong.";
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

        private void CboBaiTap_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubmissions();
        }
    }
}
