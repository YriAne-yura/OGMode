using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;

namespace ogmm
{
    public partial class Formtools : Form
    {

        [DllImport("psapi")]
        public static extern int EmptyWorkingSet(IntPtr handle);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string methodName);

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail), DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string moduleName);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr GetCurrentProcess();

        [SecurityCritical]
        internal static bool DoesWin32MethodExist(string moduleName, string methodName)
        {
            IntPtr moduleHandle = GetModuleHandle(moduleName);
            if (moduleHandle == IntPtr.Zero)
            {
                return false;
            }
            return (GetProcAddress(moduleHandle, methodName) != IntPtr.Zero);
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool IsWow64Process([In] IntPtr hSourceProcessHandle, [MarshalAs(UnmanagedType.Bool)] out bool isWow64);

        [SecuritySafeCritical]
        public static bool get_Is64BitOperatingSystem()
        {
            bool flag;
            return (IntPtr.Size == 8) ||
                ((DoesWin32MethodExist("kernel32.dll", "IsWow64Process") &&
                IsWow64Process(GetCurrentProcess(), out flag)) && flag);
        }
        public Formtools()
        {
            InitializeComponent();
            GraphUpdate();

            // Bắt đầu một task chạy vô hạn để gọi GraphUpdate() sau mỗi 1 giây
            Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(1000); // Đợi 1 giây
                    GraphUpdate();
                }
            });
        }


        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel1.ClientRectangle, Color.FromArgb(70, 77, 111), ButtonBorderStyle.Solid);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            GraphUpdate();
            if (button1.Enabled == false) button1.Enabled = true;
        }

        private void GraphUpdate()
        {
            Int64 phav = PerformanceInfo.GetPhysicalAvailableMemoryInMiB();
            Int64 tot = PerformanceInfo.GetTotalMemoryInMiB();
            decimal percentFree = ((decimal)phav / (decimal)tot) * 100;
            decimal percentOccupied = 100 - percentFree;
            progressBar1.Value = Convert.ToInt32(Math.Round(percentOccupied));
            label2.Text = "RAM Sử dụng (" + Convert.ToInt32(Math.Round(percentOccupied)) + "%)";
        }

        private void MakeCircularButton(Button button)
        {
            // Làm cho nút trở thành hình tròn
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Size = new Size(80, 80); // Đặt kích thước theo mong muốn

            // Thiết lập độ cong để tạo hình tròn
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, button.Width, button.Height);
            button.Region = new Region(path);
        }

        public static class PerformanceInfo
        {
            [DllImport("psapi.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetPerformanceInfo([Out] out PerformanceInformation PerformanceInformation, [In] int Size);

            [StructLayout(LayoutKind.Sequential)]
            public struct PerformanceInformation
            {
                public int Size;
                public IntPtr CommitTotal;
                public IntPtr CommitLimit;
                public IntPtr CommitPeak;
                public IntPtr PhysicalTotal;
                public IntPtr PhysicalAvailable;
                public IntPtr SystemCache;
                public IntPtr KernelTotal;
                public IntPtr KernelPaged;
                public IntPtr KernelNonPaged;
                public IntPtr PageSize;
                public int HandlesCount;
                public int ProcessCount;
                public int ThreadCount;
            }

            public static Int64 GetPhysicalAvailableMemoryInMiB()
            {
                PerformanceInformation pi = new PerformanceInformation();
                if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi)))
                {
                    return Convert.ToInt64((pi.PhysicalAvailable.ToInt64() * pi.PageSize.ToInt64() / 1048576));
                }
                else
                {
                    return -1;
                }
            }

            public static Int64 GetTotalMemoryInMiB()
            {
                PerformanceInformation pi = new PerformanceInformation();
                if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi)))
                {
                    return Convert.ToInt64((pi.PhysicalTotal.ToInt64() * pi.PageSize.ToInt64() / 1048576));
                }
                else
                {
                    return -1;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Int64 phav = PerformanceInfo.GetPhysicalAvailableMemoryInMiB();
            Int64 tot = PerformanceInfo.GetTotalMemoryInMiB();
            decimal percentFree = ((decimal)phav / (decimal)tot) * 100;
            decimal percentOccupied = 100 - percentFree;

        }

        private async void button1_Click(object sender, EventArgs e)
        {

            Int64 phav = PerformanceInfo.GetPhysicalAvailableMemoryInMiB();
            Int64 tot = PerformanceInfo.GetTotalMemoryInMiB();
            decimal percentFree = ((decimal)phav / (decimal)tot) * 100;
            decimal percentOccupied = 100 - percentFree;

            int Ramused = Convert.ToInt32(Math.Round(percentOccupied));

            // Memory Clean
            Process[] process = Process.GetProcesses();
            foreach (Process p in process) try { EmptyWorkingSet(p.Handle); } catch { }
            DirectoryInfo directory = new DirectoryInfo(Path.GetTempPath());

            // Chờ một khoảng thời gian mà không làm đóng băng giao diện người dùng
            await Task.Delay(5000);

            Int64 phav2 = PerformanceInfo.GetPhysicalAvailableMemoryInMiB();
            Int64 tot2 = PerformanceInfo.GetTotalMemoryInMiB();
            decimal percentFree2 = ((decimal)phav2 / (decimal)tot2) * 100;
            decimal percentOccupied2 = 100 - percentFree2;
            int Ramused2 = Convert.ToInt32(Math.Round(percentOccupied2));
            // Tính toán phần trăm và số MB RAM đã dọn
            MessageBox.Show($"RAM từ " + Ramused + "% Giảm Xuống " + Ramused2 +"%", "OGMode CleanRAM By WDLF Osteup", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void Formtools_Paint(object sender, PaintEventArgs e)
        {
            MakeCircularButton(button1);
            // Tạo một Pen với màu mong muốn và độ đậm tăng thêm 1
            using (Pen borderPen = new Pen(Color.FromArgb(70, 77, 111), 2)) // 2 là độ đậm
            {
                // Đặt SmoothingMode thành AntiAlias để làm mịn các đường vẽ
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Vẽ đường viền trực tiếp lên Graphics
                e.Graphics.DrawEllipse(borderPen, button1.ClientRectangle);

                // Đặt SmoothingMode lại thành Default để tránh ảnh hưởng đến các vẽ khác
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            }
        }
    }
}
