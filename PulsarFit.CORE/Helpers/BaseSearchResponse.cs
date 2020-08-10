using Pulsar.EntityFrameworkCore.BaseService;

namespace PulsarFit.CORE.Helpers
{
    public class BaseSearchResponse<TSearchRequest, TEntityDTO> 
        : PulsarBaseSearchResponse<TSearchRequest, TEntityDTO> 
        where TSearchRequest : PulsarBaseSearchRequest, new()
        where TEntityDTO : class
    { }
}
