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
    public class BaoCaoService : ServiceBase
        {
            public BaoCaoService(IQuanLyIeltsRepository repository) : base(repository) { }
    
            public ServiceResult<string> TaoBaoCao(BaoCaoDTO dto, int maNguoiDungLapBaoCao)
            {
                return Try(() =>
                {
                    if (AppConstants.ReportTypes.Contains(dto.LoaiBaoCao))
                    {
                        var htmlResult = TaoBaoCaoHtml(dto);
                        if (!htmlResult.Success)
                        {
                            return htmlResult;
                        }
    
                        Repository.GhiNhatKyBaoCao(maNguoiDungLapBaoCao, dto.LoaiBaoCao, "MaLopHoc=" + dto.MaLopHoc);
                        return ServiceResult<string>.Ok(htmlResult.Data, "Tạo báo cáo HTML thành công.");
                    }
    
                    var builder = new StringBuilder();
                    builder.AppendLine("BÁO CÁO QUẢN LÝ LỚP IELTS");
                    builder.AppendLine("Loại báo cáo: " + dto.LoaiBaoCao);
                    builder.AppendLine("Thời gian tạo: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                    builder.AppendLine(new string('-', 60));
    
                    if (dto.LoaiBaoCao == "Điểm số")
                    {
                        var lop = dto.MaLopHoc.HasValue ? Repository.GetLopHoc().FirstOrDefault(x => x.MaLopHoc == dto.MaLopHoc.Value) : null;
                        builder.AppendLine("Lớp: " + (lop == null ? "Tất cả" : lop.TenLop));
                        if (dto.MaLopHoc.HasValue)
                        {
                            foreach (var dot in Repository.GetDotKiemTra(dto.MaLopHoc.Value))
                            {
                                builder.AppendLine("Đợt kiểm tra: " + dot.TenDotKiemTra + " - " + dot.NgayKiemTra.ToString("dd/MM/yyyy"));
                                foreach (var diem in Repository.GetDiemSo(dot.MaDotKiemTra))
                                {
                                    builder.AppendLine(string.Format("{0}: L={1}, R={2}, W={3}, S={4}, Tổng={5}, Nhận xét={6}",
                                        diem.HoTen, diem.DiemL, diem.DiemR, diem.DiemW, diem.DiemS, diem.DiemTong, diem.NhanXet));
                                }
                            }
                        }
                    }
                    else
                    {
                        if (!dto.MaLopHoc.HasValue)
                        {
                            return ServiceResult<string>.Fail("Vui lòng chọn lớp để tạo báo cáo chuyên cần.");
                        }
    
                        var lop = Repository.GetLopHoc().FirstOrDefault(x => x.MaLopHoc == dto.MaLopHoc.Value);
                        builder.AppendLine("Lớp: " + (lop == null ? string.Empty : lop.TenLop));
                        foreach (var hv in Repository.GetHocVienTrongLop(dto.MaLopHoc.Value))
                        {
                            builder.AppendLine(hv.HoTen + ": " + Repository.TinhTiLeChuyenCan(hv.MaNguoiDung, dto.MaLopHoc.Value) + "% chuyên cần");
                        }
                    }
    
                    Repository.GhiNhatKyBaoCao(maNguoiDungLapBaoCao, dto.LoaiBaoCao, "MaLopHoc=" + dto.MaLopHoc);
                    return ServiceResult<string>.Ok(builder.ToString(), "Tạo báo cáo thành công.");
                });
            }
    
            private ServiceResult<string> TaoBaoCaoHtml(BaoCaoDTO dto)
            {
                if ((dto.LoaiBaoCao == "Chuyên cần" || dto.LoaiBaoCao == "Cuối kỳ") && (!dto.MaLopHoc.HasValue || dto.MaLopHoc.Value <= 0))
                {
                    return ServiceResult<string>.Fail("Vui lòng chọn lớp cho báo cáo này.");
                }
    
                var builder = new StringBuilder();
                builder.AppendLine("<!doctype html><html><head><meta charset=\"utf-8\"><title>Báo cáo IELTS</title>");
                builder.AppendLine("<style>body{font-family:Segoe UI,Arial,sans-serif;margin:24px;color:#222}table{border-collapse:collapse;width:100%;margin-top:16px}th,td{border:1px solid #ddd;padding:8px;text-align:left}th{background:#2A2A3E;color:#EAEAEA}.muted{color:#666}</style>");
                builder.AppendLine("</head><body>");
                builder.AppendLine("<h1>Báo cáo quản lý lớp IELTS</h1>");
                builder.AppendLine("<p class=\"muted\">Loại báo cáo: " + Html(dto.LoaiBaoCao) + " | Thời gian tạo: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "</p>");
    
                if (dto.LoaiBaoCao == "Điểm số")
                {
                    builder.AppendLine("<table><tr><th>Lớp</th><th>Học viên</th><th>Đợt kiểm tra</th><th>Điểm</th><th>Band estimate</th><th>Nhận xét</th></tr>");
                    foreach (var row in Repository.GetBaoCaoDiem(dto.MaLopHoc))
                    {
                        builder.AppendLine("<tr><td>" + Html(row.TenLop) + "</td><td>" + Html(row.HoTen) + "</td><td>" + Html(row.TenDotKiemTra) + "</td><td>" + Html(FormatScore(row.DiemTong)) + "</td><td>" + Html(FormatScore(row.DiemTong)) + "</td><td>" + Html(row.NhanXet) + "</td></tr>");
                    }
                    builder.AppendLine("</table>");
                }
                else if (dto.LoaiBaoCao == "Bài tập")
                {
                    builder.AppendLine("<table><tr><th>Học viên</th><th>Bài tập</th><th>Hạn nộp</th><th>Trạng thái</th></tr>");
                    foreach (var row in Repository.GetBaoCaoBaiTap(dto.MaLopHoc))
                    {
                        builder.AppendLine("<tr><td>" + Html(row.HoTen) + "</td><td>" + Html(row.TieuDe) + "</td><td>" + row.Deadline.ToString("dd/MM/yyyy") + "</td><td>" + Html(row.TrangThaiNop) + "</td></tr>");
                    }
                    builder.AppendLine("</table>");
                }
                else if (dto.LoaiBaoCao == "Chuyên cần")
                {
                    builder.AppendLine("<table><tr><th>Học viên</th><th>Có mặt</th><th>Vắng</th><th>Tỉ lệ</th></tr>");
                    foreach (var row in Repository.GetBaoCaoChuyenCan(dto.MaLopHoc.Value))
                    {
                        builder.AppendLine("<tr><td>" + Html(row.HoTen) + "</td><td>" + row.SoBuoiCoMat + "</td><td>" + row.SoBuoiVang + "</td><td>" + row.TiLeChuyenCan.ToString("0.##") + "%</td></tr>");
                    }
                    builder.AppendLine("</table>");
                }
                else if (dto.LoaiBaoCao == "Cuối kỳ")
                {
                    builder.AppendLine("<table><tr><th>Học viên</th><th>Đợt kiểm tra</th><th>Điểm</th><th>Trung bình</th><th>Nhận xét giáo viên</th></tr>");
                    foreach (var row in Repository.GetBaoCaoCuoiKy(dto.MaLopHoc.Value))
                    {
                        builder.AppendLine("<tr><td>" + Html(row.HoTen) + "</td><td>" + Html(row.TenDotKiemTra) + "</td><td>" + Html(FormatScore(row.DiemTong)) + "</td><td>" + Html(FormatScore(row.DiemTrungBinh)) + "</td><td>" + Html(row.NhanXet) + "</td></tr>");
                    }
                    builder.AppendLine("</table>");
                }
    
                builder.AppendLine("</body></html>");
                return ServiceResult<string>.Ok(builder.ToString(), "OK");
            }
    
            private static string FormatScore(decimal? score)
            {
                return score.HasValue ? score.Value.ToString("0.0") : string.Empty;
            }
    
            private static string Html(string value)
            {
                if (value == null)
                {
                    return string.Empty;
                }
    
                return value.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;");
            }
    
            public ServiceResult XuatBaoCao(string noiDung, string filePath)
            {
                return Try(() =>
                {
                    if (ValidationHelper.IsBlank(noiDung) || ValidationHelper.IsBlank(filePath))
                    {
                        return ServiceResult.Fail("Không có nội dung hoặc đường dẫn xuất báo cáo.");
                    }
    
                    File.WriteAllText(filePath, noiDung, Encoding.UTF8);
                    return ServiceResult.Ok("Xuất báo cáo thành công.");
                });
            }
        }
}

