using PulsarFit.CORE.Helpers;
using System;
using System.Collections.Generic;

namespace PulsarFit.CORE.Domain
{
    public class Client : BaseEntity
    {
        public double Price { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public bool Active { get; set; }
        public int UserId { get; set; }
        public int TrainerId { get; set; }

        public User User { get; set; }
        public Trainer Trainer { get; set; }
        public IEnumerable<ClientPlan> ClientPlans { get; set; }
    }
}