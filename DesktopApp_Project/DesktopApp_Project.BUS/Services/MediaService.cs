// Dịch vụ xử lý nghiệp vụ tệp đa phương tiện
// Chức năng:
// - Nhận dữ liệu từ giao diện dưới dạng đối tượng truyền dữ liệu hoặc tham số lọc
// - Kiểm tra nghiệp vụ trước khi gọi tầng dữ liệu
// - Trả kết quả xử lý hoặc danh sách đối tượng truyền dữ liệu cho giao diện

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using DesktopApp_Project.Common;
using DesktopApp_Project.DAL;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.BUS
{
    // Lớp xử lý nghiệp vụ tệp đa phương tiện, kiểm tra dữ liệu trước khi gọi kho dữ liệu/tầng dữ liệu.
    public class MediaService : ServiceBase
    {
        private readonly IExternalStorageService _externalStorage;

        public MediaService(IQuanLyIeltsRepository repository, IExternalStorageService externalStorage)
            : base(repository)
        {
            _externalStorage = externalStorage;
        }

        // Xử lý tệp vào thư mục tải lên.
        public ServiceResult<MediaFileDTO> CopyFileToUploadFolder(string sourcePath, string moduleName)
        {
            return Try(() =>
            {
                // Ràng buộc dữ liệu: Tệp nguồn không tồn tại.
                if (string.IsNullOrWhiteSpace(sourcePath) || !File.Exists(sourcePath))
                {
                    return ServiceResult<MediaFileDTO>.Fail("File nguon khong ton tai.");
                }

                if (!IsSupported(sourcePath))
                {
                    return ServiceResult<MediaFileDTO>.Fail("Dinh dang file khong duoc ho tro.");
                }

                moduleName = SanitizePathSegment(moduleName);
                var targetFolder = Path.Combine(AppRoot, "Uploads", moduleName);
                Directory.CreateDirectory(targetFolder);

                var originalName = SanitizeFileName(Path.GetFileName(sourcePath));
                var storedName = Guid.NewGuid().ToString("N") + "_" + originalName;
                var targetPath = Path.Combine(targetFolder, storedName);
                File.Copy(sourcePath, targetPath, false);

                var info = new FileInfo(sourcePath);
                return ServiceResult<MediaFileDTO>.Ok(new MediaFileDTO
                {
                    OriginalFileName = Path.GetFileName(sourcePath),
                    Extension = Path.GetExtension(sourcePath),
                    FileType = GetFileType(sourcePath),
                    LocalPath = "Uploads/" + moduleName + "/" + storedName,
                    SizeInBytes = info.Length
                }, "Da sao chep file vao thu muc quan ly.");
            });
        }

        // Xử lý tệp lên kho đám mây giả lập.
        public ServiceResult<string> UploadToFakeCloud(string localPath, string moduleName)
        {
            return _externalStorage.UploadFile(ResolvePath(localPath), moduleName);
        }

        // Hiển thị tệp.
        public ServiceResult OpenFile(string localPath)
        {
            return Try(() =>
            {
                var path = ResolvePath(localPath);
                // Ràng buộc dữ liệu: Tệp không tồn tại.
                if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                {
                    return ServiceResult.Fail("File khong ton tai.");
                }

                Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
                return ServiceResult.Ok("Da mo file.");
            });
        }

        // Xử lý đường dẫn tệp thực tế.
        public string ResolvePath(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || Path.IsPathRooted(path))
            {
                return path;
            }

            return Path.Combine(AppRoot, path.Replace('/', Path.DirectorySeparatorChar));
        }

        // Xử lý định dạng tệp được hỗ trợ.
        public bool IsSupported(string path)
        {
            var extension = Path.GetExtension(path).ToLowerInvariant();
            return AppConstants.SupportedMediaExtensions.Contains(extension);
        }

        // Xử lý tệp hình ảnh.
        public bool IsImage(string path)
        {
            var extension = Path.GetExtension(path).ToLowerInvariant();
            return new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" }.Contains(extension);
        }

        // Xử lý tệp video.
        public bool IsVideo(string path)
        {
            var extension = Path.GetExtension(path).ToLowerInvariant();
            return new[] { ".mp4", ".mov", ".avi", ".mkv" }.Contains(extension);
        }

        // Xử lý tệp âm thanh.
        public bool IsAudio(string path)
        {
            var extension = Path.GetExtension(path).ToLowerInvariant();
            return new[] { ".mp3", ".wav", ".m4a", ".aac", ".flac" }.Contains(extension);
        }

        // Lấy loại tệp.
        public string GetFileType(string path)
        {
            if (IsImage(path)) return "Image";
            if (IsVideo(path)) return "Video";
            if (IsAudio(path)) return "Audio";
            return "Document";
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
