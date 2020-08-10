using PulsarFit.CORE.Helpers;
using System.Collections.Generic;
using static PulsarFit.CORE.Constants.Enumerations;

namespace PulsarFit.CORE.Domain
{
    public class Workout : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public StrengthLevel StrengthLevel { get; set; }
        public CardioLevel CardioLevel { get; set; }
        public bool IsPublic { get; set; }
        public int TrainerId { get; set; }
        public int MultimediaFileId { get; set; }

        public Trainer Trainer { get; set; }
        public MultimediaFile MultimediaFile { get; set; }
        public IEnumerable<PlanWorkout> PlanWorkouts { get; set; }
        public IEnumerable<WorkoutExercise> WorkoutExercises { get; set; }
    }
}