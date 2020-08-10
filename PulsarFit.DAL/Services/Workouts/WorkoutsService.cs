using System;
using PulsarFit.CORE.Domain;

namespace PulsarFit.DAL.Services
{
    public class WorkoutsService
        : BaseCrudService<
            Workout, 
            WorkoutInsertRequest, 
            WorkoutUpdateRequest, 
            WorkoutSearchRequest, 
            WorkoutSearchResponse, 
            WorkoutDTO
            >, IWorkoutsService
    {
        public WorkoutsService(IServiceProvider serviceProvider) : base(serviceProvider){}
    }
}