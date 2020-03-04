namespace MyCalisthenicApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class MembershipsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
