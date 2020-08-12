using HyperQL;
using System;
using PulsarFit.CORE.Domain;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.DAL.Services
{
    public class CountriesAuthorizationResolver : IAuthorizationResolver<Country, ExecutionUser> 
    {
        public bool IsAuthorizedToGet(IServiceProvider serviceProvider, Country entity, ExecutionUser executionUser = null)
        {
            return true;
        }
    }
}
