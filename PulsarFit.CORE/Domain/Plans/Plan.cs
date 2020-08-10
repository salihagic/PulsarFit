using PulsarFit.CORE.Helpers;
using System.Collections.Generic;
using static PulsarFit.CORE.Constants.Enumerations;

namespace PulsarFit.CORE.Domain
{
    public class Plan : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public PlanLevel PlanLevel { get; set; }
        public StrengthLevel StrengthLevel { get; set; }
        public CardioLevel CardioLevel { get; set; }
        public double? Price { get; set; }
        public bool IsPublic { get; set; }
        public int TrainerId { get; set; }
        public int MultimediaFileId { get; set; }

        public Trainer Trainer { get; set; }
        public MultimediaFile MultimediaFile { get; set; }
        public IEnumerable<ClientPlan> ClientPlans { get; set; }
        public IEnumerable<PlanWorkout> PlanWorkouts { get; set; }
        public IEnumerable<PlanResult> PlanResults { get; set; }
        public IEnumerable<PlanTag> PlanTags { get; set; }
    }
}