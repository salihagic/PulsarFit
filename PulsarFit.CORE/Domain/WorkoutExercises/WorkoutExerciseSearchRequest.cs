using PulsarFit.CORE.Helpers;
using Pulsar.EntityFrameworkCore.Extensions;

namespace PulsarFit.CORE.Domain
{
    public class WorkoutExerciseSearchRequest : BaseSearchRequest
    {
        public int? NumberOfRepetitions { get; set; }
        public int? NumberOfCalories { get; set; }
        public int? DurationInSeconds { get; set; }
        public int OrderNumber { get; set; }
        public int WorkoutId { get; set; }
        public int ExerciseId { get; set; }

        public WorkoutSearchRequest Workout { get; set; }
        public ExerciseSearchRequest Exercise { get; set; }
        public WorkoutSessionSearchRequest WorkoutSessions { get; set; }

        [Include]
        public bool IncludeWorkout { get; set; }
        [Include]
        public bool IncludeExercise { get; set; }
        [Include]
        public bool IncludeWorkoutSessions { get; set; }
    }
}
