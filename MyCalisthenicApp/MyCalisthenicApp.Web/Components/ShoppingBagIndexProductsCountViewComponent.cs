namespace MyCalisthenicApp.Web.Components
{
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;

    [ViewComponent(Name = "ShoppingBagIndexProductsCount")]
    public class ShoppingBagIndexProductsCountViewComponent : ViewComponent
    {
        private readonly IOrdersService orderService;

        public ShoppingBagIndexProductsCountViewComponent(IOrdersService orderService)
        {
            this.orderService = orderService;
        }

        public IViewComponentResult Invoke()
        {
            var productsCount = this.orderService
                .ShoppingBagProductsCountAsync()
                .GetAwaiter()
                .GetResult();

            return this.View(productsCount);
        }
    }
}
