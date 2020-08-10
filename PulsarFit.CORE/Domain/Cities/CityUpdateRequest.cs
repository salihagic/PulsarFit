using System.ComponentModel.DataAnnotations;
using PulsarFit.COMMON.Helpers;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class CityUpdateRequest : BaseUpdateRequest
    {
        [Required(ErrorMessage = nameof(Localizer.Required_field))]
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int CountryId { get; set; }
    }
}
