namespace JewBot9K.Utilities.Twitch
{
    public class LiveViewers
    {
        public class Rootobject
        {
            public _Links _links { get; set; }
            public int chatter_count { get; set; }
            public Chatters chatters { get; set; }
        }

        public class _Links
        {
        }

        public class Chatters
        {
            public string[] moderators { get; set; }
            public object[] staff { get; set; }
            public object[] admins { get; set; }
            public object[] global_mods { get; set; }
            public string[] viewers { get; set; }
        }
    }

}
