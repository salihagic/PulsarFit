using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class PlanResult : BaseEntity
    {
        public string Name { get; set; }
        public int PlanId { get; set; }

        public Plan Plan { get; set; }
    }
}