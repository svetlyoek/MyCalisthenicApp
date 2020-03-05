namespace MyCalisthenicApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using MyCalisthenicApp.ViewModels;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            this._logger = logger;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult About()
        {
            return this.View();
        }

        [HttpGet("~/Views/Home/Privacy.cshtml")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Error404(int statusCode)
        {
            if (statusCode == 404)
            {
                return View();
            }

            return this.Redirect("Error");

        }

        public IActionResult ComingSoon()
        {
            return View();
        }
    }
}
