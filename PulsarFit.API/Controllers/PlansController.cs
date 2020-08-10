using Microsoft.Extensions.DependencyInjection;
using PulsarFit.CORE.Domain;
using PulsarFit.DAL.Services;
using System;

namespace PulsarFit.API.Controllers
{
    //Example usage
    //[Authorization(Role.Admin)]
    public class PlansController
        : BaseCrudController<
            Plan,
            PlanInsertRequest,
            PlanUpdateRequest,
            PlanSearchRequest,
            PlanSearchResponse,
            PlanDTO
            >
    {
        public PlansController(IServiceProvider serviceProvider) 
            : base(serviceProvider, serviceProvider.GetService<IPlansService>()) { }
    }
}
