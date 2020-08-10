using System.Collections.Generic;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int? CurrencyId { get; set; }

        public Currency Currency { get; set; }
        public IEnumerable<City> Cities { get; set; }
    }
}