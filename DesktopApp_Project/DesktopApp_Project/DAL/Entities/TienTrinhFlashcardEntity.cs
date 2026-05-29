using System;
using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.TienTrinh_Flashcard")]
    public class TienTrinhFlashcardEntity
        {
            [Column(IsPrimaryKey = true)] public int MaNguoiDung { get; set; }
            [Column(IsPrimaryKey = true)] public int MaTuVung { get; set; }
            [Column] public string KetQua { get; set; }
        }
}


