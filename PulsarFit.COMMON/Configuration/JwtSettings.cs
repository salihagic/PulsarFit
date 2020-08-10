using System;

namespace PulsarFit.COMMON.Configuration
{
    public class JwtSettings
    {
        public string JWTSecret { get; set; }
        public int JWTExpirationInDays { get; set; }
        public int TokenVersion { get; set; }
    }
}
