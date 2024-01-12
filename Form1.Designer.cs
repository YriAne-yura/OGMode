
namespace ogmm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
 
        private void time1_Tick(object sender, EventArgs e)
        {
            Opacity = 100;
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            button4 = new Button();
            bntcontact = new Button();
            bnttool = new Button();
            btngamemode = new Button();
            btnhome = new Button();
            panel2 = new Panel();
            pnlnav = new Panel();
            label2 = new Label();
            usernamelog = new Label();
            pictureBox1 = new PictureBox();
            title = new Label();
            btnclose = new Button();
            btnminimize = new Button();
            panel3 = new Panel();
            label7 = new Label();
            pictureBox2 = new PictureBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            panel4 = new Panel();
            panel_move = new Panel();
            panel_body = new Panel();
            label3 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel4.SuspendLayout();
            panel_move.SuspendLayout();
            panel_body.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(24, 30, 54);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(bntcontact);
            panel1.Controls.Add(bnttool);
            panel1.Controls.Add(btngamemode);
            panel1.Controls.Add(btnhome);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(186, 577);
            panel1.TabIndex = 0;
            // 
            // button4
            // 
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Franklin Gothic Medium", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.FromArgb(0, 126, 249);
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.Location = new Point(0, 534);
            button4.Name = "button4";
            button4.Size = new Size(186, 43);
            button4.TabIndex = 5;
            button4.Text = "Cài Đặt";
            button4.TextImageRelation = TextImageRelation.TextBeforeImage;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            button4.Leave += button4_Leave;
            // 
            // bntcontact
            // 
            bntcontact.FlatAppearance.BorderSize = 0;
            bntcontact.FlatStyle = FlatStyle.Flat;
            bntcontact.Font = new Font("Franklin Gothic Medium", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bntcontact.ForeColor = Color.FromArgb(0, 126, 249);
            bntcontact.Image = (Image)resources.GetObject("bntcontact.Image");
            bntcontact.Location = new Point(0, 288);
            bntcontact.Name = "bntcontact";
            bntcontact.Size = new Size(186, 43);
            bntcontact.TabIndex = 4;
            bntcontact.Text = "Liên Hệ";
            bntcontact.TextImageRelation = TextImageRelation.TextBeforeImage;
            bntcontact.UseVisualStyleBackColor = true;
            bntcontact.Click += bntcontact_Click;
            bntcontact.Leave += btncontact_Leave;
            // 
            // bnttool
            // 
            bnttool.FlatAppearance.BorderSize = 0;
            bnttool.FlatStyle = FlatStyle.Flat;
            bnttool.Font = new Font("Franklin Gothic Medium", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnttool.ForeColor = Color.FromArgb(0, 126, 249);
            bnttool.Image = (Image)resources.GetObject("bnttool.Image");
            bnttool.Location = new Point(0, 239);
            bnttool.Name = "bnttool";
            bnttool.Size = new Size(186, 43);
            bnttool.TabIndex = 3;
            bnttool.Text = "Công Cụ";
            bnttool.TextImageRelation = TextImageRelation.TextBeforeImage;
            bnttool.UseVisualStyleBackColor = true;
            bnttool.Click += bnttool_Click;
            bnttool.Leave += bnttool_Leave;
            // 
            // btngamemode
            // 
            btngamemode.FlatAppearance.BorderSize = 0;
            btngamemode.FlatStyle = FlatStyle.Flat;
            btngamemode.Font = new Font("Franklin Gothic Medium", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btngamemode.ForeColor = Color.FromArgb(0, 126, 249);
            btngamemode.Image = (Image)resources.GetObject("btngamemode.Image");
            btngamemode.Location = new Point(0, 190);
            btngamemode.Name = "btngamemode";
            btngamemode.Size = new Size(186, 43);
            btngamemode.TabIndex = 2;
            btngamemode.Text = "Game Mode";
            btngamemode.TextImageRelation = TextImageRelation.TextBeforeImage;
            btngamemode.UseVisualStyleBackColor = true;
            btngamemode.Click += btngamemode_Click;
            btngamemode.Leave += btngamemode_Leave;
            // 
            // btnhome
            // 
            btnhome.FlatAppearance.BorderSize = 0;
            btnhome.FlatStyle = FlatStyle.Flat;
            btnhome.Font = new Font("Franklin Gothic Medium", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnhome.ForeColor = Color.FromArgb(0, 126, 249);
            btnhome.Image = (Image)resources.GetObject("btnhome.Image");
            btnhome.Location = new Point(0, 141);
            btnhome.Name = "btnhome";
            btnhome.Size = new Size(186, 43);
            btnhome.TabIndex = 1;
            btnhome.Text = "Giới Thiệu";
            btnhome.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnhome.UseVisualStyleBackColor = true;
            btnhome.Click += btnhome_Click;
            btnhome.Leave += btnhome_Leave;
            // 
            // panel2
            // 
            panel2.Controls.Add(pnlnav);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(usernamelog);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(186, 144);
            panel2.TabIndex = 0;
            // 
            // pnlnav
            // 
            pnlnav.BackColor = Color.FromArgb(0, 126, 249);
            pnlnav.Location = new Point(0, 193);
            pnlnav.Name = "pnlnav";
            pnlnav.Size = new Size(3, 100);
            pnlnav.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(36, 114);
            label2.Name = "label2";
            label2.Size = new Size(114, 16);
            label2.TabIndex = 2;
            label2.Text = "OGMode By Osteup";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // usernamelog
            // 
            usernamelog.AutoSize = true;
            usernamelog.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usernamelog.ForeColor = Color.FromArgb(0, 126, 249);
            usernamelog.Location = new Point(51, 88);
            usernamelog.Name = "usernamelog";
            usernamelog.Size = new Size(85, 16);
            usernamelog.TabIndex = 1;
            usernamelog.Text = "User Name";
            usernamelog.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = Properties.Resources.Untitled_11;
            pictureBox1.Location = new Point(62, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(64, 64);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            title.ForeColor = SystemColors.AppWorkspace;
            title.Location = new Point(27, 39);
            title.Name = "title";
            title.Size = new Size(147, 37);
            title.TabIndex = 1;
            title.Text = "Giới Thiệu";
            // 
            // btnclose
            // 
            btnclose.FlatAppearance.BorderSize = 0;
            btnclose.FlatStyle = FlatStyle.Flat;
            btnclose.ForeColor = Color.White;
            btnclose.Location = new Point(926, 0);
            btnclose.Name = "btnclose";
            btnclose.Size = new Size(25, 25);
            btnclose.TabIndex = 3;
            btnclose.Text = "x";
            btnclose.UseVisualStyleBackColor = true;
            btnclose.Click += btnclose_Click;
            // 
            // btnminimize
            // 
            btnminimize.FlatAppearance.BorderSize = 0;
            btnminimize.FlatStyle = FlatStyle.Flat;
            btnminimize.ForeColor = Color.White;
            btnminimize.Location = new Point(896, 0);
            btnminimize.Name = "btnminimize";
            btnminimize.Size = new Size(24, 24);
            btnminimize.TabIndex = 4;
            btnminimize.Text = "–";
            btnminimize.UseVisualStyleBackColor = true;
            btnminimize.Click += btnminimize_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(label7);
            panel3.Controls.Add(pictureBox2);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label4);
            panel3.Location = new Point(58, 27);
            panel3.Name = "panel3";
            panel3.Size = new Size(658, 218);
            panel3.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ButtonFace;
            label7.Location = new Point(423, 162);
            label7.Name = "label7";
            label7.Size = new Size(176, 18);
            label7.TabIndex = 4;
            label7.Text = "---------WDLF Osteup--------";
            label7.Click += label7_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(211, 215);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ButtonFace;
            label6.Location = new Point(243, 114);
            label6.Name = "label6";
            label6.Size = new Size(234, 18);
            label6.TabIndex = 2;
            label6.Text = "Update thêm tối ưu hoá vô game mode";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ButtonFace;
            label5.Location = new Point(243, 71);
            label5.Name = "label5";
            label5.Size = new Size(164, 18);
            label5.TabIndex = 1;
            label5.Text = "Update thêm hiệu ứng app";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(382, 21);
            label4.Name = "label4";
            label4.Size = new Size(109, 19);
            label4.TabIndex = 0;
            label4.Text = "OGMode v1.1.0";
            // 
            // panel4
            // 
            panel4.Controls.Add(panel_move);
            panel4.Controls.Add(title);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(186, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(765, 104);
            panel4.TabIndex = 6;
            // 
            // panel_move
            // 
            panel_move.BackColor = Color.FromArgb(24, 30, 54);
            panel_move.Controls.Add(btnclose);
            panel_move.Controls.Add(btnminimize);
            panel_move.Location = new Point(-186, 0);
            panel_move.Name = "panel_move";
            panel_move.Size = new Size(951, 26);
            panel_move.TabIndex = 5;
            // 
            // panel_body
            // 
            panel_body.Controls.Add(label3);
            panel_body.Controls.Add(panel3);
            panel_body.Location = new Point(186, 104);
            panel_body.Name = "panel_body";
            panel_body.Size = new Size(765, 473);
            panel_body.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(58, 291);
            label3.Name = "label3";
            label3.Size = new Size(547, 17);
            label3.TabIndex = 6;
            label3.Text = "-> Lưu ý: Hãy Chạy Chương trình với quyền administrators để sử dụng 100% tính năng";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Tick += timer1_tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(951, 577);
            Controls.Add(panel_body);
            Controls.Add(panel4);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Opacity = 0D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel_move.ResumeLayout(false);
            panel_body.ResumeLayout(false);
            panel_body.PerformLayout();
            ResumeLayout(false);
        }

        private void btnhome_Leave(object sender, EventArgs e)
        {
            btnhome.BackColor = Color.FromArgb(24, 30, 54);
        }
        private void btngamemode_Leave(object sender, EventArgs e)
        {
            btngamemode.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void bnttool_Leave(object sender, EventArgs e)
        {
            bnttool.BackColor = Color.FromArgb(24, 30, 54);
        }
        private void btncontact_Leave(object sender, EventArgs e)
        {
            bntcontact.BackColor = Color.FromArgb(24, 30, 54);
        }
        private void button4_Leave(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(24, 30, 54);
        }
        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label usernamelog;
        private Label label2;
        private Button btnhome;
        private Button btngamemode;
        private Button button4;
        private Button bntcontact;
        private Button bnttool;
        private Panel pnlnav;
        private Label title;
        private Button btnclose;
        private Button btnminimze;
        private Panel panel3;
        private Label label5;
        private Label label4;
        private Label label6;
        private Label label7;
        private PictureBox pictureBox2;
        private Button btnminimize;
        private Panel panel4;
        private Panel panel_body;
        private Label label3;
        private Panel panel_move;
        private System.Windows.Forms.Timer timer1;
    }
}
