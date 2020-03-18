namespace MyCalisthenicApp.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;

    public class ShoppingBagsController : BaseController
    {
        private readonly IProductsService productsService;

        public ShoppingBagsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var products = await this.productsService.GetShoppingBagProductsAsync();

            return this.View(products);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await this.productsService.RemoveProductFromShoppingBagAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
