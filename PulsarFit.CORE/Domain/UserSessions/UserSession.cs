using PulsarFit.CORE.Helpers;
using System;

namespace PulsarFit.CORE.Domain
{
    public class UserSession : BaseEntity
    {
        public DateTime TokenCreatedAt { get; set; }
        public string IpAddress { get; set; }
        public string DeviceName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool ShouldRegenerateToken { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
    }
}