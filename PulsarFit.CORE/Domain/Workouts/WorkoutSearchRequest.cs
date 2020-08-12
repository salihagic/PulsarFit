using HyperQL;
using PulsarFit.CORE.Helpers;
using static PulsarFit.CORE.Constants.Enumerations;

namespace PulsarFit.CORE.Domain
{
    public class WorkoutSearchRequest : BaseSearchRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public StrengthLevel StrengthLevel { get; set; }
        public CardioLevel CardioLevel { get; set; }
        public bool IsPublic { get; set; }
        public int TrainerId { get; set; }
        public int MultimediaFileId { get; set; }

        public TrainerSearchRequest Trainer { get; set; }
        public MultimediaFileSearchRequest MultimediaFile { get; set; }
        public PlanWorkoutSearchRequest PlanWorkouts { get; set; }
        public WorkoutExerciseSearchRequest WorkoutExercises { get; set; }

        [Include]
        public bool IncludeTrainer { get; set; }        
        [Include]
        public bool IncludeMultimediaFile { get; set; }
        [Include]
        public bool IncludePlanWorkouts { get; set; }
        [Include]
        public bool IncludeWorkoutExercises { get; set; }
    }
}
