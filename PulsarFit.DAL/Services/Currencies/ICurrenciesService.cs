using PulsarFit.CORE.Domain;
using PulsarFit.DAL.Services;

namespace PulsarFit.DAL.Services
{
    public interface ICurrenciesService 
        : IBaseCrudService<
            Currency, 
            CurrencyInsertRequest, 
            CurrencyUpdateRequest, 
            CurrencySearchRequest, 
            CurrencySearchResponse, 
            CurrencyDTO
            > {}
}
