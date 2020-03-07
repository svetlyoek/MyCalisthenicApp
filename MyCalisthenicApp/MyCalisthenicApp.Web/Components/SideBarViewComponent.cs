namespace MyCalisthenicApp.Web.Components
{
    using Microsoft.AspNetCore.Mvc;

    [ViewComponent(Name ="SideBar")]
    public class SideBarViewComponent : ViewComponent
    {
        public SideBarViewComponent()
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
