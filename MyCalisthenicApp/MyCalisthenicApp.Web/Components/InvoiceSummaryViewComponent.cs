namespace MyCalisthenicApp.Web.Components
{
    using Microsoft.AspNetCore.Mvc;

    [ViewComponent(Name ="InvoiceSummary")]
    public class InvoiceSummaryViewComponent : ViewComponent
    {
        public InvoiceSummaryViewComponent()
        {
            //TODO
            //Inject service here
        }

        //TODO Async
        public IViewComponentResult Invoke()
        {
            //TODO View-list from latest n count of posts

            return View();
        }
    }
}
