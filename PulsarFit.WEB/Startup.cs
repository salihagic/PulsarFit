using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using PulsarFit.COMMON.Configuration;
using PulsarFit.WEB.Helpers.Auth;

namespace PulsarFit.WEB
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
            PulsarFit.WEB.Helpers.ServiceConfigurator.Configure(services);

            PulsarFit.DAL.Helpers.DbInitializer.Seed(services.BuildServiceProvider());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy(app.ApplicationServices.GetService<IOptions<CookiePolicyOptions>>().Value);
            
            app.UseRouting();

            app.UseMiddleware<JwtInHeaderMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseRequestLocalization(app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value);
            app.UseNToastNotify();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
