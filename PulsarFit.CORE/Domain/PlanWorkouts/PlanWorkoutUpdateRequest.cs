using System.ComponentModel.DataAnnotations;
using PulsarFit.COMMON.Helpers;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class PlanWorkoutUpdateRequest : BaseUpdateRequest
    {
        public int OrderNumber { get; set; }
        public int PlanId { get; set; }
        public int WorkoutId { get; set; }
    }
}
