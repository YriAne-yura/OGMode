using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Win32;

namespace ogmm
{
    public partial class Formhome : Form
    {
        // Danh sách tên dịch vụ cần tắt khi bật Game Mode
        List<string> backendServicesToStop = new List<string> { "EventLog", "lmhosts", "BITS",
        "Dnscache","BcastDVRUserService_78710","Spooler","seclogon","SCardSvr","ScDeviceEnum","SysMain","TapiSrv",
        "Themes","WSearch","mpssvc","XblAuthManager","BthAvctpSvc","bthserv","BTAGService",
        "BluetoothUserService_8c6ce","DiagTrack","MapsBroker","SharedAccess",
        "Netlogon","PcaSvc","WpcMonSvc","WerSvc","FrameServer",
        "wisvc","LanmanServer"
        };
        List<string> displayServicesToStop = new List<string> { "EventLogServices", "TCP/IP NetBIOS Helper", "Background Intelligent Transfer Service",
        "DNS Client","BcastDVRUserService","Print Spooler","Secondary Logon","Smart Card","Smart Card Device Enumeration Service","SysMain","Telephony",
        "Themes","Windows Search","Windows Defender Firewall","Xbox Live Auth Manager","AVCTP service","Bluetooth Support Service","Bluetooth Audio Gateway Service",
        "Bluetooth User Support Service_8c6ce","Connected User Experiences and Telemetry","Downloaded Maps Manager","Internet Connection Sharing (ICS)",
        "Netlogon","Program Compatibility Assistant Service","Parental Controls","Windows Error Reporting Service","Windows Camera Frame Server",
        "Windows Insider Service","Server"
        };


        public Formhome()
        {
            InitializeComponent();
        }

        private void Formhome_Load(object sender, EventArgs e)
        {
            // Gọi hàm để làm cho btngamemode trở thành hình tròn
            MakeCircularButton(btngamemode);

            // Khôi phục trạng thái và màu của btngamemode từ Properties.Settings
            bool isGameModeEnabled = Properties.Settings.Default.IsGameModeEnabled;
            Color buttonColor = Properties.Settings.Default.ButtonColor;


            // Áp dụng trạng thái và màu
            ApplyButtonState(isGameModeEnabled, buttonColor);

            // Gọi hàm để lấy tên người dùng và hiển thị trên Userwindow
            string username = GetUsername();
            Userwindows.Text = "Username: " + username;
            outputgamemode.ScrollBars = ScrollBars.Vertical; // Hiển thị thanh cuộn dọc
            outputgamemode.Multiline = true;

        }
        
        private bool SetValueInRegistry(string registryPath, string valueName, object value, RegistryValueKind valueKind)
        {
            try
            {
                // Lưu giá trị vào Registry
                Registry.SetValue(registryPath, valueName, value, valueKind);
                return true; // Trả về true nếu thành công
            }
            catch
            {
                return false; // Trả về false nếu thất bại
            }
        }
        private void ApplyButtonState(bool isGameModeEnabled, Color buttonColor)
        {
            btngamemode.BackColor = buttonColor;

            if (isGameModeEnabled)
            {
                btngamemode.Text = "Đang Bật";
            }
            else
            {
                btngamemode.Text = "Đã Tắt";
            }
        }

        private void MakeCircularButton(Button button)
        {
            // Làm cho nút trở thành hình'
            // tròn
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Size = new Size(128, 128); // Đặt kích thước theo mong muốn

            // Thiết lập độ cong để tạo hình tròn
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, button.Width, button.Height);
            button.Region = new Region(path);
        }

        private string GetUsername()
        {
            // Lấy thông tin về người dùng hiện tại
            WindowsIdentity currentIdentity = WindowsIdentity.GetCurrent();

            // Lấy tên người dùng từ thông tin đó và loại bỏ đường dẫn trước tên
            string usernameWithDomain = currentIdentity.Name;
            string[] usernameParts = usernameWithDomain.Split('\\');
            string username = (usernameParts.Length > 1) ? usernameParts[1] : usernameWithDomain;

            // Trả về tên người dùng
            return username;
        }

