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
    public class AuthService : ServiceBase
        {
            public AuthService(IQuanLyIeltsRepository repository) : base(repository) { }
    
            public ServiceResult<NguoiDungDTO> DangNhap(string taiKhoan, string matKhau)
            {
                return Try(() =>
                {
                    if (ValidationHelper.IsBlank(taiKhoan) || ValidationHelper.IsBlank(matKhau))
                    {
                        return ServiceResult<NguoiDungDTO>.Fail("Vui lòng nhập tài khoản và mật khẩu.");
                    }
    
                    string error;
                    if (!Repository.KiemTraKetNoi(out error))
                    {
                        return ServiceResult<NguoiDungDTO>.Fail("Không kết nối được cơ sở dữ liệu. Hãy chạy DAL\\Sql\\Schema.sql và kiểm tra chuỗi kết nối. Chi tiết: " + error);
                    }
    
                    var nguoiDung = Repository.GetNguoiDungByTaiKhoan(taiKhoan.Trim());
                    if (nguoiDung == null || nguoiDung.MatKhau != matKhau)
                    {
                        return ServiceResult<NguoiDungDTO>.Fail("Tài khoản hoặc mật khẩu không đúng.");
                    }
    
                    if (!AppConstants.AdminRoles.Contains(nguoiDung.VaiTro))
                    {
                        return ServiceResult<NguoiDungDTO>.Fail("Vai trò Học sinh đã được chừa trong kiến trúc nhưng chưa có giao diện ở phiên bản hiện tại.");
                    }
    
                    return ServiceResult<NguoiDungDTO>.Ok(nguoiDung, "Đăng nhập thành công.");
                });
            }
        }
}

