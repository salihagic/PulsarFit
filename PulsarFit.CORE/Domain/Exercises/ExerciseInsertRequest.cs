namespace PulsarFit.CORE.Domain
{
    public class ExerciseInsertRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public int TrainerId { get; set; }
        public int ExerciseCategoryId { get; set; }
        public int MultimediaFileId { get; set; }
    }
}
