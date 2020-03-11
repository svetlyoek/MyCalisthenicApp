namespace MyCalisthenicApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class BlogsController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Details()
        {
            return this.View();
        }
    }
}
