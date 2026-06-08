# Desktop_Project

Ứng dụng WinForms quản lý lớp IELTS theo tài liệu `context.pdf`.

## Chạy cơ sở dữ liệu

1. Mở SQL Server Management Studio.
2. Chạy script `DesktopApp_Project/DesktopApp_Project/DAL/Sql/Schema.sql`.
3. Kiểm tra chuỗi kết nối trong `App.config`:

```xml
Data Source=.;Initial Catalog=QuanLyLopIELTS;Integrated Security=True
```
*Lưu ý cho dev: Chạy script `DesktopApp_Project/DesktopApp_Project/DAL/Sql/ResetDatabase.sql`, để reset database

Tài khoản mẫu sau khi chạy script:

- `admin` / `admin`
- `giaovien` / `123456`

## Kiến trúc

- `DTO`: đối tượng truyền dữ liệu.
- `DAL`: LINQ to SQL/DataContext/repository và schema SQL Server.
- `BUS`: kiểm tra nghiệp vụ, validation và xử lý theo workflow PDF.
- `GUI`: WinForms tiếng Việt, chỉ hiển thị và gọi BUS.
