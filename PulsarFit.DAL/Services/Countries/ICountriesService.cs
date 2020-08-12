using PulsarFit.CORE.Domain;

namespace PulsarFit.DAL.Services
{
    public interface ICountriesService 
        : IBaseCrudService<
            Country, 
            CountryInsertRequest, 
            CountryUpdateRequest, 
            CountrySearchRequest, 
            CountrySearchResponse, 
            CountryDTO
            > {}
}
