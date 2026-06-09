// Dịch vụ xử lý nghiệp vụ báo cáo
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
    // Lớp xử lý nghiệp vụ báo cáo, kiểm tra dữ liệu trước khi gọi kho dữ liệu/tầng dữ liệu.
    public class BaoCaoService : ServiceBase
        {
            public BaoCaoService(IQuanLyIeltsRepository repository) : base(repository) { }
    
            // Tạo báo cáo.
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
    
                        // Xử lý nhật ký lập báo cáo qua tầng dữ liệu.
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
                        // Lấy danh sách lớp học qua tầng dữ liệu.
                        var lop = dto.MaLopHoc.HasValue ? Repository.GetLopHoc().FirstOrDefault(x => x.MaLopHoc == dto.MaLopHoc.Value) : null;
                        builder.AppendLine("Lớp: " + (lop == null ? "Tất cả" : lop.TenLop));
                        if (dto.MaLopHoc.HasValue)
                        {
                            // Lấy danh sách đợt kiểm tra của lớp qua tầng dữ liệu.
                            foreach (var dot in Repository.GetDotKiemTra(dto.MaLopHoc.Value))
                            {
                                builder.AppendLine("Đợt kiểm tra: " + dot.TenDotKiemTra + " - " + dot.NgayKiemTra.ToString("dd/MM/yyyy"));
                                // Lấy danh sách điểm số của đợt kiểm tra qua tầng dữ liệu.
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
    
                        // Lấy danh sách lớp học qua tầng dữ liệu.
                        var lop = Repository.GetLopHoc().FirstOrDefault(x => x.MaLopHoc == dto.MaLopHoc.Value);
                        builder.AppendLine("Lớp: " + (lop == null ? string.Empty : lop.TenLop));
                        // Lấy danh sách học viên trong lớp qua tầng dữ liệu.
                        foreach (var hv in Repository.GetHocVienTrongLop(dto.MaLopHoc.Value))
                        {
                            // Tính tỉ lệ chuyên cần qua tầng dữ liệu.
                            builder.AppendLine(hv.HoTen + ": " + Repository.TinhTiLeChuyenCan(hv.MaNguoiDung, dto.MaLopHoc.Value) + "% chuyên cần");
                        }
                    }
    
                    // Xử lý nhật ký lập báo cáo qua tầng dữ liệu.
                    Repository.GhiNhatKyBaoCao(maNguoiDungLapBaoCao, dto.LoaiBaoCao, "MaLopHoc=" + dto.MaLopHoc);
                    return ServiceResult<string>.Ok(builder.ToString(), "Tạo báo cáo thành công.");
                });
            }
    
            // Tạo nội dung HTML cho báo cáo theo loại được chọn.
            private ServiceResult<string> TaoBaoCaoHtml(BaoCaoDTO dto)
            {
                // Ràng buộc dữ liệu: chọn lớp cho báo cáo này.
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
                    // Lấy dữ liệu báo cáo điểm qua tầng dữ liệu.
                    foreach (var row in Repository.GetBaoCaoDiem(dto.MaLopHoc))
                    {
                        builder.AppendLine("<tr><td>" + Html(row.TenLop) + "</td><td>" + Html(row.HoTen) + "</td><td>" + Html(row.TenDotKiemTra) + "</td><td>" + Html(FormatScore(row.DiemTong)) + "</td><td>" + Html(FormatScore(row.DiemTong)) + "</td><td>" + Html(row.NhanXet) + "</td></tr>");
                    }
                    builder.AppendLine("</table>");
                }
                else if (dto.LoaiBaoCao == "Bài tập")
                {
                    builder.AppendLine("<table><tr><th>Học viên</th><th>Bài tập</th><th>Hạn nộp</th><th>Trạng thái</th></tr>");
                    // Lấy dữ liệu báo cáo bài tập qua tầng dữ liệu.
                    foreach (var row in Repository.GetBaoCaoBaiTap(dto.MaLopHoc))
                    {
                        builder.AppendLine("<tr><td>" + Html(row.HoTen) + "</td><td>" + Html(row.TieuDe) + "</td><td>" + row.Deadline.ToString("dd/MM/yyyy") + "</td><td>" + Html(row.TrangThaiNop) + "</td></tr>");
                    }
                    builder.AppendLine("</table>");
                }
                else if (dto.LoaiBaoCao == "Chuyên cần")
                {
                    builder.AppendLine("<table><tr><th>Học viên</th><th>Có mặt</th><th>Vắng</th><th>Tỉ lệ</th></tr>");
                    // Lấy dữ liệu báo cáo chuyên cần qua tầng dữ liệu.
                    foreach (var row in Repository.GetBaoCaoChuyenCan(dto.MaLopHoc.Value))
                    {
                        builder.AppendLine("<tr><td>" + Html(row.HoTen) + "</td><td>" + row.SoBuoiCoMat + "</td><td>" + row.SoBuoiVang + "</td><td>" + row.TiLeChuyenCan.ToString("0.##") + "%</td></tr>");
                    }
                    builder.AppendLine("</table>");
                }
                else if (dto.LoaiBaoCao == "Cuối kỳ")
                {
                    builder.AppendLine("<table><tr><th>Học viên</th><th>Đợt kiểm tra</th><th>Điểm</th><th>Trung bình</th><th>Nhận xét giáo viên</th></tr>");
                    // Lấy dữ liệu báo cáo cuối kỳ qua tầng dữ liệu.
                    foreach (var row in Repository.GetBaoCaoCuoiKy(dto.MaLopHoc.Value))
                    {
                        builder.AppendLine("<tr><td>" + Html(row.HoTen) + "</td><td>" + Html(row.TenDotKiemTra) + "</td><td>" + Html(FormatScore(row.DiemTong)) + "</td><td>" + Html(FormatScore(row.DiemTrungBinh)) + "</td><td>" + Html(row.NhanXet) + "</td></tr>");
                    }
                    builder.AppendLine("</table>");
                }
    
                builder.AppendLine("</body></html>");
                return ServiceResult<string>.Ok(builder.ToString(), "OK");
            }
    
            // Định dạng điểm.
            private static string FormatScore(decimal? score)
            {
                return score.HasValue ? score.Value.ToString("0.0") : string.Empty;
            }
    
            // Mã hóa ký tự đặc biệt trước khi đưa dữ liệu vào HTML.
            private static string Html(string value)
            {
                if (value == null)
                {
                    return string.Empty;
                }
    
                return value.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;");
            }
    
            // Ghi nội dung báo cáo ra tệp người dùng đã chọn.
            public ServiceResult XuatBaoCao(string noiDung, string filePath)
            {
                return Try(() =>
                {
                    // Ràng buộc dữ liệu: Không có nội dung hoặc đường dẫn xuất báo cáo.
                    if (ValidationHelper.IsBlank(noiDung) || ValidationHelper.IsBlank(filePath))
                    {
                        return ServiceResult.Fail("Không có nội dung hoặc đường dẫn xuất báo cáo.");
                    }
    
                    File.WriteAllText(filePath, noiDung, Encoding.UTF8);
                    return ServiceResult.Ok("Xuất báo cáo thành công.");
                });
            }
            // Tạo hóa đơn học phí.
            public ServiceResult<HoaDonHocPhiDTO> TaoHoaDonHocPhi(int maThanhToan)
            {
                return Try(() =>
                {
                    // Ràng buộc dữ liệu: Vui lòng chọn phiếu học phí.
                    if (maThanhToan <= 0)
                    {
                        return ServiceResult<HoaDonHocPhiDTO>.Fail("Vui long chon phieu hoc phi.");
                    }

                    // Lấy hóa đơn học phí theo mã thanh toán qua tầng dữ liệu.
                    var invoice = Repository.LayHoaDonHocPhi(maThanhToan);
                    if (invoice == null)
                    {
                        return ServiceResult<HoaDonHocPhiDTO>.Fail("Khong tim thay phieu hoc phi.");
                    }

                    if (string.IsNullOrWhiteSpace(invoice.MaHoaDon))
                    {
                        invoice.MaHoaDon = "HD-" + invoice.MaThanhToan.ToString("000000");
                        // Cập nhật mã hóa đơn học phí qua tầng dữ liệu.
                        Repository.CapNhatThongTinHoaDon(invoice.MaThanhToan, invoice.MaHoaDon);
                    }

                    return ServiceResult<HoaDonHocPhiDTO>.Ok(invoice, "OK");
                });
            }

            // Dựng nội dung HTML cho hóa đơn học phí.
            public ServiceResult<string> TaoHoaDonHocPhiHtml(int maThanhToan)
            {
                return Try(() =>
                {
                    var result = TaoHoaDonHocPhi(maThanhToan);
                    if (!result.Success)
                    {
                        return ServiceResult<string>.Fail(result.Message);
                    }

                    var invoice = result.Data;
                    var finalAmount = invoice.SoTienCuoi.HasValue ? invoice.SoTienCuoi.Value : invoice.SoTien;
                    var originalAmount = invoice.SoTienGoc.HasValue ? invoice.SoTienGoc.Value : invoice.SoTien;
                    var builder = new StringBuilder();

                    builder.AppendLine("<!doctype html><html><head><meta charset=\"utf-8\"><title>Hoa don hoc phi</title>");
                    builder.AppendLine("<style>body{font-family:Segoe UI,Arial,sans-serif;margin:32px;color:#222}.header{border-bottom:2px solid #444;margin-bottom:20px}table{border-collapse:collapse;width:100%;max-width:760px}td{border:1px solid #ddd;padding:9px}.label{width:240px;background:#f3f5f7;font-weight:600}.money{text-align:right}.muted{color:#666}</style>");
                    builder.AppendLine("</head><body>");
                    builder.AppendLine("<div class=\"header\"><h1>Hoa don hoc phi</h1><p class=\"muted\">Ma hoa don: " + Html(invoice.MaHoaDon) + "</p></div>");
                    builder.AppendLine("<table>");
                    AddHtmlRow(builder, "Hoc vien", invoice.HoTen);
                    AddHtmlRow(builder, "Lop", invoice.TenLop);
                    AddHtmlRow(builder, "Ngay tao", invoice.NgayTao.ToString("dd/MM/yyyy HH:mm"));
                    AddHtmlRow(builder, "Han thanh toan", invoice.HanThanhToan.ToString("dd/MM/yyyy"));
                    AddHtmlRow(builder, "Ngay thanh toan", invoice.NgayThanhToan.HasValue ? invoice.NgayThanhToan.Value.ToString("dd/MM/yyyy HH:mm") : string.Empty);
                    AddHtmlRow(builder, "Hoc phi goc", FormatMoney(originalAmount), true);
                    AddHtmlRow(builder, "Giam gia", invoice.PhanTramGiam.ToString("0.##") + "% (" + FormatMoney(invoice.SoTienGiam) + ")", true);
                    AddHtmlRow(builder, "So tien cuoi", FormatMoney(finalAmount), true);
                    AddHtmlRow(builder, "Phuong thuc", invoice.PhuongThucThanhToan);
                    AddHtmlRow(builder, "Trang thai", invoice.TrangThai);
                    AddHtmlRow(builder, "Ghi chu thanh toan", invoice.ThongTinNganHang);
                    builder.AppendLine("</table></body></html>");

                    return ServiceResult<string>.Ok(builder.ToString(), "Da tao hoa don HTML.");
                });
            }

            // Xuất hóa đơn học phí dạng HTML vào thư mục đầu ra.
            public ServiceResult<string> XuatHoaDonHocPhiHtml(int maThanhToan, string outputFolder)
            {
                return Try(() =>
                {
                    // Ràng buộc dữ liệu: Vui lòng chọn thư mục xuất hóa đơn.
                    if (string.IsNullOrWhiteSpace(outputFolder))
                    {
                        return ServiceResult<string>.Fail("Vui long chon thu muc xuat hoa don.");
                    }

                    Directory.CreateDirectory(outputFolder);
                    var html = TaoHoaDonHocPhiHtml(maThanhToan);
                    if (!html.Success)
                    {
                        return ServiceResult<string>.Fail(html.Message);
                    }

                    var path = Path.Combine(outputFolder, "HoaDonHocPhi_" + maThanhToan.ToString("000000") + ".html");
                    File.WriteAllText(path, html.Data, Encoding.UTF8);
                    return ServiceResult<string>.Ok(path, "Da xuat hoa don HTML.");
                });
            }

            // Dựng nội dung HTML cho báo cáo doanh thu.
            public ServiceResult<string> TaoBaoCaoDoanhThuHtml(DateTime tuNgay, DateTime denNgay)
            {
                return Try(() =>
                {
                    if (tuNgay.Date > denNgay.Date)
                    {
                        return ServiceResult<string>.Fail("Khoang ngay bao cao khong hop le.");
                    }

                    // Lấy báo cáo doanh thu theo khoảng ngày qua tầng dữ liệu.
                    var rows = Repository.LayBaoCaoDoanhThu(tuNgay, denNgay);
                    var builder = new StringBuilder();
                    builder.AppendLine("<!doctype html><html><head><meta charset=\"utf-8\"><title>Bao cao doanh thu</title>");
                    builder.AppendLine("<style>body{font-family:Segoe UI,Arial,sans-serif;margin:32px;color:#222}table{border-collapse:collapse;width:100%}th,td{border:1px solid #ddd;padding:8px;text-align:left}th{background:#2A2A3E;color:#fff}.money{text-align:right}.muted{color:#666}</style>");
                    builder.AppendLine("</head><body>");
                    builder.AppendLine("<h1>Bao cao doanh thu hoc phi</h1>");
                    builder.AppendLine("<p class=\"muted\">Tu ngay " + tuNgay.ToString("dd/MM/yyyy") + " den ngay " + denNgay.ToString("dd/MM/yyyy") + "</p>");
                    builder.AppendLine("<table><tr><th>Ngay</th><th>Lop</th><th>So phieu</th><th>Da thanh toan</th><th>Tong tien da thu</th></tr>");
                    foreach (var row in rows)
                    {
                        builder.AppendLine("<tr><td>" + row.Ngay.ToString("dd/MM/yyyy") + "</td><td>" + Html(row.TenLop) + "</td><td>" + row.SoPhieu + "</td><td>" + row.SoPhieuDaThanhToan + "</td><td class=\"money\">" + FormatMoney(row.TongTienDaThanhToan) + "</td></tr>");
                    }

                    builder.AppendLine("</table></body></html>");
                    return ServiceResult<string>.Ok(builder.ToString(), "Da tao bao cao doanh thu HTML.");
                });
            }

            // Xuất báo cáo doanh thu dạng HTML vào thư mục đầu ra.
            public ServiceResult<string> XuatBaoCaoDoanhThu(DateTime tuNgay, DateTime denNgay, string outputFolder)
            {
                return Try(() =>
                {
                    // Ràng buộc dữ liệu: Vui lòng chọn thư mục xuất báo cáo.
                    if (string.IsNullOrWhiteSpace(outputFolder))
                    {
                        return ServiceResult<string>.Fail("Vui long chon thu muc xuat bao cao.");
                    }

                    Directory.CreateDirectory(outputFolder);
                    var html = TaoBaoCaoDoanhThuHtml(tuNgay, denNgay);
                    if (!html.Success)
                    {
                        return ServiceResult<string>.Fail(html.Message);
                    }

                    var path = Path.Combine(outputFolder, "BaoCaoDoanhThu_" + tuNgay.ToString("yyyyMMdd") + "_" + denNgay.ToString("yyyyMMdd") + ".html");
                    File.WriteAllText(path, html.Data, Encoding.UTF8);
                    return ServiceResult<string>.Ok(path, "Da xuat bao cao doanh thu.");
                });
            }

            // Thêm dòng HTML.
            private static void AddHtmlRow(StringBuilder builder, string label, string value)
            {
                AddHtmlRow(builder, label, value, false);
            }

            // Thêm dòng HTML.
            private static void AddHtmlRow(StringBuilder builder, string label, string value, bool money)
            {
                builder.AppendLine("<tr><td class=\"label\">" + Html(label) + "</td><td" + (money ? " class=\"money\"" : string.Empty) + ">" + Html(value) + "</td></tr>");
            }

            // Định dạng tiền tệ.
            private static string FormatMoney(decimal value)
            {
                return value.ToString("#,##0") + " VND";
            }
        }
}
