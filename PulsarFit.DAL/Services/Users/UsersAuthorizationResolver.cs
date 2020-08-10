using Pulsar.EntityFrameworkCore.BaseService;
using System;
using PulsarFit.CORE.Domain;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.DAL.Services
{
    public class UsersAuthorizationResolver : IPulsarAuthorizationResolver<User, ExecutionUser>
    {                                          
        public bool IsRecordOwner(IServiceProvider serviceProvider, User entity, ExecutionUser executionUser = null)
        {
            return (executionUser == null);
        }

        public bool IsAuthorizedToAdd(IServiceProvider serviceProvider, User entity, ExecutionUser executionUser = null)
        {
            return (executionUser == null);
        }

        public bool IsAuthorizedToGet(IServiceProvider serviceProvider, User entity, ExecutionUser executionUser = null)
        {
            return true;
        }

        public bool IsAuthorizedToUpdate(IServiceProvider serviceProvider, User entity, ExecutionUser executionUser = null)
        {
            return IsRecordOwner(serviceProvider, entity, executionUser);
        }

        public bool IsAuthorizedToDelete(IServiceProvider serviceProvider, User entity, ExecutionUser executionUser = null)
        {
            return IsRecordOwner(serviceProvider, entity, executionUser);
        }
    }
}
