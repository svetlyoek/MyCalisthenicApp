namespace MyCalisthenicApp.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Common;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Coupons;

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

        [HttpPost]
        public async Task<IActionResult> Coupon(CouponViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("Index");
            }

            var products = await this.productsService.GetShoppingBagProductsAsync();

            if (inputModel.Coupon == ServicesConstants.AppDiscountCoupon)
            {
                foreach (var product in products)
                {
                    product.Price -= product.Price * 0.10M;
                }

                return this.View("Index", products);
            }

            return this.RedirectToAction("Index");
        }
    }
}
