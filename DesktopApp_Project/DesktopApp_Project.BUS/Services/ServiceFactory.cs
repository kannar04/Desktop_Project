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
    public class ServiceFactory
        {
            private readonly IQuanLyIeltsRepository _repository;
    
            public ServiceFactory()
                : this(new QuanLyIeltsRepository(new AppConfigDataContextFactory()))
            {
            }
    
            public ServiceFactory(IQuanLyIeltsRepository repository)
            {
                _repository = repository;
                Auth = new AuthService(_repository);
                HocVien = new HocVienService(_repository);
                LopHoc = new LopHocService(_repository);
                TaiLieu = new TaiLieuService(_repository);
                BaiTap = new BaiTapService(_repository);
                ChamBai = new ChamBaiService(_repository);
                DiemDanh = new DiemDanhService(_repository);
                DiemSo = new DiemSoService(_repository);
                DeThi = new DeThiService(_repository);
                BaoCao = new BaoCaoService(_repository);
                TuVung = new TuVungService(_repository);
                ThongBao = new ThongBaoService(_repository);
                HocPhi = new HocPhiService(_repository);
                Dashboard = new DashboardService(_repository);
                ExternalStorage = new FakeExternalStorageService();
                Media = new MediaService(_repository, ExternalStorage);
                Payment = new PaymentService(_repository);
            }
    
            public AuthService Auth { get; private set; }
            public HocVienService HocVien { get; private set; }
            public LopHocService LopHoc { get; private set; }
            public TaiLieuService TaiLieu { get; private set; }
            public BaiTapService BaiTap { get; private set; }
            public ChamBaiService ChamBai { get; private set; }
            public DiemDanhService DiemDanh { get; private set; }
            public DiemSoService DiemSo { get; private set; }
            public DeThiService DeThi { get; private set; }
            public BaoCaoService BaoCao { get; private set; }
            public TuVungService TuVung { get; private set; }
            public ThongBaoService ThongBao { get; private set; }
            public HocPhiService HocPhi { get; private set; }
            public DashboardService Dashboard { get; private set; }
            public PaymentService Payment { get; private set; }
            public MediaService Media { get; private set; }
            public IExternalStorageService ExternalStorage { get; private set; }
        }
}