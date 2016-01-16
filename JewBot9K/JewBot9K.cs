using System;
using System.Windows.Forms;
using ChatSharp;
using JewBot9K.Utilities;
using System.Threading;
using Newtonsoft.Json;
using System.Net;
using System.Collections.Generic;
using System.Drawing;

namespace JewBot9K
{
    public partial class JewBot9K : Form
    {

        // "https://api.twitch.tv/kraken/oauth2/authorize?response_type=token&client_id=f9zg203ybd5xm8vzpl69nllx9d1amf1&redirect_uri=http://jewsofhazard.com/oauth&scope=user_read+user_blocks_read+user_blocks_edit+channel_editor+channel_commercial+channel_subscriptions+chat_login+channel_check_subscription";

        private Dictionary<string, int[]> sessionUsers = new Dictionary<string, int[]>();
        IrcClient client;


        public JewBot9K()
        {
            InitializeComponent();
        }

        private void runIrc()
        {

            client = new IrcClient("irc.twitch.tv", new IrcUser(Settings.username, Settings.username, Settings.oauth));
            client.ConnectionComplete += (s, e) => client.JoinChannel("#" + Settings.username);
            client.ConnectionComplete += (s, e) => Invoke((MethodInvoker)(() => label2.Text = "Connected"));
            client.ConnectionComplete += (s, e) => Invoke((MethodInvoker)(() => label2.Location = new System.Drawing.Point(25,127)));

            client.ChannelMessageRecieved += (s, e) => //holy shit the wrong spelling of received
            {
                
                //var channel = client.Channels[0];
                string message = e.IrcMessage.RawMessage;
                message = message.Substring(1);
                string user = message.Substring(0, message.IndexOf("!"));
                message = message.Substring(message.IndexOf(":") + 1);

                if (!sessionUsers.ContainsKey(user))
                {
                    sessionUsers.Add(user, new int[] { int.Parse(DateTime.Now.ToString("MMddHHmm")), 1 });
                    Console.WriteLine(sessionUsers[user].ToString());
                }
                else
                {
                    sessionUsers[user] = new int[] { sessionUsers[user][0], sessionUsers[user][1] + 1 };
                }

                Invoke((MethodInvoker)(() => ChatWindow.AppendText(user + ": " + message + "\n")));
            };

            client.ConnectAsync();
        }

        private async void updateViewers()
        {
            Utilities.Twitch.LiveViewers.Rootobject json;
            try
            {
                using (WebClient wc = new WebClient())
                {
                    json = JsonConvert.DeserializeObject<Utilities.Twitch.LiveViewers.Rootobject>(await wc.DownloadStringTaskAsync("https://tmi.twitch.tv/group/user/" + Settings.username + "/chatters"));
                }
                ViewersList.Items.Clear();
                foreach (string item in json.chatters.viewers)
                {
                    ViewersList.Items.Add(item);
 
                }
            }
            catch(Exception)
            { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Settings.isAuthorized)
            {
                try
                {
                    updateViewers();
                }
                catch(WebException)
                {
                    //The server failed to recieve a json from twitch for whatever reason
                }
            }
        }

        private void AuthButton_Click(object sender, EventArgs e)
        {
            //open authorize form
            AuthorizeForm form = new AuthorizeForm();
            form.Show();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (Settings.isAuthorized && !Settings.isConnected)
            {
                DisconnectButton.Enabled = true;
                Settings.isConnected = true;
                runIrc();
            }
            else
            {
                label2.Text = "Auth Needed";
            }

        }

        private void Disconnect_Click(object sender, EventArgs e)
        {
            if (client != null)
            {
                client.Quit();
                label2.Text = "Disconnected";
                label2.Location = new System.Drawing.Point(19, 127);
                Settings.isConnected = false;
                DisconnectButton.Enabled = false;
            }
            else
            {
                label2.ForeColor = Color.Red;
                Thread.Sleep(100);
                label2.ForeColor = Color.Black;
            }
        }

        private async void ViewersList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ViewersList.SelectedItem != null)
            {
                using (WebClient wc = new WebClient())
                {
                    Utilities.Twitch.User.Rootobject user = JsonConvert.DeserializeObject<Utilities.Twitch.User.Rootobject>(await wc.DownloadStringTaskAsync("https://api.twitch.tv/kraken/users/" + ViewersList.SelectedItem.ToString()));
                    UserInformation userinfo;
                    try
                    {
                        userinfo = new UserInformation(user.logo, user.display_name, sessionUsers[user.name][0], sessionUsers[user.name][1]);
                    }
                    catch (KeyNotFoundException)
                    {
                        userinfo = new UserInformation(user.logo, user.display_name, int.Parse(DateTime.Now.ToString("MMddHHmm")), 0);
                    }
                    userinfo.Show();
                }
            }
        }

        private void ChatBox_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void VersionLabel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/JewsOfHazard/JewBot9K/releases");
        }

        private void JewBot9K_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void JewBot9K_Load(object sender, EventArgs e)
        {

        }
    }
}
