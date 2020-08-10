using PulsarFit.CORE.Helpers;
using System.Collections.Generic;
using static PulsarFit.CORE.Constants.Enumerations;

namespace PulsarFit.CORE.Domain
{
    public class UserDTO : BaseDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender? Gender { get; set; }
        public int? CityId { get; set; }
        public int? MultimediaFileId { get; set; }

        public CityDTO City { get; set; }
        public MultimediaFileDTO MultimediaFile { get; set; }
        public UserSettingDTO UserSetting { get; set; }
        public TrainerDTO Trainer { get; set; }
        public IEnumerable<UserRoleDTO> UserRoles { get; set; }
    }
}
