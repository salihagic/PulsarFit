using Microsoft.Extensions.DependencyInjection;
using Pulsar.EntityFrameworkCore.BaseService;
using System;
using PulsarFit.CORE.Helpers;
using PulsarFit.DAL.EF;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PulsarFit.DAL.Services
{
    public class BaseReadService<TEntity, TSearchRequest, TSearchResponse, TEntityDTO>
        : PulsarBaseReadService<TEntity, TSearchRequest, TSearchResponse, TEntityDTO>
        , IBaseReadService<TEntity, TSearchRequest, TSearchResponse, TEntityDTO>
        where TEntity : BaseEntity,
        new() where TSearchRequest : BaseSearchRequest,
        new() where TSearchResponse : BaseSearchResponse<TSearchRequest, TEntityDTO>,
        new() where TEntityDTO : class 
    {
        public BaseReadService(IServiceProvider serviceProvider) : base(serviceProvider, serviceProvider.GetService<DatabaseContext>()) {}

        public override async Task<List<TEntityDTO>> GetItems<TExecutionUser>(TSearchRequest searchRequest = null, TExecutionUser executionUser = null)
        {
            try
            {
                return await base.GetItems(searchRequest, executionUser);
            }
            catch(Exception e)
            {
            }

            return null;
        }
    }
}