
namespace DealershipClient
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.EndpointText = new System.Windows.Forms.Label();
            this.Endpoint = new System.Windows.Forms.TextBox();
            this.EndpointUnderline = new System.Windows.Forms.Panel();
            this.TestButton = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.UsernameUnderline = new System.Windows.Forms.Panel();
            this.Password = new System.Windows.Forms.TextBox();
            this.PasswordUnderline = new System.Windows.Forms.Panel();
            this.Username = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.UsernameLabel);
            this.panel1.Controls.Add(this.PasswordLabel);
            this.panel1.Controls.Add(this.EndpointText);
            this.panel1.Controls.Add(this.Endpoint);
            this.panel1.Controls.Add(this.EndpointUnderline);
            this.panel1.Controls.Add(this.TestButton);
            this.panel1.Controls.Add(this.Title);
            this.panel1.Controls.Add(this.UsernameUnderline);
            this.panel1.Controls.Add(this.Password);
            this.panel1.Controls.Add(this.PasswordUnderline);
            this.panel1.Controls.Add(this.Username);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(30);
            this.panel1.Size = new System.Drawing.Size(782, 453);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.ForeColor = System.Drawing.Color.SlateGray;
            this.UsernameLabel.Location = new System.Drawing.Point(25, 98);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(75, 20);
            this.UsernameLabel.TabIndex = 8;
            this.UsernameLabel.Text = "Username";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.ForeColor = System.Drawing.Color.SlateGray;
            this.PasswordLabel.Location = new System.Drawing.Point(25, 157);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(70, 20);
            this.PasswordLabel.TabIndex = 7;
            this.PasswordLabel.Text = "Password";
            // 
            // EndpointText
            // 
            this.EndpointText.AutoSize = true;
            this.EndpointText.ForeColor = System.Drawing.Color.SlateGray;
            this.EndpointText.Location = new System.Drawing.Point(25, 217);
            this.EndpointText.Name = "EndpointText";
            this.EndpointText.Size = new System.Drawing.Size(69, 20);
            this.EndpointText.TabIndex = 6;
            this.EndpointText.Text = "Endpoint";
            // 
            // Endpoint
            // 
            this.Endpoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Endpoint.BackColor = System.Drawing.Color.White;
            this.Endpoint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Endpoint.ForeColor = System.Drawing.Color.Black;
            this.Endpoint.Location = new System.Drawing.Point(30, 237);
            this.Endpoint.Margin = new System.Windows.Forms.Padding(0);
            this.Endpoint.Name = "Endpoint";
            this.Endpoint.Size = new System.Drawing.Size(722, 20);
            this.Endpoint.TabIndex = 4;
            this.Endpoint.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // EndpointUnderline
            // 
            this.EndpointUnderline.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EndpointUnderline.BackColor = System.Drawing.Color.SteelBlue;
            this.EndpointUnderline.Location = new System.Drawing.Point(30, 263);
            this.EndpointUnderline.Margin = new System.Windows.Forms.Padding(0);
            this.EndpointUnderline.Name = "EndpointUnderline";
            this.EndpointUnderline.Padding = new System.Windows.Forms.Padding(5);
            this.EndpointUnderline.Size = new System.Drawing.Size(722, 2);
            this.EndpointUnderline.TabIndex = 5;
            // 
            // TestButton
            // 
            this.TestButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TestButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.TestButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TestButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TestButton.FlatAppearance.BorderSize = 0;
            this.TestButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.TestButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.TestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TestButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TestButton.ForeColor = System.Drawing.Color.White;
            this.TestButton.Location = new System.Drawing.Point(30, 288);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(722, 28);
            this.TestButton.TabIndex = 4;
            this.TestButton.Text = "Login";
            this.TestButton.UseVisualStyleBackColor = false;
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // Title
            // 
            this.Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title.ForeColor = System.Drawing.Color.SlateGray;
            this.Title.Location = new System.Drawing.Point(30, 30);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(722, 20);
            this.Title.TabIndex = 1;
            this.Title.Text = "Login";
            this.Title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // UsernameUnderline
            // 
            this.UsernameUnderline.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsernameUnderline.BackColor = System.Drawing.Color.SteelBlue;
            this.UsernameUnderline.Location = new System.Drawing.Point(30, 144);
            this.UsernameUnderline.Margin = new System.Windows.Forms.Padding(0);
            this.UsernameUnderline.Name = "UsernameUnderline";
            this.UsernameUnderline.Padding = new System.Windows.Forms.Padding(5);
            this.UsernameUnderline.Size = new System.Drawing.Size(722, 2);
            this.UsernameUnderline.TabIndex = 2;
            // 
            // Password
            // 
            this.Password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Password.BackColor = System.Drawing.Color.White;
            this.Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Password.ForeColor = System.Drawing.Color.Black;
            this.Password.Location = new System.Drawing.Point(30, 177);
            this.Password.Margin = new System.Windows.Forms.Padding(0);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '•';
            this.Password.Size = new System.Drawing.Size(722, 20);
            this.Password.TabIndex = 3;
            // 
            // PasswordUnderline
            // 
            this.PasswordUnderline.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordUnderline.BackColor = System.Drawing.Color.SteelBlue;
            this.PasswordUnderline.Location = new System.Drawing.Point(30, 203);
            this.PasswordUnderline.Margin = new System.Windows.Forms.Padding(0);
            this.PasswordUnderline.Name = "PasswordUnderline";
            this.PasswordUnderline.Padding = new System.Windows.Forms.Padding(5);
            this.PasswordUnderline.Size = new System.Drawing.Size(722, 2);
            this.PasswordUnderline.TabIndex = 1;
            // 
            // Username
            // 
            this.Username.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Username.BackColor = System.Drawing.Color.White;
            this.Username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Username.ForeColor = System.Drawing.Color.Black;
            this.Username.Location = new System.Drawing.Point(30, 118);
            this.Username.Margin = new System.Windows.Forms.Padding(0);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(722, 20);
            this.Username.TabIndex = 2;
            this.Username.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Fraiser Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.Panel PasswordUnderline;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Panel UsernameUnderline;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button TestButton;
        private System.Windows.Forms.TextBox Endpoint;
        private System.Windows.Forms.Panel EndpointUnderline;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label EndpointText;
    }
}