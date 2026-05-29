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
        }
}

