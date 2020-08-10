using System;
using PulsarFit.CORE.Domain;
using PulsarFit.DAL.Services;

namespace PulsarFit.DAL.Services
{
    public class CitiesService 
        : BaseCrudService<
            City, 
            CityInsertRequest, 
            CityUpdateRequest, 
            CitySearchRequest, 
            CitySearchResponse, 
            CityDTO
            >, ICitiesService
    {
        public CitiesService(IServiceProvider serviceProvider) : base(serviceProvider){}
    }
}