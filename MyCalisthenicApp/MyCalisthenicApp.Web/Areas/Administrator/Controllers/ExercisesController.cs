namespace MyCalisthenicApp.Web.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Exercises;

    public class ExercisesController : AdministratorController
    {
        private readonly IExercisesService exercisesService;
        private readonly ICategoriesService categoriesService;

        public ExercisesController(IExercisesService exercisesService, ICategoriesService categoriesService)
        {
            this.exercisesService = exercisesService;
            this.categoriesService = categoriesService;
        }

        public async Task<IActionResult> All()
        {
            var exrecises = await this.exercisesService.GetAllExercisesForAdminAsync();

            return this.View(exrecises);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var exercise = await this.exercisesService.GetExerciseByIdAsync(id);

            return this.View(exercise);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ExerciseAdminEditViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.exercisesService.EditExerciseAsync(inputModel);

            return this.RedirectToAction("All");
        }

        public IActionResult Create()
        {
            var categories = this.categoriesService.GetAllProgramCategories();

            var categoryCreateViewMOdel = new ExerciseAdminCreateViewModel
            {
                Categories = categories,
            };

            return this.View(categoryCreateViewMOdel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExerciseAdminCreateViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.exercisesService.CreateExerciseAsync(inputModel);

            return this.RedirectToAction("All");
        }
    }
}
