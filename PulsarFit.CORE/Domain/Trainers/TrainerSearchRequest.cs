using Pulsar.EntityFrameworkCore.Extensions;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class TrainerSearchRequest : BaseSearchRequest
    {
        public string LicenseNumber { get; set; }
        public int UserId { get; set; }

        public UserSearchRequest User { get; set; }
        public ClientSearchRequest Clients { get; set; }
        public ExerciseSearchRequest Exercises { get; set; }
        public PlanSearchRequest Plans { get; set; }

        [Include]
        public bool IncludeUser { get; set; }
        [Include]
        public bool IncludeClients { get; set; }
        [Include]
        public bool IncludeExercises { get; set; }
        [Include]
        public bool IncludePlans { get; set; }
    }
}
