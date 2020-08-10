using System.Collections.Generic;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class LanguageDTO : BaseDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public IEnumerable<CountryDTO> Countries { get; set; }
    }
}
