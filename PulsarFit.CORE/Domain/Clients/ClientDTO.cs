using System;
using System.Collections.Generic;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class ClientDTO : BaseDTO
    {
        public double Price { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public bool Active { get; set; }
        public int UserId { get; set; }
        public int TrainerId { get; set; }

        public UserDTO User { get; set; }
        public TrainerDTO Trainer { get; set; }
        public IEnumerable<ClientPlanDTO> ClientPlans { get; set; }
    }
}
