namespace AmbiLED
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
        /* protected override void Dispose(bool disposing)
         {
             if (disposing && (components != null))
             {
                 components.Dispose();
             }
             base.Dispose(disposing); 
         }
         */
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
            this.ratioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cinematic21x9ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hD16x9ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oLDTV4x3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlineMovieThinBarsOnTopbottomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dVideoSideBySideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dualMonitorSideBySideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorSelectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sleepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pseudoFullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.showSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.DelayLabel = new System.Windows.Forms.Label();
            this.DelayBar = new System.Windows.Forms.TrackBar();
            this.button2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.ComPortCombo = new System.Windows.Forms.ComboBox();
            this.TransmitTimeLabel = new System.Windows.Forms.Label();
            this.ProcessTimeLabel = new System.Windows.Forms.Label();
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
            this.Aero_CheckBox = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.processList = new System.Windows.Forms.ListBox();
            this.MonitorSleepButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ScreenPanel = new System.Windows.Forms.Panel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.StaticColorTimer = new System.Windows.Forms.Timer(this.components);
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.MyContextMenuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DelayBar)).BeginInit();
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
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            // 
            // MyNotifyIcon
            // 
            this.MyNotifyIcon.BalloonTipText = "Active Here";
            this.MyNotifyIcon.BalloonTipTitle = "AmbiLED HD";
            this.MyNotifyIcon.ContextMenuStrip = this.MyContextMenuStrip;
            this.MyNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("MyNotifyIcon.Icon")));
            this.MyNotifyIcon.Text = "AmbiLED HD";
            this.MyNotifyIcon.Visible = true;
            // 
            // MyContextMenuStrip
            // 
            this.MyContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lightLevelToolStripMenuItem,
            this.ratioToolStripMenuItem,
            this.ModeToolStripMenuItem,
            this.pseudoFullScreenToolStripMenuItem,
            this.showSettingsToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.MyContextMenuStrip.Name = "contextMenuStrip1";
            this.MyContextMenuStrip.Size = new System.Drawing.Size(174, 136);
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
            this.autoToolStripMenuItem.Enabled = false;
            this.autoToolStripMenuItem.Name = "autoToolStripMenuItem";
            this.autoToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.autoToolStripMenuItem.Text = "Auto";
            this.autoToolStripMenuItem.Click += new System.EventHandler(this.autoToolStripMenuItem_Click);
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
            // ratioToolStripMenuItem
            // 
            this.ratioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullScreenToolStripMenuItem,
            this.cinematic21x9ToolStripMenuItem,
            this.hD16x9ToolStripMenuItem,
            this.oLDTV4x3ToolStripMenuItem,
            this.onlineMovieThinBarsOnTopbottomToolStripMenuItem,
            this.dVideoSideBySideToolStripMenuItem,
            this.dualMonitorSideBySideToolStripMenuItem});
            this.ratioToolStripMenuItem.Name = "ratioToolStripMenuItem";
            this.ratioToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.ratioToolStripMenuItem.Text = "Aspect Ratio";
            // 
            // fullScreenToolStripMenuItem
            // 
            this.fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
            this.fullScreenToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.fullScreenToolStripMenuItem.Text = "Default - Full Screen";
            this.fullScreenToolStripMenuItem.Click += new System.EventHandler(this.fullScreenToolStripMenuItem_Click);
            // 
            // cinematic21x9ToolStripMenuItem
            // 
            this.cinematic21x9ToolStripMenuItem.Name = "cinematic21x9ToolStripMenuItem";
            this.cinematic21x9ToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.cinematic21x9ToolStripMenuItem.Text = "Cinematic - 21x9";
            this.cinematic21x9ToolStripMenuItem.Click += new System.EventHandler(this.cinematic21x9ToolStripMenuItem_Click);
            // 
            // hD16x9ToolStripMenuItem
            // 
            this.hD16x9ToolStripMenuItem.Name = "hD16x9ToolStripMenuItem";
            this.hD16x9ToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.hD16x9ToolStripMenuItem.Text = "HD  - 16x9";
            this.hD16x9ToolStripMenuItem.Click += new System.EventHandler(this.hD16x9ToolStripMenuItem_Click);
            // 
            // oLDTV4x3ToolStripMenuItem
            // 
            this.oLDTV4x3ToolStripMenuItem.Name = "oLDTV4x3ToolStripMenuItem";
            this.oLDTV4x3ToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.oLDTV4x3ToolStripMenuItem.Text = "OLD TV - 4x3";
            this.oLDTV4x3ToolStripMenuItem.Click += new System.EventHandler(this.oLDTV4x3ToolStripMenuItem_Click);
            // 
            // onlineMovieThinBarsOnTopbottomToolStripMenuItem
            // 
            this.onlineMovieThinBarsOnTopbottomToolStripMenuItem.Name = "onlineMovieThinBarsOnTopbottomToolStripMenuItem";
            this.onlineMovieThinBarsOnTopbottomToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.onlineMovieThinBarsOnTopbottomToolStripMenuItem.Text = "Online Movie - Thin bars on top && bottom";
            this.onlineMovieThinBarsOnTopbottomToolStripMenuItem.Click += new System.EventHandler(this.onlineMovieThinBarsOnTopbottomToolStripMenuItem_Click);
            // 
            // dVideoSideBySideToolStripMenuItem
            // 
            this.dVideoSideBySideToolStripMenuItem.Name = "dVideoSideBySideToolStripMenuItem";
            this.dVideoSideBySideToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.dVideoSideBySideToolStripMenuItem.Text = "3D Video (Side By Side)";
            this.dVideoSideBySideToolStripMenuItem.Click += new System.EventHandler(this.dVideoSideBySideToolStripMenuItem_Click);
            // 
            // dualMonitorSideBySideToolStripMenuItem
            // 
            this.dualMonitorSideBySideToolStripMenuItem.Name = "dualMonitorSideBySideToolStripMenuItem";
            this.dualMonitorSideBySideToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.dualMonitorSideBySideToolStripMenuItem.Text = "Dual Monitor (Side By Side)";
            this.dualMonitorSideBySideToolStripMenuItem.Click += new System.EventHandler(this.dualMonitorSideBySideToolStripMenuItem_Click);
            // 
            // ModeToolStripMenuItem
            // 
            this.ModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultToolStripMenuItem,
            this.colorSelectToolStripMenuItem,
            this.sleepToolStripMenuItem,
            this.audioToolStripMenuItem});
            this.ModeToolStripMenuItem.Name = "ModeToolStripMenuItem";
            this.ModeToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.ModeToolStripMenuItem.Text = "Modes";
            // 
            // defaultToolStripMenuItem
            // 
            this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            this.defaultToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.defaultToolStripMenuItem.Text = "Default";
            this.defaultToolStripMenuItem.Click += new System.EventHandler(this.defaultToolStripMenuItem_Click);
            // 
            // colorSelectToolStripMenuItem
            // 
            this.colorSelectToolStripMenuItem.Name = "colorSelectToolStripMenuItem";
            this.colorSelectToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.colorSelectToolStripMenuItem.Text = "Color Select";
            this.colorSelectToolStripMenuItem.Click += new System.EventHandler(this.colorSelectToolStripMenuItem_Click);
            // 
            // sleepToolStripMenuItem
            // 
            this.sleepToolStripMenuItem.Name = "sleepToolStripMenuItem";
            this.sleepToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.sleepToolStripMenuItem.Text = "Sleep";
            this.sleepToolStripMenuItem.Click += new System.EventHandler(this.sleepToolStripMenuItem_Click);
            // 
            // audioToolStripMenuItem
            // 
            this.audioToolStripMenuItem.Enabled = false;
            this.audioToolStripMenuItem.Name = "audioToolStripMenuItem";
            this.audioToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.audioToolStripMenuItem.Text = "Audio";
            this.audioToolStripMenuItem.Click += new System.EventHandler(this.audioToolStripMenuItem_Click);
            // 
            // pseudoFullScreenToolStripMenuItem
            // 
            this.pseudoFullScreenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem9});
            this.pseudoFullScreenToolStripMenuItem.Name = "pseudoFullScreenToolStripMenuItem";
            this.pseudoFullScreenToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.pseudoFullScreenToolStripMenuItem.Text = "Pseudo Full Screen";
            this.pseudoFullScreenToolStripMenuItem.DropDownOpened += new System.EventHandler(this.pseudoFullScreenToolStripMenuItem_DropDownOpened);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(185, 22);
            this.toolStripMenuItem9.Text = "-- Active Windows --";
            // 
            // showSettingsToolStripMenuItem
            // 
            this.showSettingsToolStripMenuItem.Name = "showSettingsToolStripMenuItem";
            this.showSettingsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.showSettingsToolStripMenuItem.Text = "Settings";
            this.showSettingsToolStripMenuItem.Click += new System.EventHandler(this.showSettingsToolStripMenuItem_Click);
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
            this.tabPage4.Controls.Add(this.textBox5);
            this.tabPage4.Controls.Add(this.DelayLabel);
            this.tabPage4.Controls.Add(this.DelayBar);
            this.tabPage4.Controls.Add(this.button2);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.ComPortCombo);
            this.tabPage4.Controls.Add(this.TransmitTimeLabel);
            this.tabPage4.Controls.Add(this.ProcessTimeLabel);
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
            // DelayLabel
            // 
            this.DelayLabel.AutoSize = true;
            this.DelayLabel.Location = new System.Drawing.Point(76, 190);
            this.DelayLabel.Name = "DelayLabel";
            this.DelayLabel.Size = new System.Drawing.Size(56, 13);
            this.DelayLabel.TabIndex = 13;
            this.DelayLabel.Text = "Delay:1ms";
            // 
            // DelayBar
            // 
            this.DelayBar.Location = new System.Drawing.Point(11, 206);
            this.DelayBar.Maximum = 100;
            this.DelayBar.Minimum = 1;
            this.DelayBar.Name = "DelayBar";
            this.DelayBar.Size = new System.Drawing.Size(191, 45);
            this.DelayBar.TabIndex = 12;
            this.DelayBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.DelayBar.Value = 1;
            this.DelayBar.Scroll += new System.EventHandler(this.DelayBar_Scroll);
            this.DelayBar.ValueChanged += new System.EventHandler(this.DelayBar_ValueChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(11, 138);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(191, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Open Config.ini file";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Port";
            // 
            // ComPortCombo
            // 
            this.ComPortCombo.FormattingEnabled = true;
            this.ComPortCombo.Location = new System.Drawing.Point(40, 10);
            this.ComPortCombo.Name = "ComPortCombo";
            this.ComPortCombo.Size = new System.Drawing.Size(93, 21);
            this.ComPortCombo.TabIndex = 9;
            this.ComPortCombo.SelectedIndexChanged += new System.EventHandler(this.ComPortCombo_SelectedIndexChanged);
            // 
            // TransmitTimeLabel
            // 
            this.TransmitTimeLabel.AutoSize = true;
            this.TransmitTimeLabel.Location = new System.Drawing.Point(8, 104);
            this.TransmitTimeLabel.Name = "TransmitTimeLabel";
            this.TransmitTimeLabel.Size = new System.Drawing.Size(98, 13);
            this.TransmitTimeLabel.TabIndex = 7;
            this.TransmitTimeLabel.Text = "Transmit Time: 0ms";
            // 
            // ProcessTimeLabel
            // 
            this.ProcessTimeLabel.AutoSize = true;
            this.ProcessTimeLabel.Location = new System.Drawing.Point(8, 91);
            this.ProcessTimeLabel.Name = "ProcessTimeLabel";
            this.ProcessTimeLabel.Size = new System.Drawing.Size(96, 13);
            this.ProcessTimeLabel.TabIndex = 6;
            this.ProcessTimeLabel.Text = "Process Time: 0ms";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(11, 60);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(133, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Black Stripe Elliminator";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // RunOnStartup
            // 
            this.RunOnStartup.AutoSize = true;
            this.RunOnStartup.Location = new System.Drawing.Point(11, 37);
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
            this.buttonSave.Size = new System.Drawing.Size(62, 47);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click_1);
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
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.panel7.BackColor = System.Drawing.Color.LimeGreen;
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
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.panel6.BackColor = System.Drawing.Color.LimeGreen;
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
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.panel5.BackColor = System.Drawing.Color.LimeGreen;
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
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.panel4.BackColor = System.Drawing.Color.LimeGreen;
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
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 8);
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
            this.panel3.BackColor = System.Drawing.Color.LimeGreen;
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 8);
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
            this.pictureBox1.Location = new System.Drawing.Point(75, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(552, 389);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Aero_CheckBox);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.processList);
            this.tabPage2.Controls.Add(this.MonitorSleepButton);
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
            // Aero_CheckBox
            // 
            this.Aero_CheckBox.AutoSize = true;
            this.Aero_CheckBox.Location = new System.Drawing.Point(214, 38);
            this.Aero_CheckBox.Name = "Aero_CheckBox";
            this.Aero_CheckBox.Size = new System.Drawing.Size(85, 17);
            this.Aero_CheckBox.TabIndex = 22;
            this.Aero_CheckBox.Text = "Aero_Check";
            this.Aero_CheckBox.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(12, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(450, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "*This tab is experimental features only. Users, please don\'t try this features, t" +
    "hey are not stable.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Process List for Pseudo Full Screen";
            // 
            // processList
            // 
            this.processList.FormattingEnabled = true;
            this.processList.Location = new System.Drawing.Point(15, 90);
            this.processList.Name = "processList";
            this.processList.Size = new System.Drawing.Size(173, 95);
            this.processList.TabIndex = 19;
            // 
            // MonitorSleepButton
            // 
            this.MonitorSleepButton.Location = new System.Drawing.Point(15, 33);
            this.MonitorSleepButton.Name = "MonitorSleepButton";
            this.MonitorSleepButton.Size = new System.Drawing.Size(110, 25);
            this.MonitorSleepButton.TabIndex = 18;
            this.MonitorSleepButton.Text = "Monitor Sleep";
            this.MonitorSleepButton.UseVisualStyleBackColor = true;
            this.MonitorSleepButton.Click += new System.EventHandler(this.MonitorSleepButton_Click);
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
            this.button1.Location = new System.Drawing.Point(15, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 24);
            this.button1.TabIndex = 16;
            this.button1.Text = "Display Count:";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ScreenPanel);
            this.panel1.Location = new System.Drawing.Point(17, 240);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(178, 138);
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
            this.tabPage3.Controls.Add(this.textBox4);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(709, 434);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "About";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox4.Location = new System.Drawing.Point(8, 315);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(692, 111);
            this.textBox4.TabIndex = 2;
            this.textBox4.Text = resources.GetString("textBox4.Text");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Location = new System.Drawing.Point(485, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(215, 274);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thanks to Kickstarter Backers";
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(13, 19);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(195, 249);
            this.textBox3.TabIndex = 1;
            this.textBox3.Text = resources.GetString("textBox3.Text");
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 274);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Developers";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(15, 21);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(230, 247);
            this.textBox2.TabIndex = 0;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            // 
            // StaticColorTimer
            // 
            this.StaticColorTimer.Interval = 500;
            this.StaticColorTimer.Tick += new System.EventHandler(this.StaticColorTimer_Tick);
            // 
            // textBox5
            // 
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Location = new System.Drawing.Point(254, 10);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(446, 286);
            this.textBox5.TabIndex = 14;
            this.textBox5.Text = resources.GetString("textBox5.Text");
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
            this.Text = "AmbiLED Driver v1.8 BETA";
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.MyContextMenuStrip.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DelayBar)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
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
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem ModeToolStripMenuItem;
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
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label ProcessTimeLabel;
        private System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sleepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem audioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorSelectToolStripMenuItem;
        private System.Windows.Forms.Timer StaticColorTimer;
        private System.Windows.Forms.Button MonitorSleepButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox processList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripMenuItem ratioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cinematic21x9ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hD16x9ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oLDTV4x3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onlineMovieThinBarsOnTopbottomToolStripMenuItem;
        private System.Windows.Forms.Label TransmitTimeLabel;
        private System.Windows.Forms.ComboBox ComPortCombo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripMenuItem dVideoSideBySideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dualMonitorSideBySideToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label DelayLabel;
        private System.Windows.Forms.TrackBar DelayBar;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.CheckBox Aero_CheckBox;
        private System.Windows.Forms.TextBox textBox5;

    }
}

