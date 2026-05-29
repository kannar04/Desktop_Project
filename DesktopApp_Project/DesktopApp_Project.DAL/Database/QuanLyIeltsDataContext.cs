using System.Configuration;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace DesktopApp_Project.DAL
{
    public class QuanLyIeltsDataContext : DataContext
    {
        public QuanLyIeltsDataContext(string connectionString)
            : base(connectionString)
        {
        }

        public Table<NguoiDungEntity> NguoiDungs { get { return GetTable<NguoiDungEntity>(); } }
        public Table<LopHocEntity> LopHocs { get { return GetTable<LopHocEntity>(); } }
        public Table<ChiTietLopHocEntity> ChiTietLopHocs { get { return GetTable<ChiTietLopHocEntity>(); } }
        public Table<TaiLieuEntity> TaiLieus { get { return GetTable<TaiLieuEntity>(); } }
        public Table<BaiTapEntity> BaiTaps { get { return GetTable<BaiTapEntity>(); } }
        public Table<ChiTietNopBaiEntity> ChiTietNopBais { get { return GetTable<ChiTietNopBaiEntity>(); } }
        public Table<BuoiHocEntity> BuoiHocs { get { return GetTable<BuoiHocEntity>(); } }
        public Table<ChiTietDiemDanhEntity> ChiTietDiemDanhs { get { return GetTable<ChiTietDiemDanhEntity>(); } }
        public Table<DeThiEntity> DeThis { get { return GetTable<DeThiEntity>(); } }
        public Table<CauHoiEntity> CauHois { get { return GetTable<CauHoiEntity>(); } }
        public Table<ChiTietDeThiEntity> ChiTietDeThis { get { return GetTable<ChiTietDeThiEntity>(); } }
        public Table<DotKiemTraEntity> DotKiemTras { get { return GetTable<DotKiemTraEntity>(); } }
        public Table<ChiTietDiemSoEntity> ChiTietDiemSos { get { return GetTable<ChiTietDiemSoEntity>(); } }
        public Table<TuVungEntity> TuVungs { get { return GetTable<TuVungEntity>(); } }
        public Table<TienTrinhFlashcardEntity> TienTrinhFlashcards { get { return GetTable<TienTrinhFlashcardEntity>(); } }
        public Table<ThongBaoEntity> ThongBaos { get { return GetTable<ThongBaoEntity>(); } }
        public Table<ChiTietThongBaoEntity> ChiTietThongBaos { get { return GetTable<ChiTietThongBaoEntity>(); } }
        public Table<ThanhToanHocPhiEntity> ThanhToanHocPhis { get { return GetTable<ThanhToanHocPhiEntity>(); } }
        public Table<NhatKyBaoCaoEntity> NhatKyBaoCaos { get { return GetTable<NhatKyBaoCaoEntity>(); } }
    }

    public interface IDataContextFactory
    {
        QuanLyIeltsDataContext Create();
    }

    public class AppConfigDataContextFactory : IDataContextFactory
    {
        public QuanLyIeltsDataContext Create()
        {
            var connection = ConfigurationManager.ConnectionStrings["QuanLyIeltsDb"];
            var connectionString = connection == null ? string.Empty : connection.ConnectionString;
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                connectionString = ReadConnectionStringFromAssemblyConfig();
            }

            return new QuanLyIeltsDataContext(connectionString);
        }

        private static string ReadConnectionStringFromAssemblyConfig()
        {
            var configPaths = new[]
            {
                Path.Combine(Directory.GetCurrentDirectory(), "DesktopApp_Project.exe.config"),
                Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "DesktopApp_Project.exe.config"),
                Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "DesktopApp_Project.exe.config"),
                Assembly.GetExecutingAssembly().Location + ".config"
            };

            foreach (var configPath in configPaths.Where(File.Exists))
            {
                var document = XDocument.Load(configPath);
                var connection = document
                    .Descendants("connectionStrings")
                    .Elements("add")
                    .FirstOrDefault(x => (string)x.Attribute("name") == "QuanLyIeltsDb");

                var connectionString = connection == null ? string.Empty : (string)connection.Attribute("connectionString");
                if (!string.IsNullOrWhiteSpace(connectionString))
                {
                    return connectionString;
                }
            }

            return string.Empty;
        }
    }
}
