using Microsoft.AspNetCore.Http;
using Pulsar.MultimediaFileProvider.Client;
using System.Collections.Generic;

namespace PulsarFit.CORE.Domain
{
    public class MultimediaFileInsertRequest
    {
        public IFormFile FormFile { get; set; }
        public string Base64File { get; set; }
        public double QualityPercentage { get; set; }
        public PulsarEnumerations.MultimediaFileTypes MultimediaFileType { get; set; }
        public PulsarEnumerations.MultimediaFileFormats MultimediaFileFormat { get; set; }
        public bool IsPublic { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}
