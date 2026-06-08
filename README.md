# Desktop_Project

Ứng dụng WinForms quản lý lớp IELTS theo tài liệu `context.pdf`.

## Chạy cơ sở dữ liệu

1. Mở SQL Server Management Studio.
2. Chạy script `DesktopApp_Project/DesktopApp_Project/DAL/Sql/Schema.sql`.
3. Kiểm tra chuỗi kết nối trong `App.config`:

```xml
Data Source=.;Initial Catalog=QuanLyLopIELTS;Integrated Security=True
```

Tài khoản mẫu sau khi chạy script:

- `admin` / `admin`
- `giaovien` / `123456`

## Kiến trúc

- `DTO`: đối tượng truyền dữ liệu.
- `DAL`: LINQ to SQL/DataContext/repository và schema SQL Server.
- `BUS`: kiểm tra nghiệp vụ, validation và xử lý theo workflow PDF.
- `GUI`: WinForms tiếng Việt, chỉ hiển thị và gọi BUS.

## Chức năng và logic từng form

### Mẫu chung trong GUI

- Hầu hết form nghiệp vụ kế thừa `ModuleFormBase`: tự áp dụng theme tối, giữ context `ServiceFactory`/người dùng hiện tại, và chỉ tải dữ liệu khi chạy runtime.
- `UiHelpers` cung cấp bộ điều khiển chuẩn (button, textbox, combobox, grid) và cấu hình grid ở chế độ chỉ đọc, chọn từng dòng.

### `FrmDangNhap`

- Mục tiêu: đăng nhập và tạo phiên làm việc với người dùng hiện tại.
- Giao diện gồm tài khoản, mật khẩu (ẩn ký tự), nút Đăng nhập và hint tài khoản mẫu.
- Luồng xử lý: gọi `Auth.DangNhap`; nếu thất bại thì hiện thông báo, nếu thành công thì ẩn form, mở `FrmChinh` dạng dialog và đóng form đăng nhập khi `FrmChinh` kết thúc.

### `FrmChinh`

- Mục tiêu: màn hình shell, điều hướng vào các module nghiệp vụ.
- Bố cục gồm header hiển thị tên người dùng/vai trò, menu bên trái và panel nội dung ở giữa.
- Các nút menu được khai báo trong designer và ánh xạ sang form tương ứng; `OpenModule` giải phóng form cũ, nhúng form mới (TopLevel = false, Dock = Fill). Mặc định mở màn hình Trang chủ.

### `FrmHocVien`

- Mục tiêu: quản lý hồ sơ học viên và tài khoản học viên.
- Có thanh tìm kiếm theo từ khóa; danh sách học viên hiển thị trong grid.
- Chọn dòng trong grid sẽ đổ dữ liệu vào form nhập. Lưu gọi `Services.HocVien.Luu`, xóa có xác nhận và gọi `Services.HocVien.Xoa` rồi tải lại danh sách.

### `FrmLopHoc`

- Mục tiêu: quản lý lớp học và danh sách học viên theo lớp.
- Khu vực trên để nhập tên lớp, nhóm trình độ, lịch học; grid lớp ở giữa; dưới là 2 grid học viên (trong lớp / ngoài lớp).
- Chọn lớp sẽ tải danh sách học viên. Nút “Thêm vào lớp” và “Xóa khỏi lớp” gọi `Services.LopHoc.ThemHocVien` / `Services.LopHoc.XoaHocVien` để phân lớp.

### `FrmTaiLieu`

- Mục tiêu: cập nhật tài liệu giảng dạy theo lớp và kỹ năng.
- Form gồm chọn lớp, kỹ năng, chủ đề, mô tả, đường dẫn file, video link; có nút chọn file.
- Khi đổi lớp thì tải lại danh sách. Lưu gọi `Services.TaiLieu.Luu`, xóa gọi `Services.TaiLieu.Xoa`, chọn dòng grid để đổ dữ liệu.

### `FrmBaiTap`

