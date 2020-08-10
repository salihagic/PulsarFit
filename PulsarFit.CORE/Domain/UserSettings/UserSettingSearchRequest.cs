using Pulsar.EntityFrameworkCore.Extensions;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class UserSettingSearchRequest : BaseSearchRequest
    {
        public bool IsProfilePublic { get; set; }
        public bool IsSidebarCollapsedWeb { get; set; }
        public bool IsTrialPeriodActive { get; set; }
        public bool IsGolderUser { get; set; }
        public int UserId { get; set; }

        public UserSearchRequest User { get; set; }

        [Include]
        public bool IncludeUser { get; set; }
    }
}