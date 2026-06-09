# DesktopApp_Project - Quản lý lớp IELTS

Ứng dụng Windows Forms hỗ trợ quản lý lớp học IELTS, bao gồm học viên, lớp học, tài liệu, bài tập, chấm bài, điểm danh, đề thi, điểm số, từ vựng/flashcard, thông báo, học phí/thanh toán và báo cáo.

## Tính năng chính

- Đăng nhập và phân quyền người dùng.
- Quản lý học viên, lớp học và lịch/buổi học.
- Quản lý tài liệu học tập, bài tập, bài nộp và chấm bài.
- Quản lý đề thi, đợt kiểm tra, điểm số và điểm danh.
- Quản lý từ vựng, chủ đề từ vựng và flashcard.
- Quản lý thông báo, học phí, thanh toán và hóa đơn.
- Xem dashboard và báo cáo doanh thu, chuyên cần, bài tập, điểm số.

## Công nghệ sử dụng

- C# WinForms trên .NET Framework 4.7.2.
- SQL Server hoặc SQL Server Express.
- LINQ to SQL/DataContext và Repository cho tầng dữ liệu.
- FontAwesome.Sharp cho icon giao diện.
- MailKit/MimeKit cho gửi email.
- VNPAY sandbox cho luồng thanh toán thử nghiệm.

## Cấu trúc solution

- `DesktopApp_Project.GUI`: giao diện WinForms, form đăng nhập và các màn hình nghiệp vụ.
- `DesktopApp_Project.BUS`: xử lý nghiệp vụ, validation và điều phối workflow.
- `DesktopApp_Project.DAL`: DataContext, entity, repository và script SQL Server.
- `DesktopApp_Project.DTO`: các đối tượng truyền dữ liệu giữa các tầng.
- `DesktopApp_Project.Common`: hằng số, helper và kiểu kết quả dùng chung.

## Yêu cầu môi trường

- Visual Studio 2022.
- .NET Framework 4.7.2 Developer Pack.
- SQL Server hoặc SQL Server Express.
- SQL Server Management Studio nếu muốn chạy script thủ công.

## Cài đặt và chạy ứng dụng

1. Clone hoặc tải mã nguồn về máy.
2. Mở solution:

```text
DesktopApp_Project/DesktopApp_Project.sln
```

3. Restore NuGet packages nếu Visual Studio chưa tự khôi phục.
4. Chạy script tạo cơ sở dữ liệu bằng SQL Server Management Studio:

```text
DesktopApp_Project/DesktopApp_Project.DAL/Sql/Schema.sql
```

5. Kiểm tra chuỗi kết nối trong:

```text
DesktopApp_Project/DesktopApp_Project.GUI/App.config
```

Ví dụ cấu hình mặc định:

```xml
<add name="QuanLyIeltsDb"
     connectionString="Data Source=localhost\SQLEXPRESS;Initial Catalog=QuanLyLopIELTS;Integrated Security=True;"
     providerName="System.Data.SqlClient" />
```

Nếu SQL Server của bạn dùng instance khác, hãy đổi `Data Source` cho phù hợp, ví dụ `.` hoặc `.\SQLEXPRESS`.

6. Đặt `DesktopApp_Project.GUI` làm startup project.
7. Build và chạy ứng dụng bằng Visual Studio.

## Tài khoản mẫu

Sau khi chạy `Schema.sql`, có thể đăng nhập bằng các tài khoản mẫu:

| Vai trò | Tài khoản | Mật khẩu |
| --- | --- | --- |
| Admin | `admin` | `admin` |
| Giáo viên | `giaovien` | `123456` |

## Reset cơ sở dữ liệu

Trong quá trình phát triển, có thể reset database bằng script:

```text
DesktopApp_Project/DesktopApp_Project.DAL/Sql/ResetDatabase.sql
```

Lưu ý: script reset có thể xóa dữ liệu hiện có. Chỉ dùng trên môi trường phát triển hoặc dữ liệu thử nghiệm.

## Cấu hình thanh toán và email

Các khóa cấu hình nằm trong `DesktopApp_Project/DesktopApp_Project.GUI/App.config`.

VNPAY sandbox:

```xml
<add key="vnpay:PayUrl" value="https://sandbox.vnpayment.vn/paymentv2/vpcpay.html" />
<add key="vnpay:TmnCode" value="YOUR_VNPAY_SANDBOX_TMN_CODE" />
<add key="vnpay:HashSecret" value="YOUR_VNPAY_SANDBOX_HASH_SECRET" />
<add key="vnpay:ReturnUrl" value="http://localhost/vnpay-return" />
```

SMTP email:

```xml
<add key="smtp:Host" value="smtp.gmail.com" />
<add key="smtp:Port" value="587" />
<add key="smtp:SenderAccount" value="your-email@gmail.com" />
<add key="smtp:AppPassword" value="YOUR_GMAIL_APP_PASSWORD" />
<add key="smtp:SenderAddress" value="your-email@gmail.com" />
```

Không commit mật khẩu email, VNPAY secret hoặc thông tin production thật lên repository. Với Gmail, hãy dùng App Password thay vì mật khẩu tài khoản chính.
