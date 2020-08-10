using System;
using PulsarFit.CORE.Domain;
using PulsarFit.DAL.Services;

namespace PulsarFit.DAL.Services
{
    public class CurrenciesService 
        : BaseCrudService<
            Currency, 
            CurrencyInsertRequest, 
            CurrencyUpdateRequest, 
            CurrencySearchRequest, 
            CurrencySearchResponse, 
            CurrencyDTO
            >, ICurrenciesService
    {
        public CurrenciesService(IServiceProvider serviceProvider) : base(serviceProvider){}
    }
}