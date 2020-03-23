namespace MyCalisthenicApp.Web.Components
{
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;

    [ViewComponent(Name = "InvoiceSummary")]
    public class InvoiceSummaryViewComponent : ViewComponent
    {
        private readonly IProductsService productsService;

        public InvoiceSummaryViewComponent(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public IViewComponentResult Invoke()
        {
            var products = this.productsService.GetShoppingBagProductsAsync()
                .GetAwaiter()
                .GetResult();

            return this.View(products);
        }
    }
}
