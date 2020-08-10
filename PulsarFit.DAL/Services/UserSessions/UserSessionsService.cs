using PulsarFit.CORE.Domain;
using PulsarFit.DAL.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PulsarFit.DAL.Services
{
    public class UserSessionsService 
        : BaseCrudService<
            UserSession, 
            UserSessionInsertRequest, 
            UserSessionUpdateRequest, 
            UserSessionSearchRequest, 
            UserSessionSearchResponse, 
            UserSessionDTO
            >, IUserSessionsService
    {

        public UserSessionsService(IServiceProvider serviceProvider) : base(serviceProvider) {}

        public async Task<bool> IsSessionActive(int pSessionId)
        {
            return DbSet.Any(x => x.Id == pSessionId && !x.IsDeleted);
        }

        public async Task<bool> IsUserSessionOwner(int pUserId, int pSessionId)
        {
            return DbSet.Any(x => x.UserId == pUserId && x.Id == pSessionId);
        }

        public async Task<bool> ShouldRegenerateToken(int pSessionId)
        {
            return DbSet.Any(x => x.Id == pSessionId && x.ShouldRegenerateToken);
        }
    }
}
