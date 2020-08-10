using Pulsar.EntityFrameworkCore.BaseService;
using System;
using PulsarFit.CORE.Domain;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.DAL.Services
{
    public class MultimediaFilesAuthorizationResolver : IPulsarAuthorizationResolver<MultimediaFile, ExecutionUser>
    {
        public bool IsAuthorizedToGet(IServiceProvider serviceProvider, MultimediaFile entity, ExecutionUser executionUser = null)
        {
            return true;
        }
    }
}
