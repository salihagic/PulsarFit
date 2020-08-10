using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using PulsarFit.COMMON.Configuration;
using PulsarFit.CORE.Domain;
using PulsarFit.DAL.Services;

namespace PulsarFit.DAL.Services
{
    public class UserSettingsService 
        : BaseCrudService<
            UserSetting, 
            UserSettingInsertRequest, 
            UserSettingUpdateRequest, 
            UserSettingSearchRequest, 
            UserSettingSearchResponse, 
            UserSettingDTO
            >, IUserSettingsService
    {
        protected AppSettings AppSettings { get; }

        public UserSettingsService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            AppSettings = serviceProvider.GetService<AppSettings>();
        }

        public async Task<bool> IsAccessAllowedForUser(int pUserId)
        {
            var userSettings = DbSet.FirstOrDefault(x => x.UserId == pUserId && !x.IsDeleted);

            //For some users there is a special treatment
            if (userSettings.IsGolderUser)
                return true;

            //If trial period has expired
            if (userSettings.IsTrialPeriodActive && (DateTime.Now - userSettings.CreatedAt).TotalHours >= AppSettings.BusinessLogicSettings.TrialPeriodDurationHours)
                return false;

            //TODO: other conditions for IsAccessAllowedForUser here 
            //...

            return true;
        }

        public async Task ToggleIsSidebarCollapsedWeb(int pUserId)
        {
            var userSettings = DbSet.FirstOrDefault(x => x.UserId == pUserId && !x.IsDeleted);

            if (userSettings != null)
            {
                userSettings.IsSidebarCollapsedWeb = !userSettings.IsSidebarCollapsedWeb;
                await SaveChanges();
            }
        }
    }
}