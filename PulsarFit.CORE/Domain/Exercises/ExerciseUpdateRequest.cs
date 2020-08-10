using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class ExerciseUpdateRequest : BaseUpdateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public int TrainerId { get; set; }
        public int ExerciseCategoryId { get; set; }
        public int MultimediaFileId { get; set; }
    }
}
