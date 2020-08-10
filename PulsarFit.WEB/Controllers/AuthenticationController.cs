using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using PulsarFit.COMMON.Helpers;
using PulsarFit.DAL.Helpers;
using PulsarFit.CORE.Domain;
using PulsarFit.DAL.Services;

namespace PulsarFit.WEB.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : BaseController
    {
        private IUsersService _usersService;

        public AuthenticationController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _usersService = serviceProvider.GetService<IUsersService>();
        }

        public IActionResult Login()
        {
            return View(new UserAuthenticateRequest());
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserAuthenticateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            try
            {
                var user = await _usersService.Authenticate(request);
                HttpContext.ReSetJwtCookie(await _usersService.GenerateJwtByUserId(user.Id), AppSettings.JwtSettings.JWTExpirationInDays);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(Localizer.Login_error, Localizer.Invalid_username_or_password);
            }

            return View(request);
        }

        [HttpGet, AllowAnonymous, Route("AuthenticateWithFacebook"), Transaction]
        public async Task<IActionResult> AuthenticateWithFacebook([FromQuery] UserAuthenticateWithFacebookRequest request)
        {
            var user = await _usersService.AuthenticateWithFacebook(request);

            HttpContext.ReSetJwt(await _usersService.GenerateJwtByUserId(user.Id));

            return Ok(user);
        }

        [HttpGet, AllowAnonymous, Route("AuthenticateWithGoogle"), Transaction]
        public async Task<IActionResult> AuthenticateWithGoogle([FromQuery] UserAuthenticateWithGoogleRequest request)
        {
            var user = await _usersService.AuthenticateWithGoogle(request);

            HttpContext.ReSetJwt(await _usersService.GenerateJwtByUserId(user.Id));

            return Ok(user);
        }

        public IActionResult Register()
        {
            return View(new UserRegisterRequest());
        }

        [HttpPost, AllowAnonymous, Route("Register"), Transaction]
        public async Task<IActionResult> Register([FromQuery] UserRegisterRequest request)
        {
            var user = await _usersService.Register(request);

            HttpContext.ReSetJwt(await _usersService.GenerateJwtByUserId(user.Id));

            return Ok(user);
        }

        public IActionResult Logout()
        {
            HttpContext.ClearTokenCookie();
            return RedirectToAction("Login", "Authentication");
        }

        public IActionResult UnauthorizedAccess() => View();
        public IActionResult UnauthorizedAccessTrialPeriodExpired() => View();
    }
}