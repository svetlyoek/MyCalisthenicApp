namespace MyCalisthenicApp.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;

    public class ProductsController : BaseController
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await this.productsService.GetAllProductsAsync();

            return this.View(products);
        }

        public IActionResult Details()
        {
            return this.View();
        }

        public async Task<IActionResult> Filter(string name)
        {
            var products = await this.productsService.GetProductsByCategory(name);

            return this.View("Index", products);
        }
    }
}
