using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class UserSettingUpdateRequest : BaseUpdateRequest
    {
        public bool IsProfilePublic { get; set; }
        public bool IsSidebarCollapsedWeb { get; set; }
        public bool IsTrialPeriodActive { get; set; }
        public bool IsGolderUser { get; set; }
    }
}
