using System.ComponentModel.DataAnnotations;
using PulsarFit.COMMON.Helpers;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class CurrencyUpdateRequest : BaseUpdateRequest
    {
        [Required(ErrorMessage = nameof(Localizer.Required_field))]
        public string Code { get; set; }
        public string Symbol { get; set; }
        [Required(ErrorMessage = nameof(Localizer.Required_field))]
        public string Name { get; set; }
    }
}
