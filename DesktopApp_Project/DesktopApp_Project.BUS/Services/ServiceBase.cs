// Lớp nền cho các dịch vụ nghiệp vụ
// Chức năng:
// - Giữ kho dữ liệu tầng dữ liệu dùng chung
// - Chuẩn hóa xử lý lỗi thành kết quả xử lý cho giao diện

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
    // Lớp nền giúp các tầng nghiệp vụ dùng chung kho dữ liệu và chuẩn hóa kết quả xử lý.
    public abstract class ServiceBase
        {
            protected readonly IQuanLyIeltsRepository Repository;
    
            // Khởi tạo dịch vụ với kho dữ liệu để Tạo kết quả nghiệp vụ dùng chung.
            protected ServiceBase(IQuanLyIeltsRepository repository)
            {
                Repository = repository;
            }
    
            // Tạo kết quả nghiệp vụ dùng chung và trả kết quả cho giao diện.
            protected ServiceResult<T> Try<T>(Func<ServiceResult<T>> action)
            {
                try
                {
                    return action();
                }
                catch (Exception ex)
                {
                    return ServiceResult<T>.Fail("Lỗi xử lý dữ liệu: " + ex.Message);
                }
            }
    
            // Tạo kết quả nghiệp vụ dùng chung và trả kết quả cho giao diện.
            protected ServiceResult Try(Func<ServiceResult> action)
            {
                try
                {
                    return action();
                }
                catch (Exception ex)
                {
                    return ServiceResult.Fail("Lỗi xử lý dữ liệu: " + ex.Message);
                }
            }
        }
}
