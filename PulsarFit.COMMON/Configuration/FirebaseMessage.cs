namespace PulsarFit.COMMON.Configuration
{
    public class FirebaseMessage
    {
        /// <summary>
        /// Title of the notification, for chat it would be "SenderFirstName SenderLastName"
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Content of the notification
        /// </summary>
        public string Body { get; set; }
        public string[] DeviceTokens { get; set; }
        public string Type { get; set; }
        public string ServerApiKey { get; set; }
        public string Data { get; set; }
        /// <summary>
        /// Tag is used to specify one conversation, mobile apps keep only last message in the notification
        /// </summary>
        public string Tag { get; set; }
    }
}
