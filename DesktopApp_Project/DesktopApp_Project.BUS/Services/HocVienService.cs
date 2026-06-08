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
    public class HocVienService : ServiceBase
        {
            public HocVienService(IQuanLyIeltsRepository repository) : base(repository) { }
    
            public List<NguoiDungDTO> TimKiem(string keyword)
            {
                return Repository.SearchHocVien(keyword);
            }
    
            public List<NguoiDungDTO> TimKiem(HocVienSearchCriteriaDTO criteria)
            {
                return Repository.SearchHocVien(criteria);
            }
    
            public ServiceResult Luu(NguoiDungDTO dto)
            {
                return Try(() =>
                {
                    dto.VaiTro = AppConstants.RoleStudent;
                    if (ValidationHelper.IsBlank(dto.HoTen) || ValidationHelper.IsBlank(dto.SDT) ||
                        ValidationHelper.IsBlank(dto.Email) || ValidationHelper.IsBlank(dto.TaiKhoan) ||
                        ValidationHelper.IsBlank(dto.MatKhau))
                    {
                        return ServiceResult.Fail("Vui lòng nhập đầy đủ họ tên, SĐT, email, tài khoản và mật khẩu.");
                    }
    
                    if (!ValidationHelper.IsValidEmail(dto.Email))
                    {
                        return ServiceResult.Fail("Email không hợp lệ.");
                    }
    
                    if (Repository.ExistsTaiKhoan(dto.TaiKhoan.Trim(), dto.MaNguoiDung))
                    {
                        return ServiceResult.Fail("Tài khoản học viên đã tồn tại.");
                    }
    
                    if (Repository.ExistsEmail(dto.Email.Trim(), dto.MaNguoiDung))
                    {
                        return ServiceResult.Fail("Email học viên đã tồn tại.");
                    }
    
                    if (dto.MaNguoiDung == 0)
                    {
                        Repository.InsertNguoiDung(dto);
                        return ServiceResult.Ok("Thêm học viên thành công.");
                    }
    
                    Repository.UpdateNguoiDung(dto);
                    return ServiceResult.Ok("Cập nhật học viên thành công.");
                });
            }
    
            public int? LayLopDangHoc(int maNguoiDung)
            {
                return Repository.GetLopHocDangHocCuaHocVien(maNguoiDung);
            }

            public ServiceResult LuuVoiLop(NguoiDungDTO dto, int maLopHoc)
            {
                return Try(() =>
                {
                    if (dto == null)
                    {
                        return ServiceResult.Fail("Dữ liệu học viên không hợp lệ.");
                    }

                    dto.VaiTro = AppConstants.RoleStudent;
                    if (maLopHoc <= 0)
                    {
                        return ServiceResult.Fail("Vui lòng chọn lớp cho học viên.");
                    }

                    if (!Repository.GetLopHoc().Any(x => x.MaLopHoc == maLopHoc))
                    {
                        return ServiceResult.Fail("Lớp học không hợp lệ.");
                    }

                    if (ValidationHelper.IsBlank(dto.HoTen) || ValidationHelper.IsBlank(dto.SDT) ||
                        ValidationHelper.IsBlank(dto.Email) || ValidationHelper.IsBlank(dto.TaiKhoan) ||
                        ValidationHelper.IsBlank(dto.MatKhau))
                    {
                        return ServiceResult.Fail("Vui lòng nhập đầy đủ họ tên, SĐT, email, tài khoản và mật khẩu.");
                    }

                    if (!ValidationHelper.IsValidEmail(dto.Email))
                    {
                        return ServiceResult.Fail("Email không hợp lệ.");
                    }

                    if (Repository.ExistsTaiKhoan(dto.TaiKhoan.Trim(), dto.MaNguoiDung))
                    {
                        return ServiceResult.Fail("Tài khoản học viên đã tồn tại.");
                    }

                    if (Repository.ExistsEmail(dto.Email.Trim(), dto.MaNguoiDung))
                    {
                        return ServiceResult.Fail("Email học viên đã tồn tại.");
                    }

                    var isNew = dto.MaNguoiDung == 0;
                    Repository.SaveHocVienVaChuyenLop(dto, maLopHoc);
                    return ServiceResult.Ok(isNew
                        ? "Thêm học viên thành công."
                        : "Cập nhật học viên thành công.");
                });
            }

            public ServiceResult Xoa(int maNguoiDung)
            {
                return Try(() =>
                {
                    Repository.DeleteNguoiDung(maNguoiDung);
                    return ServiceResult.Ok("Xóa học viên thành công.");
                });
            }
        }
}
