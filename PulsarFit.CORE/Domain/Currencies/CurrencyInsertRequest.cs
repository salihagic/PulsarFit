using System.ComponentModel.DataAnnotations;
using PulsarFit.COMMON.Helpers;

namespace PulsarFit.CORE.Domain
{
    public class CurrencyInsertRequest
    {
        [Required(ErrorMessage = nameof(Localizer.Required_field))]
        public string Code { get; set; }
        public string Symbol { get; set; }
        [Required(ErrorMessage = nameof(Localizer.Required_field))]
        public string Name { get; set; }
    }
}
