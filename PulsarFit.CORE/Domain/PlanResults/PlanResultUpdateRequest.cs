﻿using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class PlanResultUpdateRequest : BaseUpdateRequest
    {
        public string Name { get; set; }
        public int PlanId { get; set; }
    }
}