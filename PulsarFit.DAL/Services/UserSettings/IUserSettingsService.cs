using System.Threading.Tasks;
using PulsarFit.CORE.Domain;
using PulsarFit.DAL.Services;

namespace PulsarFit.DAL.Services
{
    public interface IUserSettingsService 
        : IBaseCrudService<
            UserSetting, 
            UserSettingInsertRequest, 
            UserSettingUpdateRequest, 
            UserSettingSearchRequest, 
            UserSettingSearchResponse, 
            UserSettingDTO
            >
    {
        public Task<bool> IsAccessAllowedForUser(int pUserId);
        public Task ToggleIsSidebarCollapsedWeb(int pUserId);
    }
}
