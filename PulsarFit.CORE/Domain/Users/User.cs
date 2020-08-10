using System.Collections.Generic;
using PulsarFit.CORE.Helpers;
using static PulsarFit.CORE.Constants.Enumerations;

namespace PulsarFit.CORE.Domain
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string FacebookId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender? Gender { get; set; }
        public int? CityId { get; set; }
        public int? MultimediaFileId { get; set; }

        public City City { get; set; }
        public MultimediaFile MultimediaFile { get; set; }
        public UserSetting UserSetting { get; set; }
        public Trainer Trainer { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; }
        public IEnumerable<Client> Clients { get; set; }
        public IEnumerable<WorkoutSession> WorkoutSessions { get; set; }
    }
}