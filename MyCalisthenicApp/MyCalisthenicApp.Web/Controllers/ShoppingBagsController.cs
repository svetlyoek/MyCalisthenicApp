namespace MyCalisthenicApp.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Addresses;
    using MyCalisthenicApp.ViewModels.Coupons;

    [Authorize]
    public class ShoppingBagsController : BaseController
    {
        private readonly IProductsService productsService;
        private readonly IUsersService usersService;
        private readonly IOrdersService ordersService;

        public ShoppingBagsController(IProductsService productsService, IUsersService usersService, IOrdersService ordersService)
        {
            this.productsService = productsService;
            this.usersService = usersService;
            this.ordersService = ordersService;
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

            await this.usersService.AddDiscountToUserAsync(inputModel);

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(AddressInputViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Index");
            }

            await this.ordersService.CreateAddressToOrderAsync(inputModel);

            return this.LocalRedirect("/Payments/Index");
        }
    }
}
