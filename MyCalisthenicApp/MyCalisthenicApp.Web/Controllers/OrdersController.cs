namespace MyCalisthenicApp.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
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

            await this.ordersService.CreateOrderAsync(product);

            return this.LocalRedirect($"/Products/Details?id={id}");
        }
    }
}
