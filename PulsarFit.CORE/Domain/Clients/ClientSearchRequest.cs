using HyperQL;
using PulsarFit.CORE.Helpers;
using System;

namespace PulsarFit.CORE.Domain
{
    public class ClientSearchRequest : BaseSearchRequest
    {
        public double Price { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public bool Active { get; set; }
        public int UserId { get; set; }
        public int TrainerId { get; set; }

        public UserSearchRequest User { get; set; }
        public TrainerSearchRequest Trainer { get; set; }
        public ClientPlanSearchRequest ClientPlans { get; set; }

        [Include]
        public bool IncludeUser { get; set; }
        [Include]
        public bool IncludeTrainer { get; set; }
        [Include]
        public bool IncludeClientPlans { get; set; }
    }
}
