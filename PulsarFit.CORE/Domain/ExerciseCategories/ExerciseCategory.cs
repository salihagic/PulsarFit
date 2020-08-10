using PulsarFit.CORE.Helpers;
using System.Collections.Generic;

namespace PulsarFit.CORE.Domain
{
    public class ExerciseCategory : BaseEntity
    {
        public string Name { get; set; }

        public IEnumerable<Exercise> Exercises { get; set; }
    }
}