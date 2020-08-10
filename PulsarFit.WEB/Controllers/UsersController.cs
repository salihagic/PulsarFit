using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using PulsarFit.COMMON.Helpers;
using PulsarFit.CORE.Domain;
using PulsarFit.DAL.Services;

namespace PulsarFit.WEB.Controllers
{
    public class UsersController
        : BaseCrudController<
            User,
            UserInsertRequest,
            UserUpdateRequest,
            UserSearchRequest,
            UserSearchResponse,
            UserDTO
            >
    {
        private ICitiesService _citiesService;
        private IUsersService _usersService;

        public UsersController(IServiceProvider serviceProvider) : base(serviceProvider, serviceProvider.GetService<IUsersService>())
        {
            _citiesService = serviceProvider.GetService<ICitiesService>();
            _usersService = serviceProvider.GetService<IUsersService>();
        }

        public async Task<IActionResult> EditProfile(int id)
        {
            var result = await _usersService.InitForUpdateProfile(id, CurrentExecutionUserForRecordLevelAuth);

            if (result.CityId.HasValue)
                ViewBag.SelectedCity = (await _citiesService.GetById(result.CityId.Value))?.Name;

            return View(result);
        }

        [HttpPut]
        public async Task<IActionResult> EditProfile(UserUpdateProfileRequest request)
        {
            if (request.CityId.HasValue)
                ViewBag.SelectedCity = (await _citiesService.GetById(request.CityId.Value))?.Name;

            if (!ModelState.IsValid)
                return View(request);

            try
            {
                await _usersService.UpdateProfile(request, CurrentExecutionUserForRecordLevelAuth);
                HttpContext.ReSetJwtCookie(await _usersService.GenerateJwtByUserId(CurrentExecutionUser.Id), AppSettings.JwtSettings.JWTExpirationInDays);
                Toast.AddSuccessToastMessage(Message_edit_success);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                Toast.AddErrorToastMessage(Message_edit_error);
            }
            return View(request);
        }

        public override async Task<IActionResult> Add(UserInsertRequest request)
        {
            if (request.CityId.HasValue)
                ViewBag.SelectedCity = (await _citiesService.GetById(request.CityId.Value))?.Name;

            return await base.Add(request);
        }

        public override async Task<IActionResult> Edit(int id, bool fullPage = true)
        {
            var result = await _crudService.InitForUpdate(id, CurrentExecutionUserForRecordLevelAuth);

            if (result.CityId.HasValue)
                ViewBag.SelectedCity = (await _citiesService.GetById(result.CityId.Value))?.Name;

            return View(result);
        }

        public override async Task<IActionResult> Edit(UserUpdateRequest request)
        {
            if (request.CityId.HasValue)
                ViewBag.SelectedCity = (await _citiesService.GetById(request.CityId.Value))?.Name;

            return await base.Edit(request);
        }
    }
}
