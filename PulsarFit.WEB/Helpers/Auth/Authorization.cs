using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using PulsarFit.COMMON.Configuration;
using PulsarFit.COMMON.Helpers;
using PulsarFit.DAL.Services;
using static PulsarFit.CORE.Constants.Enumerations;
using System.Collections.Generic;
using System.Linq;

namespace PulsarFit.WEB.Helpers.Auth
{
    public class AuthorizationAttribute : TypeFilterAttribute
    {
        public AuthorizationAttribute(params Role[] roles) : base(typeof(AsyncActionFilter))
        {
            Arguments = new object[] { roles };
        }
    }

    public class AsyncActionFilter : IAsyncActionFilter
    {
        public List<Role> Roles { get; set; }

        public AsyncActionFilter(Role[] roles)
        {
            Roles = roles?.ToList() ?? new List<Role>();
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //AllowAnonymous - skip authorization 
            if (context.HasAllowAnonymousAttribute())
            {
                await next();
                return;
            }

            //Check if there is a valid userId in jwt
            var currentExecutionUser = context.HttpContext.CurrentExecutionUser();

            if (currentExecutionUser == null)
            {
                context.Result = new RedirectToActionResult("Login", "Authentication", new { area = string.Empty });
                return;
            }

            //Check if current token is still valid in the database(if the session hasn't been terminated in the database)
            var userSessionsService = context.HttpContext.RequestServices.GetService<IUserSessionsService>();

            if (!(await userSessionsService.IsSessionActive(currentExecutionUser.SessionId)))
            {
                context.Result = new RedirectToActionResult("Login", "Authentication", new { area = string.Empty });
                return;
            }

            //Check if the user should regenerate token if there were changes to the data contained in the token
            var shouldRegenerateToken1 = await userSessionsService.ShouldRegenerateToken(currentExecutionUser.SessionId);

            //Check if the token has valid version
            var appSettings = context.HttpContext.RequestServices.GetService<AppSettings>();

            var shouldRegenerateToken2 = appSettings.JwtSettings.TokenVersion > currentExecutionUser.TokenVersion;

            if (shouldRegenerateToken1 || shouldRegenerateToken2)
            {
                var usersService = context.HttpContext.RequestServices.GetService<IUsersService>();

                context.HttpContext.ReSetJwtCookie(await usersService.GenerateJwtByUserId(currentExecutionUser.Id), appSettings.JwtSettings.JWTExpirationInDays);
            }

            //Check if user has roles required to access the resources requested
            if (Roles.Count > 0 && !Roles.Any(x => currentExecutionUser.Roles?.Contains(x) ?? false))
            {
                context.Result = new RedirectToActionResult("UnauthorizedAccess", "Authentication", new { area = string.Empty });
                return;
            }

            //Check if users trial period has expired and/or user has done all his responsibilities
            var userSettingsService = context.HttpContext.RequestServices.GetService<IUserSettingsService>();

            if (!(await userSettingsService.IsAccessAllowedForUser(currentExecutionUser.Id)))
            {
                context.Result = new RedirectToActionResult("UnauthorizedAccessTrialPeriodExpired", "Authentication", new { area = string.Empty });
                return;
            }

            //Successfully passed authorization
            await next();
        }
    }
}
