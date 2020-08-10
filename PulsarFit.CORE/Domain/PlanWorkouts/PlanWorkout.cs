using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class PlanWorkout : BaseEntity
    {
        public int OrderNumber { get; set; }
        public int PlanId { get; set; }
        public int WorkoutId { get; set; }

        public Plan Plan { get; set; }
        public Workout Workout { get; set; }
    }
}