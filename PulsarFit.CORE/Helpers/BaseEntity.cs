using Pulsar.EntityFrameworkCore.BaseService;
using System;

namespace PulsarFit.CORE.Helpers
{
    public class BaseEntity : PulsarBaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
