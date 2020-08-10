using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class ClientPlanDTO : BaseDTO
    {
        public double Price { get; set; }
        public double PercentageFinished { get; set; }
        public int ClientId { get; set; }
        public int PlanId { get; set; }

        public ClientDTO Client { get; set; }
        public PlanDTO Plan { get; set; }
    }
}
