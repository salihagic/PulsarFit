using Pulsar.EntityFrameworkCore.BaseService;
using PulsarFit.CORE.Domain;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.DAL.Services
{
    public class UserRolesAuthorizationResolver : IPulsarAuthorizationResolver<UserRole, ExecutionUser> {}
}
