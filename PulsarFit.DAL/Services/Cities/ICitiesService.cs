using PulsarFit.CORE.Domain;

namespace PulsarFit.DAL.Services
{
    public interface ICitiesService 
        : IBaseCrudService<
            City, 
            CityInsertRequest, 
            CityUpdateRequest, 
            CitySearchRequest, 
            CitySearchResponse, 
            CityDTO
            > {}
}
