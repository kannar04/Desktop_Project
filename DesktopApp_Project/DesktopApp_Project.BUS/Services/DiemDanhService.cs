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
    public class DiemDanhService : ServiceBase
        {
            public DiemDanhService(IQuanLyIeltsRepository repository) : base(repository) { }
    
            public ServiceResult<List<DiemDanhDTO>> LayBangDiemDanh(int maLopHoc, DateTime ngayHoc)
            {
                return Try(() =>
                {
                    if (maLopHoc <= 0)
                    {
                        return ServiceResult<List<DiemDanhDTO>>.Fail("Vui lòng chọn lớp học.");
                    }
    
                    var maBuoiHoc = Repository.GetOrCreateBuoiHoc(maLopHoc, ngayHoc);
                    var hocVien = Repository.GetHocVienLop(maLopHoc, true);
                    var daDiemDanh = Repository.GetDiemDanh(maBuoiHoc).ToDictionary(x => x.MaNguoiDung);
                    var result = new List<DiemDanhDTO>();
    
                    foreach (var hv in hocVien)
                    {
                        DiemDanhDTO dto;
                        if (!daDiemDanh.TryGetValue(hv.MaNguoiDung, out dto))
                        {
                            dto = new DiemDanhDTO
                            {
                                MaNguoiDung = hv.MaNguoiDung,
                                MaBuoiHoc = maBuoiHoc,
                                HoTen = hv.HoTen,
                                TrangThai = AppConstants.AttendancePresent,
                                CoMat = true
                            };
                        }
                        else
                        {
                            dto.CoMat = dto.TrangThai == AppConstants.AttendancePresent || dto.TrangThai == AppConstants.AttendanceLate;
                        }
    
                        dto.TiLeChuyenCan = Repository.TinhTiLeChuyenCan(hv.MaNguoiDung, maLopHoc);
                        result.Add(dto);
                    }
    
                    return ServiceResult<List<DiemDanhDTO>>.Ok(result, "Tải bảng điểm danh thành công.");
                });
            }
    
            public ServiceResult Luu(DiemDanhDTO dto)
            {
                return Try(() =>
                {
                    if (ValidationHelper.IsBlank(dto.TrangThai))
                    {
                        dto.TrangThai = dto.CoMat ? AppConstants.AttendancePresent : AppConstants.AttendanceAbsent;
                    }

                    if (!AppConstants.AttendanceStatuses.Contains(dto.TrangThai))
                    {
                        return ServiceResult.Fail("Vui lòng chọn trạng thái điểm danh hợp lệ.");
                    }

                    dto.CoMat = dto.TrangThai == AppConstants.AttendancePresent || dto.TrangThai == AppConstants.AttendanceLate;
                    dto.LyDoVang = dto.TrangThai == AppConstants.AttendanceAbsent ? dto.LyDoVang : string.Empty;
    
                    Repository.LuuDiemDanh(dto);
                    return ServiceResult.Ok("Lưu điểm danh thành công.");
                });
            }
    
            public ServiceResult LuuTatCa(IEnumerable<DiemDanhDTO> danhSach)
            {
                return Try(() =>
                {
                    var rows = (danhSach ?? Enumerable.Empty<DiemDanhDTO>()).ToList();
                    if (rows.Count == 0)
                    {
                        return ServiceResult.Fail("Không có học viên để lưu điểm danh.");
                    }
    
                    foreach (var row in rows)
                    {
                        if (row.MaNguoiDung <= 0 || row.MaBuoiHoc <= 0)
                        {
                            return ServiceResult.Fail("Dữ liệu điểm danh không hợp lệ.");
                        }

                        if (ValidationHelper.IsBlank(row.TrangThai))
                        {
                            row.TrangThai = row.CoMat ? AppConstants.AttendancePresent : AppConstants.AttendanceAbsent;
                        }

                        if (!AppConstants.AttendanceStatuses.Contains(row.TrangThai))
                        {
                            return ServiceResult.Fail("Vui lòng chọn trạng thái điểm danh hợp lệ.");
                        }

                        row.CoMat = row.TrangThai == AppConstants.AttendancePresent || row.TrangThai == AppConstants.AttendanceLate;
                        row.LyDoVang = row.TrangThai == AppConstants.AttendanceAbsent ? row.LyDoVang : string.Empty;
                    }
    
                    Repository.LuuDiemDanh(rows);
                    return ServiceResult.Ok("Đã lưu điểm danh cho toàn bộ lớp.");
                });
            }
        }
}
