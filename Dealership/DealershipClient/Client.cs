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

        public static string GetFile(string fileName = null)
        {
            if (fileName != null && File.Exists(fileName)) {
                return fileName;
            }

            string[] files = Directory.GetFiles(Path.GetDirectoryName(ExecutablePath()), "*.csv");
            if (files.Any())
            {
                return files.Select(f => new DirectoryInfo(f)).OrderByDescending(di => di.LastWriteTime).First().FullName;
            }
            return null;
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
