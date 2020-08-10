using System;
using PulsarFit.CORE.Domain;
using PulsarFit.DAL.Services;

namespace PulsarFit.DAL.Services
{
    public class CountriesService 
        : BaseCrudService<
            Country, 
            CountryInsertRequest, 
            CountryUpdateRequest, 
            CountrySearchRequest, 
            CountrySearchResponse, 
            CountryDTO
            >, ICountriesService
    {
        public CountriesService(IServiceProvider serviceProvider) : base(serviceProvider){}
    }
}