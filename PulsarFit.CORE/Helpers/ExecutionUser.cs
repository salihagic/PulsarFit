using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using PulsarFit.COMMON.Configuration;
using PulsarFit.CORE.Domain;
using static PulsarFit.CORE.Constants.Enumerations;

namespace PulsarFit.CORE.Helpers
{
    public class ExecutionUser
    {
        public ExecutionUser() {}

        public ExecutionUser(ClaimsPrincipal claimsPrincipal)
        {
            Id = int.Parse(claimsPrincipal.FindFirst(CustomClaimTypes.Id)?.Value);
            
            Username = claimsPrincipal.FindFirst(CustomClaimTypes.Username)?.Value;
            
            FirstName = claimsPrincipal.FindFirst(CustomClaimTypes.FirstName)?.Value;
            
            LastName = claimsPrincipal.FindFirst(CustomClaimTypes.LastName)?.Value;
            
            Gender = string.IsNullOrEmpty(claimsPrincipal.FindFirst(CustomClaimTypes.Gender)?.Value) ? (Gender?)null : Enum.Parse<Gender>(claimsPrincipal.FindFirst(CustomClaimTypes.Gender)?.Value);
            
            ProfilePhotoUrl = claimsPrincipal.FindFirst(CustomClaimTypes.ProfilePhotoUrl)?.Value;
            
            SessionId = int.Parse(claimsPrincipal.FindFirst(CustomClaimTypes.SessionId)?.Value);
            
            TokenVersion = int.Parse(claimsPrincipal.FindFirst(CustomClaimTypes.TokenVersion)?.Value);

            var userSettingsString = claimsPrincipal.FindFirst(CustomClaimTypes.UserSettings)?.Value;
            UserSettings = !string.IsNullOrEmpty(userSettingsString) ? JsonConvert.DeserializeObject<UserSettingDTO>(userSettingsString) : null;

            var rolesString = claimsPrincipal.FindFirst(CustomClaimTypes.Roles)?.Value;
            Roles = !string.IsNullOrEmpty(rolesString) ? rolesString.Split(',')?.ToList()?.Select(x => Enum.Parse<Role>(x))?.ToList() : new List<Role>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender? Gender { get; set; }
        public string ProfilePhotoUrl { get; set; }
        public int SessionId { get; set; }
        public int TokenVersion { get; set; }
        public UserSettingDTO UserSettings { get; set; }
        public List<Role> Roles { get; set; }

        public static Claim[] GetClaimsByUser(UserDTO user, List<Role> roleIds, int sessionId, int tokenVersion)
        {
            try
            {
                var claims = new List<Claim>();

                claims.Add(new Claim(CustomClaimTypes.Id, user.Id.ToString()));
                claims.Add(new Claim(CustomClaimTypes.Username, user.Username ?? string.Empty));
                claims.Add(new Claim(CustomClaimTypes.FirstName, user.FirstName ?? string.Empty));
                claims.Add(new Claim(CustomClaimTypes.LastName, user.LastName ?? string.Empty));
                claims.Add(new Claim(CustomClaimTypes.Gender, user.Gender.ToString()));
                claims.Add(new Claim(CustomClaimTypes.ProfilePhotoUrl, user.MultimediaFile?.Url));
                claims.Add(new Claim(CustomClaimTypes.SessionId, sessionId.ToString()));
                claims.Add(new Claim(CustomClaimTypes.TokenVersion, tokenVersion.ToString()));
                claims.Add(new Claim(CustomClaimTypes.UserSettings, user.UserSetting != null ? JsonConvert.SerializeObject(user.UserSetting, PulsarFit.COMMON.Helpers.Extensions.JsonSerializerSettings) : ""));
                claims.Add(new Claim(CustomClaimTypes.Roles, string.Join(',', roleIds ?? new List<Role>())));

                return claims.ToArray();
            }
            catch(Exception e)
            {

            }

            return null;
        }

        public static bool IsValidUser(ClaimsPrincipal claimsPrincipal)
        {
            int.TryParse(claimsPrincipal.FindFirst(CustomClaimTypes.Id)?.Value, out var userId);
            return userId != 0;
        }
    }
}
