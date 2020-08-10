using Microsoft.Extensions.DependencyInjection;
using System;
using PulsarFit.CORE.Domain;
using PulsarFit.DAL.Services;

namespace PulsarFit.WEB.Controllers
{
    public class CurrenciesController
        : BaseCrudController<
            Currency,
            CurrencyInsertRequest,
            CurrencyUpdateRequest,
            CurrencySearchRequest,
            CurrencySearchResponse,
            CurrencyDTO
            >
    {
        public CurrenciesController(IServiceProvider serviceProvider) : base(serviceProvider, serviceProvider.GetService<ICurrenciesService>()) {}
    }
}
