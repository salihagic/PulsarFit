using Pulsar.EntityFrameworkCore.Extensions;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class CurrencySearchRequest : BaseSearchRequest
    {
        public string Code { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }

        public CountrySearchRequest Countries { get; set; }

        [Include]
        public bool IncludeCountries { get; set; }
    }
}
