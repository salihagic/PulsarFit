using HyperQL;
using PulsarFit.CORE.Helpers;
using static PulsarFit.CORE.Constants.Enumerations;

namespace PulsarFit.CORE.Domain
{
    public class UserRoleSearchRequest : BaseSearchRequest
    {
        public int UserId { get; set; }
        public Role Role { get; set; }

        public UserSearchRequest User { get; set; }

        [Include]
        public bool IncludeUser { get; set; }
    }
}
