using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Auer.Extensions;

namespace DealershipClient
{
    class Client
    {

        public static Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        public static LoginForm LoginForm;
        public static MainForm MainForm;


        public static bool IsLoggedIn()
        {
            
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string SavedDealerName = config.GetAppSetting("Dealer");
            string DealerName = Client.Login(
                config.GetAppSetting("Username"), 
                config.GetAppSetting("Password"),
                config.GetAppSetting("Endpoint") ?? ConfigurationManager.ConnectionStrings["Endpoint"].ConnectionString);

            if (string.IsNullOrWhiteSpace(DealerName)) { return false; }

            if (SavedDealerName == DealerName) { return true; }
            return false;
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


            BootTrigger bt = new BootTrigger();
            bt.Repetition.Interval = TimeSpan.FromMinutes(1);
            bt.Repetition.Duration = TimeSpan.FromHours(12);

            //RegistrationTrigger rt = new RegistrationTrigger();
            //rt.Repetition.Interval = TimeSpan.FromMinutes(1);

            td.Triggers.Add(bt);
            td.Actions.Add(ExecutablePath(), "myArgs");

            TaskService.Instance.RootFolder.RegisterTaskDefinition(TaskName, td);
        }
        public static bool? RunTask(string[] args)
        {
            string file = GetFile(config.GetAppSetting("CSV"));

            if (string.IsNullOrWhiteSpace(file)) { return null; }

            //File is updated
            if(File.GetLastWriteTime(file) > DateTime.Parse(config.GetAppSetting("csvWriteDate")))
            {
                string endpoint = Client.config.GetAppSetting("Endpoint") ?? ConfigurationManager.ConnectionStrings["Endpoint"].ConnectionString;
                string result = Client.Upload(
                    Client.GetFile(Client.config.GetAppSetting("CSV")),
                    Client.config.GetAppSetting("Username"),
                    Client.config.GetAppSetting("Password"),
                    endpoint + "/Upload");
                return true;
            }

            return false;
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

        public static string GetFile(string fileName = null)
        {
            if (fileName != null && File.Exists(fileName)) {
                return SetFileInfo(fileName);
            }

            string[] files = Directory.GetFiles(Path.GetDirectoryName(ExecutablePath()), "*.csv");
            if (files.Any())
            {
                string file = files.Select(f => new DirectoryInfo(f)).OrderByDescending(di => di.LastWriteTime).First().FullName;
                return SetFileInfo(fileName);
            }
            return null;
        }

        private static string SetFileInfo(string file)
        {
            File.SetLastWriteTime(file, DateTime.Now);
            config.SetAppSetting("CSV", file);
            config.SetAppSetting("csvWriteDate", DateTime.Now.ToString());
            return file;
        }

        public static string Login(string username, string password, string url = null)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        MultipartFormDataContent multiContent = new MultipartFormDataContent();

                        multiContent.Add(new StringContent(username), "Username");
                        multiContent.Add(new StringContent(password), "Password");

                        var response = client.PostAsync(url ?? "https://localhost:44381/Client/Login", multiContent).Result;
                        var contents = response.Content.ReadAsStringAsync();
                        contents.Wait();


                        return contents.Result;

                    }
                    catch (Exception ex) { return null; }
                }
            }
            catch (Exception) { return null; }

        }


        public static string Upload(string FilePath, string username, string password, string url = null)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        byte[] data = File.ReadAllBytes(FilePath);

                        ByteArrayContent bytes = new ByteArrayContent(data);

                        MultipartFormDataContent multiContent = new MultipartFormDataContent();

                        multiContent.Add(bytes, "file", "Data");

                        multiContent.Add(new StringContent(username), "Username");
                        multiContent.Add(new StringContent(password), "Password");

                        var response = client.PostAsync(url ?? "https://localhost:44381/Client/Upload", multiContent).Result;
                        var contents = response.Content.ReadAsStringAsync();
                        contents.Wait();


                        return contents.Result;

                    }
                    catch (Exception ex) { return null; }
                }
            }
            catch (Exception) { return null; }

        }
    }
}
