using FirebaseNet.Messaging;
using PulsarFit.COMMON.Configuration;
using System.Threading.Tasks;

namespace PulsarFit.COMMON.Services
{
    public interface IFirebaseService
    {
        Task<IFCMResponse> Send(FirebaseMessage firebaseMessage);
    }
}
