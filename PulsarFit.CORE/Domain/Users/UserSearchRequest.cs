using Pulsar.EntityFrameworkCore.Extensions;
using PulsarFit.CORE.Helpers;
using static PulsarFit.CORE.Constants.Enumerations;

namespace PulsarFit.CORE.Domain
{
    public class UserSearchRequest : BaseSearchRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FacebookId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender? Gender { get; set; }
        public int? CityId { get; set; }
        public int? MultimediaFileId { get; set; }

        public CitySearchRequest City { get; set; }
        public MultimediaFileSearchRequest MultimediaFile { get; set; }
        public UserSettingSearchRequest UserSetting { get; set; }
        public TrainerSearchRequest Trainer { get; set; }
        public UserRoleSearchRequest UserRoles { get; set; }
        public ClientSearchRequest Clients { get; set; }
        public WorkoutSessionSearchRequest WorkoutSessions { get; set; }

        [Include]
        public bool IncludeCity { get; set; }
        [Include]
        public bool IncludeUserSetting { get; set; }
        [Include]
        public bool IncludeUserRoles { get; set; }
        [Include]
        public bool IncludeClients { get; set; }       
        [Include]
        public bool IncludeWorkoutSessions { get; set; }
        [Include]
        public bool IncludeMultimediaFile { get; set; }
    }
}
