using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AmbiLED
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException); //detailed error information

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());


            //Form1 f = new Form1();
            Application.Run(new Form1());
            

        }

   
    static void CurrentDomain_UnhandledException
  (object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.ExceptionObject;

                MessageBox.Show("Whoops! Please contact the developers with the following information:\n\n" + ex.Message + ex.StackTrace,"Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                Application.Exit();
            }
        }
    
    }
}
