using Pulsar.EntityFrameworkCore.BaseService;
using System;
using PulsarFit.CORE.Domain;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.DAL.Services
{
    public class LanguagesAuthorizationResolver : IPulsarAuthorizationResolver<Language, ExecutionUser>
    {
        public bool IsAuthorizedToGet(IServiceProvider serviceProvider, Language entity, ExecutionUser executionUser = null)
        {
            return true;
        }
    }
}
