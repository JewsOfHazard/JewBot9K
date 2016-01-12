using System;
using System.Windows.Forms;
using JewBot9K.Utilities;
using System.Security;
using System.Text;
using System.IO;

namespace JewBot9K
{
    public partial class AuthorizeForm : Form
    {
        public AuthorizeForm()
        {
            InitializeComponent();
            if (Settings.isAuthorized)
            {
                button2.Enabled = true;
                textBox1.Text = Settings.realName;
                textBox2.Text = Settings.oauth;
            }
            else
            {
                System.Diagnostics.Process.Start("https://api.twitch.tv/kraken/oauth2/authorize?response_type=token&client_id=f9zg203ybd5xm8vzpl69nllx9d1amf1&redirect_uri=http://jewsofhazard.com/oauth&scope=user_read+user_blocks_read+user_blocks_edit+channel_editor+channel_commercial+channel_subscriptions+chat_login+channel_check_subscription");
            }
        }
   
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\JewBot9KSettings.xml");
            Settings.realName = null;
            Settings.username = null;
            Settings.oauth = null;
            Settings.isAuthorized = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://api.twitch.tv/kraken/oauth2/authorize?response_type=token&client_id=f9zg203ybd5xm8vzpl69nllx9d1amf1&redirect_uri=http://jewsofhazard.com/oauth&scope=user_read+user_blocks_read+user_blocks_edit+channel_editor+channel_commercial+channel_subscriptions+chat_login+channel_check_subscription");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Settings.realName = textBox1.Text;
            Settings.username = textBox1.Text.ToLower();
            Settings.oauth = textBox2.Text;
            Settings.isAuthorized = true;
            SaveData(textBox1.Text, textBox2.Text);
            Close();
        }
        private void SaveData(string username, string password)
        {
            byte[] usernameByteArray = Encoding.UTF8.GetBytes(username);
            byte[] passwordByteArray = Encoding.UTF8.GetBytes(password);
            //to do tomorrow
        }
    }
}
