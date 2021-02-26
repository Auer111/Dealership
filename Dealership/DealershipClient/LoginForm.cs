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
using System.Threading.Tasks;

namespace DealershipClient
{
    public partial class LoginForm : Form
    {
        public Configuration config;
        public LoginForm()
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
            config.SetAppSetting("Password", Crypto.Encrypt(this.Password.Text));

            string dealer = Client.Login(
                this.Username.Text, 
                Crypto.Encrypt(this.Password.Text),
                this.Endpoint.Text + "/Login");
            if(dealer != null)
            {
                SwitchFourms(new MainForm(this));
            }
            
            config.SetAppSetting("Dealer", dealer);

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            config.SetAppSetting("Password", Crypto.Encrypt(this.Password.Text));

            config.Save();
        }

        private void Title_Click(object sender, EventArgs e)
        {

        }

        private void Username_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Username.Text))
            {
                errorProviderUsername.SetError(Username, "Required");
            }
            else
            {
                errorProviderUsername.Clear();
            }
            
        }

        private void Password_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Password.Text))
            {
                errorProviderUsername.SetError(Password, "Required");
            }
            else
            {
                errorProviderUsername.Clear();
            }
        }


        //----Open a new form-------
        private void SwitchFourms(Form f)
        {
            Hide();
            this.Enabled = false;
        }
    }
}
