using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using static PulsarFit.CORE.Constants.Enumerations;

namespace PulsarFit.WEB.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IServiceProvider serviceProvider) : base(serviceProvider) {}

        public IActionResult Index()
        {
            ResetNavigationStack();
                    
            if (CurrentExecutionUser.Roles.Contains(Role.Trainer))
                return View("IndexTrainer");
            if (CurrentExecutionUser.Roles.Contains(Role.Admin))
                return View("IndexAdmin");
            if (CurrentExecutionUser.Roles.Contains(Role.Superadmin))
                return View("IndexSuperadmin");

            return View();
        }

        public IActionResult ChangeLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}
