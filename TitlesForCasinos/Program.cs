using System;
using System.IO;
using System.Windows.Forms;
using Mew.AppLogAndEventHelper;

namespace TitlesForCasinos {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main() {
            AppLogAndEventHelper.Instance.AddLog(Application.ExecutablePath);
            Properties.Settings.Default.WorkingDir = new FileInfo(Application.ExecutablePath).Directory?.FullName;
            try {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FCasinos());
            }
            catch (Exception e) {
                AppLogAndEventHelper.Instance.RaiseError(e);
            }
            finally {
                AppLogAndEventHelper.Instance.Dispose();
            }
        }
    }
}