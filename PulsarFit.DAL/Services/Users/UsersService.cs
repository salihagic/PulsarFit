using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PulsarFit.COMMON.Configuration;
using PulsarFit.COMMON.Services;
using PulsarFit.CORE.Domain;
using PulsarFit.CORE.Helpers;
using PulsarFit.DAL.EF;
using static PulsarFit.CORE.Constants.Enumerations;

namespace PulsarFit.DAL.Services
{
    public class UsersService 
        : BaseCrudService<
            User, 
            UserInsertRequest, 
            UserUpdateRequest, 
            UserSearchRequest, 
            UserSearchResponse, 
            UserDTO
            >, IUsersService
    {
        private DatabaseContext _databaseContext;
        private AppSettings _appSettings;
        private ICryptographyService _cryptographyService;
        private IMultimediaFilesService _multimediaFilesService;

        public UsersService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _appSettings = serviceProvider.GetService<AppSettings>();
            _cryptographyService = serviceProvider.GetService<ICryptographyService>();
            _databaseContext = serviceProvider.GetService<DatabaseContext>();
            _multimediaFilesService = serviceProvider.GetService<IMultimediaFilesService>();
        }

        #region Auth

        public async Task<string> GenerateJwtByUserId(int pUserId)
        {
            var user = await base.GetById(pUserId,
                new UserSearchRequest 
                { 
                    IncludeUserSetting = true,
                    IncludeMultimediaFile = true,
                });

            return await GenerateJwtByUser(user);
        }

        public async Task<string> GenerateJwtByUser(UserDTO user)
        {
            var newUserSession = _databaseContext.UserSessions.Add(new UserSession
            {
                TokenCreatedAt = DateTime.Now,
                UserId = user.Id,
                IsActive = true
            }).Entity;

            await SaveChanges();

            var roles = _databaseContext.UserRoles.Where(x => x.UserId == user.Id).Select(x => x.Role).ToList();

            var claims = ExecutionUser.GetClaimsByUser(user, roles, newUserSession.Id, _appSettings.JwtSettings.TokenVersion).ToList();

            var newToken = _cryptographyService.GenerateJwt(claims.ToArray(), _appSettings.JwtSettings.JWTSecret);

            return newToken;
        }

        public async Task<UserDTO> Authenticate(UserAuthenticateRequest request)
        {
            var user = DbSet.FirstOrDefault(x => x.Username == request.Username);

            if (user == null)
                throw new NullReferenceException("Invalid username or password.");

            if (!_cryptographyService.Validate(request.Password, user.PasswordSalt, user.PasswordHash))
                throw new NullReferenceException("Invalid username or password.");

            var userDTO = Mapper.Map<UserDTO>(user);

            return userDTO;
        }

