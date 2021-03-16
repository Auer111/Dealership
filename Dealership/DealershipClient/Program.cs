using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;

namespace DealershipClient
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //string AppName = "DealerspaceClient";
            if (args.Any())
            {
                if (Client.RunTask(args) ?? false)
                {
                    Application.Run(Client.MainForm = new MainForm());
                }
            }
            else
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                //Thread.Sleep(8000); //Sleep to allow localhost to startup
                if (!Client.IsLoggedIn())
                {
                    Application.Run(Client.LoginForm = new LoginForm());
                }
                else
                {
                    Application.Run(Client.MainForm = new MainForm());
                }
            }  
        }
    }
}
