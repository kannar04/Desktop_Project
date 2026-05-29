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
    public class DeThiService : ServiceBase
        {
            public DeThiService(IQuanLyIeltsRepository repository) : base(repository) { }
    
            public List<DeThiDTO> LayDeThi()
            {
                return Repository.GetDeThi();
            }
    
            public List<CauHoiDTO> LayCauHoi(string keyword)
            {
                return Repository.GetCauHoi(keyword);
            }
    
            public ServiceResult<List<CauHoiDTO>> LayCauHoi(CauHoiSearchCriteriaDTO criteria)
            {
                return Try(() =>
                {
                    criteria = criteria ?? new CauHoiSearchCriteriaDTO();
                    if (criteria.BandTu.HasValue && !ValidationHelper.IsValidIeltsScore(criteria.BandTu))
                    {
                        return ServiceResult<List<CauHoiDTO>>.Fail("Band bắt đầu không hợp lệ.");
                    }
    
                    if (criteria.BandDen.HasValue && !ValidationHelper.IsValidIeltsScore(criteria.BandDen))
                    {
                        return ServiceResult<List<CauHoiDTO>>.Fail("Band kết thúc không hợp lệ.");
                    }
    
                    if (criteria.BandTu.HasValue && criteria.BandDen.HasValue && criteria.BandTu.Value > criteria.BandDen.Value)
                    {
                        return ServiceResult<List<CauHoiDTO>>.Fail("Band bắt đầu không được lớn hơn band kết thúc.");
                    }
    
                    return ServiceResult<List<CauHoiDTO>>.Ok(Repository.SearchCauHoi(criteria), "Tải câu hỏi thành công.");
                });
            }
    
            public ServiceResult<int> TaoDeThi(DeThiDTO dto)
            {
                return Try(() =>
                {
                    if (ValidationHelper.IsBlank(dto.TenDeThi))
                    {
                        return ServiceResult<int>.Fail("Vui lòng nhập tên đề thi.");
                    }
    
                    var id = Repository.InsertDeThi(dto);
                    return ServiceResult<int>.Ok(id, "Tạo đề thi thành công.");
                });
            }
    
            public ServiceResult LuuCauHoi(CauHoiDTO dto)
            {
                return Try(() =>
                {
                    if (ValidationHelper.IsBlank(dto.NoiDung) || !ValidationHelper.IsValidSkill(dto.NhanKyNang))
                    {
                        return ServiceResult.Fail("Nội dung câu hỏi và nhãn kỹ năng không hợp lệ.");
                    }
    
                    if (!ValidationHelper.IsValidIeltsScore(dto.BandLevel))
                    {
                        return ServiceResult.Fail("Band câu hỏi phải nằm trong khoảng 0 đến 9 và theo bước 0.5.");
                    }
    
                    if (dto.MaCauHoi == 0)
                    {
                        Repository.InsertCauHoi(dto);
                        return ServiceResult.Ok("Thêm câu hỏi thành công.");
                    }
    
                    Repository.UpdateCauHoi(dto);
                    return ServiceResult.Ok("Cập nhật câu hỏi thành công.");
                });
            }
    
            public ServiceResult XoaCauHoi(int maCauHoi)
            {
                return Try(() =>
                {
                    Repository.DeleteCauHoi(maCauHoi);
                    return ServiceResult.Ok("Xóa câu hỏi thành công.");
                });
            }
    
            public ServiceResult ThemCauHoiVaoDeThi(int maDeThi, int maCauHoi)
            {
                return Try(() =>
                {
                    if (maDeThi <= 0 || maCauHoi <= 0)
                    {
                        return ServiceResult.Fail("Vui lòng chọn đề thi và câu hỏi.");
                    }
    
                    Repository.ThemCauHoiVaoDeThi(maDeThi, maCauHoi);
                    return ServiceResult.Ok("Đã thêm câu hỏi vào đề thi.");
                });
            }
        }
}

