using Pulsar.EntityFrameworkCore.BaseService;
using System;
using PulsarFit.CORE.Domain;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.DAL.Services
{
    public class CurrenciesAuthorizationResolver : IPulsarAuthorizationResolver<Currency, ExecutionUser>
    {
        public bool IsAuthorizedToGet(IServiceProvider serviceProvider, Currency entity, ExecutionUser executionUser = null)
        {
            return true;
        }
    }
}
