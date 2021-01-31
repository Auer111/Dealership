using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Auer.Extensions;
using Auer.Security;

namespace DealershipClient
{
    public partial class MainForm : Form
    {
        public Configuration config;
        public MainForm()
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            config.SetAppSetting("Username", this.Username.Text);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = Title;
            this.Username.Text = config.GetAppSetting("Username");
            this.Endpoint.Text = config.GetAppSetting("Endpoint") ?? ConfigurationManager.ConnectionStrings["Endpoint"].ConnectionString;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            config.SetAppSetting("Endpoint", this.Endpoint.Text);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            config.SetAppSetting("Password",Crypto.Encrypt(this.Password.Text));

            config.Save();
        }


    }
}
