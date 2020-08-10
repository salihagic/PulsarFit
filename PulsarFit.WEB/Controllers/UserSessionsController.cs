using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using PulsarFit.CORE.Domain;
using PulsarFit.DAL.Services;
using PulsarFit.WEB.Helpers;

namespace PulsarFit.WEB.Controllers
{
    public class UserSessionsController
        : BaseCrudController<
            UserSession,
            UserSessionInsertRequest,
            UserSessionUpdateRequest,
            UserSessionSearchRequest,
            UserSessionSearchResponse,
            UserSessionDTO
            >
    {
        public UserSessionsController(IServiceProvider serviceProvider) : base(serviceProvider, serviceProvider.GetService<IUserSessionsService>()) { }

        public async Task<IActionResult> IndexByUserId(int id) => View(id);
        public async Task<IActionResult> IndexByUserIdJson(UserSessionSearchRequest searchRequest)
        {
            searchRequest = searchRequest ?? new UserSessionSearchRequest();
            searchRequest.Pagination = Request.Query.GetPagination();
            var response = await _readService.Get(searchRequest, CurrentExecutionUserForRecordLevelAuth);

            return Ok(new
            {
                meta = new
                {
                    page = searchRequest.Pagination?.Page,
                    pages = searchRequest.Pagination?.TotalNumberOfPages,
                    perpage = searchRequest.Pagination?.Take,
                    total = searchRequest.Pagination?.TotalNumberOfRecords
                },
                data = response?.Items,
            });
        }
    }
}
