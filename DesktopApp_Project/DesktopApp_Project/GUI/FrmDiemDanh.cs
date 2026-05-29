using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public partial class FrmDiemDanh : ModuleFormBase
    {
        private BindingList<DiemDanhDTO> _rows = new BindingList<DiemDanhDTO>();

        public FrmDiemDanh()
        {
            InitializeComponent();
            WireEvents();
        }

        public FrmDiemDanh(ServiceFactory services, NguoiDungDTO currentUser)
            : this()
        {
            SetRuntimeContext(services, currentUser);
        }

        private void WireEvents()
        {
            WireClick(btnTai, BtnTai_Click);
            WireClick(btnLuu, BtnLuu_Click);
        }

        protected override void OnRuntimeLoad()
        {
            ConfigureGrid();
            ConfigureActions();
            UiHelpers.BindLopHoc(_cboLop, Services);
            LoadData();
        }

        private void ConfigureActions()
        {
            bottom.Controls.Clear();
            btnLuu.Text = "Lưu tất cả";
            btnLuu.Width = 130;
            bottom.Controls.Add(btnLuu);
        }

        private void ConfigureGrid()
        {
            _grid.AutoGenerateColumns = false;
            _grid.ReadOnly = false;
            _grid.AllowUserToAddRows = false;
            _grid.AllowUserToDeleteRows = false;
            _grid.Columns.Clear();

            _grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaNguoiDung",
                HeaderText = "Mã",
                Visible = false
            });
            _grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HoTen",
                HeaderText = "Học viên",
                ReadOnly = true,
                FillWeight = 180
            });
            _grid.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "CoMat",
                HeaderText = "Có mặt",
                FillWeight = 60
            });
            _grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TiLeChuyenCan",
                HeaderText = "Chuyên cần (%)",
                ReadOnly = true,
                FillWeight = 80,
                DefaultCellStyle = { Format = "0.##" }
            });
        }

        private void LoadData()
        {
            var result = SafeLoad(() => Services.DiemDanh.LayBangDiemDanh(UiHelpers.SelectedId(_cboLop), _dtNgay.Value), null);
            if (result == null)
            {
                return;
            }

            if (result.Success)
            {
                _rows = new BindingList<DiemDanhDTO>(result.Data);
                _grid.DataSource = _rows;
            }
            else
            {
                UiHelpers.ShowResult(result);
            }
        }

        private void BtnTai_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            _grid.EndEdit();
            var result = Services.DiemDanh.LuuTatCa(_rows.ToList());
            UiHelpers.ShowResult(result);
            if (result.Success) LoadData();
        }
    }
}
