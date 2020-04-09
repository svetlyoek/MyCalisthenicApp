namespace MyCalisthenicApp.Web.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Orders;

    public class OrdersController : AdministratorController
    {
        private readonly IOrdersService ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        public async Task<IActionResult> Edit(string id)
        {
            var order = await this.ordersService.GetOrderByIdAsync(id);

            return this.View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(OrderAdminEditViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.ordersService.EditOrderAsync(inputModel);

            return this.RedirectToAction("Orders", "Users", new { id = inputModel.UserId });
        }

    }
}
