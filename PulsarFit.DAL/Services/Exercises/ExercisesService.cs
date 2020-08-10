using System;
using PulsarFit.CORE.Domain;

namespace PulsarFit.DAL.Services
{
    public class ExercisesService
        : BaseCrudService<
            Exercise, 
            ExerciseInsertRequest, 
            ExerciseUpdateRequest, 
            ExerciseSearchRequest, 
            ExerciseSearchResponse, 
            ExerciseDTO
            >, IExercisesService
    {
        public ExercisesService(IServiceProvider serviceProvider) : base(serviceProvider){}
    }
}