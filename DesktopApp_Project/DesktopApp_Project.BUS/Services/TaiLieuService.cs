// Dịch vụ xử lý nghiệp vụ tài liệu học tập
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
    // Lớp xử lý nghiệp vụ tài liệu học tập, kiểm tra dữ liệu trước khi gọi kho dữ liệu/tầng dữ liệu.
    public class TaiLieuService : ServiceBase
        {
            private static readonly string[] SupportedAudioExtensions = { ".mp3", ".wav", ".m4a", ".aac", ".flac" };

            public TaiLieuService(IQuanLyIeltsRepository repository) : base(repository) { }
    
            // Lấy danh sách.
            public List<TaiLieuDTO> LayDanhSach(int? maLopHoc)
            {
                // Lấy danh sách tài liệu theo lớp qua tầng dữ liệu.
                return Repository.GetTaiLieu(maLopHoc);
            }
    
            // Kiểm tra nghiệp vụ rồi gọi tầng dữ liệu để lưu dữ liệu tài liệu học tập.
            public ServiceResult Luu(TaiLieuDTO dto)
            {
                return Try(() =>
                {
                    // Ràng buộc dữ liệu: chọn lớp và nhập tên chủ đề.
                    if (dto.MaLopHoc <= 0 || ValidationHelper.IsBlank(dto.TenChuDe))
                    {
                        return ServiceResult.Fail("Vui lòng chọn lớp và nhập tên chủ đề.");
                    }
    
                    // Ràng buộc dữ liệu: Nhãn kỹ năng phải là Listening, Reading, Writing hoặc Speaking.
                    if (!ValidationHelper.IsValidSkill(dto.NhanKyNang))
                    {
                        return ServiceResult.Fail("Nhãn kỹ năng phải là Listening, Reading, Writing hoặc Speaking.");
                    }
    
                    // Ràng buộc dữ liệu: Định dạng tệp không được hỗ trợ.
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
    
                    // Ràng buộc dữ liệu: Link video không hợp lệ.
                    if (!ValidationHelper.IsValidVideoLink(dto.VideoLink))
                    {
                        return ServiceResult.Fail("Link video không hợp lệ.");
                    }
    
                    if (dto.MaTaiLieu == 0)
                    {
                        // Thêm tài liệu mới qua tầng dữ liệu.
                        Repository.InsertTaiLieu(dto);
                        return ServiceResult.Ok("Cập nhật tài liệu thành công.");
                    }
    
                    // Cập nhật thông tin tài liệu qua tầng dữ liệu.
                    Repository.UpdateTaiLieu(dto);
                    return ServiceResult.Ok("Sửa tài liệu thành công.");
                });
            }

            // Xử lý exceeds.
            private static bool Exceeds(string value, int maxLength)
            {
                return !string.IsNullOrEmpty(value) && value.Length > maxLength;
            }
    
            // Gọi tầng dữ liệu để xóa dữ liệu tài liệu học tập sau khi giao diện xác nhận.
            public ServiceResult Xoa(int maTaiLieu)
            {
                return Try(() =>
                {
                    // Xóa tài liệu đã chọn qua tầng dữ liệu.
                    Repository.DeleteTaiLieu(maTaiLieu);
                    return ServiceResult.Ok("Xóa tài liệu thành công.");
                });
            }
        }
}
