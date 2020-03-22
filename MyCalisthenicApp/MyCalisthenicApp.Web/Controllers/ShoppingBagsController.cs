namespace MyCalisthenicApp.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Coupons;

    [Authorize]
    public class ShoppingBagsController : BaseController
    {
        private readonly IProductsService productsService;
        private readonly IUsersService usersService;

        public ShoppingBagsController(IProductsService productsService, IUsersService usersService)
        {
            this.productsService = productsService;
            this.usersService = usersService;
        }

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

        [HttpPost]
        public async Task<IActionResult> Coupon(CouponViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Index");
            }

            await this.usersService.AddDiscountToUser(inputModel);

            return this.RedirectToAction("Index");
        }
    }
}
