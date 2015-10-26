using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ParameterManagementSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int FreeConsole();
        [STAThread]
        static void Main(string[] argv)
        {
            Debugger.Launch();

            if (argv.Count<string>() < 2)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                FreeConsole();
                Application.Run(new Form1());
            }
            else
            {
                ConsoleHost.Run(argv);
            }
        }
    }
}

