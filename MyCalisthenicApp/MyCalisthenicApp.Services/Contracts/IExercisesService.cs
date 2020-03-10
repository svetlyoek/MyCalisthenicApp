namespace MyCalisthenicApp.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyCalisthenicApp.ViewModels.Exercises;

    public interface IExercisesService
    {
        Task<IEnumerable<ExercisesViewModel>> GetExercisesByCategoryId(string id);
    }
}
