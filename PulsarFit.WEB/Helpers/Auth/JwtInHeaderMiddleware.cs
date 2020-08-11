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
            //this is only for demonstration purposes, usually the line above is valid
            //context.Request.Headers.Append("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJJZCI6IjEiLCJVc2VybmFtZSI6ImRlbW8uc3VwZXJhZG1pbiIsIkZpcnN0TmFtZSI6IkRlbW8iLCJMYXN0TmFtZSI6IlN1cGVyYWRtaW4iLCJHZW5kZXIiOiJNYWxlIiwiUHJvZmlsZVBob3RvVXJsIjoiaHR0cHM6Ly9pbWFnZXMucGV4ZWxzLmNvbS9waG90b3MvNzM2NzE2L3BleGVscy1waG90by03MzY3MTYuanBlZz9hdXRvPWNvbXByZXNzJmNzPXRpbnlzcmdiJmRwcj0yJmg9NzUwJnc9MTI2MCIsIlNlc3Npb25JZCI6IjEzIiwiVG9rZW5WZXJzaW9uIjoiMiIsIlVzZXJTZXR0aW5ncyI6IntcImlzUHJvZmlsZVB1YmxpY1wiOmZhbHNlLFwiaXNTaWRlYmFyQ29sbGFwc2VkV2ViXCI6dHJ1ZSxcImlzVHJpYWxQZXJpb2RBY3RpdmVcIjpmYWxzZSxcImlzR29sZGVyVXNlclwiOmZhbHNlLFwidXNlcklkXCI6MSxcInVzZXJcIjp7XCJ1c2VybmFtZVwiOlwiZGVtby5zdXBlcmFkbWluXCIsXCJlbWFpbFwiOlwiZGVtby5zdXBlcmFkbWluQGV4YW1wbGUuY29tXCIsXCJmaXJzdE5hbWVcIjpcIkRlbW9cIixcImxhc3ROYW1lXCI6XCJTdXBlcmFkbWluXCIsXCJnZW5kZXJcIjoxLFwiY2l0eUlkXCI6MSxcIm11bHRpbWVkaWFGaWxlSWRcIjoxLFwiY2l0eVwiOm51bGwsXCJtdWx0aW1lZGlhRmlsZVwiOntcInVybFwiOlwiaHR0cHM6Ly9pbWFnZXMucGV4ZWxzLmNvbS9waG90b3MvNzM2NzE2L3BleGVscy1waG90by03MzY3MTYuanBlZz9hdXRvPWNvbXByZXNzJmNzPXRpbnlzcmdiJmRwcj0yJmg9NzUwJnc9MTI2MFwiLFwidGh1bWJuYWlsVXJsXCI6XCJodHRwczovL2ltYWdlcy5wZXhlbHMuY29tL3Bob3Rvcy83MzY3MTYvcGV4ZWxzLXBob3RvLTczNjcxNi5qcGVnP2F1dG89Y29tcHJlc3MmY3M9dGlueXNyZ2ImZHByPTImaD03NTAmdz0xMjYwXCIsXCJibHVyaGFzaFwiOm51bGwsXCJzaXplTUJcIjowLjAsXCJtdWx0aW1lZGlhRmlsZVR5cGVcIjowLFwibXVsdGltZWRpYUZpbGVGb3JtYXRcIjowLFwiaXNQdWJsaWNcIjpmYWxzZSxcImV4ZXJjaXNlc1wiOltdLFwicGxhbnNcIjpbXSxcIndvcmtvdXRzXCI6W10sXCJpZFwiOjF9LFwidHJhaW5lclwiOm51bGwsXCJ1c2VyUm9sZXNcIjpbXSxcImlkXCI6MX0sXCJpZFwiOjF9IiwiUm9sZXMiOiJTdXBlcmFkbWluIiwibmJmIjoxNTk3MDQ4NTcyLCJleHAiOjE1OTc2NTMzNzIsImlhdCI6MTU5NzA0ODU3Mn0.p9JnHOh-dDQvtPPU8wNb0JzlJJAUy2Q6E_rjbW648-g");

            await _next.Invoke(context);
        }
    }
}
