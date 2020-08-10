using PulsarFit.CORE.Helpers;
using System;

namespace PulsarFit.CORE.Domain
{
    public class WorkoutSession : BaseEntity
    {
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public int UserId { get; set; }
        public int WorkoutExerciseId { get; set; }

        public User User { get; set; }
        public WorkoutExercise WorkoutExercise { get; set; }
    }
}