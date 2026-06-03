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
    public abstract class ServiceBase
        {
            protected readonly IQuanLyIeltsRepository Repository;
    
            protected ServiceBase(IQuanLyIeltsRepository repository)
            {
                Repository = repository;
            }
    
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
