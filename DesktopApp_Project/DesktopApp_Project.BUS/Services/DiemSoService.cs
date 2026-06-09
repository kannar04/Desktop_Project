// Dịch vụ xử lý nghiệp vụ điểm số
// Chức năng:
// - Nhận dữ liệu từ giao diện dưới dạng đối tượng truyền dữ liệu hoặc tham số lọc
// - Kiểm tra nghiệp vụ trước khi gọi tầng dữ liệu
// - Trả kết quả xử lý hoặc danh sách đối tượng truyền dữ liệu cho giao diện

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DesktopApp_Project.Common;
using DesktopApp_Project.DAL;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.BUS
{
	// Lớp xử lý nghiệp vụ điểm số, kiểm tra dữ liệu trước khi gọi kho dữ liệu/tầng dữ liệu.
	public class DiemSoService : ServiceBase
	{
		public DiemSoService(IQuanLyIeltsRepository repository) : base(repository) { }

		// Lấy danh sách đợt kiểm tra của lớp.
		public List<DotKiemTraDTO> LayDotKiemTra(int maLopHoc)
		{
			// Lấy danh sách đợt kiểm tra của lớp qua tầng dữ liệu.
			return Repository.GetDotKiemTra(maLopHoc);
		}

		// Tạo đợt kiểm tra.
		public ServiceResult<int> TaoDotKiemTra(DotKiemTraDTO dto)
		{
			return Try(() =>
			{
				// Ràng buộc dữ liệu: chọn lớp và nhập tên đợt kiểm tra.
				if (dto.MaLopHoc <= 0 || ValidationHelper.IsBlank(dto.TenDotKiemTra))
				{
					return ServiceResult<int>.Fail("Vui lòng chọn lớp và nhập tên đợt kiểm tra.");
				}

				// Thêm đợt kiểm tra mới qua tầng dữ liệu.
				var id = Repository.InsertDotKiemTra(dto);
				return ServiceResult<int>.Ok(id, "Tạo đợt kiểm tra thành công.");
			});
		}

		// Lấy danh sách điểm số của đợt kiểm tra.
		public List<DiemSoDTO> LayDiemSo(int maDotKiemTra)
		{
			// Lấy danh sách điểm số của đợt kiểm tra qua tầng dữ liệu.
			return Repository.GetDiemSo(maDotKiemTra);
		}

		// Kiểm tra nghiệp vụ rồi gọi tầng dữ liệu để lưu dữ liệu điểm số.
		public ServiceResult LuuDiem(DiemSoDTO dto)
		{
			return Try(() =>
			{
				var scores = new[] { dto.DiemL, dto.DiemR, dto.DiemW, dto.DiemS, dto.DiemTong };
				// Ràng buộc dữ liệu: Điểm IELTS phải nằm trong khoảng 0 đến 9 và theo bước 0.5.
				if (scores.Any(x => !ValidationHelper.IsValidIeltsScore(x)))
				{
					return ServiceResult.Fail("Điểm IELTS phải nằm trong khoảng 0 đến 9 và theo bước 0.5.");
				}

				if (!dto.DiemTong.HasValue)
				{
					var parts = new[] { dto.DiemL, dto.DiemR, dto.DiemW, dto.DiemS }.Where(x => x.HasValue).Select(x => x.Value).ToList();
					if (parts.Count > 0)
					{
						dto.DiemTong = Math.Round(parts.Average() * 2m, MidpointRounding.AwayFromZero) / 2m;
					}
				}

				// Kiểm tra điểm số đã có của học viên trong đợt kiểm tra qua tầng dữ liệu.
				if (Repository.ExistsDiemSo(dto.MaNguoiDung, dto.MaDotKiemTra))
				{
					return ServiceResult.Fail("Học viên đã có điểm cho đợt kiểm tra này. PDF yêu cầu lưu lịch sử, không ghi đè điểm cũ.");
				}

				// Thêm điểm số mới cho học viên qua tầng dữ liệu.
				Repository.InsertDiemSo(dto);
				return ServiceResult.Ok("Lưu điểm thành công.");
			});
		}
	}
}