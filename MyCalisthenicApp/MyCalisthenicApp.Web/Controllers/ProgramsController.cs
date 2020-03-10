namespace MyCalisthenicApp.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;

    public class ProgramsController : Controller
    {
        private readonly IProgramsService programsService;
        private readonly ICategoriesService categoriesService;
        private readonly IExercisesService exercisesService;
        private readonly ICommentsService commentsService;

        public ProgramsController(
            IProgramsService programsService,
            ICategoriesService categoriesService,
            IExercisesService exercisesService,
            ICommentsService commentsService)
        {
            this.programsService = programsService;
            this.categoriesService = categoriesService;
            this.exercisesService = exercisesService;
            this.commentsService = commentsService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public async Task<IActionResult> Details(string id)
        {
            var programDetails = await this.programsService
                .GetProgramDetailsByIdAsync(id);

            var category = await this.categoriesService.GetCategoryByProgramId(id);
            programDetails.Category = category;

            var exercises = await this.exercisesService.GetExercisesByCategoryId(category.Id);
            category.Exercises = exercises;

            var comments = await this.commentsService.GetCommentsByCategoryId(category.Id);
            category.Comments = comments;

            return this.View(programDetails);
        }
    }
}
