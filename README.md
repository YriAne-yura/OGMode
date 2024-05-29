# OGMode
Công cụ tối ưu hoá hệ điều hành windows, optimize windows for gaming , one click game mode on desktop - laptop.

Chỉ với 1 click sẽ giúp cho chiếc máy tính cấu hình yếu của bạn chơi game mượt hơn thông thường với các tweaks tối ưu có sẵn trên công cụ OGMode của tớ :3

Trang bài viết chính: https://osteup.com/ogmode/

Được build bởi Osteup . Sử dụng ngôn ngữ C# + Batch Tuỳ chỉnh máy tính / laptop .

![image](https://github.com/SiroCandy06/OGMode/assets/101639160/e50f465b-47b9-4b1a-9c4d-c6fdafaff1c5)

# Lợi ích Mang Lại
* Sử Dụng Nhanh Chóng Tiện Lợi
* Cải thiện hiệu suất mang lại trải nghiệm mượt mà hơn trên máy tính
* Tăng FPS đôi chút tốt hơn so với ban đầu
* Có chế độ game mode ( Chế độ trò chơi ) giúp tập trung hiệu suất chơi game tốt hơn
* Tương Lai sẽ cập nhập nhiều tính năng như: Giảm lag game cụ thể, các tính năng tối ưu hoá máy tính chuyên sâu,...

# Nhược điểm
* Giao diện , đồ hoạ trên máy tính có thể xấu đi ( đồng nghĩa với máy tính bớt gánh hiệu ứng chống máy hoạt động chậm )
* Chương trình beta Thử nghiệm C#

# Yêu cầu
Phù hợp với mọi thiết bị máy cấu hình yếu
* [.NET Desktop Runtime 8.0.1](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
* Tải và cài đặt: [OGMode](https://github.com/SiroCandy06/OGMode/releases)

# Cách Sử dụng
Đơn giản thoi. 

- Tải và cài đặt chương trình OGmode
- Mở chương trình lên với quyền admin và sử dụng các chức năng bạn thích

![image](https://github.com/SiroCandy06/OGMode/assets/101639160/445d2bcc-2220-4553-bc5f-73528130fd8f)

- Tick vào "Windows Explorer" là tắt Windows Explorer khi bạn sử dụng chế độ trò chơi, bỏ tick thì không tắt.
- Windows explorer cũng ăn khá nhiều dung lượng RAM trên các cấu hình trung.
  Lưu ý: Windows explorer khi tắt thì sẽ đen toàn màn hình, chỉ để trống lại một số ứng dụng đang mở thôi, hãy sử dụng alt + tab để di chuyển qua lại.
  Nếu lỡ tắt ogmode mà không biết bật windows explorer thì: Esc + shift + ctrl -> task manager -> new task -> explorer.exe và enter là xong.

![image](https://github.com/SiroCandy06/OGMode/assets/101639160/65f2b9e1-d9e6-4c7f-97d3-82d798699a4b)

![image](https://github.com/SiroCandy06/OGMode/assets/101639160/40c9ad34-4e0e-43f5-a320-cf500b1b0910)

# Các phiên bản gần đây
## V1.4 ( Đang chuẩn bị )
- Fix Lỗi Công Cụ Load Chậm [BUG]
- Thêm Check Update Vô Chương trình
- 
## V1.3 – 6/3/2024
- Fix lỗi văng game roblox
- Fix lỗi lag trình duyệt + youtube triệt để hơn v1.2
- Fix lỗi windows explorer not responding mặc dù không tắt windows explorer (win11)
- Thêm công cụ tối ưu dung lượng , dọn rác tăng tốc máy, giải phóng dung lượng.
- Tab cài đặt chuyển thành tab tweaks
- Thêm chế độ giảm ping chơi game vào gamemode -> sử dụng DNS google giảm ping cho các game việt (bật/tắt tuỳ ý)
- Cải thiện chức năng gamemode thêm một số tuỳ chỉnh.
- Clean sourcecode
- Tích hợp oced link vô app
## V1.2 – 19/1/2024
- Fix lỗi không hiển thị ảnh trong windows explorer
- Thêm chức năng dọn RAM vào mục công cụ và gamemode (auto)
- Thêm phần lựa chọn #Disable_Bluetooth vào gamemode cho người dùng lựa chọn tự do 😀
- Sửa lại giao diện giảm thiểu khả năng lỗi chương trình
- Cập nhập command của ogmode chạy ổn định hơn bản cũ // WDLF Osteup [ Version v0.03.8847 ]
- Bổ sung dialog thông báo người dùng nên chạy chương trình với quyền administrators
- Fix lỗi youtube bị lag , đơ , chậm ( nếu bị )
## v1.1 – 12/1/2024
- Cập nhập hiệu ứng fade-in và fade-out cho application
- Fix các lỗi nhỏ và tối ưu hiệu suất của chương trình.
- Fix Bug Navigation Home (Trang Form Giới Thiệu Lỗi .net framework )
- Cập nhập thêm code tắt services windows tối ưu hoá vào gamemode:
- Danh sách services để tắt mới được thêm vào:
- AVCTP service, Bluetooth Support Service, Bluetooth Audio Gateway Service, Bluetooth User Support Service_8c6ce, Connected User Experiences and Telemetry, Downloaded Maps Manager, Internet Connection Sharing (ICS), Program Compatibility Assistant Service, Parental Controls, Windows Error Reporting Service, Windows Camera Frame Server, Windows Insider Service, Server
## v1.0 – 3/1/2024
- Công cụ đầu tiên code C#
- Tối ưu hoá windows ( chức năng gamemode đầu tiên ra mắt )
- Tăng FPS Chơi Game
- Phiên bản v0.5 (Batch) cập nhập lên v1 (C#)

# Các Phiên bản trước bản v1 ( v0.1 -> v0.5 )
Đều được sử dụng bằng code batch để tối ưu game.

Bạn có thể đọc thêm chi tiết [tại đây](https://osteup.com/tool-ogmode-fix-lag-windows-toi-uu-hoa-may-tinh/)

# Hỗ trợ - Trợ giúp
Bạn có thể tham gia cộng đồng discord của chúng tôi hoặc liên hệ với tôi qua danh mục "Liên hệ"

![image](https://github.com/SiroCandy06/OGMode/assets/101639160/504aeffc-4e15-4d63-8c31-ceeec8c700fe)

