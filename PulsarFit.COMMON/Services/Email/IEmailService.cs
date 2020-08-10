using PulsarFit.COMMON.Configuration;

namespace PulsarFit.COMMON.Services
{
    public interface IEmailService
    {
        void Send(EmailSettings emailSettings, string to, string subject, string body);
    }
}
