using System;
using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.DeThi")]
    public class DeThiEntity
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
            public int MaDeThi { get; set; }
    
            [Column] public string TenDeThi { get; set; }
            [Column] public string FileDuLieu { get; set; }
            [Column] public DateTime NgayTao { get; set; }
        }
}


