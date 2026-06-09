using System;
// Thực thể dữ liệu ánh xạ bảng tiến trình flashcard trong cơ sở dữ liệu
// Chức năng:
// - Khai báo các cột LINQ sang SQL
// - Được kho dữ liệu dùng để đọc và ghi dữ liệu cơ sở dữ liệu

using System.Data.Linq.Mapping;

namespace DesktopApp_Project.DAL
{
    [Table(Name = "dbo.TienTrinh_Flashcard")]
    // Lớp thực thể dữ liệu ánh xạ dữ liệu tiến trình flashcard từ bảng cơ sở dữ liệu sang đối tượng C#.
    public class TienTrinhFlashcardEntity
        {
            [Column(IsPrimaryKey = true)] public int MaNguoiDung { get; set; }
            [Column(IsPrimaryKey = true)] public int MaTuVung { get; set; }
            [Column] public string KetQua { get; set; }
        }
}


