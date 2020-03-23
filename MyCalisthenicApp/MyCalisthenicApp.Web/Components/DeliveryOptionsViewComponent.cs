namespace MyCalisthenicApp.Web.Components
{
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.ViewModels.Orders;

    [ViewComponent(Name = "DeliveryOptions")]
    public class DeliveryOptionsViewComponent : ViewComponent
    {
        public DeliveryOptionsViewComponent()
        {
        }

        public IViewComponentResult Invoke(AddressInputViewModel inputModel)
        {
            return this.View(inputModel);
        }
    }
}