- Mục tiêu: giao bài và quản lý danh sách bài tập theo lớp.
- Nhập lớp, deadline, tiêu đề, mô tả, file đính kèm; grid hiển thị các bài đã tạo.
- Khi đổi lớp thì tải lại danh sách; chọn dòng grid để chỉnh sửa; lưu gọi `Services.BaiTap.GiaoBai`, xóa gọi `Services.BaiTap.Xoa`.

### `FrmChamBai`

- Mục tiêu: quản lý nộp bài và chấm bài.
- Combo chọn bài tập, grid danh sách bài nộp, phần preview nội dung/đường dẫn file; điểm và nhận xét ở thanh dưới.
- Chọn dòng sẽ hiển thị file bài làm (nếu tồn tại) và điểm/nhận xét hiện tại. Nút Chấm bài cập nhật `NopBaiDTO` và gọi `Services.ChamBai.Cham` rồi tải lại danh sách.

### `FrmDiemSo`

- Mục tiêu: tạo đợt kiểm tra và lưu điểm IELTS theo kỹ năng.
- Khu vực trên tạo đợt (lớp, tên đợt, ngày); giữa là danh sách học viên và điểm theo đợt; dưới là điểm L/R/W/S và nhận xét.
- Đổi lớp sẽ tải lại học viên và các đợt; lưu điểm gọi `Services.DiemSo.LuuDiem` theo học viên và đợt được chọn.

### `FrmDiemDanh`

- Mục tiêu: điểm danh theo lớp và ngày học.
- Chọn lớp và ngày để tải bảng điểm danh; chọn dòng để điền trạng thái và lý do vắng.
- Nút Lưu điểm danh cập nhật `DiemDanhDTO` và gọi `Services.DiemDanh.Luu`, sau đó tải lại bảng.

### `FrmDeThi`

- Mục tiêu: quản lý ngân hàng câu hỏi và tạo đề thi IELTS.
- Nhập kỹ năng, nội dung câu hỏi, đáp án; tên đề thi được dùng khi tạo đề mới.
- Lưu/xóa câu hỏi gọi `Services.DeThi.LuuCauHoi` / `Services.DeThi.XoaCauHoi`. Tạo đề gọi `Services.DeThi.TaoDeThi`, gắn câu hỏi vào đề gọi `Services.DeThi.ThemCauHoiVaoDeThi`.

### `FrmBaoCao`

- Mục tiêu: tạo báo cáo điểm số hoặc chuyên cần theo lớp.
- Chọn loại báo cáo và lớp, nhấn Tạo báo cáo để lấy nội dung từ `Services.BaoCao.TaoBaoCao`.
- Xuất file hỗ trợ CSV/TXT/RTF; với RTF thì bọc nội dung thành chuỗi RTF trước khi gọi `Services.BaoCao.XuatBaoCao`.

### `FrmThongBao`

- Mục tiêu: gửi thông báo đến học viên.
- Có thể gửi cho toàn bộ học viên hoặc theo lớp; nội dung thông báo được nhập dạng multiline.
- Nút Gửi gọi `Services.ThongBao.Gui`; nếu thành công thì xóa nội dung và tải lại lịch sử thông báo.

### `FrmTuVung`

- Mục tiêu: quản lý kho từ vựng theo lớp.
- Nhập từ tiếng Anh, từ loại, phiên âm, nghĩa; lọc theo lớp.
- Chọn dòng để chỉnh sửa; lưu gọi `Services.TuVung.Luu`, xóa gọi `Services.TuVung.Xoa` và tải lại danh sách.

### `FrmHocPhi`

- Mục tiêu: quản lý yêu cầu thanh toán học phí.
- Chọn học viên, nhập số tiền và thông tin ngân hàng; trạng thái thanh toán có các mức chờ/đã thanh toán/quá hạn.
- Tạo yêu cầu gọi `Services.HocPhi.TaoYeuCau`, cập nhật trạng thái gọi `Services.HocPhi.CapNhatTrangThai` và tải lại danh sách.
