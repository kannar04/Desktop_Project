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
    public class ThongBaoService : ServiceBase
        {
            public ThongBaoService(IQuanLyIeltsRepository repository) : base(repository) { }
    
            public List<ThongBaoDTO> LayDanhSach()
            {
                return Repository.GetThongBao();
            }
    
            public ServiceResult Gui(ThongBaoDTO dto, int? maLopHoc)
            {
                return Try(() =>
                {
                    if (ValidationHelper.IsBlank(dto.TieuDe) || ValidationHelper.IsBlank(dto.NoiDung))
                    {
                        return ServiceResult.Fail("Tiêu đề và nội dung thông báo không được để trống.");
                    }
    
                    List<int> nguoiNhan;
                    if (maLopHoc.HasValue)
                    {
                        nguoiNhan = Repository.GetHocVienTrongLop(maLopHoc.Value).Select(x => x.MaNguoiDung).ToList();
                        dto.DoiTuongNhan = "Lớp " + maLopHoc.Value;
                    }
                    else
                    {
                        nguoiNhan = Repository.GetNguoiDungByVaiTro(AppConstants.RoleStudent).Select(x => x.MaNguoiDung).ToList();
                        dto.DoiTuongNhan = "Tất cả học viên";
                    }
    
                    if (nguoiNhan.Count == 0)
                    {
                        return ServiceResult.Fail("Không có học viên nhận thông báo.");
                    }
    
                    var maThongBao = Repository.InsertThongBao(dto);
                    Repository.TaoNguoiNhanThongBao(maThongBao, nguoiNhan);
                    return ServiceResult.Ok("Gửi thông báo thành công.");
                });
            }
        }
}

