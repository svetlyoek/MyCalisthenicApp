namespace MyCalisthenicApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class BlogsController : Controller
    {
        public IActionResult Details()
        {
            return this.View();
        }
    }
}