        private void UpdateOutputGamemode(string text)
        {
            // Code để cập nhật labeltext trong giao diện người dùng
            outputgamemode.Text += text + Environment.NewLine; // Thêm text và xuống dòng
        }

        private void ClearOutputGamemode()
        {
            // Code để xóa nội dung của labeltext trong giao diện người dùng
            outputgamemode.Text = string.Empty;
        }

        private void Userwindow_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện khi Userwindow được nhấp
            // Bạn có thể thêm mã xử lý khác tại đây nếu cần
        }

        private async void btngamemode_Click(object sender, EventArgs e)
{
    bool isGameModeEnabled;
    Color buttonColor;
    Color textColor;

    // Clear text sau khi thêm thông báo
    ClearOutputGamemode();

            if (btngamemode.Text == "Bắt Đầu")
            {
                // Bật Game Mode và tắt các dịch vụ
                isGameModeEnabled = true;
                buttonColor = Color.FromArgb(127, 255, 200);
                textColor = Color.FromArgb(1, 140, 255);
                await Task.Run(() => StopServices(backendServicesToStop, displayServicesToStop));
                // Lưu các giá trị hiệu ứng vào Registry
                SavePerformanceOptionsRegistry();

                // Kết thúc nhiệm vụ Windows Explorer nếu có đánh dấu
                if (endExplorerTask)
                {
                    EndExplorerTask();
                }
                outputgamemode.Text += Environment.NewLine;

                UpdateOutputGamemode("GAME MODE ĐÃ ĐƯỢC BẬT");
            }
            else if (btngamemode.Text == "Đang Bật")
            {
                // Tắt Game Mode và khôi phục các dịch vụ
                isGameModeEnabled = false;
                buttonColor = Color.FromArgb(255, 127, 127);
                textColor = Color.FromArgb(254, 50, 49);
                await Task.Run(() => StartServices(backendServicesToStop, displayServicesToStop));
                // Khôi phục các giá trị hiệu ứng từ Registry
                RestorePerformanceOptionsRegistry();

                // Bật lại nhiệm vụ Windows Explorer nếu có đánh dấu
                if (endExplorerTask)
                {
                    StartExplorerTask();
                }
                outputgamemode.Text += Environment.NewLine;

                UpdateOutputGamemode("GAME MODE ĐÃ ĐƯỢC TẮT");
            }
            else // "Đang Tắt"
            {
                // Bật Game Mode và tắt các dịch vụ
                isGameModeEnabled = true;
                buttonColor = Color.FromArgb(127, 255, 200);
                textColor = Color.FromArgb(1, 140, 255);
                await Task.Run(() => StopServices(backendServicesToStop, displayServicesToStop));

                // Lưu các giá trị hiệu ứng vào Registry
                SavePerformanceOptionsRegistry();

                // Kết thúc nhiệm vụ Windows Explorer nếu có đánh dấu
                if (endExplorerTask)
                {
                    EndExplorerTask();
                }
                outputgamemode.Text += Environment.NewLine;
                UpdateOutputGamemode("GAME MODE ĐÃ ĐƯỢC BẬT");
            }

            // Lưu trạng thái và màu vào Properties.Settings
            Properties.Settings.Default.IsGameModeEnabled = isGameModeEnabled;
            Properties.Settings.Default.ButtonColor = buttonColor;
            Properties.Settings.Default.Save();

            // Áp dụng trạng thái và màu
            ApplyButtonState(isGameModeEnabled, buttonColor);
    }
        private void EndExplorerTask()
        {
            try
            {
                // Tìm quy trình Windows Explorer và kết thúc nó
                Process[] explorerProcesses = Process.GetProcessesByName("explorer");
                foreach (Process explorerProcess in explorerProcesses)
                {
                    Process.Start(@"C:\Windows\System32\taskkill.exe", @"/F /IM explorer.exe");
                    UpdateOutputGamemode("End Task Thành Công Windows Explorer exe"); 
                }
            }
            catch (Exception ex)
            {
                UpdateOutputGamemode($"Lỗi khi kết thúc quy trình Windows Explorer: {ex.Message}");
            }
        }

        private void StartExplorerTask()
        {
            try
            {
                // Khởi động lại Windows Explorer
                Process.Start("explorer.exe");
                UpdateOutputGamemode("End Task Thành Công Windows Explorer exe");

            }
            catch (Exception ex)
            {
                UpdateOutputGamemode($"Lỗi khi khởi động lại Windows Explorer: {ex.Message}");
            }
        }
        private void SavePerformanceOptionsRegistry()
        {
            try
            {
                // Đường dẫn trong Registry
                string registryPath = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";

                // Tạo chuỗi StringBuilder để xây dựng thông báo
                StringBuilder messageBuilder = new StringBuilder();

                // Lưu các giá trị hiệu ứng
                if (SetValueInRegistry(registryPath, "AnimateControls", 0, RegistryValueKind.DWord))
                    messageBuilder.AppendLine("AnimateControls: Tắt Thành công.");
                else
                    messageBuilder.AppendLine("AnimateControls: Tắt Thất bại.");

                if (SetValueInRegistry(registryPath, "AnimateWindows", 0, RegistryValueKind.DWord))
                    messageBuilder.AppendLine("AnimateWindows: Tắt Thành công.");
                else
                    messageBuilder.AppendLine("AnimateWindows: Tắt Thất bại.");

                if (SetValueInRegistry(registryPath, "TaskbarAnimations", 0, RegistryValueKind.DWord))
                    messageBuilder.AppendLine("TaskbarAnimations: Tắt Thành công.");
                else
                    messageBuilder.AppendLine("TaskbarAnimations: Tắt Thất bại.");

                if (SetValueInRegistry(registryPath, "EnableAeroPeek", 0, RegistryValueKind.DWord))
                    messageBuilder.AppendLine("EnableAeroPeek: Tắt Thành công.");
                else
                    messageBuilder.AppendLine("EnableAeroPeek: Tắt Thất bại.");

                if (SetValueInRegistry(registryPath, "ListviewAlphaSelect", 0, RegistryValueKind.DWord))
                    messageBuilder.AppendLine("ListviewAlphaSelect: Tắt Thành công.");
                else
                    messageBuilder.AppendLine("ListviewAlphaSelect: Tắt Thất bại.");

                if (SetValueInRegistry(registryPath, "ListviewShadow", 0, RegistryValueKind.DWord))
                    messageBuilder.AppendLine("ListviewShadow: Tắt Thành công.");
                else
                    messageBuilder.AppendLine("ListviewShadow: Tắt Thất bại.");

                if (SetValueInRegistry(registryPath, "IconsOnly", 0, RegistryValueKind.DWord))
                    messageBuilder.AppendLine("IconsOnly: Tắt Thành công.");
                else
                    messageBuilder.AppendLine("IconsOnly: Tắt Thất bại.");

                if (SetValueInRegistry(registryPath, "ListviewShadow", 0, RegistryValueKind.DWord))
                    messageBuilder.AppendLine("ListviewShadow: Tắt Thành công.");
                else
                    messageBuilder.AppendLine("ListviewShadow: Tắt Thất bại.");

                if (SetValueInRegistry(registryPath, "ThumbnailLivePreviewHoverTime", 0, RegistryValueKind.DWord))
                    messageBuilder.AppendLine("ThumbnailLivePreviewHoverTime: Tắt Thành công.");
                else
                    messageBuilder.AppendLine("ThumbnailLivePreviewHoverTime: Tắt Thất bại.");

                if (SetValueInRegistry(registryPath, "ThumbnailLivePreviewHover", 0, RegistryValueKind.DWord))
                    messageBuilder.AppendLine("ThumbnailLivePreviewHover: Tắt Thành công.");
                else
                    messageBuilder.AppendLine("ThumbnailLivePreviewHover: Tắt Thất bại.");

                if (SetValueInRegistry(registryPath, "ListViewAlphaSelect", 0, RegistryValueKind.DWord))
                    messageBuilder.AppendLine("ListViewAlphaSelect: Tắt Thành công.");
                else
                    messageBuilder.AppendLine("ListViewAlphaSelect: Tắt Thất bại.");

                // Thêm các giá trị khác nếu cần thiết

                // Cập nhật thông tin trên outputgamemode
                UpdateOutputGamemode(messageBuilder.ToString());
            }
            catch (Exception ex)
            {
                UpdateOutputGamemode($"Lỗi khi lưu các giá trị hiệu ứng: {ex.Message}");
            }
        }

        private void RestorePerformanceOptionsRegistry()
        {
            try
            {
                // Đường dẫn trong Registry
                string registryPath = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";

                // Tạo chuỗi StringBuilder để xây dựng thông báo
                StringBuilder messageBuilder = new StringBuilder();

                // Khôi phục các giá trị hiệu ứng
                if (SetValueInRegistry(registryPath, "AnimateControls", 1, RegistryValueKind.DWord))
                    messageBuilder.AppendLine("AnimateControls: Khôi phục Thành công.");
                else
                    messageBuilder.AppendLine("AnimateControls: Khôi phục Thất bại.");

                if (SetValueInRegistry(registryPath, "AnimateWindows", 1, RegistryValueKind.DWord))
                    messageBuilder.AppendLine("AnimateWindows: Khôi phục Thành công.");
                else
                    messageBuilder.AppendLine("AnimateWindows: Khôi phục Thất bại.");

                if (SetValueInRegistry(registryPath, "TaskbarAnimations", 1, RegistryValueKind.DWord))
                    messageBuilder.AppendLine("TaskbarAnimations: Khôi phục Thành công.");
                else
                    messageBuilder.AppendLine("TaskbarAnimations: Khôi phục Thất bại.");

                if (SetValueInRegistry(registryPath, "EnableAeroPeek", 1, RegistryValueKind.DWord))
                    messageBuilder.AppendLine("EnableAeroPeek: Khôi phục Thành công.");
                else
                    messageBuilder.AppendLine("EnableAeroPeek: Khôi phục Thất bại.");

                if (SetValueInRegistry(registryPath, "ListviewAlphaSelect", 1, RegistryValueKind.DWord))
                    messageBuilder.AppendLine("ListviewAlphaSelect: Khôi phục Thành công.");
                else
                    messageBuilder.AppendLine("ListviewAlphaSelect: Khôi phục Thất bại.");

                if (SetValueInRegistry(registryPath, "ListviewShadow", 1, RegistryValueKind.DWord))
                    messageBuilder.AppendLine("ListviewShadow: Khôi phục Thành công.");
                else
                    messageBuilder.AppendLine("ListviewShadow: Khôi phục Thất bại.");

                if (SetValueInRegistry(registryPath, "IconsOnly", 1, RegistryValueKind.DWord))
                    messageBuilder.AppendLine("IconsOnly: Khôi phục Thành công.");
                else
                    messageBuilder.AppendLine("IconsOnly: Khôi phục Thất bại.");

                if (SetValueInRegistry(registryPath, "ListviewShadow", 1, RegistryValueKind.DWord))
                    messageBuilder.AppendLine("ListviewShadow: Khôi phục Thành công.");
                else
                    messageBuilder.AppendLine("ListviewShadow: Khôi phục Thất bại.");

                if (SetValueInRegistry(registryPath, "ThumbnailLivePreviewHoverTime", 1, RegistryValueKind.DWord))
                    messageBuilder.AppendLine("ThumbnailLivePreviewHoverTime: Khôi phục Thành công.");
                else
                    messageBuilder.AppendLine("ThumbnailLivePreviewHoverTime: Khôi phục Thất bại.");

                if (SetValueInRegistry(registryPath, "ThumbnailLivePreviewHover", 1, RegistryValueKind.DWord))
                    messageBuilder.AppendLine("ThumbnailLivePreviewHover: Khôi phục Thành công.");
                else
                    messageBuilder.AppendLine("ThumbnailLivePreviewHover: Khôi phục Thất bại.");

                if (SetValueInRegistry(registryPath, "ListViewAlphaSelect", 1, RegistryValueKind.DWord))
                    messageBuilder.AppendLine("ListViewAlphaSelect: Khôi phục Thành công.");
                else
                    messageBuilder.AppendLine("ListViewAlphaSelect: Khôi phục Thất bại.");

                // Thêm các giá trị khác nếu cần thiết

                // Cập nhật thông tin trên outputgamemode
                UpdateOutputGamemode(messageBuilder.ToString());
            }
            catch (Exception ex)
            {
                UpdateOutputGamemode($"Lỗi khi khôi phục các giá trị hiệu ứng: {ex.Message}");
            }
        }






        private void StopServices(List<string> backendServiceNames, List<string> displayServiceNames)
        {
            // Dừng các dịch vụ
            for (int i = 0; i < backendServiceNames.Count; i++)
            {
                string backendServiceName = backendServiceNames[i];
                string displayServiceName = displayServiceNames[i];

                try
                {
                    ServiceController[] services = ServiceController.GetServices();

                    // Kiểm tra xem dịch vụ có tồn tại không
                    ServiceController serviceController = services.FirstOrDefault(s => s.ServiceName == backendServiceName);

                    if (serviceController != null)
                    {
                        if (serviceController.Status == ServiceControllerStatus.Running)
                        {
                            serviceController.Stop();
                            serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
                            UpdateOutputGamemode($"Dịch vụ '{displayServiceName}' đã được tắt thành công.");
                        }
                        else
                        {
                            UpdateOutputGamemode($"Dịch vụ '{displayServiceName}' đã được tắt trước đó.");
                        }
                    }
                    else
                    {
                        UpdateOutputGamemode($"Dịch vụ '{displayServiceName}' không tồn tại.");
                    }
                }
                catch (Exception ex)
                {
                    UpdateOutputGamemode($"Lỗi khi tắt dịch vụ '{displayServiceName}': {ex.Message}");
                }
            }
        }


        private void StartServices(List<string> backendServiceNames, List<string> displayServiceNames)
        {
            // Khởi động lại các dịch vụ
            for (int i = 0; i < backendServiceNames.Count; i++)
            {
                string backendServiceName = backendServiceNames[i];
                string displayServiceName = displayServiceNames[i];

                try
                {
                    ServiceController[] services = ServiceController.GetServices();

                    // Kiểm tra xem dịch vụ có tồn tại không
                    ServiceController serviceController = services.FirstOrDefault(s => s.ServiceName == backendServiceName);

                    if (serviceController != null)
                    {
                        if (serviceController.Status == ServiceControllerStatus.Stopped)
                        {
                            serviceController.Start();
                            serviceController.WaitForStatus(ServiceControllerStatus.Running);
                            UpdateOutputGamemode($"Dịch vụ '{displayServiceName}' đã được khởi động thành công.");
                        }
                        else
                        {
                            UpdateOutputGamemode($"Dịch vụ '{displayServiceName}' đang chạy hoặc không tồn tại.");
                        }
                    }
                    else
                    {
                        UpdateOutputGamemode($"Dịch vụ '{displayServiceName}' không tồn tại.");
                    }
                }
                catch (Exception ex)
                {
                    UpdateOutputGamemode($"Lỗi khi khởi động lại dịch vụ '{displayServiceName}': {ex.Message}");
                }
            }
        }
        private bool endExplorerTask = false;

        private void checkexplorer_CheckedChanged(object sender, EventArgs e)
        {

            // Đặt giá trị biến dựa trên trạng thái của checkbox
            endExplorerTask = checkexplorer.Checked;
        }

    }
}
