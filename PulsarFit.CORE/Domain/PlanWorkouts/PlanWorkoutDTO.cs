using System.Collections.Generic;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class PlanWorkoutDTO : BaseDTO
    {
        public int OrderNumber { get; set; }
        public int PlanId { get; set; }
        public int WorkoutId { get; set; }

        public PlanDTO Plan { get; set; }
        public WorkoutDTO Workout { get; set; }
    }
}
