using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using NToastNotify;
using System.Reflection;
using PulsarFit.COMMON.Configuration;
using PulsarFit.COMMON.Helpers;
using PulsarFit.WEB.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Localization;

namespace PulsarFit.WEB.Helpers
{
    public static class ServiceConfigurator
    {
        public static void Configure(IServiceCollection services)
        {
            var appSettings = services.BuildServiceProvider().GetRequiredService<AppSettings>();

            ConfigureOtherServices(services);
            ConfigureLocalization(services);
            ConfigureAuth(services);
            services.AddSession();

            services.AddCors();

            services.AddMvc().AddNewtonsoftJson(Extensions.MvcNewtonsoftJsonOptions).AddRazorRuntimeCompilation()
                .AddNToastNotifyToastr(new ToastrOptions
                {
                    ProgressBar = false,
                    PositionClass = ToastPositions.TopRight
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddDataAnnotationsLocalization(options =>
                {
                    var assemblyName = new AssemblyName(typeof(Localizer).GetTypeInfo().Assembly.FullName);
                    options.DataAnnotationLocalizerProvider = (type, factory) => factory.Create("Resource", assemblyName.Name);
                });
        }

        static void ConfigureOtherServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CORE.Helpers.Mapper).Assembly);

            services.AddScoped<DropdownHelper>();
            services.AddScoped<ViewHelper>();
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
