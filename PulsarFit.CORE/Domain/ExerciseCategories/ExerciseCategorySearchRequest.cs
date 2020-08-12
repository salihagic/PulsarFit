using HyperQL;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class ExerciseCategorySearchRequest : BaseSearchRequest
    {
        public string Name { get; set; }

        public ExerciseSearchRequest Exercises { get; set; }

        [Include]
        public bool IncludeExercises { get; set; }
    }
}
