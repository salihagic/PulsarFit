using System.Collections.Generic;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class WorkoutExerciseDTO : BaseDTO
    {
        public int? NumberOfRepetitions { get; set; }
        public int? NumberOfCalories { get; set; }
        public int? DurationInSeconds { get; set; }
        public int OrderNumber { get; set; }
        public int WorkoutId { get; set; }
        public int ExerciseId { get; set; }

        public WorkoutDTO Workout { get; set; }
        public ExerciseDTO Exercise { get; set; }
        public IEnumerable<WorkoutSessionDTO> WorkoutSessions { get; set; }
    }
}
