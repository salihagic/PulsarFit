using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class ClientPlan : BaseEntity
    {
        public double Price { get; set; }
        public double PercentageFinished { get; set; }
        public int ClientId { get; set; }
        public int PlanId { get; set; }

        public Client Client { get; set; }
        public Plan Plan { get; set; }
    }
}