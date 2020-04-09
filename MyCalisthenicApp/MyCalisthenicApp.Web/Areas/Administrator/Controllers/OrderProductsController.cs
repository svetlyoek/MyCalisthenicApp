namespace MyCalisthenicApp.Web.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.OrderProducts;

    public class OrderProductsController : AdministratorController
    {
        private readonly IProductsService productsService;

        public OrderProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public async Task<IActionResult> Edit(string id)
        {
            var orderProduct = await this.productsService.GetOrderProductByIdAsync(id);

            return this.View(orderProduct);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(OrderProductAdminEditViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.productsService.EditOrderProductAsync(inputModel);

            return this.RedirectToAction("All", "Products", new { id = inputModel.OrderId });
        }
    }
}
