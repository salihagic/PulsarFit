using Microsoft.Extensions.DependencyInjection;
using PulsarFit.COMMON.Services;

namespace PulsarFit.COMMON.Helpers
{
    public static class ServiceConfigurator
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<ICryptographyService, CryptographyService>();
        }
    }
}
