// Dịch vụ xử lý nghiệp vụ lưu trữ ngoài mô phỏng
// Chức năng:
// - Nhận dữ liệu từ giao diện dưới dạng đối tượng truyền dữ liệu hoặc tham số lọc
// - Kiểm tra nghiệp vụ trước khi gọi tầng dữ liệu
// - Trả kết quả xử lý hoặc danh sách đối tượng truyền dữ liệu cho giao diện

using System;
using System.IO;
using DesktopApp_Project.Common;

namespace DesktopApp_Project.BUS
{
    // Lớp xử lý nghiệp vụ lưu trữ ngoài mô phỏng, kiểm tra dữ liệu trước khi gọi kho dữ liệu/tầng dữ liệu.
    public class FakeExternalStorageService : IExternalStorageService
    {
        // Xử lý tải tệp lên kho lưu trữ.
        public ServiceResult<string> UploadFile(string localFilePath, string folderName)
        {
            try
            {
                var source = ResolvePath(localFilePath);
                // Ràng buộc dữ liệu: Tệp cần tải lên không tồn tại.
                if (string.IsNullOrWhiteSpace(source) || !File.Exists(source))
                {
                    return ServiceResult<string>.Fail("File can upload khong ton tai.");
                }

                folderName = SanitizePathSegment(folderName);
                var targetFolder = Path.Combine(AppRoot, "Uploads", "CloudMock", folderName);
                Directory.CreateDirectory(targetFolder);

                var storedName = Guid.NewGuid().ToString("N") + "_" + SanitizeFileName(Path.GetFileName(source));
                File.Copy(source, Path.Combine(targetFolder, storedName), false);

                return ServiceResult<string>.Ok("https://fake-storage.local/" + folderName + "/" + storedName, "Upload cloud gia lap thanh cong.");
            }
            catch (Exception ex)
            {
                return ServiceResult<string>.Fail("Khong the upload cloud gia lap: " + ex.Message);
            }
        }

        // Gọi tầng dữ liệu để xóa dữ liệu lưu trữ ngoài mô phỏng sau khi giao diện xác nhận.
        public ServiceResult DeleteFile(string fileUrl)
        {
            return ServiceResult.Ok("Da ghi nhan xoa file cloud gia lap.");
        }

        // Xử lý đường dẫn tệp thực tế.
        private static string ResolvePath(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || Path.IsPathRooted(path))
            {
                return path;
            }

            return Path.Combine(AppRoot, path.Replace('/', Path.DirectorySeparatorChar));
        }

        private static string AppRoot
        {
            get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QuanLyLopIELTS"); }
        }

        // Xử lý đoạn đường dẫn an toàn.
        private static string SanitizePathSegment(string value)
        {
            value = string.IsNullOrWhiteSpace(value) ? "General" : value.Trim();
            foreach (var invalid in Path.GetInvalidFileNameChars())
            {
                value = value.Replace(invalid, '_');
            }

            return value;
        }

        // Xử lý tên tệp an toàn.
        private static string SanitizeFileName(string value)
        {
            value = string.IsNullOrWhiteSpace(value) ? "upload" : value.Trim();
            foreach (var invalid in Path.GetInvalidFileNameChars())
            {
                value = value.Replace(invalid, '_');
            }

            return value;
        }
    }
}
