using HyperQL;
using System;
using PulsarFit.CORE.Domain;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.DAL.Services
{
    public class LanguagesAuthorizationResolver : IAuthorizationResolver<Language, ExecutionUser>
    {
        public bool IsAuthorizedToGet(IServiceProvider serviceProvider, Language entity, ExecutionUser executionUser = null)
        {
            return true;
        }
    }
}
