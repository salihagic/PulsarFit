using Microsoft.Extensions.DependencyInjection;
using PulsarFit.CORE.Domain;
using PulsarFit.DAL.Services;
using System;

namespace PulsarFit.API.Controllers
{
    public class WorkoutsController
        : BaseCrudController<
            Workout,
            WorkoutInsertRequest,
            WorkoutUpdateRequest,
            WorkoutSearchRequest,
            WorkoutSearchResponse,
            WorkoutDTO
            >
    {
        public WorkoutsController(IServiceProvider serviceProvider) 
            : base(serviceProvider, serviceProvider.GetService<IWorkoutsService>()) { }
    }
}
