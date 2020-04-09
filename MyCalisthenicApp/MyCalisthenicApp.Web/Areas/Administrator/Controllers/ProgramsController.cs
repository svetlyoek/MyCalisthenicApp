namespace MyCalisthenicApp.Web.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Programs;

    public class ProgramsController : AdministratorController
    {
        private readonly IProgramsService programsService;
        private readonly ICategoriesService categoriesService;

        public ProgramsController(IProgramsService programsService, ICategoriesService categoriesService)
        {
            this.programsService = programsService;
            this.categoriesService = categoriesService;
        }

        public async Task<IActionResult> All()
        {
            var programs = await this.programsService.GetAllProgramsForAdminAsync();

            return this.View(programs);
        }

        public async Task<IActionResult> Likes(string id)
        {
            var likes = await this.programsService.GetAllLikesByProgramIdAsync(id);

            return this.View(likes);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var program = await this.programsService.GetProgramByIdAsync(id);

            return this.View(program);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProgramAdminEditViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.programsService.EditProgramAsync(inputModel);

            return this.RedirectToAction("All");
        }

        public IActionResult Create()
        {
            var categories = this.categoriesService.GetAllProgramCategories();

            var programViewModel = new ProgramAdminCreateViewModel
            {
                Categories = categories,
            };

            return this.View(programViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProgramAdminCreateViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.programsService.CreateProgramAsync(inputModel);

            return this.RedirectToAction("All");
        }
    }
}
