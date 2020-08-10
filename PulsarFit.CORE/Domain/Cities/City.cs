using PulsarFit.CORE.Helpers;
using System.Collections.Generic;

namespace PulsarFit.CORE.Domain
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int CountryId { get; set; }

        public Country Country { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}