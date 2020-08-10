using PulsarFit.CORE.Domain;
using PulsarFit.DAL.Services;
using System.Threading.Tasks;

namespace PulsarFit.DAL.Services
{
    public interface IUserSessionsService 
        : IBaseCrudService<
            UserSession, 
            UserSessionInsertRequest, 
            UserSessionUpdateRequest, 
            UserSessionSearchRequest, 
            UserSessionSearchResponse,
            UserSessionDTO
            >
    {
        Task<bool> IsSessionActive(int pSessionId);
        Task<bool> IsUserSessionOwner(int pUserId, int pSessionId);
        Task<bool> ShouldRegenerateToken(int pSessionId);
    }
}
