namespace MyCalisthenicApp.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.Web.Common;

    public class OrdersController : BaseController
    {
        private readonly IOrdersService ordersService;
        private readonly IProductsService productsService;

        public OrdersController(IOrdersService ordersService, IProductsService productsService)
        {
            this.ordersService = ordersService;
            this.productsService = productsService;
        }

        [Authorize]
        public async Task<IActionResult> Create(string id)
        {
            var product = await this.productsService.GetProductAsync(id);

            if (product == null)
            {
                return this.LocalRedirect($"/Products/Details?id={id}");
            }

            var result = await this.ordersService.CreateOrderAsync(product);

            if (result)
            {
                this.TempData["InfoMessage"] = GlobalConstants.SuccessfullyAddedProduct;
            }

            if (result == false)
            {
                this.TempData["InfoMessage"] = GlobalConstants.ProductAlreadyExists;
            }

            if (product.IsSoldOut && result == false)
            {
                this.TempData["InfoMessage"] = GlobalConstants.SoldOutProduct;
            }

            return this.LocalRedirect($"/Products/Details?id={id}");
        }

        public async Task<IActionResult> Quantity(string id, int quantity)
        {
            await this.ordersService.ChangeQuantityAsync(id, quantity);

            return this.LocalRedirect("/ShoppingBags/Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delivery(decimal deliveryPrice)
        {
            var result = await this.ordersService.SetDeliveryPriceToOrderAsync(deliveryPrice);

            if (result == false)
            {
                this.TempData["NoOrderMessage"] = GlobalConstants.NoProductsInShoppingBag;
            }

            return this.RedirectToAction("Index", "ShoppingBags");
        }

        [Authorize]
        public async Task<IActionResult> All()
        {
            var orders = await this.ordersService.GetAllOrdersAsync();

            return this.View(orders);
        }
    }
}
