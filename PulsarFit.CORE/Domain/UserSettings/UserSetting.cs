using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class UserSetting : BaseEntity
    {
        public bool IsProfilePublic { get; set; }
        public bool IsSidebarCollapsedWeb { get; set; }
        public bool IsTrialPeriodActive { get; set; }
        public bool IsGolderUser { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
    }
}