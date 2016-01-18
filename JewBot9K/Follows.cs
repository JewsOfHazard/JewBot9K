using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewBot9K.Utilities.Twitch
{
    class Follows
    {

        public class Rootobject
        {
            public Follow[] follows { get; set; }
            public int _total { get; set; }
            public _Links _links { get; set; }
            public string _cursor { get; set; }
        }

        public class _Links
        {
            public string self { get; set; }
            public string next { get; set; }
        }

        public class Follow
        {
            public DateTime created_at { get; set; }
            public _Links1 _links { get; set; }
            public bool notifications { get; set; }
            public User user { get; set; }
        }

        public class _Links1
        {
            public string self { get; set; }
        }

        public class User
        {
            public int _id { get; set; }
            public string name { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public _Links2 _links { get; set; }
            public string display_name { get; set; }
            public string logo { get; set; }
            public string bio { get; set; }
            public string type { get; set; }
        }

        public class _Links2
        {
            public string self { get; set; }
        }

    }
}
