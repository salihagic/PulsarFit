using System;
using PulsarFit.CORE.Helpers;
using HyperQL;

namespace PulsarFit.CORE.Domain
{
    public class UserSessionSearchRequest : BaseSearchRequest
    {
        public DateTime TokenCreatedAt { get; set; }
        public string IpAddress { get; set; }
        public string DeviceName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool ShouldRegenerateToken { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }

        public UserSearchRequest User { get; set; }

        [Include]
        public bool IncludeUser { get; set; }
    }
}