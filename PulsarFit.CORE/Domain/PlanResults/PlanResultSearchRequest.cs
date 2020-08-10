using Pulsar.EntityFrameworkCore.Extensions;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class PlanResultSearchRequest : BaseSearchRequest
    {
        public string Name { get; set; }
        public int PlanId { get; set; }

        public PlanSearchRequest Plan { get; set; }

        [Include]
        public bool IncludePlan { get; set; }
    }
}
