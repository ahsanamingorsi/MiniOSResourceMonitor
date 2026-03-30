using System;
using System.Windows.Forms;
using System;
using System.Windows.Forms;

namespace MiniOSResourceMonitor
{
    internal static class Program
    {
        /// <summary>
        /// Application entry point.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.Run(new UI.MainForm());
        }
    }
}