using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JewBot9K
{
    public partial class Form1 : Form
    {

        private string AuthorizeUrl = "https://api.twitch.tv/kraken/oauth2/authorize?response_type=token&client_id=f9zg203ybd5xm8vzpl69nllx9d1amf1&redirect_uri=http://jewsofhazard.com/oauth&scope=user_read+user_blocks_read+user_blocks_edit+channel_editor+channel_commercial+channel_subscriptions+chat_login+channel_check_subscription";

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://mega.nz/#F!bxoVxCBK!9SXCXc32PoUJbGxmNGoy5Q");
        }
    }
}
