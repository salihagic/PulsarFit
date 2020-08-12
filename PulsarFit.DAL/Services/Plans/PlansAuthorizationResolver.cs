using HyperQL;
using System;
using PulsarFit.CORE.Domain;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.DAL.Services
{
    public class PlansAuthorizationResolver : IAuthorizationResolver<Plan, ExecutionUser>
    {
        public bool IsRecordOwner(IServiceProvider serviceProvider, Plan entity, ExecutionUser executionUser = null)
        {
            return executionUser == null || entity.TrainerId == executionUser.Id;
        }

        public bool IsAuthorizedToGet(IServiceProvider serviceProvider, Plan entity, ExecutionUser executionUser = null)
        {
            return (entity.IsPublic && !entity.IsDeleted) || IsRecordOwner(serviceProvider, entity, executionUser);
        }
    }
}
