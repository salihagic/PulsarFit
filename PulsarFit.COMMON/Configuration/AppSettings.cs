namespace PulsarFit.COMMON.Configuration
{
    public class AppSettings
    {
        public string WebUrl { get; set; }
        public string ApiUrl { get; set; }
        public string AppName { get; set; }
        public string CompanyName { get; set; }
        public Social Social { get; set; }
        public JwtSettings JwtSettings { get; set; }
        public EmailSettings EmailSettings { get; set; }
        public FilesSettings FilesSettings { get; set; }
        public BusinessLogicSettings BusinessLogicSettings { get; set; }
        public PulsarMultimediaFileProviderSettings PulsarMultimediaFileProviderSettings { get; set; }
    }
}
