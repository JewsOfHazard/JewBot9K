using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin_Inferface
{
    interface Interface
    {
        string Name { get; }
        string Description { get; }
        Image icon { get; }
        Form settings_page { get; }
        
        // testname
        // this is a test plugin for the bot.
        // icon = refrence.image
        // settings_page = form1

        void messagearrived(string message, string username, string channel, DateTime time);
        void pingarrived(DateTime time);
        void modearrived(string perams, DateTime time);

        void user_joined(string username, string channel, DateTime time);
        void user_left(string username, string channel, DateTime time);
        void user_part(string username, string reason, DateTime time);
        
        void bot_channeljoined(string channel, DateTime time);
        void bot_messagesent(string message, string username, string channel, DateTime time);

        void twitch_commercial_started(DateTime time);
        void twitch_commercial_ended(DateTime time);
        void twitch_title_Changed(string title, DateTime time);
        void twitch_user_followed(string username, DateTime time); 

        void connected(DateTime time);
        void disconnected(DateTime time);
        void authorized(DateTime time);
        void deauthorized(DateTime time);
        void chatcleared(string chatlog, DateTime time);
        void slowmode_on(DateTime time);
        void slowmode_off(DateTime time);
        void submode_on(DateTime time);
        void submode_off(DateTime time);

        void plugin_enabled(string plugin_loc, DateTime time);
        void plugin_disabled(string plugin_loc, DateTime time);
    }
}
