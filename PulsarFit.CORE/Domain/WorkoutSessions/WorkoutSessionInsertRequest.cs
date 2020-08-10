using System;

namespace PulsarFit.CORE.Domain
{
    public class WorkoutSessionInsertRequest
    {
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public int UserId { get; set; }
        public int WorkoutExerciseId { get; set; }
    }
}
