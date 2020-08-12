using HyperQL;
using System.ComponentModel.DataAnnotations;
using PulsarFit.COMMON.Helpers;

namespace PulsarFit.CORE.Helpers
{
    public class BaseUpdateRequest : IUpdateRequestBase
    {
        [Required(ErrorMessage = nameof(Localizer.Required_field))]
        public int Id { get; set; }
    }
}
