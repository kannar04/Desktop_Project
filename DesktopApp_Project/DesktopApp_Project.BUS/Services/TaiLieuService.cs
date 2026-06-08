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
            private static readonly string[] SupportedAudioExtensions = { ".mp3", ".wav", ".m4a", ".aac", ".flac" };

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
    
                    if (!ValidationHelper.IsSupportedFile(dto.DuongDanFile, AppConstants.SupportedMediaExtensions)
                        || !ValidationHelper.IsSupportedFile(dto.DuongDanLocal, AppConstants.SupportedMediaExtensions)
                        || !ValidationHelper.IsSupportedFile(dto.AudioPath, SupportedAudioExtensions))
                    {
                        return ServiceResult.Fail("Dinh dang file khong duoc ho tro.");
                    }

                    if (Exceeds(dto.TenChuDe, 150) || Exceeds(dto.NoiDungMoTa, 1000)
                        || Exceeds(dto.DuongDanFile, 500) || Exceeds(dto.VideoLink, 500)
                        || Exceeds(dto.AudioPath, 500) || Exceeds(dto.NhanKyNang, 30)
                        || Exceeds(dto.LoaiFile, 30) || Exceeds(dto.TenFileGoc, 255)
                        || Exceeds(dto.DuongDanLocal, 500) || Exceeds(dto.DuongDanCloud, 500)
                        || Exceeds(dto.ThumbnailPath, 500))
                    {
                        return ServiceResult.Fail("Thong tin tai lieu vuot qua do dai cho phep.");
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

            private static bool Exceeds(string value, int maxLength)
            {
                return !string.IsNullOrEmpty(value) && value.Length > maxLength;
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
