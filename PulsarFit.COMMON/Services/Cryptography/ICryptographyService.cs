using System.Security.Claims;

namespace PulsarFit.COMMON.Services
{
    public interface ICryptographyService
    {
        string GenerateHash(string value, string salt);

        bool Validate(string value, string salt, string hash) => GenerateHash(value, salt) == hash;

        string GenerateSalt();
        string GenerateJwt(Claim[] claims, string jwtSecret);
    }
}
