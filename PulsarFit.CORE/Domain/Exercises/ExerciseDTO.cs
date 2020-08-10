using System.Collections.Generic;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class ExerciseDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public int TrainerId { get; set; }
        public int ExerciseCategoryId { get; set; }
        public int MultimediaFileId { get; set; }

        public TrainerDTO Trainer { get; set; }
        public ExerciseCategoryDTO ExerciseCategory { get; set; }
        public MultimediaFileDTO MultimediaFile { get; set; }
        public IEnumerable<WorkoutExerciseDTO> WorkoutExercises { get; set; }
    }
}
