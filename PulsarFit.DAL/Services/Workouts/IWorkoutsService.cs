using PulsarFit.CORE.Domain;

namespace PulsarFit.DAL.Services
{
    public interface IWorkoutsService
        : IBaseCrudService<
            Workout, 
            WorkoutInsertRequest, 
            WorkoutUpdateRequest, 
            WorkoutSearchRequest, 
            WorkoutSearchResponse, 
            WorkoutDTO
            > {}
}
