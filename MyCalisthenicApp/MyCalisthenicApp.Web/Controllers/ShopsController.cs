namespace MyCalisthenicApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ShopsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
