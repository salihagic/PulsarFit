using Microsoft.Extensions.DependencyInjection;
using PulsarFit.CORE.Domain;
using PulsarFit.DAL.Services;
using System;

namespace PulsarFit.API.Controllers
{
    public class UserSettingsController
        : BaseCrudController<
            UserSetting,
            UserSettingInsertRequest,
            UserSettingUpdateRequest,
            UserSettingSearchRequest,
            UserSettingSearchResponse,
            UserSettingDTO
            >
    {
        public UserSettingsController(IServiceProvider serviceProvider) 
            : base(serviceProvider, serviceProvider.GetService<IUserSettingsService>()) { }
    }
}
