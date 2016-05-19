using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace DBSync
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch(Exception e)
            {
                LogException(e);
            }
        }

        public static void LogException(Exception e)
        {
            File.AppendAllText("log.txt", e.Message+Environment.NewLine);
            File.AppendAllText("log.txt", e.StackTrace + Environment.NewLine);
            if (e.InnerException != null)
                LogException(e.InnerException);
        }
    }
}
