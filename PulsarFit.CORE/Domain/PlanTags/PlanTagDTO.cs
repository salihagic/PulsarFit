using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class PlanTagDTO : BaseDTO
    {
        public string Name { get; set; }
        public int PlanId { get; set; }

        public PlanDTO Plan { get; set; }
    }
}
