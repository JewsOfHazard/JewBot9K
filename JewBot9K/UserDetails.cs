using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewBot9K.Utilities.Twitch
{
    public class User
    {
        public class Rootobject
        {
            public string type { get; set; }
            public string name { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public _Links _links { get; set; }
            public string logo { get; set; }
            public int _id { get; set; }
            public string display_name { get; set; }
            public string email { get; set; }
            public bool partnered { get; set; }
            public string bio { get; set; }
            public Notifications notifications { get; set; }
        }

        public class _Links
        {
            public string self { get; set; }
        }

        public class Notifications
        {
            public bool email { get; set; }
            public bool push { get; set; }
        }
    }


}
