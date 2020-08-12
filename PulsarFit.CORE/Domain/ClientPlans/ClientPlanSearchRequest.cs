using HyperQL;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class ClientPlanSearchRequest : BaseSearchRequest
    {
        public double Price { get; set; }
        public double PercentageFinished { get; set; }
        public int ClientId { get; set; }
        public int PlanId { get; set; }

        public ClientSearchRequest Client { get; set; }
        public PlanSearchRequest Plan { get; set; }

        [Include]
        public bool IncludeClient { get; set; }
        [Include]
        public bool IncludePlan { get; set; }
    }
}
