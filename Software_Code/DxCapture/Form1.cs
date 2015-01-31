using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Reflection;
using Ini;
using Microsoft.Win32;
using AmbiLED.WindowsApi;
using AmbiLED_HD;
using SharpUpdate;


namespace AmbiLED
{
    public partial class Form1 : Form, ISharpUpdatable
    {

        //----------MONITOR SLEEP DETECTION------------------- 
        Guid GUID_CONSOLE_DISPLAY_STATE = new Guid("6fe69556-704a-47a0-8f24-c28d936fda47");
        const int DEVICE_NOTIFY_WINDOW_HANDLE = 0x00000000;
        const int WM_SYSCOMMAND = 0x0112;
        const int WM_POWERBROADCAST = 0x218;
        const int SC_MONITORPOWER = 0xf170;
        const int PBT_POWERSETTINGCHANGE = 0x8013;
        //#region Win32 calls
        struct POWERBROADCAST_SETTING { public Guid PowerSetting; public UInt32 DataLength; public byte Data; }

        [DllImport(@"User32", SetLastError = true, EntryPoint = "RegisterPowerSettingNotification", CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr RegisterPowerSettingNotification(IntPtr hRecipient, ref Guid PowerSettingGuid, Int32 Flags);

        [DllImport("user32.dll")]
        private static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);

        [DllImport("user32.dll")]
        static extern int GetForegroundWindow();

       // #endregion
        //----------END - MONITOR SLEEP DETECTION-------------

        //------ AERO Enamble/Disbale ----------
        public readonly uint DWM_EC_DISABLECOMPOSITION = 0;
        public readonly uint DWM_EC_ENABLECOMPOSITION = 1;
        [DllImport("dwmapi.dll", EntryPoint = "DwmEnableComposition")]
        protected extern static uint Win32DwmEnableComposition(uint uCompositionAction);
        //------ END - AERO Enamble/Disbale ----------
        


        ///     list of useless processes
        private readonly string[] processBlacklist = { "explorer", "AmbiLED_HD", "chrome","devenv", "IW4 Console", "XSplit" };
        ///     list of currently running processes
        private List<string> processCache = new List<string>();

        private SharpUpdater updater;

        public Color ColorSetValue { get; set; }

        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        struct LEDPoint
        {
            public int x, y;
        }


        //----------PSEUDO FULL SCREEN DLLs----------------------------
        //Gets window rect
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT Rect);
        
        //Move Window
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int Width, int Height, bool Repaint);

