using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class PlanTagUpdateRequest : BaseUpdateRequest
    {
        public string Name { get; set; }
        public int PlanId { get; set; }
    }
}
