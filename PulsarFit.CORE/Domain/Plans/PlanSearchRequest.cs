using Pulsar.EntityFrameworkCore.Extensions;
using PulsarFit.CORE.Helpers;
using static PulsarFit.CORE.Constants.Enumerations;

namespace PulsarFit.CORE.Domain
{
    public class PlanSearchRequest : BaseSearchRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public PlanLevel PlanLevel { get; set; }
        public StrengthLevel StrengthLevel { get; set; }
        public CardioLevel CardioLevel { get; set; }
        public double Price { get; set; }
        public bool IsPublic { get; set; }
        public int TrainerId { get; set; }
        public int MultimediaFileId { get; set; }

        public TrainerSearchRequest Trainer { get; set; }
        public MultimediaFileSearchRequest MultimediaFile { get; set; }
        public ClientPlanSearchRequest ClientPlans { get; set; }
        public PlanWorkoutSearchRequest PlanWorkouts { get; set; }
        public PlanResultSearchRequest PlanResults { get; set; }
        public PlanTagSearchRequest PlanTags { get; set; }

        [Include]
        public bool IncludeTrainer { get; set; }
        [Include]
        public bool IncludeMultimediaFile { get; set; }
        [Include]
        public bool IncludeClientPlans { get; set; }
        [Include]
        public bool IncludePlanWorkouts { get; set; }        
        [Include]
        public bool IncludePlanResults { get; set; }
        [Include]
        public bool IncludePlanTags { get; set; }
    }
}
