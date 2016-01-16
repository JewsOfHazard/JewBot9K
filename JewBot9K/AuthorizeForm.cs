using System;
using System.Windows.Forms;
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
                textBox1.Text = Settings.displayName;
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
            Settings.logOut();
            Settings.displayName = null;
            Settings.username = null;
            Settings.oauth = null;
            Settings.isAuthorized = false;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://api.twitch.tv/kraken/oauth2/authorize?response_type=token&client_id=f9zg203ybd5xm8vzpl69nllx9d1amf1&redirect_uri=http://jewsofhazard.com/oauth&scope=user_read+user_blocks_read+user_blocks_edit+channel_editor+channel_commercial+channel_subscriptions+chat_login+channel_check_subscription");
            Settings.isAuthorized = false;
        }

        private void button3_Click(object sender, EventArgs e)//submit button
        {
            Settings.displayName = textBox1.Text;
            Settings.username = textBox1.Text.ToLower();
            Settings.oauth = textBox2.Text;
            Settings.isAuthorized = true;
            SavePassword(textBox1.Text, textBox2.Text);
            Close();
        }
        private void SavePassword(string username, string password)
        {
            Settings.SavePassword(username, password);
            //to do tomorrow
        }
    }
}
