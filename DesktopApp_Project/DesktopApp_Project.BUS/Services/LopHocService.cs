// Dịch vụ xử lý nghiệp vụ lớp học
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
    // Lớp xử lý nghiệp vụ lớp học, kiểm tra dữ liệu trước khi gọi kho dữ liệu/tầng dữ liệu.
    public class LopHocService : ServiceBase
        {
            public LopHocService(IQuanLyIeltsRepository repository) : base(repository) { }
    
            // Lấy danh sách.
            public List<LopHocDTO> LayDanhSach()
            {
                // Lấy danh sách lớp học qua tầng dữ liệu.
                return Repository.GetLopHoc();
            }
    
            // Lấy danh sách học viên trong lớp.
            public List<NguoiDungDTO> LayHocVienTrongLop(int maLopHoc)
            {
                // Lấy danh sách học viên trong lớp qua tầng dữ liệu.
                return Repository.GetHocVienTrongLop(maLopHoc);
            }
    
            // Kiểm tra nghiệp vụ rồi gọi tầng dữ liệu để lưu dữ liệu lớp học.
            public ServiceResult Luu(LopHocDTO dto)
            {
                return Try(() =>
                {
                    // Ràng buộc dữ liệu: Tên lớp và nhóm trình độ không được để trống.
                    if (ValidationHelper.IsBlank(dto.TenLop) || ValidationHelper.IsBlank(dto.NhomTrinhDo))
                    {
                        return ServiceResult.Fail("Tên lớp và nhóm trình độ không được để trống.");
                    }
    
                    // Kiểm tra tên lớp bị trùng qua tầng dữ liệu.
                    if (Repository.ExistsTenLop(dto.TenLop.Trim(), dto.MaLopHoc))
                    {
                        return ServiceResult.Fail("Tên lớp đã tồn tại.");
                    }
    
                    // Kiểm tra lịch học bị trùng qua tầng dữ liệu.
                    if (Repository.ExistsLichHoc(dto.LichHoc, dto.MaLopHoc))
                    {
                        return ServiceResult.Fail("Lịch học đã trùng với lớp khác.");
                    }
    
                    if (dto.MaLopHoc == 0)
                    {
                        // Thêm lớp học mới qua tầng dữ liệu.
                        Repository.InsertLopHoc(dto);
                        return ServiceResult.Ok("Tạo lớp học thành công.");
                    }
    
                    // Cập nhật thông tin lớp học qua tầng dữ liệu.
                    Repository.UpdateLopHoc(dto);
                    return ServiceResult.Ok("Cập nhật lớp học thành công.");
                });
            }
    
            // Gọi tầng dữ liệu để xóa dữ liệu lớp học sau khi giao diện xác nhận.
            public ServiceResult Xoa(int maLopHoc)
            {
                return Try(() =>
                {
                    // Xóa lớp học đã chọn qua tầng dữ liệu.
                    Repository.DeleteLopHoc(maLopHoc);
                    return ServiceResult.Ok("Xóa lớp học thành công.");
                });
            }
    
        }
}
