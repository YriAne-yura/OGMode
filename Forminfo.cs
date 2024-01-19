using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ogmm
{
    public partial class Forminfo : Form
    {
        public Forminfo()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenUrl("https://www.facebook.com/SiroCandy06/");
        }

        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenUrl("https://discord.gg/NUhDfy8hXa");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenUrl("https://www.youtube.com/@osteup");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            OpenUrl("https://osteup.com/");
        }

    }
}
