using Microsoft.Extensions.DependencyInjection;
using PulsarFit.CORE.Domain;
using PulsarFit.DAL.Services;
using System;

namespace PulsarFit.API.Controllers
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
        public UsersController(IServiceProvider serviceProvider) 
            : base(serviceProvider, serviceProvider.GetService<IUsersService>()) { }
    }
}
