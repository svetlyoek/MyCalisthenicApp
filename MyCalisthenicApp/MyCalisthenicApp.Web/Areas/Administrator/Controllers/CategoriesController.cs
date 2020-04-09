namespace MyCalisthenicApp.Web.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Categories;

    public class CategoriesController : AdministratorController
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult CreateBlogCategory()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogCategory(BlogCategoryAdminCreateViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.categoriesService.CreateBlogCategoryAsync(inputModel);

            return this.RedirectToAction("Index", "Home");
        }

        public IActionResult CreateProgramCategory()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProgramCategory(ProgramCategoryAdminCreateViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.categoriesService.CreateProgramCategoryAsync(inputModel);

            return this.RedirectToAction("Index", "Home");
        }

        public IActionResult CreateProductCategory()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductCategory(ProductCategoryAdminCreateViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.categoriesService.CreateProductCategoryAsync(inputModel);

            return this.RedirectToAction("Index", "Home");
        }
    }
}
