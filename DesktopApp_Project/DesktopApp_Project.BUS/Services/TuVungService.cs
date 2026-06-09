// Dịch vụ xử lý nghiệp vụ từ vựng và flashcard
// Chức năng:
// - Nhận dữ liệu từ giao diện dưới dạng đối tượng truyền dữ liệu hoặc tham số lọc
// - Kiểm tra nghiệp vụ trước khi gọi tầng dữ liệu
// - Trả kết quả xử lý hoặc danh sách đối tượng truyền dữ liệu cho giao diện

using System;
using System.Collections.Generic;
using System.Linq;
using DesktopApp_Project.Common;
using DesktopApp_Project.DAL;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.BUS
{
	// Lớp xử lý nghiệp vụ từ vựng và flashcard, kiểm tra dữ liệu trước khi gọi kho dữ liệu/tầng dữ liệu.
	public class TuVungService : ServiceBase
	{
		public TuVungService(IQuanLyIeltsRepository repository) : base(repository) { }

		// Lấy danh sách.
		public List<TuVungDTO> LayDanhSach(int? maLopHoc)
		{
			// Lấy danh sách từ vựng theo lớp qua tầng dữ liệu.
			return Repository.GetTuVung(maLopHoc);
		}

		// Tìm kiếm từ vựng và flashcard theo tiêu chí nhận từ giao diện.
		public List<TuVungDTO> TimKiem(TuVungSearchCriteriaDTO criteria)
		{
			// Tìm kiếm từ vựng theo tiêu chí tìm kiếm qua tầng dữ liệu.
			return Repository.SearchTuVung(criteria);
		}

		// Tìm kiếm từ vựng và flashcard theo tiêu chí nhận từ giao diện.
		public ServiceResult<List<TuVungDTO>> TimKiemNangCao(
			int? maLopHoc,
			List<SearchConditionDTO> conditions,
			SearchJoinOperator joinOperator)
		{
			return Try(() =>
			{
				// Ràng buộc dữ liệu: chọn lớp.
				if (!maLopHoc.HasValue || maLopHoc.Value <= 0)
				{
					return ServiceResult<List<TuVungDTO>>.Fail("Vui lòng chọn lớp.");
				}

				var normalized = NormalizeAdvancedConditions(conditions);
				if (normalized.Count == 0)
				{
					return ServiceResult<List<TuVungDTO>>.Fail("Vui lòng thêm ít nhất một điều kiện tìm kiếm.");
				}

				foreach (var condition in normalized)
				{
					var validation = ValidateAdvancedCondition(condition);
					if (!string.IsNullOrWhiteSpace(validation))
					{
						return ServiceResult<List<TuVungDTO>>.Fail(validation);
					}
				}

				// Lấy danh sách từ vựng theo lớp qua tầng dữ liệu.
				var rows = Repository.GetTuVung(maLopHoc.Value);
				var result = joinOperator == SearchJoinOperator.Or
					? rows.Where(row => normalized.Any(condition => MatchesCondition(row, condition))).ToList()
					: rows.Where(row => MatchesAllConditionGroups(row, normalized)).ToList();

				return ServiceResult<List<TuVungDTO>>.Ok(result.OrderBy(x => x.TuTiengAnh).ToList(), "Đã tìm kiếm từ vựng nâng cao.");
			});
		}

		// Tìm kiếm từ vựng và flashcard theo tiêu chí nhận từ giao diện.
		public ServiceResult<List<TuVungDTO>> TimKiemNangCao(
			int? maLopHoc,
			List<SearchConditionDTO> conditions)
		{
			return Try(() =>
			{
				// Ràng buộc dữ liệu: chọn lớp.
				if (!maLopHoc.HasValue || maLopHoc.Value <= 0)
				{
					return ServiceResult<List<TuVungDTO>>.Fail("Vui lòng chọn lớp.");
				}

				var normalized = NormalizeAdvancedConditions(conditions);
				if (normalized.Count == 0)
				{
					return ServiceResult<List<TuVungDTO>>.Fail("Vui lòng thêm ít nhất một điều kiện tìm kiếm.");
				}

				foreach (var condition in normalized)
				{
					var validation = ValidateAdvancedCondition(condition);
					if (!string.IsNullOrWhiteSpace(validation))
					{
						return ServiceResult<List<TuVungDTO>>.Fail(validation);
					}
				}

				var parenthesesValidation = AutoCloseParentheses(normalized);
				if (!string.IsNullOrWhiteSpace(parenthesesValidation))
				{
					return ServiceResult<List<TuVungDTO>>.Fail(parenthesesValidation);
				}

				// Lấy danh sách từ vựng theo lớp qua tầng dữ liệu.
				var rows = Repository.GetTuVung(maLopHoc.Value);
				var result = rows
					.Where(row => MatchesConditionExpression(row, normalized))
					.OrderBy(x => x.TuTiengAnh)
					.ToList();

				return ServiceResult<List<TuVungDTO>>.Ok(result, "Đã tìm kiếm từ vựng nâng cao.");
			});
		}

		// Lấy danh sách flashcard.
		public ServiceResult<List<TuVungDTO>> LayDanhSachFlashcard(TuVungSearchCriteriaDTO criteria)
		{
			return Try(() =>
			{
				// Tìm kiếm từ vựng theo tiêu chí tìm kiếm qua tầng dữ liệu.
				var rows = Repository.SearchTuVung(criteria ?? new TuVungSearchCriteriaDTO());
				return ServiceResult<List<TuVungDTO>>.Ok(rows, "Tai danh sach flashcard thanh cong.");
			});
		}

		// Ghi nhận flashcard đã học.
		public ServiceResult GhiNhanFlashcardDaHoc(int maNguoiDung, int maTuVung)
		{
			return Try(() =>
			{
				// Ràng buộc dữ liệu: Không có thông tin người dùng hoặc từ vựng.
				if (maNguoiDung <= 0 || maTuVung <= 0)
				{
					return ServiceResult.Fail("Khong co thong tin nguoi dung hoac tu vung.");
				}

				// Lưu tiến trình học flashcard qua tầng dữ liệu.
				Repository.UpsertTienTrinhFlashcard(maNguoiDung, maTuVung, "Đã học");
				return ServiceResult.Ok("Da cap nhat tien trinh flashcard.");
			});
		}

		// Kiểm tra nghiệp vụ rồi gọi tầng dữ liệu để lưu dữ liệu từ vựng và flashcard.
		public ServiceResult Luu(TuVungDTO dto)
		{
			return Try(() =>
			{
				if (ValidationHelper.IsBlank(dto.CapDo))
				{
					dto.CapDo = "B1";
				}

				// Ràng buộc dữ liệu: nhập đầy đủ thông tin từ vựng.
				if (ValidationHelper.IsBlank(dto.ChuDe))
				{
					dto.ChuDe = "Academic/IELTS General";
				}

				// Ràng buộc dữ liệu: nhập đầy đủ thông tin từ vựng.
				if (dto.MaLopHoc <= 0 || ValidationHelper.IsBlank(dto.TuTiengAnh) ||
					ValidationHelper.IsBlank(dto.TuLoai) || ValidationHelper.IsBlank(dto.PhienAm) ||
					ValidationHelper.IsBlank(dto.Nghia))
				{
					return ServiceResult.Fail("Vui lòng nhập đầy đủ thông tin từ vựng.");
				}

				if (!AppConstants.CefrLevels.Contains(dto.CapDo))
				{
					return ServiceResult.Fail("Cấp độ CEFR không hợp lệ.");
				}

				// Kiểm tra từ vựng bị trùng trong lớp qua tầng dữ liệu.
				if (Repository.ExistsTuVungTrongLop(dto.TuTiengAnh.Trim(), dto.MaLopHoc, dto.MaTuVung))
				{
					return ServiceResult.Fail("Từ vựng đã tồn tại trong lớp này.");
				}

				if (dto.MaTuVung == 0)
				{
					// Thêm từ vựng mới qua tầng dữ liệu.
					var maTuVung = Repository.InsertTuVung(dto);
					// Đồng bộ flashcard của lớp theo từ vựng qua tầng dữ liệu.
					Repository.DongBoFlashcardChoLop(maTuVung, dto.MaLopHoc);
					return ServiceResult.Ok("Thêm từ vựng thành công và đã đồng bộ Flashcard.");
				}

				// Cập nhật thông tin từ vựng qua tầng dữ liệu.
				Repository.UpdateTuVung(dto);
				return ServiceResult.Ok("Cập nhật từ vựng thành công.");
			});
		}

		// Gọi tầng dữ liệu để xóa dữ liệu từ vựng và flashcard sau khi giao diện xác nhận.
		public ServiceResult Xoa(int maTuVung)
		{
			return Try(() =>
			{
				// Xóa từ vựng đã chọn qua tầng dữ liệu.
				Repository.DeleteTuVung(maTuVung);
				return ServiceResult.Ok("Xóa từ vựng thành công.");
			});
		}

		// Chuẩn hóa điều kiện tìm kiếm nâng caos.
		private static List<SearchConditionDTO> NormalizeAdvancedConditions(IEnumerable<SearchConditionDTO> conditions)
		{
			return (conditions ?? Enumerable.Empty<SearchConditionDTO>())
				.Where(x => x != null)
				.Select(x => new SearchConditionDTO
				{
					Field = SafeText(x.Field),
					Value = SafeText(Convert.ToString(x.Value)),
					JoinOperator = x.JoinOperator,
					OpenParentheses = Math.Max(0, x.OpenParentheses),
					CloseParentheses = Math.Max(0, x.CloseParentheses)
				})
				.Where(x => !string.IsNullOrWhiteSpace(x.Field)
							|| !string.IsNullOrWhiteSpace(Convert.ToString(x.Value)))
				.ToList();
		}

		// Kiểm tra điều kiện tìm kiếm nâng cao.
		private static string ValidateAdvancedCondition(SearchConditionDTO condition)
		{
			if (string.IsNullOrWhiteSpace(condition.Field))
			{
				return "Vui lòng chọn trường cần tìm kiếm.";
			}

			if (string.IsNullOrWhiteSpace(Convert.ToString(condition.Value)))
			{
				return "Vui lòng nhập hoặc chọn giá trị tìm kiếm.";
			}

			if (!IsSupportedField(condition.Field))
			{
				return "Vui lòng chọn trường cần tìm kiếm.";
			}

			return string.Empty;
		}

		// Xử lý định dạng tệp được hỗ trợ field.
		private static bool IsSupportedField(string field)
		{
			return field == "Keyword"
				|| field == "ChuDe"
				|| field == "ChuCaiDau"
				|| field == "CapDo"
				|| field == "TuLoai";
		}

		// Tự bổ sung ngoặc đóng còn thiếu trong biểu thức tìm kiếm nâng cao.
		private static string AutoCloseParentheses(List<SearchConditionDTO> conditions)
		{
			var balance = 0;
			foreach (var condition in conditions)
			{
				balance += condition.OpenParentheses;
				balance -= condition.CloseParentheses;
				if (balance < 0)
				{
					return "Biểu thức ngoặc không hợp lệ.";
				}
			}

			if (balance > 0 && conditions.Count > 0)
			{
				conditions[conditions.Count - 1].CloseParentheses += balance;
			}

			return string.Empty;
		}

		// Xử lý matches condition expression.
		private static bool MatchesConditionExpression(TuVungDTO row, List<SearchConditionDTO> conditions)
		{
			return new SearchExpressionParser(BuildExpressionTokens(row, conditions)).Evaluate();
		}

		// Tạo expression tokens.
		private static List<SearchExpressionToken> BuildExpressionTokens(TuVungDTO row, List<SearchConditionDTO> conditions)
		{
			var tokens = new List<SearchExpressionToken>();
			for (var i = 0; i < conditions.Count; i++)
			{
				var condition = conditions[i];
				if (i > 0)
				{
					tokens.Add(new SearchExpressionToken(
						condition.JoinOperator == SearchJoinOperator.Or
							? SearchExpressionTokenType.Or
							: SearchExpressionTokenType.And));
				}

				for (var open = 0; open < condition.OpenParentheses; open++)
				{
					tokens.Add(new SearchExpressionToken(SearchExpressionTokenType.OpenParenthesis));
				}

				tokens.Add(new SearchExpressionToken(MatchesCondition(row, condition)));

				for (var close = 0; close < condition.CloseParentheses; close++)
				{
					tokens.Add(new SearchExpressionToken(SearchExpressionTokenType.CloseParenthesis));
				}
			}

			return tokens;
		}

		// Xử lý matches tất cả condition groups.
		private static bool MatchesAllConditionGroups(TuVungDTO row, List<SearchConditionDTO> conditions)
		{
			// Lọc học viên theo từ khóa họ tên, tài khoản hoặc thư điện tử.
			var keywordConditions = conditions.Where(x => x.Field == "Keyword").ToList();
			// Lọc học viên theo từ khóa họ tên, tài khoản hoặc thư điện tử.
			if (keywordConditions.Any(condition => !MatchesCondition(row, condition)))
			{
				return false;
			}

			return conditions
				// Lọc học viên theo từ khóa họ tên, tài khoản hoặc thư điện tử.
				.Where(x => x.Field != "Keyword")
				// Lọc học viên theo từ khóa họ tên, tài khoản hoặc thư điện tử.
				.GroupBy(x => x.Field)
				.All(group => group.Any(condition => MatchesCondition(row, condition)));
		}

		// Xử lý matches condition.
		private static bool MatchesCondition(TuVungDTO row, SearchConditionDTO condition)
		{
			var value = Convert.ToString(condition.Value);
			if (condition.Field == "Keyword")
			{
				return Contains(row.TuTiengAnh, value)
					|| Contains(row.Nghia, value);
			}

			if (condition.Field == "ChuDe")
			{
				return EqualsText(row.ChuDe, value);
			}

			if (condition.Field == "ChuCaiDau")
			{
				return StartsWith(row.TuTiengAnh, value);
			}

			if (condition.Field == "CapDo")
			{
				return EqualsText(row.CapDo, value);
			}

			if (condition.Field == "TuLoai")
			{
				return EqualsText(row.TuLoai, value);
			}

			return false;
		}

		// Xử lý contains.
		private static bool Contains(string source, string value)
		{
			return !string.IsNullOrWhiteSpace(source)
				&& !string.IsNullOrWhiteSpace(value)
				&& source.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0;
		}

		// Kiểm tra chuỗi bắt đầu bằng giá trị cần so khớp.
		private static bool StartsWith(string source, string value)
		{
			return !string.IsNullOrWhiteSpace(source)
				&& !string.IsNullOrWhiteSpace(value)
				&& source.Trim().StartsWith(value.Trim(), StringComparison.OrdinalIgnoreCase);
		}

		// Xử lý equals text.
		private static bool EqualsText(string source, string value)
		{
			return string.Equals(SafeText(source), SafeText(value), StringComparison.OrdinalIgnoreCase);
		}

		// Xử lý safe text.
		private static string SafeText(string value)
		{
			return string.IsNullOrWhiteSpace(value) ? string.Empty : value.Trim();
		}

		// Kiểu liệt kê biểu diễn loại phần tử biểu thức tìm kiếm dùng trong luồng xử lý nghiệp vụ.
		private enum SearchExpressionTokenType
		{
			Condition,
			And,
			Or,
			OpenParenthesis,
			CloseParenthesis
		}

		// Lớp hỗ trợ lưu trạng thái phần tử biểu thức tìm kiếm trong quá trình xử lý nghiệp vụ.
		private class SearchExpressionToken
		{
			// Khởi tạo đối tượng phần tử biểu thức tìm kiếm phục vụ luồng xử lý nội bộ.
			public SearchExpressionToken(SearchExpressionTokenType type)
			{
				Type = type;
			}

			// Khởi tạo đối tượng phần tử biểu thức tìm kiếm phục vụ luồng xử lý nội bộ.
			public SearchExpressionToken(bool value)
			{
				Type = SearchExpressionTokenType.Condition;
				Value = value;
			}

			public SearchExpressionTokenType Type { get; private set; }
			public bool Value { get; private set; }
		}

		// Lớp hỗ trợ lưu trạng thái bộ phân tích biểu thức tìm kiếm trong quá trình xử lý nghiệp vụ.
		private class SearchExpressionParser
		{
			private readonly List<SearchExpressionToken> _tokens;
			private int _index;

			// Khởi tạo đối tượng bộ phân tích biểu thức tìm kiếm phục vụ luồng xử lý nội bộ.
			public SearchExpressionParser(List<SearchExpressionToken> tokens)
			{
				_tokens = tokens ?? new List<SearchExpressionToken>();
			}

			// Xử lý evaluate.
			public bool Evaluate()
			{
				if (_tokens.Count == 0)
				{
					return false;
				}

				return ParseOr();
			}

			// Phân tích biểu thức điều kiện với toán tử OR.
			private bool ParseOr()
			{
				var result = ParseAnd();
				while (Match(SearchExpressionTokenType.Or))
				{
					var right = ParseAnd();
					result = result || right;
				}

				return result;
			}

			// Phân tích biểu thức điều kiện với toán tử AND.
			private bool ParseAnd()
			{
				var result = ParsePrimary();
				while (Match(SearchExpressionTokenType.And))
				{
					var right = ParsePrimary();
					result = result && right;
				}

				return result;
			}

			// Phân tích điều kiện đơn hoặc nhóm điều kiện trong ngoặc.
			private bool ParsePrimary()
			{
				if (Match(SearchExpressionTokenType.OpenParenthesis))
				{
					var result = ParseOr();
					Match(SearchExpressionTokenType.CloseParenthesis);
					return result;
				}

				if (_index < _tokens.Count && _tokens[_index].Type == SearchExpressionTokenType.Condition)
				{
					return _tokens[_index++].Value;
				}

				return false;
			}

			// Xử lý match.
			private bool Match(SearchExpressionTokenType type)
			{
				if (_index >= _tokens.Count || _tokens[_index].Type != type)
				{
					return false;
				}

				_index++;
				return true;
			}
		}
	}
}
