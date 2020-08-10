using System.Collections.Generic;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class ExerciseCategoryDTO : BaseDTO
    {
        public string Name { get; set; }

        public IEnumerable<ExerciseDTO> Exercises { get; set; }
    }
}
