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
    public class DashboardService : ServiceBase
        {
            public DashboardService(IQuanLyIeltsRepository repository) : base(repository) { }
    
            public ServiceResult<DashboardSummaryDTO> LayTongQuan()
            {
                return Try(() => ServiceResult<DashboardSummaryDTO>.Ok(Repository.GetDashboardSummary(DateTime.Today), "Tải tổng quan thành công."));
            }
    
            public ServiceResult<List<MonthlyRevenueDTO>> LayDoanhThuThang(int soThang)
            {
                return Try(() => ServiceResult<List<MonthlyRevenueDTO>>.Ok(Repository.GetRevenueByMonth(soThang, DateTime.Today), "Tải doanh thu thành công."));
            }
    
            public ServiceResult<List<WeeklyScheduleDTO>> LayLichHocTuan()
            {
                return Try(() => ServiceResult<List<WeeklyScheduleDTO>>.Ok(Repository.GetWeeklySchedule(DateTime.Today), "Tải lịch học tuần thành công."));
            }
        }
}

