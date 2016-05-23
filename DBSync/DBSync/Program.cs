using DBSync.Encryption;
using DBSync.SqlLiteDb;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            String appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Directory.CreateDirectory($"{appDataPath}\\DbSync");
            AppDomain.CurrentDomain.SetData("DataDirectory", appDataPath);

            AesHelper.InitAes();      
            SettingsManager.Instance.LoadSettings();
            String lang = SettingsManager.Instance.Lang;

            if (!String.IsNullOrEmpty(lang))
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(lang);
            }

            try
            {
                Application.Run(new MainForm());
            }
            catch (Exception e)
            {
                LogException(e);
            }
        }

        public static void LogException(Exception e)
        {
            File.AppendAllText("log.txt", e.Message + Environment.NewLine);
            File.AppendAllText("log.txt", e.StackTrace + Environment.NewLine);
            if (e.InnerException != null)
                LogException(e.InnerException);
        }
    }
}
