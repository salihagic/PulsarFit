using HyperQL;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class PlanWorkoutSearchRequest : BaseSearchRequest
    {
        public int OrderNumber { get; set; }
        public int PlanId { get; set; }
        public int WorkoutId { get; set; }

        public PlanSearchRequest Plan { get; set; }
        public WorkoutSearchRequest Workout { get; set; }

        [Include]
        public bool IncludePlan { get; set; }
        [Include]
        public bool IncludeWorkout { get; set; }
    }
}
