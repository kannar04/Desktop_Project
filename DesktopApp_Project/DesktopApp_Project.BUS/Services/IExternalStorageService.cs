using DesktopApp_Project.Common;

namespace DesktopApp_Project.BUS
{
    public interface IExternalStorageService
    {
        ServiceResult<string> UploadFile(string localFilePath, string folderName);
        ServiceResult DeleteFile(string fileUrl);
    }
}
