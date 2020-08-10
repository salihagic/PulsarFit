using Microsoft.AspNetCore.Http;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.WEB.Helpers.Auth
{
    public static class Authentication
    {
        public static ExecutionUser CurrentExecutionUser(this HttpContext httpContext)
        {
            if (!ExecutionUser.IsValidUser(httpContext.User))
                return null;

            return new ExecutionUser(httpContext.User);
        }
    }
}
