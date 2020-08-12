using HyperQL;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class CountrySearchRequest : BaseSearchRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? CurrencyId { get; set; }
        
        public CurrencySearchRequest Currency { get; set; }
        public CitySearchRequest Cities { get; set; }

        [Include]
        public bool IncludeCurrency { get; set; }
        [Include]
        public bool IncludeCities { get; set; }
    }
}
