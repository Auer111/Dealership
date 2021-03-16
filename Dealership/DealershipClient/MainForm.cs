using Auer.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Auer.Extensions;

namespace DealershipClient
{
    public partial class MainForm : Form
    {


        public MainForm()
        {
            InitializeComponent();
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(Client.ExecutablePath());
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    FilePathInput.Text = filePath;

                    Client.config.SetAppSetting("CSV", filePath);

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            string endpoint = Client.config.GetAppSetting("Endpoint") ?? ConfigurationManager.ConnectionStrings["Endpoint"].ConnectionString;
            string result = Client.Upload(
            Client.GetFile(Client.config.GetAppSetting("CSV")),
            Client.config.GetAppSetting("Username"),
            Client.config.GetAppSetting("Password"),
            endpoint + "/Upload");

            Console.WriteLine(result);
        
        }
    }
}
