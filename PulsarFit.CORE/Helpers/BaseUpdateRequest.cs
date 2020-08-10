using Pulsar.EntityFrameworkCore.BaseService;
using System.ComponentModel.DataAnnotations;
using PulsarFit.COMMON.Helpers;

namespace PulsarFit.CORE.Helpers
{
    public class BaseUpdateRequest : IPulsarBaseUpdateRequest
    {
        [Required(ErrorMessage = nameof(Localizer.Required_field))]
        public int Id { get; set; }
    }
}
