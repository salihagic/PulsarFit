using System;

namespace PulsarFit.CORE.Domain
{
    public class UserSessionInsertRequest
    {
        public DateTime TokenCreatedAt { get; set; }
        public string IpAddress { get; set; }
        public string DeviceName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
    }
}