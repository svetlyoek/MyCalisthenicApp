namespace MyCalisthenicApp.Web.Components
{
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;

    [ViewComponent(Name = "DeliverySupplier")]
    public class DeliverySupplierViewComponent : ViewComponent
    {
        private readonly IOrdersService ordersService;

        public DeliverySupplierViewComponent(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        public IViewComponentResult Invoke()
        {
            var suppliers = this.ordersService.GetAllSuppliersAsync()
                .GetAwaiter()
                .GetResult();

            return this.View(suppliers);
        }
    }
}
