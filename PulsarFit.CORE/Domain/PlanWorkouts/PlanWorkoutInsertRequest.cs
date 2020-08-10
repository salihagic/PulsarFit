using System.ComponentModel.DataAnnotations;
using PulsarFit.COMMON.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class PlanWorkoutInsertRequest
    {
        public int OrderNumber { get; set; }
        public int PlanId { get; set; }
        public int WorkoutId { get; set; }
    }
}
