using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public partial class FrmHocPhi : ModuleFormBase
    {
        private BindingList<HocPhiTinhDTO> _previewRows = new BindingList<HocPhiTinhDTO>();
        private bool _isCreatingTuition;
        private bool _isPreviewMode;

        public FrmHocPhi()
        {
            InitializeComponent();
            WireEvents();
        }

        public FrmHocPhi(ServiceFactory services, NguoiDungDTO currentUser)
            : this()
        {
            SetRuntimeContext(services, currentUser);
        }

        private void WireEvents()
        {
            WireClick(btnTao, BtnTao_Click);
            WireClick(btnCapNhat, BtnCapNhat_Click);
            WireSelectedIndexChanged(_cboHocVien, CboHocVien_SelectedIndexChanged);
            _grid.CurrentCellDirtyStateChanged += Grid_CurrentCellDirtyStateChanged;
        }

        protected override void OnRuntimeLoad()
        {
            ConfigureClassTuitionMode();
            UiHelpers.BindLopHoc(_cboHocVien, Services);
            LoadData();
        }

        private void ConfigureClassTuitionMode()
        {
            _lblDesigner1.Text = "Lớp";
            _lblDesigner2.Text = "Số tiền gốc";
            btnTao.Text = "Tính học phí";
            btnTao.Width = 130;
            _cboTrangThai.DataSource = AppConstants.PaymentStatuses;

            WireClick(_btnTaoPhieu, BtnTaoPhieu_Click);
            WireClick(_btnXemHoaDon, BtnXemHoaDon_Click);
            WireClick(_btnXuatHoaDon, BtnXuatHoaDon_Click);
            WireClick(_btnThanhToan, BtnThanhToan_Click);
            WireClick(_btnGuiHocPhi, BtnGuiHocPhi_Click);
            WireClick(_btnChonTatCa, BtnChonTatCa_Click);
            WireClick(_btnBoChonTatCa, BtnBoChonTatCa_Click);
            WireClick(_btnGuiHocPhiDaChon, BtnGuiHocPhiDaChon_Click);
        }

        private void LoadData()
        {
            _isPreviewMode = false;
            _grid.DataSource = SafeLoad<object>(() => Services.HocPhi.LayDanhSach(UiHelpers.SelectedId(_cboHocVien)), null);
            ConfigureSelectionColumn(true);
        }

        private void BtnTao_Click(object sender, EventArgs e)
        {
            var result = Services.HocPhi.TinhTheoLop(UiHelpers.SelectedId(_cboHocVien), _numSoTien.Value);
            if (result.Success)
            {
                _previewRows = new BindingList<HocPhiTinhDTO>(result.Data);
                _isPreviewMode = true;
                _grid.DataSource = _previewRows;
                ConfigureSelectionColumn(false);
            }

            UiHelpers.ShowResult(result);
        }

        private void BtnTaoPhieu_Click(object sender, EventArgs e)
        {
            if (_isCreatingTuition)
            {
                return;
            }

            _isCreatingTuition = true;
            _btnTaoPhieu.Enabled = false;
            try
            {
                var result = Services.HocPhi.TaoYeuCauTheoLop(
                    UiHelpers.SelectedId(_cboHocVien),
                    _numSoTien.Value,
                    _txtNganHang.Text.Trim());

                UiHelpers.ShowResult(result);
                if (result.Success)
                {
                    LoadData();
                }
            }
            finally
            {
                _isCreatingTuition = false;
                _btnTaoPhieu.Enabled = true;
            }
        }

        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            var item = UiHelpers.SelectedItem<ThanhToanHocPhiDTO>(_grid);
            if (item == null) return;

            var result = Services.HocPhi.CapNhatTrangThai(item.MaThanhToan, Convert.ToString(_cboTrangThai.SelectedItem));
            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }

        private void CboHocVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private ThanhToanHocPhiDTO GetSelectedPayment()
        {
            var item = UiHelpers.SelectedItem<ThanhToanHocPhiDTO>(_grid);
            if (item == null)
            {
                UiHelpers.WarnSelect("phieu hoc phi");
            }

            return item;
        }

        private void BtnXemHoaDon_Click(object sender, EventArgs e)
        {
            var item = GetSelectedPayment();
            if (item == null) return;

            using (var form = new FrmHoaDonHocPhi(Services, CurrentUser, item.MaThanhToan))
            {
                form.ShowDialog(this);
            }
        }

        private void BtnXuatHoaDon_Click(object sender, EventArgs e)
        {
            var item = GetSelectedPayment();
            if (item == null) return;

            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                var result = Services.BaoCao.XuatHoaDonHocPhiHtml(item.MaThanhToan, dialog.SelectedPath);
                UiHelpers.ShowResult(result);
                if (result.Success)
                {
                    Process.Start(new ProcessStartInfo(result.Data) { UseShellExecute = true });
                }
            }
        }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            var item = GetSelectedPayment();
            if (item == null) return;

            using (var form = new FrmThanhToan(Services, CurrentUser, item.MaThanhToan))
            {
                if (form.ShowDialog(this) == DialogResult.OK || form.HasPaymentChanged)
                {
                    LoadData();
                }
            }
        }

        private void BtnGuiHocPhi_Click(object sender, EventArgs e)
        {
            var item = GetSelectedPayment();
            if (item == null) return;

            _btnGuiHocPhi.Enabled = false;
            try
            {
                var result = Services.Payment.GuiThongTinHocPhi(item.MaThanhToan);
                UiHelpers.ShowResult(result);
                if (result.Success)
                {
                    LoadData();
                }
            }
            finally
            {
                _btnGuiHocPhi.Enabled = true;
            }
        }

        private void ConfigureSelectionColumn(bool enabled)
        {
            var existing = _grid.Columns["colChonHocPhi"];
            if (existing != null)
            {
                _grid.Columns.Remove(existing);
            }

            _grid.ReadOnly = !enabled;
            _grid.MultiSelect = false;

            if (enabled)
            {
                var column = new DataGridViewCheckBoxColumn
                {
                    Name = "colChonHocPhi",
                    HeaderText = "Chọn",
                    Width = 55,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                    ReadOnly = false
                };
                _grid.Columns.Insert(0, column);

                foreach (DataGridViewColumn gridColumn in _grid.Columns)
                {
                    if (gridColumn.Name != "colChonHocPhi")
                    {
                        gridColumn.ReadOnly = true;
                    }
                }
            }

            SetBatchButtonsEnabled(enabled);
        }

        private void SetBatchButtonsEnabled(bool enabled)
        {
            if (_btnChonTatCa != null) _btnChonTatCa.Enabled = enabled;
            if (_btnBoChonTatCa != null) _btnBoChonTatCa.Enabled = enabled;
            if (_btnGuiHocPhiDaChon != null) _btnGuiHocPhiDaChon.Enabled = enabled;
        }

        private void Grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (_grid.IsCurrentCellDirty)
            {
                _grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void BtnChonTatCa_Click(object sender, EventArgs e)
        {
            SetAllVisibleSelections(true);
        }

        private void BtnBoChonTatCa_Click(object sender, EventArgs e)
        {
            SetAllVisibleSelections(false);
        }

        private void SetAllVisibleSelections(bool selected)
        {
            if (_isPreviewMode || _grid.Columns["colChonHocPhi"] == null)
            {
                return;
            }

            foreach (DataGridViewRow row in _grid.Rows)
            {
                if (row.Visible && row.DataBoundItem is ThanhToanHocPhiDTO)
                {
                    row.Cells["colChonHocPhi"].Value = selected;
                }
            }
        }

        private List<int> GetSelectedTuitionIds()
        {
            if (_grid.Columns["colChonHocPhi"] == null)
            {
                return new List<int>();
            }

            _grid.EndEdit();
            return _grid.Rows
                .Cast<DataGridViewRow>()
                .Where(row => row.Visible
                              && row.DataBoundItem is ThanhToanHocPhiDTO
                              && Convert.ToBoolean(row.Cells["colChonHocPhi"].Value ?? false))
                .Select(row => ((ThanhToanHocPhiDTO)row.DataBoundItem).MaThanhToan)
                .Distinct()
                .ToList();
        }

        private void BtnGuiHocPhiDaChon_Click(object sender, EventArgs e)
        {
            var selectedIds = GetSelectedTuitionIds();
            SetBatchButtonsEnabled(false);
            try
            {
                var result = Services.Payment.GuiHocPhiHangLoat(selectedIds);
                ShowBatchSendResult(result);
                if (result.Data != null)
                {
                    LoadData();
                }
            }
            finally
            {
                if (!_isPreviewMode)
                {
                    SetBatchButtonsEnabled(true);
                }
            }
        }

        private void ShowBatchSendResult(ServiceResult<BatchSendTuitionResultDTO> result)
        {
            if (result == null)
            {
                UiHelpers.ShowResult(ServiceResult.Fail("Lỗi không xác định."));
                return;
            }

            if (result.Data == null || result.Data.FailedCount == 0)
            {
                UiHelpers.ShowResult(result);
                return;
            }

            var builder = new StringBuilder();
            builder.AppendLine(result.Message);
            foreach (var item in result.Data.Items.Where(x => !x.Success))
            {
                builder.AppendLine(FormatBatchFailure(item));
            }

            MessageBox.Show(builder.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private static string FormatBatchFailure(BatchSendTuitionItemResultDTO item)
        {
            var name = string.IsNullOrWhiteSpace(item.HocVienName) ? "Học phí #" + item.HocPhiId : item.HocVienName;
            var email = string.IsNullOrWhiteSpace(item.Email) ? "thiếu email" : item.Email;
            var message = string.IsNullOrWhiteSpace(item.Message) ? "gửi email thất bại" : item.Message;
            return name + " - " + email + " - " + message;
        }
    }
}
