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
    public class ChamBaiService : ServiceBase
        {
            public ChamBaiService(IQuanLyIeltsRepository repository) : base(repository) { }
    
            public List<NopBaiDTO> LayDanhSach(int maBaiTap)
            {
                return Repository.GetNopBaiTheoBaiTap(maBaiTap);
            }
    
            public ServiceResult Cham(NopBaiDTO dto)
            {
                return Try(() =>
                {
                    if (!ValidationHelper.IsValidIeltsScore(dto.DiemSo))
                    {
                        return ServiceResult.Fail("Điểm phải nằm trong khoảng 0 đến 9 và theo bước 0.5.");
                    }
    
                    if (dto.DiemSo == null)
                    {
                        return ServiceResult.Fail("Vui lòng nhập điểm bài làm.");
                    }
    
                    if (dto.TrangThaiNop == "Chưa nộp" && string.IsNullOrWhiteSpace(dto.FileBaiLam))
                    {
                        return ServiceResult.Fail("Học viên chưa nộp bài nên chưa thể chấm.");
                    }
    
                    Repository.ChamBai(dto);
                    return ServiceResult.Ok("Chấm bài thành công.");
                });
            }
        }
}

