using System.ComponentModel.DataAnnotations;
using PulsarFit.COMMON.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class CityInsertRequest
    {
        [Required(ErrorMessage = nameof(Localizer.Required_field))]
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int CountryId { get; set; }
    }
}
