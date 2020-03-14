namespace MyCalisthenicApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class PostsController : BaseController
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
