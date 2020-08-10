using FirebaseNet.Messaging;
using PulsarFit.COMMON.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PulsarFit.COMMON.Services
{

    public class FirebaseService : IFirebaseService
    {
        FCMClient _client;

        public FirebaseService(string serverApiKey)
        {
            _client = new FCMClient(serverApiKey);
        }

        public Task<IFCMResponse> Send(FirebaseMessage firebaseMessage)
        {
            try
            {
                return _client.SendMessageAsync(new Message
                {
                    RegistrationIds = firebaseMessage.DeviceTokens,

                    Data = new Dictionary<string, string>
                    {
                        { "body", firebaseMessage.Data },
                    },
                    Notification = new AndroidNotification
                    {
                        Title = firebaseMessage.Title,
                        Body = firebaseMessage.Body,
                        Sound = "defualt",
                        Tag = firebaseMessage.Tag
                    }
                });
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}
