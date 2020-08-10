using Microsoft.Extensions.DependencyInjection;
using PulsarFit.CORE.Domain;
using PulsarFit.DAL.Services;
using System;

namespace PulsarFit.API.Controllers
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
        public UserSessionsController(IServiceProvider serviceProvider) 
            : base(serviceProvider, serviceProvider.GetService<IUserSessionsService>()) { }
    }
}