        //Sets window attributes
        [DllImport("USER32.DLL")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        //Gets window attributes
        [DllImport("USER32.DLL")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        
        public static int GWL_STYLE = -16;
        public static int WS_CHILD = 0x40000000; //child window
        public static int WS_BORDER = 0x00800000; //window with border
        public static int WS_DLGFRAME = 0x00400000; //window with double border but no title
        public static int WS_CAPTION = 0x00C00000; //window with a title bar
        private const int WS_SIZEBOX = 0x040000;
        private const int WS_EX_DLGMODALFRAME = 0x00000001;
        //-------------------------------------------------------

        KeyboardHook hook = new KeyboardHook();
        KeyboardHook hook_Pseudo_FullScreen = new KeyboardHook();

        /*
        //------ HOT KEY DLLs------------------------------------
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }
        //-------------------------------------------------------    

        //--------GET Focused Window Handle-----------------------------
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        //-------------------------------------------------------
        */

        //------ GLOBAL VARIABLES------------------------------------
        byte[] COM_Tx_Buffer = new byte[2000];
        byte[] StaticColorBuffer = new byte[2000];

        float POWER_LEVEL = (float)0.3;
        int Refresh_Interval = 100;
        int Power_Level = 30;
        string SerialPortName = "COM0";

        Boolean Monitor_Sleeping = false;
        Boolean Black_Stripe_Eliminator = false;
        Boolean Black_Stripe_Detected = false;
        int Black_Stripe_Threshold = 30;
        int BSD_i = 0;
        int BSD_width = 0;

        int FRAME_LED_LEFT = 10;
        int FRAME_LED_TOP = 10;
        int FRAME_LED_RIGHT = 10;
        int FRAME_LED_BOTTOM_LEFT = 5;
        int FRAME_LED_BOTTOM_RIGHT = 5;
        int FRAME_LED_GAP = 0;
        int TOTAL_LED_COUNT = 40;

        int HOTKEY_PSEUDO_FULL_SCREEN = 122;
        int HOTKEY_SET_RATIO = 123;


        int Monitor_Width = 300; 
        int Monitor_Height = 200;

        string IniFilePath;

        Boolean inverted_strip = false;

        //-------------------------------------------------------

        /*
        byte[] RedRamp = new byte[256];
        byte[] GreenRamp = new byte[256];
        byte[] BlueRamp = new byte[256];

        byte[] GammaE = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2,
2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5,
6, 6, 6, 7, 7, 7, 8, 8, 8, 9, 9, 9, 10, 10, 11, 11,
11, 12, 12, 13, 13, 13, 14, 14, 15, 15, 16, 16, 17, 17, 18, 18,
19, 19, 20, 21, 21, 22, 22, 23, 23, 24, 25, 25, 26, 27, 27, 28,
29, 29, 30, 31, 31, 32, 33, 34, 34, 35, 36, 37, 37, 38, 39, 40,
40, 41, 42, 43, 44, 45, 46, 46, 47, 48, 49, 50, 51, 52, 53, 54,
55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70,
71, 72, 73, 74, 76, 77, 78, 79, 80, 81, 83, 84, 85, 86, 88, 89,
90, 91, 93, 94, 95, 96, 98, 99,100,102,103,104,106,107,109,110,
111,113,114,116,117,119,120,121,123,124,126,128,129,131,132,134,
135,137,138,140,142,143,145,146,148,150,151,153,155,157,158,160,
162,163,165,167,169,170,172,174,176,178,179,181,183,185,187,189,
191,193,194,196,198,200,202,204,206,208,210,212,214,216,218,220,
222,224,227,229,231,233,235,237,239,241,244,246,248,250,252,255};
        */
        //DxScreenCapture sc = new DxScreenCapture();


        Collection<Point> stripPos = new Collection<Point>();
        Collection<int> Black_Stripe_Pos = new Collection<int>();
        Collection<System.Drawing.Color> stripColor = new Collection<System.Drawing.Color>();

        const int Bpp = 4;

        public Form1()
        {
          try
            {
            InitializeComponent();
            IniFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AmbiLED\\config.ini");
            Read_Ini_File();
            Set_LED_Positions();

            this.Text = "AmbiLED Driver v" + this.ApplicationAssembly.GetName().Version.ToString() + " BETA";
            updater = new SharpUpdater(this);

            
            }
         catch (Exception ex)
            {
                //MessageBox.Show("Whoops! We have a problem!\n\n" + ex.ToString());
            }
        }

        #region SharpUpdate
        public string ApplicationName
        {
            get { return "AmbiLED"; }
        }

        public string ApplicationID
        {
            get { return "AmbiLED"; }
        }

        public Assembly ApplicationAssembly
        {
            get { return Assembly.GetExecutingAssembly(); }
        }

        public Icon ApplicationIcon
        {
            get { return this.Icon; }
        }

        public Uri UpdateXmlLocation
        {
            get { return new Uri("http://www.ambiledhd.com/update.xml"); }
        }

        public Form Context
        {
            get { return this; }
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
                {
                    //AppLog.Write("Application XXXX already running. Only one instance of this application is allowed", AppLog.LogMessageType.Warn);
                    Environment.Exit(1);
                    serialPort1.Close();
                    Application.Exit();
                }

                // register the event that is fired after the key press.
                hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
                // register the control + alt + F12 combination as hot key.
                hook.RegisterHotKey(AmbiLED_HD.ModifierKeys.Control | AmbiLED_HD.ModifierKeys.Alt, (Keys)HOTKEY_SET_RATIO);
                   
                hook.RegisterHotKey(AmbiLED_HD.ModifierKeys.Control | AmbiLED_HD.ModifierKeys.Alt, (Keys)HOTKEY_PSEUDO_FULL_SCREEN);

                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (rk.GetValue("AmbiLED") != null) RunOnStartup.Checked = true;

                // Notify icon set up
                MyNotifyIcon.Visible = true;
                //MyNotifyIcon.Text = "Tooltip message here";
                this.ShowInTaskbar = false;
                this.Hide();


                // Get a list of serial port names. 
                string[] ports = SerialPort.GetPortNames();
                ComPortCombo.Items.Clear();

                // Display each port name to the console. 
                foreach (string port in ports)
                {
                    ComPortCombo.Items.Add(port);
                }


                RegisterPowerSettingNotification(this.Handle, ref GUID_CONSOLE_DISPLAY_STATE, DEVICE_NOTIFY_WINDOW_HANDLE); // MONITOR SLEEP DETECTION 


                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        // MONITOR SLEEP DETECTION 
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_POWERBROADCAST && m.WParam.ToInt32() == PBT_POWERSETTINGCHANGE)
            {
                POWERBROADCAST_SETTING ps = (POWERBROADCAST_SETTING)Marshal.PtrToStructure(m.LParam, typeof(POWERBROADCAST_SETTING));

                try
                {

                    switch (ps.Data)
                    {
                        // defined at http://msdn.microsoft.com/en-us/library/windows/desktop/hh448380(v=vs.85).aspx
                        case 0:
                            Monitor_Sleeping = true;
                            break;
                        case 1:
                            Monitor_Sleeping = false;
                            break;
                    }
                }
                catch
                {
                    // failed to communicate
                    // For now, just ignore. Might be nice to retry in the future.
                }


            }

            base.WndProc(ref m);

            
        }
        // END-MONITOR SLEEP DETECTION 

        System.Drawing.Color avcs(byte[] gs, Collection<long> positions)
        {
            byte[] bu = new byte[4];
            int r = 0;
            int g = 0;
            int b = 0;
            int i = 0;

            

            foreach (long pos in positions)
            {
                //gs.Position = pos;
                //gs.Read(bu, 0, 4);
                r += bu[2];
                g += bu[1];
                b += bu[0];
                i++;

                
            }

            return System.Drawing.Color.FromArgb(r / i, g / i, b / i);
        }

        void Read_Ini_File()
        {
            IniFile ini = new IniFile(IniFilePath);


            FRAME_LED_LEFT = ini.IniReadInt("MAIN", "FRAME_LED_LEFT");
            FRAME_LED_TOP = ini.IniReadInt("MAIN", "FRAME_LED_TOP");
            FRAME_LED_RIGHT = ini.IniReadInt("MAIN", "FRAME_LED_RIGHT");
            FRAME_LED_BOTTOM_LEFT = ini.IniReadInt("MAIN", "FRAME_LED_BOTTOM_LEFT");
            FRAME_LED_BOTTOM_RIGHT = ini.IniReadInt("MAIN", "FRAME_LED_BOTTOM_RIGHT");
            FRAME_LED_GAP = ini.IniReadInt("MAIN", "FRAME_LED_GAP");

            HOTKEY_PSEUDO_FULL_SCREEN = ini.IniReadInt("MAIN", "HOTKEY_PSEUDO_FULL_SCREEN");
            HOTKEY_SET_RATIO = ini.IniReadInt("MAIN", "HOTKEY_SET_RATIO");


            TOTAL_LED_COUNT = FRAME_LED_LEFT + FRAME_LED_TOP + FRAME_LED_RIGHT + FRAME_LED_BOTTOM_LEFT + FRAME_LED_BOTTOM_RIGHT;


            UpDown_Left.Value = FRAME_LED_LEFT;
            UpDown_Top.Value = FRAME_LED_TOP;
            UpDown_Right.Value = FRAME_LED_RIGHT;
            UpDown_BottomLeft.Value = FRAME_LED_BOTTOM_LEFT;
            UpDown_BottomRight.Value = FRAME_LED_BOTTOM_RIGHT;
            UpDown_Gap.Value = FRAME_LED_GAP;




            Refresh_Interval = ini.IniReadInt("MAIN", "Refresh_Interval");
            Power_Level =  ini.IniReadInt("MAIN", "Power_Level");
            SerialPortName = ini.IniReadValue("MAIN", "PortName");

            if (ini.IniReadValue("MAIN", "STRIP_DIRECTION") != "COUNTERCLOCKWISE") inverted_strip = true; //Special for Clockwise strip installations.

            DelayBar.Value = Refresh_Interval;
            
            if (SerialPortName == "COM0") // If com port didnt set
                {
                // Get a list of serial port names. 
                string[] ports = SerialPort.GetPortNames();

                // Display each port name to the console. 
                foreach (string port in ports)
                    {
                        try
                        {   //TEST com port
                            serialPort1.PortName = port;
                            serialPort1.Open();
                            serialPort1.Close();
                            SerialPortName = port; //Set if it's working. 
                        }
                        catch
                        {
                        }

                    }
                }

            if (SerialPortName != "COM0")
                {
                serialPort1.PortName = SerialPortName;
                serialPort1.BaudRate = 115200;

                serialPort1.Open();
                serialPort1.Encoding = System.Text.Encoding.UTF8;
                ComPortCombo.Text = SerialPortName;
                }

            CaptureTimer.Interval = Refresh_Interval;
            
            POWER_LEVEL = (float)Power_Level / 100;

            mode_select(1);

        }


        void Set_LED_Positions(int Left_Right_Space = 8, int Up_Down_Space = 8, string Monitor_Mode = "2D")
        {
            int o = 2;// ((Screen.PrimaryScreen.Bounds.Width + Screen.PrimaryScreen.Bounds.Height) * 2) / (led_adet * 10);
            //int m = 8;
            int Screen_Width =  Screen.PrimaryScreen.Bounds.Width; //SystemInformation.VirtualScreen.Width; 
            int Screen_Height = Screen.PrimaryScreen.Bounds.Height; //SystemInformation.VirtualScreen.Height; 

            switch (Monitor_Mode) // monitor modes
            {
                case "2D": Screen_Width = Screen_Width ; break; //default
                case "3D": Screen_Width = Screen_Width / 2; break; //side by side 3D
                case "DUAL": Screen_Width = Screen_Width * 2; break; //Dual monitor
            }
            Monitor_Width = Screen_Width;
            Monitor_Height = Screen_Height;

            
            int sx = Screen_Width - Left_Right_Space;
            int sy = Screen_Height - Up_Down_Space;


            float ekran_orani = (float)Screen_Width / Screen_Height;

            ScreenPanel.Height = (int)(100 / ekran_orani);
            ScreenPanel.Width = 100;

            int x, y;
            Point pos = new Point { X = 0, Y = 0 };
            stripPos.Clear();
            Black_Stripe_Pos.Clear();


            int bottom_right_length = (int)((Screen_Width-(2*Left_Right_Space))* (((float)FRAME_LED_BOTTOM_RIGHT / (float)(FRAME_LED_BOTTOM_LEFT + FRAME_LED_GAP + FRAME_LED_BOTTOM_RIGHT))));
            y = sy;//Right Bottom to Left Bottom
            for (x = bottom_right_length+1; x > 1; x -= o)
            {
                pos.X = x;
                pos.Y = y;
                stripPos.Add(pos);
                Black_Stripe_Pos.Add(stripPos.Count-1); //black strip pixels
            }

            x = Left_Right_Space;//Left Bottom to Left Top
            for (y = Screen_Height - 1; y >  1; y -= o)
            {
                pos.X = x;
                pos.Y = y;
                stripPos.Add(pos);

            }

            y = Up_Down_Space; //Left Top to Right Top
            for (x = 1; x < Screen_Width-1; x += o)
            {
                pos.X = x;
                pos.Y = y;
                stripPos.Add(pos);
                Black_Stripe_Pos.Add(stripPos.Count - 1);
            }

            x = sx; //Right Top to Right Bottom
            for (y = 1; y < Screen_Height - 1; y += o)
            {
                pos.X = x;
                pos.Y = y;
                stripPos.Add(pos);
            }

            int bottom_left_length = (int)((Screen_Width - (2 * Left_Right_Space)) * (((float)FRAME_LED_BOTTOM_LEFT / (float)(FRAME_LED_BOTTOM_LEFT + FRAME_LED_GAP + FRAME_LED_BOTTOM_RIGHT))));
            y = sy;//Right Bottom to LEft Bottom
            for (x = Screen_Width - 1; x > Screen_Width - bottom_left_length; x -= o)
            {
                pos.X = x;
                pos.Y = y;
                stripPos.Add(pos);
                Black_Stripe_Pos.Add(stripPos.Count - 1);
            }


        
        }

        void SET_Ratio(int Xratio, int Yratio, string Monitor_Mode = "2D")
        {

            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;

            int h2 = (w * Yratio) / Xratio; // display ratio difference calculation
            int w2 = (h * Xratio) / Yratio; // display ratio difference calculation 

            int blank_space = 0;
            int blank_space2 = 0;

            if ((h - h2) >= 0)
                blank_space = (h - h2) / 2;
            else
                blank_space2 = (w - w2) / 2;

            Set_LED_Positions(blank_space2 + 8, blank_space + 8, Monitor_Mode); //Set the blank spaces
        }

        void Calculate()
        {


            Rectangle bounds = new Rectangle(0, 0, Monitor_Width, Monitor_Height);
           

            Point[] stripPos_array = new Point[stripPos.Count] ;
            stripPos.CopyTo(stripPos_array,0);

            byte[] LEDarray = new Byte[stripPos.Count*3];
            LEDarray = ScreenShot.CaptureImage(bounds, stripPos_array);


            // BLACK STRIPE ELIMINATOR 
            if (Black_Stripe_Eliminator)
            {

                BSD_i++;
                if (BSD_i >20) 
                    {
                    Black_Stripe_Detected = true;
                    BSD_i = 0;
                    }


                for (int i = 0; i < Black_Stripe_Pos.Count; i++)
                {
                    if ((LEDarray[3 * Black_Stripe_Pos[i] + 0] + LEDarray[3 * Black_Stripe_Pos[i] + 1] + LEDarray[3 * Black_Stripe_Pos[i] + 2]) > Black_Stripe_Threshold)
                    {
                        Black_Stripe_Detected = false;
                        BSD_i = 1;
                    }
                }

                if (Black_Stripe_Detected)
                {
                    Console.Beep();
                    Black_Stripe_Detected = false;
                    BSD_width += 5; // increase the stripe +5 pixel
                    Set_LED_Positions(8, BSD_width + 8, "2D");
                    return;
                }                  

            }
            // END of BLACK STRIPE ELIMINATOR 


            int r = 0;
            int g = 0;
            int b = 0;
            //int i = 0;

            float led_oran = (float)stripPos.Count() / TOTAL_LED_COUNT;// +1;
            int Tx_Buffer_ID = 0;

            for (int i = 0; i < LEDarray.Length ;i+=3 )
            {
                r += LEDarray[i+0];
                g += LEDarray[i+1];
                b += LEDarray[i+2];

                
                
                if ((i/3) % led_oran >= led_oran-1)
                {



                    r = (int)(r / led_oran);
                    g = (int)(g / led_oran);
                    b = (int)(b / led_oran);

                    //r = (int)(r * POWER_LEVEL * 0.9);
                    //g = (int)(g * POWER_LEVEL * 1.0);
                    //b = (int)(b * POWER_LEVEL * 0.85);

                    r = (int)(r * POWER_LEVEL * 1.0);
                    g = (int)(g * POWER_LEVEL * 1.0);
                    b = (int)(b * POWER_LEVEL * 1.0);

                    if (r > 250) r = 250;
                    if (g > 250) g = 250;
                    if (b > 250) b = 250;

                    //stripColor[Tx_Buffer_ID] = Color.FromArgb(r , g , b );
                    COM_Tx_Buffer[(Tx_Buffer_ID * 3) + 1] = (byte)(r); //GammaE[(byte)(r)]; //RedRamp[(byte)(r)];// gamma8[(byte)(r)];
                    COM_Tx_Buffer[(Tx_Buffer_ID * 3) + 2] = (byte)(g); //GammaE[(byte)(g)];//GreenRamp[(byte)(g)];// gamma8[(byte)(g)];
                    COM_Tx_Buffer[(Tx_Buffer_ID * 3) + 3] = (byte)(b); // GammaE[(byte)(b)];//BlueRamp[(byte)(b)];// gamma8[(byte)(b)];
                    r = 0;
                    g = 0;
                    b = 0;

                    Tx_Buffer_ID++;
                }

            }

        }
            
        private void mode_select(int mode_number)
        {
            defaultToolStripMenuItem.Checked = false;
            sleepToolStripMenuItem.Checked = false;
            audioToolStripMenuItem.Checked = false;
            colorSelectToolStripMenuItem.Checked = false;

            switch (mode_number)
            {
                case 1:
                    CaptureTimer.Enabled = true;
                    StaticColorTimer.Enabled = false;
                    defaultToolStripMenuItem.Checked = true;
                    break;
                case 2:
                    CaptureTimer.Enabled = false;
                    StaticColorTimer.Enabled = false;
                    sleepToolStripMenuItem.Checked = true;
                    break;
                case 3:
                    CaptureTimer.Enabled = false;
                    StaticColorTimer.Enabled = false;
                    //AUDIO CODE
                    audioToolStripMenuItem.Checked = true;
                    break;
                case 4:
                    CaptureTimer.Enabled = false;
                    StaticColorTimer.Enabled = true;
                    colorSelectToolStripMenuItem.Checked = true;
                    /* ---- OLD Code ----
                    ColorDialog colorDialog1 = new ColorDialog();
                    colorDialog1.AllowFullOpen = true;
                    colorDialog1.FullOpen = true;
                    colorDialog1.AnyColor = true;
                    colorDialog1.SolidColorOnly = true;

                    if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        byte R = (byte)colorDialog1.Color.R;
                        byte G = (byte)colorDialog1.Color.G ;
                        byte B = (byte)colorDialog1.Color.B;
                        //if (R > 250) R = 250;
                        //if (G > 250) G = 250;
                        //if (B > 250) B = 250;


                        for (int i = 0; i < 512; i++)
                        {
                            COM_Tx_Buffer[(i * 3) + 1] = (byte)(R >> 1);
                            COM_Tx_Buffer[(i * 3) + 2] = (byte)(G >> 1);
                            COM_Tx_Buffer[(i * 3) + 3] = (byte)(B >> 1);
                        }
                        COM_Tx_Buffer[512 * 3] = (byte)255; //SHOW 
                        StaticColorBuffer = COM_Tx_Buffer;
                        if ((SerialPortName != "COM0") && (Monitor_Sleeping == false))
                            serialPort1.Write(COM_Tx_Buffer, 0, (512 * 3) + 3);
                    }
                     */
                    break;
                default:
                    
                    break;
            }

        }

        /// <summary>
        ///     Updates the list of processes
        /// </summary>
        private void UpdateProcessList()
        {
            // update processCache
            var processes = Process.GetProcesses().Where(process => !processBlacklist.Contains(process.ProcessName));

            // prune closed processes
            for (var i = processList.Items.Count - 1; i > 0; i--)
            {
                var process = processList.Items[i] as string;
                if (!processes.Any(p => p.ProcessName == process))
                {
                    processList.Items.RemoveAt(i);
                    processCache.Remove(process);
                    (pseudoFullScreenToolStripMenuItem as ToolStripMenuItem).DropDownItems.RemoveAt(i);
                }
            }

            // add new processes
            foreach (var process in processes)
            {
                if (!processList.Items.Contains(process.ProcessName))
                {
                    if (process.MainWindowHandle != IntPtr.Zero)
                    {
                        processList.Items.Add(process.ProcessName);
                        processCache.Add(process.ProcessName);
                        (pseudoFullScreenToolStripMenuItem as ToolStripMenuItem).DropDownItems.Add(process.ProcessName,null, new EventHandler(pseudoFullScreenToolStripMenuItem_Click));
                    }

                    // getting MainWindowHandle is 'heavy' -> pause a bit to spread the load
                    Thread.Sleep(10);
                }
            }
        }

        ///    KEYBOARD SHORTCUT CTRL+ALT+F12
         void hook_KeyPressed(object sender, KeyPressedEventArgs e)
            {
                if ((int)e.Key == HOTKEY_SET_RATIO) Set_LED_Positions(Cursor.Position.X + 5, Cursor.Position.Y + 5); //Set the blank spaces// F12 Key
                if ((int)e.Key == HOTKEY_PSEUDO_FULL_SCREEN) RemoveBorder((IntPtr)GetForegroundWindow()); //Set current window as full screen //  F11 Key,
            }


        
        ///     Gets the WindowHandle for the given Process
        private IntPtr FindWindowHandle(string processName)
        {
            var process = Process.GetProcessesByName(processName).FirstOrDefault(p => p.MainWindowHandle != IntPtr.Zero);
            return process != null ? process.MainWindowHandle : IntPtr.Zero;
        }
        /// <summary>
        ///     remove the menu, resize the window, remove border
        /// </summary>
        private void RemoveBorder(string procName)
        {
            
            var targetHandle = FindWindowHandle(procName);
            if (targetHandle == IntPtr.Zero) return;

            RemoveBorder(targetHandle);
        }

        /// <summary>
        ///     remove the menu, resize the window, remove border
        /// </summary>
        private bool RemoveBorder(IntPtr hWnd)
        {
            var targetScreen = Screen.FromHandle(hWnd);
            return RemoveBorderRect(hWnd, targetScreen.Bounds);
        }

        /// <summary>
        ///     remove the menu, resize the window, remove border
        /// </summary>
        private bool RemoveBorderRect(IntPtr targetHandle, System.Drawing.Rectangle targetFrame)
        {
            // check windowstyles
            var windowStyle = Native.GetWindowLong(targetHandle, WindowLongIndex.Style);

            var newWindowStyle = (windowStyle
                                  & ~(WindowStyleFlags.ExtendedDlgmodalframe | WindowStyleFlags.Caption
                                      | WindowStyleFlags.ThickFrame | WindowStyleFlags.Minimize
                                      | WindowStyleFlags.Maximize | WindowStyleFlags.SystemMenu
                                      | WindowStyleFlags.MaximizeBox | WindowStyleFlags.MinimizeBox
                                      | WindowStyleFlags.Border | WindowStyleFlags.ExtendedComposited));

            // if the windowstyles differ this window hasn't been made borderless yet
            if (windowStyle != newWindowStyle)
            {
                // remove the menu and menuitems and force a redraw
                var menuHandle = Native.GetMenu(targetHandle);
                var menuItemCount = Native.GetMenuItemCount(menuHandle);

                for (var i = 0; i < menuItemCount; i++)
                {
                    Native.RemoveMenu(menuHandle, 0, MenuFlags.ByPosition | MenuFlags.Remove);
                }

                Native.DrawMenuBar(targetHandle);

                // update windowstyle & position
                Native.SetWindowLong(targetHandle, WindowLongIndex.Style, newWindowStyle);
                Native.SetWindowPos(
                    targetHandle,
                    0,
                    targetFrame.X,
                    targetFrame.Y,
                    targetFrame.Width,
                    targetFrame.Height,
                    SetWindowPosFlags.ShowWindow | SetWindowPosFlags.NoOwnerZOrder);
                return true;
            }

            return false;
        }
        /// <summary>
        /// End of Pseudo Full Screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        /// Power Set
        /// 

        private void Set_Power_Level(float lvl)
        {
            POWER_LEVEL = lvl;
            // connect to INI file
            IniFile ini = new IniFile(IniFilePath);
            ini.IniWriteValue("MAIN", "Power_Level", (lvl * 100).ToString());
        }
        /// END POWER SET
        /// 

        public bool ControlAero(bool enable)
        {
            try
            {
                if (enable)
                    Win32DwmEnableComposition(DWM_EC_ENABLECOMPOSITION);
                if (!enable)
                    Win32DwmEnableComposition(DWM_EC_DISABLECOMPOSITION);

                return true;
            }
            catch { return false; }
        }

//------------------------------------------------------------------
//------------------------------------------------------------------
//----------------------END OF FUNCTIONS  --------------------------
//------------------------------------------------------------------
//------------------------------------------------------------------



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true; // this cancels the close event.
           
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                MyNotifyIcon.Visible = true;
                MyNotifyIcon.ShowBalloonTip(3000);
                this.ShowInTaskbar = false;
            }
        }



        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult d = MessageBox.Show("Are you sure you want to close AmbiLED HD?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == DialogResult.Yes)
            {
                hook.Dispose();// Unregister hotkey 
                MyNotifyIcon.Visible = false;
                Environment.Exit(1);
                serialPort1.Close();
                Application.Exit();
            }
 
        }

        private void showSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.Focus();
            this.WindowState = FormWindowState.Normal;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            
            
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Set_Power_Level((float)0.1);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Set_Power_Level((float)0.15);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Set_Power_Level((float)0.2);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Set_Power_Level((float)0.25);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Set_Power_Level((float)0.3);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Set_Power_Level((float)0.4);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Set_Power_Level((float)0.5);
        }
        
        private void Form1_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
        }




        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            Gap_Textbox.Text = UpDown_Gap.Value.ToString();
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            BottomRight_Textbox.Text = UpDown_BottomRight.Value.ToString();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            Right_Textbox.Text = UpDown_Right.Value.ToString();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Top_Textbox.Text = UpDown_Top.Value.ToString();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            Left_Textbox.Text = UpDown_Left.Value.ToString();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
           BottomLeft_Textbox.Text = UpDown_BottomLeft.Value.ToString();
        }

        private Process GetaProcess(string processname)
        {
            Process[] aProc = Process.GetProcessesByName(processname);

            if (aProc.Length > 0)
                return aProc[0];

            else return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Screen[] screendata = Screen.AllScreens;
            button1.Text = "Display Count: " + screendata.Length.ToString();

        }

        private void RunOnStartup_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (RunOnStartup.Checked == true)
            {
                rk.SetValue("AmbiLED", Application.ExecutablePath.ToString());
            }
            else
            {
                rk.DeleteValue("AmbiLED", false);
            }
        }

        private void pseudoFullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Warning, " + ((ToolStripMenuItem)sender).Text + " application will be stretched to full screen.\n" +
            "All windows based, borders and application control buttons will be dissappear for current session.\nYou can close this application "+
                "from it's own menu or simply press ALT+F4 keys to close it.\nTo switching between windows applications press ALT+TAB keys.\n\nDo you want to continue? ",
                "Pseudo Full Screen Alert",
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                RemoveBorder(((ToolStripMenuItem)sender).Text);
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
            
        }



        private void UpDown_BottomRight_ValueChanged(object sender, EventArgs e)
        {
            BottomRight_Textbox.Text = UpDown_BottomRight.Value.ToString();
        }

        private void UpDown_Right_ValueChanged(object sender, EventArgs e)
        {
            Right_Textbox.Text = UpDown_Right.Value.ToString();
        }

        private void UpDown_Top_ValueChanged(object sender, EventArgs e)
        {
            Top_Textbox.Text = UpDown_Top.Value.ToString();
        }

        private void UpDown_Left_ValueChanged(object sender, EventArgs e)
        {
            Left_Textbox.Text = UpDown_Left.Value.ToString();
        }

        private void UpDown_BottomLeft_ValueChanged(object sender, EventArgs e)
        {
            BottomLeft_Textbox.Text = UpDown_BottomLeft.Value.ToString();
        }

        private void UpDown_Gap_ValueChanged(object sender, EventArgs e)
        {
            Gap_Textbox.Text = UpDown_Gap.Value.ToString();
        }

        private void CaptureTimer_Tick(object sender, EventArgs e)
        {
            CaptureTimer.Enabled = false; //timer disable to avoid from conflict
            
            Stopwatch sw = new Stopwatch(); //Process timer set
            sw.Start();

            Calculate(); //Capture screen and calcualte the LED colors
            sw.Stop();
            ProcessTimeLabel.Text = "Capture Time" + sw.Elapsed.Milliseconds + "ms"; //Print process time
            
            sw.Reset();
            sw.Start();

            if (inverted_strip)
            {
                //INVERT DATA for CLOCKWISE STRIP DIRECTION
                byte[] Buf_COM_Tx_Buffer = new byte[2000];
                Array.Copy(COM_Tx_Buffer, Buf_COM_Tx_Buffer, 2000);
                for (int di = 0;di<TOTAL_LED_COUNT;di++)
                {
                    int byte_num = (di * 3);
                    COM_Tx_Buffer[byte_num + 1] = Buf_COM_Tx_Buffer[(TOTAL_LED_COUNT * 3) - (byte_num + 2)];
                    COM_Tx_Buffer[byte_num + 2] = Buf_COM_Tx_Buffer[(TOTAL_LED_COUNT * 3) - (byte_num + 1)];
                    COM_Tx_Buffer[byte_num + 3] = Buf_COM_Tx_Buffer[(TOTAL_LED_COUNT * 3) - (byte_num + 0)];
                }
                //===================================
            }

            COM_Tx_Buffer[TOTAL_LED_COUNT * 3] = (byte)255; //SHOW 
            // Send data over serial if the device enabled
            if ((SerialPortName != "COM0") && (Monitor_Sleeping==false)) 
                serialPort1.Write(COM_Tx_Buffer, 0, (TOTAL_LED_COUNT * 3) + 3);

            sw.Stop(); // Stop the Process timer
            TransmitTimeLabel.Text = "Transmit Time" + sw.Elapsed.Milliseconds + "ms"; //Print Serial transmit time
            CaptureTimer.Enabled = true; //timer enable again
        }




        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode_select(1);
        }


        private void sleepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode_select(2);
        }


        private void audioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode_select(3);
        }

        private void colorSelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorForm frm = new ColorForm();
            frm.Show();
            mode_select(4);
        }

  

        private void StaticColorTimer_Tick(object sender, EventArgs e)
        {
            byte R = GlobalVars.ColorSelectValueR ;
            byte G = GlobalVars.ColorSelectValueG;
            byte B = GlobalVars.ColorSelectValueB;


            for (int i = 0; i < 512; i++)
            {
                COM_Tx_Buffer[(i * 3) + 1] = (byte)(R >> 2); // divide 2
                COM_Tx_Buffer[(i * 3) + 2] = (byte)(G >> 2);
                COM_Tx_Buffer[(i * 3) + 3] = (byte)(B >> 2);
            }
            COM_Tx_Buffer[512 * 3] = (byte)255; //SHOW 
            StaticColorBuffer = COM_Tx_Buffer;
            if ((SerialPortName != "COM0") && (Monitor_Sleeping == false))
                serialPort1.Write(COM_Tx_Buffer, 0, (512 * 3) + 3);
            

        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {
            IniFile ini = new IniFile(IniFilePath);
            //Write to INI
            ini.IniWriteValue("MAIN", "FRAME_LED_LEFT", Left_Textbox.Text.ToString());
            ini.IniWriteValue("MAIN", "FRAME_LED_RIGHT", Right_Textbox.Text.ToString());
            ini.IniWriteValue("MAIN", "FRAME_LED_TOP", Top_Textbox.Text.ToString());
            ini.IniWriteValue("MAIN", "FRAME_LED_BOTTOM_LEFT", BottomLeft_Textbox.Text.ToString());
            ini.IniWriteValue("MAIN", "FRAME_LED_BOTTOM_RIGHT", BottomRight_Textbox.Text.ToString());
            ini.IniWriteValue("MAIN", "FRAME_LED_GAP", Gap_Textbox.Text.ToString());
            // Read and refresh from INI
            FRAME_LED_LEFT = ini.IniReadInt("MAIN", "FRAME_LED_LEFT");
            FRAME_LED_TOP = ini.IniReadInt("MAIN", "FRAME_LED_TOP");
            FRAME_LED_RIGHT = ini.IniReadInt("MAIN", "FRAME_LED_RIGHT");
            FRAME_LED_BOTTOM_LEFT = ini.IniReadInt("MAIN", "FRAME_LED_BOTTOM_LEFT");
            FRAME_LED_BOTTOM_RIGHT = ini.IniReadInt("MAIN", "FRAME_LED_BOTTOM_RIGHT");
            FRAME_LED_GAP = ini.IniReadInt("MAIN", "FRAME_LED_GAP");

            TOTAL_LED_COUNT = FRAME_LED_LEFT + FRAME_LED_TOP + FRAME_LED_RIGHT + FRAME_LED_BOTTOM_LEFT + FRAME_LED_BOTTOM_RIGHT;
            // Refresh default full screen settigns.
            fullScreenToolStripMenuItem.PerformClick();
            // Clear the Strip buffer
            COM_Tx_Buffer[512 * 3] = (byte)252; //Clear LED buffer and read the color sensor.(the sensor read is not important now, just for clear)
            if ((SerialPortName != "COM0") && (Monitor_Sleeping == false))
                serialPort1.Write(COM_Tx_Buffer, 0, (512 * 3) + 3);



        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void MonitorSleepButton_Click(object sender, EventArgs e)
        {
            SendMessage(this.Handle.ToInt32(), WM_SYSCOMMAND, SC_MONITORPOWER, 2);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Black_Stripe_Eliminator = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void cinematic21x9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SET_Ratio(21, 9);
        }

        private void hD16x9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SET_Ratio(16, 9);
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {

        }

        private void oLDTV4x3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SET_Ratio(4, 3);
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            SET_Ratio(w, h);
        }

        private void autoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void onlineMovieThinBarsOnTopbottomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SET_Ratio(19, 9);
        }

        private void ComPortCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // connect to INI file
            IniFile ini = new IniFile(IniFilePath);
            //Check port name for change
            if (ComPortCombo.Text != ini.IniReadValue("MAIN", "PortName"))
            {
                ini.IniWriteValue("MAIN", "PortName", ComPortCombo.Text);
                MessageBox.Show("Com Port changed!\n Now,You should restart the application.");
                quitToolStripMenuItem.PerformClick();
            }

        }

        private void dVideoSideBySideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            SET_Ratio(w, h, "3D");
        }

        private void dualMonitorSideBySideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            SET_Ratio(w, h, "DUAL");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", IniFilePath);
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void DelayBar_ValueChanged(object sender, EventArgs e)
        {
            Refresh_Interval = DelayBar.Value;
            IniFile ini = new IniFile(IniFilePath);
            ini.IniWriteValue("MAIN", "Refresh_Interval", Refresh_Interval.ToString());
            DelayLabel.Text = "Delay: " + Refresh_Interval.ToString() + "ms";

        }

        private void DelayBar_Scroll(object sender, EventArgs e)
        {

        }

        private void pseudoFullScreenToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            UpdateProcessList();
        }

        private void Aero_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ControlAero(Aero_CheckBox.Checked);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Direction_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            


        }

        private void button3_Click(object sender, EventArgs e)
        {
            IniFile ini = new IniFile(IniFilePath);

            if (ini.IniReadValue("MAIN", "STRIP_DIRECTION") != "COUNTERCLOCKWISE")
            {
                ini.IniWriteValue("MAIN", "STRIP_DIRECTION", "COUNTERCLOCKWISE");
                inverted_strip = false;
            }
            else
            {
                ini.IniWriteValue("MAIN", "STRIP_DIRECTION", "CLOCKWISE");
                inverted_strip = true;
            }
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            updater.DoUpdate();
        }






    }
}