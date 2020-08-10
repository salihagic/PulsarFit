using PulsarFit.CORE.Helpers;
using static PulsarFit.CORE.Constants.Enumerations;

namespace PulsarFit.CORE.Domain
{
    public class UserRole : BaseEntity
    {
        public int UserId { get; set; }
        public Role Role { get; set; }

        public User User { get; set; }
    }
}
