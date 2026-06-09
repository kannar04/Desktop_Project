// Dịch vụ xử lý nghiệp vụ học viên
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
    // Lớp xử lý nghiệp vụ học viên, kiểm tra dữ liệu trước khi gọi kho dữ liệu/tầng dữ liệu.
    public class HocVienService : ServiceBase
        {
            public HocVienService(IQuanLyIeltsRepository repository) : base(repository) { }
    
            // Tìm kiếm học viên theo tiêu chí nhận từ giao diện.
            public List<NguoiDungDTO> TimKiem(string keyword)
            {
                // Tìm kiếm danh sách học viên theo tiêu chí tìm kiếm qua tầng dữ liệu.
                return Repository.SearchHocVien(keyword);
            }
    
            // Tìm kiếm học viên theo tiêu chí nhận từ giao diện.
            public List<NguoiDungDTO> TimKiem(HocVienSearchCriteriaDTO criteria)
            {
                // Tìm kiếm danh sách học viên theo tiêu chí tìm kiếm qua tầng dữ liệu.
                return Repository.SearchHocVien(criteria);
            }
    
            // Kiểm tra nghiệp vụ rồi gọi tầng dữ liệu để lưu dữ liệu học viên.
            public ServiceResult Luu(NguoiDungDTO dto)
            {
                return Try(() =>
                {
                    dto.VaiTro = AppConstants.RoleStudent;
                    // Ràng buộc dữ liệu: nhập đầy đủ họ tên, số điện thoại, thư điện tử, tài khoản và mật khẩu.
                    if (ValidationHelper.IsBlank(dto.HoTen) || ValidationHelper.IsBlank(dto.SDT) ||
                        ValidationHelper.IsBlank(dto.Email) || ValidationHelper.IsBlank(dto.TaiKhoan) ||
                        ValidationHelper.IsBlank(dto.MatKhau))
                    {
                        return ServiceResult.Fail("Vui lòng nhập đầy đủ họ tên, SĐT, email, tài khoản và mật khẩu.");
                    }
    
                    // Ràng buộc dữ liệu: Thư điện tử không hợp lệ.
                    if (!ValidationHelper.IsValidEmail(dto.Email))
                    {
                        return ServiceResult.Fail("Email không hợp lệ.");
                    }
    
                    // Kiểm tra tài khoản bị trùng qua tầng dữ liệu.
                    if (Repository.ExistsTaiKhoan(dto.TaiKhoan.Trim(), dto.MaNguoiDung))
                    {
                        return ServiceResult.Fail("Tài khoản học viên đã tồn tại.");
                    }
    
                    // Kiểm tra thư điện tử bị trùng qua tầng dữ liệu.
                    if (Repository.ExistsEmail(dto.Email.Trim(), dto.MaNguoiDung))
                    {
                        return ServiceResult.Fail("Email học viên đã tồn tại.");
                    }
    
                    if (dto.MaNguoiDung == 0)
                    {
                        // Thêm người dùng mới qua tầng dữ liệu.
                        Repository.InsertNguoiDung(dto);
                        return ServiceResult.Ok("Thêm học viên thành công.");
                    }
    
                    // Cập nhật thông tin người dùng qua tầng dữ liệu.
                    Repository.UpdateNguoiDung(dto);
                    return ServiceResult.Ok("Cập nhật học viên thành công.");
                });
            }
    
            // Lấy lớp đang học.
            public int? LayLopDangHoc(int maNguoiDung)
            {
                // Lấy lớp hiện tại của học viên qua tầng dữ liệu.
                return Repository.GetLopHocDangHocCuaHocVien(maNguoiDung);
            }

            // Kiểm tra nghiệp vụ rồi gọi tầng dữ liệu để lưu dữ liệu học viên.
            public ServiceResult LuuVoiLop(NguoiDungDTO dto, int maLopHoc)
            {
                return Try(() =>
                {
                    // Ràng buộc dữ liệu: Dữ liệu học viên không hợp lệ.
                    if (dto == null)
                    {
                        return ServiceResult.Fail("Dữ liệu học viên không hợp lệ.");
                    }

                    dto.VaiTro = AppConstants.RoleStudent;
                    // Ràng buộc dữ liệu: chọn lớp cho học viên.
                    if (maLopHoc <= 0)
                    {
                        return ServiceResult.Fail("Vui lòng chọn lớp cho học viên.");
                    }

                    // Lấy danh sách lớp học qua tầng dữ liệu.
                    if (!Repository.GetLopHoc().Any(x => x.MaLopHoc == maLopHoc))
                    {
                        return ServiceResult.Fail("Lớp học không hợp lệ.");
                    }

                    // Ràng buộc dữ liệu: nhập đầy đủ họ tên, số điện thoại, thư điện tử, tài khoản và mật khẩu.
                    if (ValidationHelper.IsBlank(dto.HoTen) || ValidationHelper.IsBlank(dto.SDT) ||
                        ValidationHelper.IsBlank(dto.Email) || ValidationHelper.IsBlank(dto.TaiKhoan) ||
                        ValidationHelper.IsBlank(dto.MatKhau))
                    {
                        return ServiceResult.Fail("Vui lòng nhập đầy đủ họ tên, SĐT, email, tài khoản và mật khẩu.");
                    }

                    // Ràng buộc dữ liệu: Thư điện tử không hợp lệ.
                    if (!ValidationHelper.IsValidEmail(dto.Email))
                    {
                        return ServiceResult.Fail("Email không hợp lệ.");
                    }

                    // Kiểm tra tài khoản bị trùng qua tầng dữ liệu.
                    if (Repository.ExistsTaiKhoan(dto.TaiKhoan.Trim(), dto.MaNguoiDung))
                    {
                        return ServiceResult.Fail("Tài khoản học viên đã tồn tại.");
                    }

                    // Kiểm tra thư điện tử bị trùng qua tầng dữ liệu.
                    if (Repository.ExistsEmail(dto.Email.Trim(), dto.MaNguoiDung))
                    {
                        return ServiceResult.Fail("Email học viên đã tồn tại.");
                    }

                    var isNew = dto.MaNguoiDung == 0;
                    // Lưu học viên và chuyển lớp nếu có thay đổi qua tầng dữ liệu.
                    Repository.SaveHocVienVaChuyenLop(dto, maLopHoc);
                    return ServiceResult.Ok(isNew
                        ? "Thêm học viên thành công."
                        : "Cập nhật học viên thành công.");
                });
            }

            // Gọi tầng dữ liệu để xóa dữ liệu học viên sau khi giao diện xác nhận.
            public ServiceResult Xoa(int maNguoiDung)
            {
                return Try(() =>
                {
                    // Xóa người dùng đã chọn qua tầng dữ liệu.
                    Repository.DeleteNguoiDung(maNguoiDung);
                    return ServiceResult.Ok("Xóa học viên thành công.");
                });
            }
        }
}
