using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Collections.ObjectModel;
using System.IO.Ports;
using KMPP;
using SlimDX.Direct3D9;
using SlimDX;
using Ini;
using Microsoft.Win32;



namespace DxCapture
{
    public partial class Form1 : Form
    {

        // MONITOR SLEEP DETECTION 
        Guid GUID_CONSOLE_DISPLAY_STATE = new Guid("6fe69556-704a-47a0-8f24-c28d936fda47");
        const int DEVICE_NOTIFY_WINDOW_HANDLE = 0x00000000;
        const int WM_SYSCOMMAND = 0x0112;
        const int WM_POWERBROADCAST = 0x218;
        const int SC_MONITORPOWER = 0xf170;
        const int PBT_POWERSETTINGCHANGE = 0x8013;
        #region Win32 calls
        struct POWERBROADCAST_SETTING { public Guid PowerSetting; public UInt32 DataLength; public byte Data; }

        [DllImport(@"User32", SetLastError = true, EntryPoint = "RegisterPowerSettingNotification", CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr RegisterPowerSettingNotification(IntPtr hRecipient, ref Guid PowerSettingGuid, Int32 Flags);

        [DllImport("user32.dll")]
        private static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);

        #endregion
        // END - MONITOR SLEEP DETECTION


    

        //PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", Process.GetCurrentProcess().ProcessName);

        //PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");

        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }


        /*
        #region Constants
        //Finds a window by class name
        [DllImport("USER32.DLL")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        //Sets a window to be a child window of another window
        [DllImport("USER32.DLL")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        //Sets window attributes
        [DllImport("USER32.DLL")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        //Gets window attributes
        [DllImport("USER32.DLL")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll")]
        static extern IntPtr GetMenu(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern int GetMenuItemCount(IntPtr hMenu);

        [DllImport("user32.dll")]
        static extern bool DrawMenuBar(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool RemoveMenu(IntPtr hMenu, uint uPosition, uint uFlags);
        */

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

        /*
        //SetWindowPos
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);


        #endregion

        //assorted constants needed
        public static uint MF_BYPOSITION = 0x400;
        public static uint MF_REMOVE = 0x1000;
        public static int GWL_STYLE = -16;
        public static int WS_CHILD = 0x40000000; //child window
        public static int WS_BORDER = 0x00800000; //window with border
        public static int WS_DLGFRAME = 0x00400000; //window with double border but no title
        public static int WS_CAPTION = WS_BORDER | WS_DLGFRAME; //window with a title bar 
        public static int WS_SYSMENU = 0x00080000; //window menu  
        public static int SWP_NOMOVE = 0x2;
        public static int SWP_NOSIZE = 1;
        public static int SWP_NOZORDER = 0x4;
        public static int SWP_SHOWWINDOW = 0x0040;
        public static int SWP_FRAMECHANGED = 0x0020;
        public static int SWP_NOOWNERZORDER = 0x0200;

        */

        public static int GWL_STYLE = -16;
        public static int WS_CHILD = 0x40000000; //child window
        public static int WS_BORDER = 0x00800000; //window with border
        public static int WS_DLGFRAME = 0x00400000; //window with double border but no title
        public static int WS_CAPTION = 0x00C00000; //window with a title bar
        private const int WS_SIZEBOX = 0x040000;
        private const int WS_EX_DLGMODALFRAME = 0x00000001;

        
        
        byte[] COM_Tx_Buffer = new byte[2000];

        float POWER_LEVEL = (float) 0.3;
        int Refresh_Interval = 100;
        int Power_Level = 30;
        string SerialPortName = "COM0";

        Boolean Monitor_Sleeping = false;

        int FRAME_LED_LEFT = 10;
        int FRAME_LED_TOP = 10;
        int FRAME_LED_RIGHT = 10;
        int FRAME_LED_BOTTOM_LEFT = 5; 
        int FRAME_LED_BOTTOM_RIGHT = 5;
        int FRAME_LED_GAP = 0;
        int TOTAL_LED_COUNT = 40;

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
        DxScreenCapture sc = new DxScreenCapture();


