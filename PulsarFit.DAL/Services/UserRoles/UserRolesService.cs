using System;
using PulsarFit.CORE.Domain;

namespace PulsarFit.DAL.Services
{
    public class UserRolesService 
        : BaseCrudService<
            UserRole, 
            UserRoleInsertRequest, 
            UserRoleUpdateRequest, 
            UserRoleSearchRequest, 
            UserRoleSearchResponse, 
            UserRoleDTO
            >, IUserRolesService
    {
        public UserRolesService(IServiceProvider serviceProvider) : base(serviceProvider){ }
    }
}
