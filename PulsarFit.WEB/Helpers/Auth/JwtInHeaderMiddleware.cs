using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace PulsarFit.WEB.Helpers.Auth
{
    public class JwtInHeaderMiddleware
    {
        RequestDelegate _next;

        public JwtInHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var jwt = context.Request.Cookies["Authorization"];

            if (jwt != null)
                context.Request.Headers.Append("Authorization", jwt);

            await _next.Invoke(context);
        }
    }
}
