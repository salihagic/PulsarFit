using HyperQL;
using PulsarFit.CORE.Helpers;
using System;

namespace PulsarFit.CORE.Domain
{
    public class WorkoutSessionSearchRequest : BaseSearchRequest
    {
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public int UserId { get; set; }
        public int WorkoutExerciseId { get; set; }

        public UserSearchRequest User { get; set; }
        public WorkoutExerciseSearchRequest WorkoutExercise { get; set; }

        [Include]
        public bool IncludeUser { get; set; }
        [Include]
        public bool IncludeWorkoutExercise { get; set; }
    }
}
