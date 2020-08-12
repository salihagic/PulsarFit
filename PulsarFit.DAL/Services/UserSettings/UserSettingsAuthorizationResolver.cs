using HyperQL;
using System;
using PulsarFit.CORE.Domain;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.DAL.Services
{
    public class UserSettingsAuthorizationResolver : IAuthorizationResolver<UserSetting, ExecutionUser>
    {
        public bool IsRecordOwner(IServiceProvider serviceProvider, UserSetting entity, ExecutionUser executionUser = null)
        {
            return executionUser == null || executionUser.Id == entity.UserId;
        }
    }
}
