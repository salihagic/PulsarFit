namespace PulsarFit.CORE.Helpers
{
    public class FacebookUser
    {
        public string id { get; set; }
        public string name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }

        public Picture picture { get; set; }

        public class Picture
        {
            public Data data { get; set; }

            public class Data
            {
                public string url { get; set; }
            }
        }
    }
}
