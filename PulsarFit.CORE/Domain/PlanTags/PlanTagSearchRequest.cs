using HyperQL;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class PlanTagSearchRequest : BaseSearchRequest
    {
        public string Name { get; set; }
        public int PlanId { get; set; }

        public PlanSearchRequest Plan { get; set; }

        [Include]
        public bool IncludePlan { get; set; }
    }
}
