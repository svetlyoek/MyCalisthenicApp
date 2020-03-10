namespace MyCalisthenicApp.Web.Components
{
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;

    [ViewComponent(Name = "ShoppingBagIndexProductsCount")]
    public class ShoppingBagIndexProductsCountViewComponent : ViewComponent
    {
        private readonly IShoppingBagsService shoppingBagService;

        public ShoppingBagIndexProductsCountViewComponent(IShoppingBagsService shoppingBagService)
        {
            this.shoppingBagService = shoppingBagService;
        }

        public IViewComponentResult Invoke()
        {
            var orderProducts = this.shoppingBagService
                .ShoppingBagProducts()
                .GetAwaiter()
                .GetResult();

            return this.View(orderProducts);
        }
    }
}
