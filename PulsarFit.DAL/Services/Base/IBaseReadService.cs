﻿using HyperQL;
using PulsarFit.CORE.Helpers;

namespace PulsarFit.DAL.Services
{
    public interface IBaseReadService<TEntity, TSearchRequest, TSearchResponse, TEntityDTO>
        : IReadServiceBase<TEntity, TSearchRequest, TSearchResponse, TEntityDTO>
        where TEntity : BaseEntity,
        new() where TSearchRequest : BaseSearchRequest,
        new() where TSearchResponse : BaseSearchResponse<TSearchRequest, TEntityDTO>,
        new() where TEntityDTO : class {}
}
