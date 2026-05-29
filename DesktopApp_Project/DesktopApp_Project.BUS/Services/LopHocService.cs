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
    public class LopHocService : ServiceBase
        {
            public LopHocService(IQuanLyIeltsRepository repository) : base(repository) { }
    
            public List<LopHocDTO> LayDanhSach()
            {
                return Repository.GetLopHoc();
            }
    
            public List<NguoiDungDTO> LayHocVienTrongLop(int maLopHoc)
            {
                return Repository.GetHocVienTrongLop(maLopHoc);
            }
    
            public List<NguoiDungDTO> LayHocVienChuaTrongLop(int maLopHoc)
            {
                return Repository.GetHocVienChuaTrongLop(maLopHoc);
            }
    
            public ServiceResult Luu(LopHocDTO dto)
            {
                return Try(() =>
                {
                    if (ValidationHelper.IsBlank(dto.TenLop) || ValidationHelper.IsBlank(dto.NhomTrinhDo))
                    {
                        return ServiceResult.Fail("Tên lớp và nhóm trình độ không được để trống.");
                    }
    
                    if (Repository.ExistsTenLop(dto.TenLop.Trim(), dto.MaLopHoc))
                    {
                        return ServiceResult.Fail("Tên lớp đã tồn tại.");
                    }
    
                    if (Repository.ExistsLichHoc(dto.LichHoc, dto.MaLopHoc))
                    {
                        return ServiceResult.Fail("Lịch học đã trùng với lớp khác.");
                    }
    
                    if (dto.MaLopHoc == 0)
                    {
                        Repository.InsertLopHoc(dto);
                        return ServiceResult.Ok("Tạo lớp học thành công.");
                    }
    
                    Repository.UpdateLopHoc(dto);
                    return ServiceResult.Ok("Cập nhật lớp học thành công.");
                });
            }
    
            public ServiceResult Xoa(int maLopHoc)
            {
                return Try(() =>
                {
                    Repository.DeleteLopHoc(maLopHoc);
                    return ServiceResult.Ok("Xóa lớp học thành công.");
                });
            }
    
            public ServiceResult ThemHocVien(int maNguoiDung, int maLopHoc)
            {
                return Try(() =>
                {
                    Repository.ThemHocVienVaoLop(maNguoiDung, maLopHoc);
                    return ServiceResult.Ok("Phân bổ học viên vào lớp thành công.");
                });
            }
    
            public ServiceResult XoaHocVien(int maNguoiDung, int maLopHoc)
            {
                return Try(() =>
                {
                    Repository.XoaHocVienKhoiLop(maNguoiDung, maLopHoc);
                    return ServiceResult.Ok("Đã xóa học viên khỏi lớp.");
                });
            }
        }
}

