using Pulsar.EntityFrameworkCore.BaseService;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.DAL.Services
{
    public interface IBaseCrudService<TEntity, TInsertRequest, TUpdateRequest, TSearchRequest, TSearchResponse, TEntityDTO>
        : IPulsarBaseCrudService<TEntity, TInsertRequest, TUpdateRequest, TSearchRequest, TSearchResponse, TEntityDTO>,
          IBaseReadService<TEntity, TSearchRequest, TSearchResponse, TEntityDTO>
        where TEntity : BaseEntity,
        new() where TInsertRequest : class,
        new() where TUpdateRequest : BaseUpdateRequest,
        new() where TSearchRequest : BaseSearchRequest,
        new() where TSearchResponse : BaseSearchResponse<TSearchRequest, TEntityDTO>,
        new() where TEntityDTO : class {}
}
