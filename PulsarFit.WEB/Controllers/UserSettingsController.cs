using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using PulsarFit.COMMON.Helpers;
using PulsarFit.CORE.Domain;
using PulsarFit.DAL.Services;

namespace PulsarFit.WEB.Controllers
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
        private IUsersService _usersService;
        private IUserSettingsService _userSettingsService;

        public UserSettingsController(IServiceProvider serviceProvider) : base(serviceProvider, serviceProvider.GetService<IUserSettingsService>()) 
        {
            _usersService = serviceProvider.GetService<IUsersService>();
            _userSettingsService = serviceProvider.GetService<IUserSettingsService>();
        }

        public async Task<IActionResult> ToggleIsSidebarCollapsedWeb()
        {
            await _userSettingsService.ToggleIsSidebarCollapsedWeb(CurrentExecutionUser.Id);
            HttpContext.ReSetJwtCookie(await _usersService.GenerateJwtByUserId(CurrentExecutionUser.Id), AppSettings.JwtSettings.JWTExpirationInDays);

            return Ok();
        }
    }
}
