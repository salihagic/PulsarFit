using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PulsarFit.COMMON.Configuration;

namespace PulsarFit.API
{
    public class Startup
    {
        IConfiguration _configuration;
        IWebHostEnvironment _environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _environment = environment;
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(_configuration.GetSection("AppSettings"));
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<AppSettings>>().Value);

            PulsarFit.COMMON.Helpers.ServiceConfigurator.Configure(services);
            PulsarFit.DAL.Helpers.ServiceConfigurator.Configure(services, _configuration, _environment);
            PulsarFit.API.Helpers.ServiceConfigurator.Configure(services);

            PulsarFit.DAL.Helpers.DbInitializer.Seed(services.BuildServiceProvider());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
