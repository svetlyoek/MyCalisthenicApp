namespace MyCalisthenicApp.Web.Components
{
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;

    [ViewComponent(Name = "DeliverySupplier")]
    public class DeliverySupplierViewComponent : ViewComponent
    {
        private readonly ISuppliersService suppliersService;

        public DeliverySupplierViewComponent(ISuppliersService suppliersService)
        {
            this.suppliersService = suppliersService;
        }

        public IViewComponentResult Invoke()
        {
            var suppliers = this.suppliersService.GetAllSuppliersAsync()
                .GetAwaiter()
                .GetResult();

            return this.View(suppliers);
        }
    }
}
