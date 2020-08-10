using PulsarFit.CORE.Domain;

namespace PulsarFit.DAL.Services
{
    public interface IExercisesService
        : IBaseCrudService<
            Exercise, 
            ExerciseInsertRequest, 
            ExerciseUpdateRequest, 
            ExerciseSearchRequest, 
            ExerciseSearchResponse, 
            ExerciseDTO
            > {}
}
