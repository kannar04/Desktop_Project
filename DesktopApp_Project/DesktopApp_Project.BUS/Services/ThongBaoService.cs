// Dịch vụ xử lý nghiệp vụ thông báo
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
    // Lớp xử lý nghiệp vụ thông báo, kiểm tra dữ liệu trước khi gọi kho dữ liệu/tầng dữ liệu.
    public class ThongBaoService : ServiceBase
        {
            public ThongBaoService(IQuanLyIeltsRepository repository) : base(repository) { }
    
            // Lấy danh sách.
            public List<ThongBaoDTO> LayDanhSach()
            {
                // Lấy danh sách thông báo qua tầng dữ liệu.
                return Repository.GetThongBao();
            }
    
            // Xử lý gửi.
            public ServiceResult Gui(ThongBaoDTO dto, int? maLopHoc)
            {
                return Try(() =>
                {
                    // Ràng buộc dữ liệu: Tiêu đề và nội dung thông báo không được để trống.
                    if (ValidationHelper.IsBlank(dto.TieuDe) || ValidationHelper.IsBlank(dto.NoiDung))
                    {
                        return ServiceResult.Fail("Tiêu đề và nội dung thông báo không được để trống.");
                    }
    
                    List<int> nguoiNhan;
                    if (maLopHoc.HasValue)
                    {
                        // Lấy danh sách học viên trong lớp qua tầng dữ liệu.
                        nguoiNhan = Repository.GetHocVienTrongLop(maLopHoc.Value).Select(x => x.MaNguoiDung).ToList();
                        dto.DoiTuongNhan = "Lớp " + maLopHoc.Value;
                    }
                    else
                    {
                        // Lấy danh sách người dùng theo vai trò qua tầng dữ liệu.
                        nguoiNhan = Repository.GetNguoiDungByVaiTro(AppConstants.RoleStudent).Select(x => x.MaNguoiDung).ToList();
                        dto.DoiTuongNhan = "Tất cả học viên";
                    }
    
                    if (nguoiNhan.Count == 0)
                    {
                        return ServiceResult.Fail("Không có học viên nhận thông báo.");
                    }
    
                    // Thêm thông báo mới qua tầng dữ liệu.
                    var maThongBao = Repository.InsertThongBao(dto);
                    // Tạo danh sách người nhận thông báo qua tầng dữ liệu.
                    Repository.TaoNguoiNhanThongBao(maThongBao, nguoiNhan);
                    return ServiceResult.Ok("Gửi thông báo thành công.");
                });
            }
        }
}
