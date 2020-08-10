using PulsarFit.CORE.Helpers;
using System.Collections.Generic;

namespace PulsarFit.CORE.Domain
{
    public class CityDTO : BaseDTO
    {
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int CountryId { get; set; }

        public CountryDTO Country { get; set; }
        public IEnumerable<UserDTO> Users { get; set; }
    }
}
