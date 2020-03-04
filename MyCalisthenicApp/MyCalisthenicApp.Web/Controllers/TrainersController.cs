namespace MyCalisthenicApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class TrainersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
