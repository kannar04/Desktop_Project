// Dịch vụ xử lý nghiệp vụ đăng nhập và xác thực người dùng
// Chức năng:
// - Nhận dữ liệu từ giao diện dưới dạng đối tượng truyền dữ liệu hoặc tham số lọc
// - Kiểm tra nghiệp vụ trước khi gọi tầng dữ liệu
// - Trả kết quả xử lý hoặc danh sách đối tượng truyền dữ liệu cho giao diện

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
    // Lớp xử lý nghiệp vụ đăng nhập và xác thực người dùng, kiểm tra dữ liệu trước khi gọi kho dữ liệu/tầng dữ liệu.
    public class AuthService : ServiceBase
        {
            public AuthService(IQuanLyIeltsRepository repository) : base(repository) { }
    
            // Xác thực tài khoản và trả về thông tin người dùng hiện tại cho giao diện.
            public ServiceResult<NguoiDungDTO> DangNhap(string taiKhoan, string matKhau)
            {
                return Try(() =>
                {
                    // Ràng buộc dữ liệu: nhập tài khoản và mật khẩu.
                    if (ValidationHelper.IsBlank(taiKhoan) || ValidationHelper.IsBlank(matKhau))
                    {
                        return ServiceResult<NguoiDungDTO>.Fail("Vui lòng nhập tài khoản và mật khẩu.");
                    }
    
                    string error;
                    // Kiểm tra kết nối cơ sở dữ liệu qua tầng dữ liệu.
                    if (!Repository.KiemTraKetNoi(out error))
                    {
                        return ServiceResult<NguoiDungDTO>.Fail("Không kết nối được cơ sở dữ liệu. Hãy chạy DAL\\Sql\\Schema.sql và kiểm tra chuỗi kết nối. Chi tiết: " + error);
                    }
    
                    // Lấy thông tin người dùng theo tài khoản qua tầng dữ liệu.
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

