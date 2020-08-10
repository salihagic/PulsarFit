using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Pulsar.EntityFrameworkCore.Extensions;
using PulsarFit.COMMON.Configuration;
using PulsarFit.COMMON.Helpers;
using PulsarFit.DAL.Services;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static PulsarFit.CORE.Constants.Enumerations;

namespace PulsarFit.API.Helpers.Auth
{
    public class AuthorizationAttribute : TypeFilterAttribute 
    { 
        public AuthorizationAttribute(params Role[] roles) : base(typeof(AsyncActionFilter)) 
        {
            Arguments = new object[]{ roles };
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
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }

            //Check if current token is still valid in the database(if the session hasn't been terminated in the database)
            var userSessionsService = context.HttpContext.RequestServices.GetService<IUserSessionsService>();

            if (!(await userSessionsService.IsSessionActive(currentExecutionUser.SessionId)))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
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

                context.HttpContext.ReSetJwt(await usersService.GenerateJwtByUserId(currentExecutionUser.Id));
            }

            //Check if user has roles required to access the resources requested
            if (Roles.Count > 0 && !Roles.Any(x => currentExecutionUser.Roles?.Contains(x) ?? false))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }

            //Check if users trial period has expired and/or user has done all his responsibilities
            var userSettingsService = context.HttpContext.RequestServices.GetService<IUserSettingsService>();

            if (!(await userSettingsService.IsAccessAllowedForUser(currentExecutionUser.Id)))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.PaymentRequired;
                return;
            }

            //Successfully passed authorization
            await next();
        }
    }
}
