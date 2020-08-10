using System.Collections.Generic;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class Language : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public IEnumerable<Country> Countries { get; set; }
    }
}