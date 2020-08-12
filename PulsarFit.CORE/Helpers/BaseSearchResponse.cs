using HyperQL;

namespace PulsarFit.CORE.Helpers
{
    public class BaseSearchResponse<TSearchRequest, TEntityDTO> 
        : SearchResponseBase<TSearchRequest, TEntityDTO> 
        where TSearchRequest : SearchRequestBase, new()
        where TEntityDTO : class
    { }
}
