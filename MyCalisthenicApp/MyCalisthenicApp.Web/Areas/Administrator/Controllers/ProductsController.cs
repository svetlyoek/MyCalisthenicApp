namespace MyCalisthenicApp.Web.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Products;

    public class ProductsController : AdministratorController
    {
        private readonly IUsersService usersService;
        private readonly IProductsService productsService;
        private readonly ICategoriesService categoriesService;

        public ProductsController(
            IUsersService usersService,
            IProductsService productsService,
            ICategoriesService categoriesService)
        {
            this.usersService = usersService;
            this.productsService = productsService;
            this.categoriesService = categoriesService;
        }

        public async Task<IActionResult> All(string id)
        {
            var products = await this.usersService.GetAllProductsByOrderIdAsync(id);

            return this.View(products);
        }

        public async Task<IActionResult> Likes(string id)
        {
            var likes = await this.productsService.GetAllLikesByProductIdAsync(id);

            return this.View(likes);
        }

        public async Task<IActionResult> AllProducts()
        {
            var products = await this.productsService.GetProductsForAdminAsync();

            return this.View(products);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var product = await this.productsService.GetAdminProductByIdAsync(id);

            return this.View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductAdminEditViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.productsService.EditProductAsync(inputModel);

            return this.RedirectToAction("AllProducts");
        }

        public IActionResult Create()
        {
            var categories = this.categoriesService.GetAllProductCategories();

            var productViewmodel = new ProductAdminCreateViewModel
            {
                Categories = categories,
            };

            return this.View(productViewmodel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductAdminCreateViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.productsService.CreateProductAsync(inputModel);

            return this.RedirectToAction("AllProducts");
        }
    }
}
