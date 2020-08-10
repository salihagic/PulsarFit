using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class ClientPlanUpdateRequest : BaseUpdateRequest
    {
        public double Price { get; set; }
        public double PercentageFinished { get; set; }
        public int ClientId { get; set; }
        public int PlanId { get; set; }
    }
}
