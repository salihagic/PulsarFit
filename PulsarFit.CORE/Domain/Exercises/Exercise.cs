using PulsarFit.CORE.Helpers;
using System.Collections.Generic;

namespace PulsarFit.CORE.Domain
{
    public class Exercise : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public int TrainerId { get; set; }
        public int ExerciseCategoryId { get; set; }
        public int MultimediaFileId { get; set; }

        public Trainer Trainer { get; set; }
        public ExerciseCategory ExerciseCategory { get; set; }
        public MultimediaFile MultimediaFile { get; set; }
        public IEnumerable<WorkoutExercise> WorkoutExercises { get; set; }
    }
}