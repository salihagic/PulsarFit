using PulsarFit.CORE.Helpers;
using static PulsarFit.CORE.Constants.Enumerations;

namespace PulsarFit.CORE.Domain
{
    public class UserRoleDTO : BaseDTO
    {
        public int UserId { get; set; }
        public Role Role { get; set; }

        public UserDTO User { get; set; }
    }
}
