using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class CountryUpdateRequest : BaseUpdateRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? CurrencyId { get; set; }
    }
}
