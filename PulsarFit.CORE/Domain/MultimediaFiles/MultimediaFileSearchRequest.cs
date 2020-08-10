using Pulsar.EntityFrameworkCore.Extensions;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class MultimediaFileSearchRequest : BaseSearchRequest
    {
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Blurhash { get; set; }
        public double SizeMB { get; set; }
        public Pulsar.MultimediaFileProvider.Client.PulsarEnumerations.MultimediaFileTypes MultimediaFileType { get; set; }
        public Pulsar.MultimediaFileProvider.Client.PulsarEnumerations.MultimediaFileFormats MultimediaFileFormat { get; set; }
        public bool IsPublic { get; set; }

        public ExerciseSearchRequest Exercises { get; set; }
        public PlanSearchRequest Plans { get; set; }
        public WorkoutSearchRequest Workouts { get; set; }

        [Include]
        public bool IncludeExercises { get; set; }
        [Include]
        public bool IncludePlans { get; set; }
        [Include]
        public bool IncludeWorkouts { get; set; }
    }
}
