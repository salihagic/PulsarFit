using PulsarFit.CORE.Helpers;
using System.Collections.Generic;

namespace PulsarFit.CORE.Domain
{
    public class WorkoutExercise : BaseEntity
    {
        public int? NumberOfRepetitions { get; set; }
        public int? NumberOfCalories { get; set; }
        public int? DurationInSeconds { get; set; }
        public int OrderNumber { get; set; }
        public int WorkoutId { get; set; }
        public int ExerciseId { get; set; }

        public Workout Workout { get; set; }
        public Exercise Exercise { get; set; }
        public IEnumerable<WorkoutSession> WorkoutSessions { get; set; }
    }
}