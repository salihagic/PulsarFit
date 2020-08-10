using PulsarFit.CORE.Helpers;
using static PulsarFit.CORE.Constants.Enumerations;

namespace PulsarFit.CORE.Domain
{
    public class PlanUpdateRequest : BaseUpdateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public PlanLevel PlanLevel { get; set; }
        public StrengthLevel StrengthLevel { get; set; }
        public CardioLevel CardioLevel { get; set; }
        public double Price { get; set; }
        public bool IsPublic { get; set; }
        public int TrainerId { get; set; }
        public int MultimediaId { get; set; }
    }
}
