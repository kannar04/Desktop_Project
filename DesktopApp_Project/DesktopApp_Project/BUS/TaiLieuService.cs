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
    public class TaiLieuService : ServiceBase
        {
            public TaiLieuService(IQuanLyIeltsRepository repository) : base(repository) { }
    
            public List<TaiLieuDTO> LayDanhSach(int? maLopHoc)
            {
                return Repository.GetTaiLieu(maLopHoc);
            }
    
            public ServiceResult Luu(TaiLieuDTO dto)
            {
                return Try(() =>
                {
                    if (dto.MaLopHoc <= 0 || ValidationHelper.IsBlank(dto.TenChuDe))
                    {
                        return ServiceResult.Fail("Vui lòng chọn lớp và nhập tên chủ đề.");
                    }
    
                    if (!ValidationHelper.IsValidSkill(dto.NhanKyNang))
                    {
                        return ServiceResult.Fail("Nhãn kỹ năng phải là Listening, Reading, Writing hoặc Speaking.");
                    }
    
                    if (!ValidationHelper.IsSupportedFile(dto.DuongDanFile, new[] { ".pdf", ".doc", ".docx" }))
                    {
                        return ServiceResult.Fail("Định dạng tài liệu không được hỗ trợ. Chỉ nhận PDF, Word.");
                    }
    
                    if (!ValidationHelper.IsValidVideoLink(dto.VideoLink))
                    {
                        return ServiceResult.Fail("Link video không hợp lệ.");
                    }
    
                    if (dto.MaTaiLieu == 0)
                    {
                        Repository.InsertTaiLieu(dto);
                        return ServiceResult.Ok("Cập nhật tài liệu thành công.");
                    }
    
                    Repository.UpdateTaiLieu(dto);
                    return ServiceResult.Ok("Sửa tài liệu thành công.");
                });
            }
    
            public ServiceResult Xoa(int maTaiLieu)
            {
                return Try(() =>
                {
                    Repository.DeleteTaiLieu(maTaiLieu);
                    return ServiceResult.Ok("Xóa tài liệu thành công.");
                });
            }
        }
}

