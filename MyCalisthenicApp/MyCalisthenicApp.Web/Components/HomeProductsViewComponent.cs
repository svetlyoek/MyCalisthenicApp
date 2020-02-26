namespace MyCalisthenicApp.Web.Components
{
    using Microsoft.AspNetCore.Mvc;

    [ViewComponent(Name = "HomeProducts")]
    public class HomeProductsViewComponent : ViewComponent
    {
        public HomeProductsViewComponent()
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
