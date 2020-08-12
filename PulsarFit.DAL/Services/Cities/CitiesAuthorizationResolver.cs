using HyperQL;
using System;
using PulsarFit.CORE.Domain;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.DAL.Services
{
    public class CitiesAuthorizationResolver : IAuthorizationResolver<City, ExecutionUser>
    {
        public bool IsAuthorizedToGet(IServiceProvider serviceProvider, City entity, ExecutionUser executionUser = null)
        {
            return true;
        }
    }
}
