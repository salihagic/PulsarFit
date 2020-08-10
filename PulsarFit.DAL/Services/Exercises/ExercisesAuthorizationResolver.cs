using Pulsar.EntityFrameworkCore.BaseService;
using System;
using PulsarFit.CORE.Domain;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.DAL.Services
{
    public class ExercisesAuthorizationResolver : IPulsarAuthorizationResolver<Exercise, ExecutionUser>
    {
        public bool IsRecordOwner(IServiceProvider serviceProvider, Exercise entity, ExecutionUser executionUser = null)
        {
            return executionUser == null || entity.TrainerId == executionUser.Id;
        }

        public bool IsAuthorizedToGet(IServiceProvider serviceProvider, Exercise entity, ExecutionUser executionUser = null)
        {
            return (entity.IsPublic && !entity.IsDeleted) || IsRecordOwner(serviceProvider, entity, executionUser);
        }
    }
}
