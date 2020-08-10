using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class ClientUpdateRequest : BaseUpdateRequest
    {
        public double Price { get; set; }
        public int UserId { get; set; }
        public int TrainerId { get; set; }
    }
}
