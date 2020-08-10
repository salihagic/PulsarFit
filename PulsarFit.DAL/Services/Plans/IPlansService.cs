using PulsarFit.CORE.Domain;

namespace PulsarFit.DAL.Services
{
    public interface IPlansService
        : IBaseCrudService<
            Plan, 
            PlanInsertRequest, 
            PlanUpdateRequest, 
            PlanSearchRequest, 
            PlanSearchResponse, 
            PlanDTO
            > {}
}
