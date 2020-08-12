using HyperQL;
using System;
using PulsarFit.CORE.Domain;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.DAL.Services
{
    public class MultimediaFilesAuthorizationResolver : IAuthorizationResolver<MultimediaFile, ExecutionUser>
    {
        public bool IsAuthorizedToGet(IServiceProvider serviceProvider, MultimediaFile entity, ExecutionUser executionUser = null)
        {
            return true;
        }
    }
}
