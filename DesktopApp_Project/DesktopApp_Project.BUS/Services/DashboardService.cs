// Dịch vụ xử lý nghiệp vụ màn hình tổng quan
// Chức năng:
// - Nhận dữ liệu từ giao diện dưới dạng đối tượng truyền dữ liệu hoặc tham số lọc
// - Kiểm tra nghiệp vụ trước khi gọi tầng dữ liệu
// - Trả kết quả xử lý hoặc danh sách đối tượng truyền dữ liệu cho giao diện

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
    // Lớp xử lý nghiệp vụ màn hình tổng quan, kiểm tra dữ liệu trước khi gọi kho dữ liệu/tầng dữ liệu.
    public class DashboardService : ServiceBase
        {
            public DashboardService(IQuanLyIeltsRepository repository) : base(repository) { }
    
            // Lấy số liệu tổng quan.
            public ServiceResult<DashboardSummaryDTO> LayTongQuan()
            {
                return Try(() => ServiceResult<DashboardSummaryDTO>.Ok(Repository.GetDashboardSummary(DateTime.Today), "Tải tổng quan thành công."));
            }
    
            // Lấy doanh thu theo tháng.
            public ServiceResult<List<MonthlyRevenueDTO>> LayDoanhThuThang(int soThang)
            {
                return Try(() => ServiceResult<List<MonthlyRevenueDTO>>.Ok(Repository.GetRevenueByMonth(soThang, DateTime.Today), "Tải doanh thu thành công."));
            }
    
            // Lấy lịch học trong tuần.
            public ServiceResult<List<WeeklyScheduleDTO>> LayLichHocTuan()
            {
                return Try(() => ServiceResult<List<WeeklyScheduleDTO>>.Ok(Repository.GetWeeklySchedule(DateTime.Today), "Tải lịch học tuần thành công."));
            }
        }
}

