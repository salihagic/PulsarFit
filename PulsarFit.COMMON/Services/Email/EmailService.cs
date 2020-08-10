using PulsarFit.COMMON.Configuration;
using System.Net.Mail;

namespace PulsarFit.COMMON.Services
{
    public class EmailService : IEmailService
    {
        public void Send(EmailSettings emailSettings, string to, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient(emailSettings.MailServer);
            mail.From = new MailAddress(emailSettings.SenderEmail);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            smtpServer.Port = int.Parse(emailSettings.MailPort);
            smtpServer.Credentials = new System.Net.NetworkCredential(emailSettings.SenderEmail, emailSettings.SenderEmailPassword);
            smtpServer.EnableSsl = true;
            smtpServer.Send(mail);
        }
    }
}
