using System.Collections.Generic;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class CurrencyDTO : BaseDTO
    {
        public string Code { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }

        public IEnumerable<CountryDTO> Countries { get; set; }
    }
}
