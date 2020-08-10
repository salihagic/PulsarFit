using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using PulsarFit.COMMON.Helpers;
using PulsarFit.CORE.Domain;
using PulsarFit.DAL.Helpers;
using PulsarFit.DAL.Services;

namespace PulsarFit.API.Controllers
{   
    [AllowAnonymous]
    public class AuthenticationController : BaseController
    {
        private IUsersService _usersService;

        public AuthenticationController(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {
            _usersService = serviceProvider.GetService<IUsersService>();
        }

        [HttpPost, Route("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserAuthenticateRequest request)
        {
            var user = await _usersService.Authenticate(request);

            HttpContext.ReSetJwt(await _usersService.GenerateJwtByUserId(user.Id));

            return Ok(user);
        }

        [HttpPost, Route("AuthenticateWithFacebook"), Transaction]
        public async Task<IActionResult> AuthenticateWithFacebook(UserAuthenticateWithFacebookRequest request)
        {
            var user = await _usersService.AuthenticateWithFacebook(request);

            HttpContext.ReSetJwt(await _usersService.GenerateJwtByUser(user));

            return Ok(user);
        }

        [HttpPost, Route("AuthenticateWithGoogle"), Transaction]
        public async Task<IActionResult> AuthenticateWithGoogle(UserAuthenticateWithGoogleRequest request)
        {
            var user = await _usersService.AuthenticateWithGoogle(request);

            HttpContext.ReSetJwt(await _usersService.GenerateJwtByUser(user));

            return Ok(user);
        }        
        
        [HttpPost, Route("Register"), Transaction]
        public async Task<IActionResult> Register(UserRegisterRequest request)
        {
            var user = await _usersService.Register(request);

            HttpContext.ReSetJwt(await _usersService.GenerateJwtByUser(user));

            return Ok(user);
        }
    }
}
