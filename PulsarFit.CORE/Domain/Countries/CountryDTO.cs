using System.Collections.Generic;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class CountryDTO : BaseDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? CurrencyId { get; set; }

        public CurrencyDTO Currency { get; set; }
        public IEnumerable<CityDTO> Cities { get; set; }
    }
}
