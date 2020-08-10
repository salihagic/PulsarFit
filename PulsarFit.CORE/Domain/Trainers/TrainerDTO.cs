using PulsarFit.CORE.Helpers;
using System.Collections.Generic;

namespace PulsarFit.CORE.Domain
{
    public class TrainerDTO : BaseDTO
    {
        public string LicenseNumber { get; set; }
        public int UserId { get; set; }

        public UserDTO User { get; set; }
        public IEnumerable<ClientDTO> Clients { get; set; }
        public IEnumerable<ExerciseDTO> Exercises { get; set; }
        public IEnumerable<PlanDTO> Plans { get; set; }
    }
}
