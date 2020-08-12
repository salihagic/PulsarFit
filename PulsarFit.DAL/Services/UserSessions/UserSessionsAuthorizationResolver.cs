using HyperQL;
using PulsarFit.CORE.Domain;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.DAL.Services
{
    public class UserSessionsAuthorizationResolver : IAuthorizationResolver<UserSession, ExecutionUser> {}
}
