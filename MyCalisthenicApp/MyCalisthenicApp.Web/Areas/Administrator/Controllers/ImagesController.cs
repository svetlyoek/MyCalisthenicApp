namespace MyCalisthenicApp.Web.Areas.Administrator.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Images;

    public class ImagesController : AdministratorController
    {
        private readonly IImagesService imagesService;
        private readonly IPostsService postsService;
        private readonly IProductsService productsService;
        private readonly IProgramsService programsService;
        private readonly IExercisesService exercisesService;

        public ImagesController(
            IImagesService imagesService,
            IPostsService postsService,
            IProductsService productsService,
            IProgramsService programsService,
            IExercisesService exercisesService)
        {
            this.imagesService = imagesService;
            this.postsService = postsService;
            this.productsService = productsService;
            this.programsService = programsService;
            this.exercisesService = exercisesService;
        }

        public async Task<IActionResult> All()
        {
            var images = await this.imagesService.GetAllImagesForAdminAsync();

            return this.View(images);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var image = await this.imagesService.GetImageByIdAsync(id);

            return this.View(image);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ImageAdminEditViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.imagesService.EditImageAsync(inputModel);

            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> Create()
        {
            var posts = await this.postsService.GetAllPostsForAdminAsync();

            var products = await this.productsService.GetProductsForAdminAsync();

            var exercises = await this.exercisesService.GetAllExercisesForAdminAsync();

            var programs = await this.programsService.GetAllProgramsForAdminAsync();

            var imageCreateViewModel = new ImageAdminCreateViewModel();

            imageCreateViewModel.Posts = posts
               .Select(c => new List<string> { c.Id, c.Title })
               .SelectMany(c => c);

            imageCreateViewModel.Products = products
              .Select(c => new List<string> { c.Id, c.Name })
              .SelectMany(c => c);

            imageCreateViewModel.Exercises = exercises
             .Select(c => new List<string> { c.Id, c.Name })
             .SelectMany(c => c);

            imageCreateViewModel.Programs = programs
            .Select(c => new List<string> { c.Id, c.Title })
            .SelectMany(c => c);

            return this.View(imageCreateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ImageAdminCreateViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.imagesService.CreateImageAsync(inputModel);

            return this.RedirectToAction("All");
        }
    }
}
