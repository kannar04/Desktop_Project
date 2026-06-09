
// Kiểu kết quả dùng chung cho tầng nghiệp vụ
// Chức năng:
// - Gói trạng thái thành công/thất bại
// - Truyền thông báo và dữ liệu từ tầng nghiệp vụ về giao diện


namespace DesktopApp_Project.Common
{
    // Lớp kết quả chuẩn hóa trạng thái và thông báo trả từ tầng nghiệp vụ về giao diện.
    public class ServiceResult
        {
            public bool Success { get; set; }
            public string Message { get; set; }
    
            // Tạo kết quả chuẩn để tầng nghiệp vụ trả trạng thái về giao diện.
            public static ServiceResult Ok(string message)
            {
                // Tạo đối tượng kết quả chuẩn để tầng nghiệp vụ trả về giao diện.
                return new ServiceResult { Success = true, Message = message };
            }
    
            // Tạo kết quả chuẩn để tầng nghiệp vụ trả trạng thái về giao diện.
            public static ServiceResult Fail(string message)
            {
                // Tạo đối tượng kết quả chuẩn để tầng nghiệp vụ trả về giao diện.
                return new ServiceResult { Success = false, Message = message };
            }
        }

    // Lớp kết quả chuẩn hóa trạng thái và thông báo trả từ tầng nghiệp vụ về giao diện.
    public class ServiceResult<T> : ServiceResult
        {
            public T Data { get; set; }
    
            // Tạo kết quả chuẩn để tầng nghiệp vụ trả trạng thái về giao diện.
            public static ServiceResult<T> Ok(T data, string message)
            {
                // Tạo đối tượng kết quả chuẩn để tầng nghiệp vụ trả về giao diện.
                return new ServiceResult<T> { Success = true, Data = data, Message = message };
            }
    
            // Tạo kết quả chuẩn để tầng nghiệp vụ trả trạng thái về giao diện.
            public new static ServiceResult<T> Fail(string message)
            {
                // Tạo đối tượng kết quả chuẩn để tầng nghiệp vụ trả về giao diện.
                return new ServiceResult<T> { Success = false, Message = message };
            }
        }
}

