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
    }
}
