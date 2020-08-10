using Microsoft.Extensions.DependencyInjection;
using System;
using PulsarFit.CORE.Domain;
using PulsarFit.DAL.Services;

namespace PulsarFit.WEB.Controllers
{
    public class CitiesController
        : BaseCrudController<
            City,
            CityInsertRequest,
            CityUpdateRequest,
            CitySearchRequest,
            CitySearchResponse,
            CityDTO
            >
    {
        public CitiesController(IServiceProvider serviceProvider) : base(serviceProvider, serviceProvider.GetService<ICitiesService>()) { }
    }
}
