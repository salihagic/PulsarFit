using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class UserSettingDTO : BaseDTO
    {
        public bool IsProfilePublic { get; set; }
        public bool IsSidebarCollapsedWeb { get; set; }
        public bool IsTrialPeriodActive { get; set; }
        public bool IsGolderUser { get; set; }
        public int UserId { get; set; }

        public UserDTO User { get; set; }
    }
}
