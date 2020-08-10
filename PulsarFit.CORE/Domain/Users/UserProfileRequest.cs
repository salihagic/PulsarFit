using System.ComponentModel.DataAnnotations;
using PulsarFit.COMMON.Helpers;
using PulsarFit.CORE.Helpers;
using static PulsarFit.CORE.Constants.Enumerations;

namespace PulsarFit.CORE.Domain
{
    public class UserUpdateProfileRequest : BaseUpdateRequest
    {
        [Required(ErrorMessage = nameof(Localizer.Required_field))]
        public string Username { get; set; }
        [Required(ErrorMessage = nameof(Localizer.Required_field))]
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmed { get; set; }
        [Required(ErrorMessage = nameof(Localizer.Required_field))]
        public string FirstName { get; set; }
        [Required(ErrorMessage = nameof(Localizer.Required_field))]
        public string LastName { get; set; }
        public Gender? Gender { get; set; }
        [Required(ErrorMessage = nameof(Localizer.Required_field))]
        public int? CityId { get; set; }
    }
}
