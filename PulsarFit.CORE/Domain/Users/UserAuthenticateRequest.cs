namespace PulsarFit.CORE.Domain
{
    public class UserAuthenticateRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Pulsar.EntityFrameworkCore.BaseService.PulsarPagination PulsarPagination { get; set; }
    }
}
