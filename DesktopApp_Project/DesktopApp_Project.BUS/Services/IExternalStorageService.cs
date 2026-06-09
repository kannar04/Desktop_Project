// Dịch vụ xử lý nghiệp vụ lưu trữ ngoài
// Chức năng:
// - Nhận dữ liệu từ giao diện dưới dạng đối tượng truyền dữ liệu hoặc tham số lọc
// - Kiểm tra nghiệp vụ trước khi gọi tầng dữ liệu
// - Trả kết quả xử lý hoặc danh sách đối tượng truyền dữ liệu cho giao diện

using DesktopApp_Project.Common;

namespace DesktopApp_Project.BUS
{
    // Hợp đồng khai báo hợp đồng xử lý lưu trữ ngoài cho các lớp cài đặt.
    public interface IExternalStorageService
    {
        // Thực hiện nghiệp vụ lưu trữ ngoài và trả kết quả cho giao diện.
        ServiceResult<string> UploadFile(string localFilePath, string folderName);
        // Khai báo thao tác xóa tệp trên nơi lưu trữ ngoài sau khi người dùng xác nhận.
        ServiceResult DeleteFile(string fileUrl);
    }
}
