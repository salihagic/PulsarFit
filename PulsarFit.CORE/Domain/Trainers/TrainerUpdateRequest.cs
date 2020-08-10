using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class TrainerUpdateRequest : BaseUpdateRequest
    {
        public string LicenseNumber { get; set; }
        public int UserId { get; set; }
    }
}
