using PulsarFit.CORE.Helpers;
using System.Collections.Generic;

namespace PulsarFit.CORE.Domain
{
    public class Trainer : BaseEntity
    {
        public string LicenseNumber { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public IEnumerable<Client> Clients { get; set; }
        public IEnumerable<Exercise> Exercises { get; set; }
        public IEnumerable<Plan> Plans { get; set; }
    }
}