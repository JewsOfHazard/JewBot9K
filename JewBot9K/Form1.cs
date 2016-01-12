using System;
using System.Windows.Forms;
using ChatSharp;
using JewBot9K.Utilities;
using System.Threading;
using Newtonsoft.Json;
using System.Net;

namespace JewBot9K
{
    public partial class Form1 : Form
    {

        // "https://api.twitch.tv/kraken/oauth2/authorize?response_type=token&client_id=f9zg203ybd5xm8vzpl69nllx9d1amf1&redirect_uri=http://jewsofhazard.com/oauth&scope=user_read+user_blocks_read+user_blocks_edit+channel_editor+channel_commercial+channel_subscriptions+chat_login+channel_check_subscription";

        Thread chatThread;
        Thread viewerThread;

        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //open versions
            System.Diagnostics.Process.Start("https://mega.nz/#F!bxoVxCBK!9SXCXc32PoUJbGxmNGoy5Q");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //open authorize form
            AuthorizeForm form = new AuthorizeForm();
            form.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //send irc message
            }
        }
        private void runIrc()
        {

            var client = new IrcClient("irc.twitch.tv", new IrcUser(Settings.username, Settings.username, Settings.oauth));

            client.ConnectionComplete += (s, e) => client.JoinChannel("#" + Settings.username);
            client.ConnectionComplete += (s, e) => Invoke((MethodInvoker)(() => label2.Text = "Connected"));
            client.ConnectionComplete += (s, e) => Invoke((MethodInvoker)(() => label2.Location = new System.Drawing.Point(25,88)));

            client.ChannelMessageRecieved += (s, e) => //holy shit the wrong spelling of received
            {
                //var channel = client.Channels[0];
                string message = e.IrcMessage.RawMessage;
                message = message.Substring(1);
                string user = message.Substring(0, message.IndexOf("!"));
                message = message.Substring(message.IndexOf(":") + 1);

                Invoke((MethodInvoker)(() => listBox2.Items.Add(user + ": " + message)));
                Invoke((MethodInvoker)(() => listBox2.SelectedIndex = listBox2.Items.Count - 1));
            };

            client.ConnectAsync();
            while (true) ;
        }

        private void updateViewers()
        {
            Utilities.Twitch.LiveViewers.Rootobject json;
            while (true)
            {
                using (WebClient wc = new WebClient())
                {
                    json = JsonConvert.DeserializeObject<Utilities.Twitch.LiveViewers.Rootobject>(wc.DownloadString("https://tmi.twitch.tv/group/user/" + Settings.username + "/chatters"));
                }
                Invoke((MethodInvoker)(() => listBox1.Items.Clear()));
                foreach (string item in json.chatters.viewers)
                {
                    Invoke((MethodInvoker)(() => listBox1.Items.Add(item)));
                }
                Thread.Sleep(10000);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Settings.isAuthorized && chatThread == null)
            {
                chatThread = new Thread(runIrc);
                viewerThread = new Thread(updateViewers);
                chatThread.Start();
                viewerThread.Start();
            }
            else if (!Settings.isAuthorized)
            {
                label2.Text = "Auth Needed";
            }
            else
            {
                //do nothing, they are connected and authorized
            }
        }
    }
}
