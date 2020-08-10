using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PulsarFit.API.Helpers.ErrorHandling;
using PulsarFit.COMMON.Configuration;
using PulsarFit.COMMON.Helpers;
using System.Text;

namespace PulsarFit.API.Helpers
{
    public static class ServiceConfigurator 
    {
        public static void Configure(IServiceCollection services)
        {
            var appSettings = services.BuildServiceProvider().GetRequiredService<AppSettings>();

            ConfigureOtherServices(services);
            ConfigureLocalization(services);
            ConfigureAuth(services);

            services.AddCors();
            services.AddControllers(x => x.Filters.Add<ErrorFilter>())
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        static void ConfigureOtherServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CORE.Helpers.Mapper).Assembly);
        }

        static void ConfigureAuth(IServiceCollection services)
        {
            var appSettings = services.BuildServiceProvider().GetRequiredService<AppSettings>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var key = Encoding.ASCII.GetBytes(appSettings.JwtSettings.JWTSecret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
        }

        static void ConfigureLocalization(IServiceCollection services)
        {
            services.AddLocalization(x => x.ResourcesPath = "Resources");
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(Localizer.supportedCultures[0]);
                options.SupportedCultures = Localizer.supportedCultures;
                options.SupportedUICultures = Localizer.supportedCultures;
            });

            services.AddScoped<Localizer>();
        }
    }
}
