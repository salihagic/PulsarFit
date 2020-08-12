using HyperQL;
using System;

namespace PulsarFit.CORE.Helpers
{
    public class BaseEntity : EntityBase
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
