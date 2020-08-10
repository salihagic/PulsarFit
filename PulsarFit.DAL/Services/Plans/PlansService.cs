using System;
using PulsarFit.CORE.Domain;

namespace PulsarFit.DAL.Services
{
    public class PlansService
        : BaseCrudService<
            Plan, 
            PlanInsertRequest, 
            PlanUpdateRequest, 
            PlanSearchRequest, 
            PlanSearchResponse, 
            PlanDTO
            >, IPlansService
    {
        public PlansService(IServiceProvider serviceProvider) : base(serviceProvider){}
    }
}