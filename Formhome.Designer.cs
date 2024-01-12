namespace ogmm
{
    partial class Formhome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            toolTip1 = new ToolTip(components);
            btngamemode = new Button();
            panel1 = new Panel();
            panel3 = new Panel();
            outputgamemode = new TextBox();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            checkexplorer = new CheckBox();
            label3 = new Label();
            Userwindows = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // btngamemode
            // 
            btngamemode.BackColor = Color.FromArgb(255, 128, 128);
            btngamemode.Cursor = Cursors.Hand;
            btngamemode.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btngamemode.ForeColor = Color.FromArgb(1, 140, 255);
            btngamemode.Location = new Point(598, 12);
            btngamemode.Name = "btngamemode";
            btngamemode.Size = new Size(128, 128);
            btngamemode.TabIndex = 3;
            btngamemode.Text = "Bắt Đầu";
            btngamemode.UseVisualStyleBackColor = false;
            btngamemode.Click += btngamemode_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 157);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(20);
            panel1.Size = new Size(749, 277);
            panel1.TabIndex = 5;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(36, 42, 59);
            panel3.Controls.Add(outputgamemode);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(23, 23);
            panel3.Name = "panel3";
            panel3.Size = new Size(703, 231);
            panel3.TabIndex = 0;
            // 
            // outputgamemode
            // 
            outputgamemode.BackColor = Color.FromArgb(36, 42, 59);
            outputgamemode.BorderStyle = BorderStyle.None;
            outputgamemode.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            outputgamemode.ForeColor = SystemColors.InactiveCaption;
            outputgamemode.Location = new Point(46, 36);
            outputgamemode.Multiline = true;
            outputgamemode.Name = "outputgamemode";
            outputgamemode.ReadOnly = true;
            outputgamemode.Size = new Size(621, 175);
            outputgamemode.TabIndex = 3;
            outputgamemode.Text = "Chưa có gì xảy ra...";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlDark;
            label2.Location = new Point(15, 36);
            label2.Name = "label2";
            label2.Size = new Size(31, 13);
            label2.TabIndex = 1;
            label2.Text = ">>>";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlDark;
            label1.Location = new Point(15, 13);
            label1.Name = "label1";
            label1.Size = new Size(216, 13);
            label1.TabIndex = 0;
            label1.Text = "WDLF Osteup [ Version v0.01.2564 beta ]";
            // 
            // panel2
            // 
            panel2.Controls.Add(checkexplorer);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(Userwindows);
            panel2.Controls.Add(btngamemode);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(749, 152);
            panel2.TabIndex = 6;
            // 
            // checkexplorer
            // 
            checkexplorer.AutoSize = true;
            checkexplorer.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkexplorer.ForeColor = SystemColors.Control;
            checkexplorer.Location = new Point(56, 110);
            checkexplorer.Name = "checkexplorer";
            checkexplorer.Size = new Size(122, 19);
            checkexplorer.TabIndex = 6;
            checkexplorer.Text = "Windows Explorer";
            checkexplorer.UseVisualStyleBackColor = true;
            checkexplorer.CheckedChanged += checkexplorer_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(0, 54);
            label3.Name = "label3";
            label3.Padding = new Padding(50, 20, 5, 5);
            label3.Size = new Size(418, 44);
            label3.TabIndex = 5;
            label3.Text = "Chức năng chơi game mượt hơn trên máy tính";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // Userwindows
            // 
            Userwindows.AutoSize = true;
            Userwindows.Dock = DockStyle.Top;
            Userwindows.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Userwindows.ForeColor = SystemColors.ButtonFace;
            Userwindows.Location = new Point(0, 0);
            Userwindows.Name = "Userwindows";
            Userwindows.Padding = new Padding(50, 20, 5, 5);
            Userwindows.Size = new Size(233, 54);
            Userwindows.TabIndex = 4;
            Userwindows.Text = "Username: Lỗi";
            Userwindows.TextAlign = ContentAlignment.TopCenter;
            // 
            // Formhome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(749, 434);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Formhome";
            Text = "Formhome";
            Load += Formhome_Load;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ToolTip toolTip1;
        private Button btngamemode;
        private Panel panel1;
        private Panel panel2;
        private Label label3;
        private Label Userwindows;
        private Panel panel3;
        private Label label1;
        private Label label2;
        private TextBox outputgamemode;
        private CheckBox checkexplorer;
    }
}