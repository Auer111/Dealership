using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
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
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }


        public static void Act(string[] args)
        {
            string AppName = "DealershipClient";
            RunCMD("running from task scheduler");

            string[] files = Directory.GetFiles(Path.GetDirectoryName(ExecutablePath()), "*.csv");
            string file = files.Select(f => new DirectoryInfo(f)).OrderByDescending(di => di.LastWriteTime).First().FullName;

            int StatusCodeResult = SendFile(file);
            WebMessage(DecodeApiStatus(StatusCodeResult));

            if (!args.Any())
            {
                ScheduleTask(AppName);
            }
            else
            {

                //string[] files = Directory.GetFiles(Path.GetDirectoryName(ExecutablePath()), "*.csv");

                if (!files.Any())
                {
                    WebMessage("Cannot%Find%Csv");
                }
                else
                {
                    //string file = files.Select(f => new DirectoryInfo(f)).OrderByDescending(di => di.LastWriteTime).First().FullName;

                    //int StatusCodeResult = SendFile(file);
                    //WebMessage(DecodeApiStatus(StatusCodeResult));
                }

            }
        }

        public static void WebMessage(string message)
        {
            RunCMD("start /max https://www.google.com/?q=" + message);
        }
        public static void RunCMD(string command)
        {

            Process cmd = new Process();

            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            cmd.StandardInput.WriteLine(command);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            //Console.WriteLine(cmd.StandardOutput.ReadToEnd());
        }

        public static void ScheduleTask(string TaskName)
        {

            TaskService ts = new TaskService();

            TaskDefinition td = ts.NewTask();
            td.RegistrationInfo.Description = "Run Task";
            td.Principal.RunLevel = TaskRunLevel.Highest;

            RegistrationTrigger rt = new RegistrationTrigger();
            rt.Repetition.Interval = TimeSpan.FromMinutes(1);

            td.Triggers.Add(rt);
            td.Actions.Add(ExecutablePath(), "myArgs");

            TaskService.Instance.RootFolder.RegisterTaskDefinition(TaskName, td);
        }

        public static string ExecutablePath()
        {
            string dll = System.Reflection.Assembly.GetExecutingAssembly().Location;
            return System.IO.Path.ChangeExtension(dll, "exe");
        }

        public static string DecodeApiStatus(int code)
        {
            switch (code)
            {
                case 201: return "Ok";
                case 500: return "Error";
                default: return code.ToString();
            }
        }

        public static int SendFile(string FilePath)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri("https://localhost:44381/UploadCSV");

                        byte[] data = File.ReadAllBytes(FilePath);

                        ByteArrayContent bytes = new ByteArrayContent(data);

                        MultipartFormDataContent multiContent = new MultipartFormDataContent();

                        multiContent.Add(bytes, "file", "Data");

                        var result = client.PostAsync("https://localhost:44381/UploadCSV", multiContent).Result;

                        return 201;

                    }
                    catch (Exception) { return 500; }
                }
            }
            catch (Exception) { return 500; }

        }
    }
}
