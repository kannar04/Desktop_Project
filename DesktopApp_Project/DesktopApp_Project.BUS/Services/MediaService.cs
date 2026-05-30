using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using DesktopApp_Project.Common;
using DesktopApp_Project.DAL;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.BUS
{
    public class MediaService : ServiceBase
    {
        private readonly IExternalStorageService _externalStorage;

        public MediaService(IQuanLyIeltsRepository repository, IExternalStorageService externalStorage)
            : base(repository)
        {
            _externalStorage = externalStorage;
        }

        public ServiceResult<MediaFileDTO> CopyFileToUploadFolder(string sourcePath, string moduleName)
        {
            return Try(() =>
            {
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

        public ServiceResult<string> UploadToFakeCloud(string localPath, string moduleName)
        {
            return _externalStorage.UploadFile(ResolvePath(localPath), moduleName);
        }

        public ServiceResult OpenFile(string localPath)
        {
            return Try(() =>
            {
                var path = ResolvePath(localPath);
                if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                {
                    return ServiceResult.Fail("File khong ton tai.");
                }

                Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
                return ServiceResult.Ok("Da mo file.");
            });
        }

        public string ResolvePath(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || Path.IsPathRooted(path))
            {
                return path;
            }

            return Path.Combine(AppRoot, path.Replace('/', Path.DirectorySeparatorChar));
        }

        public bool IsSupported(string path)
        {
            var extension = Path.GetExtension(path).ToLowerInvariant();
            return AppConstants.SupportedMediaExtensions.Contains(extension);
        }

        public bool IsImage(string path)
        {
            var extension = Path.GetExtension(path).ToLowerInvariant();
            return new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" }.Contains(extension);
        }

        public bool IsVideo(string path)
        {
            var extension = Path.GetExtension(path).ToLowerInvariant();
            return new[] { ".mp4", ".mov", ".avi", ".mkv" }.Contains(extension);
        }

        public bool IsAudio(string path)
        {
            var extension = Path.GetExtension(path).ToLowerInvariant();
            return new[] { ".mp3", ".wav", ".m4a" }.Contains(extension);
        }

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

        private static string SanitizePathSegment(string value)
        {
            value = string.IsNullOrWhiteSpace(value) ? "General" : value.Trim();
            foreach (var invalid in Path.GetInvalidFileNameChars())
            {
                value = value.Replace(invalid, '_');
            }

            return value;
        }

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
