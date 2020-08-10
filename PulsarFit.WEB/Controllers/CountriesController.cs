using Microsoft.Extensions.DependencyInjection;
using System;
using PulsarFit.CORE.Domain;
using PulsarFit.DAL.Services;

namespace PulsarFit.WEB.Controllers
{
    public class CountriesController
        : BaseCrudController<
            Country,
            CountryInsertRequest,
            CountryUpdateRequest,
            CountrySearchRequest,
            CountrySearchResponse,
            CountryDTO
            >
    {
        public CountriesController(IServiceProvider serviceProvider) : base(serviceProvider, serviceProvider.GetService<ICountriesService>()) { }
    }
}
