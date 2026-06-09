// Biểu mẫu quản lý điểm số
// Chức năng:
// - Hiển thị và nhập dữ liệu điểm số
// - Gọi tầng nghiệp vụ để tải, lưu hoặc xóa dữ liệu
// - Cập nhật trạng thái giao diện sau thao tác của người dùng

using System;
using DesktopApp_Project.BUS;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
	// Lớp biểu mẫu Windows Forms chịu trách nhiệm hiển thị điểm số và gọi tầng nghiệp vụ khi người dùng thao tác.
	public partial class FrmDiemSo : ModuleFormBase
	{
		public FrmDiemSo()
		{
			InitializeComponent();
			WireEvents();
		}

		public FrmDiemSo(ServiceFactory services, NguoiDungDTO currentUser)
			: this()
		{
			SetRuntimeContext(services, currentUser);
		}

		// Đăng ký các hàm xử lý sự kiện cho điều khiển trên biểu mẫu.
		private void WireEvents()
		{
			WireClick(btnTaoDot, BtnTaoDot_Click);
			WireClick(btnTai, BtnTai_Click);
			WireClick(btnLuu, BtnLuu_Click);
			WireSelectedIndexChanged(_cboLop, CboLop_SelectedIndexChanged);
			WireSelectedIndexChanged(_cboDot, CboDot_SelectedIndexChanged);
		}

		// Nạp dữ liệu và thiết lập trạng thái ban đầu khi biểu mẫu được mở.
		protected override void OnRuntimeLoad()
		{
			UiHelpers.BindLopHoc(_cboLop, Services);
			LoadRoundsAndStudents();
		}

		// Lấy đợt kiểm tra và danh sách học viên.
		private void LoadRoundsAndStudents()
		{
			var maLop = UiHelpers.SelectedId(_cboLop);
			if (maLop <= 0) return;

			// Nạp danh sách học viên trong lớp vào bảng học viên.
			_gridHocVien.DataSource = SafeLoad<object>(() => Services.LopHoc.LayHocVienTrongLop(maLop), null);
			// Nạp danh sách đợt kiểm tra của lớp vào ô chọn đợt kiểm tra.
			_cboDot.DataSource = SafeLoad<object>(() => Services.DiemSo.LayDotKiemTra(maLop), null);
			_cboDot.DisplayMember = "TenDotKiemTra";
			_cboDot.ValueMember = "MaDotKiemTra";
			LoadScores();
		}

		// Xử lý sự kiện người dùng nhấn nút Tạo đợt.
		private void BtnTaoDot_Click(object sender, EventArgs e)
		{
			// Gọi tầng nghiệp vụ để tạo đợt kiểm tra.
			var result = Services.DiemSo.TaoDotKiemTra(new DotKiemTraDTO
			{
				MaLopHoc = UiHelpers.SelectedId(_cboLop),
				TenDotKiemTra = _txtTenDot.Text.Trim(),
				NgayKiemTra = _dtNgay.Value.Date
			});

			UiHelpers.ShowResult(result);
			if (result.Success) LoadRoundsAndStudents();
		}

		// Lấy điểm số.
		private void LoadScores()
		{
			var maDot = UiHelpers.SelectedId(_cboDot);
			if (maDot > 0)
			{
				// Nạp danh sách điểm số của đợt kiểm tra vào bảng điểm.
				_gridDiem.DataSource = SafeLoad<object>(() => Services.DiemSo.LayDiemSo(maDot), null);
			}
			else
			{
				// Cập nhật dữ liệu hiển thị trên bảng điểm.
				_gridDiem.DataSource = null;
			}
		}

		// Xử lý sự kiện người dùng nhấn nút Tải.
		private void BtnTai_Click(object sender, EventArgs e)
		{
			LoadScores();
		}

		// Xử lý sự kiện người dùng nhấn nút Lưu.
		private void BtnLuu_Click(object sender, EventArgs e)
		{
			var hv = UiHelpers.SelectedItem<NguoiDungDTO>(_gridHocVien);
			if (hv == null) return;

			// Gọi tầng nghiệp vụ để lưu điểm số của học viên.
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

		// Xử lý khi người dùng thay đổi lựa chọn trên bộ lọc hoặc combobox.
		private void CboLop_SelectedIndexChanged(object sender, EventArgs e)
		{
			LoadRoundsAndStudents();
		}

		// Xử lý khi người dùng thay đổi lựa chọn trên bộ lọc hoặc combobox.
		private void CboDot_SelectedIndexChanged(object sender, EventArgs e)
		{
			LoadScores();
		}
	}
}