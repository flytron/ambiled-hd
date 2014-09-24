namespace DxCapture
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.CaptureTimer = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.MyNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.MyContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lightLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.showSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sleepModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pseudoFullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.RunOnStartup = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.UpDown_Gap = new System.Windows.Forms.NumericUpDown();
            this.Gap_Textbox = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.UpDown_Right = new System.Windows.Forms.NumericUpDown();
            this.Right_Textbox = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.UpDown_Left = new System.Windows.Forms.NumericUpDown();
            this.Left_Textbox = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.UpDown_Top = new System.Windows.Forms.NumericUpDown();
            this.Top_Textbox = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.UpDown_BottomLeft = new System.Windows.Forms.NumericUpDown();
            this.BottomLeft_Textbox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.UpDown_BottomRight = new System.Windows.Forms.NumericUpDown();
            this.BottomRight_Textbox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ScreenPanel = new System.Windows.Forms.Panel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.MyContextMenuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_Gap)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_Right)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_Left)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_Top)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_BottomLeft)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_BottomRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CaptureTimer
            // 
            this.CaptureTimer.Tick += new System.EventHandler(this.CaptureTimer_Tick);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.PortName = "COM3";
            this.serialPort1.WriteBufferSize = 4096;
            // 
            // MyNotifyIcon
            // 
            this.MyNotifyIcon.BalloonTipText = "Active Here";
            this.MyNotifyIcon.BalloonTipTitle = "AmbiLED HD";
            this.MyNotifyIcon.ContextMenuStrip = this.MyContextMenuStrip;
            this.MyNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("MyNotifyIcon.Icon")));
            this.MyNotifyIcon.Text = "AmbiLED HD";
            this.MyNotifyIcon.Visible = true;
            this.MyNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            this.MyNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // MyContextMenuStrip
            // 
            this.MyContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lightLevelToolStripMenuItem,
            this.showSettingsToolStripMenuItem,
            this.sleepModeToolStripMenuItem,
            this.pseudoFullScreenToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.MyContextMenuStrip.Name = "contextMenuStrip1";
            this.MyContextMenuStrip.Size = new System.Drawing.Size(174, 114);
            this.MyContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // lightLevelToolStripMenuItem
            // 
            this.lightLevelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem7,
            this.toolStripMenuItem3,
            this.toolStripMenuItem8,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.lightLevelToolStripMenuItem.Name = "lightLevelToolStripMenuItem";
            this.lightLevelToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.lightLevelToolStripMenuItem.Text = "Light Level";
            // 
            // autoToolStripMenuItem
            // 
            this.autoToolStripMenuItem.Name = "autoToolStripMenuItem";
            this.autoToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.autoToolStripMenuItem.Text = "Auto";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem2.Text = "%10";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem7.Text = "%15";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem3.Text = "%20";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem8.Text = "%25";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem4.Text = "%30";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem5.Text = "%40";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem6.Text = "%50";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // showSettingsToolStripMenuItem
            // 
            this.showSettingsToolStripMenuItem.Name = "showSettingsToolStripMenuItem";
            this.showSettingsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.showSettingsToolStripMenuItem.Text = "Show Setup";
            this.showSettingsToolStripMenuItem.Click += new System.EventHandler(this.showSettingsToolStripMenuItem_Click);
            // 
            // sleepModeToolStripMenuItem
            // 
            this.sleepModeToolStripMenuItem.Name = "sleepModeToolStripMenuItem";
            this.sleepModeToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.sleepModeToolStripMenuItem.Text = "Sleep Mode";
            this.sleepModeToolStripMenuItem.Click += new System.EventHandler(this.sleepModeToolStripMenuItem_Click);
            // 
            // pseudoFullScreenToolStripMenuItem
            // 
            this.pseudoFullScreenToolStripMenuItem.Name = "pseudoFullScreenToolStripMenuItem";
            this.pseudoFullScreenToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.pseudoFullScreenToolStripMenuItem.Text = "Pseudo Full Screen";
            this.pseudoFullScreenToolStripMenuItem.Click += new System.EventHandler(this.pseudoFullScreenToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(717, 460);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button2);
            this.tabPage4.Controls.Add(this.checkBox1);
            this.tabPage4.Controls.Add(this.RunOnStartup);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(709, 434);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Main Settings";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.tabPage4.Click += new System.EventHandler(this.tabPage4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(209, 158);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Ambient Sensor Read";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 31);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(133, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Black Stripe Elliminator";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // RunOnStartup
            // 
            this.RunOnStartup.AutoSize = true;
            this.RunOnStartup.Location = new System.Drawing.Point(6, 8);
            this.RunOnStartup.Name = "RunOnStartup";
            this.RunOnStartup.Size = new System.Drawing.Size(100, 17);
            this.RunOnStartup.TabIndex = 0;
            this.RunOnStartup.Text = "Run On Startup";
            this.RunOnStartup.UseVisualStyleBackColor = true;
            this.RunOnStartup.CheckedChanged += new System.EventHandler(this.RunOnStartup_CheckedChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(709, 434);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "LED Strip Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonSave);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(7, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(699, 426);
            this.panel2.TabIndex = 18;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(631, 375);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(62, 46);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel8.Controls.Add(this.label6);
            this.panel8.Controls.Add(this.UpDown_Gap);
            this.panel8.Controls.Add(this.Gap_Textbox);
            this.panel8.Location = new System.Drawing.Point(299, 381);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(94, 29);
            this.panel8.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Gap";
            // 
            // UpDown_Gap
            // 
            this.UpDown_Gap.Location = new System.Drawing.Point(73, 5);
            this.UpDown_Gap.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.UpDown_Gap.Name = "UpDown_Gap";
            this.UpDown_Gap.Size = new System.Drawing.Size(17, 20);
            this.UpDown_Gap.TabIndex = 2;
            this.UpDown_Gap.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.UpDown_Gap.ValueChanged += new System.EventHandler(this.UpDown_Gap_ValueChanged);
            // 
            // Gap_Textbox
            // 
            this.Gap_Textbox.Location = new System.Drawing.Point(36, 5);
            this.Gap_Textbox.Name = "Gap_Textbox";
            this.Gap_Textbox.ReadOnly = true;
            this.Gap_Textbox.Size = new System.Drawing.Size(31, 20);
            this.Gap_Textbox.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Silver;
            this.panel7.Controls.Add(this.label5);
            this.panel7.Controls.Add(this.UpDown_Right);
            this.panel7.Controls.Add(this.Right_Textbox);
            this.panel7.Location = new System.Drawing.Point(630, 184);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(64, 54);
            this.panel7.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Right LEDs";
            // 
            // UpDown_Right
            // 
            this.UpDown_Right.Location = new System.Drawing.Point(42, 24);
            this.UpDown_Right.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.UpDown_Right.Name = "UpDown_Right";
            this.UpDown_Right.Size = new System.Drawing.Size(17, 20);
            this.UpDown_Right.TabIndex = 2;
            this.UpDown_Right.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.UpDown_Right.ValueChanged += new System.EventHandler(this.UpDown_Right_ValueChanged);
            // 
            // Right_Textbox
            // 
            this.Right_Textbox.Location = new System.Drawing.Point(5, 24);
            this.Right_Textbox.Name = "Right_Textbox";
            this.Right_Textbox.ReadOnly = true;
            this.Right_Textbox.Size = new System.Drawing.Size(31, 20);
            this.Right_Textbox.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Silver;
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.UpDown_Left);
            this.panel6.Controls.Add(this.Left_Textbox);
            this.panel6.Location = new System.Drawing.Point(5, 184);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(64, 54);
            this.panel6.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Left LEDs";
            // 
            // UpDown_Left
            // 
            this.UpDown_Left.Location = new System.Drawing.Point(42, 24);
            this.UpDown_Left.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.UpDown_Left.Name = "UpDown_Left";
            this.UpDown_Left.Size = new System.Drawing.Size(17, 20);
            this.UpDown_Left.TabIndex = 2;
            this.UpDown_Left.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.UpDown_Left.ValueChanged += new System.EventHandler(this.UpDown_Left_ValueChanged);
            // 
            // Left_Textbox
            // 
            this.Left_Textbox.Location = new System.Drawing.Point(5, 24);
            this.Left_Textbox.Name = "Left_Textbox";
            this.Left_Textbox.ReadOnly = true;
            this.Left_Textbox.Size = new System.Drawing.Size(31, 20);
            this.Left_Textbox.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Silver;
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.UpDown_Top);
            this.panel5.Controls.Add(this.Top_Textbox);
            this.panel5.Location = new System.Drawing.Point(291, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(115, 29);
            this.panel5.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Top LEDs";
            // 
            // UpDown_Top
            // 
            this.UpDown_Top.Location = new System.Drawing.Point(94, 4);
            this.UpDown_Top.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.UpDown_Top.Name = "UpDown_Top";
            this.UpDown_Top.Size = new System.Drawing.Size(17, 20);
            this.UpDown_Top.TabIndex = 2;
            this.UpDown_Top.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.UpDown_Top.ValueChanged += new System.EventHandler(this.UpDown_Top_ValueChanged);
            // 
            // Top_Textbox
            // 
            this.Top_Textbox.Location = new System.Drawing.Point(57, 3);
            this.Top_Textbox.Name = "Top_Textbox";
            this.Top_Textbox.ReadOnly = true;
            this.Top_Textbox.Size = new System.Drawing.Size(31, 20);
            this.Top_Textbox.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Silver;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.UpDown_BottomLeft);
            this.panel4.Controls.Add(this.BottomLeft_Textbox);
            this.panel4.Location = new System.Drawing.Point(103, 381);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(163, 29);
            this.panel4.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bottom Left LEDs";
            // 
            // UpDown_BottomLeft
            // 
            this.UpDown_BottomLeft.Location = new System.Drawing.Point(142, 4);
            this.UpDown_BottomLeft.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.UpDown_BottomLeft.Name = "UpDown_BottomLeft";
            this.UpDown_BottomLeft.Size = new System.Drawing.Size(17, 20);
            this.UpDown_BottomLeft.TabIndex = 2;
            this.UpDown_BottomLeft.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.UpDown_BottomLeft.ValueChanged += new System.EventHandler(this.UpDown_BottomLeft_ValueChanged);
            // 
            // BottomLeft_Textbox
            // 
            this.BottomLeft_Textbox.Location = new System.Drawing.Point(105, 4);
            this.BottomLeft_Textbox.Name = "BottomLeft_Textbox";
            this.BottomLeft_Textbox.ReadOnly = true;
            this.BottomLeft_Textbox.Size = new System.Drawing.Size(31, 20);
            this.BottomLeft_Textbox.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.UpDown_BottomRight);
            this.panel3.Controls.Add(this.BottomRight_Textbox);
            this.panel3.Location = new System.Drawing.Point(426, 381);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(163, 29);
            this.panel3.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bottom Right LEDs";
            // 
            // UpDown_BottomRight
            // 
            this.UpDown_BottomRight.Location = new System.Drawing.Point(142, 4);
            this.UpDown_BottomRight.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.UpDown_BottomRight.Name = "UpDown_BottomRight";
            this.UpDown_BottomRight.Size = new System.Drawing.Size(17, 20);
            this.UpDown_BottomRight.TabIndex = 2;
            this.UpDown_BottomRight.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.UpDown_BottomRight.ValueChanged += new System.EventHandler(this.UpDown_BottomRight_ValueChanged);
            // 
            // BottomRight_Textbox
            // 
            this.BottomRight_Textbox.Location = new System.Drawing.Point(105, 4);
            this.BottomRight_Textbox.Name = "BottomRight_Textbox";
            this.BottomRight_Textbox.ReadOnly = true;
            this.BottomRight_Textbox.Size = new System.Drawing.Size(31, 20);
            this.BottomRight_Textbox.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AmbiLED_HD.Properties.Resources.d630_032;
            this.pictureBox1.Location = new System.Drawing.Point(75, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(549, 382);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(709, 434);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Advanced";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(305, 17);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(103, 168);
            this.textBox1.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(64, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 66);
            this.button1.TabIndex = 16;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ScreenPanel);
            this.panel1.Location = new System.Drawing.Point(29, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 195);
            this.panel1.TabIndex = 15;
            // 
            // ScreenPanel
            // 
            this.ScreenPanel.BackColor = System.Drawing.Color.DodgerBlue;
            this.ScreenPanel.Location = new System.Drawing.Point(25, 14);
            this.ScreenPanel.Name = "ScreenPanel";
            this.ScreenPanel.Size = new System.Drawing.Size(100, 67);
            this.ScreenPanel.TabIndex = 15;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(709, 434);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "About";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 461);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AmbiLED Driver v1.0";
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.MyContextMenuStrip.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_Gap)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_Right)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_Left)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_Top)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_BottomLeft)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_BottomRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer CaptureTimer;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.NotifyIcon MyNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip MyContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem sleepModeToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown UpDown_Gap;
        private System.Windows.Forms.TextBox Gap_Textbox;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown UpDown_Right;
        private System.Windows.Forms.TextBox Right_Textbox;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown UpDown_Left;
        private System.Windows.Forms.TextBox Left_Textbox;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown UpDown_Top;
        private System.Windows.Forms.TextBox Top_Textbox;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown UpDown_BottomLeft;
        private System.Windows.Forms.TextBox BottomLeft_Textbox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown UpDown_BottomRight;
        private System.Windows.Forms.TextBox BottomRight_Textbox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel ScreenPanel;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox RunOnStartup;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolStripMenuItem pseudoFullScreenToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonSave;

    }
}

