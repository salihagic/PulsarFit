using Microsoft.Extensions.DependencyInjection;
using PulsarFit.CORE.Domain;
using PulsarFit.DAL.Services;
using System;

namespace PulsarFit.API.Controllers
{
    public class ExercisesController
        : BaseCrudController<
            Exercise,
            ExerciseInsertRequest,
            ExerciseUpdateRequest,
            ExerciseSearchRequest,
            ExerciseSearchResponse,
            ExerciseDTO
            >
    {
        public ExercisesController(IServiceProvider serviceProvider) 
            : base(serviceProvider, serviceProvider.GetService<IExercisesService>()) { }
    }
}
