using PulsarFit.CORE.Domain;
using System.Threading.Tasks;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.DAL.Services
{
    public interface IUsersService 
        : IBaseCrudService<
            User, 
            UserInsertRequest, 
            UserUpdateRequest, 
            UserSearchRequest, 
            UserSearchResponse,
            UserDTO
            >
    {
        #region Auth

        public Task<UserDTO> Authenticate(UserAuthenticateRequest request);
        public Task<UserDTO> AuthenticateWithFacebook(UserAuthenticateWithFacebookRequest request);
        public Task<UserDTO> AuthenticateWithGoogle(UserAuthenticateWithGoogleRequest request);
        public Task<string> GenerateJwtByUserId(int pUserId);
        public Task<string> GenerateJwtByUser(UserDTO user);

        #endregion

        public Task<UserDTO> Register(UserRegisterRequest request);
        public Task<UserUpdateProfileRequest> InitForUpdateProfile(int id, ExecutionUser executionUser = null);
        public Task<UserDTO> UpdateProfile(UserUpdateProfileRequest request, ExecutionUser executionUser = null);
    }
}
