using Pulsar.EntityFrameworkCore.Extensions;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class CitySearchRequest : BaseSearchRequest
    {
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int CountryId { get; set; }

        public CountrySearchRequest Country { get; set; }

        [Include]
        public bool IncludeCountry { get; set; }
    }
}
