using HyperQL;
using System;
using PulsarFit.CORE.Domain;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.DAL.Services
{
    public class WorkoutsAuthorizationResolver : IAuthorizationResolver<Workout, ExecutionUser>
    {
        public bool IsRecordOwner(IServiceProvider serviceProvider, Workout entity, ExecutionUser executionUser = null)
        {
            return executionUser == null || entity.TrainerId == executionUser.Id;
        }

        public bool IsAuthorizedToGet(IServiceProvider serviceProvider, Workout entity, ExecutionUser executionUser = null)
        {
            return (entity.IsPublic && !entity.IsDeleted) || IsRecordOwner(serviceProvider, entity, executionUser);
        }
    }
}
