using Pulsar.MultimediaFileProvider.Client;
using System.ComponentModel.DataAnnotations;
using PulsarFit.COMMON.Helpers;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class MultimediaFileUpdateRequest : BaseUpdateRequest
    {
        [Required(ErrorMessage = nameof(Localizer.Required_field))]
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Blurhash { get; set; }
        public double SizeMB { get; set; }
        public PulsarEnumerations.MultimediaFileTypes MultimediaFileType { get; set; }
        public PulsarEnumerations.MultimediaFileFormats MultimediaFileFormat { get; set; }
        public bool IsPublic { get; set; }
    }
}
