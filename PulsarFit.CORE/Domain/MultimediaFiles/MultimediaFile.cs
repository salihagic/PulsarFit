using Pulsar.MultimediaFileProvider.Client;
using PulsarFit.CORE.Helpers;
using System.Collections.Generic;

namespace PulsarFit.CORE.Domain
{
    public class MultimediaFile : BaseEntity
    {
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Blurhash { get; set; }
        public double SizeMB { get; set; }
        public PulsarEnumerations.MultimediaFileTypes MultimediaFileType { get; set; }
        public PulsarEnumerations.MultimediaFileFormats MultimediaFileFormat { get; set; }
        public bool IsPublic { get; set; }

        public IEnumerable<Exercise> Exercises { get; set; }
        public IEnumerable<Plan> Plans { get; set; }
        public IEnumerable<Workout> Workouts { get; set; }
    }
}