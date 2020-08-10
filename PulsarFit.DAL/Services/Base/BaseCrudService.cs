using Microsoft.Extensions.DependencyInjection;
using Pulsar.EntityFrameworkCore.BaseService;
using System;
using PulsarFit.CORE.Helpers;
using PulsarFit.DAL.EF;

namespace PulsarFit.DAL.Services
{
    public class BaseCrudService<TEntity, TInsertRequest, TUpdateRequest, TSearchRequest, TSearchResponse, TEntityDTO>
         : PulsarBaseCrudService<TEntity, TInsertRequest, TUpdateRequest, TSearchRequest, TSearchResponse, TEntityDTO>
              , IBaseCrudService<TEntity, TInsertRequest, TUpdateRequest, TSearchRequest, TSearchResponse, TEntityDTO>
        where TEntity : BaseEntity, new()
        where TInsertRequest : class, new()
        where TUpdateRequest : BaseUpdateRequest, new()
        where TSearchRequest : BaseSearchRequest, new()
        where TSearchResponse : BaseSearchResponse<TSearchRequest, TEntityDTO>, new()
        where TEntityDTO : class
    {
        public BaseCrudService(IServiceProvider serviceProvider) : base(serviceProvider, serviceProvider.GetService<DatabaseContext>()) { }
    }
}