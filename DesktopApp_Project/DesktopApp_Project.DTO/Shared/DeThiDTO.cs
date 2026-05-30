using System;

namespace DesktopApp_Project.DTO
{
    public class DeThiDTO
        {
            public int MaDeThi { get; set; }
            public string TenDeThi { get; set; }
            public string KyNang { get; set; }
            public decimal? BandLevel { get; set; }
            public decimal? BandTu { get; set; }
            public decimal? BandDen { get; set; }
            public string MoTa { get; set; }
            public string FileDuLieu { get; set; }
            public string FilePath
            {
                get { return FileDuLieu; }
                set { FileDuLieu = value; }
            }
            public string AudioPath { get; set; }
            public string ImagePath { get; set; }
            public DateTime NgayTao { get; set; }
            public string TrangThai { get; set; }
        }
}
