using PulsarFit.CORE.Domain;

namespace PulsarFit.DAL.Services
{
    public interface IUserRolesService 
        : IBaseCrudService<
            UserRole, 
            UserRoleInsertRequest, 
            UserRoleUpdateRequest, 
            UserRoleSearchRequest, 
            UserRoleSearchResponse, 
            UserRoleDTO
            > {}
}
