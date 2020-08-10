using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class WorkoutExerciseUpdateRequest : BaseUpdateRequest
    {
        public int? NumberOfRepetitions { get; set; }
        public int? NumberOfCalories { get; set; }
        public int? DurationInSeconds { get; set; }
        public int OrderNumber { get; set; }
        public int WorkoutId { get; set; }
        public int ExerciseId { get; set; }
    }
}
