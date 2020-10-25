using System;
using System.Threading;
using System.Windows.Forms;

namespace eVidyalaya
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            //Application.Run(new UIParent());
            Application.Run(new UserLogin());
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //MessageBox.Show("CurrentDomain_UnhandledException: " + e.ExceptionObject, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            MessageBox.Show("Error : Please contact to support team.", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            //e.Exception.TargetSite.ToString()
            //MessageBox.Show("Application_ThreadException: " + e.Exception.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            MessageBox.Show("Error : Please contact to support team.", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //https://www.codeproject.com/Articles/43182/Centralised-Exception-Handling-in-C-Windows-Applic
        //https://www.codeproject.com/Articles/14912/A-Simple-Class-to-Catch-Unhandled-Exceptions-in-Wi
        //https://www.codeproject.com/Articles/17253/A-Custom-Message-Box
    }
}
