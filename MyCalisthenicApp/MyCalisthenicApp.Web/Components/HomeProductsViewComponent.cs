namespace MyCalisthenicApp.Web.Components
{
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;

    [ViewComponent(Name = "HomeProducts")]
    public class HomeProductsViewComponent : ViewComponent
    {
        private readonly IProductsService productsService;

        public HomeProductsViewComponent(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public IViewComponentResult Invoke()
        {
            var products = this.productsService.GetPopularProductsAsync()
                .GetAwaiter()
                .GetResult();

            return this.View(products);
        }
    }
}
