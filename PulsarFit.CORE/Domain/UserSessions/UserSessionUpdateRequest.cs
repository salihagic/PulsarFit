using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class UserSessionUpdateRequest : BaseUpdateRequest
    {
        public string DeviceName { get; set; }
        public bool ShouldRegenerateToken { get; set; }
        public bool IsActive { get; set; }
    }
}