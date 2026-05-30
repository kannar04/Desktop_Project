using System;
using System.IO;
using DesktopApp_Project.Common;

namespace DesktopApp_Project.BUS
{
    public class FakeExternalStorageService : IExternalStorageService
    {
        public ServiceResult<string> UploadFile(string localFilePath, string folderName)
        {
            try
            {
                var source = ResolvePath(localFilePath);
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

        public ServiceResult DeleteFile(string fileUrl)
        {
            return ServiceResult.Ok("Da ghi nhan xoa file cloud gia lap.");
        }

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
