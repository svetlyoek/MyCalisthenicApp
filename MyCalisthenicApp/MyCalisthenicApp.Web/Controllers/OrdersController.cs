namespace MyCalisthenicApp.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;

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
            var product = await this.productsService.GetProduct(id);

            if (product == null)
            {
                return this.LocalRedirect($"/Products/Details?id={id}");
            }

            await this.ordersService.CreateOrderAsync(product);

            return this.LocalRedirect($"/Products/Details?id={id}");
        }

        public async Task<IActionResult> Quantity(string id, int quantity)
        {
            await this.ordersService.ChangeQuantity(id, quantity);

            return this.LocalRedirect("/ShoppingBags/Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delivery(decimal deliveryPrice)
        {
            await this.ordersService.SetDeliveryPriceToOrderAsync(deliveryPrice);

            return this.LocalRedirect("/ShoppingBags/Index");
        }
    }
}
