using DBSync.Encryption;
using DBSync.SqlLiteDb;
using System;
using System.Collections.Generic;
using System.Globalization;
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

                AesHelper.InitAes();

                String ss=AesHelper.EncryptString("valera_test");
                 ss = AesHelper.DecryptString(ss);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                SettingsManager.Instance.LoadSettings();
                String lang = SettingsManager.Instance.Lang;

                if(!String.IsNullOrEmpty(lang))
                {
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(lang);
                }
                
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
