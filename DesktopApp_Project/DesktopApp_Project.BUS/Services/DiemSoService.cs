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
	public class DiemSoService : ServiceBase
	{
		public DiemSoService(IQuanLyIeltsRepository repository) : base(repository) { }

		public List<DotKiemTraDTO> LayDotKiemTra(int maLopHoc)
		{
			return Repository.GetDotKiemTra(maLopHoc);
		}

		public ServiceResult<int> TaoDotKiemTra(DotKiemTraDTO dto)
		{
			return Try(() =>
			{
				if (dto.MaLopHoc <= 0 || ValidationHelper.IsBlank(dto.TenDotKiemTra))
				{
					return ServiceResult<int>.Fail("Vui lòng chọn lớp và nhập tên đợt kiểm tra.");
				}

				var id = Repository.InsertDotKiemTra(dto);
				return ServiceResult<int>.Ok(id, "Tạo đợt kiểm tra thành công.");
			});
		}

		public List<DiemSoDTO> LayDiemSo(int maDotKiemTra)
		{
			return Repository.GetDiemSo(maDotKiemTra);
		}

		public ServiceResult LuuDiem(DiemSoDTO dto)
		{
			return Try(() =>
			{
				var scores = new[] { dto.DiemL, dto.DiemR, dto.DiemW, dto.DiemS, dto.DiemTong };
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

				if (Repository.ExistsDiemSo(dto.MaNguoiDung, dto.MaDotKiemTra))
				{
					return ServiceResult.Fail("Học viên đã có điểm cho đợt kiểm tra này. PDF yêu cầu lưu lịch sử, không ghi đè điểm cũ.");
				}

				Repository.InsertDiemSo(dto);
				return ServiceResult.Ok("Lưu điểm thành công.");
			});
		}
	}
}