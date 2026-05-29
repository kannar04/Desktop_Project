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
    public class BaiTapService : ServiceBase
        {
            public BaiTapService(IQuanLyIeltsRepository repository) : base(repository) { }
    
            public List<BaiTapDTO> LayDanhSach(int? maLopHoc)
            {
                return Repository.GetBaiTap(maLopHoc);
            }
    
            public ServiceResult GiaoBai(BaiTapDTO dto)
            {
                return Try(() =>
                {
                    if (dto.MaLopHoc <= 0 || ValidationHelper.IsBlank(dto.TieuDe) || ValidationHelper.IsBlank(dto.MoTa))
                    {
                        return ServiceResult.Fail("Vui lòng chọn lớp, nhập tiêu đề và mô tả bài tập.");
                    }
    
                    if (dto.Deadline <= DateTime.Now)
                    {
                        return ServiceResult.Fail("Hạn nộp phải lớn hơn thời điểm hiện tại.");
                    }
    
                    if (!ValidationHelper.IsSupportedFile(dto.FileDinhKem, new[] { ".pdf", ".doc", ".docx", ".zip", ".rar" }))
                    {
                        return ServiceResult.Fail("Định dạng file đính kèm không được hỗ trợ.");
                    }
    
                    if (dto.MaBaiTap == 0)
                    {
                        var maBaiTap = Repository.InsertBaiTap(dto);
                        Repository.TaoChiTietNopBaiChoLop(maBaiTap, dto.MaLopHoc);
                        return ServiceResult.Ok("Giao bài tập thành công.");
                    }
    
                    Repository.UpdateBaiTap(dto);
                    Repository.TaoChiTietNopBaiChoLop(dto.MaBaiTap, dto.MaLopHoc);
                    return ServiceResult.Ok("Cập nhật bài tập thành công.");
                });
            }
    
            public ServiceResult Xoa(int maBaiTap)
            {
                return Try(() =>
                {
                    Repository.DeleteBaiTap(maBaiTap);
                    return ServiceResult.Ok("Xóa bài tập thành công.");
                });
            }
        }
}