        public async Task<UserDTO> AuthenticateWithFacebook(UserAuthenticateWithFacebookRequest request)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"https://graph.facebook.com/v2.12/me?fields=name,first_name,last_name,email,picture&access_token={request.AccessToken}");

                if (!response.IsSuccessStatusCode)
                    throw new Exception("There was an error");

                var responseString = await response.Content.ReadAsStringAsync();

                var facebookUser = JsonConvert.DeserializeObject<FacebookUser>(responseString);

                if (DbSet.Any(x => x.FacebookId == facebookUser.id && !x.IsDeleted))
                {
                    return (await base.Get(new UserSearchRequest { FacebookId = facebookUser.id }))?.Items?.FirstOrDefault();
                }

                var user = new User
                {
                    FacebookId = facebookUser.id,
                    Username = facebookUser.name,
                    FirstName = facebookUser.first_name,
                    LastName = facebookUser.last_name,
                    Email = facebookUser.email,
                    MultimediaFile = new MultimediaFile
                    {
                        Url = facebookUser?.picture?.data?.url,
                        MultimediaFileType = Pulsar.MultimediaFileProvider.Client.PulsarEnumerations.MultimediaFileTypes.Image,
                    }
                };
                
                var userDTO = await base.Add(user);

                _databaseContext.UserSettings.Add(new UserSetting
                {
                    UserId = userDTO.Id,
                    IsSidebarCollapsedWeb = true
                });

                _databaseContext.UserRoles.Add(new UserRole
                {
                    UserId = userDTO.Id,
                    Role = Role.Client
                });

                await SaveChanges();

                return userDTO;
            }
        }

        public Task<UserDTO> AuthenticateWithGoogle(UserAuthenticateWithGoogleRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> Register(UserRegisterRequest request)
        {
            //var image = await _multimediaFilesService.Add(new MultimediaFileInsertRequest
            //{
            //    Base64File = Settings.Base64TestImage,
            //    IsPublic = true,
            //    MultimediaFileType = Pulsar.MultimediaFileProvider.Client.Enumerations.MultimediaFileTypes.Image
            //});

            var user = Mapper.Map<User>(request);

            var salt = _cryptographyService.GenerateSalt();

            user.PasswordHash = _cryptographyService.GenerateHash(request.Password, salt);
            user.PasswordSalt = salt;

            var userDTO = await base.Add(user);

            _databaseContext.UserSettings.Add(new UserSetting
            {
                UserId = userDTO.Id,
                IsSidebarCollapsedWeb = true
            });

            _databaseContext.UserRoles.Add(new UserRole
            {
                UserId = userDTO.Id,
                Role = Role.Client
            });

            await SaveChanges();

            return userDTO;
        }

        #endregion

        public async Task<UserUpdateProfileRequest> InitForUpdateProfile(int id, ExecutionUser executionUser = null)
        {
            var dto = await GetById(id, executionUser);
            return Mapper.Map<UserUpdateProfileRequest>(dto);
        }

        public async Task<UserDTO> UpdateProfile(UserUpdateProfileRequest request, ExecutionUser executionUser = null)
        {
            var entity = DbSet.First(x => x.Id == request.Id);

            Mapper.Map(request, entity);

            if (!string.IsNullOrEmpty(request.Password))
            {
                entity.PasswordHash = _cryptographyService.GenerateHash(request.Password, entity.PasswordSalt);
            }

            return await Update(entity, executionUser);
        }

        public override async Task<UserDTO> Add<TExecutionUser>(User entity, TExecutionUser executionUser = null)
        {
            var salt = _cryptographyService.GenerateSalt();

            entity.PasswordHash = _cryptographyService.GenerateHash(entity.PasswordHash, salt);
            entity.PasswordSalt = salt;

            var userDTO = await base.Add(entity, executionUser);

            _databaseContext.UserSettings.Add(new UserSetting
            {
                UserId = userDTO.Id,
                IsSidebarCollapsedWeb = true
            });

            await SaveChanges();

            return userDTO;
        }

        public override async Task<UserDTO> Add<TExecutionUser>(UserInsertRequest request, TExecutionUser executionUser = null)
        {
            var userDTO = await base.Add(request, executionUser);

            if (request.Roles != null && request.Roles.Count() > 0)
            {
                _databaseContext.UserRoles.AddRange(request.Roles.Select(x => new UserRole
                {
                    UserId = userDTO.Id,
                    Role = x
                }));

                await SaveChanges();
            }

            return userDTO;
        }

        public override async Task<UserUpdateRequest> InitForUpdate<TExecutionUser>(int id, TExecutionUser executionUser = null)
        {
            var updateRequest = await base.InitForUpdate(id, executionUser);

            updateRequest.Roles = _databaseContext.UserRoles.Where(x => x.UserId == updateRequest.Id && !x.IsDeleted).Select(x => x.Role).ToList();

            return updateRequest;
        }

        public override async Task<UserDTO> Update<TExecutionUser>(UserUpdateRequest request, TExecutionUser executionUser = null)
        {
            var entity = DbSet.First(x => x.Id == request.Id);

            Mapper.Map(request, entity);

            if (!string.IsNullOrEmpty(request.Password))
            {
                entity.PasswordHash = _cryptographyService.GenerateHash(request.Password, entity.PasswordSalt);
            }

            var currentUserRoles = _databaseContext.UserRoles.Where(x => x.UserId == request.Id && !x.IsDeleted).ToList();
            var currentUserRoleIds = currentUserRoles.Select(x => x.Id).ToList();
            var currentRoleIds = currentUserRoles.Select(x => x.Role).ToList();

            var roleIdsToAdd = request.Roles.Where(x => !currentRoleIds.Contains(x)).ToList();

            if (roleIdsToAdd != null && roleIdsToAdd.Count > 0)
            {
                _databaseContext.UserRoles.AddRange(roleIdsToAdd.Select(x => new UserRole
                {
                    UserId = entity.Id,
                    Role = x
                }));
            }

            var userRolesToDelete = currentUserRoles.Where(x => !request.Roles.Contains(x.Role)).ToList();

            if(userRolesToDelete != null && userRolesToDelete.Count > 0)
            {
                userRolesToDelete.ForEach(x => x.IsDeleted = true);
            }

            // if the roles are updated then regenerate jwt for every user session (every token/device user is currently logged in with)
            if ((roleIdsToAdd != null && roleIdsToAdd.Count > 0) || (userRolesToDelete != null && userRolesToDelete.Count > 0)) 
            {
                _databaseContext.UserSessions
                    .Where(x => x.UserId == request.Id && !x.IsDeleted)
                    .ToList()
                    .ForEach(x => x.ShouldRegenerateToken = true);
            }

            await SaveChanges();

            return await Update(entity, executionUser);
        }
    }
}