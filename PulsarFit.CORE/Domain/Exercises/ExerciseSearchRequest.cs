using PulsarFit.CORE.Helpers;
using Pulsar.EntityFrameworkCore.Extensions;

namespace PulsarFit.CORE.Domain
{
    public class ExerciseSearchRequest : BaseSearchRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public int TrainerId { get; set; }
        public int ExerciseCategoryId { get; set; }
        public int MultimediaFileId { get; set; }

        public TrainerSearchRequest Trainer { get; set; }
        public ExerciseCategorySearchRequest ExerciseCategory { get; set; }
        public MultimediaFileSearchRequest MultimediaFile { get; set; }
        public WorkoutExerciseSearchRequest WorkoutExercises { get; set; }

        [Include]
        public bool IncludeTrainer { get; set; }
        [Include]
        public bool IncludeExerciseCategory { get; set; }
        [Include]
        public bool IncludeMultimediaFile { get; set; }
        [Include]
        public bool IncludeWorkoutExercises { get; set; }
    }
}
