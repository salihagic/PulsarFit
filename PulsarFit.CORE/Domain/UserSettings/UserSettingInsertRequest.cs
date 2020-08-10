namespace PulsarFit.CORE.Domain
{
    public class UserSettingInsertRequest
    {
        public bool IsProfilePublic { get; set; }
        public bool IsSidebarCollapsedWeb { get; set; }
        public bool IsTrialPeriodActive { get; set; }
        public bool IsGolderUser { get; set; }
        public int UserId { get; set; }
    }
}
