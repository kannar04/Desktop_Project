using System;
using System.Collections.Generic;
using System.Linq;
using DesktopApp_Project.Common;
using DesktopApp_Project.DAL;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.BUS
{
    public class TuVungService : ServiceBase
    {
        public TuVungService(IQuanLyIeltsRepository repository) : base(repository) { }

        public List<TuVungDTO> LayDanhSach(int? maLopHoc)
        {
            return Repository.GetTuVung(maLopHoc);
        }

        public List<TuVungDTO> TimKiem(TuVungSearchCriteriaDTO criteria)
        {
            return Repository.SearchTuVung(criteria);
        }

        public ServiceResult<List<TuVungDTO>> TimKiemNangCao(
            int? maLopHoc,
            List<SearchConditionDTO> conditions,
            SearchJoinOperator joinOperator)
        {
            return Try(() =>
            {
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

                var rows = Repository.GetTuVung(maLopHoc.Value);
                var result = joinOperator == SearchJoinOperator.Or
                    ? rows.Where(row => normalized.Any(condition => MatchesCondition(row, condition))).ToList()
                    : rows.Where(row => MatchesAllConditionGroups(row, normalized)).ToList();

                return ServiceResult<List<TuVungDTO>>.Ok(result.OrderBy(x => x.TuTiengAnh).ToList(), "Đã tìm kiếm từ vựng nâng cao.");
            });
        }

        public ServiceResult<List<TuVungDTO>> TimKiemNangCao(
            int? maLopHoc,
            List<SearchConditionDTO> conditions)
        {
            return Try(() =>
            {
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

                var rows = Repository.GetTuVung(maLopHoc.Value);
                var result = rows
                    .Where(row => MatchesConditionExpression(row, normalized))
                    .OrderBy(x => x.TuTiengAnh)
                    .ToList();

                return ServiceResult<List<TuVungDTO>>.Ok(result, "Đã tìm kiếm từ vựng nâng cao.");
            });
        }

        public ServiceResult<List<TuVungDTO>> LayDanhSachFlashcard(TuVungSearchCriteriaDTO criteria)
        {
            return Try(() =>
            {
                var rows = Repository.SearchTuVung(criteria ?? new TuVungSearchCriteriaDTO());
                return ServiceResult<List<TuVungDTO>>.Ok(rows, "Tai danh sach flashcard thanh cong.");
            });
        }

        public ServiceResult GhiNhanFlashcardDaHoc(int maNguoiDung, int maTuVung)
        {
            return Try(() =>
            {
                if (maNguoiDung <= 0 || maTuVung <= 0)
                {
                    return ServiceResult.Fail("Khong co thong tin nguoi dung hoac tu vung.");
                }

                Repository.UpsertTienTrinhFlashcard(maNguoiDung, maTuVung, "Đã học");
                return ServiceResult.Ok("Da cap nhat tien trinh flashcard.");
            });
        }

        public ServiceResult Luu(TuVungDTO dto)
        {
            return Try(() =>
            {
                if (ValidationHelper.IsBlank(dto.CapDo))
                {
                    dto.CapDo = "B1";
                }

                if (ValidationHelper.IsBlank(dto.ChuDe))
                {
                    dto.ChuDe = "Academic/IELTS General";
                }

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

                if (Repository.ExistsTuVungTrongLop(dto.TuTiengAnh.Trim(), dto.MaLopHoc, dto.MaTuVung))
                {
                    return ServiceResult.Fail("Từ vựng đã tồn tại trong lớp này.");
                }

                if (dto.MaTuVung == 0)
                {
                    var maTuVung = Repository.InsertTuVung(dto);
                    Repository.DongBoFlashcardChoLop(maTuVung, dto.MaLopHoc);
                    return ServiceResult.Ok("Thêm từ vựng thành công và đã đồng bộ Flashcard.");
                }

                Repository.UpdateTuVung(dto);
                return ServiceResult.Ok("Cập nhật từ vựng thành công.");
            });
        }

        public ServiceResult Xoa(int maTuVung)
        {
            return Try(() =>
            {
                Repository.DeleteTuVung(maTuVung);
                return ServiceResult.Ok("Xóa từ vựng thành công.");
            });
        }

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

        private static bool IsSupportedField(string field)
        {
            return field == "Keyword"
                || field == "ChuDe"
                || field == "ChuCaiDau"
                || field == "CapDo"
                || field == "TuLoai";
        }

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

        private static bool MatchesConditionExpression(TuVungDTO row, List<SearchConditionDTO> conditions)
        {
            return new SearchExpressionParser(BuildExpressionTokens(row, conditions)).Evaluate();
        }

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

        private static bool MatchesAllConditionGroups(TuVungDTO row, List<SearchConditionDTO> conditions)
        {
            var keywordConditions = conditions.Where(x => x.Field == "Keyword").ToList();
            if (keywordConditions.Any(condition => !MatchesCondition(row, condition)))
            {
                return false;
            }

            return conditions
                .Where(x => x.Field != "Keyword")
                .GroupBy(x => x.Field)
                .All(group => group.Any(condition => MatchesCondition(row, condition)));
        }

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

        private static bool Contains(string source, string value)
        {
            return !string.IsNullOrWhiteSpace(source)
                && !string.IsNullOrWhiteSpace(value)
                && source.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private static bool StartsWith(string source, string value)
        {
            return !string.IsNullOrWhiteSpace(source)
                && !string.IsNullOrWhiteSpace(value)
                && source.Trim().StartsWith(value.Trim(), StringComparison.OrdinalIgnoreCase);
        }

        private static bool EqualsText(string source, string value)
        {
            return string.Equals(SafeText(source), SafeText(value), StringComparison.OrdinalIgnoreCase);
        }

        private static string SafeText(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? string.Empty : value.Trim();
        }

        private enum SearchExpressionTokenType
        {
            Condition,
            And,
            Or,
            OpenParenthesis,
            CloseParenthesis
        }

        private class SearchExpressionToken
        {
            public SearchExpressionToken(SearchExpressionTokenType type)
            {
                Type = type;
            }

            public SearchExpressionToken(bool value)
            {
                Type = SearchExpressionTokenType.Condition;
                Value = value;
            }

            public SearchExpressionTokenType Type { get; private set; }
            public bool Value { get; private set; }
        }

        private class SearchExpressionParser
        {
            private readonly List<SearchExpressionToken> _tokens;
            private int _index;

            public SearchExpressionParser(List<SearchExpressionToken> tokens)
            {
                _tokens = tokens ?? new List<SearchExpressionToken>();
            }

            public bool Evaluate()
            {
                if (_tokens.Count == 0)
                {
                    return false;
                }

                return ParseOr();
            }

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
