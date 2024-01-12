using System.Runtime.InteropServices;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Reflection;

namespace ogmm
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        private const int SW_HIDE = 0;
        private const int SW_RESTORE = 9;

        private bool isMinimized = false;
        // Khai báo các hàm và hằng số để di chuyển cửa sổ
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            // Xác định khi nào form được minimize
            if (this.WindowState == FormWindowState.Minimized)
            {
                isMinimized = true;
                this.ShowInTaskbar = false;
            }
            else
            {
                isMinimized = false;
                this.ShowInTaskbar = true;
            }
        }
        // Xử lí các navigation hehee

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
           int nLeftRect,
           int nTopRect,
           int nRightRect,
           int nBottomRect,
           int nWidthEllipse,
           int nHeightEllipse

            );

        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlnav.Height = btnhome.Height;
            pnlnav.Top = btnhome.Top;
            pnlnav.Left = btnhome.Left;
            btnhome.BackColor = Color.FromArgb(46, 51, 73);
            // Thêm sự kiện chuột cho panel_move để di chuyển cửa sổ
            panel_move.MouseDown += PanelMove_MouseDown;
            panel_move.MouseMove += PanelMove_MouseMove;

        }


        private void PanelMove_MouseDown(object sender, MouseEventArgs e)
        {
            // Khi chuột được nhấn vào panel, di chuyển cửa sổ
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void PanelMove_MouseMove(object sender, MouseEventArgs e)
        {
            // Khi chuột được di chuyển trên panel, thực hiện các xử lý nếu cần
            // Ví dụ: thay đổi màu sắc hoặc hiển thị thông tin gì đó
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            // Ẩn chương trình xuống taskbar khi bấm vào dấu "-"
            if (!isMinimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            // Đóng chương trình khi bấm vào button
            while (Opacity > 0)
            {
                Opacity -= 0.1; // Adjust the decrement value for the fading speed
                System.Threading.Thread.Sleep(1); // Add a delay to control the fading speed
                Application.DoEvents(); // Allow the UI to update during the loop
                if (Opacity == 0 )
                {
                    this.Close();
                }
            }
        }



        // Minimize Forms Taskbar
        const int WS_MINIMIZEBOX = 0x20000;
        const int CS_DBLCLKS = 0x8;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= WS_MINIMIZEBOX;
                cp.ClassStyle |= CS_DBLCLKS;
                return cp;
            }
        }

        public bool Drag { get; private set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnclose.Click += btnclose_Click;

            // Bổ sung code để lấy tên người dùng và thay thế cho "usernamelog"
            string username = Environment.UserName;
            usernamelog.Text = username;

        }


        private void btnhome_Click(object sender, EventArgs e)
        {
            pnlnav.Height = btnhome.Height;
            pnlnav.Top = btnhome.Top;
            pnlnav.Left = btnhome.Left;
            btnhome.BackColor = Color.FromArgb(46, 51, 73);
            CurrentFormChild.Close();
            activebordersolid(btnhome);
            title.Text = "Giới Thiệu";


        }

        private void btngamemode_Click(object sender, EventArgs e)
        {
            pnlnav.Height = btngamemode.Height;
            pnlnav.Top = btngamemode.Top;
            pnlnav.Left = btngamemode.Left;
            btngamemode.BackColor = Color.FromArgb(46, 51, 73);
            activebordersolid(btngamemode);
            OpenChildForm(new Formhome());
            title.Text = "GameMode";
        }

        private void bnttool_Click(object sender, EventArgs e)
        {
            pnlnav.Height = bnttool.Height;
            pnlnav.Top = bnttool.Top;
            pnlnav.Left = bnttool.Left;
            bnttool.BackColor = Color.FromArgb(46, 51, 73);
            OpenChildForm(new Formtools());
            activebordersolid(bnttool);
            title.Text = "Công Cụ";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            pnlnav.Height = button4.Height;
            pnlnav.Top = button4.Top;
            pnlnav.Left = button4.Left;
            button4.BackColor = Color.FromArgb(46, 51, 73);
            activebordersolid(button4);
            OpenChildForm(new Formtools());
            title.Text = "Cài Đặt";

        }


        private void bntcontact_Click(object sender, EventArgs e)
        {
            pnlnav.Height = bntcontact.Height;
            pnlnav.Top = bntcontact.Top;
            pnlnav.Left = bntcontact.Left;
            bntcontact.BackColor = Color.FromArgb(46, 51, 73);
            activebordersolid(bntcontact);
            OpenChildForm(new Forminfo());
            title.Text = "Liên hệ";

        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }



        // Form child
        private Form CurrentFormChild;
        private Button IDnamesave;

        private void activebordersolid(Button IDname)
        {
            if (IDnamesave != null)
            {
                IDnamesave.FlatAppearance.BorderSize = 0;
            }
            IDname.FlatStyle = FlatStyle.Flat;
            IDname.FlatAppearance.BorderColor = Color.FromArgb(0, 126, 249);
            IDname.FlatAppearance.BorderSize = 1;
            IDnamesave = IDname;


        }


        private void OpenChildForm(Form childForm)
        {
            if (CurrentFormChild != null)
            {
                CurrentFormChild.Close();
            }
            CurrentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_body.Controls.Add(childForm);
            panel_body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (CurrentFormChild != null)
            {
                CurrentFormChild.Close();
            }
            if (IDnamesave != null)
            {
                IDnamesave.FlatAppearance.BorderSize = 0;
            }

        }

        private void timer1_tick(object sender, EventArgs e)
        {
            if (Opacity >= 1)
            {
                Opacity = 1;
            }
            Opacity += .1;
            if (Opacity == 1)
            {
                timer1.Stop();
            }
        }

        private void timer2_tick(object sender, EventArgs e)
        {
           
        }

    }
}
