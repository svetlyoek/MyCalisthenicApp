namespace MyCalisthenicApp.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using MyCalisthenicApp.ViewModels;

    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
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
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        public IActionResult Error404(int statusCode)
        {
            if (statusCode == 404)
            {
                return this.View();
            }

            return this.Redirect("Error");
        }

        public IActionResult ComingSoon()
        {
            return this.View();
        }
    }
}
