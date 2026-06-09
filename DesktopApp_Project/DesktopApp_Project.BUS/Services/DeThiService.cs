// Dịch vụ xử lý nghiệp vụ đề thi IELTS
// Chức năng:
// - Nhận dữ liệu từ giao diện dưới dạng đối tượng truyền dữ liệu hoặc tham số lọc
// - Kiểm tra nghiệp vụ trước khi gọi tầng dữ liệu
// - Trả kết quả xử lý hoặc danh sách đối tượng truyền dữ liệu cho giao diện

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.FileIO;
using DesktopApp_Project.Common;
using DesktopApp_Project.DAL;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.BUS
{
	// Lớp xử lý nghiệp vụ đề thi IELTS, kiểm tra dữ liệu trước khi gọi kho dữ liệu/tầng dữ liệu.
	public class DeThiService : ServiceBase
	{
		public DeThiService(IQuanLyIeltsRepository repository) : base(repository) { }

		// Lấy đề thi.
		public List<DeThiDTO> LayDeThi()
		{
			// Lấy danh sách đề thi qua tầng dữ liệu.
			return Repository.GetDeThi();
		}

		// Kiểm tra nghiệp vụ rồi gọi tầng dữ liệu để lưu dữ liệu đề thi IELTS.
		public ServiceResult Luu(DeThiDTO dto)
		{
			return Try(() =>
			{
				dto = dto ?? new DeThiDTO();
				dto.KyNang = NormalizeSkill(dto.KyNang);

				// Ràng buộc dữ liệu: Vui lòng nhập tên đề thi.
				if (ValidationHelper.IsBlank(dto.TenDeThi))
				{
					return ServiceResult.Fail("Vui long nhap ten de thi.");
				}

				// Ràng buộc dữ liệu: Kỹ năng phải là Listening, Reading, Writing hoặc Speaking.
				if (!ValidationHelper.IsValidSkill(dto.KyNang))
				{
					return ServiceResult.Fail("Ky nang phai la Listening, Reading, Writing hoac Speaking.");
				}

				// Ràng buộc dữ liệu: Band phải nằm trong khoảng 0 đến 9 và theo bước 0.5.
				if (!ValidationHelper.IsValidIeltsScore(dto.BandLevel)
					|| !ValidationHelper.IsValidIeltsScore(dto.BandTu)
					|| !ValidationHelper.IsValidIeltsScore(dto.BandDen))
				{
					return ServiceResult.Fail("Band phai nam trong khoang 0 den 9 va theo buoc 0.5.");
				}

				if (dto.BandTu.HasValue && dto.BandDen.HasValue && dto.BandTu.Value > dto.BandDen.Value)
				{
					return ServiceResult.Fail("Band bat dau khong duoc lon hon band ket thuc.");
				}

				if (!IsSupportedDocument(dto.FileDuLieu))
				{
					return ServiceResult.Fail("File de thi chi ho tro .pdf, .doc, .docx, .xlsx.");
				}

				if (!IsSupportedAudio(dto.AudioPath))
				{
					return ServiceResult.Fail("Audio chi ho tro .mp3 hoac .wav.");
				}

				if (!IsSupportedImage(dto.ImagePath))
				{
					return ServiceResult.Fail("Anh chi ho tro .jpg, .jpeg hoac .png.");
				}

				// Ràng buộc dữ liệu: Đề Listening bắt buộc phải có âm thanh.
				if (dto.KyNang == "Listening" && string.IsNullOrWhiteSpace(dto.AudioPath))
				{
					return ServiceResult.Fail("De Listening bat buoc phai co audio.");
				}

				dto.TrangThai = string.IsNullOrWhiteSpace(dto.TrangThai) ? "DangTao" : dto.TrangThai.Trim();
				if (dto.MaDeThi == 0)
				{
					// Thêm đề thi mới qua tầng dữ liệu.
					Repository.InsertDeThi(dto);
					return ServiceResult.Ok("Them de thi thanh cong.");
				}

				// Cập nhật thông tin đề thi qua tầng dữ liệu.
				Repository.UpdateDeThi(dto);
				return ServiceResult.Ok("Cap nhat de thi thanh cong.");
			});
		}

		// Gọi tầng dữ liệu để xóa dữ liệu đề thi IELTS sau khi giao diện xác nhận.
		public ServiceResult Xoa(int maDeThi)
		{
			return Try(() =>
			{
				// Ràng buộc dữ liệu: Vui lòng chọn đề thi.
				if (maDeThi <= 0)
				{
					return ServiceResult.Fail("Vui long chon de thi.");
				}

				// Xóa đề thi đã chọn qua tầng dữ liệu.
				Repository.DeleteDeThi(maDeThi);
				return ServiceResult.Ok("Xoa de thi thanh cong.");
			});
		}

		// Lấy câu hỏi.
		public List<CauHoiDTO> LayCauHoi(string keyword)
		{
			// Lấy danh sách câu hỏi qua tầng dữ liệu.
			return Repository.GetCauHoi(keyword);
		}

		// Lấy câu hỏi.
		public ServiceResult<List<CauHoiDTO>> LayCauHoi(CauHoiSearchCriteriaDTO criteria)
		{
			return Try(() =>
			{
				criteria = criteria ?? new CauHoiSearchCriteriaDTO();
				if (!ValidateBandRange(criteria.BandTu, criteria.BandDen, out var message))
				{
					return ServiceResult<List<CauHoiDTO>>.Fail(message);
				}

				// Tìm kiếm câu hỏi theo bộ lọc nâng cao qua tầng dữ liệu.
				return ServiceResult<List<CauHoiDTO>>.Ok(Repository.SearchCauHoi(criteria), "Tai cau hoi thanh cong.");
			});
		}

		// Lấy các đoạn Reading theo khoảng band điểm.
		public ServiceResult<List<ReadingPassageDTO>> LayReadingPassages(decimal? bandTu, decimal? bandDen)
		{
			return Try(() =>
			{
				if (!ValidateBandRange(bandTu, bandDen, out var message))
				{
					return ServiceResult<List<ReadingPassageDTO>>.Fail(message);
				}

				// Lấy các đoạn Reading theo khoảng band qua tầng dữ liệu.
				return ServiceResult<List<ReadingPassageDTO>>.Ok(Repository.GetReadingPassages(bandTu, bandDen), "OK");
			});
		}

		// Lấy phần phần Listening.
		public ServiceResult<List<ListeningSectionDTO>> LayListeningSections(decimal? bandTu, decimal? bandDen)
		{
			return Try(() =>
			{
				if (!ValidateBandRange(bandTu, bandDen, out var message))
				{
					return ServiceResult<List<ListeningSectionDTO>>.Fail(message);
				}

				// Lấy các phần Listening theo khoảng band qua tầng dữ liệu.
				return ServiceResult<List<ListeningSectionDTO>>.Ok(Repository.GetListeningSections(bandTu, bandDen), "OK");
			});
		}

		// Lấy nội dung đề thi.
		public ServiceResult<List<IeltsExamItemDTO>> LayNoiDungDeThi(int maDeThi)
		{
			return Try(() =>
			{
				// Ràng buộc dữ liệu: Vui lòng chọn đề thi.
				if (maDeThi <= 0)
				{
					return ServiceResult<List<IeltsExamItemDTO>>.Fail("Vui long chon de thi.");
				}

				// Lấy nội dung đề thi qua tầng dữ liệu.
				return ServiceResult<List<IeltsExamItemDTO>>.Ok(Repository.GetNoiDungDeThi(maDeThi), "OK");
			});
		}

		// Lấy ngân hàng câu hỏi IELTS.
		public ServiceResult<List<BankRowDTO>> LayBankIELTS(string kyNang, float bandTu, float bandDen)
		{
			return Try(() =>
			{
				var skill = NormalizeSkill(kyNang);
				var from = Convert.ToDecimal(bandTu);
				var to = Convert.ToDecimal(bandDen);
				if (!IsSupportedExamSkill(skill))
				{
					return ServiceResult<List<BankRowDTO>>.Fail("Chi ho tro ngan hang Reading hoac Listening.");
				}

				if (!ValidateBandRange(from, to, out var message))
				{
					return ServiceResult<List<BankRowDTO>>.Fail(message);
				}

				var rows = new List<BankRowDTO>();
				// Tìm kiếm câu hỏi theo bộ lọc nâng cao qua tầng dữ liệu.
				var questions = Repository.SearchCauHoi(new CauHoiSearchCriteriaDTO { NhanKyNang = skill, BandTu = from, BandDen = to });
				if (skill == "Reading")
				{
					// Lấy các đoạn Reading theo khoảng band qua tầng dữ liệu.
					rows.AddRange(Repository.GetReadingPassages(from, to).Select(x => new BankRowDTO
					{
						Kind = "Passage",
						Id = x.PassageId,
						Title = x.Title,
						Skill = "Reading",
						BandLevel = x.BandLevel,
						QuestionCount = x.SoCauHoi,
						MediaPath = x.ImagePath,
						ContentPreview = x.Content
					}));
				}
				else
				{
					// Lấy các phần Listening theo khoảng band qua tầng dữ liệu.
					rows.AddRange(Repository.GetListeningSections(from, to).Select(x => new BankRowDTO
					{
						Kind = "Section",
						Id = x.SectionId,
						Title = "Part " + (x.PartNo > 0 ? x.PartNo : x.SectionNumber) + " - " + x.Title,
						Skill = "Listening",
						BandLevel = x.BandLevel,
						QuestionCount = x.SoCauHoi,
						MediaPath = x.AudioPath,
						ContentPreview = x.Transcript
					}));
				}

				rows.AddRange(questions.Select(x => new BankRowDTO
				{
					Kind = "Question",
					Id = x.MaCauHoi,
					Title = x.NoiDung,
					Skill = x.NhanKyNang,
					BandLevel = x.BandLevel,
					ParentId = x.PassageId ?? x.SectionId,
					QuestionCount = 1,
					ContentPreview = x.NoiDung,
					ParentTitle = x.GroupTitle
				}));

				return ServiceResult<List<BankRowDTO>>.Ok(rows, "Tai ngan hang IELTS thanh cong.");
			});
		}

		// Lấy bản xem trước câu hỏi trong ngân hàng.
		public ServiceResult<string> LayPreviewBankItem(BankRowDTO row)
		{
			return Try(() =>
			{
				if (row == null)
				{
					return ServiceResult<string>.Fail("Vui long chon dong can preview.");
				}

				if (row.Kind == "Passage")
				{
					// Lấy đoạn Reading theo mã qua tầng dữ liệu.
					var passage = Repository.GetReadingPassageById(row.Id);
					if (passage == null) return ServiceResult<string>.Fail("Khong tim thay passage.");
					return ServiceResult<string>.Ok(passage.Title + Environment.NewLine + Environment.NewLine + passage.Content + Environment.NewLine + Environment.NewLine + passage.ImagePath, passage.ImagePath);
				}

				if (row.Kind == "Section")
				{
					// Lấy phần Listening theo mã qua tầng dữ liệu.
					var section = Repository.GetListeningSectionById(row.Id);
					if (section == null) return ServiceResult<string>.Fail("Khong tim thay section.");
					return ServiceResult<string>.Ok(section.Title + Environment.NewLine + Environment.NewLine + section.Transcript + Environment.NewLine + Environment.NewLine + section.AudioPath, section.AudioPath);
				}

				// Lấy danh sách câu hỏi qua tầng dữ liệu.
				var question = Repository.GetCauHoi(null).FirstOrDefault(x => x.MaCauHoi == row.Id);
				if (question == null) return ServiceResult<string>.Fail("Khong tim thay cau hoi.");
				var preview = question.NoiDung + Environment.NewLine
					+ "Type: " + question.QuestionType + Environment.NewLine
					+ "A. " + question.OptionA + Environment.NewLine
					+ "B. " + question.OptionB + Environment.NewLine
					+ "C. " + question.OptionC + Environment.NewLine
					+ "D. " + question.OptionD + Environment.NewLine
					+ "Answer: " + question.AnswerKey + Environment.NewLine
					+ "Explanation: " + question.Explanation;
				return ServiceResult<string>.Ok(preview, string.Empty);
			});
		}

		// Tạo đề thi.
		public ServiceResult<int> TaoDeThi(DeThiDTO dto)
		{
			return Try(() =>
			{
				dto = dto ?? new DeThiDTO();
				dto.KyNang = NormalizeSkill(dto.KyNang);
				// Ràng buộc dữ liệu: Vui lòng nhập tên đề thi.
				if (ValidationHelper.IsBlank(dto.TenDeThi))
				{
					return ServiceResult<int>.Fail("Vui long nhap ten de thi.");
				}

				if (!IsSupportedExamSkill(dto.KyNang))
				{
					return ServiceResult<int>.Fail("Ky nang de thi phai la Reading hoac Listening.");
				}

				if (!ValidateBandRange(dto.BandTu, dto.BandDen, out var bandMessage))
				{
					return ServiceResult<int>.Fail(bandMessage);
				}

				// Thêm đề thi mới qua tầng dữ liệu.
				var id = Repository.InsertDeThi(dto);
				return ServiceResult<int>.Ok(id, "Tao de thi thanh cong.");
			});
		}

		// Tạo đề thi IELTS tự động.
		public ServiceResult<int> TaoDeThiIELTSTuDong(string kyNang, float bandTu, float bandDen)
		{
			return Try(() =>
			{
				var skill = NormalizeSkill(kyNang);
				var from = Convert.ToDecimal(bandTu);
				var to = Convert.ToDecimal(bandDen);
				if (skill != "Reading" && skill != "Listening")
				{
					return ServiceResult<int>.Fail("Chi ho tro tao de tu dong cho Reading hoac Listening.");
				}

				if (!ValidateBandRange(from, to, out var message))
				{
					return ServiceResult<int>.Fail(message);
				}

				if (skill == "Reading")
				{
					// Lấy các đoạn Reading theo khoảng band qua tầng dữ liệu.
					var passages = Repository.GetReadingPassages(from, to)
						.Where(x => x.SoCauHoi > 0)
						.OrderBy(x => Guid.NewGuid())
						.Take(3)
						.ToList();
					if (passages.Count < 3)
					{
						return ServiceResult<int>.Fail("Can toi thieu 3 Reading Passage phu hop.");
					}

					var groupedQuestions = passages
						// Lấy câu hỏi thuộc đoạn Reading qua tầng dữ liệu.
						.Select(x => new { Passage = x, Questions = Repository.GetCauHoiByPassageId(x.PassageId).Where(q => IsInBand(q.BandLevel, from, to)).OrderBy(q => q.MaCauHoi).ToList() })
						.ToList();
					if (groupedQuestions.Sum(x => x.Questions.Count) < 40)
					{
						return ServiceResult<int>.Fail("3 Passage da chon chua du 40 cau hoi Reading.");
					}

					var examId = CreateAutoExam(skill, from, to);
					var order = 1;
					foreach (var group in groupedQuestions)
					{
						foreach (var question in group.Questions)
						{
							if (order > 40) break;
							// Thêm câu hỏi vào đề thi qua tầng dữ liệu.
							Repository.ThemCauHoiVaoDeThi(examId, question.MaCauHoi, "Reading", group.Passage.PassageId, order++);
						}
					}
					return ServiceResult<int>.Ok(examId, "Da tao de Reading gom 40 cau theo 3 Passage.");
				}
				else
				{
					// Lấy các phần Listening theo khoảng band qua tầng dữ liệu.
					var sections = Repository.GetListeningSections(from, to)
						.Where(x => x.SoCauHoi > 0)
						.GroupBy(x => x.PartNo > 0 ? x.PartNo : x.SectionNumber)
						.Where(x => x.Key >= 1 && x.Key <= 4)
						.Select(x => x.OrderBy(_ => Guid.NewGuid()).First())
						.OrderBy(x => x.PartNo > 0 ? x.PartNo : x.SectionNumber)
						.ToList();
					if (sections.Count < 4)
					{
						return ServiceResult<int>.Fail("Can du 4 Listening Section phu hop.");
					}

					var groupedQuestions = sections
						// Lấy câu hỏi thuộc phần Listening qua tầng dữ liệu.
						.Select(x => new { Section = x, Questions = Repository.GetCauHoiBySectionId(x.SectionId).Where(q => IsInBand(q.BandLevel, from, to)).OrderBy(q => q.MaCauHoi).ToList() })
						.ToList();
					if (groupedQuestions.Sum(x => x.Questions.Count) < 40)
					{
						return ServiceResult<int>.Fail("4 Section da chon chua du 40 cau hoi Listening.");
					}

					var examId = CreateAutoExam(skill, from, to);
					var order = 1;
					foreach (var group in groupedQuestions)
					{
						foreach (var question in group.Questions)
						{
							if (order > 40) break;
							// Thêm câu hỏi vào đề thi qua tầng dữ liệu.
							Repository.ThemCauHoiVaoDeThi(examId, question.MaCauHoi, "Listening", group.Section.SectionId, order++);
						}
					}
					return ServiceResult<int>.Ok(examId, "Da tao de Listening gom 40 cau theo 4 Section.");
				}
			});
		}

		// Kiểm tra nghiệp vụ rồi gọi tầng dữ liệu để lưu dữ liệu đề thi IELTS.
		public ServiceResult LuuCauHoi(CauHoiDTO dto)
		{
			return Try(() =>
			{
				// Ràng buộc dữ liệu: Nội dung câu hỏi và kỹ năng không hợp lệ.
				if (ValidationHelper.IsBlank(dto.NoiDung) || !ValidationHelper.IsValidSkill(dto.NhanKyNang))
				{
					return ServiceResult.Fail("Noi dung cau hoi va ky nang khong hop le.");
				}

				// Ràng buộc dữ liệu: Band câu hỏi phải nằm trong khoảng 0 đến 9 và theo bước 0.5.
				if (!ValidationHelper.IsValidIeltsScore(dto.BandLevel))
				{
					return ServiceResult.Fail("Band cau hoi phai nam trong khoang 0 den 9 va theo buoc 0.5.");
				}

				if ((dto.NhanKyNang == "Reading" && !dto.PassageId.HasValue)
					|| (dto.NhanKyNang == "Listening" && !dto.SectionId.HasValue))
				{
					return ServiceResult.Fail("Cau hoi Reading/Listening phai gan voi Passage hoac Section.");
				}

				dto.DapAn = string.IsNullOrWhiteSpace(dto.DapAn) ? dto.AnswerKey : dto.DapAn;
				if (dto.MaCauHoi == 0)
				{
					// Thêm câu hỏi mới qua tầng dữ liệu.
					Repository.InsertCauHoi(dto);
					return ServiceResult.Ok("Them cau hoi thanh cong.");
				}

				// Cập nhật thông tin câu hỏi qua tầng dữ liệu.
				Repository.UpdateCauHoi(dto);
				return ServiceResult.Ok("Cap nhat cau hoi thanh cong.");
			});
		}

		// Gọi tầng dữ liệu để xóa dữ liệu đề thi IELTS sau khi giao diện xác nhận.
		public ServiceResult XoaCauHoi(int maCauHoi)
		{
			return Try(() =>
			{
				// Xóa câu hỏi đã chọn qua tầng dữ liệu.
				Repository.DeleteCauHoi(maCauHoi);
				return ServiceResult.Ok("Xoa cau hoi thanh cong.");
			});
		}

		// Thêm câu hỏi vào đề thi.
		public ServiceResult ThemCauHoiVaoDeThi(int maDeThi, int maCauHoi)
		{
			return ThemCauHoiVaoDeThi(maDeThi, maCauHoi, null, null, null);
		}

		// Thêm câu hỏi vào đề thi.
		public ServiceResult ThemCauHoiVaoDeThi(int maDeThi, int maCauHoi, string groupType, int? groupId, int? thuTu)
		{
			return Try(() =>
			{
				// Ràng buộc dữ liệu: Vui lòng chọn đề thi và câu hỏi.
				if (maDeThi <= 0 || maCauHoi <= 0)
				{
					return ServiceResult.Fail("Vui long chon de thi va cau hoi.");
				}

				// Kiểm tra câu hỏi đã nằm trong đề thi qua tầng dữ liệu.
				if (Repository.ExistsQuestionInExam(maDeThi, maCauHoi))
				{
					return ServiceResult.Fail("Cau hoi da ton tai trong de, khong them trung.");
				}

				// Thêm câu hỏi vào đề thi qua tầng dữ liệu.
				Repository.ThemCauHoiVaoDeThi(maDeThi, maCauHoi, groupType, groupId, thuTu ?? Repository.GetNextThuTu(maDeThi));
				return ServiceResult.Ok("Da them cau hoi vao de thi.");
			});
		}

		// Xử lý gom câu hỏi theo nguồn Reading/Listening.
		public ServiceResult<List<CauHoiDTO>> ResolveQuestions(BankRowDTO row)
		{
			return Try(() =>
			{
				if (row == null)
				{
					return ServiceResult<List<CauHoiDTO>>.Fail("Vui long chon dong trong ngan hang.");
				}

				if (row.Kind == "Passage")
				{
					// Lấy câu hỏi thuộc đoạn Reading qua tầng dữ liệu.
					return ServiceResult<List<CauHoiDTO>>.Ok(Repository.GetCauHoiByPassageId(row.Id), "OK");
				}

				if (row.Kind == "Section")
				{
					// Lấy câu hỏi thuộc phần Listening qua tầng dữ liệu.
					return ServiceResult<List<CauHoiDTO>>.Ok(Repository.GetCauHoiBySectionId(row.Id), "OK");
				}

				// Lấy danh sách câu hỏi qua tầng dữ liệu.
				var question = Repository.GetCauHoi(null).FirstOrDefault(x => x.MaCauHoi == row.Id);
				return ServiceResult<List<CauHoiDTO>>.Ok(question == null ? new List<CauHoiDTO>() : new List<CauHoiDTO> { question }, "OK");
			});
		}

		// Gọi tầng dữ liệu để xóa dữ liệu đề thi IELTS sau khi giao diện xác nhận.
		public ServiceResult XoaCauHoiKhoiDeThi(int maDeThi, int maCauHoi)
		{
			return Try(() =>
			{
				// Ràng buộc dữ liệu: Vui lòng chọn câu hỏi trong đề thi.
				if (maDeThi <= 0 || maCauHoi <= 0)
				{
					return ServiceResult.Fail("Vui long chon cau hoi trong de thi.");
				}

				// Xóa câu hỏi khỏi đề thi qua tầng dữ liệu.
				Repository.XoaCauHoiKhoiDeThi(maDeThi, maCauHoi);
				return ServiceResult.Ok("Da xoa cau hoi khoi de thi.");
			});
		}

		// Xử lý tải đường dẫn âm thanh lên kho lưu trữ.
		public ServiceResult<string> UploadAudioPath(string sourcePath)
		{
			return CopyFileToUploadFolder(sourcePath, "DeThi/Audio", new[] { ".mp3", ".wav" });
		}

		// Xử lý tải đường dẫn hình ảnh lên kho lưu trữ.
		public ServiceResult<string> UploadImagePath(string sourcePath)
		{
			return CopyFileToUploadFolder(sourcePath, "DeThi/Image", new[] { ".jpg", ".jpeg", ".png" });
		}

		// Xử lý tải âm thanh cho phần Listening.
		public ServiceResult<string> UploadAudioForSection(int maSection, string sourceFilePath)
		{
			// Ràng buộc dữ liệu: Phần Listening không hợp lệ.
			if (maSection <= 0)
			{
				return ServiceResult<string>.Fail("Section khong hop le.");
			}

			return UploadAudioPath(sourceFilePath);
		}

		// Xử lý tải hình ảnh cho đoạn Reading.
		public ServiceResult<string> UploadImageForPassage(int maPassage, string sourceFilePath)
		{
			// Ràng buộc dữ liệu: Đoạn Reading không hợp lệ.
			if (maPassage <= 0)
			{
				return ServiceResult<string>.Fail("Passage khong hop le.");
			}

			return UploadImagePath(sourceFilePath);
		}

		// Đọc dữ liệu đề thi IELTS từ tệp Excel hoặc CSV.
		public ServiceResult<IeltsImportResultDTO> ImportIeltsExcel(string filePath)
		{
			return Try(() =>
			{
				var result = new IeltsImportResultDTO();
				// Ràng buộc dữ liệu: Tệp dữ liệu nhập không tồn tại.
				if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
				{
					return ServiceResult<IeltsImportResultDTO>.Fail("File import khong ton tai.");
				}

				if (!string.Equals(Path.GetExtension(filePath), ".xlsx", StringComparison.OrdinalIgnoreCase)
					&& !string.Equals(Path.GetExtension(filePath), ".csv", StringComparison.OrdinalIgnoreCase))
				{
					return ServiceResult<IeltsImportResultDTO>.Fail("Chi ho tro file .xlsx hoac .csv.");
				}

				var rows = ReadImportRows(filePath);
				var validRows = rows.Where(row => ValidateImportRow(row, result.Errors)).ToList();
				if (validRows.Count == 0)
				{
					return ServiceResult<IeltsImportResultDTO>.Fail("File import khong co dong hop le. " + string.Join(Environment.NewLine, result.Errors.Take(5)));
				}

				foreach (var row in validRows)
				{
					if (!string.IsNullOrWhiteSpace(row.AudioPath) && File.Exists(row.AudioPath))
					{
						var upload = UploadAudioPath(row.AudioPath);
						if (upload.Success) row.AudioPath = upload.Data;
					}

					if (!string.IsNullOrWhiteSpace(row.ImagePath) && File.Exists(row.ImagePath))
					{
						var upload = UploadImagePath(row.ImagePath);
						if (upload.Success) row.ImagePath = upload.Data;
					}
				}

				// Nhập dữ liệu IELTS từ tệp nhập qua tầng dữ liệu.
				var count = Repository.ImportIeltsRows(validRows);
				result.QuestionCount = count;
				result.PassageCount = validRows.Where(x => x.Skill == "Reading").Select(x => x.ParentCode).Distinct().Count();
				result.SectionCount = validRows.Where(x => x.Skill == "Listening").Select(x => x.ParentCode).Distinct().Count();
				var message = "Da import " + result.QuestionCount + " cau hoi IELTS.";
				if (result.Errors.Count > 0)
				{
					message += " Bo qua " + result.Errors.Count + " dong loi.";
				}

				return ServiceResult<IeltsImportResultDTO>.Ok(result, message);
			});
		}

		// Tạo đề thi tự động.
		private int CreateAutoExam(string skill, decimal from, decimal to)
		{
			// Thêm đề thi mới qua tầng dữ liệu.
			return Repository.InsertDeThi(new DeThiDTO
			{
				TenDeThi = skill + " IELTS " + DateTime.Now.ToString("yyyyMMdd HHmm"),
				KyNang = skill,
				BandTu = from,
				BandDen = to,
				TrangThai = "DangTao"
			});
		}

		// Kiểm tra khoảng band điểm.
		private static bool ValidateBandRange(decimal? bandTu, decimal? bandDen, out string message)
		{
			if (bandTu.HasValue && !ValidationHelper.IsValidIeltsScore(bandTu))
			{
				message = "Band bat dau khong hop le.";
				return false;
			}

			if (bandDen.HasValue && !ValidationHelper.IsValidIeltsScore(bandDen))
			{
				message = "Band ket thuc khong hop le.";
				return false;
			}

			if (bandTu.HasValue && bandDen.HasValue && bandTu.Value > bandDen.Value)
			{
				message = "Band bat dau khong duoc lon hon band ket thuc.";
				return false;
			}

			message = string.Empty;
			return true;
		}

		// Xử lý tệp vào thư mục tải lên.
		private ServiceResult<string> CopyFileToUploadFolder(string sourcePath, string folderName, string[] allowedExtensions)
		{
			return Try(() =>
			{
				// Ràng buộc dữ liệu: Tệp nguồn không tồn tại.
				if (string.IsNullOrWhiteSpace(sourcePath) || !File.Exists(sourcePath))
				{
					return ServiceResult<string>.Fail("File nguon khong ton tai.");
				}

				// Ràng buộc dữ liệu: Định dạng tệp không được hỗ trợ.
				if (!ValidationHelper.IsSupportedFile(sourcePath, allowedExtensions))
				{
					return ServiceResult<string>.Fail("Dinh dang file khong duoc ho tro.");
				}

				if (new FileInfo(sourcePath).Length > 50 * 1024 * 1024)
				{
					return ServiceResult<string>.Fail("File vuot qua gioi han 50MB.");
				}

				var targetFolder = Path.Combine(AppRoot, "Uploads", folderName.Replace('/', Path.DirectorySeparatorChar));
				Directory.CreateDirectory(targetFolder);
				var fileName = Guid.NewGuid().ToString("N") + "_" + Path.GetFileName(sourcePath);
				var targetPath = Path.Combine(targetFolder, fileName);
				File.Copy(sourcePath, targetPath, false);
				return ServiceResult<string>.Ok("Uploads/" + folderName + "/" + fileName, "Upload file thanh cong.");
			});
		}

		private static string AppRoot
		{
			get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QuanLyLopIELTS"); }
		}

		// Xử lý kỹ năng đề thi được hỗ trợ.
		private static bool IsSupportedExamSkill(string skill)
		{
			return skill == "Reading" || skill == "Listening";
		}

		// Chuẩn hóa skill.
		private static string NormalizeSkill(string skill)
		{
			if (string.Equals(skill, "Reading", StringComparison.OrdinalIgnoreCase)) return "Reading";
			if (string.Equals(skill, "Listening", StringComparison.OrdinalIgnoreCase)) return "Listening";
			return (skill ?? string.Empty).Trim();
		}

		// Xử lý điểm nằm trong khoảng band.
		private static bool IsInBand(decimal? bandLevel, decimal bandTu, decimal bandDen)
		{
			return !bandLevel.HasValue || (bandLevel.Value >= bandTu && bandLevel.Value <= bandDen);
		}

		// Xử lý định dạng tài liệu được hỗ trợ.
		private static bool IsSupportedDocument(string path)
		{
			return IsBlankOrExtension(path, ".pdf", ".doc", ".docx", ".xlsx");
		}

		// Xử lý định dạng âm thanh được hỗ trợ.
		private static bool IsSupportedAudio(string path)
		{
			return IsBlankOrExtension(path, ".mp3", ".wav");
		}

		// Xử lý định dạng hình ảnh được hỗ trợ.
		private static bool IsSupportedImage(string path)
		{
			return IsBlankOrExtension(path, ".jpg", ".jpeg", ".png");
		}

		// Xử lý đường dẫn rỗng hoặc phần mở rộng tệp.
		private static bool IsBlankOrExtension(string path, params string[] extensions)
		{
			if (string.IsNullOrWhiteSpace(path))
			{
				return true;
			}

			var extension = Path.GetExtension(path).ToLowerInvariant();
			return extensions.Contains(extension);
		}

		// Kiểm tra dòng dữ liệu nhập.
		private static bool ValidateImportRow(IeltsImportRowDTO row, List<string> errors)
		{
			if (row == null)
			{
				errors.Add("Dong rong khong hop le.");
				return false;
			}

			var rowLabel = row.RowNumber > 0 ? "Dong " + row.RowNumber + ": " : string.Empty;
			var rowErrors = new List<string>();
			row.Skill = NormalizeSkill(row.Skill);
			if (!IsSupportedExamSkill(row.Skill)) rowErrors.Add("Skill phai la Reading hoac Listening");
			if (string.IsNullOrWhiteSpace(row.ParentCode)) rowErrors.Add("ParentCode khong duoc rong");
			if (string.IsNullOrWhiteSpace(row.QuestionType)) rowErrors.Add("QuestionType khong duoc rong");
			if (string.IsNullOrWhiteSpace(row.QuestionText)) rowErrors.Add("NoiDung khong duoc rong");
			if (string.IsNullOrWhiteSpace(row.AnswerKey)) rowErrors.Add("AnswerKey khong duoc rong");
			if (!row.BandLevel.HasValue) rowErrors.Add("BandLevel phai la so");

			if (rowErrors.Count > 0)
			{
				errors.Add(rowLabel + string.Join(", ", rowErrors));
				return false;
			}

			return true;
		}

		// Đọc các dòng dữ liệu nhập từ tệp.
		private static List<IeltsImportRowDTO> ReadImportRows(string filePath)
		{
			var extension = Path.GetExtension(filePath).ToLowerInvariant();
			if (extension == ".csv")
			{
				return ReadCsvRows(filePath);
			}

			return ReadExcelRows(filePath);
		}

		// Xử lý đọc các dòng CSV.
		private static List<IeltsImportRowDTO> ReadCsvRows(string filePath)
		{
			var result = new List<IeltsImportRowDTO>();
			using (var parser = new TextFieldParser(filePath, Encoding.UTF8))
			{
				parser.TextFieldType = FieldType.Delimited;
				parser.SetDelimiters(",");
				if (parser.EndOfData)
				{
					return result;
				}

				var headers = parser.ReadFields();
				var rowNumber = 1;
				while (!parser.EndOfData)
				{
					rowNumber++;
					result.Add(ToImportRow(headers, parser.ReadFields(), rowNumber));
				}
			}

			return result;
		}

		// Xử lý đọc các dòng Excel.
		private static List<IeltsImportRowDTO> ReadExcelRows(string filePath)
		{
			var connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";";
			using (var connection = new OleDbConnection(connectionString))
			{
				connection.Open();
				var passages = ReadSheet(connection, "ReadingPassage$").Rows.Cast<DataRow>()
					.Where(x => !string.IsNullOrWhiteSpace(Convert.ToString(x["PassageCode"])))
					.ToDictionary(x => Convert.ToString(x["PassageCode"]).Trim(), x => x);
				var sections = ReadSheet(connection, "ListeningSection$").Rows.Cast<DataRow>()
					.Where(x => !string.IsNullOrWhiteSpace(Convert.ToString(x["SectionCode"])))
					.ToDictionary(x => Convert.ToString(x["SectionCode"]).Trim(), x => x);
				var questions = ReadSheet(connection, "Question$");
				var result = new List<IeltsImportRowDTO>();
				var rowNumber = 1;
				foreach (DataRow row in questions.Rows)
				{
					rowNumber++;
					var skill = NormalizeSkill(GetCell(row, "Skill"));
					var parentCode = GetCell(row, "ParentCode");
					IeltsImportRowDTO dto;
					if (skill == "Reading" && passages.ContainsKey(parentCode))
					{
						var parent = passages[parentCode];
						dto = ToQuestionImportRow(row, rowNumber, skill, parentCode);
						dto.PassageCode = parentCode;
						dto.PassageTitle = GetCell(parent, "Title");
						dto.PassageContent = GetCell(parent, "Content");
						dto.ImagePath = GetCell(parent, "ImagePath");
						dto.Topic = GetCell(parent, "Topic");
						result.Add(dto);
					}
					else if (skill == "Listening" && sections.ContainsKey(parentCode))
					{
						var parent = sections[parentCode];
						dto = ToQuestionImportRow(row, rowNumber, skill, parentCode);
						dto.SectionCode = parentCode;
						dto.SectionTitle = GetCell(parent, "Title");
						dto.Transcript = GetCell(parent, "Transcript");
						dto.AudioPath = GetCell(parent, "AudioPath");
						dto.SectionNumber = TryParseInt(GetCell(parent, "PartNo"));
						dto.Topic = GetCell(parent, "Topic");
						result.Add(dto);
					}
					else
					{
						result.Add(ToQuestionImportRow(row, rowNumber, skill, parentCode));
					}
				}

				return result;
			}
		}

		// Xử lý đọc sheet Excel.
		private static DataTable ReadSheet(OleDbConnection connection, string sheetName)
		{
			using (var adapter = new OleDbDataAdapter("SELECT * FROM [" + sheetName + "]", connection))
			{
				var table = new DataTable();
				adapter.Fill(table);
				return table;
			}
		}

		// Chuyển đổi dòng dữ liệu nhập.
		private static IeltsImportRowDTO ToImportRow(string[] headers, string[] values, int rowNumber)
		{
			Func<string, string> get = name =>
			{
				var index = Array.FindIndex(headers, x => string.Equals(x, name, StringComparison.OrdinalIgnoreCase));
				return index >= 0 && index < values.Length ? values[index] : string.Empty;
			};

			decimal band;
			int sectionNumber;
			return new IeltsImportRowDTO
			{
				RowNumber = rowNumber,
				ParentCode = get("ParentCode"),
				Skill = NormalizeSkill(get("Skill")),
				PassageCode = get("PassageCode"),
				PassageTitle = get("PassageTitle"),
				PassageContent = get("PassageContent"),
				Topic = get("Topic"),
				SectionCode = get("SectionCode"),
				SectionTitle = get("SectionTitle"),
				SectionNumber = int.TryParse(get("SectionNumber"), out sectionNumber) ? sectionNumber : (int?)null,
				Transcript = get("Transcript"),
				AudioPath = get("AudioPath"),
				ImagePath = get("ImagePath"),
				QuestionText = get("QuestionText"),
				QuestionType = get("QuestionType"),
				OptionA = get("OptionA"),
				OptionB = get("OptionB"),
				OptionC = get("OptionC"),
				OptionD = get("OptionD"),
				AnswerKey = get("AnswerKey"),
				BandLevel = decimal.TryParse(get("BandLevel"), out band) ? band : (decimal?)null,
				Explanation = get("Explanation")
			};
		}

		// Chuyển đổi dòng dữ liệu nhập thành câu hỏi.
		private static IeltsImportRowDTO ToQuestionImportRow(DataRow row, int rowNumber, string skill, string parentCode)
		{
			decimal band;
			return new IeltsImportRowDTO
			{
				RowNumber = rowNumber,
				ParentCode = parentCode,
				Skill = skill,
				QuestionType = GetCell(row, "QuestionType"),
				QuestionText = GetCell(row, "NoiDung"),
				OptionA = GetCell(row, "OptionA"),
				OptionB = GetCell(row, "OptionB"),
				OptionC = GetCell(row, "OptionC"),
				OptionD = GetCell(row, "OptionD"),
				AnswerKey = GetCell(row, "AnswerKey"),
				Explanation = GetCell(row, "Explanation"),
				BandLevel = decimal.TryParse(GetCell(row, "BandLevel"), out band) ? band : (decimal?)null
			};
		}

		// Lấy cell.
		private static string GetCell(DataRow row, string columnName)
		{
			return row.Table.Columns.Contains(columnName) ? Convert.ToString(row[columnName]).Trim() : string.Empty;
		}

		// Xử lý chuyển chuỗi sang số nguyên.
		private static int? TryParseInt(string value)
		{
			int number;
			return int.TryParse(value, out number) ? number : (int?)null;
		}
	}
}
