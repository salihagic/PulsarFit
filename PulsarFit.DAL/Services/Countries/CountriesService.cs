using System;
using PulsarFit.CORE.Domain;

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