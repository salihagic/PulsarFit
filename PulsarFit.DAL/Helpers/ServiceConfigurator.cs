using Microsoft.Extensions.DependencyInjection;
using Pulsar.MultimediaFileProvider.Client;
using PulsarFit.CORE.Domain;
using PulsarFit.CORE.Helpers;
using PulsarFit.DAL.Services;
using Pulsar.EntityFrameworkCore.BaseService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using PulsarFit.DAL.EF;
using Microsoft.EntityFrameworkCore;
using PulsarFit.COMMON.Configuration;

namespace PulsarFit.DAL.Helpers
{
    public static class ServiceConfigurator
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            var appSettings = services.BuildServiceProvider().GetRequiredService<AppSettings>();

            ConfigureDatabase(services, configuration, environment);

            ConfigureAuthorizationResolversAndServices(services);

            services.Configure<PulsarMultimediaFileProviderOptions>(options =>
            {
                options.ApiUrl = appSettings.PulsarMultimediaFileProviderSettings.ApiUrl;
                options.Jwt = appSettings.PulsarMultimediaFileProviderSettings.Jwt;
            });

            services.AddScoped<IPulsarMultimediaFileProvider, PulsarMultimediaFileProvider>();
        }

        static void ConfigureDatabase(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            var connectionString = string.Empty;
            if (environment.IsDevelopment())
                connectionString = configuration.GetConnectionString("PulsarFit_development");
            if (environment.IsProduction())
                connectionString = configuration.GetConnectionString("PulsarFit_production");

            services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connectionString));
        }

        static void ConfigureAuthorizationResolversAndServices(IServiceCollection services)
        {
            services.AddScoped<ICitiesService, CitiesService>();
            services.AddScoped<IPulsarAuthorizationResolver<City, ExecutionUser>, CitiesAuthorizationResolver>();
            
            services.AddScoped<ICountriesService, CountriesService>();
            services.AddScoped<IPulsarAuthorizationResolver<Country, ExecutionUser>, CountriesAuthorizationResolver>();
            
            services.AddScoped<ICurrenciesService, CurrenciesService>();
            services.AddScoped<IPulsarAuthorizationResolver<Currency, ExecutionUser>, CurrenciesAuthorizationResolver>();
            
            services.AddScoped<IExercisesService, ExercisesService>();
            services.AddScoped<IPulsarAuthorizationResolver<Exercise, ExecutionUser>, ExercisesAuthorizationResolver>();
            
            services.AddScoped<ILanguagesService, LanguagesService>();
            services.AddScoped<IPulsarAuthorizationResolver<Language, ExecutionUser>, LanguagesAuthorizationResolver>();

            services.AddScoped<IMultimediaFilesService, MultimediaFilesService>();
            services.AddScoped<IPulsarAuthorizationResolver<MultimediaFile, ExecutionUser>, MultimediaFilesAuthorizationResolver>();
            
            services.AddScoped<IPlansService, PlansService>();
            services.AddScoped<IPulsarAuthorizationResolver<Plan, ExecutionUser>, PlansAuthorizationResolver>();

            services.AddScoped<IUserRolesService, UserRolesService>();
            services.AddScoped<IPulsarAuthorizationResolver<UserRole, ExecutionUser>, UserRolesAuthorizationResolver>();

            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IPulsarAuthorizationResolver<User, ExecutionUser>, UsersAuthorizationResolver>();

            services.AddScoped<IUserSessionsService, UserSessionsService>();
            services.AddScoped<IPulsarAuthorizationResolver<UserSession, ExecutionUser>, UserSessionsAuthorizationResolver>();

            services.AddScoped<IUserSettingsService, UserSettingsService>();
            services.AddScoped<IPulsarAuthorizationResolver<UserSetting, ExecutionUser>, UserSettingsAuthorizationResolver>();

            services.AddScoped<IWorkoutsService, WorkoutsService>();
            services.AddScoped<IPulsarAuthorizationResolver<Workout, ExecutionUser>, WorkoutsAuthorizationResolver>();
        }
    }
}