        Collection<long> stripPos = new Collection<long>();
        Collection<Color> stripColor = new Collection<Color>();

        const int Bpp = 4;

        public Form1()
        {
          try
            {
            InitializeComponent();

            Read_Ini_File();
            Set_LED_Positions();

            /*
            float gamma_R = (float) 0.45;
            float gamma_G = (float) 0.45;
            float gamma_B = (float) 0.45;
            //GAMMA Düzeltmesi
            for (int i = 0; i < 256; ++i)
            {
                RedRamp[i] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(i / 255.0, 1.0 / gamma_R)) + 0.5));
                GreenRamp[i] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(i / 255.0, 1.0 / gamma_G)) + 0.5));
                BlueRamp[i] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(i / 255.0, 1.0 / gamma_B)) + 0.5));
                textBox2.Text = textBox2.Text + "," + BlueRamp[i].ToString();

            }  
            */

            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (rk.GetValue("AmbiLED") != null) RunOnStartup.Checked = true;
            }
         catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

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



                // Notify icon set up
                MyNotifyIcon.Visible = true;
                //MyNotifyIcon.Text = "Tooltip message here";
                this.ShowInTaskbar = false;
                this.Hide();
                string[] ports = SerialPort.GetPortNames();
                textBox1.Text = string.Join(" ,", ports);


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

        Color avcs(DataStream gs, Collection<long> positions)
        {
            byte[] bu = new byte[4];
            int r = 0;
            int g = 0;
            int b = 0;
            int i = 0;

            

            foreach (long pos in positions)
            {
                gs.Position = pos;
                gs.Read(bu, 0, 4);
                r += bu[2];
                g += bu[1];
                b += bu[0];
                i++;

                
            }

            return Color.FromArgb(r / i, g / i, b / i);
        }

        void Read_Ini_File()
        {
            //INIFile Ini = new INIFile(Application.StartupPath + @"\\config.ini");
            IniFile ini = new IniFile(Application.StartupPath + @"\\config.ini");


            FRAME_LED_LEFT = ini.IniReadInt("MAIN", "FRAME_LED_LEFT");
            FRAME_LED_TOP = ini.IniReadInt("MAIN", "FRAME_LED_TOP");
            FRAME_LED_RIGHT = ini.IniReadInt("MAIN", "FRAME_LED_RIGHT");
            FRAME_LED_BOTTOM_LEFT = ini.IniReadInt("MAIN", "FRAME_LED_BOTTOM_LEFT");
            FRAME_LED_BOTTOM_RIGHT = ini.IniReadInt("MAIN", "FRAME_LED_BOTTOM_RIGHT");
            FRAME_LED_GAP = ini.IniReadInt("MAIN", "FRAME_LED_GAP");


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

            if (SerialPortName != "COM0")
                {
                serialPort1.PortName = SerialPortName;
                serialPort1.BaudRate = 115200;

                serialPort1.Open();
                serialPort1.Encoding = System.Text.Encoding.UTF8;
                }

            CaptureTimer.Interval = Refresh_Interval;
            CaptureTimer.Enabled = true;

            POWER_LEVEL = (float)Power_Level / 100;

        }

        void Set_LED_Positions()
        {
            int o = 2;// ((Screen.PrimaryScreen.Bounds.Width + Screen.PrimaryScreen.Bounds.Height) * 2) / (led_adet * 10);
            int m = 8;
            int Screen_Width = Screen.PrimaryScreen.Bounds.Width; //SystemInformation.VirtualScreen.Width; 
            int Screen_Height = Screen.PrimaryScreen.Bounds.Height; //SystemInformation.VirtualScreen.Height; 
            int sx = Screen_Width - m;
            int sy = Screen_Height - m;


            float ekran_orani = (float)Screen_Width / Screen_Height;

            ScreenPanel.Height = (int)(100 / ekran_orani);
            ScreenPanel.Width = 100;

            long x, y;
            long pos;


            int bottom_right_length = (int)((Screen_Width-(2*m))* (((float)FRAME_LED_BOTTOM_RIGHT / (float)(FRAME_LED_BOTTOM_LEFT + FRAME_LED_GAP + FRAME_LED_BOTTOM_RIGHT))));
            y = sy;//Sağ alttan sol alta
            for (x = bottom_right_length+m; x > m; x -= o)
            {
                pos = (y * Screen_Width + x) * Bpp;
                stripPos.Add(pos);
                stripColor.Add(Color.Blue);
            }

            x = m;//sol alttan sol üste
            for (y = sy - 1; y > m + 1; y -= o)
            {
                pos = (y * Screen_Width + x) * Bpp;
                stripPos.Add(pos);
                stripColor.Add(Color.Yellow);
            }

            y = m; //sol ustten sağ üste
            for (x = m; x < sx; x += o)
            {
                pos = (y * Screen_Width + x) * Bpp;
                stripPos.Add(pos);
                stripColor.Add(Color.Red);
            }

            x = sx; //sağ usten sağ alta
            for (y = m + 1; y < sy - 1; y += o)
            {
                pos = (y * Screen_Width + x) * Bpp;
                stripPos.Add(pos);
                stripColor.Add(Color.Green);
            }

            int bottom_left_length = (int)((Screen_Width - (2 * m)) * (((float)FRAME_LED_BOTTOM_LEFT / (float)(FRAME_LED_BOTTOM_LEFT + FRAME_LED_GAP + FRAME_LED_BOTTOM_RIGHT))));
            y = sy;//Sağ alttan sol alta
            for (x = sx; x > sx-bottom_left_length; x -= o)
            {
                pos = (y * Screen_Width + x) * Bpp;
                stripPos.Add(pos);
                stripColor.Add(Color.Blue);
            }


        
        }
        void Calculate()
        {
            Surface s = sc.CaptureScreen();
            DataRectangle dr = s.LockRectangle(LockFlags.None);
            DataStream gs = dr.Data;
            //second display
            //Surface s2 = sc.CaptureScreen2();
            //DataRectangle dr2 = s2.LockRectangle(LockFlags.None);
            //DataStream gs2 = dr2.Data;


            
            byte[] bu = new byte[4];
            int r = 0;
            int g = 0;
            int b = 0;
            int i = 0;

            int led_oran =  (stripPos.Count() / TOTAL_LED_COUNT)+1;
            int Tx_Buffer_ID = 0;

            foreach (long pos in stripPos)
            {
                gs.Position = pos;
                gs.Read(bu, 0, 4);
                r += bu[2];
                g += bu[1];
                b += bu[0];
                i++;


                if (i % led_oran == 0)
                    {

                        

                        r = r / led_oran;
                        g = g / led_oran;
                        b = b / led_oran;

                        r = (int)(r * POWER_LEVEL * 0.9);
                        g = (int)(g * POWER_LEVEL * 1.0);
                        b = (int)(b * POWER_LEVEL * 0.85);

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

            s.UnlockRectangle();
            s.Dispose();
            //s2.UnlockRectangle();
            //s2.Dispose();
        }

       /*
        void dump_buffer()
            {
               IDirect3DSurface9* pRenderTarget=NULL;
               IDirect3DSurface9* pDestTarget=NULL;
                 const char file[] = "cap.bmp";
               // sanity checks.
               if (Device == NULL)
                  return;

               // get the render target surface.
               HRESULT hr = Device->GetRenderTarget(0, &pRenderTarget);
               // get the current adapter display mode.
               //hr = pDirect3D->GetAdapterDisplayMode(D3DADAPTER_DEFAULT,&d3ddisplaymode);

               // create a destination surface.
               hr = Device->CreateOffscreenPlainSurface(DisplayMde.Width,
                                     DisplayMde.Height,
                                     DisplayMde.Format,
                                     D3DPOOL_SYSTEMMEM,
                                     &pDestTarget,
                                     NULL);
               //copy the render target to the destination surface.
               hr = Device->GetRenderTargetData(pRenderTarget, pDestTarget);
               //save its contents to a bitmap file.
               hr = D3DXSaveSurfaceToFile(file,
                                          D3DXIFF_BMP,
                                          pDestTarget,
                                          NULL,
                                          NULL);

               // clean up.
               pRenderTarget->Release();
               pDestTarget->Release();
            }
        */



        private void topLeft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void top_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

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

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void Start_Timer_Tick(object sender, EventArgs e)
        {

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
            serialPort1.Close();
            Application.Exit();
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
            POWER_LEVEL = (float)0.1;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            POWER_LEVEL = (float)0.15;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            POWER_LEVEL = (float)0.2;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            POWER_LEVEL = (float)0.25;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            POWER_LEVEL = (float)0.3;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            POWER_LEVEL = (float)0.4;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            POWER_LEVEL = (float)0.5;
        }
        
        private void Form1_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void runOnStartupToolStripMenuItem_Click(object sender, EventArgs e)
        {
        


        }

        private void sleepModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CaptureTimer.Enabled == true)
            {
                CaptureTimer.Enabled = false;
                sleepModeToolStripMenuItem.Checked = true;
            }
            else
            {
                CaptureTimer.Enabled = true;
                sleepModeToolStripMenuItem.Checked = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            Gap_Textbox.Text = UpDown_Gap.Value.ToString();
        }

        private void label6_Click(object sender, EventArgs e)
        {

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
            textBox1.Text = screendata.Length.ToString() ;




                //textBox1.Text = cpuCounter.NextValue() + "%"; ;

                //this.Text = Process.GetCurrentProcess().ProcessName;

                //foreach (Process proc in Process.GetProcesses())
                {
                    //using (PerformanceCounter pcProcess = new PerformanceCounter("Process", "% Processor Time", proc.ProcessName))
                    {
                        //pcProcess.NextValue();
                        //System.Threading.Thread.Sleep(1000);
                        //textBox1.Text = textBox1.Text + "Process:{0} CPU% {1}" + proc.ProcessName;// +pcProcess.NextValue();
                    }
                }

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
            Process[] processes = Process.GetProcessesByName("WorldOftanks");
            foreach (Process p in processes)
            {
                IntPtr handle = p.MainWindowHandle;
                RECT Rect = new RECT();
                if (GetWindowRect(handle, ref Rect))
                    MoveWindow(handle, -5, -5, Screen.PrimaryScreen.Bounds.Width+10, Screen.PrimaryScreen.Bounds.Height+500, true);

                int style = GetWindowLong(handle, GWL_STYLE);

                SetWindowLong(handle, GWL_STYLE, (style + WS_CAPTION + WS_SIZEBOX));

                
            }


   



        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //byte[] buffer = { 254,0,0 };
            //serialPort1.Write(buffer,0,3);
            SendMessage(this.Handle.ToInt32(), WM_SYSCOMMAND, SC_MONITORPOWER, 2);

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            IniFile ini = new IniFile(Application.StartupPath + @"\\config.ini");
            ini.IniWriteValue("MAIN", "FRAME_LED_LEFT", FRAME_LED_LEFT.ToString());
            ini.IniWriteValue("MAIN", "FRAME_LED_RIGHT", FRAME_LED_RIGHT.ToString());
            ini.IniWriteValue("MAIN", "FRAME_LED_TOP", FRAME_LED_TOP.ToString());
            ini.IniWriteValue("MAIN", "FRAME_LED_BOTTOM_LEFT", FRAME_LED_BOTTOM_LEFT.ToString());
            ini.IniWriteValue("MAIN", "FRAME_LED_BOTTOM_RIGHT", FRAME_LED_BOTTOM_RIGHT.ToString());
            ini.IniWriteValue("MAIN", "FRAME_LED_GAP", FRAME_LED_GAP.ToString());
            

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
            Calculate();
            COM_Tx_Buffer[TOTAL_LED_COUNT * 3] = (byte)255; //SHOW 
            if ((SerialPortName != "COM0") && (Monitor_Sleeping==false))
                serialPort1.Write(COM_Tx_Buffer, 0, (TOTAL_LED_COUNT * 3) + 3);
        }




    }
}