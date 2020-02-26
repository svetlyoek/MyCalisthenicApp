namespace MyCalisthenicApp.Web.Components
{
    using Microsoft.AspNetCore.Mvc;

    [ViewComponent(Name = "HomePopularPrograms")]
    public class HomePopularProgramsViewComponent : ViewComponent
    {
        public HomePopularProgramsViewComponent()
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
