using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class LanguageUpdateRequest : BaseUpdateRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
