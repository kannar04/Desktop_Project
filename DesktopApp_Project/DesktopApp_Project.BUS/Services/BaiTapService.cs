// Dịch vụ xử lý nghiệp vụ bài tập
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
    // Lớp xử lý nghiệp vụ bài tập, kiểm tra dữ liệu trước khi gọi kho dữ liệu/tầng dữ liệu.
    public class BaiTapService : ServiceBase
        {
            public BaiTapService(IQuanLyIeltsRepository repository) : base(repository) { }
    
            // Lấy danh sách.
            public List<BaiTapDTO> LayDanhSach(int? maLopHoc)
            {
                // Lấy danh sách bài tập theo lớp qua tầng dữ liệu.
                return Repository.GetBaiTap(maLopHoc);
            }
    
            // Xử lý bài tập cho lớp.
            public ServiceResult GiaoBai(BaiTapDTO dto)
            {
                return Try(() =>
                {
                    // Ràng buộc dữ liệu: chọn lớp, nhập tiêu đề và mô tả bài tập.
                    if (dto.MaLopHoc <= 0 || ValidationHelper.IsBlank(dto.TieuDe) || ValidationHelper.IsBlank(dto.MoTa))
                    {
                        return ServiceResult.Fail("Vui lòng chọn lớp, nhập tiêu đề và mô tả bài tập.");
                    }
    
                    if (dto.Deadline <= DateTime.Now)
                    {
                        return ServiceResult.Fail("Hạn nộp phải lớn hơn thời điểm hiện tại.");
                    }
    
                    // Ràng buộc dữ liệu: Định dạng tệp đính kèm không được hỗ trợ.
                    if (!ValidationHelper.IsSupportedFile(dto.FileDinhKem, new[] { ".pdf", ".doc", ".docx", ".zip", ".rar" }))
                    {
                        return ServiceResult.Fail("Định dạng file đính kèm không được hỗ trợ.");
                    }
    
                    if (dto.MaBaiTap == 0)
                    {
                        // Thêm bài tập mới qua tầng dữ liệu.
                        var maBaiTap = Repository.InsertBaiTap(dto);
                        // Tạo dòng nộp bài cho từng học viên trong lớp qua tầng dữ liệu.
                        Repository.TaoChiTietNopBaiChoLop(maBaiTap, dto.MaLopHoc);
                        return ServiceResult.Ok("Giao bài tập thành công.");
                    }
    
                    // Cập nhật thông tin bài tập qua tầng dữ liệu.
                    Repository.UpdateBaiTap(dto);
                    // Tạo dòng nộp bài cho từng học viên trong lớp qua tầng dữ liệu.
                    Repository.TaoChiTietNopBaiChoLop(dto.MaBaiTap, dto.MaLopHoc);
                    return ServiceResult.Ok("Cập nhật bài tập thành công.");
                });
            }
    
            // Gọi tầng dữ liệu để xóa dữ liệu bài tập sau khi giao diện xác nhận.
            public ServiceResult Xoa(int maBaiTap)
            {
                return Try(() =>
                {
                    // Xóa bài tập đã chọn qua tầng dữ liệu.
                    Repository.DeleteBaiTap(maBaiTap);
                    return ServiceResult.Ok("Xóa bài tập thành công.");
                });
            }
        }
}

