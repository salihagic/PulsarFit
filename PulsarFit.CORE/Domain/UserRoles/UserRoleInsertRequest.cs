using static PulsarFit.CORE.Constants.Enumerations;

namespace PulsarFit.CORE.Domain
{
    public class UserRoleInsertRequest
    {
        public int UserId { get; set; }
        public Role Role { get; set; }
    }
}
